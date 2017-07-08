using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;

using DSoftCore;
using DSoftLogger;
using DSoftModels;
using DSoftModels.NFe;
using DSoftParameters;
using DSoftModels.Enums;

namespace DSoftBd
{
	public class Bd
	{
		#region Fields

		public string Banco;
		public string Host;
		public string Porta;

		private int _usuario;

		public const string VERSAO_BD = "1.2.8.1";

		#endregion Fields

		#region Constructors

		public Bd(int usuario)
		{
			_usuario = usuario;
		}

		#endregion Constructors

		#region Properties

		public NpgsqlConnection Conn
		{
			get
			{
				NpgsqlConnection conn;

				string conexao = "Server=" + Host + ";Port=" + Porta + ";User Id=dsoft;Password=dsoft2008;Database=" + Banco + ";MaxPoolSize=100;";

				conn = new NpgsqlConnection(conexao);

				try
				{
					conn.Open();

					return conn;
				}
				catch (NpgsqlException e)
				{
					Logger.Instance.Error(e, _usuario);

					return null;
				}
			}
		}

		#endregion Properties

		#region Methods

		public bool AbrirConhecimento(int indice)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set situacao = 'A' where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("indice", indice));
			return ExecCommand(com);
		}

		public void AdicionaItensPedido(Pedido pedido, int usuario)
		{
			int numero;

			// Primeiro pegamos o número do último item do pedido para dar sequência
			NpgsqlCommand com = new NpgsqlCommand("select numero from pedidos_itens where pedido = :pedido order by numero desc limit 1", Conn);
			com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));

			numero = getInt(com);

			foreach (ItemPedido item in pedido.ItensPedido)
			{
				if (!item.Secundario)
				{
					com = new NpgsqlCommand("insert into pedidos_itens(pedido, numero, produto, unitario, fracao, preco, observacao, usuario, vendedor) " +
						"values(:pedido, :numero, :produto, :unitario, :qtd, :preco, :obs, :usuario, :vendedor) returning indice", Conn);

					com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
					com.Parameters.Add(new NpgsqlParameter("numero", ++numero));
					com.Parameters.Add(new NpgsqlParameter("produto", item.Produto));
					com.Parameters.Add(new NpgsqlParameter("unitario", item.Unitario));
					com.Parameters.Add(new NpgsqlParameter("qtd", item.Quantidade));
					com.Parameters.Add(new NpgsqlParameter("preco", item.Preco));
					com.Parameters.Add(new NpgsqlParameter("obs", item.Observacao));
					com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
					com.Parameters.Add(new NpgsqlParameter("vendedor", pedido.Vendedor.Codigo));

					NpgsqlDataReader dr = com.ExecuteReader();

					if (dr.Read())
					{
						int indice = Convert.ToInt32(dr[0]);

						foreach (ItemAdicional adicional in item.ItensAdicionais)
						{
							NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
								"values (:descricao, :valor, :pedido, :item_adicional, :indice_item)", Conn);
							add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
							add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
							add_item.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
							add_item.Parameters.Add(new NpgsqlParameter("item_adicional", numero));
							add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice));
							add_item.ExecuteNonQuery();
						}
					}
				}
				else
				{
					com = new NpgsqlCommand("insert into pedidos_itens(pedido, numero, produto, fracao, observacao, usuario, vendedor) " +
						"values(:pedido, :numero, :produto, :qtd, :obs, :usuario, :vendedor) returning indice", Conn);

					com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
					com.Parameters.Add(new NpgsqlParameter("numero", numero));
					com.Parameters.Add(new NpgsqlParameter("produto", item.Produto));
					com.Parameters.Add(new NpgsqlParameter("qtd", item.Quantidade));
					com.Parameters.Add(new NpgsqlParameter("obs", item.Observacao));
					com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
					com.Parameters.Add(new NpgsqlParameter("vendedor", pedido.Vendedor.Codigo));

					NpgsqlDataReader dr = com.ExecuteReader();

					if (dr.Read())
					{
						int indice = Convert.ToInt32(dr[0]);

						foreach (ItemAdicional adicional in item.ItensAdicionais)
						{
							NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
								"values (:descricao, :valor, :pedido, :item_adicional, :indice_item)", Conn);
							add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
							add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
							add_item.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
							add_item.Parameters.Add(new NpgsqlParameter("item_adicional", numero));
							add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice));
							add_item.ExecuteNonQuery();
						}
					}
				}
			}

			RecalculaTotalPedido(pedido.Numero);
		}

		public bool AdicionarItemAdicional(ItemAdicional item)
		{
			NpgsqlCommand com = new NpgsqlCommand("select dsoft_adicionar_item_adicional(:descricao, :valor);", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", item.Descricao.Trim()));
			com.Parameters.Add(new NpgsqlParameter("valor", item.Valor));

			NpgsqlDataReader dr = com.ExecuteReader();

			return dr.Read();
		}

		public bool AdicionarItemAdicional(ItemAdicional item, long produto)
		{
			NpgsqlCommand com = new NpgsqlCommand("select dsoft_adicionar_item_adicional(:descricao, :valor, :produto);", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", DbType.String));
			com.Parameters.Add(new NpgsqlParameter("valor", DbType.Decimal));
			com.Parameters.Add(new NpgsqlParameter("produto", DbType.Int64));
			com.Parameters["descricao"].Value = item.Descricao.Trim();
			com.Parameters["valor"].Value = item.Valor;
			com.Parameters["produto"].Value = produto;

			NpgsqlDataReader dr = com.ExecuteReader();

			return dr.Read();
		}

		public bool AdicionarItemAdicional(ItemAdicional item, ProdutoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select dsoft_adicionar_item_adicional_tipo(:descricao, :valor, :tipo);", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", DbType.String));
			com.Parameters.Add(new NpgsqlParameter("valor", DbType.Decimal));
			com.Parameters.Add(new NpgsqlParameter("tipo", DbType.Int32));
			com.Parameters["descricao"].Value = item.Descricao.Trim();
			com.Parameters["valor"].Value = item.Valor;
			com.Parameters["tipo"].Value = tipo.Codigo;

			NpgsqlDataReader dr = com.ExecuteReader();

			return dr.Read();
		}

		public bool AlterarCaixa(Caixa caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_caixa(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", caixa.Descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarCliente(Cliente cliente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_clientes set nome = :nome, " +
														"nascimento = :nascimento, " +
														"tipo = :tipo, " +
														"documento = :documento, " +
														"inscricao_estadual = :insc_estadual, " +
														"inscricao_suframa = :insc_suframa, " +
														"rg = :rg, " +
														"isento_icms = :isento_icms, " +
														"tel1 = :tel1, " +
														"tel2 = :tel2, " +
														"celular = :celular, " +
														"endereco = :endereco, " +
														"numero = :numero, " +
														"complemento = :complemento, " +
														"bairro = :bairro, " +
														"cidade = :cidade, " +
														"estado = :estado, " +
														"pais = :pais, " +
														"cep = :cep, " +
														"referencia = :referencia, " +
														"observacao = :observacao, " +
														"alterado_usuario = :cod_usuario, " +
														"grupo = :grupo, " +
														"pai = :pai, " +
														"mae = :mae, " +
														"conjuge = :conjuge, " +
														"profissao = :profissao, " +
														"senha = :senha, " +
														"contato = :contato, " +
														"email = :email, " +
														"site = :site, " +
														"tabela_precos = :tabela, " +
														"taxa_de_entrega = :taxa, " +
														"tipo_cliente = :tipo_cliente, " +
														"vencimento_mensalidade = :vencimento_mensalidade, " +
														"valor_mensalidade = :valor_mensalidade, " +
														"funcionario = :funcionario, " +
														"aux_tel = :auxiliar " +
														"where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", cliente.Nome));
				com.Parameters.Add(new NpgsqlParameter("nascimento", cliente.Nascimento));
				com.Parameters.Add(new NpgsqlParameter("tipo", cliente.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("documento", cliente.Documento));
				com.Parameters.Add(new NpgsqlParameter("insc_estadual", cliente.InscricaoEstadual));
				com.Parameters.Add(new NpgsqlParameter("insc_suframa", cliente.InscricaoSuframa));
				com.Parameters.Add(new NpgsqlParameter("rg", cliente.Rg));
				com.Parameters.Add(new NpgsqlParameter("isento_icms", cliente.IsentoICMS));
				com.Parameters.Add(new NpgsqlParameter("tel1", cliente.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", cliente.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("celular", cliente.Celular));
				com.Parameters.Add(new NpgsqlParameter("endereco", cliente.Endereco));
				com.Parameters.Add(new NpgsqlParameter("numero", cliente.Numero));
				com.Parameters.Add(new NpgsqlParameter("complemento", cliente.Complemento));
				com.Parameters.Add(new NpgsqlParameter("bairro", cliente.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cidade", cliente.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", cliente.Estado));
				com.Parameters.Add(new NpgsqlParameter("pais", cliente.Pais));
				com.Parameters.Add(new NpgsqlParameter("cep", cliente.Cep));
				com.Parameters.Add(new NpgsqlParameter("referencia", cliente.Referencia));
				com.Parameters.Add(new NpgsqlParameter("observacao", cliente.Observacao));
				com.Parameters.Add(new NpgsqlParameter("cod_usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("grupo", cliente.Grupo));
				com.Parameters.Add(new NpgsqlParameter("pai", cliente.Pai));
				com.Parameters.Add(new NpgsqlParameter("mae", cliente.Mae));
				com.Parameters.Add(new NpgsqlParameter("conjuge", cliente.Conjuge));
				com.Parameters.Add(new NpgsqlParameter("profissao", cliente.Profissao));
				com.Parameters.Add(new NpgsqlParameter("senha", ""));
				com.Parameters.Add(new NpgsqlParameter("contato", cliente.Contato));
				com.Parameters.Add(new NpgsqlParameter("email", cliente.Email));
				com.Parameters.Add(new NpgsqlParameter("site", cliente.Site));
				com.Parameters.Add(new NpgsqlParameter("tabela", cliente.Tabela));
				com.Parameters.Add(new NpgsqlParameter("taxa", cliente.TaxaDeEntrega));
				com.Parameters.Add(new NpgsqlParameter("tipo_cliente", cliente.ClienteTipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("vencimento_mensalidade", cliente.VencimentoMensalidade));
				com.Parameters.Add(new NpgsqlParameter("valor_mensalidade", cliente.ValorMensalidade));

				if (cliente.Funcionario == null)
				{
					com.Parameters.Add(new NpgsqlParameter("funcionario", null));
				}
				else
				{
					com.Parameters.Add(new NpgsqlParameter("funcionario", cliente.Funcionario.Codigo));
				}

				com.Parameters.Add(new NpgsqlParameter("auxiliar", cliente.Auxiliar));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarCompra(Compra compra, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_limpar_compra(:usuario, " +
																				":compra)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("compra", compra.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				com.CommandText = "select dsoft_novo_compra_item(:compra, :numero, :produto, :unitario, :quantidade, :total)";

				for (int i = 0; i < compra.Itens; i++)
				{
					com.Parameters.Clear();

					com.Parameters.Add(new NpgsqlParameter("compra", compra.Codigo));
					com.Parameters.Add(new NpgsqlParameter("numero", compra.Item[i].Numero));
					com.Parameters.Add(new NpgsqlParameter("produto", compra.Item[i].Produto));
					com.Parameters.Add(new NpgsqlParameter("unitario", compra.Item[i].Unitario));
					com.Parameters.Add(new NpgsqlParameter("quantidade", compra.Item[i].Quantidade));
					com.Parameters.Add(new NpgsqlParameter("total", compra.Item[i].Total));

					dr = com.ExecuteReader();

					if (!dr.Read() || !bool.Parse(dr[0].ToString()))
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarDespesa(Despesa despesa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_despesa(:usuario, " +
																					":indice, " +
																					":tipo, " +
																					":fornecedor, " +
																					":valor, " +
																					":vencimento, " +
																					":documento, " +
																					":observacao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("indice", despesa.Indice));
				com.Parameters.Add(new NpgsqlParameter("tipo", despesa.Tipo));
				com.Parameters.Add(new NpgsqlParameter("fornecedor", despesa.Fornecedor));
				com.Parameters.Add(new NpgsqlParameter("valor", despesa.Valor));
				com.Parameters.Add(new NpgsqlParameter("vencimento", despesa.Vencimento));
				com.Parameters.Add(new NpgsqlParameter("documento", despesa.Documento));
				com.Parameters.Add(new NpgsqlParameter("observacao", despesa.Observacao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarDespesaTipo(DespesaTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_despesa_tipo(:codigo, :nome, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", tipo.Descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarEmitente(Emitente emitente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_emitente(:razao_social, " +
														":nome_fantasia, " +
														":cnpj, " +
														":insc_estadual, " +
														":cnae_fiscal, " +
														":insc_municipal, " +
														":logradouro, " +
														":numero, " +
														":complemento, " +
														":bairro, " +
														":cep, " +
														":pais, " +
														":uf, " +
														":municipio, " +
														":telefone, " +
														":rntrc);");

				com.Parameters.Add(new NpgsqlParameter("razao_social", emitente.RazaoSocial));
				com.Parameters.Add(new NpgsqlParameter("nome_fantasia", emitente.NomeFantasia));
				com.Parameters.Add(new NpgsqlParameter("cnpj", emitente.Cnpj));
				com.Parameters.Add(new NpgsqlParameter("insc_estadual", emitente.InscricaoEstadual));
				com.Parameters.Add(new NpgsqlParameter("cnae_fiscal", emitente.CNAEFiscal));
				com.Parameters.Add(new NpgsqlParameter("insc_municipal", emitente.InscricaoMunicipal));
				com.Parameters.Add(new NpgsqlParameter("logradouro", emitente.Logradouro));
				com.Parameters.Add(new NpgsqlParameter("numero", emitente.Numero));
				com.Parameters.Add(new NpgsqlParameter("complemento", emitente.Complemento));
				com.Parameters.Add(new NpgsqlParameter("bairro", emitente.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cep", emitente.Cep));
				com.Parameters.Add(new NpgsqlParameter("pais", emitente.Pais));
				com.Parameters.Add(new NpgsqlParameter("uf", emitente.Uf));
				com.Parameters.Add(new NpgsqlParameter("municipio", emitente.Municipio));
				com.Parameters.Add(new NpgsqlParameter("telefone", emitente.Telefone));
				com.Parameters.Add(new NpgsqlParameter("rntrc", emitente.RNTRC));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarEntrada(FluxoDeCaixa entrada, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("SELECT dsoft_altera_entrada(:indice, :usuario, :caixa, :cliente, :forma, :valor, :observacao, :data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", entrada.Indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("cliente", entrada.Cliente));
				com.Parameters.Add(new NpgsqlParameter("forma", entrada.Forma.ToString()));
				com.Parameters.Add(new NpgsqlParameter("valor", entrada.Valor));
				com.Parameters.Add(new NpgsqlParameter("observacao", entrada.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", entrada.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return Convert.ToBoolean(dr[0]);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarEstoque(ProdutoEstoque estoque)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_estoque(:produto, :minimo, :maximo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", estoque.Codigo));
				com.Parameters.Add(new NpgsqlParameter("minimo", estoque.Minimo));
				com.Parameters.Add(new NpgsqlParameter("maximo", estoque.Maximo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarFornecedor(Fornecedor fornecedor)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_fornecedores set nome = :nome," +
																				"cnpj = :cnpj, " +
																				"tel1 = :tel1, " +
																				"tel2 = :tel2, " +
																				"endereco = :endereco, " +
																				"bairro = :bairro, " +
																				"cidade = :cidade, " +
																				"estado = :estado, " +
																				"pais = :pais, " +
																				"cep = :cep, " +
																				"contato = :contato, " +
																				"tipo = :tipo, " +
																				"obs = :obs, " +
																				"email = :email " +
																				"where codigo = :codigo;");

				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("codigo", fornecedor.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", fornecedor.Nome));
				com.Parameters.Add(new NpgsqlParameter("cnpj", fornecedor.Cnpj));
				com.Parameters.Add(new NpgsqlParameter("tel1", fornecedor.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", fornecedor.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("endereco", fornecedor.Endereco));
				com.Parameters.Add(new NpgsqlParameter("bairro", fornecedor.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cidade", fornecedor.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", fornecedor.Estado));
				com.Parameters.Add(new NpgsqlParameter("pais", fornecedor.Pais));
				com.Parameters.Add(new NpgsqlParameter("cep", fornecedor.Cep));
				com.Parameters.Add(new NpgsqlParameter("contato", fornecedor.Contato));
				com.Parameters.Add(new NpgsqlParameter("tipo", fornecedor.Tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("obs", fornecedor.Observacao));
				com.Parameters.Add(new NpgsqlParameter("email", fornecedor.Email));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarGrupoClientes(ClienteGrupo grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update clientes_grupos set nome = :nome, taxa_entrega = :taxa, taxa_servico = :servico, "
					+ "cidade = :cidade, estado = :estado where codigo = :codigo;", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", grupo.Nome));
				com.Parameters.Add(new NpgsqlParameter("taxa", grupo.Taxa));
				com.Parameters.Add(new NpgsqlParameter("servico", grupo.TaxaDeServico));
				com.Parameters.Add(new NpgsqlParameter("cidade", grupo.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", grupo.Estado));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool AlterarGrupoRecursos(int codigo, string descricao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_grupo_recursos(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarGrupoTributario(GrupoTributario grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_grupo_tributario(:codigo, :nome, :icms, :ipi, :pis, :cofins, :csll, :irrf, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", grupo.Nome));
				com.Parameters.Add(new NpgsqlParameter("icms", grupo.ICMS));
				com.Parameters.Add(new NpgsqlParameter("ipi", grupo.IPI));
				com.Parameters.Add(new NpgsqlParameter("pis", grupo.PIS));
				com.Parameters.Add(new NpgsqlParameter("cofins", grupo.COFINS));
				com.Parameters.Add(new NpgsqlParameter("csll", grupo.CSLL));
				com.Parameters.Add(new NpgsqlParameter("irrf", grupo.IRRF));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (bool.Parse(dr[0].ToString()))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarLocal(Local local)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_local(:codigo, :nome, :descricao, :tipo, :responsavel)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", local.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", local.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", local.Descricao));
				com.Parameters.Add(new NpgsqlParameter("tipo", local.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("responsavel", local.Reponsavel));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarManifesto(Manifesto manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update manifestos set rntrc = :rntrc, ciot = :ciot, uf_entrega = :uf_entrega, mun_entrega = :mun_entrega, chave = :chave where indice = :indice");
				com.Parameters.Add(new NpgsqlParameter("rntrc", manifesto.RNTRC));
				com.Parameters.Add(new NpgsqlParameter("ciot", manifesto.CIOT));
				com.Parameters.Add(new NpgsqlParameter("uf_entrega", manifesto.UFEntrega));
				com.Parameters.Add(new NpgsqlParameter("mun_entrega", manifesto.MunEntrega));
				com.Parameters.Add(new NpgsqlParameter("chave", manifesto.Chave));
				com.Parameters.Add(new NpgsqlParameter("indice", manifesto.Indice));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarMaterial(Material material)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_material(:codigo, :nome, :descricao, :fornecedor, :tipo, :medida, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", material.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", material.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", material.Descricao));
				com.Parameters.Add(new NpgsqlParameter("fornecedor", material.Fornecedor));
				com.Parameters.Add(new NpgsqlParameter("tipo", material.Tipo));
				com.Parameters.Add(new NpgsqlParameter("medida", material.Medida));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarMedida(Medida medida)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update medidas set descricao = :descricao, abreviatura = :abreviatura where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", medida.Codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", medida.Descricao));
				com.Parameters.Add(new NpgsqlParameter("abreviatura", medida.Abreviatura));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarOrdemTransporte(OrdemDeColeta ordem)
		{
			try
			{
				int zero = 0;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_ordem_transporte(:ordem, " +
																							":cfop, " +
																							":natop, " +
																							":rntrc, " +
																							":cst, " +
																							":bc, " +
																							":aliq, " +
																							":vICMS, " +
																							":natureza, " +
																							":quantidade, " +
																							":especie, " +
																							":peso, " +
																							":m3l, " +
																							":nota_fiscal, " +
																							":serie, " +
																							":valor_mercadoria, " +
																							":valor_frete, " +
																							":usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("cfop", ordem.CFOP));
				com.Parameters.Add(new NpgsqlParameter("natop", ordem.NaturezaDaOperacao));
				com.Parameters.Add(new NpgsqlParameter("rntrc", ordem.RNTRC));
				com.Parameters.Add(new NpgsqlParameter("cst", ordem.CST));
				com.Parameters.Add(new NpgsqlParameter("bc", ordem.ValorBCICMS));
				com.Parameters.Add(new NpgsqlParameter("aliq", ordem.AliquotaICMS));
				com.Parameters.Add(new NpgsqlParameter("vICMS", ordem.ValorICMS));
				com.Parameters.Add(new NpgsqlParameter("ordem", ordem.Indice));
				com.Parameters.Add(new NpgsqlParameter("natureza", ordem.ProdudoPredominante));
				com.Parameters.Add(new NpgsqlParameter("quantidade", ordem.Quantidade[0]));
				com.Parameters.Add(new NpgsqlParameter("especie", ordem.TipoMedida[0]));
				com.Parameters.Add(new NpgsqlParameter("peso", zero));
				com.Parameters.Add(new NpgsqlParameter("m3l", zero));
				com.Parameters.Add(new NpgsqlParameter("nota_fiscal", ordem.DocNota[0]));
				com.Parameters.Add(new NpgsqlParameter("serie", ordem.DocSerie[0]));
				com.Parameters.Add(new NpgsqlParameter("valor_mercadoria", ordem.ValorMercadoria));
				com.Parameters.Add(new NpgsqlParameter("valor_frete", ordem.ValorFrete));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarPagamento(FluxoDeCaixa pagamento, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_pagamento(:indice, " +
																				":usuario, " +
																				":caixa, " +
																				":valor, " +
																				":recurso, " +
																				":observacao, " +
																				":data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", pagamento.Indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", pagamento.Valor));
				com.Parameters.Add(new NpgsqlParameter("recurso", pagamento.Recurso));
				com.Parameters.Add(new NpgsqlParameter("observacao", pagamento.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", pagamento.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return Convert.ToBoolean(dr[0]);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarPedido(Pedido pedido, Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_limpar_pedido(:pedido, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido.NumeroPedido()));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

				if (!getBool(com))
				{
					return false;
				}

				for (int i = 0; i < pedido.ItensQtd; i++)
				{
					string msg;

					if (pedido.ItensPedido[i].Situacao == 'C')
						continue;

					com.Parameters.Clear();

					if (pedido.ItensPedido[i].Secundario)
					{
						com.CommandText = "insert into pedidos_itens (pedido, numero, produto, fracao, observacao, usuario) " +
							"values (:pedido, :numero, :produto, :qtd, :obs, :usuario) returning indice";

						com.Parameters.Add(new NpgsqlParameter("pedido", pedido.NumeroPedido()));
						com.Parameters.Add(new NpgsqlParameter("numero", pedido.ItensPedido[i].Numero));
						com.Parameters.Add(new NpgsqlParameter("produto", pedido.ItensPedido[i].Produto));
						com.Parameters.Add(new NpgsqlParameter("qtd", pedido.ItensPedido[i].Quantidade));
						com.Parameters.Add(new NpgsqlParameter("obs", pedido.ItensPedido[i].Observacao));
						com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

						NpgsqlDataReader dr = com.ExecuteReader();

						dr.Read();

						int indice_item = Convert.ToInt32(dr[0]);

						if (pedido.ItensPedido[i].ItensAdicionais.Count > 0)
						{
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
									"values (:descricao, :valor, :pedido, :item_adicional, :indice_item)", Conn);
								add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
								add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
								add_item.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
								add_item.Parameters.Add(new NpgsqlParameter("item_adicional", pedido.ItensPedido[i].Numero));
								add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice_item));
								add_item.ExecuteNonQuery();
							}
						}
					}
					else
					{
						com.CommandText = "insert into pedidos_itens (pedido, produto, fracao, preco, observacao, usuario, numero, unitario) " +
							"values (:pedido, :produto, :fracao, :preco, :observacao, :usuario, :numero, :unitario) returning indice";

						com.Parameters.Add(new NpgsqlParameter("pedido", pedido.NumeroPedido()));
						com.Parameters.Add(new NpgsqlParameter("produto", pedido.ItensPedido[i].Produto));
						com.Parameters.Add(new NpgsqlParameter("fracao", pedido.ItensPedido[i].Quantidade));
						com.Parameters.Add(new NpgsqlParameter("preco", pedido.ItensPedido[i].Preco));
						com.Parameters.Add(new NpgsqlParameter("observacao", pedido.ItensPedido[i].Observacao));
						com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
						com.Parameters.Add(new NpgsqlParameter("numero", pedido.ItensPedido[i].Numero));
						com.Parameters.Add(new NpgsqlParameter("unitario", pedido.ItensPedido[i].Unitario));

						NpgsqlDataReader dr = com.ExecuteReader();

						dr.Read();

						int indice_item = Convert.ToInt32(dr[0]);

						if (pedido.ItensPedido[i].ItensAdicionais.Count > 0)
						{
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
									"values (:descricao, :valor, :pedido, :item_pedido, :indice_item)", Conn);
								add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
								add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
								add_item.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
								add_item.Parameters.Add(new NpgsqlParameter("item_pedido", pedido.ItensPedido[i].Numero));
								add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice_item));
								add_item.ExecuteNonQuery();
							}
						}
					}
				}

				com = new NpgsqlCommand("update pedidos set cliente = :cliente, observacao = :observacao, total = :total, taxa_entrega = :taxa, troco = :troco, retira = :retira where indice = :pedido");
				com.Parameters.Add(new NpgsqlParameter("cliente", pedido.Cliente));
				com.Parameters.Add(new NpgsqlParameter("observacao", pedido.Observacao));
				com.Parameters.Add(new NpgsqlParameter("total", pedido.TotalPedido));
				com.Parameters.Add(new NpgsqlParameter("taxa", pedido.TaxaDeEntrega));
				com.Parameters.Add(new NpgsqlParameter("troco", pedido.Troco));
				com.Parameters.Add(new NpgsqlParameter("retira", pedido.Retirar));
				com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
				ExecCommand(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarPreco(long produto, int tabela, decimal preco, decimal tributario, decimal locacao, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update produtos_precos set preco = :preco, " +
														"tributavel = :tributario, " +
														"locacao = :locacao, " +
														"alterado = now(), " +
														"usuario = :usuario " +
														"where produto = :produto and tabela = :tabela;");

				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				com.Parameters.Add(new NpgsqlParameter("tabela", tabela));
				com.Parameters.Add(new NpgsqlParameter("preco", preco));
				com.Parameters.Add(new NpgsqlParameter("tributario", tributario));
				com.Parameters.Add(new NpgsqlParameter("locacao", locacao));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarProduto(Produto produto)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_produto(:codigo, :nome, :tipo, :grupo, :descricao, :grupo_tributario, :medida, :producao, " +
					":fornecedor, :foto, :ncm, :cfop, :ean, :ean_trib, :med_trib, :qtd_trib)");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", produto.Nome));
				com.Parameters.Add(new NpgsqlParameter("tipo", produto.Tipo));
				com.Parameters.Add(new NpgsqlParameter("grupo", produto.Grupo));
				com.Parameters.Add(new NpgsqlParameter("descricao", produto.Descricao));
				com.Parameters.Add(new NpgsqlParameter("grupo_tributario", produto.GrupoTributario));
				com.Parameters.Add(new NpgsqlParameter("medida", produto.Medida.Codigo));
				com.Parameters.Add(new NpgsqlParameter("producao", produto.Producao));

				if (produto.Fornecedor == null)
				{
					long fornecedor = 0;

					com.Parameters.Add(new NpgsqlParameter("fornecedor", fornecedor));
				}
				else
				{
					com.Parameters.Add(new NpgsqlParameter("fornecedor", produto.Fornecedor.Codigo));
				}

				com.Parameters.Add(new NpgsqlParameter("foto", produto.Foto));
				com.Parameters.Add(new NpgsqlParameter("ncm", produto.NCM));
				com.Parameters.Add(new NpgsqlParameter("cfop", produto.CFOP));
				com.Parameters.Add(new NpgsqlParameter("ean", produto.EAN));
				com.Parameters.Add(new NpgsqlParameter("ean_trib", produto.EANTrib));
				com.Parameters.Add(new NpgsqlParameter("med_trib", produto.MedidaTributavel.Codigo));
				com.Parameters.Add(new NpgsqlParameter("qtd_trib", produto.QuantidadeTributavel));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarProdutoGrupo(int codigo, string descricao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_produto_grupo(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarProdutoTipo(ProdutoTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update produtos_tipos set nome = :nome, " +
														"descricao = :descricao, " +
														"producao = :producao, " +
														"estoque = :estoque, " +
														"soma = :soma, " +
														"impressora_externa = :impressora, " +
														"imprime_total = :imprime_total, " +
														"adicionais = :adicionais, " +
														"meio = :meio, " +
														"fracao = :fracao, " +
														"permite_locacao = :permite_locacao, " +
														"intervalo_locacao = :intervalo_locacao, " +
														"periodo_locacao = :periodo_locacao " +
														"where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", tipo.Descricao));
				com.Parameters.Add(new NpgsqlParameter("producao", tipo.Producao));
				com.Parameters.Add(new NpgsqlParameter("estoque", tipo.Estoque));
				com.Parameters.Add(new NpgsqlParameter("soma", tipo.Soma));
				com.Parameters.Add(new NpgsqlParameter("impressora", tipo.ImpressoraExterna));
				com.Parameters.Add(new NpgsqlParameter("imprime_total", tipo.ImprimeQuantidadeTotal));
				com.Parameters.Add(new NpgsqlParameter("adicionais", tipo.Adicionais));
				com.Parameters.Add(new NpgsqlParameter("meio", tipo.MeioAMeio));
				com.Parameters.Add(new NpgsqlParameter("fracao", tipo.Fracionado));
				com.Parameters.Add(new NpgsqlParameter("permite_locacao", tipo.PermiteLocacao));
				com.Parameters.Add(new NpgsqlParameter("intervalo_locacao", tipo.IntervaloDeLocacao));
				com.Parameters.Add(new NpgsqlParameter("periodo_locacao", tipo.PeriodoLocacao));

				if (ExecCommand(com))
				{
					if (tipo.LocacaoEspecial.Count > 0)
					{
						foreach (LocacaoEspecial l in tipo.LocacaoEspecial)
						{
							com = new NpgsqlCommand("select dsoft_insert_or_update_locacao_especial(:produto_tipo, :descricao, :periodo)");
							com.Parameters.Add(new NpgsqlParameter("produto_tipo", tipo.Codigo));
							com.Parameters.Add(new NpgsqlParameter("descricao", l.Descricao));
							com.Parameters.Add(new NpgsqlParameter("periodo", l.Periodo));

							ExecCommand(com);
						}
					}

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarRecurso(Recurso recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_recursos set nome = :nome, " +
														"tipo = :tipo, " +
														"alterado_usuario = :usuario, " +
														"nascimento = :nascimento, " +
														"tel1 = :tel1, " +
														"tel2 = :tel2, " +
														"celular = :celular, " +
														"endereco = :endereco, " +
														"cidade = :cidade, " +
														"estado = :estado, " +
														"rg = :rg, " +
														"cpf = :cpf, " +
														"habilitacao = :habilitacao, " +
														"categoria = :categoria, " +
														"email = :email " +
														"where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", recurso.Nome));
				com.Parameters.Add(new NpgsqlParameter("tipo", recurso.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("nascimento", recurso.Nascimento));
				com.Parameters.Add(new NpgsqlParameter("tel1", recurso.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", recurso.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("celular", recurso.Celular));
				com.Parameters.Add(new NpgsqlParameter("endereco", recurso.Endereco));
				com.Parameters.Add(new NpgsqlParameter("cidade", recurso.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", recurso.Estado));
				com.Parameters.Add(new NpgsqlParameter("rg", recurso.Rg));
				com.Parameters.Add(new NpgsqlParameter("cpf", recurso.Cpf));
				com.Parameters.Add(new NpgsqlParameter("habilitacao", recurso.Habilitacao));
				com.Parameters.Add(new NpgsqlParameter("categoria", recurso.Categoria));
				com.Parameters.Add(new NpgsqlParameter("email", recurso.Email));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarRecursoTipo(RecursoTipo recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update recursos_tipos set descricao = :descricao, entrega = :entrega, producao = :producao, comissao_diaria = :com_dia, "
					+ "comissao_nominal = :com_nom, fixo_semanal = :fixo_sem, fixo_mensal = :fixo_mes, valor_entrega = :valor_entrega, diaria = :diaria where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("descricao", recurso.Descricao));
				com.Parameters.Add(new NpgsqlParameter("entrega", recurso.Entrega));
				com.Parameters.Add(new NpgsqlParameter("producao", recurso.Producao));
				com.Parameters.Add(new NpgsqlParameter("com_dia", recurso.ComissaoDiaria));
				com.Parameters.Add(new NpgsqlParameter("com_nom", recurso.ComissaoNominal));
				com.Parameters.Add(new NpgsqlParameter("fixo_sem", recurso.FixoSemanal));
				com.Parameters.Add(new NpgsqlParameter("fixo_mes", recurso.FixoMensal));
				com.Parameters.Add(new NpgsqlParameter("valor_entrega", recurso.ValorEntrega));
				com.Parameters.Add(new NpgsqlParameter("diaria", recurso.Diaria));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarSaida(FluxoDeCaixa saida, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_lanca_saida(:indice, " +
																				":usuario, " +
																				":caixa, " +
																				":valor, " +
																				":observacao, " +
																				":data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", saida.Indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", saida.Valor));
				com.Parameters.Add(new NpgsqlParameter("observacao", saida.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", saida.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarTabela(int codigo, string nome, string descricao)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("update cad_tabelas set nome = :nome, descricao = :descricao where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarTipoClientes(ClienteTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update clientes_tipos set nome = :nome, cliente_interno = :interno, mensalidade = :mensalidade where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("interno", tipo.Interno));
				com.Parameters.Add(new NpgsqlParameter("mensalidade", tipo.Mensalidade));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool AlterarUsuario(Usuario usuario)
		{
			return AlterarUsuario(usuario.Codigo, usuario.Nome, usuario.Senha, usuario.NivelUsuario.Nivel, usuario.Recurso.Codigo);
		}

		public bool AlterarUsuario(int codigo, string nome, string senha, string nivel, int recurso)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("update cad_usuarios set nome = :nome, senha = :senha, nivel = :nivel, recurso = :recurso, alterado = now() "
					+ "where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", nome));
				com.Parameters.Add(new NpgsqlParameter("senha", senha));
				com.Parameters.Add(new NpgsqlParameter("nivel", nivel));
				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AlterarVeiculo(Veiculo veiculo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_veiculos set modelo = :modelo, ano = :ano, cor = :cor, marca = :marca, proprietario = :proprietario, " +
					"endereco = :endereco, cidade = :cidade, estado = :estado, telefone = :telefone, cpf = :cpf, renavam = :renavam, tara = :tara, capkg = :capkg, capm3 = :capm3, rntrc = :rntrc, ie = :ie where placa = :placa");

				com.Parameters.Add(new NpgsqlParameter("placa", veiculo.Placa));
				com.Parameters.Add(new NpgsqlParameter("modelo", veiculo.Modelo));
				com.Parameters.Add(new NpgsqlParameter("ano", veiculo.Ano));
				com.Parameters.Add(new NpgsqlParameter("cor", veiculo.Cor));
				com.Parameters.Add(new NpgsqlParameter("marca", veiculo.Marca));
				com.Parameters.Add(new NpgsqlParameter("proprietario", veiculo.Proprietario));
				com.Parameters.Add(new NpgsqlParameter("endereco", veiculo.Endereco));
				com.Parameters.Add(new NpgsqlParameter("cidade", veiculo.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", veiculo.Estado));
				com.Parameters.Add(new NpgsqlParameter("telefone", veiculo.Telefone));
				com.Parameters.Add(new NpgsqlParameter("cpf", veiculo.Cpf));
				com.Parameters.Add(new NpgsqlParameter("renavam", veiculo.RENAVAM));
				com.Parameters.Add(new NpgsqlParameter("tara", veiculo.Tara));
				com.Parameters.Add(new NpgsqlParameter("capkg", veiculo.CapKg));
				com.Parameters.Add(new NpgsqlParameter("capm3", veiculo.CapM3));
				com.Parameters.Add(new NpgsqlParameter("rntrc", veiculo.RNTRC));
				com.Parameters.Add(new NpgsqlParameter("ie", veiculo.IE));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool AtribuiCupomFiscal(int pedido, int loja, int caixa, long cupom)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update pedidos set loja = :loja, caixa = :caixa, cupom = :cupom where indice = :pedido");

				com.Parameters.Add(new NpgsqlParameter("loja", loja));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("cupom", cupom));
				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int AtribuirErroNFe(string nfe, string msg)
		{
			NpgsqlCommand com = new NpgsqlCommand("update notas_fiscais set situacao = 'R', msg_erro = :msg where nfe = :nfe returning indice;");
			com.Parameters.Add(new NpgsqlParameter("nfe", nfe));
			com.Parameters.Add(new NpgsqlParameter("msg", msg));

			return getInt(com);
		}

		public int AtribuirNumeroConhecimento(int conhecimento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_atribuir_numero_conhecimento(:conhecimento, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("conhecimento", conhecimento));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return 0;

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public bool AtualizarEstoque(long produto, double quantidade)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_atualiza_estoque(:produto, :quantidade, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				com.Parameters.Add(new NpgsqlParameter("quantidade", quantidade));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void Backup()
		{
			try
			{
				string comando = Terminal.PostgreSql() + "\\pg_dump.exe ";
				string argumentos = "-h " + Host + " -p " + Porta + " -U postgres -F c -b -v -f " + Terminal.Backup() + "backup_" + DateTime.Now.ToString("ddMMyy") + ".backup " + Banco;
				System.Diagnostics.Process processo = new System.Diagnostics.Process();

				processo.StartInfo.FileName = comando;
				processo.StartInfo.Arguments = argumentos;

				if (processo.Start())
				{
					while (!processo.HasExited)
					{
						System.Threading.Thread.Sleep(500);
					}
				}
				else
				{
					MessageBox.Show("Não foi possivel iniciar as rotinas de backup!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao executar backup! Se o problema persistir, entre em contato com o suporte." + Environment.NewLine + e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void BaixarProdutos()
		{
			//try
			//{
			//    NpgsqlConnection conn = new NpgsqlConnection("Server=201.93.187.253;Port=5432;User Id=dsoft;Password=dsoft2008;Database=matriz");

			//    conn.Open();

			//    if (conn.State != ConnectionState.Open)
			//    {
			//        MessageBox.Show("Não foi possivel se conectar à matriz.", "DSoft BD");

			//        return;
			//    }

			//    NpgsqlCommand com = new NpgsqlCommand("Select codigo, nome, situacao, descricao, grupo, tipo, grupo_tributario, medida, producao from cad_produtos order by codigo", Conn);

			//    NpgsqlDataReader dr = com.ExecuteReader();

			//    while (dr.Read())
			//    {
			//        NpgsqlCommand com_local = new NpgsqlCommand("select dsoft_sincroniza_produto(:codigo, :nome, :situacao, :descricao, :grupo, :tipo, :grupo_tributario, :medida, :producao)", Conn);

			//        com_local.Parameters.Add(new NpgsqlParameter("codigo", long.Parse(dr["codigo"].ToString())));
			//        com_local.Parameters.Add(new NpgsqlParameter("nome", dr["nome"].ToString()));
			//        com_local.Parameters.Add(new NpgsqlParameter("situacao", dr["situacao"].ToString()));
			//        com_local.Parameters.Add(new NpgsqlParameter("descricao", dr["descricao"].ToString()));
			//        com_local.Parameters.Add(new NpgsqlParameter("grupo", int.Parse(dr["grupo"].ToString())));
			//        com_local.Parameters.Add(new NpgsqlParameter("tipo", int.Parse(dr["tipo"].ToString())));
			//        com_local.Parameters.Add(new NpgsqlParameter("grupo_tributario", int.Parse(dr["grupo_tributario"].ToString())));
			//        com_local.Parameters.Add(new NpgsqlParameter("medida", int.Parse(dr["medida"].ToString())));
			//        com_local.Parameters.Add(new NpgsqlParameter("producao", bool.Parse(dr["producao"].ToString())));

			//        com_local.ExecuteNonQuery();
			//    }
			//}
			//catch (Exception e)
			//{
			//    Logger.Instance.Error(e, _usuario);
			//    MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		public bool BloquearCliente(int cliente)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_bloqueia_cliente(:cliente, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool BloquearProduto(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_bloqueia_produto(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool BloquearRecurso(int recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_bloqueia_recurso(:recurso, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool BloquearTabela(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_bloqueia_tabela(:codigo, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool BloquearUsuario(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_bloqueia_usuario(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CaixaAberto()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_caixa_aberto()", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CaixaAtivo(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select situacao from cad_caixa where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				if (dr[0].ToString() == "A")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public string CaixaDescricao(int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from cad_caixa where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool CaixaLancamento(int caixa, char tipo, double valor)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_lancamento_caixa(:caixa, :tipo, :valor, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("tipo", tipo));
				com.Parameters.Add(new NpgsqlParameter("valor", valor));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public double CaixaPeriodo(DateTime de, DateTime ate, out double dinheiro, out double cartao, out double cheques)
		{
			try
			{
				double total = 0;

				NpgsqlCommand com = new NpgsqlCommand();

				com.CommandText = "select sum(valor) from caixa_fluxo where forma = 'D' and tipo = 'E' and situacao <> 'C' and " +
					"data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "'";

				dinheiro = getDouble(com);
				total += dinheiro;

				com.CommandText = "select sum(valor) from caixa_fluxo where forma = 'X' and tipo = 'E' and situacao <> 'C' and " +
					"data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "'";

				cheques = getDouble(com);
				total += cheques;

				com.CommandText = "select sum(valor) from caixa_fluxo where forma = 'C' and tipo = 'E' and situacao <> 'C' and " +
					"data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "'";

				cartao = getDouble(com);
				total += cartao;

				return total;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				dinheiro = 0;
				cartao = 0;
				cheques = 0;

				return 0;
			}
		}

		public bool CancelarCliente(long cliente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_cliente(:cliente, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarConhecimento(int indice)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set situacao = 'C', cancelada_data = now(), cancelada_hora = now(), cancelada_usuario = :usuario "
				+ "where indice = :indice;");

			com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			return ExecCommand(com);
		}

		public bool CancelarCrediario(int crediario, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_crediario(:crediario, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("crediario", crediario));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarDespesa(int despesa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_despesa(:usuario, :despesa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("despesa", despesa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarEmitente(string cnpj)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_emitente(:cnpj);");

				com.Parameters.Add(new NpgsqlParameter("cnpj", Convert.ToInt64(cnpj)));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarEntrada(int indice, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_entrada(:indice, :usuario, :caixa);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarGrupoClientes(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_grupo_clientes(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool CancelarGrupoTributario(GrupoTributario grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_grupo_tributario(:codigo, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (bool.Parse(dr[0].ToString()))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarItemPedido(int pedido, int item, int recurso, out List<ItemPedido> itens)
		{
			List<ItemPedido> itens_cancelados = new List<ItemPedido>();

			NpgsqlCommand com = new NpgsqlCommand("select * from pedidos_itens where pedido = :pedido and numero = :item and situacao = 'A' order by numero", Conn);
			com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
			com.Parameters.Add(new NpgsqlParameter("item", item));

			NpgsqlDataReader dr = com.ExecuteReader();

			while (dr.Read())
			{
				ItemPedido i = new ItemPedido();
				i.Numero = Convert.ToInt32(dr["numero"]);
				i.Produto = Convert.ToInt64(dr["produto"]);
				i.ProdutoNome = ProdutoNome(i.Produto);
				i.Quantidade = (float)Convert.ToDouble(dr["fracao"]);

				if (dr["preco"].ToString().Length > 0)
				{
					i.Unitario = Convert.ToDecimal(dr["unitario"]);
					i.Preco = Convert.ToDecimal(dr["preco"]);
				}
				else
				{
					i.Secundario = true;
				}

				itens_cancelados.Add(i);
			}

			if (itens_cancelados.Count > 0)
			{
				itens = itens_cancelados;

				return CancelarItemPedido(pedido, item, recurso);
			}
			else
			{
				itens = null;
				return false;
			}
		}

		public bool CancelarItemPedido(int pedido, int item, int recurso)
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos_itens set situacao = 'C' where pedido = :pedido and numero = :item;", Conn);
			com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
			com.Parameters.Add(new NpgsqlParameter("item", item));

			if (com.ExecuteNonQuery() > 0)
			{
				com = new NpgsqlCommand("select dsoft_recalcula_total_pedido(:pedido);", Conn);
				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.ExecuteNonQuery();

				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CancelarLocal(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_local(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarLoteNotas(int indice)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update notas_lotes set situacao = 'C' where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", indice));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarManifesto(int indice)
		{
			NpgsqlCommand com = new NpgsqlCommand("update manifestos set situacao = 'C' where indice = :indice and situacao = 'A'");
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			if (!ExecCommand(com))
			{
				return false;
			}

			com = new NpgsqlCommand("update ordem_servico set manifesto = null where manifesto = :indice");
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			ExecCommand(com);

			return true;
		}

		public bool CancelarMaterial(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_material(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarOcorrencia(Ocorrencia ocorrencia, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_ocorrencia(:indice, :usuario, :motivo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ocorrencia.Indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("motivo", ocorrencia.Motivo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarPedido(int pedido, string motivo, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_pedido(:pedido, :motivo, :usuario);");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("motivo", motivo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarPonto(int indice, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_ponto(:indice, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarProduto(long codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_produto(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarRecurso(int recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_recurso(:recurso, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarTabela(int codigo, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_tabela(:codigo, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarUsuario(int codigo, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_usuario(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CancelarVeiculo(string placa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cancela_veiculo(:placa);");

				com.Parameters.Add(new NpgsqlParameter("placa", placa));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarCaixaAberto(Caixa caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand();

				com.CommandText = "select saldo from resumos where situacao <> 'C' order by indice desc limit 1";

				caixa.SaldoInicial = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :caixa and tipo = 'E' and forma = 'D'";

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));

				caixa.Dinheiro = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :caixa and tipo = 'E' and forma = 'X'";

				caixa.Cheque = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :caixa and tipo = 'E' and forma = 'C'";

				caixa.Cartao = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :caixa and tipo = 'E' and forma = 'A'";

				caixa.Debito = getDouble(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarCaixaDia(Caixa caixa, DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand();

				com.CommandText = "select saldo from resumos where situacao <> 'C' order by indice desc limit 1";

				caixa.SaldoInicial = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where data between todate('" + de.ToString("ddMMyy") + "') and todate('" +
					ate.ToString("ddMMyy") + "') and situacao <> 'C' and tipo = 'E' and forma = 'D'";

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));

				caixa.Dinheiro = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where data between todate('" + de.ToString("ddMMyy") + "') and todate('" +
					ate.ToString("ddMMyy") + "') and situacao <> 'C' and tipo = 'E' and forma = 'X'";

				caixa.Cheque = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where data between todate('" + de.ToString("ddMMyy") + "') and todate('" +
					ate.ToString("ddMMyy") + "') and situacao <> 'C' and tipo = 'E' and forma = 'C'";

				caixa.Cartao = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where data between todate('" + de.ToString("ddMMyy") + "') and todate('" +
					ate.ToString("ddMMyy") + "') and situacao <> 'C' tipo = 'E' and forma = 'A'";

				caixa.Debito = getDouble(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarCaixas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, situacao from cad_caixa order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public List<Caixa> CarregarCaixas()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo, descricao from cad_caixa where situacao = 'A' order by codigo", Conn);
				NpgsqlDataReader dr = com.ExecuteReader();

				List<Caixa> caixas = new List<Caixa>();

				while (dr.Read())
				{
					Caixa caixa = new Caixa();

					caixa.Codigo = Convert.ToInt32(dr["codigo"]);
					caixa.Descricao = dr["descricao"].ToString();

					caixas.Add(caixa);
				}

				return caixas;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public Cliente CarregarCliente(long codigo)
		{
			Cliente cliente = new Cliente(codigo);

			if (CarregarDadosCliente(cliente))
			{
				return cliente;
			}

			return null;
		}

		public List<Cliente> CarregarClientes()
		{
			List<Cliente> clientes = new List<Cliente>();

			NpgsqlCommand com = new NpgsqlCommand("select codigo, nome from cad_clientes where situacao = 'A' order by codigo", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			while (dr.Read())
			{
				Cliente cliente = new Cliente();
				cliente.Codigo = Convert.ToInt64(dr["codigo"]);
				cliente.Nome = dr["nome"].ToString();

				clientes.Add(cliente);
			}

			return clientes;
		}

		public void CarregarClientes(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, tel1, tel2, celular, " +
																"endereco, bairro, cidade, estado, situacao, observacao " +
																"from cad_clientes order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientesAtivos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, tel1, tel2, celular, situacao " +
																"from cad_clientes where situacao = 'A' order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, string filtro)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, tel1, tel2, celular, " +
																"endereco, bairro, cidade, estado, situacao " +
																"from cad_clientes where nome like '%" + filtro + "%' order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, double saldo)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome, " +
																"clientes_grupos.nome as grupo, cad_clientes.saldo, cad_clientes.credito_limite " +
																"from cad_clientes left join clientes_grupos on (clientes_grupos.codigo = cad_clientes.grupo) " +
																"where cad_clientes.saldo < " + saldo.ToString() + " order by cad_clientes.nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, double saldo, DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome, " +
																"clientes_grupos.nome as grupo, cad_clientes.credito_limite, cad_clientes.saldo, " +
																"(select sum(valor) from caixa_fluxo where cliente = cad_clientes.codigo and tipo = 'E' and forma = 'A' and situacao <> 'C' " +
																"and data between todate('" + de.ToString("ddMMyy") + "') and todate('" + ate.ToString("ddMMyy") + "')) as debito, " +
																"(select sum(valor) from caixa_fluxo where cliente = cad_clientes.codigo and tipo = 'E' and (forma = 'D' or forma = 'C' or forma = 'X') and situacao <> 'C' " +
																"and data between todate('" + de.ToString("ddMMyy") + "') and todate('" + ate.ToString("ddMMyy") + "') and pedido is null) as entrada " +
																"from cad_clientes left join clientes_grupos on (clientes_grupos.codigo = cad_clientes.grupo) " +
																"where cad_clientes.saldo < " + saldo.ToString() + " order by cad_clientes.nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, int grupo, double saldo)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome, " +
																"clientes_grupos.nome as grupo, cad_clientes.saldo, cad_clientes.credito_limite " +
																"from cad_clientes left join clientes_grupos on (clientes_grupos.codigo = cad_clientes.grupo) " +
																"where cad_clientes.grupo = " + grupo.ToString() + " and cad_clientes.saldo < " + saldo.ToString() + " order by cad_clientes.nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, int grupo)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome " +
																"from cad_clientes " +
																"where cad_clientes.grupo = " + grupo.ToString() + " order by cad_clientes.codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientes(DataSet ds, int grupo, double saldo, DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome, " +
																"clientes_grupos.nome as grupo, cad_clientes.credito_limite, cad_clientes.saldo, " +
																"(select sum(valor) from caixa_fluxo where cliente = cad_clientes.codigo and tipo = 'E' and forma = 'A' and situacao <> 'C' " +
																"and data between todate('" + de.ToString("ddMMyy") + "') and todate('" + ate.ToString("ddMMyy") + "')) as debito, " +
																"(select sum(valor) from caixa_fluxo where cliente = cad_clientes.codigo and tipo = 'E' and (forma = 'D' or forma = 'C' or forma = 'X') and situacao <> 'C' " +
																"and data between todate('" + de.ToString("ddMMyy") + "') and todate('" + ate.ToString("ddMMyy") + "') and pedido is null) as entrada " +
																"from cad_clientes left join clientes_grupos on (clientes_grupos.codigo = cad_clientes.grupo) " +
																"where cad_clientes.grupo = " + grupo.ToString() + " and cad_clientes.saldo < " + saldo.ToString() + " order by cad_clientes.nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientesNome(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select nome " +
																"from cad_clientes where situacao = 'A' order by codigo desc limit 100", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarClientesNomeCodigo(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select nome, codigo " +
																"from cad_clientes where situacao = 'A' order by nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public Task<DataSet> CarregarClientesAsync(int usuario)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();

				CarregarClientesNomeCodigo(ds);

				return ds;
			});
		}

		public Task<DataSet> CarregarClientesAsync(double saldo, DateTime de, DateTime ate)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarClientes(ds, saldo, de, ate);
				return ds;
			});
		}

		public Task<DataSet> CarregarClientesAsync(int grupo, double saldo, DateTime de, DateTime ate)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarClientes(ds, grupo, saldo, de, ate);
				return ds;
			});
		}

		public void CarregarClientesCompleto(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																	"nome ," +
																	"to_char(nascimento, 'DD/MM/YY') as nascimento ," +
																	"tipo ," +
																	"documento ," +
																	"rg ," +
																	"tel1 ," +
																	"tel2 ," +
																	"celular ," +
																	"endereco ," +
																	"bairro ," +
																	"cidade ," +
																	"estado ," +
																	"pais ," +
																	"referencia ," +
																	"observacao ," +
																	"situacao ," +
																	"to_char(cadastro, 'DD/MM/YY') as cadastro ," +
																	"grupo ," +
																	"saldo ," +
																	"cep ," +
																	"numero ," +
																	"complemento ," +
																	"inscricao_estadual ," +
																	"inscricao_suframa ," +
																	"isento_icms ," +
																	"credito_limite ," +
																	"pai ," +
																	"mae ," +
																	"conjuge ," +
																	"profissao ," +
																	"to_char(ultima_compra, 'DD/MM/YY') as ultima_compra " +
																	"from cad_clientes order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Carrega do banco-de-dados todos os clientes ativos cujos tipos sejam clientes internos
		/// </summary>
		/// <param name="ds">DataSet com os dados</param>
		public void CarregarClientesInternos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_clientes.codigo, cad_clientes.nome " +
																"from cad_clientes " +
																"where cad_clientes.situacao = 'A' and cad_clientes.tipo_cliente in (select codigo from clientes_tipos where cliente_interno = true) order by cad_clientes.codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Dado o código do tipo de cliente, retorna uma instância da classe ClienteTipo com os dados contidos no banco-de-dados
		/// </summary>
		/// <param name="codigo">Código do tipo de cliente</param>
		/// <returns>Instância do tipo de cliente, ou null caso o código não seja encontrado</returns>
		public ClienteTipo CarregarClienteTipo(int codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select * from clientes_tipos where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			try
			{
				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read() && dr["nome"].ToString().Length > 0)
				{
					ClienteTipo tipo = new ClienteTipo();
					tipo.Codigo = codigo;
					tipo.Nome = dr["nome"].ToString();
					tipo.Interno = Convert.ToBoolean(dr["cliente_interno"]);

					return tipo;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarCompra(Compra compra)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select data, fornecedor, situacao from compras where indice = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", compra.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				compra.Data = DateTime.Parse(dr["data"].ToString());
				compra.Fornecedor = int.Parse(dr["fornecedor"].ToString());
				compra.Situacao = char.Parse(dr["situacao"].ToString());

				com.Parameters.Clear();

				com.CommandText = "select numero, produto, unitario, quantidade, total from compras_itens where compra = :compra order by numero";

				com.Parameters.Add(new NpgsqlParameter("compra", compra.Codigo));

				dr = com.ExecuteReader();

				while (dr.Read())
				{
					CompraItem item = new CompraItem();

					item.Numero = int.Parse(dr["numero"].ToString());
					item.Produto = CarregarProduto(Convert.ToInt64(dr["produto"]));
					item.Unitario = decimal.Parse(dr["unitario"].ToString());
					item.Quantidade = float.Parse(dr["quantidade"].ToString());
					item.Total = decimal.Parse(dr["total"].ToString());

					compra.NovoItem(item);
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarCompras(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select compras.indice as codigo, " +
																	"compras.data, " +
																	"compras.hora, " +
																	"compras.fornecedor, " +
																	"cad_fornecedores.nome, " +
																	"compras.itens, " +
																	"compras.valor, " +
																	"compras.situacao, " +
																	"compras.usuario " +
																	"from compras " +
																	"left join cad_fornecedores on (cad_fornecedores.codigo = compras.fornecedor) " +
																	"order by compras.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarConhecimentos(DataSet ds, string emitente)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select ordem_servico.indice, " +
																	"ordem_servico.abertura_data, " +
																	"(select nome from cad_clientes where cad_clientes.codigo = ordem_servico.remetente) as remetente, " +
																	"(select nome from cad_clientes where cad_clientes.codigo = ordem_servico.destinatario) as destinatario, " +
																	"ordem_servico.nota_fiscal, " +
																	"ordem_servico.valor_mercadoria, " +
																	"dsoft_ordem_servico_peso(ordem_servico.indice) as peso, " +
																	"dsoft_ordem_servico_volume(ordem_servico.indice) as m3l, " +
																	"ordem_servico.valor_frete " +
																	"from ordem_servico left join cad_emitentes on (ordem_servico.emitente = cad_emitentes.cnpj) " +
																	"where ordem_servico.manifesto is null and cad_emitentes.razao_social = '" + emitente + "' " +
																	"and ordem_servico.situacao <> 'C' order by ordem_servico.indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarConhecimentos(DataSet ds, int manifesto)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select ordem_servico.indice, " +
																	"ordem_servico.abertura_data, " +
																	"(select nome from cad_clientes where cad_clientes.codigo = ordem_servico.remetente) as remetente, " +
																	"(select nome from cad_clientes where cad_clientes.codigo = ordem_servico.destinatario) as destinatario, " +
																	"(select cidade from cad_clientes where cad_clientes.codigo = ordem_servico.destinatario) as destino, " +
																	"(select estado from cad_clientes where cad_clientes.codigo = ordem_servico.destinatario) as destino_uf, " +
																	"ordem_servico.nota_fiscal, " +
																	"ordem_servico.valor_mercadoria, " +
																	"dsoft_ordem_servico_peso(ordem_servico.indice) as peso, " +
																	"dsoft_ordem_servico_volume(ordem_servico.indice) as m3l, " +
																	"ordem_servico.valor_frete, " +
																	"ordem_servico.doc_nota, " +
																	"ordem_servico.doc_serie, " +
																	"ordem_servico.doc_nota[1] as doc_nota1, " +
																	"ordem_servico.doc_nota[2] as doc_nota2, " +
																	"ordem_servico.doc_nota[3] as doc_nota3, " +
																	"ordem_servico.doc_nota[4] as doc_nota4, " +
																	"ordem_servico.doc_nota[5] as doc_nota5, " +
																	"ordem_servico.doc_nota[6] as doc_nota6, " +
																	"ordem_servico.cte " +
																	"from ordem_servico " +
																	"where ordem_servico.manifesto  = " + manifesto.ToString() + " " +
																	"and ordem_servico.situacao != 'C' order by ordem_servico.indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarCrediario(Crediario crediario)
		{
			try
			{
				int qtd;

				NpgsqlCommand com = new NpgsqlCommand("select count(indice) from pagamentos where tipo = 'P' and pedido = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", crediario.Numero));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (!int.TryParse(dr[0].ToString(), out qtd) || qtd == 0)
					return false;

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select cliente from pedidos where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", crediario.Numero));

				dr = com.ExecuteReader();

				dr.Read();

				crediario.Cliente = new Cliente();

				if (!long.TryParse(dr[0].ToString(), out crediario.Cliente.Codigo))
					return false;

				crediario.Cliente.Preencher();

				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select numero, data, situacao, valor, parcela, vencimento, total_pago " +
					"from pagamentos where pedido = " + crediario.Numero.ToString() + " order by parcela", Conn);

				crediario.Parcelas = new DataSet();

				da.Fill(crediario.Parcelas);

				crediario.ValorTotal = 0;

				foreach (DataRow d in crediario.Parcelas.Tables[0].Rows)
				{
					crediario.ValorTotal += double.Parse(d.ItemArray[3].ToString());
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public ClienteGrupo CarregarClientesGrupo(int codigo)
		{
			ClienteGrupo grupo = new ClienteGrupo();

			NpgsqlCommand com = new NpgsqlCommand("select codigo, nome, taxa_entrega, taxa_servico from clientes_grupos where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				grupo.Codigo = Convert.ToInt32(dr["codigo"]);
				grupo.Nome = dr["nome"].ToString();
				grupo.Taxa = Convert.ToDecimal(dr["taxa_entrega"]);
				grupo.TaxaDeServico = Convert.ToDecimal(dr["taxa_servico"]);
			}

			return grupo;
		}

		public bool CarregarDadosCliente(Cliente cliente)
		{
			NpgsqlConnection conn = Conn;

			if (cliente.Codigo < 1)
			{
				return false;
			}

			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, " +
																"nascimento, " +
																"tipo, " +
																"documento, " +
																"inscricao_estadual, " +
																"inscricao_suframa, " +
																"rg, " +
																"isento_icms, " +
																"tel1, " +
																"tel2, " +
																"celular, " +
																"endereco, " +
																"numero, " +
																"complemento, " +
																"bairro, " +
																"cidade, " +
																"estado, " +
																"pais, " +
																"cep, " +
																"referencia, " +
																"observacao, " +
																"grupo, " +
																"pai, " +
																"mae, " +
																"conjuge, " +
																"profissao, " +
																"saldo, " +
																"tabela_precos, " +
																"tipo_cliente, " +
																"contato, " +
																"email, " +
																"site, " +
																"vencimento_mensalidade, " +
																"valor_mensalidade, " +
																"taxa_de_entrega, " +
																"funcionario, " +
																"situacao from cad_clientes where codigo = :codigo", conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				cliente.Nome = dr["nome"].ToString();
				DateTime.TryParse(dr["nascimento"].ToString(), out cliente.Nascimento);
				char.TryParse(dr["tipo"].ToString(), out cliente.Tipo);
				cliente.Documento = dr["documento"].ToString();
				cliente.InscricaoEstadual = dr["inscricao_estadual"].ToString();
				cliente.InscricaoSuframa = dr["inscricao_suframa"].ToString();
				cliente.Rg = dr["rg"].ToString();
				bool.TryParse(dr["isento_icms"].ToString(), out cliente.IsentoICMS);
				long.TryParse(dr["tel1"].ToString(), out cliente.Telefone1);
				long.TryParse(dr["tel2"].ToString(), out cliente.Telefone2);
				long.TryParse(dr["celular"].ToString(), out cliente.Celular);
				cliente.Endereco = dr["endereco"].ToString();
				cliente.Numero = dr["numero"].ToString();
				cliente.Complemento = dr["complemento"].ToString();
				cliente.Bairro = dr["bairro"].ToString();
				cliente.Cidade = dr["cidade"].ToString();
				cliente.Estado = dr["estado"].ToString();
				cliente.Pais = dr["pais"].ToString();
				cliente.Cep = dr["cep"].ToString();
				cliente.Referencia = dr["referencia"].ToString();
				cliente.Observacao = dr["observacao"].ToString();
				int.TryParse(dr["grupo"].ToString(), out cliente.Grupo);
				cliente.Pai = dr["pai"].ToString();
				cliente.Mae = dr["mae"].ToString();
				cliente.Conjuge = dr["conjuge"].ToString();
				cliente.Profissao = dr["profissao"].ToString();
				decimal.TryParse(dr["saldo"].ToString(), out cliente.Saldo);
				char.TryParse(dr["situacao"].ToString(), out cliente.Situacao);
				cliente.Tabela = dr["tabela_precos"].ToString() == "" ? (int?)null : Convert.ToInt32(dr["tabela_precos"]);
				cliente.ClienteTipo = CarregarClienteTipo(Convert.ToInt32(dr["tipo_cliente"]));
				cliente.Contato = dr["contato"].ToString();
				cliente.Email = dr["email"].ToString();
				cliente.Site = dr["site"].ToString();

				if (dr["taxa_de_entrega"].ToString().Length > 0)
				{
					cliente.TaxaDeEntrega = Convert.ToDecimal(dr["taxa_de_entrega"]);
				}

				if (dr["vencimento_mensalidade"].ToString().Length > 0)
				{
					cliente.VencimentoMensalidade = Convert.ToInt32(dr["vencimento_mensalidade"]);
				}

				if (dr["valor_mensalidade"].ToString().Length > 0)
				{
					cliente.ValorMensalidade = Convert.ToDecimal(dr["valor_mensalidade"]);
				}

				if (dr["funcionario"].ToString().Length > 0)
				{
					cliente.Funcionario = CarregarRecurso(Convert.ToInt32(dr["funcionario"]));
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		public bool CarregarDadosPedido(int pedido, out char situacao, out int itens, out double valor, out DateTime data, out DateTime hora, out int cliente, out DateTime saida, out DateTime entrega, out int recurso, out decimal taxa_entrega)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select pedidos.situacao, pedidos.itens, pedidos.valor, pedidos.data, pedidos.hora, pedidos.cliente, pedidos.taxa_entrega, " +
														"entregas.saida, entregas.entrega, entregas.recurso, entregas.situacao as esituacao " +
														"from pedidos left join entregas on (pedidos.entrega = entregas.indice) " +
														"where pedidos.indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					situacao = '0';
					itens = 0;
					valor = 0;
					cliente = 0;
					data = DateTime.Now;
					hora = DateTime.Now;
					saida = DateTime.Now;
					entrega = DateTime.Now;
					recurso = 0;
					taxa_entrega = 0;

					return false;
				}

				char.TryParse(dr["situacao"].ToString(), out situacao);
				int.TryParse(dr["itens"].ToString(), out itens);
				int.TryParse(dr["cliente"].ToString(), out cliente);
				double.TryParse(dr["valor"].ToString(), out valor);
				DateTime.TryParse(dr["data"].ToString(), out data);
				DateTime.TryParse(dr["hora"].ToString(), out hora);
				DateTime.TryParse(dr["saida"].ToString(), out saida);
				DateTime.TryParse(dr["entrega"].ToString(), out entrega);
				int.TryParse(dr["recurso"].ToString(), out recurso);
				decimal.TryParse(dr["taxa_entrega"].ToString(), out taxa_entrega);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				situacao = '0';
				itens = 0;
				valor = 0;
				cliente = 0;
				data = DateTime.Now;
				hora = DateTime.Now;
				saida = DateTime.Now;
				entrega = DateTime.Now;
				recurso = 0;
				taxa_entrega = 0;

				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarDadosRecurso(Recurso recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, nascimento, tel1, tel2, celular, endereco, cidade, estado, tipo, situacao, rg, cpf, habilitacao, categoria, email " +
														"from cad_recursos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				char c;
				DateTime data;
				long numero;

				recurso.Nome = dr["nome"].ToString();

				if (DateTime.TryParse(dr["nascimento"].ToString(), out data))
				{
					recurso.Nascimento = data;
				}

				if (long.TryParse(dr["tel1"].ToString(), out numero))
				{
					recurso.Telefone1 = numero;
				}

				if (long.TryParse(dr["tel2"].ToString(), out numero))
				{
					recurso.Telefone2 = numero;
				}

				if (long.TryParse(dr["celular"].ToString(), out numero))
				{
					recurso.Celular = numero;
				}

				recurso.Endereco = dr["endereco"].ToString();
				recurso.Cidade = dr["cidade"].ToString();
				recurso.Estado = dr["estado"].ToString();

				if (char.TryParse(dr["tipo"].ToString(), out c))
				{
					recurso.Tipo = c;
				}

				if (char.TryParse(dr["situacao"].ToString(), out c))
				{
					recurso.Situacao = c;
				}

				recurso.Rg = dr["rg"].ToString();
				recurso.Cpf = dr["cpf"].ToString();
				recurso.Habilitacao = dr["habilitacao"].ToString();
				recurso.Categoria = dr["categoria"].ToString();
				recurso.Email = dr["email"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarDespesas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select despesas.indice as codigo, " +
																	"despesas.data, " +
																	"despesas.vencimento, " +
																	"despesas.pagamento, " +
																	"despesas.tipo, " +
																	"despesas_tipo.nome, " +
																	"despesas.fornecedor, " +
																	"cad_fornecedores.nome, " +
																	"despesas.valor, " +
																	"despesas.documento, " +
																	"despesas.valor_pago, " +
																	"despesas.situacao, " +
																	"despesas.observacao, " +
																	"despesas.usuario " +
																	"from despesas " +
																	"left join despesas_tipo on (despesas_tipo.codigo = despesas.tipo) " +
																	"left join cad_fornecedores on (cad_fornecedores.codigo = despesas.fornecedor) " +
																	"order by despesas.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public Task<DataSet> CarregarDespesasAsync()
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarDespesas(ds);
				return ds;
			});
		}

		public void CarregarDespesasTipo(out string[] tipos)
		{
			try
			{
				int indice = 0;

				NpgsqlCommand com = new NpgsqlCommand("select count(codigo) from despesas_tipo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				indice = int.Parse(dr[0].ToString());

				if (indice < 1)
				{
					tipos = null;

					return;
				}

				tipos = new string[indice];

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select codigo, nome from despesas_tipo order by codigo", Conn);

				dr = com.ExecuteReader();

				indice = 0;

				while (dr.Read())
				{
					tipos[indice++] = dr[0].ToString() + " - " + dr[1].ToString();
				}

				return;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				tipos = null;
			}
		}

		public void CarregarDespesasTipos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																	"nome, " +
																	"descricao " +
																	"from despesas_tipo " +
																	"order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public Task<DataSet> CarregarDespesasTiposAsync()
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarDespesasTipos(ds);
				return ds;
			});
		}

		public bool CarregarEmitente(Emitente emitente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome_fantasia, " +
																"cnpj, " +
																"inscricao_estadual, " +
																"cnae_fiscal, " +
																"inscricao_municipal, " +
																"logradouro, " +
																"numero, " +
																"complemento, " +
																"bairro, " +
																"cep, " +
																"pais, " +
																"uf, " +
																"municipio, " +
																"telefone, " +
																"\"RNTRC\", " +
																"situacao from cad_emitentes where razao_social = :razao_social", Conn);

				com.Parameters.Add(new NpgsqlParameter("razao_social", emitente.RazaoSocial));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				emitente.NomeFantasia = dr["nome_fantasia"].ToString();
				emitente.Cnpj = long.Parse(dr["cnpj"].ToString());
				emitente.InscricaoEstadual = dr["inscricao_estadual"].ToString();
				emitente.CNAEFiscal = dr["cnae_fiscal"].ToString();
				emitente.InscricaoMunicipal = dr["inscricao_municipal"].ToString();
				emitente.Logradouro = dr["logradouro"].ToString();
				emitente.Numero = dr["numero"].ToString();
				emitente.Complemento = dr["complemento"].ToString();
				emitente.Bairro = dr["bairro"].ToString();
				emitente.Cep = dr["cep"].ToString();
				emitente.Pais = dr["pais"].ToString();
				emitente.Uf = dr["uf"].ToString();
				emitente.Municipio = dr["municipio"].ToString();
				emitente.Telefone = dr["telefone"].ToString();
				emitente.RNTRC = dr["rntrc"].ToString();
				emitente.Situacao = dr["situacao"].ToString()[0];

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public Emitente CarregarEmitente(long cnpj)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome_fantasia, " +
																"razao_social, " +
																"inscricao_estadual, " +
																"cnae_fiscal, " +
																"inscricao_municipal, " +
																"logradouro, " +
																"numero, " +
																"complemento, " +
																"bairro, " +
																"cep, " +
																"pais, " +
																"uf, " +
																"municipio, " +
																"telefone, " +
																"\"RNTRC\", " +
																"situacao from cad_emitentes where cnpj = :cnpj", Conn);

				com.Parameters.Add(new NpgsqlParameter("cnpj", cnpj));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return null;

				Emitente emitente = new Emitente();

				emitente.NomeFantasia = dr["nome_fantasia"].ToString();
				emitente.RazaoSocial = dr["razao_social"].ToString();
				emitente.Cnpj = cnpj;
				emitente.InscricaoEstadual = dr["inscricao_estadual"].ToString();
				emitente.CNAEFiscal = dr["cnae_fiscal"].ToString();
				emitente.InscricaoMunicipal = dr["inscricao_municipal"].ToString();
				emitente.Logradouro = dr["logradouro"].ToString();
				emitente.Numero = dr["numero"].ToString();
				emitente.Complemento = dr["complemento"].ToString();
				emitente.Bairro = dr["bairro"].ToString();
				emitente.Cep = dr["cep"].ToString();
				emitente.Pais = dr["pais"].ToString();
				emitente.Uf = dr["uf"].ToString();
				emitente.Municipio = dr["municipio"].ToString();
				emitente.Telefone = dr["telefone"].ToString();
				emitente.RNTRC = dr["rntrc"].ToString();
				emitente.Situacao = dr["situacao"].ToString()[0];

				return emitente;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public void CarregarEmitentes(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select razao_social, " +
																"nome_fantasia, " +
																"cnpj, " +
																"inscricao_estadual, " +
																"cnae_fiscal, " +
																"inscricao_municipal, " +
																"logradouro, " +
																"numero, " +
																"complemento, " +
																"bairro, " +
																"cep, " +
																"pais, " +
																"uf, " +
																"municipio, " +
																"telefone, " +
																"\"RNTRC\", " +
																"situacao from cad_emitentes order by razao_social", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public List<Emitente> CarregarEmitentes()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cnpj from cad_emitentes where situacao = 'A'", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Emitente> emitentes = new List<Emitente>();

				while (dr.Read())
				{
					Emitente emitente = new Emitente();
					emitente = CarregarEmitente(Convert.ToInt64(dr[0]));
					emitentes.Add(emitente);
				}

				return emitentes;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public Task<DataSet> CarregarEmitentesAsync(int usuario)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarEmitentes(ds);
				return ds;
			});
		}

		public bool CarregarEntregas(DataSet ds, int entregador, DateTime de, DateTime ate, bool em_aberto)
		{
			try
			{
				string sql = "select pedidos.indice as codigo, " +
									"pedidos.data, " +
									"pedidos.hora, " +
									"pedidos.cliente, " +
									"cad_clientes.nome, " +
									"pedidos.itens, " +
									"pedidos.valor, " +
									"pedidos.situacao, " +
									"pedidos.caixa, " +
									"cad_caixa.descricao, " +
									"entregas.indice as entrega, " +
									"entregas.data, " +
									"entregas.saida, " +
									"entregas.entrega, " +
									"entregas.recurso, " +
									"cad_recursos.nome " +
									"from pedidos left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
												"left join cad_caixa on (cad_caixa.codigo = pedidos.caixa) " +
												"left join entregas on (entregas.pedido = pedidos.indice) " +
												"left join cad_recursos on (cad_recursos.codigo = entregas.recurso) " +
												"where pedidos.cliente is not null and ";

				if (entregador > 0)
				{
					sql += "entregas.recurso = " + entregador.ToString() + " and ";
				}

				if (em_aberto)
				{
					sql += "(pedidos.situacao <> 'P' and pedidos.situacao <> 'E') and ";
				}

				sql += "pedidos.data between to_date('" + de.Date.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.Date.ToString("dd/MM/yy") + "', 'DD/MM/YY') ";
				sql += "order by pedidos.indice;";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarEntregasCompras(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select entregas_compras.indice, " +
																"entregas_compras.previsao_data, " +
																"entregas_compras.previsao_hora, " +
																"entregas_compras.fornecedor_nome, " +
																"entregas_compras.produto, " +
																"cad_produtos.nome as nome, " +
																"entregas_compras.quantidade, " +
																"entregas_compras.entrega_data, " +
																"entregas_compras.entrega_hora, " +
																"entregas_compras.situacao " +
																"from entregas_compras " +
																"left join cad_produtos on (cad_produtos.codigo = entregas_compras.produto) " +
																"order by entregas_compras.indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarEstados(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select sigla, nome from estados order by sigla", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public List<string> CarregarEstados()
		{
			DataSet ds = new DataSet();

			if (CarregarEstados(ds))
			{
				List<string> estados = new List<string>();

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					estados.Add(string.Format("{0} - {1}", dr[0].ToString(), dr[1].ToString()));
				}

				return estados;
			}
			else
			{
				return null;
			}
		}

		public void CarregarEstoque(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select distinct estoque.produto, " +
																	"cad_produtos.nome, " +
																	"estoque.minimo, " +
																	"estoque.maximo, " +
																	"dsoft_total_estoque(estoque.produto) as quantidade, " +
																	"cad_produtos.fornecedor " +
																	"from estoque " +
																	"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
																	"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
																	"where produtos_tipos.estoque = true " +
																	"order by estoque.produto", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarEstoque(DataSet ds, string filtro)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select distinct estoque.produto, " +
																	"cad_produtos.nome, " +
																	"estoque.minimo, " +
																	"estoque.maximo, " +
																	"dsoft_total_estoque(estoque.produto) as quantidade, " +
																	"cad_produtos.fornecedor " +
																	"from estoque " +
																	"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
																	"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
																	"where produtos_tipos.estoque = true and cad_produtos.nome like '%" + filtro + "%' " +
																	"order by estoque.produto", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public DataSet CarregarEstoque(string ordenacao = "produto")
		{
			try
			{
				string query = string.Format("select distinct estoque.produto, " +
																	"cad_produtos.nome, " +
																	"estoque.minimo, " +
																	"estoque.maximo, " +
																	"dsoft_total_estoque(estoque.produto) as quantidade, " +
																	"cad_produtos.fornecedor " +
																	"from estoque " +
																	"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
																	"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
																	"where produtos_tipos.estoque = true " +
																	"order by {0}", ordenacao);

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public DataSet CarregarEstoqueCritico(string ordenacao = "produto")
		{
			try
			{
				string query = string.Format("select distinct estoque.produto, " +
																	"cad_produtos.nome, " +
																	"estoque.minimo, " +
																	"estoque.maximo, " +
																	"dsoft_total_estoque(estoque.produto) as quantidade, " +
																	"cad_produtos.fornecedor " +
																	"from estoque " +
																	"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
																	"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
																	"where produtos_tipos.estoque = true and (cad_produtos.estoque < estoque.minimo or cad_produtos.estoque <= 0) " +
																	"order by {0}", ordenacao);

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public bool CarregarEstoqueDados(ProdutoEstoque produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cad_produtos.nome, " +
															"estoque.minimo, " +
															"estoque.maximo, " +
															"dsoft_total_estoque(estoque.produto) as quantidade, " +
															"cad_produtos.fornecedor " +
															"from estoque " +
															"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
															"where estoque.produto = :produto", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", produto.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				produto.Nome = dr["nome"].ToString();
				produto.Minimo = int.Parse(dr["minimo"].ToString());
				produto.Maximo = int.Parse(dr["maximo"].ToString());
				produto.Quantidade = int.Parse(dr["quantidade"].ToString());

				if (dr["fornecedor"].ToString().Length > 0)
				{
					produto.Fornecedor = long.Parse(dr["fornecedor"].ToString());
				}
				else
				{
					produto.Fornecedor = 0;
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarEstoqueFornecedor(long fornecedor, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select distinct estoque.produto, " +
																	"cad_produtos.nome, " +
																	"estoque.minimo, " +
																	"estoque.maximo, " +
																	"dsoft_total_estoque(estoque.produto) as atual, " +
																	"cad_produtos.fornecedor " +
																	"from estoque " +
																	"left join cad_produtos on (cad_produtos.codigo = estoque.produto) " +
																	"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
																	"where produtos_tipos.estoque = true and cad_produtos.fornecedor = " + fornecedor.ToString() + " " +
																	"order by estoque.produto", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarEstoqueLocais(int produto, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select estoque.local, " +
																	"locais.nome, " +
																	"estoque.quantidade " +
																	"from estoque " +
																	"left join locais on (estoque.local = locais.codigo) " +
																	"where estoque.produto = " + produto.ToString() + " and estoque.local is not null", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarFechamento(Fechamento fechamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select * from resumos where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", fechamento.Indice));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				DateTime.TryParse(dr["data"].ToString(), out fechamento.Data);
				DateTime.TryParse(dr["hora"].ToString(), out fechamento.Hora);
				int.TryParse(dr["usuario"].ToString(), out fechamento.Usuario);
				double.TryParse(dr["saldo_anterior"].ToString(), out fechamento.SaldoAnterior);
				double.TryParse(dr["saldo"].ToString(), out fechamento.SaldoAtual);
				double.TryParse(dr["vendas"].ToString(), out fechamento.Vendas);
				int.TryParse(dr["volume"].ToString(), out fechamento.Volume);
				double.TryParse(dr["entrada"].ToString(), out fechamento.Entrada);
				double.TryParse(dr["saida"].ToString(), out fechamento.Saida);
				double.TryParse(dr["vales"].ToString(), out fechamento.Vales);
				double.TryParse(dr["despesas"].ToString(), out fechamento.Despesas);
				double.TryParse(dr["pagamentos"].ToString(), out fechamento.Pagamentos);
				double.TryParse(dr["dinheiro"].ToString(), out fechamento.Dinheiro);
				double.TryParse(dr["cheque"].ToString(), out fechamento.Cheque);
				double.TryParse(dr["cartao"].ToString(), out fechamento.Cartao);
				double.TryParse(dr["debito"].ToString(), out fechamento.Debito);
				double.TryParse(dr["crediario"].ToString(), out fechamento.Crediario);
				double.TryParse(dr["recebimentos"].ToString(), out fechamento.Recebimentos);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarFechamentos(DataSet ds, int caixa, int usuario, DateTime de, DateTime ate)
		{
			try
			{
				string sql = "select caixa.indice, " +
									"caixa.data, " +
									"caixa.hora, " +
									"caixa.caixa, " +
									"cad_caixa.descricao, " +
									"caixa.saldo, " +
									"caixa.entrada, " +
									"caixa.saida, " +
									"caixa.despesa, " +
									"caixa.vale, " +
									"caixa.pagamento, " +
									"caixa.transferencia, " +
									"caixa.situacao, " +
									"caixa.usuario, " +
									"cad_usuarios.nome " +
									"from caixa " +
									"left join cad_caixa on (cad_caixa.codigo = caixa.caixa) " +
									"left join cad_usuarios on (cad_usuarios.codigo = caixa.usuario) " +
									"where caixa.tipo = 'F' ";

				if (caixa > 0)
				{
					sql += "and caixa.caixa = " + caixa.ToString() + " ";
				}

				if (usuario > 0)
				{
					sql += "and caixa.usuario = " + usuario.ToString() + " ";
				}

				sql += "and caixa.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') ";

				sql += "order by caixa.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Carrega os dados da filial para o sistema.
		/// </summary>
		/// <returns></returns>
		public bool CarregarFilial()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select * from cad_filiais", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				Filial.Instance().Codigo = int.Parse(dr["codigo"].ToString());
				Filial.Instance().Nome = dr["nome"].ToString();
				Filial.Instance().Endereco = dr["endereco"].ToString();
				Filial.Instance().Bairro = dr["bairro"].ToString();
				Filial.Instance().Cep = dr["cep"].ToString();
				Filial.Instance().Cidade = dr["cidade"].ToString();
				Filial.Instance().Estado = dr["estado"].ToString();
				Filial.Instance().Pais = dr["pais"].ToString();
				Filial.Instance().Telefone = dr["telefone"].ToString().Length > 0 ? Convert.ToInt32(dr["telefone"]) : 0;
				Filial.Instance().Cnpj = dr["cnpj"].ToString();
				//Filial.IE = dr["ie"].ToString();
				Filial.Instance().Ip = dr["ip"].ToString();
				Filial.Instance().Porta = dr["porta"].ToString();
				Filial.Instance().Banco = dr["banco"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public Filial CarregarFilial(int codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select nome, endereco, bairro, cep, cidade, estado, pais, telefone, cnpj, situacao from cad_filiais where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				Filial filial = new Filial();
				filial.Codigo = codigo;
				filial.Nome = dr["nome"].ToString();
				filial.Endereco = dr["endereco"].ToString();
				filial.Bairro = dr["bairro"].ToString();
				filial.Cep = dr["cep"].ToString();
				filial.Cidade = dr["cidade"].ToString();
				filial.Estado = dr["estado"].ToString();
				filial.Pais = dr["pais"].ToString();
				filial.Telefone = dr["telefone"].ToString().Length > 0 ? Convert.ToInt32(dr["telefone"]) : 0;
				filial.Cnpj = dr["cnpj"].ToString();
				filial.Situacao = dr["situacao"].ToString();

				return filial;
			}
			else
			{
				return null;
			}
		}

		public List<Filial> CarregarFiliais()
		{
			NpgsqlCommand com = new NpgsqlCommand("select codigo, nome, endereco, bairro, cep, cidade, estado, pais, telefone, cnpj from cad_filiais where situacao = 'A' order by codigo", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Filial> filiais = new List<Filial>();

			while (dr.Read())
			{
				Filial filial = new Filial();
				filial.Codigo = Convert.ToInt32(dr["codigo"]);
				filial.Nome = dr["nome"].ToString();
				filial.Endereco = dr["endereco"].ToString();
				filial.Bairro = dr["bairro"].ToString();
				filial.Cep = dr["cep"].ToString();
				filial.Cidade = dr["cidade"].ToString();
				filial.Estado = dr["estado"].ToString();
				filial.Pais = dr["pais"].ToString();
				filial.Telefone = dr["telefone"].ToString().Length > 0 ? Convert.ToInt32(dr["telefone"]) : 0;
				filial.Cnpj = dr["cnpj"].ToString();

				filiais.Add(filial);
			}

			return filiais;
		}

		public DataTable CarregarCadastroFiliais()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, cnpj, telefone, cep, endereco, bairro, cidade, estado, pais, situacao from cad_filiais order by codigo", Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public bool InsertOrUpdate(Filial filial)
		{
			NpgsqlCommand com = new NpgsqlCommand("select incluir_ou_alterar_filial(:codigo, :nome, :cnpj, :telefone, :cep, :endereco, :bairro, :cidade, :estado, :pais);");
			com.Parameters.Add(new NpgsqlParameter("codigo", filial.Codigo));
			com.Parameters.Add(new NpgsqlParameter("nome", filial.Nome));
			com.Parameters.Add(new NpgsqlParameter("cnpj", filial.Cnpj));
			com.Parameters.Add(new NpgsqlParameter("telefone", filial.Telefone));
			com.Parameters.Add(new NpgsqlParameter("cep", filial.Cep));
			com.Parameters.Add(new NpgsqlParameter("endereco", filial.Endereco));
			com.Parameters.Add(new NpgsqlParameter("bairro", filial.Bairro));
			com.Parameters.Add(new NpgsqlParameter("cidade", filial.Cidade));
			com.Parameters.Add(new NpgsqlParameter("estado", filial.Estado));
			com.Parameters.Add(new NpgsqlParameter("pais", filial.Pais));

			return getBool(com);
		}

		public void CarregarFornecedores(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																	"nome, " +
																	"cnpj, " +
																	"tel1, " +
																	"tel2, " +
																	"endereco, " +
																	"bairro, " +
																	"cidade, " +
																	"estado, " +
																	"pais, " +
																	"cep, " +
																	"contato, " +
																	"tipo, " +
																	"obs, " +
																	"email, " +
																	"situacao " +
																	"from cad_fornecedores order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CancelarFornecedor(long codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_fornecedores set situacao = 'C' where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			return ExecCommand(com);
		}

		public bool ReativarFornecedor(long codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_fornecedores set situacao = 'A' where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			return ExecCommand(com);
		}

		public List<ClienteGrupo> CarregarClientesGrupos()
		{
			List<ClienteGrupo> grupos = new List<ClienteGrupo>();

			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo, nome, taxa_entrega, taxa_servico, cidade, estado from clientes_grupos order by codigo", Conn);
				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					ClienteGrupo grupo = new ClienteGrupo();

					grupo.Codigo = Convert.ToInt32(dr["codigo"]);
					grupo.Nome = dr["nome"].ToString();
					grupo.Taxa = Convert.ToDecimal(dr["taxa_entrega"]);
					grupo.TaxaDeServico = Convert.ToDecimal(dr["taxa_servico"]);
					grupo.Cidade = dr["cidade"].ToString();
					grupo.Estado = dr["estado"].ToString();

					grupos.Add(grupo);
				}

				return grupos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarGruposClientes(out string[] tabelas)
		{
			try
			{
				int indice = 0;

				NpgsqlCommand com = new NpgsqlCommand("select count(indice) from clientes_grupos where situacao = 'A'", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				indice = int.Parse(dr[0].ToString());

				if (indice < 1)
				{
					tabelas = null;

					return false;
				}

				tabelas = new string[indice];

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select codigo, nome from clientes_grupos where situacao = 'A' order by codigo", Conn);

				dr = com.ExecuteReader();

				indice = 0;

				while (dr.Read())
				{
					tabelas[indice++] = dr[0].ToString() + " - " + dr[1].ToString();
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				tabelas = null;

				return false;
			}
		}

		public void CarregarGruposTributarios(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																"nome, " +
																"icms, " +
																"ipi, " +
																"pis, " +
																"cofins, " +
																"csll, " +
																"irrf, " +
																"situacao, " +
																"usuario " +
																"from grupos_tributarios order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarItensAdicionais(DataSet ds)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select descricao, adicional from cad_adicionais where produto is null and tipo is null order by descricao", Conn);
			da.Fill(ds);
		}

		public void CarregarItensAdicionais(DataSet ds, long produto)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select descricao, adicional from cad_adicionais where produto = " + produto.ToString() + " order by descricao", Conn);
			da.Fill(ds);
		}

		public void CarregarItensAdicionais(DataSet ds, ProdutoTipo tipo)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select descricao, adicional from cad_adicionais where tipo = " + tipo.Codigo + " order by descricao", Conn);
				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public List<ItemAdicional> CarregarItensAdicionais()
		{
			NpgsqlCommand com = new NpgsqlCommand("select descricao, adicional from cad_adicionais where produto is null and tipo is null order by descricao", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<ItemAdicional> itens = new List<ItemAdicional>();

			while (dr.Read())
			{
				ItemAdicional item = new ItemAdicional();
				item.Descricao = dr["descricao"].ToString();
				item.Valor = Convert.ToDecimal(dr["adicional"]);

				itens.Add(item);
			}

			return itens;
		}

		public List<ItemAdicional> CarregarItensAdicionais(long produto)
		{
			NpgsqlCommand com = new NpgsqlCommand("select descricao, adicional from cad_adicionais where produto = :produto order by descricao", Conn);
			com.Parameters.Add(new NpgsqlParameter("produto", produto));

			NpgsqlDataReader dr = com.ExecuteReader();

			List<ItemAdicional> itens = new List<ItemAdicional>();

			while (dr.Read())
			{
				ItemAdicional item = new ItemAdicional();
				item.Descricao = dr["descricao"].ToString();
				item.Valor = Convert.ToDecimal(dr["adicional"]);

				itens.Add(item);
			}

			return itens;
		}

		public void CarregarItensAdicionaisPorProduto(DataSet ds)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select descricao, adicional, produto from cad_adicionais where produto is not null order by descricao", Conn);
			da.Fill(ds);
		}

		public void CarregarItensAdicionaisPorTipo(DataSet ds)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select descricao, adicional, tipo from cad_adicionais where tipo is not null order by descricao", Conn);
			da.Fill(ds);
		}

		public List<ItemAdicional> CarregarItensAdicionais(ProdutoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select descricao, adicional from cad_adicionais where tipo = :tipo order by descricao", Conn);
			com.Parameters.Add(new NpgsqlParameter("tipo", tipo.Codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			List<ItemAdicional> itens = new List<ItemAdicional>();

			while (dr.Read())
			{
				ItemAdicional item = new ItemAdicional();
				item.Descricao = dr["descricao"].ToString();
				item.Valor = Convert.ToDecimal(dr["adicional"]);

				itens.Add(item);
			}

			return itens;
		}

		public int CarregarItensPedido(int pedido, DataSet ds)
		{
			try
			{
				int itens;

				NpgsqlCommand com = new NpgsqlCommand("select count(indice) from pedidos_itens where pedido = :pedido and situacao = 'A'", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				int.TryParse(dr[0].ToString(), out itens);

				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos_itens.numero, " +
																	"pedidos_itens.produto, " +
																	"cad_produtos.nome, " +
																	"pedidos_itens.fracao, " +
																	"pedidos_itens.preco, " +
																	"pedidos_itens.observacao " +
																	"from pedidos_itens " +
																	"left join cad_produtos on (cad_produtos.codigo = pedidos_itens.produto) " +
																	"where pedidos_itens.pedido = " + pedido.ToString() +
																	"order by pedidos_itens.numero", Conn);

				da.Fill(ds);

				return itens;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public void CarregarLocais(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, descricao, tipo, situacao, responsavel from locais order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarLotesNotas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select inicial, final, serie, tipo, situacao, indice from notas_lotes order by indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarManifesto(Manifesto manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select emitente, " +
															"montagem_data, " +
															"motorista, " +
															"veiculo, " +
															"carreta, " +
															"situacao, " +
															"saida_data, " +
															"chegada_data, " +
															"rntrc, " +
															"ciot, " +
															"uf_entrega, " +
															"mun_entrega, " +
															"chave, " +
															"numero, " +
															"protocolo, " +
															"arquivo " +
															"from manifestos where indice = :indice order by indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", manifesto.Indice));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				manifesto.Emitente.Cnpj = long.Parse(dr["emitente"].ToString());
				manifesto.Data = DateTime.Parse(dr["montagem_data"].ToString());
				manifesto.Motorista.Codigo = int.Parse(dr["motorista"].ToString());
				manifesto.Veiculo.Placa = dr["veiculo"].ToString();
				manifesto.Carreta.Placa = dr["carreta"].ToString();
				manifesto.Situacao = dr["situacao"].ToString()[0];
				manifesto.RNTRC = dr["rntrc"].ToString();
				manifesto.CIOT = dr["ciot"].ToString();
				manifesto.UFEntrega = dr["uf_entrega"].ToString();
				manifesto.MunEntrega = dr["mun_entrega"].ToString();
				manifesto.CodUFEntrega = CodigoEstado(manifesto.UFEntrega);
				manifesto.CodMunEntrega = CodigoMunicipio(manifesto.MunEntrega, manifesto.UFEntrega);
				manifesto.Chave = dr["chave"].ToString();
				//manifesto.Numero = int.Parse(dr["numero"].ToString());
				manifesto.Protocolo = dr["protocolo"].ToString();
				manifesto.Arquivo = dr["arquivo"].ToString();

				if (manifesto.Situacao == 'S')
				{
					manifesto.Saida = DateTime.Parse(dr["saida_data"].ToString());
				}
				else if (manifesto.Situacao == 'E')
				{
					manifesto.Saida = DateTime.Parse(dr["saida_data"].ToString());
					manifesto.Chegada = DateTime.Parse(dr["chegada_data"].ToString());
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarManifestos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select manifestos.indice, " +
																"manifestos.montagem_data, " +
																"manifestos.montagem_hora, " +
																"manifestos.saida_data, " +
																"manifestos.saida_hora, " +
																"manifestos.chegada_data, " +
																"manifestos.chegada_hora, " +
																"cad_usuarios.nome as usuario, " +
																"cad_emitentes.razao_social as emitente, " +
																"cad_recursos.nome as motorista, " +
																"manifestos.veiculo, " +
																"manifestos.carreta, " +
																"manifestos.situacao, " +
																"manifestos.itens, " +
																"manifestos.valor_total, " +
																"manifestos.peso_total, " +
																"manifestos.volume_total, " +
																"manifestos.frete_total " +
																"from manifestos " +
																"left join cad_usuarios on (cad_usuarios.codigo = manifestos.usuario) " +
																"left join cad_emitentes on (cad_emitentes.cnpj = manifestos.emitente) " +
																"left join cad_recursos on (cad_recursos.codigo = manifestos.motorista) " +
																"order by manifestos.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarMedidas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from medidas", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarMotoristas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																	"nome " +
																	"from cad_recursos where tipo = 'M' and situacao = 'A' " +
																	"order by nome", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarMunicipios(DataSet ds, string uf)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome from municipios where uf = '" + uf + "' order by nome", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		/// <summary>
		/// Carrega um Nível de usuário do banco-de-dados
		/// </summary>
		/// <param name="nivel">Código do nível de usuário</param>
		/// <returns>NivelUsuario carregado do banco-de-dados</returns>
		public NivelUsuario CarregarNivelUsuario(string nivel)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select * from usuario_niveis where nivel = :nivel", Conn);
				com.Parameters.Add(new NpgsqlParameter("nivel", nivel));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				NivelUsuario _nivel = new NivelUsuario();
				_nivel.Nivel = nivel;
				_nivel.Nome = dr["nome"].ToString();
				_nivel.Administrador = Convert.ToBoolean(dr["administrador"]);
				_nivel.LancarPedidos = Convert.ToBoolean(dr["lancar_pedidos"]);
				_nivel.AlterarPedidos = Convert.ToBoolean(dr["alterar_pedidos"]);
				_nivel.AlterarClienteDoPedido = Convert.ToBoolean(dr["alterar_cliente_pedido"]);
				_nivel.CancelarPedidos = Convert.ToBoolean(dr["cancelar_pedidos"]);
				_nivel.Caixa = Convert.ToBoolean(dr["caixa"]);
				_nivel.ControleFinanceiro = Convert.ToBoolean(dr["controle_financeiro"]);
				_nivel.Entregas = Convert.ToBoolean(dr["entregas"]);
				_nivel.Relatorios = Convert.ToBoolean(dr["relatorios"]);
				_nivel.CadastrarProdutos = Convert.ToBoolean(dr["cadastrar_produtos"]);
				_nivel.AlterarPrecos = Convert.ToBoolean(dr["alterar_precos"]);
				_nivel.Compras = Convert.ToBoolean(dr["compras"]);
				_nivel.CadastrarRecursos = Convert.ToBoolean(dr["cadastrar_recursos"]);
				_nivel.CadastrarUsuarios = Convert.ToBoolean(dr["cadastrar_usuarios"]);
				_nivel.AlterarEstoque = Convert.ToBoolean(dr["alterar_estoque"]);
				_nivel.ScriptBd = Convert.ToBoolean(dr["script_bd"]);
				_nivel.Preferencias = Convert.ToBoolean(dr["preferencias"]);
				_nivel.Terminal = Convert.ToBoolean(dr["preferencias"]);
				_nivel.RegrasDeNegocio = Convert.ToBoolean(dr["regras_negocio"]);
				_nivel.CadastrarGruposDeClientes = Convert.ToBoolean(dr["cadastrar_grupos_de_clientes"]);
				_nivel.Escritorio = Convert.ToBoolean(dr["escritorio"]);
				_nivel.Almoxarifado = Convert.ToBoolean(dr["almoxarifado"]);

				return _nivel;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return null;
			}
		}

		public void CarregarNotasFiscais(DataTable table)
		{
			try
			{
				DataSet ds = new DataSet();

				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from notas_fiscais order by indice", Conn);

				da.Fill(ds);

				table = ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarOrdemTransporte(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select " +
													"abertura_data, " +
													"emitente, " +
													"situacao, " +
													"remetente, " +
													"destinatario, " +
													"conhecimento, " +
													"manifesto, " +
													"recebida_data, " +
													"conferida_data, " +
													"montagem_data, " +
													"chegada_data, " +
													"cancelada_data, " +
													"coleta, " +
													"prev_coleta, " +
													"cfop, " +
													"cst, " +
													"bc_icms, " +
													"aliquota_icms, " +
													"valor_icms, " +
													"enviada_data, " +
													"natureza_operacao, " +
													"rntrc, " +
													"valor_mercadoria, " +
													"valor_frete, " +
													"pago, " +
													"cte, " +
													"arquivo, " +
													"prod_predominante, " +
													"outras_caract, " +
													"trim(both '''' from observacoes[1]) as ob1, " +
													"trim(both '''' from observacoes[2]) as ob2, " +
													"trim(both '''' from observacoes[3]) as ob3, " +
													"trim(both '''' from observacoes[4]) as ob4, " +
													"trim(both '''' from observacoes[5]) as ob5, " +
													"qtd_merc[1] as qm1, " +
													"qtd_merc[2] as qm2, " +
													"qtd_merc[3] as qm3, " +
													"qtd_merc[4] as qm4, " +
													"qtd_merc[5] as qm5, " +
													"trim(both '''' from un_med[1]) as um1, " +
													"trim(both '''' from un_med[2]) as um2, " +
													"trim(both '''' from un_med[3]) as um3, " +
													"trim(both '''' from un_med[4]) as um4, " +
													"trim(both '''' from un_med[5]) as um5, " +
													"trim(both '''' from tipo_med[1]) as tm1, " +
													"trim(both '''' from tipo_med[2]) as tm2, " +
													"trim(both '''' from tipo_med[3]) as tm3, " +
													"trim(both '''' from tipo_med[4]) as tm4, " +
													"trim(both '''' from tipo_med[5]) as tm5, " +
													"trim(both '''' from doc_cte[1]) as dc1, " +
													"trim(both '''' from doc_cte[2]) as dc2, " +
													"trim(both '''' from doc_cte[3]) as dc3, " +
													"trim(both '''' from doc_cte[4]) as dc4, " +
													"trim(both '''' from doc_cte[5]) as dc5, " +
													"trim(both '''' from doc_cte[6]) as dc6, " +
													"trim(both '''' from doc_tipo[1]) as dt1, " +
													"trim(both '''' from doc_tipo[2]) as dt2, " +
													"trim(both '''' from doc_tipo[3]) as dt3, " +
													"trim(both '''' from doc_tipo[4]) as dt4, " +
													"trim(both '''' from doc_tipo[5]) as dt5, " +
													"trim(both '''' from doc_tipo[6]) as dt6, " +
													"trim(both '''' from doc_emit[1]) as de1, " +
													"trim(both '''' from doc_emit[2]) as de2, " +
													"trim(both '''' from doc_emit[3]) as de3, " +
													"trim(both '''' from doc_emit[4]) as de4, " +
													"trim(both '''' from doc_emit[5]) as de5, " +
													"trim(both '''' from doc_emit[6]) as de6, " +
													"trim(both '''' from doc_nota[1]) as dn1, " +
													"trim(both '''' from doc_nota[2]) as dn2, " +
													"trim(both '''' from doc_nota[3]) as dn3, " +
													"trim(both '''' from doc_nota[4]) as dn4, " +
													"trim(both '''' from doc_nota[5]) as dn5, " +
													"trim(both '''' from doc_nota[6]) as dn6, " +
													"trim(both '''' from doc_serie[1]) as ds1, " +
													"trim(both '''' from doc_serie[2]) as ds2, " +
													"trim(both '''' from doc_serie[3]) as ds3, " +
													"trim(both '''' from doc_serie[4]) as ds4, " +
													"trim(both '''' from doc_serie[5]) as ds5, " +
													"trim(both '''' from doc_serie[6]) as ds6, " +
													"prev_entrega, " +
													"trim(both '''' from componente[1]) as comp1, " +
													"trim(both '''' from componente[2]) as comp2, " +
													"trim(both '''' from componente[3]) as comp3, " +
													"trim(both '''' from componente[4]) as comp4, " +
													"trim(both '''' from componente[5]) as comp5, " +
													"trim(both '''' from componente[6]) as comp6, " +
													"trim(both '''' from componente[7]) as comp7, " +
													"trim(both '''' from componente[8]) as comp8, " +
													"trim(both '''' from componente[9]) as comp9, " +
													"trim(both '''' from componente[10]) as comp10, " +
													"trim(both '''' from componente[11]) as comp11, " +
													"trim(both '''' from componente[12]) as comp12, " +
													"valor_prestacao[1] as vp1, " +
													"valor_prestacao[2] as vp2, " +
													"valor_prestacao[3] as vp3, " +
													"valor_prestacao[4] as vp4, " +
													"valor_prestacao[5] as vp5, " +
													"valor_prestacao[6] as vp6, " +
													"valor_prestacao[7] as vp7, " +
													"valor_prestacao[8] as vp8, " +
													"valor_prestacao[9] as vp9, " +
													"valor_prestacao[10] as vp10, " +
													"valor_prestacao[11] as vp11, " +
													"valor_prestacao[12] as vp12, " +
													"red_bc, " +
													"icms_st, " +
													"icms_orig, " +
													"msg_erro, " +
													"lote, " +
													"ambiente, " +
													"status, " +
													"motivo, " +
													"recibo, " +
													"dhrecbto, " +
													"nprot, " +
													"digval, " +
													"motorista, " +
													"veiculo, " +
													"num_coleta, " +
													"carac_ad, " +
													"carac_ser, " +
													"obs_cont, " +
													"obs_fisco, " +
													"xobs " +
													"from ordem_servico where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem.Indice));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				DateTime.TryParse(dr["abertura_data"].ToString(), out ordem.Data);
				ordem.Emitente.Cnpj = long.Parse(dr["emitente"].ToString());
				ordem.Situacao = dr["situacao"].ToString()[0];
				long.TryParse(dr["remetente"].ToString(), out ordem.Remetente.Codigo);
				long.TryParse(dr["destinatario"].ToString(), out ordem.Destinatario.Codigo);
				ordem.Conhecimento = dr["conhecimento"].ToString();
				int.TryParse(dr["manifesto"].ToString(), out ordem.Manifesto);
				DateTime.TryParse(dr["recebida_data"].ToString(), out ordem.Recebida);
				DateTime.TryParse(dr["conferida_data"].ToString(), out ordem.Conferida);
				DateTime.TryParse(dr["montagem_data"].ToString(), out ordem.Montagem);
				DateTime.TryParse(dr["chegada_data"].ToString(), out ordem.Chegada);
				DateTime.TryParse(dr["cancelada_data"].ToString(), out ordem.Cancelada);
				DateTime.TryParse(dr["coleta"].ToString(), out ordem.Coleta);
				DateTime.TryParse(dr["prev_coleta"].ToString(), out ordem.PrevisaoColeta);
				int.TryParse(dr["cfop"].ToString(), out ordem.CFOP);
				ordem.CST = dr["cst"].ToString();
				double.TryParse(dr["bc_icms"].ToString(), out ordem.ValorBCICMS);
				double.TryParse(dr["aliquota_icms"].ToString(), out ordem.AliquotaICMS);
				double.TryParse(dr["valor_icms"].ToString(), out ordem.ValorICMS);
				DateTime.TryParse(dr["enviada_data"].ToString(), out ordem.Enviada);
				ordem.NaturezaDaOperacao = dr["natureza_operacao"].ToString();
				ordem.RNTRC = dr["rntrc"].ToString();
				double.TryParse(dr["valor_mercadoria"].ToString(), out ordem.ValorMercadoria);
				double.TryParse(dr["valor_frete"].ToString(), out ordem.ValorFrete);
				bool.TryParse(dr["pago"].ToString(), out ordem.Pago);
				ordem.CTe = dr["cte"].ToString();
				ordem.Arquivo = dr["arquivo"].ToString();
				ordem.ProdudoPredominante = dr["prod_predominante"].ToString();
				ordem.OutrasCaracteristicas = dr["outras_caract"].ToString();
				ordem.Observacoes[0] = dr["ob1"].ToString();
				ordem.Observacoes[1] = dr["ob2"].ToString();
				ordem.Observacoes[2] = dr["ob3"].ToString();
				ordem.Observacoes[3] = dr["ob4"].ToString();
				ordem.Observacoes[4] = dr["ob5"].ToString();
				double.TryParse(dr["qm1"].ToString(), out ordem.Quantidade[0]);
				double.TryParse(dr["qm2"].ToString(), out ordem.Quantidade[1]);
				double.TryParse(dr["qm3"].ToString(), out ordem.Quantidade[2]);
				double.TryParse(dr["qm4"].ToString(), out ordem.Quantidade[3]);
				double.TryParse(dr["qm5"].ToString(), out ordem.Quantidade[4]);
				ordem.UnidadeMedida[0] = dr["um1"].ToString();
				ordem.UnidadeMedida[1] = dr["um2"].ToString();
				ordem.UnidadeMedida[2] = dr["um3"].ToString();
				ordem.UnidadeMedida[3] = dr["um4"].ToString();
				ordem.UnidadeMedida[4] = dr["um5"].ToString();
				ordem.TipoMedida[0] = dr["tm1"].ToString();
				ordem.TipoMedida[1] = dr["tm2"].ToString();
				ordem.TipoMedida[2] = dr["tm3"].ToString();
				ordem.TipoMedida[3] = dr["tm4"].ToString();
				ordem.TipoMedida[4] = dr["tm5"].ToString();
				ordem.ChaveAcesso[0] = dr["dc1"].ToString();
				ordem.ChaveAcesso[1] = dr["dc2"].ToString();
				ordem.ChaveAcesso[2] = dr["dc3"].ToString();
				ordem.ChaveAcesso[3] = dr["dc4"].ToString();
				ordem.ChaveAcesso[4] = dr["dc5"].ToString();
				ordem.ChaveAcesso[5] = dr["dc6"].ToString();
				ordem.DocTipo[0] = dr["dt1"].ToString();
				ordem.DocTipo[1] = dr["dt2"].ToString();
				ordem.DocTipo[2] = dr["dt3"].ToString();
				ordem.DocTipo[3] = dr["dt4"].ToString();
				ordem.DocTipo[4] = dr["dt5"].ToString();
				ordem.DocTipo[5] = dr["dt6"].ToString();
				ordem.DocEmit[0] = dr["de1"].ToString();
				ordem.DocEmit[1] = dr["de2"].ToString();
				ordem.DocEmit[2] = dr["de3"].ToString();
				ordem.DocEmit[3] = dr["de4"].ToString();
				ordem.DocEmit[4] = dr["de5"].ToString();
				ordem.DocEmit[5] = dr["de6"].ToString();
				ordem.DocNota[0] = dr["dn1"].ToString();
				ordem.DocNota[1] = dr["dn2"].ToString();
				ordem.DocNota[2] = dr["dn3"].ToString();
				ordem.DocNota[3] = dr["dn4"].ToString();
				ordem.DocNota[4] = dr["dn5"].ToString();
				ordem.DocNota[5] = dr["dn6"].ToString();
				ordem.DocSerie[0] = dr["ds1"].ToString();
				ordem.DocSerie[1] = dr["ds2"].ToString();
				ordem.DocSerie[2] = dr["ds3"].ToString();
				ordem.DocSerie[3] = dr["ds4"].ToString();
				ordem.DocSerie[4] = dr["ds5"].ToString();
				ordem.DocSerie[5] = dr["ds6"].ToString();
				DateTime.TryParse(dr["prev_entrega"].ToString(), out ordem.PrevisaoEntrega);
				ordem.Componente[0] = dr["comp1"].ToString();
				ordem.Componente[1] = dr["comp2"].ToString();
				ordem.Componente[2] = dr["comp3"].ToString();
				ordem.Componente[3] = dr["comp4"].ToString();
				ordem.Componente[4] = dr["comp5"].ToString();
				ordem.Componente[5] = dr["comp6"].ToString();
				ordem.Componente[6] = dr["comp7"].ToString();
				ordem.Componente[7] = dr["comp8"].ToString();
				ordem.Componente[8] = dr["comp9"].ToString();
				ordem.Componente[9] = dr["comp10"].ToString();
				ordem.Componente[10] = dr["comp11"].ToString();
				ordem.Componente[11] = dr["comp12"].ToString();
				double.TryParse(dr["vp1"].ToString(), out ordem.ValorPrestacao[0]);
				double.TryParse(dr["vp2"].ToString(), out ordem.ValorPrestacao[1]);
				double.TryParse(dr["vp3"].ToString(), out ordem.ValorPrestacao[2]);
				double.TryParse(dr["vp4"].ToString(), out ordem.ValorPrestacao[3]);
				double.TryParse(dr["vp5"].ToString(), out ordem.ValorPrestacao[4]);
				double.TryParse(dr["vp6"].ToString(), out ordem.ValorPrestacao[5]);
				double.TryParse(dr["vp7"].ToString(), out ordem.ValorPrestacao[6]);
				double.TryParse(dr["vp8"].ToString(), out ordem.ValorPrestacao[7]);
				double.TryParse(dr["vp9"].ToString(), out ordem.ValorPrestacao[8]);
				double.TryParse(dr["vp10"].ToString(), out ordem.ValorPrestacao[9]);
				double.TryParse(dr["vp11"].ToString(), out ordem.ValorPrestacao[10]);
				double.TryParse(dr["vp12"].ToString(), out ordem.ValorPrestacao[11]);
				double.TryParse(dr["red_bc"].ToString(), out ordem.RedBCICMS);
				double.TryParse(dr["icms_st"].ToString(), out ordem.ICMSST);
				ordem.Origem = dr["icms_orig"].ToString();
				ordem.MsgErro = dr["msg_erro"].ToString();
				int.TryParse(dr["lote"].ToString(), out ordem.Lote);
				ordem.Ambiente = dr["ambiente"].ToString();
				ordem.Status = dr["status"].ToString();
				ordem.Motivo = dr["motivo"].ToString();
				long.TryParse(dr["recibo"].ToString(), out ordem.Recibo);
				ordem.DataHoraRecebimento = dr["dhrecbto"].ToString();
				long.TryParse(dr["nprot"].ToString(), out ordem.NumeroProtocolo);
				ordem.DigVal = dr["digval"].ToString();
				ordem.NumeroColeta = dr["num_coleta"].ToString();

				if (dr["motorista"].ToString().Length > 0)
				{
					ordem.Motorista.Codigo = int.Parse(dr["motorista"].ToString());
					ordem.Motorista.Nome = RecursoNome(ordem.Motorista.Codigo);
				}

				ordem.Veiculo.Placa = dr["veiculo"].ToString();

				ordem.CaracAd = dr["carac_ad"].ToString();
				ordem.CaracSer = dr["carac_ser"].ToString();
				ordem.ObsCont = dr["obs_cont"].ToString();
				ordem.ObsFisco = dr["obs_fisco"].ToString();
				ordem.Obs = dr["xobs"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarOrdensColetaTransmitindo(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select indice, situacao, cte, msg_erro, lote from ordem_servico where situacao in ('T', 'E', 'U', 'P', 'R') order by indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarOrdensServico(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select ordem_servico.indice, " +
																	"ordem_servico.abertura_data, " +
																	"ordem_servico.abertura_hora, " +
																	"cad_clientes.nome as remetente, " +
																	"ordem_servico.conhecimento, " +
																	"ordem_servico.manifesto, " +
																	"ordem_servico.recebida_data, " +
																	"ordem_servico.recebida_hora, " +
																	"ordem_servico.conferida_data, " +
																	"ordem_servico.conferida_hora, " +
																	"ordem_servico.montagem_data, " +
																	"ordem_servico.montagem_hora, " +
																	"ordem_servico.chegada_data, " +
																	"ordem_servico.chegada_hora, " +
																	"ordem_servico.msg_erro, " +
																	"ordem_servico.lote, " +
																	"ordem_servico.motivo, " +
																	"ordem_servico.arquivo, " +
																	"ordem_servico.situacao, " +
																	"ordem_servico.cte " +
																	"from ordem_servico left join cad_clientes on (ordem_servico.remetente = cad_clientes.codigo) order by indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarPagamento(Pagamento pagamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cliente, tipo, situacao, vencimento, (valor + juros) as valor from pagamentos where indice = :numero;", Conn);

				com.Parameters.Add(new NpgsqlParameter("numero", pagamento.Numero));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				pagamento.Tipo = dr["tipo"].ToString()[0];
				pagamento.Situacao = dr["situacao"].ToString()[0];

				if (dr["cliente"].ToString().Length > 0)
				{
					pagamento.Cliente = new Cliente();

					pagamento.Cliente.Codigo = int.Parse(dr["cliente"].ToString());
				}

				if (dr["vencimento"].ToString().Length > 0)
				{
					pagamento.Vencimento = DateTime.Parse(dr["vencimento"].ToString());
				}

				pagamento.Valor = new double[1];

				pagamento.Valor[0] = double.Parse(dr["valor"].ToString());

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarPagamentoNumero(Pagamento pagamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cliente, tipo, situacao, vencimento, (valor + juros) as valor, total_pago from pagamentos where numero = :numero;", Conn);

				com.Parameters.Add(new NpgsqlParameter("numero", pagamento.Numero));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				pagamento.Tipo = dr["tipo"].ToString()[0];
				pagamento.Situacao = dr["situacao"].ToString()[0];

				if (dr["cliente"].ToString().Length > 0)
				{
					pagamento.Cliente = new Cliente();

					pagamento.Cliente.Codigo = long.Parse(dr["cliente"].ToString());
				}

				if (dr["vencimento"].ToString().Length > 0)
				{
					pagamento.Vencimento = DateTime.Parse(dr["vencimento"].ToString());
				}

				pagamento.Valor = new double[1];

				pagamento.Valor[0] = double.Parse(dr["valor"].ToString());

				double.TryParse(dr["total_pago"].ToString(), out pagamento.TotalPago);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public decimal CarregarPagamentosPedido(int pedido, DataSet ds)
		{
			try
			{
				decimal valor;

				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos " +
														"where pedido = :pedido and situacao = 'A'", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				decimal.TryParse(dr[0].ToString(), out valor);

				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pagamentos.indice as codigo, " +
																	"pagamentos.tipo, " +
																	"pagamentos_formas.descricao, " +
																	"pagamentos.valor " +
																	"from pagamentos " +
																	"left join pagamentos_formas on (pagamentos_formas.codigo = pagamentos.tipo) " +
																	"where pedido = " + pedido.ToString() + " and situacao = 'A'", Conn);

				da.Fill(ds);

				return valor;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return 0;
			}
		}

		public bool CarregarPagamentosPeriodo(long cliente, DateTime de, DateTime ate, out double pago, out double entrada)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where data between :de and :ate and " +
														"cliente = :cliente and situacao <> 'C' and tipo = 'E' and (forma <> 'A' and forma <> 'P') and " +
														"pedido is not null");

				com.Parameters.Add(new NpgsqlParameter("de", de));
				com.Parameters.Add(new NpgsqlParameter("ate", ate));
				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));

				pago = getDouble(com);

				com.CommandText = "select sum(valor) from caixa_fluxo where data between :de and :ate and " +
									"cliente = :cliente and situacao <> 'C' and tipo = 'E' and (forma <> 'A' and forma <> 'P') and " +
									"pedido is null";

				entrada = getDouble(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				pago = 0;
				entrada = 0;

				return false;
			}
		}

		public bool CarregarPedido(int numero, Pedido pedido, bool carrega_itens_adicionais = true)
		{
			try
			{
				int n2;
				long auxiliar;
				decimal totalPedido;

				NpgsqlCommand com = new NpgsqlCommand("select data, " +
															"hora, " +
															"situacao, " +
															"itens, " +
															"total, " +
															"observacao, " +
															"taxa_entrega, " +
															"troco, " +
															"comanda, " +
															"cliente, " +
															"vendedor, " +
															"tabela, " +
															"motivo_cancelamento, " +
															"retira " +
															"from pedidos where indice = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", numero));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				pedido.NumeroPedido(numero);
				pedido.Data = DateTime.Parse(dr["data"].ToString());
				pedido.Hora = DateTime.Parse(dr["hora"].ToString());
				pedido.Situacao = char.Parse(dr["situacao"].ToString());
				//pedido.ItensPedido = new ItemPedido[int.Parse(dr["itens"].ToString())];
				//pedido.Valor = double.Parse(dr["valor"].ToString());

				if (dr["total"].ToString().Length > 0)
				{
					totalPedido = Convert.ToDecimal(dr["total"]);
				}
				else
				{
					totalPedido = 0;
				}

				if (dr["vendedor"].ToString().Length > 0)
				{
					pedido.Vendedor = CarregarRecurso(Convert.ToInt32(dr["vendedor"]));
				}

				pedido.Observacao = dr["observacao"].ToString();
				pedido.TaxaDeEntrega = Convert.ToDecimal(dr["taxa_entrega"]);
				pedido.Troco = dr["troco"].ToString().Length > 0 ? Convert.ToDecimal(dr["troco"]) : 0;

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda && dr["comanda"].ToString().Length > 0)
				{
					pedido.Comanda = Convert.ToInt32(dr["comanda"]);
				}

				if (long.TryParse(dr["cliente"].ToString(), out auxiliar))
				{
					pedido.ClientePedido(auxiliar);
				}

				if (dr["tabela"] != null && dr["tabela"].ToString() != "")
				{
					pedido.Tabela = CarregarTabela(Convert.ToInt32(dr["tabela"]));
				}
				else
				{
					pedido.Tabela = CarregarTabela(1);
				}

				pedido.MotivoDoCancelamento = dr["motivo_cancelamento"].ToString();
				pedido.Retirar = Convert.ToBoolean(dr["retira"]);

				com.Parameters.Clear();

				com.CommandText = "select numero, produto, unitario, fracao, preco, observacao, indice, usuario, vendedor " +
									"from pedidos_itens where pedido = :pedido and situacao = 'A' " +
									"order by numero, indice";

				com.Parameters.Add(new NpgsqlParameter("pedido", numero));

				dr = com.ExecuteReader();

				int n = 0;
				n2 = numero;

				while (dr.Read())
				{
					double d;
					int indice_item;
					ItemPedido item = new ItemPedido();

					if (double.TryParse(dr["preco"].ToString(), out d))
					{
						item.Secundario = false;
						item.Unitario = Convert.ToDecimal(dr["unitario"]);
						item.Preco = Convert.ToDecimal(dr["preco"]);

						n2 = item.Numero;
					}
					else
					{
						item.Secundario = true;
					}

					item.Produto = Convert.ToInt64(dr["produto"]);
					item.ProdutoNome = ProdutoNome(item.Produto);
					item.Quantidade = (float)Convert.ToDouble(dr["fracao"]);
					item.Numero = Convert.ToInt32(dr["numero"]);
					item.Observacao = dr["observacao"].ToString();

					if (dr["vendedor"].ToString().Length > 0)
					{
						item.Recurso = Convert.ToInt32(dr["vendedor"]);
					}

					int.TryParse(dr["indice"].ToString(), out indice_item);

					if (carrega_itens_adicionais)
					{
						NpgsqlCommand com_adicionais;

						if (indice_item > 0)
						{
							com_adicionais = new NpgsqlCommand("select * from itens_adicionais where pedido = :pedido and item_pedido = :item_pedido and indice_item = :indice_item", Conn);

							com_adicionais.Parameters.Add("indice_item", indice_item);
						}
						else
						{
							com_adicionais = new NpgsqlCommand("select * from itens_adicionais where pedido = :pedido and item_pedido = :item_pedido", Conn);
						}

						com_adicionais.Parameters.Add(new NpgsqlParameter("pedido", numero));
						com_adicionais.Parameters.Add(new NpgsqlParameter("item_pedido", item.Numero));

						NpgsqlDataReader ad_reader = com_adicionais.ExecuteReader();

						while (ad_reader.Read())
						{
							decimal valor_adicional;
							decimal.TryParse(ad_reader["valor"].ToString(), out valor_adicional);

							item.ItensAdicionais.Add(new ItemAdicional() { Descricao = ad_reader["descricao"].ToString(), Valor = valor_adicional });
						}
					}

					pedido.NovoItem(item);
				}

				NpgsqlCommand com2 = new NpgsqlCommand("select count(indice) from pagamentos where pedido = :pedido and tipo = 'A' and situacao <> 'C'");
				com2.Parameters.Add(new NpgsqlParameter("pedido", numero));

				if (getInt(com2) > 0)
					pedido.Debito = true;

				if (totalPedido != pedido.TotalPedido)
				{
					pedido.TotalPedido = totalPedido;
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public Pedido CarregarPedido(int numero)
		{
			Pedido pedido = new Pedido();

			if (CarregarPedido(numero, pedido))
			{
				return pedido;
			}
			else
			{
				return null;
			}
		}

		public void CarregarPedidos(DataSet ds, int ultimo = 0)
		{
			try
			{
				string sql = "select * from (select pedidos.indice, " +
								"pedidos.data, " +
								"pedidos.hora, " +
								"pedidos.cliente, " +
								"cad_clientes.nome, " +
								"pedidos.itens, " +
								"pedidos.total, " +
								"pedidos.observacao, " +
								"pedidos.situacao " +
								"from pedidos " +
								"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) ";

				if (ultimo > 0)
				{
					sql += "where pedidos.indice < " + ultimo.ToString() + " ";
				}

				sql += "order by pedidos.indice desc limit 100) as a order by a.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarPedidos(DataSet ds, long cliente)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos.indice as codigo, " +
																"pedidos.data, " +
																"pedidos.hora, " +
																"pedidos.itens, " +
																"pedidos.valor, " +
																"pedidos.observacao, " +
																"pedidos.situacao " +
																"from pedidos " +
																"where pedidos.cliente = " + cliente.ToString() + " " +
																"order by pedidos.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Carrega o histórico de pedidos de determinado cliente
		/// </summary>
		/// <param name="cliente">Cliente do qual iremos pesquisar o histórico</param>
		/// <returns>Tabela com histórico de pedidos</returns>
		public DataTable CarregarPedidos(Cliente cliente)
		{
			if (cliente != null && cliente.Codigo > 0)
			{
				DataSet ds = new DataSet();

				CarregarPedidos(ds, cliente.Codigo);

				if (ds != null && ds.Tables.Count > 0)
				{
					return ds.Tables[0];
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
		}

		public Task<DataSet> CarregarPedidosAsync(int usuario)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				CarregarPedidos(ds);
				return ds;
			});
		}

		public bool AlterarTaxaEntregador(Pedido pedido, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos set taxa_entregador = :taxa where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("taxa", pedido.TaxaEntregador));
			com.Parameters.Add(new NpgsqlParameter("indice", pedido.Numero));

			return ExecCommand(com);
		}

		public bool CarregarPontos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pontos.indice, " +
																"pontos.data, " +
																"pontos.hora, " +
																"pontos.situacao, " +
																"pontos.tipo, " +
																"pontos.funcionario, " +
																"cad_recursos.nome " +
																"from pontos left join cad_recursos on (pontos.funcionario = cad_recursos.codigo) " +
																"order by pontos.indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarProduto(int tabela, long codigo, out string nome, out string descricao, out decimal preco)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cad_produtos.nome, " +
														"cad_produtos.descricao, " +
														"produtos_precos.preco, " +
														"cad_produtos.situacao " +
														"from cad_produtos " +
														"inner join produtos_precos on (produtos_precos.produto = cad_produtos.codigo) " +
														"where produtos_precos.tabela = :tabela and cad_produtos.codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("tabela", tabela));
				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					nome = string.Empty;
					descricao = string.Empty;
					preco = 0;

					return false;
				}

				nome = dr["nome"].ToString();
				descricao = dr["descricao"].ToString();
				preco = decimal.Parse(dr["preco"].ToString());

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				nome = null;
				descricao = null;
				preco = 0;

				return false;
			}
		}

		public Produto CarregarProduto(long codigo)
		{
			try
			{
				Produto produto = new Produto();

				NpgsqlCommand com = new NpgsqlCommand("select nome, tipo, grupo, descricao, situacao, grupo_tributario, medida, medida_tributavel, producao, fornecedor, foto, " +
					"ncm, cfop, ean, ean_trib, quantidade_tributavel from cad_produtos where codigo = :pcodigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("pcodigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				produto.Codigo = codigo;
				produto.Nome = dr["nome"].ToString();

				int tipo;
				int.TryParse(dr["tipo"].ToString(), out tipo);
				produto.Tipo = tipo;

				if (tipo > 0)
				{
					produto.ProdutoTipo = CarregarProdutoTipo(tipo);
				}

				int grupo;
				int.TryParse(dr["grupo"].ToString(), out grupo);
				produto.Grupo = grupo;

				produto.Descricao = dr["descricao"].ToString();

				produto.Foto = dr["foto"].ToString();
				produto.Situacao = dr["situacao"].ToString()[0];

				int grupo_tributario;
				int.TryParse(dr["grupo_tributario"].ToString(), out grupo_tributario);
				produto.GrupoTributario = grupo_tributario;

				int medida;
				int.TryParse(dr["medida"].ToString(), out medida);
				produto.Medida = new Medida(medida);

				int medida_tributavel;
				int.TryParse(dr["medida_tributavel"].ToString(), out medida_tributavel);
				produto.MedidaTributavel = new Medida(medida_tributavel);

				produto.Producao = bool.Parse(dr["producao"].ToString());

				long fornecedor;
				long.TryParse(dr["fornecedor"].ToString(), out fornecedor);
				produto.Fornecedor = new Fornecedor(fornecedor);

				produto.NCM = dr["ncm"].ToString();
				produto.CFOP = dr["cfop"].ToString();
				produto.EAN = dr["ean"].ToString();
				produto.EANTrib = dr["ean_trib"].ToString();

				int quantidade_tributavel;
				int.TryParse(dr["quantidade_tributavel"].ToString(), out quantidade_tributavel);
				produto.QuantidadeTributavel = quantidade_tributavel;

				return produto;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public DataTable CarregarProdutosLocacao()
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_produtos.codigo, cad_produtos.nome, cad_produtos.situacao, cad_produtos.descricao, produtos_tipos.nome " +
					"from cad_produtos left join produtos_tipos on(produtos_tipos.codigo = cad_produtos.tipo) where produtos_tipos.permite_locacao = true order by cad_produtos.codigo", Conn);

				DataSet ds = new DataSet();
				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public void CarregarPromissorias(long cliente, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select numero as indice, data, vencimento, pago_data, (valor + juros) as valor, parcela, multa, total_pago, situacao, pedido " +
																"from pagamentos where cliente = " + cliente.ToString() + " and tipo = 'P' order by indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void CarregarPromissorias(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select numero as indice, to_char(data, 'DD/MM/YY') as data, to_char(hora::time, 'HH24:MI:SS') as hora, " +
																"to_char(vencimento, 'DD/MM/YY') as vencimento, to_char(pago_data, 'DD/MM/YY') as pago_data, " +
																"to_char(pago_hora::time, 'HH24:MI:SS') as pago_hora, valor, juros, parcela, multa, total_pago, situacao, pedido, cliente " +
																"from pagamentos where tipo = 'P' and situacao <> 'C' order by indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarPromissorias(DateTime inicial, DateTime final, bool porEmissao, bool pagas, bool abertas, DataSet ds)
		{
			try
			{
				string sql;

				sql = "select pagamentos.indice, " +
							"pagamentos.data, " +
							"pagamentos.pedido, " +
							"pagamentos.valor, " +
							"pagamentos.parcela, " +
							"pagamentos.vencimento, " +
							"pagamentos.pago_data, " +
							"pagamentos.multa, " +
							"pagamentos.juros, " +
							"pagamentos.total_pago, " +
							"pagamentos.cliente, " +
							"cad_clientes.nome as cliente_nome, " +
							"pagamentos.numero, " +
							"pagamentos.situacao " +
							"from pagamentos " +
							"left join cad_clientes on (cad_clientes.codigo = pagamentos.cliente) ";

				if (pagas && abertas)
				{
					sql += "where pagamentos.situacao <> 'C' ";
				}
				else if (abertas)
				{
					sql += "where (pagamentos.situacao = 'A' or pagamentos.situacao = 'R') ";
				}
				else if (pagas)
				{
					sql += "where (pagamentos.situacao = 'P') ";
				}

				sql += "and pagamentos.tipo = 'P' ";

				if (porEmissao)
				{
					sql += "and pagamentos.data between to_date('" + inicial.ToString("ddMMyyyy") + "', 'DDMMYYYY') and " +
														"to_date('" + final.ToString("ddMMyyyy") + "', 'DDMMYYYY') ";
				}
				else
				{
					sql += "and pagamentos.pago_data between to_date('" + inicial.ToString("ddMMyyyy") + "', 'DDMMYYYY') and " +
									"to_date('" + final.ToString("ddMMyyyy") + "', 'DDMMYYYY') ";
				}

				sql += "order by pagamentos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarPromissorias(long cliente, DateTime inicial, DateTime final, bool pagas, DataSet ds)
		{
			try
			{
				string sql;

				sql = "select pagamentos.indice, " +
							"pagamentos.data, " +
							"pagamentos.pedido, " +
							"pagamentos.valor, " +
							"pagamentos.parcela, " +
							"pagamentos.vencimento, " +
							"pagamentos.pago_data, " +
							"pagamentos.multa, " +
							"pagamentos.juros, " +
							"pagamentos.total_pago, " +
							"pagamentos.numero, " +
							"pagamentos.situacao " +
							"from pagamentos " +
							"left join cad_clientes on (cad_clientes.codigo = pagamentos.cliente) ";

				if (pagas)
				{
					sql += "where pagamentos.situacao <> 'C' ";
				}
				else
				{
					sql += "where (pagamentos.situacao = 'A' or pagamentos.situacao = 'R') ";
				}

				sql += "and pagamentos.tipo = 'P' ";

				sql += "and pagamentos.cliente = " + cliente.ToString() + " ";

				sql += "and pagamentos.data between to_date('" + inicial.ToString("ddMMyyyy") + "', 'DDMMYYYY') and " +
													"to_date('" + final.ToString("ddMMyyyy") + "', 'DDMMYYYY') ";

				sql += "order by pagamentos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarRecebimentosDia(DateTime dia, out double dinheiro, out double cheque, out double cartao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'D' and pedido is null");

				com.Parameters.Add(new NpgsqlParameter("data", dia));

				dinheiro = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'X' and pedido is null";

				cheque = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'C' and pedido is null";

				cartao = getDouble(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				dinheiro = 0;
				cheque = 0;
				cartao = 0;

				return false;
			}
		}

		/// <summary>
		/// Preenche uma classe Recurso, de acordo com o código previamente definido.
		/// </summary>
		/// <param name="recurso">Classe Recurso com o código já definido</param>
		/// <param name="usuario">Usuário logado no sistema</param>
		/// <returns>True caso o recurso tenha sido encontrado e preenchido, false no caso de código inválido ou erro ao preencher o Recurso.</returns>
		public bool CarregarRecurso(Recurso recurso)
		{
			try
			{
				if (recurso == null || recurso.Codigo < 1)
				{
					return false;
				}

				NpgsqlCommand com = new NpgsqlCommand("select cad_recursos.nome, " +
														"cad_recursos.tipo, " +
														"recursos_tipos.descricao, " +
														"cad_recursos.cadastro, " +
														"cad_recursos.situacao, " +
														"cad_recursos.nascimento, " +
														"cad_recursos.tel1, " +
														"cad_recursos.tel2, " +
														"cad_recursos.celular, " +
														"cad_recursos.rg, " +
														"cad_recursos.cpf, " +
														"cad_recursos.habilitacao, " +
														"cad_recursos.estado, " +
														"cad_recursos.email " +
														"from cad_recursos " +
														"left join recursos_tipos on (recursos_tipos.codigo = cad_recursos.tipo) " +
														"where cad_recursos.codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				recurso.Nome = dr["nome"].ToString();
				recurso.Tipo = dr["tipo"].ToString()[0];
				recurso.Situacao = dr["situacao"].ToString()[0];
				recurso.Nascimento = Convert.ToDateTime(dr["nascimento"]);

				if (dr["tel1"].ToString().Length > 0)
				{
					recurso.Telefone1 = Convert.ToInt64(dr["tel1"]);
				}

				if (dr["tel2"].ToString().Length > 0)
				{
					recurso.Telefone2 = Convert.ToInt64(dr["tel2"]);
				}

				if (dr["celular"].ToString().Length > 0)
				{
					recurso.Celular = Convert.ToInt64(dr["celular"]);
				}

				recurso.Rg = dr["rg"].ToString();
				recurso.Cpf = dr["cpf"].ToString();
				recurso.Habilitacao = dr["habilitacao"].ToString();
				recurso.Estado = dr["estado"].ToString();
				recurso.Email = dr["email"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public Recurso CarregarRecurso(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cad_recursos.nome, " +
														"cad_recursos.tipo, " +
														"recursos_tipos.descricao, " +
														"cad_recursos.cadastro, " +
														"cad_recursos.situacao, " +
														"cad_recursos.nascimento, " +
														"cad_recursos.tel1, " +
														"cad_recursos.tel2, " +
														"cad_recursos.celular, " +
														"cad_recursos.rg, " +
														"cad_recursos.cpf, " +
														"cad_recursos.habilitacao, " +
														"cad_recursos.estado, " +
														"cad_recursos.email " +
														"from cad_recursos " +
														"left join recursos_tipos on (recursos_tipos.codigo = cad_recursos.tipo) " +
														"where cad_recursos.codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				Recurso recurso = new Recurso();

				recurso.Codigo = codigo;
				recurso.Nome = dr["nome"].ToString();
				recurso.Tipo = dr["tipo"].ToString()[0];
				recurso.Situacao = dr["situacao"].ToString()[0];
				recurso.Nascimento = Convert.ToDateTime(dr["nascimento"]);

				if (dr["tel1"].ToString().Length > 0)
				{
					recurso.Telefone1 = Convert.ToInt64(dr["tel1"]);
				}

				if (dr["tel2"].ToString().Length > 0)
				{
					recurso.Telefone2 = Convert.ToInt64(dr["tel2"]);
				}

				if (dr["celular"].ToString().Length > 0)
				{
					recurso.Celular = Convert.ToInt64(dr["celular"]);
				}

				recurso.Rg = dr["rg"].ToString();
				recurso.Cpf = dr["cpf"].ToString();
				recurso.Habilitacao = dr["habilitacao"].ToString();
				recurso.Estado = dr["estado"].ToString();
				recurso.Email = dr["email"].ToString();

				return recurso;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarRecursos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_recursos.codigo, " +
																	"cad_recursos.nome, " +
																	"cad_recursos.tipo, " +
																	"recursos_tipos.descricao, " +
																	"recursos_tipos.entrega, " +
																	"recursos_tipos.producao, " +
																	"cad_recursos.cadastro, " +
																	"cad_recursos.situacao, " +
																	"cad_recursos.nascimento, " +
																	"cad_recursos.tel1, " +
																	"cad_recursos.tel2, " +
																	"cad_recursos.celular, " +
																	"cad_recursos.rg, " +
																	"cad_recursos.cpf, " +
																	"cad_recursos.habilitacao, " +
																	"cad_recursos.email " +
																	"from cad_recursos " +
																	"left join recursos_tipos on (recursos_tipos.codigo = cad_recursos.tipo) " +
																	"order by cad_recursos.codigo", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public List<Recurso> CarregarRecursos()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cad_recursos.codigo from cad_recursos where situacao = 'A' order by cad_recursos.codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Recurso> recursos = new List<Recurso>();

				while (dr.Read())
				{
					Recurso r = CarregarRecurso(Convert.ToInt32(dr["codigo"]));

					recursos.Add(r);
				}

				return recursos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarRecursosGrupos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, situacao from recursos_grupos order by descricao", Conn);
				da.Fill(ds);
				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool CarregarRecursoTipo(RecursoTipo recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao, " +
																"entrega, " +
																"producao, " +
																"comissao_diaria, " +
																"comissao_nominal, " +
																"fixo_semanal, " +
																"fixo_mensal, " +
																"valor_entrega " +
																"from recursos_tipos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo.ToString()));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				recurso.Descricao = dr["descricao"].ToString();
				recurso.Entrega = bool.Parse(dr["entrega"].ToString());
				recurso.Producao = bool.Parse(dr["producao"].ToString());
				recurso.ComissaoDiaria = float.Parse(dr["comissao_diaria"].ToString());
				recurso.ComissaoNominal = float.Parse(dr["comissao_nominal"].ToString());
				recurso.FixoSemanal = decimal.Parse(dr["fixo_semanal"].ToString());
				recurso.FixoMensal = decimal.Parse(dr["fixo_mensal"].ToString());
				recurso.ValorEntrega = decimal.Parse(dr["valor_entrega"].ToString());

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarRegrasDeNegocios()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select * from regras_negocios", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					switch (dr["chave"].ToString())
					{
						case "aviso_estoque":
							RegrasDeNegocio.Instance.AvisoEstoque = Convert.ToInt32(dr["valor"]);
							break;

						case "bloqueia_cliente_anonimo":
							RegrasDeNegocio.Instance.BloqueiaClienteAnonimo = Convert.ToBoolean(dr["valor"]);
							break;

						case "bloqueia_estoque":
							RegrasDeNegocio.Instance.BloqueiaEstoque = Convert.ToBoolean(dr["valor"]);
							break;

						case "controla_entregas":
							RegrasDeNegocio.Instance.ControlaEntregas = Convert.ToBoolean(dr["valor"]);
							break;

						case "controla_processos":
							RegrasDeNegocio.Instance.ControlaProcessos = Convert.ToBoolean(dr["valor"]);
							break;

						case "emite_cupom_fiscal":
							RegrasDeNegocio.Instance.EmiteCupomFiscal = Convert.ToBoolean(dr["valor"]);
							break;

						case "fecha_caixa_automaticamente":
							RegrasDeNegocio.Instance.FechaCaixaAutomaticamente = Convert.ToBoolean(dr["valor"]);
							break;

						case "ordem_coleta_vias":
							RegrasDeNegocio.Instance.OrdemDeColetaVias = Convert.ToInt32(dr["valor"]);
							break;

						case "ramo":
							RegrasDeNegocio.Instance.Ramo = dr["valor"].ToString();
							break;

						case "registra_vendedor":
							RegrasDeNegocio.Instance.RegistraVendedor = Convert.ToBoolean(dr["valor"]);
							break;

						case "taxa_entrega_grupo":
							RegrasDeNegocio.Instance.TaxaEntregaPorGrupo = Convert.ToBoolean(dr["valor"]);
							break;

						case "entrega_automatica_cliente_interno_pagamento":
							RegrasDeNegocio.Instance.EntregaAutomaticaClientesInternosPagamento = Convert.ToBoolean(dr["valor"]);
							break;

						case "termo_de_responsabilidade":
							RegrasDeNegocio.Instance.TermoDeResponsabilidade = dr["valor"].ToString();
							break;

						case "recibo_de_devolucao":
							RegrasDeNegocio.Instance.ReciboDeDevolucao = dr["valor"].ToString();
							break;

						case "aviso_atraso":
							RegrasDeNegocio.Instance.AvisoAtraso = Convert.ToInt32(dr["valor"]);
							break;

						case "segundos_alerta":
							RegrasDeNegocio.Instance.SegundosAlerta = Convert.ToInt32(dr["valor"]);
							break;

						case "produto_fracionado_preco_medio":
							RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio = Convert.ToBoolean(dr["valor"]);
							break;

						case "busca_endereco_por_cep":
							RegrasDeNegocio.Instance.BuscaEnderecoPorCep = Convert.ToBoolean(dr["valor"]);
							break;

						case "gerencia_disponibilidade_de_entregadores":
							RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores = Convert.ToBoolean(dr["valor"]);
							break;

						case "controla_por_comandas":
							RegrasDeNegocio.Instance.ControlaPedidosPorComanda = Convert.ToBoolean(dr["valor"]);
							break;

						case "baixa_pedidos_fechamento_diario":
							RegrasDeNegocio.Instance.BaixaPedidosNoFechamentoDiario = Convert.ToBoolean(dr["valor"]);
							break;

						case "itens_adicionais_por_produto":
							RegrasDeNegocio.Instance.ItensAdicionaisPorProduto = Convert.ToBoolean(dr["valor"]);
							break;

						case "itens_adicionais_por_tipo_de_produto":
							RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto = Convert.ToBoolean(dr["valor"]);
							break;

						case "modelo_impressao":
							RegrasDeNegocio.Instance.ModeloImpressao = dr["valor"].ToString();
							break;

						case "imprimir_linha_entre_itens":
							RegrasDeNegocio.Instance.ImprimirLinhaEntreItens = Convert.ToBoolean(dr["valor"]);
							break;

						case "agrupa_produtos_por_tipo":
							RegrasDeNegocio.Instance.AgrupaProdutosPorTipo = Convert.ToBoolean(dr["valor"]);
							break;

						case "imprimir_usuario_na_comanda":
							RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda = Convert.ToBoolean(dr["valor"]);
							break;

						case "imprimir_vendedor_na_comanda":
							RegrasDeNegocio.Instance.ImprimirVendedorNaComanda = Convert.ToBoolean(dr["valor"]);
							break;

						case "observacao_obrigatoria_no_pedido":
							RegrasDeNegocio.Instance.ObservacaoObrigatoriaNoPedido = Convert.ToBoolean(dr["valor"]);
							break;

						case "taxa_de_entrega_por_cliente":
							RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente = Convert.ToBoolean(dr["valor"]);
							break;

						case "motivo_obrigatorio_no_cancelamento":
							RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento = Convert.ToBoolean(dr["valor"]);
							break;

						case "pagamento_no_lancamento":
							RegrasDeNegocio.Instance.PagamentoNoLancamento = Convert.ToBoolean(dr["valor"]);
							break;

						case "duas_vias_no_balcao":
							RegrasDeNegocio.Instance.DuasViasNoBalcao = Convert.ToBoolean(dr["valor"]);
							break;

						case "pagamento_automatico_de_entregadores":
							RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores = Convert.ToBoolean(dr["valor"]);
							break;

						case "precos_em_aberto":
							RegrasDeNegocio.Instance.PrecosEmAberto = Convert.ToBoolean(dr["valor"]);
							break;

						case "permite_fechamento_com_pedidos_em_aberto":
							RegrasDeNegocio.Instance.PermiteFechamentoComPedidosEmAberto = Convert.ToBoolean(dr["valor"]);
							break;

						case "taxa_paga_por_entrega":
							RegrasDeNegocio.Instance.TaxaPagaPorEntrega = Convert.ToBoolean(dr["valor"]);
							break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar regras de negócios. Entre em contato com o suporte!", "DSoft BD");
			}
		}

		public Task<List<Recurso>> CarregarResursosAsync()
		{
			return Task.Factory.StartNew<List<Recurso>>(() =>
			{
				return CarregarRecursos();
			});
		}

		public TabelaDePrecos CarregarTabela(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, descricao, situacao from cad_tabelas where codigo = :pcodigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("pcodigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				TabelaDePrecos tabela = new TabelaDePrecos(codigo);
				tabela.Nome = dr["nome"].ToString();
				tabela.Descricao = dr["descricao"].ToString();
				tabela.Situacao = dr["situacao"].ToString()[0];

				return tabela;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarTabelas(out string[] tabelas)
		{
			try
			{
				int indice = 0;

				NpgsqlCommand com = new NpgsqlCommand("select count(indice) from cad_tabelas where situacao = 'A'");

				indice = getInt(com);

				if (indice < 1)
				{
					tabelas = null;

					return false;
				}

				tabelas = new string[indice];

				com.Dispose();

				com = new NpgsqlCommand("select codigo, nome from cad_tabelas where situacao = 'A' order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				indice = 0;

				while (dr.Read())
				{
					tabelas[indice++] = dr[0].ToString() + " - " + dr[1].ToString();
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				tabelas = null;

				return false;
			}
		}


		public List<TabelaDePrecos> CarregarTabelas()
		{
			try
			{
				List<TabelaDePrecos> tabelas = new List<TabelaDePrecos>();

				NpgsqlCommand com = new NpgsqlCommand("select codigo, nome, descricao from cad_tabelas where situacao = 'A' order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					TabelaDePrecos tabela = new TabelaDePrecos();
					tabela.Codigo = Convert.ToInt32(dr[0]);
					tabela.Nome = dr[1].ToString();
					tabela.Descricao = dr[2].ToString();

					tabelas.Add(tabela);
				}

				return tabelas;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public Task<List<TabelaDePrecos>> CarregarTabelasAsync()
		{
			return Task.Factory.StartNew<List<TabelaDePrecos>>(() =>
			{
				List<TabelaDePrecos> tabelas = CarregarTabelas();
				return tabelas;
			});
		}

		public Usuario CarregarUsuario(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, senha, nivel, situacao, recurso from cad_usuarios where codigo = :pcodigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("pcodigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				Usuario usuario = new Usuario(codigo);
				usuario.Nome = dr["nome"].ToString();
				usuario.Senha = dr["senha"].ToString();
				usuario.Nivel = dr["nivel"].ToString()[0];
				usuario.Situacao = dr["situacao"].ToString()[0];
				usuario.NivelUsuario = CarregarNivelUsuario(usuario.Nivel.ToString());

				if (dr["recurso"].ToString().Length > 0)
				{
					usuario.Recurso = CarregarRecurso(Convert.ToInt32(dr["recurso"]));
				}

				return usuario;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public Usuario CarregarUsuario(int codigo, string senha)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, senha, nivel, situacao from cad_usuarios where codigo = :pcodigo and senha = :senha", Conn);

				com.Parameters.Add(new NpgsqlParameter("pcodigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("senha", senha));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return null;
				}

				Usuario usuario = new Usuario(codigo);
				usuario.Nome = dr["nome"].ToString();
				usuario.Nivel = dr["nivel"].ToString()[0];
				usuario.Situacao = dr["situacao"].ToString()[0];
				usuario.NivelUsuario = CarregarNivelUsuario(usuario.Nivel.ToString());

				return usuario;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool CarregarVeiculo(Veiculo veiculo)
		{
			try
			{
				if (veiculo == null || veiculo.Placa == "")
				{
					return false;
				}

				NpgsqlCommand com = new NpgsqlCommand("select modelo, " +
														"ano, " +
														"cor, " +
														"marca, " +
														"proprietario, " +
														"endereco, " +
														"cidade, " +
														"estado, " +
														"telefone, " +
														"cpf, " +
														"ie, " +
														"tara, " +
														"capkg, " +
														"capm3, " +
														"situacao, " +
														"renavam " +
														"from cad_veiculos where placa = :placa", Conn);

				com.Parameters.Add(new NpgsqlParameter("placa", veiculo.Placa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				veiculo.Modelo = dr["modelo"].ToString();
				veiculo.Ano = Convert.ToInt32(dr["ano"]);
				veiculo.Cor = dr["cor"].ToString();
				veiculo.Marca = dr["marca"].ToString();
				veiculo.Proprietario = dr["proprietario"].ToString();
				veiculo.Endereco = dr["endereco"].ToString();
				veiculo.Cidade = dr["cidade"].ToString();
				veiculo.Estado = dr["estado"].ToString();
				veiculo.Telefone = dr["telefone"].ToString();
				veiculo.Cpf = dr["cpf"].ToString();
				veiculo.IE = dr["ie"].ToString();
				veiculo.Tara = dr["tara"].ToString();
				veiculo.CapKg = dr["capkg"].ToString();
				veiculo.CapM3 = dr["capm3"].ToString();
				veiculo.Situacao = dr["situacao"].ToString()[0];

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void CarregarVeiculos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select placa, " +
																"modelo, " +
																"ano, " +
																"cor, " +
																"marca, " +
																"proprietario, " +
																"endereco, " +
																"cidade, " +
																"estado, " +
																"telefone, " +
																"cpf, " +
																"renavam, " +
																"tara, " +
																"capkg, " +
																"capm3, " +
																"rntrc, " +
																"ie, " +
																"situacao from cad_veiculos order by placa", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool CarregarVendasDia(DateTime dia, out double vendas, out int volume, out double dinheiro, out double cheque, out double cartao,
			out double debito, out double crediario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pedidos where situacao <> 'C' and data = :data");

				com.Parameters.Add(new NpgsqlParameter("data", dia));

				vendas = getDouble(com);

				com.CommandText = "select count(indice) from pedidos where situacao <> 'C' and data = :data";

				volume = getInt(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'D' and pedido is not null";

				dinheiro = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'X' and pedido is not null";

				cheque = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'C' and pedido is not null";

				cartao = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'A' and pedido is not null";

				debito = getDouble(com);

				com.CommandText = "select sum(valor) from pagamentos where situacao <> 'C' and data = :data and tipo = 'P' and pedido is not null";

				crediario = getDouble(com);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				vendas = 0;
				volume = 0;
				dinheiro = 0;
				cheque = 0;
				cartao = 0;
				debito = 0;
				crediario = 0;

				return false;
			}
		}

		public bool ClienteCadastrado(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read() || dr[0].ToString() == string.Empty)
				{
					return false;
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public string ClienteCidade(long codigo)
		{
			return getString(new NpgsqlCommand("select cidade from cad_clientes where codigo = " + codigo.ToString()));
		}

		public long ClienteCodigo(string nome)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_clientes where nome = :nome limit 1", Conn);

				com.Parameters.Add(new NpgsqlParameter("nome", nome));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				return long.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public string ClienteDocumento(long codigo)
		{
			return getString(new NpgsqlCommand("select documento from cad_clientes where codigo = " + codigo.ToString()));
		}

		public bool ClienteEndereco(long codigo, out string endereco, out string bairro)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select endereco, numero, bairro from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					endereco = string.Empty;
					bairro = string.Empty;

					return false;
				}

				endereco = dr["endereco"].ToString();

				if (dr["numero"].ToString() != "")
				{
					endereco += ", " + dr["numero"].ToString();
				}

				bairro = dr["bairro"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				endereco = string.Empty;
				bairro = string.Empty;

				return false;
			}
		}

		public int ClienteGrupo(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select grupo from cad_clientes where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public string ClienteGrupoDescricao(int grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from clientes_grupos where codigo = :grupo", Conn);

				com.Parameters.Add(new NpgsqlParameter("grupo", grupo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public string ClienteIE(long codigo)
		{
			return getString(new NpgsqlCommand("select inscricao_estadual from cad_clientes where codigo = " + codigo.ToString()));
		}

		public bool ClienteInterno(long cliente)
		{
			NpgsqlCommand com = new NpgsqlCommand("select clientes_tipos.cliente_interno from cad_clientes left join clientes_tipos on (clientes_tipos.codigo = cad_clientes.tipo_cliente) " +
													"where cad_clientes.codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", cliente));

			return getBool(com);
		}

		public double ClienteLimite(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cliente_limite(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return double.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public bool ClienteLimite(long cliente, double limite)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cliente_limite(:codigo, :limite)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", cliente));
				com.Parameters.Add(new NpgsqlParameter("limite", limite));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ClienteNome(long codigo, out string nome, out char situacao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, situacao from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					nome = string.Empty;
					situacao = default(char);

					return false;
				}

				nome = dr["nome"].ToString();
				situacao = char.Parse(dr["situacao"].ToString());

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				nome = string.Empty;
				situacao = default(char);

				return false;
			}
		}

		public string ClienteNome(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool ClienteReferencia(long codigo, out string referencia)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select referencia from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					referencia = string.Empty;

					return false;
				}

				referencia = dr["referencia"].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				referencia = string.Empty;

				return false;
			}
		}

		public double ClienteSaldo(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cliente_saldo(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return double.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public void ClientesGrupos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, situacao from clientes_grupos order by nome", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool ClienteTelefones(long codigo, out string tel1, out string tel2, out string cel)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select tel1, tel2, celular from cad_clientes where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					tel1 = tel2 = cel = string.Empty;

					return false;
				}

				tel1 = dr[0].ToString();
				tel2 = dr[1].ToString();
				cel = dr[2].ToString();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				tel1 = tel2 = cel = string.Empty;

				return false;
			}
		}

		public int CodigoEstado(string sigla)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from estados where sigla = :sigla", Conn);

				com.Parameters.Add(new NpgsqlParameter("sigla", sigla));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		[Obsolete]
		public int CodigoMunicipio(string nome)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from municipios where nome = :nome limit 1", conn);

				com.Parameters.Add(new NpgsqlParameter("nome", nome));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show("Município inválido!" + Environment.NewLine + e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		public int CodigoMunicipio(string nome, string uf)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from municipios where uf = :uf and nome = :nome limit 1", Conn);

				com.Parameters.Add(new NpgsqlParameter("uf", uf.ToUpper()));
				com.Parameters.Add(new NpgsqlParameter("nome", nome.ToUpper()));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					return int.Parse(dr[0].ToString());
				}
				else
				{
					return -1;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool Conecta(string host, string porta, string banco)
		{
			NpgsqlConnection conn;

			try
			{
				string conexao = "Server=" + host + ";Port=" + porta.ToString() + ";User Id=dsoft;Password=dsoft2008;Database=" + banco;

				Host = host;
				Porta = porta;
				Banco = banco;

				conn = new NpgsqlConnection(conexao);

				conn.Open();

				if (conn.State == System.Data.ConnectionState.Open)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (NpgsqlException ne)
			{
				if (ne.Code == "3D000")
				{
					if (MessageBox.Show("Banco-de-dados não encontrado! Se esse for o primeiro acesso ao sistema, clique em Sim, caso contrário entre em contato com o suporte.", "DSoft BD", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
						== DialogResult.Yes)
					{
						GiveAccess();

						CriarUsuario();

						if (CriarBD())
						{
							RestaurarBancoDeDados();
						}

						RevogeAccess();
					}
					else
					{
						return false;
					}
				}
				else if (ne.Code == "28P01")
				{
					if (MessageBox.Show("Não encontramos o banco-de-dados!\nSe esse for o primeiro acesso ao sistema, clique em Sim, para que o sistema crie seu novo banco-de-dados,\n caso contrário entre em contato com o suporte.", "DSoft BD", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
						== DialogResult.Yes)
					{
						GiveAccess();

						CriarUsuario();

						if (CriarBD())
						{
							RestaurarBancoDeDados();
						}

						RevogeAccess();
					}
					else
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool RestaurarBancoDeDados()
		{
			try
			{
				string folder = string.Empty;

				if (Terminal.ProcessadorPostgreSql == "x86")
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
				}
				else
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				}

				folder = Path.Combine(folder, "Postgresql");
				folder = Path.Combine(folder, Terminal.VersaoPostgreSql);
				folder = Path.Combine(folder, "bin");

				string comando = Path.Combine(folder, "pg_restore.exe");

				string argumentos = string.Format(" -i -w -h {0} -p {1} -U postgres -d {2} -v \"dsoft.backup\"", Host, Porta, Banco);
				//string saida;
				System.Diagnostics.Process processo = new System.Diagnostics.Process();

				processo.StartInfo.FileName = comando;
				processo.StartInfo.Arguments = argumentos;

				if (processo.Start())
				{
					//frmMain.Backupeando = true;

					while (!processo.HasExited)
					{
						//frmMain.ProgredirBarraPasso();

						System.Threading.Thread.Sleep(500);
					}

					//frmMain.Backupeando = false;

					return true;
				}
				else
				{
					MessageBox.Show("Não foi possivel criar o banco-de-dados!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao criar o banco-de-dados! Se o problema persistir, entre em contato com o suporte." + Environment.NewLine + e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ConfirmarEntregaCompra(int indice, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_confirma_entrega(:indice, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ConfirmarPagamento(Pagamento pagamento, int usuario)
		{
			try
			{
				/*NpgsqlCommand com = new NpgsqlCommand("select dsoft_confirma_pagamento(:numero, :data, '{'':forma1'','':forma2'','':forma3''}', '{'':doc1'','':doc2'','':doc3''}', '{:valor1,:valor2,:valor3}', :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("numero", pagamento.Numero));
				com.Parameters.Add(new NpgsqlParameter("data", pagamento.Data));
				com.Parameters.Add(new NpgsqlParameter("forma1", pagamento.Forma[0].ToString().ToUpper()));
				com.Parameters.Add(new NpgsqlParameter("forma2", pagamento.Forma[1].ToString().ToUpper()));
				com.Parameters.Add(new NpgsqlParameter("forma3", pagamento.Forma[2].ToString().ToUpper()));
				com.Parameters.Add(new NpgsqlParameter("doc1", pagamento.Documento[0]));
				com.Parameters.Add(new NpgsqlParameter("doc2", pagamento.Documento[1]));
				com.Parameters.Add(new NpgsqlParameter("doc3", pagamento.Documento[2]));
				com.Parameters.Add(new NpgsqlParameter("valor1", pagamento.Valor[0].ToString()));
				com.Parameters.Add(new NpgsqlParameter("valor2", pagamento.Valor[1].ToString()));
				com.Parameters.Add(new NpgsqlParameter("valor3", pagamento.Valor[2].ToString()));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				*/

				// Caso tenha multa, antes de confirmar o pagamento, adicionamos a multa
				if (pagamento.Multa > 0)
				{
					NpgsqlCommand com2 = new NpgsqlCommand("update pagamentos set multa = :multa where numero = :numero", Conn);
					com2.Parameters.Add(new NpgsqlParameter("multa", pagamento.Multa));
					com2.Parameters.Add(new NpgsqlParameter("numero", pagamento.Numero));
					com2.ExecuteNonQuery();
				}

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_confirma_pagamento(" + pagamento.Numero.ToString() + "," +
					"to_date('" + pagamento.Data.ToString("ddMMyy") + "','DDMMYY'), '" + pagamento.Forma[0].ToString().ToUpper() + "'," +
					"'" + pagamento.Forma[1].ToString().ToUpper() + "','" + pagamento.Forma[2].ToString().ToUpper() + "','" +
					pagamento.Documento[0] + "','" + pagamento.Documento[1] + "','" + pagamento.Documento[2] + "','{" +
					(pagamento.Valor[0] * 100).ToString("00000000") + "," + (pagamento.Valor[1] * 100).ToString("00000000") + "," + (pagamento.Valor[2] * 100).ToString("00000000") + "}'," + usuario.ToString() +
					"," + Caixa.Numero.ToString() + ");", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int ConhecimentoAtribuirErro(string cte, string msg)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set situacao = 'R', msg_erro = :msg where cte = :cte returning indice;");
			com.Parameters.Add(new NpgsqlParameter("cte", cte));
			com.Parameters.Add(new NpgsqlParameter("msg", msg));

			return getInt(com);
		}

		public int ConhecimentoMarcarAutorizado(string cte)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set situacao = 'U' where cte = :cte returning indice;");
			com.Parameters.Add(new NpgsqlParameter("cte", cte));

			return getInt(com);
		}

		public bool AutorizarManifesto(int manifesto, int numero, string protocolo, string destino)
		{
			NpgsqlCommand com = new NpgsqlCommand("update manifestos set numero = :numero, protocolo = :protocolo, arquivo = :arquivo where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("numero", numero));
			com.Parameters.Add(new NpgsqlParameter("protocolo", protocolo));
			com.Parameters.Add(new NpgsqlParameter("arquivo", destino));
			com.Parameters.Add(new NpgsqlParameter("indice", manifesto));

			return ExecCommand(com);
		}

		public int CriarNovaTabelaPrecos(string nome, DataTable dt)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_tabelas order by codigo desc limit 1");
				int codigo = getInt(com) + 1;

				com = new NpgsqlCommand("insert into cad_tabelas (codigo, nome, descricao, usuario) values(:codigo, :nome, :descricao, :usuario);");
				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", "TABELA CRIADA PARA O CLIENTE " + nome));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				ExecCommand(com);

				foreach (DataRow item in dt.Rows)
				{
					com = new NpgsqlCommand("insert into produtos_precos(tabela, produto, preco, usuario) values(:tabela, :produto, :preco, :usuario);");
					com.Parameters.Add(new NpgsqlParameter("tabela", codigo));
					com.Parameters.Add(new NpgsqlParameter("produto", Convert.ToInt64(item["codigo"])));
					com.Parameters.Add(new NpgsqlParameter("preco", Convert.ToDecimal(item["preco"])));
					com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
					ExecCommand(com);
				}

				return codigo;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
		}

		public void CriarTabelas()
		{
			try
			{
				string tabelas = File.ReadAllText("Tabelas.sql");

				if (tabelas != null)
				{
					NpgsqlCommand com = new NpgsqlCommand(tabelas, Conn);

					com.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public string CTeMensagemErro(int indice)
		{
			NpgsqlCommand com = new NpgsqlCommand("select msg_erro from ordem_servico where indice = :indice;");
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			return getString(com);
		}

		public bool DesbloquearCliente(int cliente, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desbloqueia_cliente(:cliente, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesbloquearProduto(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desbloqueia_produto(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesbloquearRecurso(int recurso, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desbloqueia_recurso(:recurso, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesbloquearTabela(int codigo, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desbloqueia_tabela(:codigo, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesbloquearUsuario(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desbloqueia_usuario(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesfazerCompra(int compra, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desfaz_compra(:usuario, :compra, :caixa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("compra", compra));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesfazerDespesa(int despesa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desfaz_despesa(:usuario, :despesa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("despesa", despesa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool DesfazerFechamentoDiario(int fechamento, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desfaz_fechamento(:fechamento, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public Task<bool> DesfazerFechamentoDiarioAsync(DateTime data)
		{
			return Task.Factory.StartNew<bool>(() =>
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desfaz_fechamento_diario(:data, :usuario);", Conn);
				com.Parameters.Add(new NpgsqlParameter("data", data.Date));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					return Convert.ToBoolean(dr[0]);
				}
				else
				{
					return false;
				}
			});
		}

		public double DespesasDia(DateTime dia)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'D' and data = :dia and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("dia", dia.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public Task<DataTable> DespesasPagasPeriodoAsync(DateTime inicial, DateTime final)
		{
			return Task.Factory.StartNew<DataTable>(() =>
			{
				string consulta = "select despesas.indice, " +
											"despesas.data, " +
											"despesas.vencimento, " +
											"despesas.pagamento, " +
											"despesas.valor, " +
											"despesas.valor_pago, " +
											"despesas.documento, " +
											"despesas.observacao, " +
											"despesas_tipo.nome " +
											"from despesas " +
											"left join despesas_tipo on despesas_tipo.codigo = despesas.tipo " +
											"where despesas.pagamento between todate('" + inicial.ToString("ddMMyy") + "') and " +
											"todate('" + final.ToString("ddMMyy") + "') " +
											"and despesas.pagamento is not null and situacao <> 'C' order by despesas.indice";

				DataSet ds = new DataSet();

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(consulta, Conn);

				da.Fill(ds);

				return ds.Tables[0];
			});
		}

		public double DespesasPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'D' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool DesvincularMaterial(int produto, int material)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_desvincula_produto_material(:produto, :material, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				com.Parameters.Add(new NpgsqlParameter("material", material));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public long EmitenteCnpj(string razao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cnpj from cad_emitentes where razao_social = :razao", Conn);

				com.Parameters.Add(new NpgsqlParameter("razao", razao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return 0;

				return long.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public string EmitenteRazaoSocial(long cnpj)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select razao_social from cad_emitentes where cnpj = :cnpj", Conn);

				com.Parameters.Add(new NpgsqlParameter("cnpj", cnpj));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return string.Empty;

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool EncerrarOcorrencia(Ocorrencia ocorrencia, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_encerra_ocorrencia(:indice, :usuario, :conclusao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ocorrencia.Indice));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("conclusao", ocorrencia.Conclusao));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public double EntradasCartaoPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where tipo = 'C' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double EntradasChequesPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where tipo = 'X' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double EntradasDinheiroPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where tipo = 'D' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double EntradasMasterPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where tipo = 'M' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double EntradasPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'E' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double EntradasVisaPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from pagamentos where tipo = 'V' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool EntregaPedido(int pedido, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_entrega_pedido(:pedido, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool EntregarCompra(int compra, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_entrega_compra(:usuario, :compra)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("compra", compra));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool EntregarManifesto(int manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_entrega_manifesto(:indice, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", manifesto));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void EntregasPorCliente(DateTime de, DateTime ate, DataSet ds)
		{
			try
			{
				string sql = "select entregas.indice as codigo, " +
									"to_char(entregas.data, 'DD/MM/YY') as data, " +
									"to_char(entregas.saida, 'HH:mm:SS') as saida, " +
									"to_char(entregas.entrega, 'HH:mm:SS') as entrega, " +
									"entregas.pedido, " +
									"pedidos.cliente, " +
									"cad_clientes.nome, " +
									"entregas.usuario, " +
									"cad_usuarios.nome, " +
									"entregas.situacao " +
									"from entregas " +
									"left join pedidos on (pedidos.indice = entregas.pedido) " +
									"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
									"left join cad_usuarios on (cad_usuarios.codigo = entregas.usuario) " +
									"where entregas.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and pedidos.cliente is not null " +
									"order by entregas.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void EntregasPorCliente(DateTime de, DateTime ate, int cliente, DataSet ds)
		{
			try
			{
				string sql = "select entregas.indice as codigo, " +
									"to_char(entregas.data, 'DD/MM/YY') as data, " +
									"to_char(entregas.saida, 'HH:mm:SS') as saida, " +
									"to_char(entregas.entrega, 'HH:mm:SS') as entrega, " +
									"entregas.pedido, " +
									"entregas.usuario, " +
									"cad_usuarios.nome, " +
									"entregas.situacao " +
									"from entregas " +
									"left join pedidos on (pedidos.indice = entregas.pedido) " +
									"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
									"left join cad_usuarios on (cad_usuarios.codigo = entregas.usuario) " +
									"where entregas.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and pedidos.cliente = " + cliente.ToString() +
									" order by entregas.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Consulta no banco-de-dados pelas entregas de determinando entregador no período especificado.
		/// </summary>
		/// <param name="recurso">Entregador</param>
		/// <param name="inicio">Início da consulta</param>
		/// <param name="fim">Final da consulta</param>
		/// <returns>DataTable com os dados solicitados. Null em caso de erro.</returns>
		public DataTable EntregasPorEntregador(Recurso recurso, DateTime inicio, DateTime fim, bool cancelados = false)
		{
			string sql = "select entregas.pedido, entregas.data, entregas.saida, entregas.entrega, entregas.situacao from entregas where recurso = " + recurso.Codigo
				+ " and data between to_date('" + inicio.Date.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + fim.Date.ToString("dd/MM/yy") + "', 'DD/MM/YY') ";

			if (!cancelados)
			{
				sql += " and entregas.situacao != 'C' ";
			}

			sql += " order by entregas.pedido";

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
			{
				return null;
			}

			return ds.Tables[0];
		}

		public void EntregasPorPeriodo(DateTime de, DateTime ate, DataSet ds)
		{
			try
			{
				string sql = "select entregas.indice as codigo, " +
									"to_char(entregas.data, 'DD/MM/YY') as data, " +
									"to_char(entregas.saida, 'HH:mm:SS') as saida, " +
									"to_char(entregas.entrega, 'HH:mm:SS') as entrega, " +
									"entregas.pedido, " +
									"entregas.recurso, " +
									"cad_recursos.nome, " +
									"entregas.usuario, " +
									"cad_usuarios.nome, " +
									"entregas.situacao " +
									"from entregas " +
									"left join cad_recursos on (cad_recursos.codigo = entregas.recurso) " +
									"left join cad_usuarios on (cad_usuarios.codigo = entregas.usuario) " +
									"where entregas.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"order by entregas.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void EntregasPorPeriodo(DateTime de, DateTime ate, int entregador, DataSet ds)
		{
			try
			{
				string sql = "select entregas.indice as codigo, " +
									"to_char(entregas.data, 'DD/MM/YY') as data, " +
									"to_char(entregas.saida, 'HH:mm:SS') as saida, " +
									"to_char(entregas.entrega, 'HH:mm:SS') as entrega, " +
									"entregas.pedido, " +
									"entregas.usuario, " +
									"cad_usuarios.nome, " +
									"entregas.situacao " +
									"from entregas " +
									"left join cad_recursos on (cad_recursos.codigo = entregas.recurso) " +
									"left join cad_usuarios on (cad_usuarios.codigo = entregas.usuario) " +
									"where entregas.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and entregas.recurso = " + entregador.ToString() +
									" order by entregas.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool ExcluirItemAdicional(ItemAdicional item)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_adicionais where descricao = :descricao and adicional = :adicional", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", item.Descricao));
			com.Parameters.Add(new NpgsqlParameter("adicional", item.Valor));
			return com.ExecuteNonQuery() > 0;
		}

		public bool ExcluirItemAdicional(ItemAdicional item, long produto)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_adicionais where descricao = :descricao and adicional = :adicional and produto = :produto", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", item.Descricao));
			com.Parameters.Add(new NpgsqlParameter("adicional", item.Valor));
			com.Parameters.Add(new NpgsqlParameter("produto", produto));
			return com.ExecuteNonQuery() > 0;
		}

		public bool ExcluirItemAdicional(ItemAdicional item, ProdutoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_adicionais where descricao = :descricao and adicional = :adicional and tipo = :tipo", Conn);
			com.Parameters.Add(new NpgsqlParameter("descricao", item.Descricao));
			com.Parameters.Add(new NpgsqlParameter("adicional", item.Valor));
			com.Parameters.Add(new NpgsqlParameter("tipo", tipo.Codigo));
			return com.ExecuteNonQuery() > 0;
		}

		public bool ExecCommand(string command)
		{
			return ExecCommand(new NpgsqlCommand(command));
		}

		public bool ExecCommand(NpgsqlCommand com)
		{
			return ExecCommand(com, _usuario);
		}

		public bool ExecCommand(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				com.Connection = conn;

				if (com.ExecuteNonQuery() > 0)
					return true;
				else
					return false;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);

				if (e is System.InvalidOperationException)
				{
				}
				else
				{
					MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				return false;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		public bool ExecQuery(string sql, DataSet ds, int usuario)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ExtratoFinanceiro(long cliente, DateTime de, DateTime ate, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select to_char(data, 'DD/MM/YY') as data, tipo, valor, situacao, pedido, observacao, forma from caixa_fluxo " +
					"where cliente = " + cliente.ToString() + " and data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and " +
					" to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') and situacao <> 'C' order by indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool Fechamento(int fec, DataSet tipos, DataSet entradas)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, " +
					"(select sum(fracao) from pedidos_itens left join cad_produtos on (pedidos_itens.produto = cad_produtos.codigo) " +
					"where pedido in (select pedido from caixa_fluxo where fechamento = " + fec.ToString() + ") and cad_produtos.tipo = produtos_tipos.codigo) as volume, " +
					"(select sum(preco) from pedidos_itens left join cad_produtos on (pedidos_itens.produto = cad_produtos.codigo) " +
					"where pedido in (select pedido from caixa_fluxo where fechamento = " + fec.ToString() + ") and cad_produtos.tipo = produtos_tipos.codigo) as valor, " +
					"soma " +
					"from produtos_tipos order by codigo", Conn);

				da.Fill(tipos);

				NpgsqlDataAdapter dap = new NpgsqlDataAdapter("select fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'A') as A, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'B') as B, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'C') as C, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'D') as D, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'M') as M, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'P') as P, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'V') as V, " +
					"fechamento_caixa_entrada_forma(" + fec.ToString() + ", " + Caixa.Numero.ToString() + ", 'X') as X "
					, Conn);

				dap.Fill(entradas);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public DataTable FechamentoCaixas(int fechamento, int usuario)
		{
			try
			{
				string consulta = "select cad_caixa.codigo, cad_caixa.descricao, " +
										"fechamento_entrada(" + fechamento.ToString() + ", cad_caixa.codigo) as entrada, " +
										"fechamento_pagamento(" + fechamento.ToString() + ", cad_caixa.codigo) as pagamento, " +
										"fechamento_saida(" + fechamento.ToString() + ", cad_caixa.codigo) as saida, " +
										"fechamento_transferencia(" + fechamento.ToString() + ", cad_caixa.codigo) as transferencia, " +
										"fechamento_vale(" + fechamento.ToString() + ", cad_caixa.codigo) as vale " +
										"from cad_caixa " +
										"where cad_caixa.situacao = 'A'";

				DataSet ds = new DataSet();

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(consulta, Conn);
				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				return null;
			}
		}

		public int FechamentoDeCaixa(Caixa caixa, Usuario usuario)
		{
			try
			{
				int fechamento;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_fecha_caixa(:caixa, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read() || (fechamento = int.Parse(dr[0].ToString())) == 0)
				{
					return 0;
				}

				LogarFechamentoDeCaixa(caixa, usuario, CaixaSaldo(caixa));

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public int FechamentoDeCaixaSaida(Caixa caixa, decimal saldo, Usuario usuario)
		{
			try
			{
				int fechamento;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_fecha_caixa_saida(:caixa, :saldo, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("saldo", saldo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read() || (fechamento = int.Parse(dr[0].ToString())) == 0)
				{
					return 0;
				}

				LogarFechamentoDeCaixa(caixa, usuario, saldo);

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public void BaixaPedidosEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos set situacao = 'P' where situacao <> 'P' and situacao <> 'C'");
			ExecCommand(com);
		}

		public int EfetuarFechamentoDiario(DateTime data, Usuario usuario)
		{
			try
			{
				int fechamento = 0;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_fecha_dia(:usuario, :data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("data", data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read() || (fechamento = Convert.ToInt32(dr[0])) <= 0)
				{
					return fechamento;
				}

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento = :fechamento and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and (cliente is null or cliente = 0)");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				decimal vendaDireta = getDecimal(com);

				com.Dispose();

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento = :fechamento and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and cliente in (select codigo from cad_clientes where tipo_cliente in (select codigo from clientes_tipos where cliente_interno = true))");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				decimal clienteInterno = getDecimal(com);

				com.Dispose();

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento = :fechamento and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and cliente in (select codigo from cad_clientes where tipo_cliente not in (select codigo from clientes_tipos where cliente_interno = true))");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				decimal delivery = getDecimal(com);

				com.Dispose();

				com = new NpgsqlCommand("update resumos set venda_direta = :venda_direta, cliente_interno = :cliente_interno, delivery = :delivery where indice = :fechamento", Conn);
				com.Parameters.Add(new NpgsqlParameter("venda_direta", vendaDireta));
				com.Parameters.Add(new NpgsqlParameter("cliente_interno", clienteInterno));
				com.Parameters.Add(new NpgsqlParameter("delivery", delivery));
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				com.ExecuteNonQuery();

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public int ConsultaFechamentoDiario(DateTime data)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select indice from resumos where data = :data and situacao = 'A'", Conn);

				com.Parameters.Add(new NpgsqlParameter("data", data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return 0;

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public DataTable FechamentoEntradas(int fechamento, int usuario)
		{
			try
			{
				string consulta = "select cad_caixa.codigo, cad_caixa.descricao, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'A') as debito, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'B') as boleto, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'C') as cartao, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'D') as dinheiro, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'M') as master, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'P') as crediario, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'V') as visa, " +
										"fechamento_entrada_forma(" + fechamento.ToString() + ", cad_caixa.codigo, 'X') as cheque " +
										"from cad_caixa " +
										"where cad_caixa.situacao = 'A'";

				DataSet ds = new DataSet();

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(consulta, Conn);
				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				return null;
			}
		}

		public void FechamentoPedidos(int fechamento, out int volume, out int itens, out decimal total, int usuario)
		{
			try
			{
				NpgsqlCommand com_vol = new NpgsqlCommand("select count(indice) from pedidos where fechamento = :fechamento and situacao <> 'C'");
				com_vol.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				volume = getInt(com_vol, usuario);

				NpgsqlCommand com_itens = new NpgsqlCommand("select sum(itens) from pedidos where fechamento = :fechamento and situacao <> 'C'");
				com_itens.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				itens = getInt(com_itens, usuario);

				NpgsqlCommand com_total = new NpgsqlCommand("select sum(valor) from pedidos where fechamento = :fechamento and situacao <> 'C'");
				com_total.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				total = getDecimal(com_total, usuario);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);

				volume = 0;
				itens = 0;
				total = 0;
			}
		}

		public void FluxoDeCaixa(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select caixa_fluxo.indice, " +
																	"caixa_fluxo.data, " +
																	"caixa_fluxo.hora, " +
																	"caixa_fluxo.tipo, " +
																	"caixa_fluxo.caixa, " +
																	"cad_caixa.descricao, " +
																	"caixa_fluxo.valor, " +
																	"caixa_fluxo.situacao, " +
																	"caixa_fluxo.fechamento, " +
																	"caixa_fluxo.pedido, " +
																	"caixa_fluxo.despesa, " +
																	"caixa_fluxo.recurso, " +
																	"cad_recursos.nome as nome_recurso, " +
																	"caixa_fluxo.cliente, " +
																	"cad_clientes.nome as nome_cliente, " +
																	"caixa_fluxo.observacao, " +
																	"caixa_fluxo.usuario, " +
																	"caixa_fluxo.forma " +
																	"from caixa_fluxo " +
																	"left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) " +
																	"left join cad_recursos on (cad_recursos.codigo = caixa_fluxo.recurso) " +
																	"left join cad_clientes on (cad_clientes.codigo = caixa_fluxo.cliente) " +
																	"order by caixa_fluxo.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public DataSet FluxoDeCaixa()
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select caixa_fluxo.indice, " +
																	"caixa_fluxo.data, " +
																	"caixa_fluxo.hora, " +
																	"caixa_fluxo.tipo, " +
																	"caixa_fluxo.caixa, " +
																	"cad_caixa.descricao, " +
																	"caixa_fluxo.valor, " +
																	"caixa_fluxo.situacao, " +
																	"caixa_fluxo.fechamento, " +
																	"caixa_fluxo.pedido, " +
																	"caixa_fluxo.despesa, " +
																	"caixa_fluxo.recurso, " +
																	"cad_recursos.nome as nome_recurso, " +
																	"caixa_fluxo.cliente, " +
																	"cad_clientes.nome as nome_cliente, " +
																	"caixa_fluxo.observacao, " +
																	"caixa_fluxo.usuario, " +
																	"caixa_fluxo.forma " +
																	"from caixa_fluxo " +
																	"left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) " +
																	"left join cad_recursos on (cad_recursos.codigo = caixa_fluxo.recurso) " +
																	"left join cad_clientes on (cad_clientes.codigo = caixa_fluxo.cliente) " +
																	"order by caixa_fluxo.indice", Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public Task<DataSet> FluxoDeCaixaAsync()
		{
			return Task.Factory.StartNew(() => { return FluxoDeCaixa(); });
		}

		public string FornecedorNome(long codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_fornecedores where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool getBool(string command)
		{
			return getBool(new NpgsqlCommand(command));
		}

		public bool getBool(NpgsqlCommand com)
		{
			return getBool(com, _usuario);
		}

		public bool getBool(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		public decimal getDecimal(string command)
		{
			return getDecimal(new NpgsqlCommand(command));
		}

		public decimal getDecimal(NpgsqlCommand com)
		{
			return getDecimal(com, _usuario);
		}

		public decimal getDecimal(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					decimal d;
					decimal.TryParse(dr[0].ToString(), out d);

					return d;
				}
				else
				{
					return 0;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
			finally
			{
				conn.Close();
			}
		}

		public double getDouble(NpgsqlCommand com)
		{
			return getDouble(com, _usuario);
		}

		public double getDouble(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				double d = 0;

				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					if (!double.TryParse(dr[0].ToString(), out d))
						return 0;
				}

				return d;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
			finally
			{
				conn.Close();
			}
		}

		public int getInt(string command)
		{
			return getInt(new NpgsqlCommand(command));
		}

		public int getInt(NpgsqlCommand com)
		{
			return getInt(com, _usuario);
		}

		public int getInt(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				int i;

				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (!dr.HasRows)
					return 0;

				if (!int.TryParse(dr[0].ToString(), out i))
					return 0;

				return i;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		public long getLong(string command)
		{
			return getLong(new NpgsqlCommand(command));
		}

		public long getLong(NpgsqlCommand com)
		{
			return getLong(com, _usuario);
		}

		public long getLong(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				long l = 0;

				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					if (!long.TryParse(dr[0].ToString(), out l))
						return 0;
				}

				return l;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		public string getString(string command)
		{
			return getString(new NpgsqlCommand(command));
		}

		public string getString(NpgsqlCommand com)
		{
			return getString(com, _usuario);
		}

		public string getString(NpgsqlCommand com, int usuario)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (!dr.HasRows)
					return string.Empty;

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		public DateTime getDateTime(NpgsqlCommand com)
		{
			NpgsqlConnection conn = Conn;

			try
			{
				DateTime dt = DateTime.MinValue;

				com.Connection = conn;

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					if (!DateTime.TryParse(dr[0].ToString(), out dt))
						return DateTime.MinValue;
				}

				return dt;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return DateTime.MinValue;
			}
			finally
			{
				if (conn != null && conn.State == ConnectionState.Open)
				{
					conn.Close();
					conn.Dispose();
				}
			}
		}

		public bool GrupoClienteExiste(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from clientes_grupos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if (getString(com) == string.Empty)
					return false;

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public string GrupoClienteNome(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from clientes_grupos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return "";
			}
		}

		public bool GrupoRecursosExiste(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from recursos_grupos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public void GruposClientes(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, situacao, taxa_entrega, taxa_servico, cidade, estado from clientes_grupos order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);
			}
		}

		public void GruposProdutos(DataSet ds)
		{
			try
			{
				string sql = "select codigo, descricao, situacao from produtos_grupos order by codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void GruposRecursos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from recursos_grupos order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);
			}
		}

		public void GruposTributarios(DataSet ds)
		{
			try
			{
				string sql = "select codigo, nome, situacao from grupos_tributarios order by codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public string GrupoTributarioDescricao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from grupos_tributarios where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool IncluirCaixa(Caixa caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_caixa(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", caixa.Descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirFornecedor(Fornecedor fornecedor)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into cad_fornecedores (codigo, nome, cnpj, tel1, tel2, endereco, bairro, cidade, estado, pais, cep, contato, tipo, obs, email) values "
					+ "(:codigo, :nome, :cnpj, :tel1, :tel2, :endereco, :bairro, :cidade, :estado, :pais, :cep, :contato, :tipo, :obs, :email);");

				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("codigo", fornecedor.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", fornecedor.Nome));
				com.Parameters.Add(new NpgsqlParameter("cnpj", fornecedor.Cnpj));
				com.Parameters.Add(new NpgsqlParameter("tel1", fornecedor.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", fornecedor.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("endereco", fornecedor.Endereco));
				com.Parameters.Add(new NpgsqlParameter("bairro", fornecedor.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cidade", fornecedor.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", fornecedor.Estado));
				com.Parameters.Add(new NpgsqlParameter("pais", fornecedor.Pais));
				com.Parameters.Add(new NpgsqlParameter("cep", fornecedor.Cep));
				com.Parameters.Add(new NpgsqlParameter("contato", fornecedor.Contato));
				com.Parameters.Add(new NpgsqlParameter("tipo", fornecedor.Tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("obs", fornecedor.Observacao));
				com.Parameters.Add(new NpgsqlParameter("email", fornecedor.Email));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirLocal(Local local)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_local(:codigo, :nome, :descricao, :tipo, :responsavel)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", local.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", local.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", local.Descricao));
				com.Parameters.Add(new NpgsqlParameter("tipo", local.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("responsavel", local.Reponsavel));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirMedida(Medida medida)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into medidas (codigo, descricao, abreviatura) values (:codigo, :descricao, :abreviatura)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", medida.Codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", medida.Descricao));
				com.Parameters.Add(new NpgsqlParameter("abreviatura", medida.Abreviatura));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirNFe(Pedido pedido, NFe nfe, string dateFormat)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into notas_fiscais (numero, " +
																			"serie, " +
																			"emissao, " +
																			"cliente, " +
																			"pedido, " +
																			"valor_total, " +
																			"frete, " +
																			"arquivo, " +
																			"status, " +
																			"serializado) values (" +
																			":numero, " +
																			":serie, " +
																			":emissao, " +
																			":cliente, " +
																			":pedido, " +
																			":valor_total, " +
																			":frete, " +
																			":arquivo, " +
																			":status, " +
																			":serializado)");

			com.Parameters.Add(new NpgsqlParameter("numero", Convert.ToInt32(nfe.infNFe.ide.nNF)));
			com.Parameters.Add(new NpgsqlParameter("serie", nfe.infNFe.ide.serie));
			com.Parameters.Add(new NpgsqlParameter("emissao", DateTime.ParseExact(nfe.infNFe.ide.dEmi, dateFormat, CultureInfo.InvariantCulture)));
			com.Parameters.Add(new NpgsqlParameter("cliente", pedido.Cliente));
			com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));
			com.Parameters.Add(new NpgsqlParameter("valor_total", Convert.ToDecimal(nfe.infNFe.total.ICMSTot.vNF)));
			com.Parameters.Add(new NpgsqlParameter("frete", Convert.ToDecimal(nfe.infNFe.total.ICMSTot.vFrete)));
			com.Parameters.Add(new NpgsqlParameter("arquivo", Preferencias.PastaNFe + "\\" + pedido.NFe + "-nfe.xml"));
			com.Parameters.Add(new NpgsqlParameter("status", "T"));
			com.Parameters.Add(new NpgsqlParameter("serializado", pedido.NFeSerializado));

			return ExecCommand(com);
		}

		public bool IncluirProduto(Produto produto)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_produto(:codigo, :nome, :tipo, :grupo, :descricao, :grupo_tributario, :medida, :producao, " +
					":fornecedor, :foto, :ncm, :cfop, :ean, :ean_trib, :med_trib, :qtd_trib)");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", produto.Nome));
				com.Parameters.Add(new NpgsqlParameter("tipo", produto.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("grupo", produto.Grupo));
				com.Parameters.Add(new NpgsqlParameter("descricao", produto.Descricao));
				com.Parameters.Add(new NpgsqlParameter("grupo_tributario", produto.GrupoTributario));
				com.Parameters.Add(new NpgsqlParameter("medida", produto.Medida.Codigo));
				com.Parameters.Add(new NpgsqlParameter("producao", produto.Producao));

				if (produto.Fornecedor == null)
				{
					long fornecedor = 0;

					com.Parameters.Add(new NpgsqlParameter("fornecedor", fornecedor));
				}
				else
				{
					com.Parameters.Add(new NpgsqlParameter("fornecedor", produto.Fornecedor.Codigo));
				}

				com.Parameters.Add(new NpgsqlParameter("foto", produto.Foto));
				com.Parameters.Add(new NpgsqlParameter("ncm", produto.NCM));
				com.Parameters.Add(new NpgsqlParameter("cfop", produto.CFOP));
				com.Parameters.Add(new NpgsqlParameter("ean", produto.EAN));
				com.Parameters.Add(new NpgsqlParameter("ean_trib", produto.EANTrib));
				com.Parameters.Add(new NpgsqlParameter("med_trib", produto.MedidaTributavel.Codigo));
				com.Parameters.Add(new NpgsqlParameter("qtd_trib", produto.QuantidadeTributavel));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirTabela(int codigo, string nome, string descricao, int tabela_pai)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_tabela(:codigo, :nome, :descricao, :pai)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));
				com.Parameters.Add(new NpgsqlParameter("pai", tabela_pai));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirUsuario(Usuario usuario)
		{
			return IncluirUsuario(usuario.Codigo, usuario.Nome, usuario.Display, usuario.Senha, usuario.NivelUsuario.Nivel, usuario.Recurso.Codigo);
		}

		public bool IncluirUsuario(int codigo, string nome, string display, string senha, string nivel, int recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into cad_usuarios(codigo, nome, display, senha, nivel, recurso) values (:codigo, :nome, :display, :senha, :nivel, :recurso)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", nome));
				com.Parameters.Add(new NpgsqlParameter("display", display));
				com.Parameters.Add(new NpgsqlParameter("senha", senha));
				com.Parameters.Add(new NpgsqlParameter("nivel", nivel));
				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void InsertOrUpdate(string table, string key, string value)
		{
			NpgsqlCommand com = new NpgsqlCommand(string.Format("select indice from {0} where chave = '{1}'", table, key), Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read() && dr[0].ToString() != "")
			{
				com = new NpgsqlCommand(string.Format("update {0} set valor = '{1}' where chave = '{2}'", table, value, key), Conn);
				com.ExecuteNonQuery();
			}
			else
			{
				com = new NpgsqlCommand(string.Format("insert into {0} (chave, valor) values ('{1}', '{2}')", table, key, value), Conn);
				com.ExecuteNonQuery();
			}
		}

		public List<ItemPedido> Itens(int pedido, int item)
		{
			return null;
		}

		public bool LancamentosPeriodoDetalhado(DateTime inicial, DateTime final, string[] lancamentos, string[] formas, DataSet ds, int usuario)
		{
			try
			{
				string comando = "select caixa_fluxo.indice as indice, " +
										"caixa_fluxo.data as data, " +
										"caixa_fluxo.hora as hora, " +
										"caixa_fluxo.tipo as tipo, " +
										"caixa_fluxo.cliente as cliente, " +
										"cad_clientes.nome as nome, " +
										"caixa_fluxo.forma as forma, " +
										"caixa_fluxo.valor as valor, " +
										"caixa_fluxo.situacao as situacao, " +
										"caixa_fluxo.pedido as pedido " +
										"from caixa_fluxo left join cad_clientes on cad_clientes.codigo = caixa_fluxo.cliente " +
										"where caixa_fluxo.data between todate('" + inicial.ToString("ddMMyy") + "') and todate('" + final.ToString("ddMMyy") + "') " +
										"and caixa_fluxo.tipo in (";

				for (int i = 0; i < lancamentos.Length; i++)
				{
					if (i > 0)
						comando += ",";

					comando += "'" + lancamentos[i] + "'";
				}

				comando += ") and caixa_fluxo.forma in (";

				for (int i = 0; i < formas.Length; i++)
				{
					if (i > 0)
						comando += ",";

					comando += "'" + formas[i] + "'";
				}

				comando += ") order by caixa_fluxo.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario);
				MessageBox.Show("Erro ao consultar dados", "Consultas", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public Task<DataSet> LancamentosPeriodoDetalhadoAsync(DateTime inicial, DateTime final, string[] lancamentos, string[] formas, int usuario)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				LancamentosPeriodoDetalhado(inicial, final, lancamentos, formas, ds, usuario);
				return ds;
			});
		}

		public int LancarEntrada(FluxoDeCaixa entrada, int caixa, int usuario)
		{
			try
			{
				string sql = "select dsoft_lanca_entrada(:usuario, " +
														":caixa, ";

				if (entrada.Cliente != null)
				{
					sql += ":cliente, ";
				}

				sql += ":forma, " +
														":valor, " +
														":observacao, " +
														":data)";

				NpgsqlCommand com = new NpgsqlCommand(sql, Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				if (entrada.Cliente != 0)
				{
					com.Parameters.Add(new NpgsqlParameter("cliente", entrada.Cliente));
				}

				com.Parameters.Add(new NpgsqlParameter("forma", entrada.Forma.ToString()));
				com.Parameters.Add(new NpgsqlParameter("valor", entrada.Valor));
				com.Parameters.Add(new NpgsqlParameter("observacao", entrada.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", entrada.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				return Convert.ToInt32(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool LancarPagamento(FluxoDeCaixa pagamento, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_lanca_pagamento(:usuario, " +
																				":caixa, " +
																				":valor, " +
																				":recurso, " +
																				":observacao, " +
																				":data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", pagamento.Valor));
				com.Parameters.Add(new NpgsqlParameter("recurso", pagamento.Recurso));
				com.Parameters.Add(new NpgsqlParameter("observacao", pagamento.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", pagamento.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool LancarSaida(FluxoDeCaixa saida, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_lanca_saida(:usuario, " +
																				":caixa, " +
																				":valor, " +
																				":observacao, " +
																				":data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", saida.Valor));
				com.Parameters.Add(new NpgsqlParameter("observacao", saida.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", saida.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool LancarSaidas(int caixa, double dinheiro, double cheque, double cartao, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand();

				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if (dinheiro > 0)
				{
					com.CommandText = "insert into caixa_fluxo (tipo, caixa, valor, usuario, observacao, forma) values " +
						"('S', :caixa, :valor, :usuario, 'LANÇAMENTO EFETUADO NO FECHAMENTO DE CAIXA', 'D')";

					com.Parameters.Add(new NpgsqlParameter("valor", dinheiro));

					ExecCommand(com, usuario);

					com.Parameters.RemoveAt("valor");
				}

				if (cheque > 0)
				{
					com.CommandText = "insert into caixa_fluxo (tipo, caixa, valor, usuario, observacao, forma) values " +
						"('S', :caixa, :valor, :usuario, 'LANÇAMENTO EFETUADO NO FECHAMENTO DE CAIXA', 'X')";

					com.Parameters.Add(new NpgsqlParameter("valor", cheque));

					ExecCommand(com, usuario);

					com.Parameters.RemoveAt("valor");
				}

				if (cartao > 0)
				{
					com.CommandText = "insert into caixa_fluxo (tipo, caixa, valor, usuario, observacao, forma) values " +
						"('S', :caixa, :valor, :usuario, 'LANÇAMENTO EFETUADO NO FECHAMENTO DE CAIXA', 'C')";

					com.Parameters.Add(new NpgsqlParameter("valor", cartao));

					ExecCommand(com, usuario);
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool LancarVale(FluxoDeCaixa vale, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_lanca_vale(:usuario, " +
																				":caixa, " +
																				":valor, " +
																				":recurso, " +
																				":observacao, " +
																				":data)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", vale.Valor));
				com.Parameters.Add(new NpgsqlParameter("recurso", vale.Recurso));
				com.Parameters.Add(new NpgsqlParameter("observacao", vale.Observacao));
				com.Parameters.Add(new NpgsqlParameter("data", vale.Data));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool LimparManifesto(int manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_limpa_manifesto(:indice);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", manifesto));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ListaClientesTipos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, situacao, cliente_interno from clientes_tipos order by codigo", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ListaProdutos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_produtos.codigo, cad_produtos.nome, cad_produtos.descricao, " +
					"cad_produtos.tipo, produtos_tipos.descricao, cad_produtos.grupo, produtos_grupos.descricao, cad_produtos.situacao " +
					"from cad_produtos left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo) " +
					"left join produtos_grupos on (produtos_grupos.codigo = cad_produtos.grupo) " +
					"order by cad_produtos.codigo", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ListaRecursos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_recursos.codigo, cad_recursos.nome, " +
					"cad_recursos.tipo, recursos_tipos.descricao, cad_recursos.situacao from cad_recursos " +
					"left join recursos_tipos on (recursos_tipos.codigo = cad_recursos.tipo) " +
					"order by cad_recursos.codigo", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ListaRecursosTipos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, entrega, producao from recursos_tipos order by codigo", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ListaUsuarios(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_usuarios.codigo, cad_usuarios.nome, cad_usuarios.nivel, " +
					"cad_usuarios.recurso, cad_recursos.nome from cad_usuarios left join cad_recursos on (cad_recursos.codigo = cad_usuarios.recurso) " +
					"order by cad_usuarios.nome", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public List<Usuario> CarregarUsuarios()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_usuarios where situacao = 'A' order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Usuario> usuarios = new List<Usuario>();

				while (dr.Read())
				{
					Usuario usuario = CarregarUsuario(Convert.ToInt32(dr[0]));
					usuarios.Add(usuario);
				}

				return usuarios;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				return null;
			}
		}

		public void LogarEntrada(int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_loga_entrada(:usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				com.ExecuteNonQuery();

				_usuario = usuario;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void LogarEntrada(int usuario, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_loga_entrada(:usuario, :caixa)");

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void LogarErro(int usuario, int caixa, string message)
		{
		}

		public void LogarSaida(int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_loga_saida(:usuario)");

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);

				if (e is System.NullReferenceException)
				{
				}
				else
				{
					MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public void Materiais(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, medida from cad_materiais where situacao <> 'C' order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void MateriaisCadastrados(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_materiais.codigo, " +
																	"cad_materiais.nome, " +
																	"cad_fornecedores.nome as fornecedor, " +
																	"materiais_tipos.nome as tipo, " +
																	"medidas.descricao as medida, " +
																	"cad_materiais.situacao, " +
																	"cad_materiais.cadastro, " +
																	"cad_usuarios.nome as usuario, " +
																	"cad_materiais.fornecedor as cod_fornecedor, " +
																	"cad_materiais.tipo as cod_tipo, " +
																	"cad_materiais.medida as cod_medida " +
																	"from cad_materiais " +
																	"left join cad_fornecedores on (cad_materiais.fornecedor = cad_fornecedores.codigo) " +
																	"left join materiais_tipos on (cad_materiais.tipo = materiais_tipos.codigo) " +
																	"left join medidas on (cad_materiais.medida = medidas.codigo) " +
																	"left join cad_usuarios on (cad_materiais.usuario = cad_usuarios.codigo) " +
																	"order by cad_materiais.codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void MateriaisVinculados(long produto, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select produtos_materiais.material, " +
																	"cad_materiais.nome as nome, " +
																	"produtos_materiais.quantidade, " +
																	"medidas.abreviatura as medida " +
																	"from produtos_materiais " +
																	"left join cad_materiais on (cad_materiais.codigo = produtos_materiais.material) " +
																	"left join medidas on (cad_materiais.medida = medidas.codigo) " +
																	"where produtos_materiais.produto = " + produto.ToString(), Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public string MedidaAbrev(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select abreviatura from medidas where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public string MedidaDescricao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from medidas where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public string MedidaMaterial(int material)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select medidas.abreviatura from medidas left join cad_materiais on (cad_materiais.medida = medidas.codigo) " +
														"where cad_materiais.codigo = :material", Conn);

				com.Parameters.Add(new NpgsqlParameter("material", material));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public void Medidas(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, abreviatura from medidas order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool MoverEstoque(int produto, double quantidade, int origem, int destino)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_move_estoque(:produto, :quantidade, :origem, :destino)", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				com.Parameters.Add(new NpgsqlParameter("quantidade", quantidade));
				com.Parameters.Add(new NpgsqlParameter("origem", origem));
				com.Parameters.Add(new NpgsqlParameter("destino", destino));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int NFeAutorizada(string nfe)
		{
			NpgsqlCommand com = new NpgsqlCommand("update notas_fiscais set situacao = 'U' where nfe = :nfe returning indice;");
			com.Parameters.Add(new NpgsqlParameter("nfe", nfe));

			return getInt(com);
		}

		public string NovaChaveCTe(int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_chave_cte();", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return "";
			}
		}

		public string NovaChaveNFe(int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_chave_nfe()", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool NovaCompra(Compra compra, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_compra(:usuario, " +
																				":fornecedor, " +
																				":observacao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("fornecedor", compra.Fornecedor));
				com.Parameters.Add(new NpgsqlParameter("observacao", compra.Observacao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				if ((compra.Codigo = int.Parse(dr[0].ToString())) == 0)
				{
					return false;
				}

				com.CommandText = "select dsoft_novo_compra_item(:compra, :numero, :produto, :unitario, :quantidade, :total)";

				for (int i = 0; i < compra.Itens; i++)
				{
					com.Parameters.Clear();

					com.Parameters.Add(new NpgsqlParameter("compra", compra.Codigo));
					com.Parameters.Add(new NpgsqlParameter("numero", compra.Item[i].Numero));
					com.Parameters.Add(new NpgsqlParameter("produto", compra.Item[i].Produto.Codigo));
					com.Parameters.Add(new NpgsqlParameter("unitario", compra.Item[i].Unitario));
					com.Parameters.Add(new NpgsqlParameter("quantidade", compra.Item[i].Quantidade));
					com.Parameters.Add(new NpgsqlParameter("total", compra.Item[i].Total));

					dr = com.ExecuteReader();

					if (!dr.Read() || !bool.Parse(dr[0].ToString()))
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int NovaDespesa(Despesa despesa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_despesa(:usuario, " +
																				":tipo, " +
																				":fornecedor, " +
																				":valor, " +
																				":vencimento, " +
																				":documento, " +
																				":observacao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("tipo", despesa.Tipo));
				com.Parameters.Add(new NpgsqlParameter("fornecedor", despesa.Fornecedor));
				com.Parameters.Add(new NpgsqlParameter("valor", despesa.Valor));
				com.Parameters.Add(new NpgsqlParameter("vencimento", despesa.Vencimento));
				com.Parameters.Add(new NpgsqlParameter("documento", despesa.Documento));
				com.Parameters.Add(new NpgsqlParameter("observacao", despesa.Observacao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public bool NovaOcorrencia(Ocorrencia ocorrencia, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_ocorrencia(:usuario, :tipo, :ocorrencia, :cliente)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("tipo", ocorrencia.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("ocorrencia", ocorrencia.Descricao));
				com.Parameters.Add(new NpgsqlParameter("cliente", ocorrencia.Cliente));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int NovaOrdemColeta(long emit, DateTime data, string numColeta, long rem, long dest, DateTime prev, bool pago, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into ordem_servico (emitente, abertura_data, num_coleta, remetente, destinatario, prev_coleta, pago, abertura_usuario, abertura_hora) " +
													"values (:emit, :data, :coleta, :rem, :dest, :prev, :pago, :usuario, now()) returning indice;", Conn);

				com.Parameters.Add(new NpgsqlParameter("emit", emit));
				com.Parameters.Add(new NpgsqlParameter("data", data));
				com.Parameters.Add(new NpgsqlParameter("coleta", numColeta));
				com.Parameters.Add(new NpgsqlParameter("rem", rem));
				com.Parameters.Add(new NpgsqlParameter("dest", dest));
				com.Parameters.Add(new NpgsqlParameter("prev", prev));
				com.Parameters.Add(new NpgsqlParameter("pago", pago));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool NovaOrdemTransporte(OrdemDeColeta ordem, int usuario)
		{
			try
			{
				int indice;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_nova_ordem_transporte(:emitente, " +
																							":data, " +
																							":remetente, " +
																							":destinatario, " +
																							":pago, " +
																							":usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("emitente", ordem.Emitente.RazaoSocial));
				com.Parameters.Add(new NpgsqlParameter("data", ordem.Data));
				com.Parameters.Add(new NpgsqlParameter("remetente", ordem.Remetente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("destinatario", ordem.Destinatario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("pago", ordem.Pago));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				indice = int.Parse(dr[0].ToString());

				if (ordem.TemDados())
				{
					NpgsqlCommand com2 = new NpgsqlCommand("select dsoft_completar_ordem_transporte(:indice, " +
																							":cfop, " +
																							":natop, " +
																							":rntrc, " +
																							":cst, " +
																							":bc, " +
																							":aliq, " +
																							":vICMS, " +
																							":natureza, " +
																							":quantidade, " +
																							":especie, " +
																							":peso, " +
																							":m3l, " +
																							":nota_fiscal, " +
																							":serie, " +
																							":valor_mercadoria, " +
																							":valor_frete);", Conn);

					com2.Parameters.Add(new NpgsqlParameter("indice", indice));
					com2.Parameters.Add(new NpgsqlParameter("cfop", ordem.CFOP));
					com2.Parameters.Add(new NpgsqlParameter("natop", ordem.NaturezaDaOperacao));
					com2.Parameters.Add(new NpgsqlParameter("rntrc", ordem.RNTRC));
					com2.Parameters.Add(new NpgsqlParameter("cst", ordem.CST));
					com2.Parameters.Add(new NpgsqlParameter("bc", ordem.ValorBCICMS));
					com2.Parameters.Add(new NpgsqlParameter("aliq", ordem.AliquotaICMS));
					com2.Parameters.Add(new NpgsqlParameter("vICMS", ordem.ValorICMS));
					com2.Parameters.Add(new NpgsqlParameter("natureza", ordem.ProdudoPredominante));
					com2.Parameters.Add(new NpgsqlParameter("quantidade", ordem.Quantidade));
					//com2.Parameters.Add(new NpgsqlParameter("especie", ordem.Especie));
					//com2.Parameters.Add(new NpgsqlParameter("peso", ordem.Peso));
					//com2.Parameters.Add(new NpgsqlParameter("m3l", ordem.M3L));
					//com2.Parameters.Add(new NpgsqlParameter("nota_fiscal", ordem.NotaFiscal));
					//com2.Parameters.Add(new NpgsqlParameter("serie", ordem.Serie));
					com2.Parameters.Add(new NpgsqlParameter("valor_mercadoria", ordem.ValorMercadoria));
					com2.Parameters.Add(new NpgsqlParameter("valor_frete", ordem.ValorFrete));

					com2.ExecuteNonQuery();
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoCliente(Cliente cliente, ILicenca licenca)
		{
			try
			{
				//Trava de segurança
				if (licenca.Demo || licenca.Expirou)
				{
					if (QuantidadeDeClientesAtivos() > 50)
					{
						MessageBox.Show("Sistema alcançou o limite máximo de clientes para versão não licenciada. Entre em contato com o suporte para continuar trabalhando com o sistema.",
							"DSoft Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

						return false;
					}
				}

				NpgsqlCommand com = new NpgsqlCommand("insert into cad_clientes(codigo, " +
														"nome, " +
														"nascimento, " +
														"tipo, " +
														"documento, " +
														"inscricao_estadual, " +
														"inscricao_suframa, " +
														"rg, " +
														"isento_icms, " +
														"tel1, " +
														"tel2, " +
														"celular, " +
														"endereco, " +
														"numero, " +
														"complemento, " +
														"bairro, " +
														"cidade, " +
														"estado, " +
														"pais, " +
														"cep, " +
														"referencia, " +
														"observacao, " +
														"usuario, " +
														"grupo, " +
														"pai, " +
														"mae, " +
														"conjuge, " +
														"profissao, " +
														"senha, " +
														"contato, " +
														"email, " +
														"site, " +
														"tabela_precos, " +
														"taxa_de_entrega, " +
														"tipo_cliente, " +
														"funcionario, " +
														"aux_tel, " +
														"vencimento_mensalidade, " +
														"valor_mensalidade) values " +
														"(:codigo, " +
														":nome, " +
														":nascimento, " +
														":tipo, " +
														":documento, " +
														":insc_estadual, " +
														":insc_suframa, " +
														":rg, " +
														":isento_icms, " +
														":tel1, " +
														":tel2, " +
														":celular, " +
														":endereco, " +
														":numero, " +
														":complemento, " +
														":bairro, " +
														":cidade, " +
														":estado, " +
														":pais, " +
														":cep, " +
														":referencia, " +
														":observacao, " +
														":cod_usuario, " +
														":grupo, " +
														":pai, " +
														":mae, " +
														":conjuge, " +
														":profissao, " +
														":senha, " +
														":contato, " +
														":email, " +
														":site, " +
														":tabela, " +
														":taxa, " +
														":tipo_cliente, " +
														":funcionario, " +
														":auxiliar, " +
														":vencimento_mensalidade, " +
														":valor_mensalidade)");

				com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", cliente.Nome));
				com.Parameters.Add(new NpgsqlParameter("nascimento", cliente.Nascimento));
				com.Parameters.Add(new NpgsqlParameter("tipo", cliente.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("documento", cliente.Documento));
				com.Parameters.Add(new NpgsqlParameter("insc_estadual", cliente.InscricaoEstadual));
				com.Parameters.Add(new NpgsqlParameter("insc_suframa", cliente.InscricaoSuframa));
				com.Parameters.Add(new NpgsqlParameter("rg", cliente.Rg));
				com.Parameters.Add(new NpgsqlParameter("isento_icms", cliente.IsentoICMS));
				com.Parameters.Add(new NpgsqlParameter("tel1", cliente.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", cliente.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("celular", cliente.Celular));
				com.Parameters.Add(new NpgsqlParameter("endereco", cliente.Endereco));
				com.Parameters.Add(new NpgsqlParameter("numero", cliente.Numero));
				com.Parameters.Add(new NpgsqlParameter("complemento", cliente.Complemento));
				com.Parameters.Add(new NpgsqlParameter("bairro", cliente.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cidade", cliente.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", cliente.Estado));
				com.Parameters.Add(new NpgsqlParameter("pais", cliente.Pais));
				com.Parameters.Add(new NpgsqlParameter("cep", cliente.Cep));
				com.Parameters.Add(new NpgsqlParameter("referencia", cliente.Referencia));
				com.Parameters.Add(new NpgsqlParameter("observacao", cliente.Observacao));
				com.Parameters.Add(new NpgsqlParameter("cod_usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("grupo", cliente.Grupo));
				com.Parameters.Add(new NpgsqlParameter("pai", cliente.Pai));
				com.Parameters.Add(new NpgsqlParameter("mae", cliente.Mae));
				com.Parameters.Add(new NpgsqlParameter("conjuge", cliente.Conjuge));
				com.Parameters.Add(new NpgsqlParameter("profissao", cliente.Profissao));
				com.Parameters.Add(new NpgsqlParameter("senha", ""));
				com.Parameters.Add(new NpgsqlParameter("contato", cliente.Contato));
				com.Parameters.Add(new NpgsqlParameter("email", cliente.Email));
				com.Parameters.Add(new NpgsqlParameter("site", cliente.Site));
				com.Parameters.Add(new NpgsqlParameter("tabela", cliente.Tabela));
				com.Parameters.Add(new NpgsqlParameter("taxa", cliente.TaxaDeEntrega));
				com.Parameters.Add(new NpgsqlParameter("tipo_cliente", cliente.ClienteTipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("auxiliar", cliente.Auxiliar));
				com.Parameters.Add(new NpgsqlParameter("vencimento_mensalidade", cliente.VencimentoMensalidade));
				com.Parameters.Add(new NpgsqlParameter("valor_mensalidade", cliente.ValorMensalidade));

				if (cliente.Funcionario == null)
				{
					com.Parameters.Add(new NpgsqlParameter("funcionario", null));
				}
				else
				{
					com.Parameters.Add(new NpgsqlParameter("funcionario", cliente.Funcionario.Codigo));
				}

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoDespesaTipo(DespesaTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_despesa_tipo(:codigo, :nome, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", tipo.Descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoEmitente(Emitente emitente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_emitente(:razao_social, " +
																				":nome_fantasia, " +
																				":cnpj, " +
																				":insc_estadual, " +
																				":cnae_fiscal, " +
																				":insc_municipal, " +
																				":logradouro, " +
																				":numero, " +
																				":complemento, " +
																				":bairro, " +
																				":cep, " +
																				":pais, " +
																				":uf, " +
																				":municipio, " +
																				":telefone, " +
																				":rntrc);");

				com.Parameters.Add(new NpgsqlParameter("razao_social", emitente.RazaoSocial));
				com.Parameters.Add(new NpgsqlParameter("nome_fantasia", emitente.NomeFantasia));
				com.Parameters.Add(new NpgsqlParameter("cnpj", emitente.Cnpj));
				com.Parameters.Add(new NpgsqlParameter("insc_estadual", emitente.InscricaoEstadual));
				com.Parameters.Add(new NpgsqlParameter("cnae_fiscal", emitente.CNAEFiscal));
				com.Parameters.Add(new NpgsqlParameter("insc_municipal", emitente.InscricaoMunicipal));
				com.Parameters.Add(new NpgsqlParameter("logradouro", emitente.Logradouro));
				com.Parameters.Add(new NpgsqlParameter("numero", emitente.Numero));
				com.Parameters.Add(new NpgsqlParameter("complemento", emitente.Complemento));
				com.Parameters.Add(new NpgsqlParameter("bairro", emitente.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cep", emitente.Cep));
				com.Parameters.Add(new NpgsqlParameter("pais", emitente.Pais));
				com.Parameters.Add(new NpgsqlParameter("uf", emitente.Uf));
				com.Parameters.Add(new NpgsqlParameter("municipio", emitente.Municipio));
				com.Parameters.Add(new NpgsqlParameter("telefone", emitente.Telefone));
				com.Parameters.Add(new NpgsqlParameter("rntrc", emitente.RNTRC));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoGrupoClientes(ClienteGrupo grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into clientes_grupos (codigo, nome, taxa_entrega, taxa_servico, cidade, estado) values (:codigo, :nome, :taxa, :servico, :cidade, :estado);", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", grupo.Nome));
				com.Parameters.Add(new NpgsqlParameter("taxa", grupo.Taxa));
				com.Parameters.Add(new NpgsqlParameter("servico", grupo.TaxaDeServico));
				com.Parameters.Add(new NpgsqlParameter("cidade", grupo.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", grupo.Estado));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool NovoGrupoRecursos(int codigo, string descricao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_recurso_grupo(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoGrupoTributario(GrupoTributario grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_grupo_tributario(:codigo, :nome, :icms, :ipi, :pis, :cofins, :csll, :irrf, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", grupo.Nome));
				com.Parameters.Add(new NpgsqlParameter("icms", grupo.ICMS));
				com.Parameters.Add(new NpgsqlParameter("ipi", grupo.IPI));
				com.Parameters.Add(new NpgsqlParameter("pis", grupo.PIS));
				com.Parameters.Add(new NpgsqlParameter("cofins", grupo.COFINS));
				com.Parameters.Add(new NpgsqlParameter("csll", grupo.CSLL));
				com.Parameters.Add(new NpgsqlParameter("irrf", grupo.IRRF));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (bool.Parse(dr[0].ToString()))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoLoteNotas(int inicial, int final, char serie, char tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_lote_notas(:inicial, :final, :serie, :tipo, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("inicial", inicial));
				com.Parameters.Add(new NpgsqlParameter("final", final));
				com.Parameters.Add(new NpgsqlParameter("serie", serie.ToString()));
				com.Parameters.Add(new NpgsqlParameter("tipo", tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoManifesto(Manifesto manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into manifestos (emitente, montagem_data, montagem_hora, motorista, veiculo, carreta, usuario, rntrc, ciot, uf_entrega, mun_entrega) " +
					"values (:emitente, :data, now(), :motorista, :veiculo, :carreta, :usuario, :rntrc, :ciot, :uf_entrega, :mun_entrega) returning indice;", Conn);

				com.Parameters.Add(new NpgsqlParameter("emitente", manifesto.Emitente.Cnpj));
				com.Parameters.Add(new NpgsqlParameter("data", manifesto.Data));
				com.Parameters.Add(new NpgsqlParameter("motorista", manifesto.Motorista.Codigo));
				com.Parameters.Add(new NpgsqlParameter("veiculo", manifesto.Veiculo.Placa));
				com.Parameters.Add(new NpgsqlParameter("carreta", manifesto.Carreta.Placa));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("rntrc", manifesto.RNTRC));
				com.Parameters.Add(new NpgsqlParameter("ciot", manifesto.CIOT));
				com.Parameters.Add(new NpgsqlParameter("uf_entrega", manifesto.UFEntrega));
				com.Parameters.Add(new NpgsqlParameter("mun_entrega", manifesto.MunEntrega));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if ((manifesto.Indice = int.Parse(dr[0].ToString())) == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoMaterial(Material material)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_material(:codigo, :nome, :descricao, :fornecedor, :tipo, :medida, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", material.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", material.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", material.Descricao));
				com.Parameters.Add(new NpgsqlParameter("fornecedor", material.Fornecedor));
				com.Parameters.Add(new NpgsqlParameter("tipo", material.Tipo));
				com.Parameters.Add(new NpgsqlParameter("medida", material.Medida));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
					return false;

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public long NovoPagamento(Pedido pedido, Parcela parcela, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_pagamento(:cliente, " +
																					":pedido, " +
																					":data, " +
																					":hora, " +
																					":vencimento, " +
																					":tipo, " +
																					":numero, " +
																					":valor, " +
																					":juros, " +
																					":usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("cliente", pedido.ClientePedido()));
				com.Parameters.Add(new NpgsqlParameter("pedido", pedido.NumeroPedido()));
				com.Parameters.Add(new NpgsqlParameter("data", pedido.Data));
				com.Parameters.Add(new NpgsqlParameter("hora", pedido.Hora));
				com.Parameters.Add(new NpgsqlParameter("vencimento", parcela.Vencimento));
				com.Parameters.Add(new NpgsqlParameter("tipo", "P"));
				com.Parameters.Add(new NpgsqlParameter("numero", parcela.Numero));
				com.Parameters.Add(new NpgsqlParameter("valor", parcela.Valor));
				com.Parameters.Add(new NpgsqlParameter("juros", parcela.Juros));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return long.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public int NovoPedido(Pedido pedido, int usuario, int caixa)
		{
			try
			{
				int numero_pedido;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_pedido(:usuario, :obs, :cliente, :caixa, :total, :vendedor, :tabela)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("obs", pedido.Observacao));
				com.Parameters.Add(new NpgsqlParameter("cliente", pedido.ClientePedido()));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("total", pedido.TotalPedido));
				com.Parameters.Add(new NpgsqlParameter("vendedor", pedido.Vendedor.Codigo));
				com.Parameters.Add(new NpgsqlParameter("tabela", pedido.Tabela.Codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (!int.TryParse(dr[0].ToString(), out numero_pedido) || numero_pedido < 1)
				{
					return 0;
				}

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					pedido.Comanda = ProximaComanda();

					com = new NpgsqlCommand("update pedidos set comanda = :comanda where indice = :indice");
					com.Parameters.Add(new NpgsqlParameter("comanda", pedido.Comanda));
					com.Parameters.Add(new NpgsqlParameter("indice", numero_pedido));
					ExecCommand(com);
				}

				if (pedido.TaxaDeEntrega > 0 || pedido.Troco > 0 || pedido.Retirar)
				{
					NpgsqlCommand comTaxa = new NpgsqlCommand("update pedidos set taxa_entrega = :taxa, troco = :troco, retira = :retira where indice = :pedido");
					comTaxa.Parameters.Add(new NpgsqlParameter("taxa", pedido.TaxaDeEntrega));
					comTaxa.Parameters.Add(new NpgsqlParameter("troco", pedido.Troco));
					comTaxa.Parameters.Add(new NpgsqlParameter("pedido", numero_pedido));
					comTaxa.Parameters.Add(new NpgsqlParameter("retira", pedido.Retirar));
					ExecCommand(comTaxa);
				}

				for (int i = 0; i < pedido.ItensQtd; i++)
				{
					if (pedido.ItensPedido[i].Situacao != 'A')
						continue;

					if (!pedido.ItensPedido[i].Secundario)
					{
						com = new NpgsqlCommand("insert into pedidos_itens (pedido, produto, fracao, preco, observacao, usuario, numero, unitario, vendedor) " +
							"values (:pedido, :produto, :fracao, :preco, :observacao, :usuario, :numero, :unitario, :vendedor) returning indice", Conn);

						com.Parameters.Add(new NpgsqlParameter("pedido", numero_pedido));
						com.Parameters.Add(new NpgsqlParameter("produto", pedido.ItensPedido[i].Produto));
						com.Parameters.Add(new NpgsqlParameter("fracao", pedido.ItensPedido[i].Quantidade));
						com.Parameters.Add(new NpgsqlParameter("preco", double.Parse(pedido.ItensPedido[i].Preco.ToString("0.00"))));
						com.Parameters.Add(new NpgsqlParameter("observacao", pedido.ItensPedido[i].Observacao));
						com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
						com.Parameters.Add(new NpgsqlParameter("numero", pedido.ItensPedido[i].Numero)); //getInt(string.Format("select numero from pedidos_itens where pedido = {0} order by numero desc limit 1", numero_pedido))));
						com.Parameters.Add(new NpgsqlParameter("unitario", double.Parse(pedido.ItensPedido[i].Unitario.ToString("0.00"))));
						com.Parameters.Add(new NpgsqlParameter("vendedor", pedido.Vendedor.Codigo));

						dr = com.ExecuteReader();

						dr.Read();

						int indice_item = Convert.ToInt32(dr[0]);

						if (pedido.ItensPedido[i].ItensAdicionais.Count > 0)
						{
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
									"values (:descricao, :valor, :pedido, :item_pedido, :indice_item)", Conn);

								add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
								add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
								add_item.Parameters.Add(new NpgsqlParameter("pedido", numero_pedido));
								add_item.Parameters.Add(new NpgsqlParameter("item_pedido", pedido.ItensPedido[i].Numero));
								add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice_item));

								add_item.ExecuteNonQuery();
							}
						}
					}
					else
					{
						com = new NpgsqlCommand("insert into pedidos_itens (pedido, numero, produto, fracao, observacao, usuario, vendedor) " +
							"values (:pedido, :numero, :produto, :qtd, :obs, :usuario, :vendedor) returning indice", Conn);

						com.Parameters.Add(new NpgsqlParameter("pedido", numero_pedido));
						com.Parameters.Add(new NpgsqlParameter("numero", pedido.ItensPedido[i].Numero));
						com.Parameters.Add(new NpgsqlParameter("produto", pedido.ItensPedido[i].Produto));
						com.Parameters.Add(new NpgsqlParameter("qtd", pedido.ItensPedido[i].Quantidade));
						com.Parameters.Add(new NpgsqlParameter("obs", pedido.ItensPedido[i].Observacao));
						com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
						com.Parameters.Add(new NpgsqlParameter("vendedor", pedido.Vendedor.Codigo));

						dr = com.ExecuteReader();

						dr.Read();

						int indice_item = Convert.ToInt32(dr[0]);

						if (pedido.ItensPedido[i].ItensAdicionais.Count > 0)
						{
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								NpgsqlCommand add_item = new NpgsqlCommand("insert into itens_adicionais(descricao, valor, pedido, item_pedido, indice_item) " +
									"values (:descricao, :valor, :pedido, :item_pedido, :indice_item)", Conn);

								add_item.Parameters.Add(new NpgsqlParameter("descricao", adicional.Descricao));
								add_item.Parameters.Add(new NpgsqlParameter("valor", adicional.Valor));
								add_item.Parameters.Add(new NpgsqlParameter("pedido", numero_pedido));
								add_item.Parameters.Add(new NpgsqlParameter("item_pedido", pedido.ItensPedido[i].Numero));
								add_item.Parameters.Add(new NpgsqlParameter("indice_item", indice_item));

								add_item.ExecuteNonQuery();
							}
						}
					}
				}

				// Data retroativa
				if (pedido.Data != DateTime.MinValue)
				{
					com = new NpgsqlCommand("update pedidos set data = :data where indice = :indice", Conn);
					com.Parameters.Add(new NpgsqlParameter("data", pedido.Data));
					com.Parameters.Add(new NpgsqlParameter("indice", numero_pedido));
					com.ExecuteNonQuery();
				}

				return numero_pedido;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool NovoPonto(int funcionario, DateTime data, DateTime hora, bool adm, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_ponto(:funcionario, :data, :hora, :adm, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario));
				com.Parameters.Add(new NpgsqlParameter("data", data));
				com.Parameters.Add(new NpgsqlParameter("hora", hora));
				com.Parameters.Add(new NpgsqlParameter("adm", adm));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoProdutoGrupo(int codigo, string descricao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_novo_produto_grupo(:codigo, :descricao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("descricao", descricao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoProdutoTipo(ProdutoTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into produtos_tipos (codigo, " +
																				"nome, " +
																				"descricao, " +
																				"producao, " +
																				"estoque, " +
																				"soma, " +
																				"impressora_externa, " +
																				"imprime_total, " +
																				"adicionais, " +
																				"meio, " +
																				"fracao, " +
																				"permite_locacao, " +
																				"intervalo_locacao, " +
																				"periodo_locacao) values " +
																				"(:codigo, " +
																				":nome, " +
																				":descricao, " +
																				":producao, " +
																				":estoque, " +
																				":soma, " +
																				":impressora, " +
																				":imprime_total, " +
																				":adicionais, " +
																				":meio, " +
																				":fracao, " +
																				":permite_locacao, " +
																				":intervalo_locacao, " +
																				":periodo_locacao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("descricao", tipo.Descricao));
				com.Parameters.Add(new NpgsqlParameter("producao", tipo.Producao));
				com.Parameters.Add(new NpgsqlParameter("estoque", tipo.Estoque));
				com.Parameters.Add(new NpgsqlParameter("soma", tipo.Soma));
				com.Parameters.Add(new NpgsqlParameter("impressora", tipo.ImpressoraExterna));
				com.Parameters.Add(new NpgsqlParameter("imprime_total", tipo.ImprimeQuantidadeTotal));
				com.Parameters.Add(new NpgsqlParameter("adicionais", tipo.Adicionais));
				com.Parameters.Add(new NpgsqlParameter("meio", tipo.MeioAMeio));
				com.Parameters.Add(new NpgsqlParameter("fracao", tipo.Fracionado));
				com.Parameters.Add(new NpgsqlParameter("permite_locacao", tipo.PermiteLocacao));
				com.Parameters.Add(new NpgsqlParameter("intervalo_locacao", tipo.IntervaloDeLocacao));
				com.Parameters.Add(new NpgsqlParameter("periodo_locacao", tipo.PeriodoLocacao));

				if (ExecCommand(com))
				{
					if (tipo.LocacaoEspecial.Count > 0)
					{
						foreach (LocacaoEspecial l in tipo.LocacaoEspecial)
						{
							com = new NpgsqlCommand("insert into locacao_especial(produto_tipo, descricao, periodo) values (:produto_tipo, :descricao, :periodo)");
							com.Parameters.Add(new NpgsqlParameter("produto_tipo", tipo.Codigo));
							com.Parameters.Add(new NpgsqlParameter("descricao", l.Descricao));
							com.Parameters.Add(new NpgsqlParameter("periodo", l.Periodo));

							ExecCommand(com);
						}
					}

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoRecurso(Recurso recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into cad_recursos (" +
														"codigo, " +
														"nome, " +
														"tipo, " +
														"usuario, " +
														"nascimento, " +
														"tel1, " +
														"tel2, " +
														"celular, " +
														"endereco, " +
														"cidade, " +
														"estado, " +
														"rg, " +
														"cpf, " +
														"habilitacao, " +
														"categoria, " +
														"email" +
														") values ( " +
														":codigo, " +
														":nome, " +
														":tipo, " +
														":usuario, " +
														":nascimento, " +
														":tel1, " +
														":tel2, " +
														":celular, " +
														":endereco, " +
														":cidade, " +
														":estado, " +
														":rg, " +
														":cpf, " +
														":habilitacao, " +
														":categoria, " +
														":email)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", recurso.Nome));
				com.Parameters.Add(new NpgsqlParameter("tipo", recurso.Tipo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("nascimento", recurso.Nascimento));
				com.Parameters.Add(new NpgsqlParameter("tel1", recurso.Telefone1));
				com.Parameters.Add(new NpgsqlParameter("tel2", recurso.Telefone2));
				com.Parameters.Add(new NpgsqlParameter("celular", recurso.Celular));
				com.Parameters.Add(new NpgsqlParameter("endereco", recurso.Endereco));
				com.Parameters.Add(new NpgsqlParameter("cidade", recurso.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", recurso.Estado));
				com.Parameters.Add(new NpgsqlParameter("rg", recurso.Rg));
				com.Parameters.Add(new NpgsqlParameter("cpf", recurso.Cpf));
				com.Parameters.Add(new NpgsqlParameter("habilitacao", recurso.Habilitacao));
				com.Parameters.Add(new NpgsqlParameter("categoria", recurso.Categoria));
				com.Parameters.Add(new NpgsqlParameter("email", recurso.Email));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoRecursoTipo(RecursoTipo recurso)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into recursos_tipos (codigo, descricao, entrega, producao, comissao_diaria, comissao_nominal, fixo_semanal, fixo_mensal, valor_entrega, diaria) "
				+ "values (:codigo, :descricao, :entrega, :producao, :com_dia, :com_nom, :fixo_sem, :fixo_mes, :valor_entrega, :diaria);");

				com.Parameters.Add(new NpgsqlParameter("codigo", recurso.Codigo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("descricao", recurso.Descricao));
				com.Parameters.Add(new NpgsqlParameter("entrega", recurso.Entrega));
				com.Parameters.Add(new NpgsqlParameter("producao", recurso.Producao));
				com.Parameters.Add(new NpgsqlParameter("com_dia", recurso.ComissaoDiaria));
				com.Parameters.Add(new NpgsqlParameter("com_nom", recurso.ComissaoNominal));
				com.Parameters.Add(new NpgsqlParameter("fixo_sem", recurso.FixoSemanal));
				com.Parameters.Add(new NpgsqlParameter("fixo_mes", recurso.FixoMensal));
				com.Parameters.Add(new NpgsqlParameter("valor_entrega", recurso.ValorEntrega));
				com.Parameters.Add(new NpgsqlParameter("diaria", recurso.Diaria));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool NovoTipoClientes(ClienteTipo tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into clientes_tipos (codigo, nome, cliente_interno, mensalidade) values (:codigo, :nome, :interno, :mensalidade);", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
				com.Parameters.Add(new NpgsqlParameter("interno", tipo.Interno));
				com.Parameters.Add(new NpgsqlParameter("mensalidade", tipo.Mensalidade));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool NovoVeiculo(Veiculo veiculo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into cad_veiculos (placa, modelo, ano, cor, marca, proprietario, endereco, cidade, estado, telefone, cpf, renavam, tara, capkg, capm3, rntrc, ie) values " +
														"(:placa, :modelo, :ano, :cor, :marca, :proprietario, :endereco, :cidade, :estado, :telefone, :cpf, :renavam, :tara, :capkg, :capm3, :rntrc, :ie);");

				com.Parameters.Add(new NpgsqlParameter("placa", veiculo.Placa));
				com.Parameters.Add(new NpgsqlParameter("modelo", veiculo.Modelo));
				com.Parameters.Add(new NpgsqlParameter("ano", veiculo.Ano));
				com.Parameters.Add(new NpgsqlParameter("cor", veiculo.Cor));
				com.Parameters.Add(new NpgsqlParameter("marca", veiculo.Marca));
				com.Parameters.Add(new NpgsqlParameter("proprietario", veiculo.Proprietario));
				com.Parameters.Add(new NpgsqlParameter("endereco", veiculo.Endereco));
				com.Parameters.Add(new NpgsqlParameter("cidade", veiculo.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", veiculo.Estado));
				com.Parameters.Add(new NpgsqlParameter("telefone", veiculo.Telefone));
				com.Parameters.Add(new NpgsqlParameter("cpf", veiculo.Cpf));
				com.Parameters.Add(new NpgsqlParameter("renavam", veiculo.RENAVAM));
				com.Parameters.Add(new NpgsqlParameter("tara", veiculo.Tara));
				com.Parameters.Add(new NpgsqlParameter("capkg", veiculo.CapKg));
				com.Parameters.Add(new NpgsqlParameter("capm3", veiculo.CapM3));
				com.Parameters.Add(new NpgsqlParameter("rntrc", veiculo.RNTRC));
				com.Parameters.Add(new NpgsqlParameter("ie", veiculo.IE));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int NumeroFechamentoCaixa(int fechamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select indice from caixa where fechamento = " + fechamento.ToString());
				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool OCDocumentosOriginarios(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_oc_doc_originarios(" + ordem.Indice.ToString() + ", '{''" +
															ordem.ChaveAcesso[0] + "'', ''" +
															ordem.ChaveAcesso[1] + "'', ''" +
															ordem.ChaveAcesso[2] + "'', ''" +
															ordem.ChaveAcesso[3] + "'', ''" +
															ordem.ChaveAcesso[4] + "'', ''" +
															ordem.ChaveAcesso[5] + "''}', '{''" +
															ordem.DocTipo[0] + "'', ''" +
															ordem.DocTipo[1] + "'', ''" +
															ordem.DocTipo[2] + "'', ''" +
															ordem.DocTipo[3] + "'', ''" +
															ordem.DocTipo[4] + "'', ''" +
															ordem.DocTipo[5] + "''}', '{''" +
															ordem.DocEmit[0] + "'', ''" +
															ordem.DocEmit[1] + "'', ''" +
															ordem.DocEmit[2] + "'', ''" +
															ordem.DocEmit[3] + "'', ''" +
															ordem.DocEmit[4] + "'', ''" +
															ordem.DocEmit[5] + "''}', '{''" +
															ordem.DocNota[0] + "'', ''" +
															ordem.DocNota[1] + "'', ''" +
															ordem.DocNota[2] + "'', ''" +
															ordem.DocNota[3] + "'', ''" +
															ordem.DocNota[4] + "'', ''" +
															ordem.DocNota[5] + "''}', '{''" +
															ordem.DocSerie[0] + "'', ''" +
															ordem.DocSerie[1] + "'', ''" +
															ordem.DocSerie[2] + "'', ''" +
															ordem.DocSerie[3] + "'', ''" +
															ordem.DocSerie[4] + "'', ''" +
															ordem.DocSerie[5] + "''}');", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OCImpostos(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set "
														+ "cst = :cst, "
														+ "bc_icms = :bc, "
														+ "aliquota_icms = :aliq, "
														+ "valor_icms = :valor, "
														+ "red_bc = :red, "
														+ "icms_st = :st, "
														+ "icms_orig = :orig "
														+ "where indice = :ordem;");

				com.Parameters.Add(new NpgsqlParameter("ordem", ordem.Indice));
				com.Parameters.Add(new NpgsqlParameter("cst", ordem.CST));
				com.Parameters.Add(new NpgsqlParameter("bc", ordem.ValorBCICMS));
				com.Parameters.Add(new NpgsqlParameter("aliq", ordem.AliquotaICMS));
				com.Parameters.Add(new NpgsqlParameter("valor", ordem.ValorICMS));
				com.Parameters.Add(new NpgsqlParameter("red", ordem.RedBCICMS));
				com.Parameters.Add(new NpgsqlParameter("st", ordem.ICMSST));
				com.Parameters.Add(new NpgsqlParameter("orig", ordem.Origem));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OCMercadoriasTransportadas(OrdemDeColeta ordem)
		{
			try
			{
				string command = string.Format("select dsoft_oc_merc_transportadas({0}, '{1}', '{2}', '{{{3}, {4}, {5}, {6}, {7}}}', '{{''{8}'', ''{9}'', ''{10}'', ''{11}'', ''{12}''}}', '{{''{13}'', ''{14}'', ''{15}'', ''{16}'', ''{17}''}}', {18});",
					ordem.Indice,
					ordem.ProdudoPredominante,
					ordem.OutrasCaracteristicas,
					Util.Formata2(ordem.Quantidade[0]),
					Util.Formata2(ordem.Quantidade[1]),
					Util.Formata2(ordem.Quantidade[2]),
					Util.Formata2(ordem.Quantidade[3]),
					Util.Formata2(ordem.Quantidade[4]),
					ordem.UnidadeMedida[0],
					ordem.UnidadeMedida[1],
					ordem.UnidadeMedida[2],
					ordem.UnidadeMedida[3],
					ordem.UnidadeMedida[4],
					ordem.TipoMedida[0],
					ordem.TipoMedida[1],
					ordem.TipoMedida[2],
					ordem.TipoMedida[3],
					ordem.TipoMedida[4],
					Util.Formata2(double.Parse(ordem.ValorMercadoria.ToString("0.00"))));

				NpgsqlCommand com = new NpgsqlCommand(command, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OCOutros(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_oc_outros(:ordem, '{" +
																				"':obs1', " +
																				"':obs2', " +
																				"':obs3', " +
																				"':obs4', " +
																				"':obs5'}');", Conn);

				com.Parameters.Add(new NpgsqlParameter("ordem", ordem.Indice));
				com.Parameters.Add(new NpgsqlParameter("obs1", ordem.Observacoes[0]));
				com.Parameters.Add(new NpgsqlParameter("obs2", ordem.Observacoes[1]));
				com.Parameters.Add(new NpgsqlParameter("obs3", ordem.Observacoes[2]));
				com.Parameters.Add(new NpgsqlParameter("obs4", ordem.Observacoes[3]));
				com.Parameters.Add(new NpgsqlParameter("obs5", ordem.Observacoes[4]));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OCPrestacaoServicos(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_oc_prest_servicos(" + ordem.Indice.ToString() + ", " +
															ordem.CFOP.ToString() + ", '" +
															ordem.NaturezaDaOperacao + "', '" +
															ordem.RNTRC + "', to_date('" +
															ordem.PrevisaoEntrega.ToString("ddMMyy") + "', 'DDMMYY'), '{''" +
															ordem.Componente[0] + "'', ''" +
															ordem.Componente[1] + "'', ''" +
															ordem.Componente[2] + "'', ''" +
															ordem.Componente[3] + "'', ''" +
															ordem.Componente[4] + "'', ''" +
															ordem.Componente[5] + "'', ''" +
															ordem.Componente[6] + "'', ''" +
															ordem.Componente[7] + "'', ''" +
															ordem.Componente[8] + "'', ''" +
															ordem.Componente[9] + "'', ''" +
															ordem.Componente[10] + "'', ''" +
															ordem.Componente[11] + "''}', '{" +
															ordem.ValorPrestacao[0].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[1].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[2].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[3].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[4].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[5].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[6].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[7].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[8].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[9].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[10].ToString().Replace(',', '.') + ", " +
															ordem.ValorPrestacao[11].ToString().Replace(',', '.') + "}', " +
															ordem.ValorFrete.ToString().Replace(',', '.') + ");", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OCRodoviaria(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set motorista = :motorista, " +
														"veiculo = :veiculo where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("motorista", ordem.Motorista.Codigo));
				com.Parameters.Add(new NpgsqlParameter("veiculo", ordem.Veiculo.Placa));
				com.Parameters.Add(new NpgsqlParameter("indice", ordem.Indice));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool Compl(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update ordem_servico set carac_ad = :carac_ad, carac_ser = :carac_ser, obs_cont = :obs_cont, obs_fisco = :obs_fisco, xobs = :obs " +
					" where indice = :indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("carac_ad", ordem.CaracAd));
				com.Parameters.Add(new NpgsqlParameter("carac_ser", ordem.CaracSer));
				com.Parameters.Add(new NpgsqlParameter("obs_cont", ordem.ObsCont));
				com.Parameters.Add(new NpgsqlParameter("obs_fisco", ordem.ObsFisco));
				com.Parameters.Add(new NpgsqlParameter("obs", ordem.Obs));
				com.Parameters.Add(new NpgsqlParameter("indice", ordem.Indice));

				return com.ExecuteNonQuery() > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OrdemColetaAutorizado(int indice, string dhRec, long nProc, string digVal, string arquivo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cte_autorizado(:indice, :dhRec, :nProc, :digVal, :arquivo);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", indice));
				com.Parameters.Add(new NpgsqlParameter("dhRec", dhRec));
				com.Parameters.Add(new NpgsqlParameter("nProc", nProc));
				com.Parameters.Add(new NpgsqlParameter("digVal", digVal));
				com.Parameters.Add(new NpgsqlParameter("arquivo", arquivo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OrdemColetaEnviada(int ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_ordem_coleta_enviada(:indice);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OrdemColetaErro(int ordem, string msg)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_ordem_coleta_erro(:indice, :msg);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem));
				com.Parameters.Add(new NpgsqlParameter("msg", msg));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OrdemColetaLote(int ordem, int lote)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cte_lote(:indice, :lote);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem));
				com.Parameters.Add(new NpgsqlParameter("lote", lote));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool OrdemColetaLoteRecebido(int ordem, string amb, int stat, string motivo, long recibo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_cte_lote_recebido(:indice, :amb, :stat, :mot, :recibo);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem));
				com.Parameters.Add(new NpgsqlParameter("amb", amb));
				com.Parameters.Add(new NpgsqlParameter("stat", stat));
				com.Parameters.Add(new NpgsqlParameter("mot", motivo));
				com.Parameters.Add(new NpgsqlParameter("recibo", recibo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PagamentoCrediario(int pedido)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select count(indice) from pagamentos where pedido = :pedido and tipo = 'P'", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (int.Parse(dr[0].ToString()) > 0)
					return true;
				else
					return false;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public List<string> PagamentosFormas(long? Cliente = null)
		{
			try
			{
				List<string> formas = new List<string>();

				NpgsqlCommand com = new NpgsqlCommand("select codigo, descricao from pagamentos_formas where ativo = true order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					if (RegrasDeNegocio.Instance.Ramo != "LOJA" && dr[0].ToString() == "P" ||
						RegrasDeNegocio.Instance.Ramo == "PIZZARIA" && (dr[0].ToString() == "B" || dr[0].ToString() == "P") ||
						Cliente == null && dr[0].ToString() == "P")
						continue;

					formas.Add(dr[0].ToString() + " - " + dr[1].ToString());
				}

				return formas;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<FormaDePagamento> FormasDePagamento()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo, descricao, debito, ativo from pagamentos_formas order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<FormaDePagamento> formasDePagamento = new List<FormaDePagamento>();

				while (dr.Read())
				{
					FormaDePagamento formaDePagamento = new FormaDePagamento();

					formaDePagamento.Codigo = dr["codigo"].ToString()[0];
					formaDePagamento.Descricao = dr["descricao"].ToString();
					formaDePagamento.Debito = Convert.ToBoolean(dr["debito"]);
					formaDePagamento.Ativo = Convert.ToBoolean(dr["ativo"]);

					formasDePagamento.Add(formaDePagamento);
				}

				return formasDePagamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public DataTable CarregarFormasDePagamento()
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, debito, ativo from pagamentos_formas order by codigo", Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				if (ds != null && ds.Tables.Count > 0)
				{
					return ds.Tables[0];
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public bool InsertOrUpdate(FormaDePagamento formaDePagamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select insert_or_update_forma_de_pagamento(:codigo, :descricao, :debito, :ativo)");
				com.Parameters.Add(new NpgsqlParameter("codigo", formaDePagamento.Codigo.ToString()));
				com.Parameters.Add(new NpgsqlParameter("descricao", formaDePagamento.Descricao));
				com.Parameters.Add(new NpgsqlParameter("debito", formaDePagamento.Debito));
				com.Parameters.Add(new NpgsqlParameter("ativo", formaDePagamento.Ativo));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool PagamentosFormas(out string[] formas)
		{
			try
			{
				int indice = 0;

				NpgsqlCommand com = new NpgsqlCommand("select count(codigo) from pagamentos_formas", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				indice = int.Parse(dr[0].ToString());

				if (indice < 1)
				{
					formas = null;

					return false;
				}

				formas = new string[indice];

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select codigo, descricao from pagamentos_formas where ativo = true", Conn);

				dr = com.ExecuteReader();

				indice = 0;

				while (dr.Read())
				{
					formas[indice++] = dr[0].ToString() + " - " + dr[1].ToString();
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				formas = null;

				return false;
			}
		}

		public Task<List<FormaDePagamento>> PagamentosFormasAsync()
		{
			return Task.Factory.StartNew<List<FormaDePagamento>>(() =>
			{
				return FormasDePagamento();
			});
		}

		public double PagamentosPendentes(long cliente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_pagamentos_pendentes(:cliente);", Conn);

				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return double.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public double PagamentosPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'P' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool PagarCompra(int compra, int usuario, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_paga_compra(:usuario, :compra, :caixa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("compra", compra));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PagarDespesa(int despesa, int usuario, int caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_paga_despesa(:usuario, :despesa, :caixa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("despesa", despesa));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PagarPedido(int pedido, char forma, string documento, double valor, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_paga_pedido(:pedido, :usuario, :valor, :forma, :documento, :caixa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("valor", valor));
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));
				com.Parameters.Add(new NpgsqlParameter("documento", documento));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (int.Parse(dr[0].ToString()) > 0)
				{
					return true;
				}
				else
				{
					switch (int.Parse(dr[0].ToString()))
					{
						case -9:
							MessageBox.Show("Operação negada.", "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							break;

						case -13:
							MessageBox.Show("Saldo insuficiente.", "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							break;

						default:
							MessageBox.Show(dr[0].ToString());
							break;
					}

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool PagarPedidoZerado(Pedido pedido, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos set situacao = :situacao where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("indice", pedido.Numero));

			if (pedido.Situacao == 'A')
			{
				com.Parameters.Add(new NpgsqlParameter("situacao", "N"));
				return ExecCommand(com);
			}
			else if (pedido.Situacao == 'E')
			{
				com.Parameters.Add(new NpgsqlParameter("situacao", "P"));
				return ExecCommand(com);
			}
			else if (pedido.Situacao == 'S')
			{
				com.Parameters.Add(new NpgsqlParameter("situacao", "O"));
				return ExecCommand(com);
			}

			return false;
		}


		public bool PagarPedidoCrediario(int pedido, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_paga_pedido_crediario(:pedido, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PagarLocacao(Locacao locacao, PagamentoNovo pagamento, Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into pagamentos(tipo, usuario, valor, documento, cliente, locacao) " +
					"values (:tipo, :usuario, :valor, :documento, :cliente, :locacao) returning indice");

				com.Parameters.Add(new NpgsqlParameter("tipo", pagamento.Forma[0].ToString()));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("valor", pagamento.Valor));
				com.Parameters.Add(new NpgsqlParameter("documento", pagamento.Documento));
				com.Parameters.Add(new NpgsqlParameter("cliente", locacao.Cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("locacao", locacao.Indice));

				int indice = getInt(com);

				com = new NpgsqlCommand("insert into caixa_fluxo(caixa, valor, usuario, observacao, cliente, forma, pagamento) " +
					"values (:caixa, :valor, :usuario, :observacao, :cliente, :forma, :pagamento)");

				com.Parameters.Add(new NpgsqlParameter("caixa", Caixa.Numero));
				com.Parameters.Add(new NpgsqlParameter("valor", pagamento.Valor));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("observacao", string.Format("PAGAMENTO REFERENTE À LOCAÇÃO N. {0}", locacao.Indice)));
				com.Parameters.Add(new NpgsqlParameter("cliente", locacao.Cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("forma", pagamento.Forma[0].ToString()));
				com.Parameters.Add(new NpgsqlParameter("pagamento", indice));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PedidoCliente(int pedido, long cliente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cliente from pedidos where indice = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				if (long.TryParse(dr[0].ToString(), out cliente))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool PedidoData(int pedido, out DateTime data)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select data from pedidos where indice = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					data = DateTime.MinValue;

					return false;
				}

				data = Convert.ToDateTime(dr["data"].ToString());

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				data = DateTime.MinValue;

				return false;
			}
		}

		public int PedidoDoCupomFiscal(int loja, int caixa, long cupom)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select indice from pedidos where loja = :loja and caixa = :caixa and cupom = :cupom limit 1", Conn);

				com.Parameters.Add(new NpgsqlParameter("loja", loja));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("cupom", cupom));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public int PedidoEmAberto(long cliente)
		{
			NpgsqlCommand com = new NpgsqlCommand("select indice from pedidos where cliente = :cliente and situacao = 'A'", Conn);
			com.Parameters.Add(new NpgsqlParameter("cliente", cliente));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (!dr.Read())
			{
				return -1;
			}

			return Convert.ToInt32(dr[0]);
		}

		/// <summary>
		/// Vincula uma NFe ao pedido no banco-de-dados
		/// </summary>
		/// <param name="pedido">Pedido com a NFe já gerada</param>
		/// <returns>Sucesso na gravação</returns>
		public bool PedidoNFe(Pedido pedido)
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos set nfe = :nfe where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("nfe", pedido.NFe));
			com.Parameters.Add(new NpgsqlParameter("indice", pedido.Indice));

			return ExecCommand(com);
		}

		public double PedidosEmAberto(DateTime inicial, DateTime final, DataSet ds)
		{
			try
			{
				double total = 0;

				string sql = "select pedidos.indice as pedido, " +
									"to_char(pedidos.data, 'DD/MM/YY') as data, " +
									"pedidos.cliente as cliente, " +
									"cad_clientes.nome as nome, " +
									"pedidos.itens as itens, " +
									"pedidos.total as total " +
									"from pedidos left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
									"where pedidos.data between to_date('" + inicial.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and to_date('" + final.ToString("dd/MM/yy") + "', 'DD/MM/YY') and pedidos.situacao = 'A' " +
									"order by pedidos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				foreach (DataRow d in ds.Tables[0].Rows)
				{
					total += double.Parse(d.ItemArray[5].ToString());
				}

				return total;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public double PedidosItensPorCliente(DateTime de, DateTime ate, long cliente, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos.indice as pedido, " +
																"to_char(pedidos.data, 'DD/MM/YY') as data, " +
																"pedidos.hora as hora, " +
																"pedidos.valor as valor, " +
																"pedidos.situacao as situacao, " +
																"pedidos_itens.produto as produto, " +
																"cad_produtos.nome as produto_nome, " +
																"pedidos_itens.fracao as quantidade, " +
																"pedidos_itens.preco as preco, " +
																"pedidos_itens.unitario as unitario, " +
																"pedidos_itens.numero as numero, " +
																"pedidos_itens.observacao " +
																"from pedidos_itens " +
																"left join pedidos on (pedidos.indice = pedidos_itens.pedido) " +
																"left join cad_produtos on (cad_produtos.codigo = pedidos_itens.produto) " +
																"where pedidos.cliente = " + cliente.ToString() + " and pedidos.situacao <> 'C' and pedidos.data between " +
																"to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
																"order by pedidos.indice", Conn);

				da.Fill(ds);

				return 0;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public char PedidoSituacao(int pedido)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select situacao from pedidos where indice = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return default(char);
				}

				char situacao;
				char.TryParse(dr[0].ToString(), out situacao);

				return situacao;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return default(char);
			}
		}

		public void PedidosLista(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos.indice as codigo, " +
																	"pedidos.data, " +
																	"pedidos.hora, " +
																	"pedidos.cliente, " +
																	"cad_clientes.nome, " +
																	"pedidos.itens, " +
																	"pedidos.total, " +
																	"pedidos.situacao, " +
																	"pedidos.observacao, " +
																	"pedidos.usuario, " +
																	"cad_usuarios.nome " +
																	"from pedidos " +
																	"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
																	"left join cad_usuarios on (cad_usuarios.codigo = pedidos.usuario) " +
																	"order by pedidos.indice", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public Task<DataSet> PedidosSemFechamentoAsync()
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				return PedidosSemFechamento();
			});
		}

		public DataSet PedidosSemFechamento()
		{
			try
			{
				string comando = string.Empty;

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					comando = "select pedidos.comanda, " +
										"pedidos.data, " +
										"pedidos.hora, " +
										"pedidos.cliente, " +
										"cad_clientes.nome, " +
										"cad_clientes.endereco, " +
										"pedidos.itens, " +
										"pedidos.total, " +
										"pedidos.taxa_entrega, " +
										"entregas.saida, " +
										"entregas.entrega, " +
										"cad_recursos.nome as vendedor, " +
										"pedidos.situacao, " +
										"pedidos.observacao, " +
										"pedidos.indice, " +
										"pedidos.usuario, " +
										"cad_usuarios.nome as usuario_nome " +
										"from pedidos " +
										"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
										"left join cad_usuarios on (cad_usuarios.codigo = pedidos.usuario) " +
										"left join entregas on (entregas.situacao <> 'C' and entregas.pedido = pedidos.indice) " +
										"left join cad_recursos on (cad_recursos.codigo = pedidos.vendedor) " +
										"where pedidos.fechamento is null " +
										"order by pedidos.indice";
				}
				else
				{
					comando = "select pedidos.indice, " +
										"pedidos.data, " +
										"pedidos.hora, " +
										"pedidos.cliente, " +
										"cad_clientes.nome, " +
										"cad_clientes.endereco, " +
										"pedidos.itens, " +
										"pedidos.total, " +
										"pedidos.taxa_entrega, " +
										"entregas.saida, " +
										"entregas.entrega, " +
										"cad_recursos.nome as vendedor, " +
										"pedidos.situacao, " +
										"pedidos.observacao, " +
										"pedidos.comanda, " +
										"pedidos.usuario, " +
										"cad_usuarios.nome as usuario_nome " +
										"from pedidos " +
										"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
										"left join cad_usuarios on (cad_usuarios.codigo = pedidos.usuario) " +
										"left join entregas on (entregas.situacao <> 'C' and entregas.pedido = pedidos.indice) " +
										"left join cad_recursos on (cad_recursos.codigo = pedidos.vendedor) " +
										"where pedidos.fechamento is null " +
										"order by pedidos.indice";
				}

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);

				return null;
			}
		}

		public Task<DataSet> PedidosListaAsync(int ultimo = 0)
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();
				PedidosPagina(ds, ultimo);
				return ds;
			});
		}

		public void PedidosPagina(DataSet ds, int ultimo = 0, int quantidade = 100)
		{
			try
			{
				string sql;

				if (ultimo == 0)
				{
					sql = String.Format("select * from (select pedidos.indice, " +
									"pedidos.data, " +
									"pedidos.hora, " +
									"pedidos.cliente, " +
									"cad_clientes.nome, " +
									"cad_clientes.endereco, " +
									"pedidos.itens, " +
									"pedidos.total, " +
									"pedidos.taxa_entrega, " +
									"entregas.saida, " +
									"entregas.entrega, " +
									"pedidos.situacao, " +
									"pedidos.observacao, " +
									"pedidos.comanda, " +
									"pedidos.usuario, " +
									"cad_recursos.nome as vendedor, " +
									"cad_usuarios.nome as usuario_nome " +
									"from pedidos " +
									"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
									"left join cad_usuarios on (cad_usuarios.codigo = pedidos.usuario) " +
									"left join entregas on (entregas.pedido = pedidos.indice) " +
									"left join cad_recursos on (cad_recursos.codigo = pedidos.vendedor) " +
									"order by pedidos.indice desc limit {0}) as a order by a.indice", quantidade);
				}
				else
				{
					sql = String.Format("select * from (select pedidos.indice, " +
									"pedidos.data, " +
									"pedidos.hora, " +
									"pedidos.cliente, " +
									"cad_clientes.nome, " +
									"cad_clientes.endereco, " +
									"pedidos.itens, " +
									"pedidos.total, " +
									"pedidos.situacao, " +
									"pedidos.observacao, " +
									"pedidos.comanda, " +
									"pedidos.usuario, " +
									"cad_usuarios.nome as usuario_nome " +
									"from pedidos " +
									"left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
									"left join cad_usuarios on (cad_usuarios.codigo = pedidos.usuario) " +
									"where pedidos.indice < {0} " +
									"order by pedidos.indice desc limit {1}) as a order by a.indice", ultimo, quantidade);
				}

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public double PedidosPorCliente(DateTime de, DateTime ate, long cliente, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos.indice as pedido, " +
																"pedidos.data as data, " +
																"pedidos.hora as hora, " +
																"entregas.saida as saida, " +
																"entregas.entrega as entrega, " +
																"pedidos.valor as valor, " +
																"pedidos.situacao as situacao, " +
																"entregas.recurso, " +
																"cad_recursos.nome as entregador " +
																"from pedidos " +
																"left join entregas on (entregas.pedido = pedidos.indice) " +
																"left join cad_recursos on (cad_recursos.codigo = entregas.recurso) " +
																"where pedidos.cliente = " + cliente.ToString() + " and pedidos.data between " +
																"to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
																"order by pedidos.indice", Conn);

				da.Fill(ds);

				return 0;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public bool PedidosPorCliente(long cliente, DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select pedidos.indice as pedido, " +
																"pedidos.data as data, " +
																"pedidos.hora as hora, " +
																"entregas.saida as saida, " +
																"entregas.entrega as entrega, " +
																"pedidos.valor as valor, " +
																"pedidos.situacao as situacao, " +
																"entregas.recurso, " +
																"cad_recursos.nome as entregador " +
																"from pedidos " +
																"left join entregas on (entregas.pedido = pedidos.indice) " +
																"left join cad_recursos on (cad_recursos.codigo = entregas.recurso) " +
																"where pedidos.cliente = " + cliente.ToString() + " " +
																"order by pedidos.indice", Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public double PedidosPorPeriodo(DateTime de, DateTime ate, DataSet ds)
		{
			try
			{
				double soma = 0;

				string sql = "select pedidos.indice as codigo, " +
									"to_char(pedidos.data, 'DD/MM/YY') as data, " +
									"pedidos.caixa, " +
									"cad_caixa.descricao as descricao, " +
									"pedidos.itens, " +
									"pedidos.valor, " +
									"pedidos.total, " +
									"pedidos.situacao " +
									"from pedidos " +
									"left join cad_caixa on (cad_caixa.codigo = pedidos.caixa) " +
									"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and pedidos.situacao <> 'C' " +
									"order by pedidos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				sql = "select sum(total) from pedidos " +
						"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
						"and pedidos.situacao <> 'C'";

				NpgsqlCommand com = new NpgsqlCommand(sql, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				double.TryParse(dr[0].ToString(), out soma);

				return soma;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public double PedidosPorPeriodo(DateTime de, DateTime ate, int caixa, DataSet ds)
		{
			try
			{
				double soma = 0;

				string sql = "select pedidos.indice as codigo, " +
									"to_char(pedidos.data, 'DD/MM/YY') as data, " +
									"pedidos.caixa, " +
									"cad_caixa.descricao as descricao, " +
									"pedidos.itens, " +
									"pedidos.valor, " +
									"pedidos.situacao " +
									"from pedidos " +
									"left join cad_caixa on (cad_caixa.codigo = pedidos.caixa) " +
									"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and pedidos.caixa = " + caixa.ToString() +
									" and pedidos.situacao <> 'C' " +
									"order by pedidos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				sql = "select sum(valor) from pedidos " +
						"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
						"and pedidos.caixa = " + caixa.ToString() +
						" and pedidos.situacao <> 'C'";

				NpgsqlCommand com = new NpgsqlCommand(sql, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				double.TryParse(dr[0].ToString(), out soma);

				return soma;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public double PedidosPorVendedor(int vendedor, DateTime de, DateTime ate, DataSet ds)
		{
			try
			{
				double soma = 0;

				string sql = "select pedidos.indice as pedido, " +
									"to_char(pedidos.data, 'DD/MM/YY') as data, " +
									"pedidos.caixa, " +
									"cad_caixa.descricao as descricao, " +
									"pedidos.itens, " +
									"pedidos.total, " +
									"pedidos.situacao " +
									"from pedidos " +
									"left join cad_caixa on (cad_caixa.codigo = pedidos.caixa) " +
									"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
									"and pedidos.vendedor = " + vendedor.ToString() +
									" and pedidos.situacao <> 'C' " +
									"order by pedidos.indice";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);

				sql = "select sum(total) from pedidos " +
						"where pedidos.data between to_date('" + de.ToString("dd/MM/yy") + "', 'DD/MM/YY') and to_date('" + ate.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
						"and pedidos.vendedor = " + vendedor.ToString() +
						" and pedidos.situacao <> 'C'";

				NpgsqlCommand com = new NpgsqlCommand(sql, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				double.TryParse(dr[0].ToString(), out soma);

				return soma;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public decimal PedidoValor(int pedido)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select total from pedidos where indice = :pedido", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return 0;
				}

				return decimal.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public void PreencherDadosBasicos()
		{
			try
			{
				string dadosBasicos = File.ReadAllText("DadosBasicos.sql");

				if (dadosBasicos != null)
				{
					NpgsqlCommand com = new NpgsqlCommand(dadosBasicos, Conn);

					com.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool PreencherEmitente(Emitente emitente)
		{
			if (emitente.RazaoSocial != null && emitente.RazaoSocial != string.Empty)
			{
				emitente.Cnpj = EmitenteCnpj(emitente.RazaoSocial);
				return true;
			}
			if (emitente.Cnpj != null && emitente.Cnpj != 0)
			{
				emitente.RazaoSocial = EmitenteRazaoSocial(emitente.Cnpj);
				return true;
			}

			return false;
		}

		public string ProdutoCFOP(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cfop from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public long ProdutoCodigo(string produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_produtos where nome = :nome");

				com.Parameters.Add(new NpgsqlParameter("nome", produto));

				return getLong(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return 0;
			}
		}

		public bool ProdutoControlaEstoque(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select estoque from produtos_tipos where codigo = (select tipo from cad_produtos where codigo = :codigo)", Conn);
				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					return Convert.ToBoolean(dr[0]);
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public string ProdutoDescricao(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public string ProdutoEAN(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select ean from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public string ProdutoEANTrib(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select ean_trib from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public double ProdutoEstoque(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_total_estoque(:produto);", Conn);
				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				NpgsqlDataReader dr = com.ExecuteReader(CommandBehavior.SingleResult);
				dr.Read();
				return Convert.ToDouble(dr[0]);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public string ProdutoGrupoDescricao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from produtos_grupos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public string ProdutoImagem(long codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select foto from cad_produtos where codigo = :codigo;");
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
			return getString(com);
		}

		public int ProdutoMedida(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select medida from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return -1;
			}
		}

		public int ProdutoMedidaTributavel(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select medida_tributavel from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return -1;
			}
		}

		public string ProdutoNCM(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select ncm from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public string ProdutoNome(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return string.Empty;
			}
		}

		public string ProdutoNome(long produto, int max)
		{
			string nome = ProdutoNome(produto);

			if (nome.Length > max)
				return nome.Substring(0, max);

			return nome;
		}

		public bool ProdutoPermiteItensAdicionais(long produto)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produtos_tipos.adicionais from cad_produtos "
				+ "left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo) "
				+ "where cad_produtos.codigo = :produto", Conn);

			com.Parameters.Add(new NpgsqlParameter("produto", produto));

			NpgsqlDataReader dr = com.ExecuteReader();

			dr.Read();

			return Convert.ToBoolean(dr[0]);
		}

		public double ProdutoPreco(long codigo, int tabela)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select produtos_precos.preco " +
														"from produtos_precos " +
														"where produtos_precos.tabela = :tabela and produtos_precos.produto = :codigo");

				com.Parameters.Add(new NpgsqlParameter("tabela", tabela));
				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public double ProdutoPrecoTributavel(long codigo, int tabela)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select produtos_precos.tributavel " +
														"from produtos_precos " +
														"where produtos_precos.tabela = :tabela and produtos_precos.produto = :codigo");

				com.Parameters.Add(new NpgsqlParameter("tabela", tabela));
				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public int ProdutoQuantidadeTributavel(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select quantidade_tributavel from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD");

				return -1;
			}
		}

		public void ProdutosCadastrados(DataSet ds)
		{
			try
			{
				string sql = "select cad_produtos.codigo, " +
									"cad_produtos.nome, " +
									"cad_produtos.tipo, " +
									"produtos_tipos.nome, " +
									"cad_produtos.grupo, " +
									"produtos_grupos.descricao, " +
									"cad_produtos.descricao, " +
									"cad_produtos.situacao, " +
									"cad_produtos.grupo_tributario, " +
									"grupos_tributarios.nome, " +
									"cad_produtos.medida, " +
									"cad_produtos.fornecedor, " +
									"cad_produtos.foto, " +
									"cad_produtos.ncm, " +
									"cad_produtos.cfop " +
									"from cad_produtos " +
									"left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo) " +
									"left join produtos_grupos on (produtos_grupos.codigo = cad_produtos.grupo) " +
									"left join grupos_tributarios on (grupos_tributarios.codigo = cad_produtos.grupo_tributario) " +
									"order by cad_produtos.codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void ProdutosCadastrados2(DataSet ds)
		{
			try
			{
				string sql = "select cad_produtos.codigo, " +
									"cad_produtos.nome " +
									"from cad_produtos " +
									"where situacao = 'A' " +
									"order by cad_produtos.codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public List<Produto> CarregarProdutos(bool estoque = false)
		{
			string comando = string.Empty;

			if (estoque)
			{
				comando = "select cad_produtos.codigo, cad_produtos.nome, cad_produtos.tipo, cad_produtos.grupo, cad_produtos.descricao, cad_produtos.producao, cad_produtos.foto, " +
					" produtos_tipos.codigo as tipo_codigo, produtos_tipos.nome as tipo_nome, produtos_tipos.descricao as tipo_descricao, produtos_tipos.producao as tipo_producao, produtos_tipos.estoque as tipo_estoque, produtos_tipos.adicionais as tipo_adicionais, produtos_tipos.meio as tipo_meio, produtos_tipos.fracao as tipo_fracao " +
					" from cad_produtos left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo) " +
					" where cad_produtos.situacao = 'A' and produtos_tipos.estoque = true order by cad_produtos.codigo";
			}
			else
			{
				comando = "select cad_produtos.codigo, cad_produtos.nome, cad_produtos.tipo, cad_produtos.grupo, cad_produtos.descricao, cad_produtos.producao, cad_produtos.foto, " +
					" produtos_tipos.codigo as tipo_codigo, produtos_tipos.nome as tipo_nome, produtos_tipos.descricao as tipo_descricao, produtos_tipos.producao as tipo_producao, produtos_tipos.estoque as tipo_estoque, produtos_tipos.adicionais as tipo_adicionais, produtos_tipos.meio as tipo_meio, produtos_tipos.fracao as tipo_fracao " +
					" from cad_produtos left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo) " +
					" where cad_produtos.situacao = 'A' order by cad_produtos.codigo";
			}

			NpgsqlCommand com = new NpgsqlCommand(comando, Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			List<Produto> produtos = new List<Produto>(1000);

			while (dr.Read())
			{
				Produto produto = new Produto();

				produto.Codigo = Convert.ToInt64(dr["codigo"]);
				produto.Nome = dr["nome"].ToString();

				if (dr["tipo"].ToString().Length > 0)
				{
					produto.Tipo = Convert.ToInt32(dr["tipo"]);

					if (produto.Tipo > 0)
					{
						produto.ProdutoTipo = new ProdutoTipo();
						produto.ProdutoTipo.Codigo = Convert.ToInt32(dr["tipo_codigo"]);
						produto.ProdutoTipo.Nome = dr["tipo_nome"].ToString();
						produto.ProdutoTipo.Descricao = dr["tipo_descricao"].ToString();
						produto.ProdutoTipo.Producao = Convert.ToBoolean(dr["tipo_producao"]);
						produto.ProdutoTipo.Estoque = Convert.ToBoolean(dr["tipo_estoque"]);
						produto.ProdutoTipo.Adicionais = Convert.ToBoolean(dr["tipo_adicionais"]);
						produto.ProdutoTipo.MeioAMeio = Convert.ToBoolean(dr["tipo_meio"]);
						produto.ProdutoTipo.Fracionado = Convert.ToBoolean(dr["tipo_fracao"]);
					}
				}

				if (dr["grupo"].ToString().Length > 0)
				{
					produto.Grupo = Convert.ToInt32(dr["grupo"]);
				}

				produto.Descricao = dr["descricao"].ToString();

				produto.Foto = dr["foto"].ToString();

				produtos.Add(produto);
			}

			return produtos;
		}

		public Task<List<Produto>> CarregarProdutosAsync()
		{
			return Task.Factory.StartNew<List<Produto>>(() =>
				{
					return CarregarProdutos();
				});
		}

		public Task<DataSet> ProdutosCadastrados2Async()
		{
			return Task.Factory.StartNew<DataSet>(() =>
			{
				DataSet ds = new DataSet();

				ProdutosCadastrados2(ds);

				return ds;
			});
		}

		public List<Produto> ProdutosFracionados()
		{
			try
			{
				List<Produto> produtos = new List<Produto>();

				NpgsqlCommand com = new NpgsqlCommand("select cad_produtos.codigo, cad_produtos.nome, cad_produtos.descricao from cad_produtos " +
					"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
					"where produtos_tipos.fracao = true order by cad_produtos.codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					Produto produto = new Produto();

					produto.Codigo = Convert.ToInt64(dr["codigo"]);
					produto.Nome = dr["nome"].ToString();
					produto.Descricao = dr["descricao"].ToString();

					produtos.Add(produto);
				}

				return produtos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show("Erro ao carregar os produtos. " + e.Message, "DSoft BD");
				return null;
			}
		}

		public int ProdutosGrupoFechamento(int fechamento, out ProdutoGrupo[] grupos)
		{
			try
			{
				int q = 0;
				string sql = "select distinct cad_produtos.grupo as codigo, " +
								"produtos_grupos.descricao as descricao, " +
								"sum(pedidos_itens.fracao) as quantidade, " +
								"sum(pedidos_itens.preco) as valor " +
								"from cad_produtos " +
								"left join produtos_grupos on (produtos_grupos.codigo = cad_produtos.grupo) " +
								"left join pedidos_itens on (pedidos_itens.produto = cad_produtos.codigo) " +
								"left join pedidos on (pedidos.indice = pedidos_itens.pedido) " +
								"where pedidos.fechamento = " + fechamento.ToString() + " " +
								"group by cad_produtos.grupo, produtos_grupos.descricao";

				NpgsqlCommand com = new NpgsqlCommand(sql, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					q++;
				}

				ProdutoGrupo[] g = new ProdutoGrupo[q];

				dr = com.ExecuteReader();

				for (int i = 0; i < g.Length; i++)
				{
					dr.Read();

					g[i] = new ProdutoGrupo();

					g[i].Codigo = long.Parse(dr["codigo"].ToString());
					g[i].Descricao = dr["descricao"].ToString();
					g[i].Quantidade = double.Parse(dr["quantidade"].ToString());
					g[i].Valor = double.Parse(dr["valor"].ToString());
				}

				grupos = g;

				return g.Length;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				grupos = null;

				return -1;
			}
		}

		public List<Produto> ProdutosMeioAMeio()
		{
			try
			{
				List<Produto> produtos = new List<Produto>();

				NpgsqlCommand com = new NpgsqlCommand("select cad_produtos.codigo, cad_produtos.nome, cad_produtos.descricao from cad_produtos " +
					"left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) " +
					"where produtos_tipos.meio = true order by cad_produtos.codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					Produto produto = new Produto();

					produto.Codigo = Convert.ToInt64(dr["codigo"]);
					produto.Nome = dr["nome"].ToString();
					produto.Descricao = dr["descricao"].ToString();

					produtos.Add(produto);
				}

				return produtos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show("Erro ao carregar os produtos. " + e.Message, "DSoft BD");
				return null;
			}
		}

		public bool ProdutosPeriodo(DataSet ds, DateTime inicial, DateTime final)
		{
			try
			{
				string consulta = "select * from (select cad_produtos.codigo as produto, " +
									"cad_produtos.nome as nome, " +
									"(select sum(fracao) from pedidos_itens " +
									"where pedidos_itens.produto = cad_produtos.codigo " +
									"and pedidos_itens.pedido in (select indice from pedidos " +
									"where situacao <> 'C' and data between " +
									"to_date('" + inicial.ToString("ddMMyyyy") + "', 'DDMMYYYY') and " +
									"to_date('" + final.ToString("ddMMyyyy") + "', 'DDMMYYYY')))::double precision as quantidade " +
									"from cad_produtos where cad_produtos.situacao = 'A' order by cad_produtos.codigo) as a where quantidade is not null";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(consulta, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ProdutosPeriodo(DataSet ds, DateTime inicial, DateTime hrinicial, DateTime final, DateTime hrfinal, ProdutoTipo tipo)
		{
			try
			{
				string condicao = string.Empty;

				if (tipo != null)
				{
					condicao = string.Format(" and cad_produtos.tipo = {0} ", tipo.Codigo);
				}

				string comando = string.Format("select * from (select cad_produtos.codigo as produto, " +
															"cad_produtos.nome as nome, " +
															"(select sum(fracao) from pedidos_itens " +
															"where pedidos_itens.produto = cad_produtos.codigo " +
															"and pedidos_itens.pedido in (select indice from pedidos " +
															"where situacao <> 'C' and data between " +
															"to_date('{0}', 'DDMMYYYY') and to_date('{1}', 'DDMMYYYY') and hora between " +
															"to_timestamp('{2}', 'HH24MISS')::time without time zone and to_timestamp('{3}', 'HH24MISS')::time without time zone " +
															"))::double precision as quantidade, " +
															"(select sum(preco) from pedidos_itens " +
															"where pedidos_itens.produto = cad_produtos.codigo " +
															"and pedidos_itens.pedido in (select indice from pedidos " +
															"where situacao <> 'C' and data between " +
															"to_date('{0}', 'DDMMYYYY') and " +
															"to_date('{1}', 'DDMMYYYY') and hora between " +
															"to_timestamp('{2}', 'HH24MISS')::time without time zone and to_timestamp('{3}', 'HH24MISS')::time without time zone " +
															")) as preco " +
															"from cad_produtos where cad_produtos.situacao = 'A' {4} order by cad_produtos.codigo) as a where quantidade is not null"
															, inicial.ToString("ddMMyyyy"), final.ToString("ddMMyyyy"), hrinicial.ToString("HHmmss"), hrfinal.ToString("HHmmss"), condicao);

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando, Conn);

				da.Fill(ds);

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public Task<DataTable> ProdutosPeriodoAsync(DateTime inicial, DateTime final)
		{
			return Task.Factory.StartNew<DataTable>(() =>
			{
				DataSet ds = new DataSet();
				ProdutosPeriodo(ds, inicial, final);
				return ds.Tables[0];
			});
		}

		public void ProdutosPrecos(int tabela, DataSet ds)
		{
			try
			{
				string sql = "select cad_produtos.codigo, " +
								"cad_produtos.nome, " +
								"cad_produtos.descricao, " +
								"produtos_precos.preco, " +
								"produtos_precos.locacao, " +
								"produtos_precos.tributavel, " +
								"cad_produtos.situacao, " +
								"cad_produtos.tipo " +
								"from cad_produtos " +
								"inner join produtos_precos on (cad_produtos.codigo = produtos_precos.produto) " +
								"where produtos_precos.tabela = " + tabela.ToString() + " " +
								"order by cad_produtos.codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public int ProdutoTipo(long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select tipo from cad_produtos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", produto));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		/// <summary>
		/// Dado o código do tipo do produto, retorna qual a impressora externa o produto deve ser impresso.
		/// </summary>
		/// <param name="tipo_produto">Código do tipo do produto</param>
		/// <returns>Código da impressora externa, sendo que 0 significa que não deve ser impresso em uma impressora externa</returns>
		public int ProdutoTipoImpressoraExterna(int tipo_produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select impressora_externa from produtos_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", tipo_produto));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public string ProdutoTipoNome(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from produtos_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool ProdutoTipoProducao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select producao from produtos_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ProdutoTipoImprimeProducao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select imprime_total from produtos_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ProdutoTipoLocacao(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select permite_locacao from produtos_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public long ProximoCodigoCliente()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_prox_cliente();", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return long.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool ReativarCliente(long cliente)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_cliente(:cliente, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("cliente", cliente));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarDespesa(int despesa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_despesa(:usuario, :despesa)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("despesa", despesa));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarEmitente(string cnpj)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_emitente(:cnpj);");

				com.Parameters.Add(new NpgsqlParameter("cnpj", Convert.ToInt64(cnpj)));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarGrupoClientes(int codigo, string nome)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_grupo_clientes(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public bool ReativarGrupoTributario(GrupoTributario grupo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_grupo_tributario(:codigo, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", grupo.Codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (bool.Parse(dr[0].ToString()))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarLocal(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_local(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarMaterial(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_material(:codigo)", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarPedido(int pedido)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_pedido(:pedido, :usuario);");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarProduto(long codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_produto(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarRecurso(int recurso, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_recurso(:recurso, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(dr[0].ToString(), "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarTabela(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_tabela(:codigo, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarUsuario(int codigo)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_usuario(:codigo)");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ReativarVeiculo(string placa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_reativa_veiculo(:placa);");

				com.Parameters.Add(new NpgsqlParameter("placa", placa));

				return getBool(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool RecalcularSaldosClientes()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_clientes set saldo = cliente_saldo_real(codigo);");
				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public Task<bool> RecalcularSaldosClientesAsync()
		{
			return Task.Factory.StartNew<bool>(() =>
			{
				return RecalcularSaldosClientes();
			});
		}

		public void RecalculaTotalPedido(int pedido)
		{
			NpgsqlCommand com = new NpgsqlCommand("select dsoft_recalcula_total_pedido(:pedido)", Conn);
			com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
			ExecCommand(com);
		}

		public bool RecursoAtivo(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select situacao from cad_recursos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				if (dr[0].ToString() == "A")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public int RecursoCodigo(string nome)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_recursos where nome = :nome", Conn);

				com.Parameters.Add(new NpgsqlParameter("nome", nome));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return int.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public string RecursoCPF(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select cpf from cad_recursos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public string RecursoNome(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_recursos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool RecursosTipos(out string[] tipos)
		{
			try
			{
				int indice = 0;

				NpgsqlCommand com = new NpgsqlCommand("select count(codigo) from recursos_tipos", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				indice = int.Parse(dr[0].ToString());

				if (indice < 1)
				{
					tipos = null;

					return false;
				}

				tipos = new string[indice];

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select codigo, descricao from recursos_tipos", Conn);

				dr = com.ExecuteReader();

				indice = 0;

				while (dr.Read())
				{
					tipos[indice++] = dr[0].ToString() + " - " + dr[1].ToString();
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				tipos = null;

				return false;
			}
		}

		public void RecursosTipos(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, " +
																	"descricao, " +
																	"entrega, " +
																	"producao, " +
																	"comissao_diaria, " +
																	"comissao_nominal, " +
																	"fixo_semanal, " +
																	"fixo_mensal, " +
																	"valor_entrega, " +
																	"diaria " +
																	"from recursos_tipos order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);
			}
		}

		public string RecursoTipoDescricao(char codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao from recursos_tipos where codigo = :codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo.ToString()));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return string.Empty;
				}

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public bool RetornaPedido(int pedido, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_retorna_pedido(:pedido, :usuario)");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool RetornarCompra(int compra)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_retorna_compra(:usuario, :compra)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));
				com.Parameters.Add(new NpgsqlParameter("compra", compra));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool RetornarManifesto(int manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_retorna_manifesto(:indice, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", manifesto));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool SaidaManifesto(int manifesto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_saida_manifesto(:indice, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", manifesto));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool SaidaPedido(int pedido, int recurso, int usuario)
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_saida_pedido(:pedido, :usuario, :recurso)");

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("recurso", recurso));

				if ((msg = getString(com)) == "OK")
				{
					return true;
				}
				else
				{
					MessageBox.Show(msg, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public double SaidasPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'S' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		/// <summary>
		/// Salva um nível de usuário no banco-de-dados, novo ou uma alteração
		/// </summary>
		/// <param name="nivel">Nível de usuário completamente preenchido</param>
		/// <param name="usuario">Usuário que está aplicando as alterações</param>
		/// <returns>True no caso de salvamento efetuado, False caso não possa salvar por algum motivo</returns>
		public bool SalvarNivelUsuario(NivelUsuario nivel, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(nivel) from usuario_niveis where nivel = :nivel", Conn);
			com.Parameters.Add(new NpgsqlParameter("nivel", nivel.Nivel));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (!dr.Read() || Convert.ToInt32(dr[0].ToString()) < 1)
			{
				com = new NpgsqlCommand("insert into usuario_niveis (nivel, " +
																	"nome, " +
																	"administrador, " +
																	"lancar_pedidos, " +
																	"alterar_pedidos, " +
																	"cancelar_pedidos, " +
																	"caixa, " +
																	"controle_financeiro, " +
																	"entregas, " +
																	"relatorios, " +
																	"cadastrar_produtos, " +
																	"alterar_precos, " +
																	"compras, " +
																	"cadastrar_recursos, " +
																	"cadastrar_usuarios, " +
																	"alterar_estoque, " +
																	"script_bd, " +
																	"preferencias, " +
																	"terminal, " +
																	"cadastrar_grupos_de_clientes, " +
																	"escritorio," +
																	"almoxarifado, " +
																	"regras_negocio) values (:nivel, " +
																	":nome, " +
																	":administrador, " +
																	":lancar_pedidos, " +
																	":alterar_pedidos, " +
																	":cancelar_pedidos, " +
																	":caixa, " +
																	":controle_financeiro, " +
																	":entregas, " +
																	":relatorios, " +
																	":cadastrar_produtos, " +
																	":alterar_precos, " +
																	":compras, " +
																	":cadastrar_recursos, " +
																	":cadastrar_usuarios, " +
																	":alterar_estoque, " +
																	":script_bd, " +
																	":preferencias, " +
																	":terminal, " +
																	":cadastrar_grupos_de_clientes, " +
																	":escritorio, " +
																	":almoxarifado, " +
																	":regras_negocio)", Conn);
			}
			else
			{
				com = new NpgsqlCommand("update usuario_niveis set nome = :nome, " +
																	"administrador = :administrador, " +
																	"lancar_pedidos = :lancar_pedidos, " +
																	"alterar_pedidos = :alterar_pedidos, " +
																	"alterar_cliente_pedido = :alterar_cliente_pedido, " +
																	"cancelar_pedidos = :cancelar_pedidos, " +
																	"caixa = :caixa, " +
																	"controle_financeiro = :controle_financeiro, " +
																	"entregas = :entregas, " +
																	"relatorios = :relatorios, " +
																	"cadastrar_produtos = :cadastrar_produtos, " +
																	"alterar_precos = :alterar_precos, " +
																	"compras = :compras, " +
																	"cadastrar_recursos = :cadastrar_recursos, " +
																	"cadastrar_usuarios = :cadastrar_usuarios, " +
																	"alterar_estoque = :alterar_estoque, " +
																	"script_bd = :script_bd, " +
																	"preferencias = :preferencias, " +
																	"terminal = :terminal, " +
																	"cadastrar_grupos_de_clientes = :cadastrar_grupos_de_clientes, " +
																	"escritorio = :escritorio, " +
																	"almoxarifado = :almoxarifado, " +
																	"regras_negocio = :regras_negocio where nivel = :nivel", Conn);
			}

			com.Parameters.Add(new NpgsqlParameter("nivel", nivel.Nivel));
			com.Parameters.Add(new NpgsqlParameter("nome", nivel.Nome));
			com.Parameters.Add(new NpgsqlParameter("administrador", nivel.Administrador));
			com.Parameters.Add(new NpgsqlParameter("lancar_pedidos", nivel.LancarPedidos));
			com.Parameters.Add(new NpgsqlParameter("alterar_pedidos", nivel.AlterarPedidos));
			com.Parameters.Add(new NpgsqlParameter("alterar_cliente_pedido", nivel.AlterarClienteDoPedido));
			com.Parameters.Add(new NpgsqlParameter("cancelar_pedidos", nivel.CancelarPedidos));
			com.Parameters.Add(new NpgsqlParameter("caixa", nivel.Caixa));
			com.Parameters.Add(new NpgsqlParameter("controle_financeiro", nivel.ControleFinanceiro));
			com.Parameters.Add(new NpgsqlParameter("entregas", nivel.Entregas));
			com.Parameters.Add(new NpgsqlParameter("relatorios", nivel.Relatorios));
			com.Parameters.Add(new NpgsqlParameter("cadastrar_produtos", nivel.CadastrarProdutos));
			com.Parameters.Add(new NpgsqlParameter("alterar_precos", nivel.AlterarPrecos));
			com.Parameters.Add(new NpgsqlParameter("compras", nivel.Compras));
			com.Parameters.Add(new NpgsqlParameter("cadastrar_recursos", nivel.CadastrarRecursos));
			com.Parameters.Add(new NpgsqlParameter("cadastrar_usuarios", nivel.CadastrarUsuarios));
			com.Parameters.Add(new NpgsqlParameter("alterar_estoque", nivel.AlterarEstoque));
			com.Parameters.Add(new NpgsqlParameter("script_bd", nivel.ScriptBd));
			com.Parameters.Add(new NpgsqlParameter("preferencias", nivel.Preferencias));
			com.Parameters.Add(new NpgsqlParameter("terminal", nivel.Terminal));
			com.Parameters.Add(new NpgsqlParameter("cadastrar_grupos_de_clientes", nivel.CadastrarGruposDeClientes));
			com.Parameters.Add(new NpgsqlParameter("escritorio", nivel.Escritorio));
			com.Parameters.Add(new NpgsqlParameter("almoxarifado", nivel.Almoxarifado));
			com.Parameters.Add(new NpgsqlParameter("regras_negocio", nivel.RegrasDeNegocio));

			return ExecCommand(com);
		}

		public void SalvarRegrasDeNegocios(string chave)
		{
			switch (chave)
			{
				case "aviso_estoque":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.AvisoEstoque.ToString());
					break;

				case "bloqueia_cliente_anonimo":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.BloqueiaClienteAnonimo.ToString());
					break;

				case "bloqueia_estoque":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.BloqueiaEstoque.ToString());
					break;

				case "controla_entregas":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ControlaEntregas.ToString());
					break;

				case "controla_processos":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ControlaProcessos.ToString());
					break;

				case "emite_cupom_fiscal":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.EmiteCupomFiscal.ToString());
					break;

				case "fecha_caixa_automaticamente":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.FechaCaixaAutomaticamente.ToString());
					break;

				case "ordem_coleta_vias":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.OrdemDeColetaVias.ToString());
					break;

				case "ramo":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.Ramo.ToString());
					break;

				case "registra_vendedor":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.RegistraVendedor.ToString());
					break;

				case "taxa_entrega_grupo":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.TaxaEntregaPorGrupo.ToString());
					break;

				case "entrega_automatica_cliente_interno_pagamento":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.EntregaAutomaticaClientesInternosPagamento.ToString());
					break;

				case "termo_de_responsabilidade":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.TermoDeResponsabilidade);
					break;

				case "recibo_de_devolucao":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ReciboDeDevolucao);
					break;

				case "aviso_atraso":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.AvisoAtraso.ToString());
					break;

				case "segundos_alerta":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.SegundosAlerta.ToString());
					break;

				case "produto_fracionado_preco_medio":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio.ToString());
					break;

				case "busca_endereco_por_cep":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.BuscaEnderecoPorCep.ToString());
					break;

				case "gerencia_disponibilidade_de_entregadores":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores.ToString());
					break;

				case "controla_por_comandas":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ControlaPedidosPorComanda.ToString());
					break;

				case "baixa_pedidos_fechamento_diario":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.BaixaPedidosNoFechamentoDiario.ToString());
					break;

				case "itens_adicionais_por_produto":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ItensAdicionaisPorProduto.ToString());
					break;

				case "itens_adicionais_por_tipo_de_produto":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto.ToString());
					break;

				case "modelo_impressao":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ModeloImpressao);
					break;

				case "imprimir_linha_entre_itens":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ImprimirLinhaEntreItens.ToString());
					break;

				case "agrupa_produtos_por_tipo":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.AgrupaProdutosPorTipo.ToString());
					break;

				case "imprimir_usuario_na_comanda":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda.ToString());
					break;

				case "imprimir_vendedor_na_comanda":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ImprimirVendedorNaComanda.ToString());
					break;

				case "observacao_obrigatoria_no_pedido":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.ObservacaoObrigatoriaNoPedido.ToString());
					break;

				case "taxa_de_entrega_por_cliente":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente.ToString());
					break;

				case "motivo_obrigatorio_no_cancelamento":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento.ToString());
					break;

				case "pagamento_no_lancamento":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.PagamentoNoLancamento.ToString());
					break;

				case "duas_vias_no_balcao":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.DuasViasNoBalcao.ToString());
					break;

				case "pagamento_automatico_de_entregadores":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores.ToString());
					break;

				case "precos_em_aberto":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.PrecosEmAberto.ToString());
					break;

				case "permite_fechamento_com_pedidos_em_aberto":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.PermiteFechamentoComPedidosEmAberto.ToString());
					break;

				case "taxa_paga_por_entrega":
					InsertOrUpdate("regras_negocios", chave, RegrasDeNegocio.Instance.TaxaPagaPorEntrega.ToString());
					break;
			}
		}

		public string ScriptExecute(string script, int usuario, out DataTable result)
		{
			string message;

			try
			{
				NpgsqlCommand com = new NpgsqlCommand(script, Conn);

				int affected = com.ExecuteNonQuery();

				message = string.Format("Sucesso. {0} registros afetados.", affected);
			}
			catch (Exception e)
			{
				message = e.Message;
			}

			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(script, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				if (ds != null && ds.Tables.Count > 0)
				{
					result = ds.Tables[0];
				}
				else
				{
					result = null;
				}
			}
			catch (Exception)
			{
				result = null;
			}

			return message;
		}

		public bool SincronizarProduto(Produto produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_sincroniza_produto(:codigo, :nome, :situacao, :descricao, :grupo, :tipo, :gtrib, :medida, :producao);", Conn);

				com.Parameters.Add(new NpgsqlParameter("codigo", produto.Codigo));
				com.Parameters.Add(new NpgsqlParameter("nome", produto.Nome));
				com.Parameters.Add(new NpgsqlParameter("situacao", produto.Situacao.ToString()));
				com.Parameters.Add(new NpgsqlParameter("descricao", produto.Descricao));
				com.Parameters.Add(new NpgsqlParameter("grupo", produto.Grupo));
				com.Parameters.Add(new NpgsqlParameter("tipo", produto.Tipo));
				com.Parameters.Add(new NpgsqlParameter("gtrib", produto.GrupoTributario));
				com.Parameters.Add(new NpgsqlParameter("medida", produto.Medida));
				com.Parameters.Add(new NpgsqlParameter("producao", produto.Producao));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool SincronizeFunctions()
		{
			try
			{
				string functions = File.ReadAllText("Functions.sql");

				if (functions != null)
				{
					NpgsqlCommand com = new NpgsqlCommand(functions, Conn);

					com.ExecuteNonQuery();

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public void ApplyPatches()
		{
			try
			{
				PatchesManager patches = new PatchesManager();

				NpgsqlCommand com = new NpgsqlCommand("select numero from patches order by numero desc limit 1");

				int ultimo_patch = getInt(com);

				foreach (var p in patches.Patches())
				{
					if (p.Key > ultimo_patch)
					{
						com = new NpgsqlCommand(p.Value);
						ExecCommand(com);

						com = new NpgsqlCommand("insert into patches (numero) values (" + p.Key + ")");
						ExecCommand(com);
					}
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void TabelasPrecos(DataSet ds)
		{
			try
			{
				string sql = "select codigo, nome, descricao, situacao from cad_tabelas order by codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public decimal TaxaEntregaGrupoClientes(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select taxa_entrega from clientes_grupos where codigo = " + codigo);

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return 0;
			}
		}

		public decimal TaxaDeServicoGrupoClientes(int grupo)
		{
			return getDecimal(string.Format("select taxa_servico from clientes_grupos where codigo = {0}", grupo));
		}

		public bool TipoClienteExiste(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select count(nome) from clientes_tipos where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getInt(com) > 0;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);

				return false;
			}
		}

		public void TiposClientes(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, situacao, cliente_interno, mensalidade from clientes_tipos order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message);
			}
		}

		public void TiposMateriais(DataSet ds)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome, descricao from materiais_tipos order by codigo", Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void TiposProdutos(DataSet ds)
		{
			try
			{
				string sql = "select codigo, nome, descricao, producao, estoque, soma, situacao, impressora_externa, adicionais, meio, fracao, imprime_total, " +
					"permite_locacao, intervalo_locacao, periodo_locacao from produtos_tipos order by codigo";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public bool TransferenciaCaixa(FluxoDeCaixa transferencia, int caixa, int usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_transferencia(:usuario, " +
																				":caixa, " +
																				":valor, " +
																				":destino, " +
																				":observacao)", Conn);

				com.Parameters.Add(new NpgsqlParameter("usuario", usuario));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("valor", transferencia.Valor));
				com.Parameters.Add(new NpgsqlParameter("destino", transferencia.Caixa));
				com.Parameters.Add(new NpgsqlParameter("observacao", transferencia.Observacao));

				NpgsqlDataReader dr = com.ExecuteReader();

				if (!dr.Read())
				{
					return false;
				}

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public double TransferenciasPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'T' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool TransmitirOrdemTransporte(OrdemDeColeta ordem)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_transmite_ordem_transporte(:indice, :cte, :usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("indice", ordem.Indice));
				com.Parameters.Add(new NpgsqlParameter("cte", ordem.CTe));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool UltimoCupomFiscal(int pedido, int loja, int caixa, long cupom)
		{
			try
			{
				int i;

				NpgsqlCommand com = new NpgsqlCommand("select indice from pedidos where indice > :pedido and loja = :loja and caixa = :caixa and cupom = :cupom limit 1", Conn);

				com.Parameters.Add(new NpgsqlParameter("pedido", pedido));
				com.Parameters.Add(new NpgsqlParameter("loja", loja));
				com.Parameters.Add(new NpgsqlParameter("caixa", caixa));
				com.Parameters.Add(new NpgsqlParameter("cupom", cupom));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (int.TryParse(dr[0].ToString(), out i))
					return true;
				else
					return false;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		/// <summary>
		/// Verifica se o usuário informado está cadastrado no sistema e retorna o nível do usuário.
		/// Caso o usuário não exista ou a senha não seja correta, retorna '0'
		/// </summary>
		/// <param name="usuario">Código do usuário</param>
		/// <param name="senha">Senha do usuário</param>
		/// <returns>Nível do usuário, ou '0' caso não exista</returns>
		public char UsuarioCadastrado(int usuario, string senha, string nova = "")
		{
			try
			{
				string msg;

				NpgsqlCommand com = new NpgsqlCommand("select nivel from cad_usuarios where codigo = :codigo and senha = :senha");

				com.Parameters.Add(new NpgsqlParameter("codigo", usuario));
				com.Parameters.Add(new NpgsqlParameter("senha", senha));

				msg = getString(com);

				if (msg.Length > 0 && msg[0] != '0' && nova != "")
				{
					com = new NpgsqlCommand("update cad_usuarios set senha = :nova where codigo = :codigo", Conn);

					com.Parameters.Add(new NpgsqlParameter("nova", nova));
					com.Parameters.Add(new NpgsqlParameter("codigo", usuario));

					com.ExecuteNonQuery();
				}

				if (msg.Length > 0)
					return msg[0];

				return '0';
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return '0';
			}
		}

		public bool UsuarioCadastrado(int codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(codigo) from cad_usuarios where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			return getInt(com) > 0;
		}

		public string UsuarioNome(int codigo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome from cad_usuarios where codigo = :codigo");

				com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

				return getString(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public int UsuarioCodigo(string nome)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_usuarios where nome = :nome limit 1");

				com.Parameters.Add(new NpgsqlParameter("nome", nome));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return 0;
			}
		}

		public void UsuariosCadastrados(DataSet ds)
		{
			try
			{
				string sql = "select codigo, nome, nivel, situacao from cad_usuarios";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public int UsuariosCadastrados()
		{
			return getInt("select count(codigo) from cad_usuarios");
		}

		public void UsuariosNiveis(DataSet ds)
		{
			try
			{
				string sql = "select * from usuario_niveis";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, Conn);

				da.Fill(ds);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public double ValesPeriodo(DateTime de, DateTime ate)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where tipo = 'V' and data between " +
					":de and :ate and situacao <> 'C'");

				com.Parameters.Add(new NpgsqlParameter("de", de.Date));
				com.Parameters.Add(new NpgsqlParameter("ate", ate.Date));

				return getDouble(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return -1;
			}
		}

		public bool VeiculoAtivo(string placa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select situacao from cad_veiculos where placa = :placa;", Conn);

				com.Parameters.Add(new NpgsqlParameter("placa", placa));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				if (dr[0].ToString() == "A")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public string VeiculoRENAVAM(string placa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select renavam from cad_veiculos where placa = :placa;", Conn);

				com.Parameters.Add(new NpgsqlParameter("placa", placa));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return dr[0].ToString();
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return "";
			}
		}

		public double VendasPeriodo(DateTime de, DateTime ate, out double dinheiro, out double cartao, out double cheques, out double debito, out double crediario, int usuario)
		{
			try
			{
				double total = 0;

				NpgsqlCommand com = new NpgsqlCommand();

				com.CommandText = "select sum(valor) from pagamentos where pedido in " +
					"(select indice from pedidos where data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "' and situacao <> 'C') " +
					"and tipo = 'D'";

				dinheiro = getDouble(com);
				total += dinheiro;

				com.CommandText = "select sum(valor) from pagamentos where pedido in " +
					"(select indice from pedidos where data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "' and situacao <> 'C') " +
					"and tipo = 'X'";

				cheques = getDouble(com);
				total += cheques;

				com.CommandText = "select sum(valor) from pagamentos where pedido in " +
					"(select indice from pedidos where data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "' and situacao <> 'C') " +
					"and tipo = 'C'";

				cartao = getDouble(com);
				total += cartao;

				com.CommandText = "select sum(valor) from pagamentos where pedido in " +
					"(select indice from pedidos where data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "' and situacao <> 'C') " +
					"and tipo = 'A'";

				debito = getDouble(com);
				total += debito;

				com.CommandText = "select sum(valor) from pagamentos where pedido in " +
					"(select indice from pedidos where data between '" + de.ToString("yyyy-MM-dd") + "' and '" + ate.ToString("yyyy-MM-dd") + "' and situacao <> 'C') " +
					"and tipo = 'P'";

				crediario = getDouble(com);
				total += crediario;

				return total;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				dinheiro = 0;
				cartao = 0;
				cheques = 0;
				debito = 0;
				crediario = 0;

				return 0;
			}
		}

		public Task<bool> VerificarBD()
		{
			return Task.Factory.StartNew<bool>(() =>
			{
				string versao = "";

				NpgsqlCommand com = new NpgsqlCommand("select dsoft_versao();", Conn);

				try
				{
					NpgsqlDataReader dr = com.ExecuteReader();
					dr.Read();
					versao = dr[0].ToString();
				}
				catch (Exception e)
				{
					string funcao = "CREATE OR REPLACE FUNCTION dsoft_versao() RETURNS character varying AS " +
									"$BODY$ " +
									"begin" +
									"	return '1.2';" +
									"end;" +
									"$BODY$" +
									"  LANGUAGE plpgsql VOLATILE";

					NpgsqlCommand com2 = new NpgsqlCommand(funcao, Conn);
					com2.ExecuteNonQuery();

					versao = VERSAO_BD;
				}

				if (versao != VERSAO_BD)
				{
					SincronizeFunctions();
				}

				ApplyPatches();

				return true;
			});
		}

		public string Versao()
		{
			return getString(new NpgsqlCommand("select dsoft_versao();"));
		}

		public bool VincularConhecimentoManifesto(int conhecimento, int manifesto, DateTime data)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_vincula_conhecimento_manifesto(:conhecimento, " +
																									":manifesto, " +
																									":data, " +
																									":usuario);", Conn);

				com.Parameters.Add(new NpgsqlParameter("conhecimento", conhecimento));
				com.Parameters.Add(new NpgsqlParameter("manifesto", manifesto));
				com.Parameters.Add(new NpgsqlParameter("data", data));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool VincularMaterial(int produto, int material, float quantidade)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_vincula_produto_material(:produto, :material, :qtd, :usuario)", Conn);

				com.Parameters.Add(new NpgsqlParameter("produto", produto));
				com.Parameters.Add(new NpgsqlParameter("material", material));
				com.Parameters.Add(new NpgsqlParameter("qtd", quantidade));
				com.Parameters.Add(new NpgsqlParameter("usuario", _usuario));

				NpgsqlDataReader dr = com.ExecuteReader();

				dr.Read();

				return bool.Parse(dr[0].ToString());
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		private void GiveAccess()
		{
			// The folder for the roaming current user 
			string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			// Combine the base folder with your specific folder....
			string specificFolder = Path.Combine(folder, "postgresql");

			// Check if folder exists and if not, create it
			if (!Directory.Exists(specificFolder))
				Directory.CreateDirectory(specificFolder);

			StreamWriter sw = File.CreateText(Path.Combine(specificFolder, "pgpass.conf"));
			sw.Write("localhost:5432:*:postgres:dsoft2008");
			sw.Flush();
			sw.Close();
		}

		private void RevogeAccess()
		{
			// The folder for the roaming current user 
			string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			// Combine the base folder with your specific folder....
			string specificFolder = Path.Combine(folder, "postgresql");

			string file = Path.Combine(specificFolder, "pgpass.conf");

			File.Delete(file);
		}

		private bool CriarBD()
		{
			try
			{
				string folder = string.Empty;

				if (Terminal.ProcessadorPostgreSql == "x86")
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
				}
				else
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				}

				folder = Path.Combine(folder, "Postgresql");
				folder = Path.Combine(folder, Terminal.VersaoPostgreSql);
				folder = Path.Combine(folder, "bin");

				string comando = Path.Combine(folder, "psql.exe");

				string argumentos = " -U postgres -w -q -c \"CREATE DATABASE " + Banco +
														" WITH ENCODING='WIN1252' " +
														"OWNER=dsoft " +
														"TEMPLATE=template0 " +
														"CONNECTION LIMIT=-1;\"";

				Logger.Instance.Log(string.Format("Criando novo banco-de-dados...\n{0}\n{1}", comando, argumentos), 1);

				//string saida;
				System.Diagnostics.Process processo = new System.Diagnostics.Process();

				processo.StartInfo.FileName = comando;
				processo.StartInfo.Arguments = argumentos;

				if (processo.Start())
				{
					//frmMain.Backupeando = true;

					while (!processo.HasExited)
					{
						//frmMain.ProgredirBarraPasso();

						System.Threading.Thread.Sleep(500);
					}

					//frmMain.Backupeando = false;

					return true;
				}
				else
				{
					MessageBox.Show("Não foi possivel criar o banco-de-dados!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao criar o banco-de-dados! Se o problema persistir, entre em contato com o suporte." + Environment.NewLine + e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		private bool CriarUsuario()
		{
			try
			{
				string folder = string.Empty;

				if (Terminal.ProcessadorPostgreSql == "x86")
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
				}
				else
				{
					folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				}

				folder = Path.Combine(folder, "Postgresql");
				folder = Path.Combine(folder, Terminal.VersaoPostgreSql);
				folder = Path.Combine(folder, "bin");

				string comando = Path.Combine(folder, "psql.exe");

				string argumentos = " -U postgres -w -q -c \"CREATE USER dsoft WITH PASSWORD 'dsoft2008' SUPERUSER CREATEDB\"";

				Logger.Instance.Log(string.Format("Criando novo usuário no banco-de-dados...\n{0}\n{1}", comando, argumentos), 1);

				//string saida;
				System.Diagnostics.Process processo = new System.Diagnostics.Process();

				processo.StartInfo.FileName = comando;
				processo.StartInfo.Arguments = argumentos;

				if (processo.Start())
				{
					//frmMain.Backupeando = true;

					while (!processo.HasExited)
					{
						//frmMain.ProgredirBarraPasso();

						System.Threading.Thread.Sleep(500);
					}

					//frmMain.Backupeando = false;

					return true;
				}
				else
				{
					MessageBox.Show("Não foi possivel criar o usuário!", "DSoftBD", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return false;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);

				MessageBox.Show("Erro ao criar o usuário! Se o problema persistir, entre em contato com o suporte." + Environment.NewLine + e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool IncluirLocacao(Locacao locacao, Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into locacao (cliente, inicio_data, inicio_hora, previsao_data, previsao_hora, usuario_inicio, valor_previsto, observacao, tabela) " +
					"values (:cliente, :inicio_data, :inicio_hora, :previsao_data, :previsao_hora, :usuario_inicio, :valor_previsto, :observacao, :tabela) returning indice;");

				com.Parameters.Add(new NpgsqlParameter("cliente", locacao.Cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("inicio_data", locacao.InicioData.Date));
				com.Parameters.Add(new NpgsqlParameter("inicio_hora", locacao.InicioHora));
				com.Parameters.Add(new NpgsqlParameter("previsao_data", locacao.PrevisaoData.Date));
				com.Parameters.Add(new NpgsqlParameter("previsao_hora", locacao.PrevisaoHora));
				com.Parameters.Add(new NpgsqlParameter("usuario_inicio", locacao.UsuarioInicio.Autorizado));
				com.Parameters.Add(new NpgsqlParameter("valor_previsto", locacao.ValorPrevisto));
				com.Parameters.Add(new NpgsqlParameter("observacao", locacao.Observacao));
				com.Parameters.Add(new NpgsqlParameter("tabela", locacao.Tabela.Codigo));

				int indice;

				if ((indice = getInt(com)) > 0)
				{
					com = new NpgsqlCommand("insert into locacao_itens (locacao, produto, quantidade, observacao) " +
						"values (:locacao, :produto, :quantidade, :observacao)");

					com.Parameters.Add(new NpgsqlParameter("locacao", indice));
					com.Parameters.Add(new NpgsqlParameter("produto", locacao.Produtos[0].Codigo));
					com.Parameters.Add(new NpgsqlParameter("quantidade", 1));
					com.Parameters.Add(new NpgsqlParameter("observacao", ""));

					ExecCommand(com);
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, usuario.Autorizado);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public DataTable Locacoes()
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select indice, cliente, inicio_data, inicio_hora, previsao_data, previsao_hora, valor_previsto, " +
					"devolucao_data, devolucao_hora, valor_real, usuario_inicio, usuario_recepcao, observacao, tabela, situacao from locacao order by indice", Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public decimal ValorLocacao(Produto produto, TabelaDePrecos tabela)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select locacao from produtos_precos where tabela = :tabela and produto = :produto");
				com.Parameters.Add(new NpgsqlParameter("tabela", tabela.Codigo));
				com.Parameters.Add(new NpgsqlParameter("produto", produto.Codigo));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public int IntervaloLocacao(Produto produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select produtos_tipos.periodo_locacao from cad_produtos left join produtos_tipos on(cad_produtos.tipo = produtos_tipos.codigo) " +
					"where cad_produtos.codigo = :produto;");

				com.Parameters.Add(new NpgsqlParameter("produto", produto.Codigo));

				return getInt(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public List<Produto> LocacaoItens(int locacao)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select produto, quantidade, situacao, observacao from locacao_itens where locacao = :locacao order by indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("locacao", locacao));

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Produto> produtos = new List<Produto>();

				while (dr.Read())
				{
					Produto prod = new Produto();
					prod = CarregarProduto(Convert.ToInt64(dr["produto"]));
					produtos.Add(prod);
				}

				return produtos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public bool CancelarLocacao(Locacao locacao, Usuario usuario, string motivo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update locacao set situacao = 'C', cancela_data = now(), cancela_hora = now(), cancela_usuario = :usuario, cancela_motivo = :motivo where indice = :indice");
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("motivo", motivo));
				com.Parameters.Add(new NpgsqlParameter("indice", locacao.Indice));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool ReceberLocacao(Locacao locacao, Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update locacao set situacao = 'P', devolucao_data = :devolucao_data, devolucao_hora = :devolucao_hora, " +
					"usuario_recepcao = :usuario, valor_real = :valor, observacao_recepcao = :observacao where indice = :indice");

				com.Parameters.Add(new NpgsqlParameter("devolucao_data", locacao.DevolucaoData));
				com.Parameters.Add(new NpgsqlParameter("devolucao_hora", locacao.DevolucaoHora));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("valor", locacao.Valor));
				com.Parameters.Add(new NpgsqlParameter("observacao", locacao.ObservacaoRecepcao));
				com.Parameters.Add(new NpgsqlParameter("indice", locacao.Indice));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public DataTable LocacoesPorUsuario(Usuario usuario, DateTime inicio, DateTime final)
		{
			try
			{
				DataSet ds = new DataSet();

				string consulta = "select count(indice) as quantidade, sum(valor_real) as valor from locacoes where usuario_inicio = {0} "
					+ "inicio_data = {1} and situacao <> 'C'";

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(consulta, Conn);
				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public string ProximoSentidoPonto(Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sentido from pontos where usuario = :usuario order by indice desc limit 1");
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

				string ultimo = getString(com);

				if (ultimo == "ENTRADA")
				{
					return "SAÍDA";
				}
				else
				{
					return "ENTRADA";
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "ENTRADA";
			}
		}

		public bool MarcarPonto(Usuario usuario, string sentido, DateTime data, DateTime hora)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("insert into pontos(data, hora, usuario, sentido) values(:data, :hora, :usuario, :sentido)");
				com.Parameters.Add(new NpgsqlParameter("data", data));
				com.Parameters.Add(new NpgsqlParameter("hora", hora));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("sentido", sentido));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public List<LocacaoEspecial> LocacaoEspecial(int produto_tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select descricao, periodo from locacao_especial where produto_tipo = :produto_tipo order by periodo", Conn);
				com.Parameters.Add(new NpgsqlParameter("produto_tipo", produto_tipo));
				NpgsqlDataReader dr = com.ExecuteReader();

				List<LocacaoEspecial> especiais = new List<LocacaoEspecial>();

				while (dr.Read())
				{
					LocacaoEspecial l = new LocacaoEspecial();
					l.Descricao = dr["descricao"].ToString();
					l.Periodo = Convert.ToInt32(dr["periodo"]);

					especiais.Add(l);
				}

				return especiais;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<LocacaoEspecialPreco> CarregarLocacoesEspeciaisPrecos(int tabela, long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select locacao_especial.descricao, locacao_especial_precos.preco, locacao_especial_precos.indice, locacao_especial.periodo "
				+ "from locacao_especial_precos left join locacao_especial on (locacao_especial_precos.locacao_especial = locacao_especial.indice) "
				+ "where locacao_especial_precos.tabela_precos = :tabela_precos and locacao_especial_precos.produto = :produto order by locacao_especial_precos.indice", Conn);

				com.Parameters.Add(new NpgsqlParameter("tabela_precos", tabela));
				com.Parameters.Add(new NpgsqlParameter("produto", produto));

				List<LocacaoEspecialPreco> precos = new List<LocacaoEspecialPreco>();

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					LocacaoEspecialPreco l = new LocacaoEspecialPreco();
					l.Descricao = dr["descricao"].ToString();
					l.Preco = Convert.ToDecimal(dr["preco"]);
					l.Indice = Convert.ToInt32(dr["indice"]);
					l.Periodo = Convert.ToInt32(dr["periodo"]);
					l.Tabela = tabela;
					l.Produto = produto;

					precos.Add(l);
				}

				return precos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void GerarLocacoesEspeciais(int tabela, long produto)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select indice from locacao_especial where produto_tipo = :produto_tipo order by indice", Conn);
				com.Parameters.Add(new NpgsqlParameter("produto_tipo", ProdutoTipo(produto)));

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					NpgsqlCommand com2 = new NpgsqlCommand("select dsoft_insert_or_update_locacao_especial_precos(:produto, :tabela, :especial)");
					com2.Parameters.Add(new NpgsqlParameter("produto", produto));
					com2.Parameters.Add(new NpgsqlParameter("tabela", tabela));
					com2.Parameters.Add(new NpgsqlParameter("especial", Convert.ToInt32(dr[0])));
					ExecCommand(com2);
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void AtualizarPrecoLocacaoEspecial(int indice, decimal preco)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("update locacao_especial_precos set preco = :preco where indice = :indice");
				com.Parameters.Add(new NpgsqlParameter("preco", preco));
				com.Parameters.Add(new NpgsqlParameter("indice", indice));

				ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public DataTable ConsultaLancamentosLocacao(Usuario usuario, DateTime inicio, DateTime final)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select indice, inicio_data, inicio_hora, situacao, devolucao_data, devolucao_hora, valor_real "
					+"from locacao where usuario_inicio = " + usuario.Codigo.ToString() + " and situacao <> 'C' order by indice", Conn);

				DataSet ds = new DataSet();
				da.Fill(ds);

				return ds.Tables[0];
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public bool TrocarCodigoCliente(long atual, long novo, Usuario usuario)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select dsoft_altera_codigo_cliente(:atual, :novo, :usuario)");
				com.Parameters.Add(new NpgsqlParameter("atual", atual));
				com.Parameters.Add(new NpgsqlParameter("novo", novo));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Autorizado));

				return ExecCommand(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public List<Cliente> BuscaClientePorTelefone(long numero)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_clientes where (tel1 = :numero or tel2 = :numero or celular = :numero) and situacao = 'A' order by codigo", Conn);

				com.Parameters.Add(new NpgsqlParameter("numero", numero));

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Cliente> lista = new List<Cliente>();

				while (dr.Read())
				{
					Cliente c = new Cliente();
					c = CarregarCliente(long.Parse(dr[0].ToString()));

					lista.Add(c);
				}

				return lista;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<Pedido> EntregasAtrasadas(int minutos)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select indice from pedidos where cliente is not null and dsoft_cliente_interno(cliente) = false and (situacao = 'A' or situacao = 'N') and (data < :data or hora < :hora)", Conn);
				DateTime hora = DateTime.Now.AddMinutes(-RegrasDeNegocio.Instance.AvisoAtraso);
				com.Parameters.Add(new NpgsqlParameter("data", DateTime.Today.ToString("yyyy-MM-dd")));
				com.Parameters.Add(new NpgsqlParameter("hora", hora.ToString("HH:mm:ss")));

				NpgsqlDataReader dr = com.ExecuteReader();

				List<Pedido> pedidos = new List<Pedido>();

				while (dr.Read())
				{
					Pedido p = new Pedido();
					p.Indice = Convert.ToInt32(dr["indice"]);

					pedidos.Add(p);
				}

				return pedidos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>
		/// Retorna o saldo do último fechamento do Caixa
		/// </summary>
		/// <param name="caixa">Caixa</param>
		/// <returns>Saldo</returns>
		public decimal CaixaSaldo(Caixa caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select saldo from cad_caixa where codigo = :codigo");
				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		/// <summary>
		/// Define o saldo inicial de um caixa
		/// </summary>
		/// <param name="caixa"></param>
		/// <param name="saldo"></param>
		/// <param name="usuario"></param>
		public void CaixaSaldo(Caixa caixa, decimal saldo, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_caixa set saldo = :saldo where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("saldo", saldo));
			com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));
			ExecCommand(com);
		}

		public decimal CaixaSaldoAnterior(Caixa caixa)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select saldo_anterior from cad_caixa where codigo = :codigo");
				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxoEmAberto(Caixa caixa, FluxosDeCaixa fluxo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :codigo and tipo = :fluxo");
				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("fluxo", ((char)fluxo).ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxo(int fechamento, FluxosDeCaixa fluxo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'F' and fechamento = :fechamento and tipo = :fluxo");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));
				com.Parameters.Add(new NpgsqlParameter("fluxo", ((char)fluxo).ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxoEntradasEmAberto(Caixa caixa, char forma)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :codigo and tipo = 'E' and forma = :forma");
				com.Parameters.Add(new NpgsqlParameter("codigo", caixa.Codigo));
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxoEntradasSemFechamentoDiario(char forma)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'F' and fechamento in (select indice from caixa where situacao = 'A') and tipo = 'E' and forma = :forma");
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxoEntradas(int fechamento, char forma)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'F' and fechamento = :fechamento and tipo = 'E' and forma = :forma");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public decimal CaixaFluxoEntradasPorFechamentoDiario(int fechamento, char forma)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'F' and fechamento in (select indice from caixa where fechamento = :fechamento and situacao = 'F') and tipo = 'E' and forma = :forma");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public FechamentoDeCaixa CaixaAberto(Caixa caixa)
		{
			try
			{
				FechamentoDeCaixa fechamento = new FechamentoDeCaixa();

				fechamento.Caixa = caixa;

				fechamento.SaldoAnterior = CaixaSaldo(caixa);

				fechamento.Entradas = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Entrada);
				fechamento.Saidas = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Saida);
				fechamento.Despesas = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Despesa);
				fechamento.Vales = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Vale);
				fechamento.Pagamentos = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Pagamento);
				fechamento.Transferencias = CaixaFluxoEmAberto(caixa, FluxosDeCaixa.Transferencia);

				fechamento.SaldoAtual = fechamento.SaldoAnterior + fechamento.Entradas
					- fechamento.Saidas - fechamento.Despesas - fechamento.Vales - fechamento.Pagamentos - fechamento.Transferencias;

				List<FormaDePagamento> formasDePagamento = FormasDePagamento();

				fechamento.FormasDePagamento = new Dictionary<FormaDePagamento, decimal>();

				foreach (FormaDePagamento formaDePagamento in formasDePagamento)
				{
					fechamento.FormasDePagamento.Add(formaDePagamento, CaixaFluxoEntradasEmAberto(caixa, formaDePagamento.Codigo));
				}

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public Caixa CaixaDoFechamento(int fechamento)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select caixa from caixa where indice = :fechamento");
				com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

				Caixa caixa = new Caixa();

				caixa.Codigo = getInt(com);
				caixa.Descricao = CaixaDescricao(caixa.Codigo);

				return caixa;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public FechamentoDeCaixa ConsultaFechamentoDeCaixa(int numero)
		{
			try
			{
				FechamentoDeCaixa fechamento = new FechamentoDeCaixa();

				fechamento.Numero = numero;

				fechamento.Caixa = CaixaDoFechamento(numero);

				fechamento.SaldoAnterior = CaixaSaldoAnterior(fechamento.Caixa);

				fechamento.Entradas = CaixaFluxo(numero, FluxosDeCaixa.Entrada);
				fechamento.Saidas = CaixaFluxo(numero, FluxosDeCaixa.Saida);
				fechamento.Despesas = CaixaFluxo(numero, FluxosDeCaixa.Despesa);
				fechamento.Vales = CaixaFluxo(numero, FluxosDeCaixa.Vale);
				fechamento.Pagamentos = CaixaFluxo(numero, FluxosDeCaixa.Pagamento);
				fechamento.Transferencias = CaixaFluxo(numero, FluxosDeCaixa.Transferencia);

				fechamento.SaldoAtual = fechamento.SaldoAnterior + fechamento.Entradas
					- fechamento.Saidas - fechamento.Despesas - fechamento.Vales - fechamento.Pagamentos - fechamento.Transferencias;

				List<FormaDePagamento> formasDePagamento = FormasDePagamento();

				fechamento.FormasDePagamento = new Dictionary<FormaDePagamento, decimal>();

				foreach (FormaDePagamento formaDePagamento in formasDePagamento)
				{
					fechamento.FormasDePagamento.Add(formaDePagamento, CaixaFluxoEntradas(numero, formaDePagamento.Codigo));
				}

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public Caixa CarregarCaixa(int numero)
		{
			Caixa caixa = new Caixa();

			caixa.Codigo = numero;
			caixa.Descricao = CaixaDescricao(numero);

			return caixa;
		}

		public bool MovimentoEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(indice) from caixa_fluxo where situacao = 'A'");

			return getInt(com) > 0;
		}

		public decimal MovimentoEmAberto(char forma)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where situacao = 'A' and caixa = :codigo and tipo = 'E' and forma = :forma");
				com.Parameters.Add(new NpgsqlParameter("forma", forma.ToString()));

				return getDecimal(com);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public FechamentoDiario MovimentoDiarioEmAberto()
		{
			try
			{
				FechamentoDiario fechamento = new FechamentoDiario();

				NpgsqlCommand com = new NpgsqlCommand("select sum(entrada) as entrada, sum(saida) as saida, sum(despesa) as despesa, sum(vale) as vale, sum(pagamento) as pagamento "
					//+ ", sum(dinheiro) as dinheiro, sum(cartao) as cartao, sum(cheque) as cheque, sum(visa) as visa, sum(master) as master, sum(boleto) as boleto, sum(vr) as vr, sum(debito) as debito "
					+ "from caixa where situacao = 'A'", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read() && dr.HasRows)
				{
					fechamento.Entradas = dr["entrada"].ToString().Length > 0 ? Convert.ToDecimal(dr["entrada"]) : 0;
					fechamento.Saidas = dr["saida"].ToString().Length > 0 ? Convert.ToDecimal(dr["saida"]) : 0;
					fechamento.Despesas = dr["despesa"].ToString().Length > 0 ? Convert.ToDecimal(dr["despesa"]) : 0;
					fechamento.Vales = dr["vale"].ToString().Length > 0 ? Convert.ToDecimal(dr["vale"]) : 0;
					fechamento.Pagamentos = dr["pagamento"].ToString().Length > 0 ? Convert.ToDecimal(dr["pagamento"]) : 0;

					fechamento.FormasDePagamento = new Dictionary<FormaDePagamento, decimal>();

					List<FormaDePagamento> formasDePagamento = FormasDePagamento();

					foreach (FormaDePagamento formaDePagamento in formasDePagamento)
					{
						fechamento.FormasDePagamento.Add(formaDePagamento, CaixaFluxoEntradasSemFechamentoDiario(formaDePagamento.Codigo));
					}
				}

				com.Dispose();
				dr.Dispose();

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento is null and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and (cliente is null or cliente = 0 or retira = true)");

				fechamento.VendaDireta = getDecimal(com);

				com.Dispose();

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento is null and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and cliente in (select codigo from cad_clientes where tipo_cliente in (select codigo from clientes_tipos where cliente_interno = true))");

				fechamento.ClienteInterno = getDecimal(com);

				com.Dispose();

				com = new NpgsqlCommand("select sum(total) from pedidos where fechamento is null and (situacao = 'P' or situacao = 'N' or situacao = 'O') "
					+ "and retira = false and cliente in (select codigo from cad_clientes where tipo_cliente not in (select codigo from clientes_tipos where cliente_interno = true))");

				fechamento.Delivery = getDecimal(com);

				com.Dispose();

				fechamento.Movimentos = MovimentosTiposEmAberto();
				fechamento.PedidosCancelados = PedidosCanceladosEmAberto();
				fechamento.TotalCancelado = TotalCanceladoEmAberto();

				fechamento.SaldoAnterior = SaldoUltimoFechamentoDiario();

				fechamento.SaldoAtual = fechamento.SaldoAnterior + fechamento.Entradas - fechamento.Saidas - fechamento.Pagamentos - fechamento.Despesas - fechamento.Vales;

				return fechamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public decimal SaldoUltimoFechamentoDiario()
		{
			return getDecimal("select saldo from resumos where situacao = 'A' order by indice desc limit 1");
		}

		public int PedidosCancelados(int fechamento)
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(indice) from pedidos where situacao = 'C' and fechamento = :fechamento");
			com.Parameters.Add(new NpgsqlParameter("fechamento", fechamento));

			return getInt(com);
		}

		public int PedidosCanceladosEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(indice) from pedidos where situacao = 'C' and fechamento is null");

			return getInt(com);
		}

		public decimal TotalCanceladoEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select sum(total) from pedidos where situacao = 'C' and fechamento is null;");

			return getDecimal(com);
		}

		public List<MovimentoTipoProduto> MovimentosTiposEmAberto()
		{
			List<MovimentoTipoProduto> movimentos = new List<MovimentoTipoProduto>();

			NpgsqlCommand com = new NpgsqlCommand("select codigo from produtos_tipos where soma = true order by codigo", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			while (dr.Read())
			{
				NpgsqlCommand com2 = new NpgsqlCommand("select sum(fracao) as volume, sum(preco) as total from pedidos_itens "
					+ "left join pedidos on (pedidos_itens.pedido = pedidos.indice) "
					+ "left join cad_produtos on (pedidos_itens.produto = cad_produtos.codigo) "
					+ "where (pedidos.situacao = 'P' or pedidos.situacao = 'N' or pedidos.situacao = 'O') and pedidos.fechamento is null "
					+ "and pedidos_itens.situacao = 'A' "
					+ "and cad_produtos.codigo in (select cad_produtos.codigo from cad_produtos left join produtos_tipos on (cad_produtos.tipo = produtos_tipos.codigo) where produtos_tipos.codigo = :codigo)", Conn);
				com2.Parameters.Add(new NpgsqlParameter("codigo", Convert.ToInt32(dr[0])));

				NpgsqlDataReader dr2 = com2.ExecuteReader();

				if (dr2.Read())
				{
					decimal vol;

					if (decimal.TryParse(dr2[0].ToString(), out vol) && vol > 0)
					{
						MovimentoTipoProduto tipo = new MovimentoTipoProduto();

						tipo.Tipo = new ProdutoTipo() { Codigo = Convert.ToInt32(dr[0]) };
						tipo.Tipo.Nome = ProdutoTipoNome(tipo.Tipo.Codigo);

						tipo.Volume = vol;

						if (dr2["total"].ToString().Length > 0)
						{
							tipo.Total = Convert.ToDecimal(dr2["total"]);
						}

						movimentos.Add(tipo);
					}
				}
			}

			return movimentos;
		}

		public DateTime DataUltimoFechamentoDiario()
		{
			NpgsqlCommand com = new NpgsqlCommand("select data from resumos where situacao = 'A' order by data desc limit 1");

			return getDateTime(com);
		}

		public List<Entrega> EntregasEmAberto()
		{
			try
			{
				List<Entrega> entregas = new List<Entrega>();

				NpgsqlCommand com = new NpgsqlCommand("select pedidos.indice, pedidos.data, pedidos.hora, pedidos.cliente, cad_clientes.bairro, cad_clientes.endereco "
					+ "from pedidos left join cad_clientes on (pedidos.cliente = cad_clientes.codigo) "
					+ "where (pedidos.situacao = 'A' or pedidos.situacao = 'N') and pedidos.cliente is not null and pedidos.cliente > 0 "
					+ "order by pedidos.indice limit 50", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					Entrega e = new Entrega();

					e.Indice = Convert.ToInt32(dr["indice"]);
					e.Data = Convert.ToDateTime(dr["data"]);
					e.Hora = Convert.ToDateTime(dr["hora"]);
					e.Cliente = Convert.ToInt64(dr["cliente"]);
					e.Bairro = dr["bairro"].ToString();
					e.Endereco = dr["endereco"].ToString();

					entregas.Add(e);
				}

				return entregas;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<Recurso> EntregadoresDisponiveis()
		{
			try
			{
				string comando;

				if (RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores)
				{
					comando = "select cad_recursos.codigo, cad_recursos.nome "
								+ "from cad_recursos left join recursos_tipos on (cad_recursos.tipo = recursos_tipos.codigo) "
								+ "where recursos_tipos.entrega = true and cad_recursos.disponivel = true order by cad_recursos.nome";
				}
				else
				{
					comando = "select cad_recursos.codigo, cad_recursos.nome "
								+ "from cad_recursos left join recursos_tipos on (cad_recursos.tipo = recursos_tipos.codigo) "
								+ "where recursos_tipos.entrega = true order by cad_recursos.nome";
				}

				List<Recurso> entregadores = new List<Recurso>();

				NpgsqlCommand com = new NpgsqlCommand(comando, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					Recurso r = new Recurso();

					r.Codigo = Convert.ToInt32(dr["codigo"]);
					r.Nome = dr["nome"].ToString();

					entregadores.Add(r);
				}

				return entregadores;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public DataTable ConsultaMovimentoDiaDia(DateTime inicio, DateTime final)
		{
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("select data, entrada, venda_direta, cliente_interno, delivery from resumos "
					+ "where situacao = 'A' and data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + final.ToString("yyyy-MM-dd") + "' order by data", Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				if (ds != null && ds.Tables.Count > 0)
				{
					return ds.Tables[0];
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public int PedidosPorGruposDeClientes(ClienteGrupo grupo, DateTime data)
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(pedidos.indice) from pedidos "
				+ "where pedidos.data = '" + data.ToString("yyyy-MM-dd") + "' and pedidos.situacao <> 'C' "
				+ "and pedidos.cliente in (select cad_clientes.codigo from cad_clientes where cad_clientes.grupo = :grupo)");
			com.Parameters.Add(new NpgsqlParameter("grupo", grupo.Codigo));

			return getInt(com);
		}

		public int UltimoPedidoAberto(Cliente cliente)
		{
			NpgsqlCommand com = new NpgsqlCommand("select pedidos.indice from pedidos where pedidos.cliente = :cliente and situacao = 'A' order by indice desc limit 1");
			com.Parameters.Add(new NpgsqlParameter("cliente", cliente.Codigo));

			return getInt(com);
		}

		public DataTable CarregarProdutosPrecos(TabelaDePrecos tabela)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_produtos.codigo, cad_produtos.nome, produtos_precos.preco from cad_produtos "
				+ "left join produtos_precos on (cad_produtos.codigo = produtos_precos.produto) where cad_produtos.situacao = 'A' and produtos_precos.tabela = "
				+ tabela.Codigo.ToString() + " order by cad_produtos.codigo", Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public Endereco BuscaEndereco(int cep)
		{
			NpgsqlCommand com = new NpgsqlCommand("select logradouros.nome as logradouro, bairros.nome as bairro, cidades.nome as cidade, uf.nome as estado, uf.sigla as uf "
				+ "from logradouros left join bairros on (bairros.codigo = logradouros.bairro) "
				+ "left join cidades on (cidades.codigo = bairros.municipio) "
				+ "left join uf on (uf.codigo = cidades.uf) "
				+ "where logradouros.cep = :cep", Conn);
			com.Parameters.Add(new NpgsqlParameter("cep", cep));

			try
			{
				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					Endereco endereco = new Endereco();

					endereco.CEP = cep;
					endereco.Logradouro = dr["logradouro"].ToString();
					endereco.Bairro = dr["bairro"].ToString();
					endereco.Cidade = dr["cidade"].ToString();
					endereco.Estado = dr["estado"].ToString();
					endereco.UF = dr["uf"].ToString();

					return endereco;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public ClienteGrupo ClienteGrupo(string nome, string cidade)
		{
			NpgsqlCommand com = new NpgsqlCommand("select codigo, taxa_entrega, taxa_servico from clientes_grupos where nome = :nome and cidade = :cidade", Conn);
			com.Parameters.Add(new NpgsqlParameter("nome", nome));
			com.Parameters.Add(new NpgsqlParameter("cidade", cidade));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read() && dr["codigo"].ToString().Length > 0)
			{
				ClienteGrupo grupo = new ClienteGrupo();
				grupo.Codigo = Convert.ToInt32(dr["codigo"]);
				grupo.Nome = nome;

				decimal taxa;
				decimal.TryParse(dr["taxa_entrega"].ToString(), out taxa);

				grupo.Taxa = taxa;

				decimal.TryParse(dr["taxa_servico"].ToString(), out taxa);

				grupo.TaxaDeServico = taxa;

				return grupo;
			}
			else
			{
				return null;
			}
		}

		public DataTable CarregarEntregadores()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select cad_recursos.codigo, cad_recursos.nome, cad_recursos.disponivel from cad_recursos "
				+ "left join recursos_tipos on (cad_recursos.tipo = recursos_tipos.codigo) where recursos_tipos.entrega = true and cad_recursos.situacao = 'A' "
				+ "order by cad_recursos.codigo", Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public void AlterarDisponibilidadeEntregador(int recurso, bool disponivel)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_recursos set disponivel = :disponivel where cad_recursos.codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("disponivel", disponivel));
			com.Parameters.Add(new NpgsqlParameter("codigo", recurso));

			ExecCommand(com);
		}

		public void AlterarDisponibilidadeEntregadores(bool disponivel)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_recursos set disponivel = :disponivel");
			com.Parameters.Add(new NpgsqlParameter("disponivel", disponivel));

			ExecCommand(com);
		}

		public List<string> CarregarObservacoes()
		{
			List<string> observacoes = new List<string>();

			NpgsqlCommand com = new NpgsqlCommand("select observacao from cad_observacoes order by ordem", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			while (dr.Read())
			{
				observacoes.Add(dr[0].ToString());
			}

			return observacoes;
		}

		public void ExcluirObservacao(string observacao)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_observacoes where observacao = :observacao");
			com.Parameters.Add(new NpgsqlParameter("observacao", observacao));

			ExecCommand(com);
		}

		public void IncluirObservacao(string observacao, int ordem = 0)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into cad_observacoes (observacao, ordem) values (:observacao, :ordem)");
			com.Parameters.Add(new NpgsqlParameter("observacao", observacao));
			com.Parameters.Add(new NpgsqlParameter("ordem", ordem));

			ExecCommand(com);
		}

		public void AlterarOrdemObservacao(string observacao, int ordem)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_observacoes set ordem = :ordem where observacao = :observacao");
			com.Parameters.Add(new NpgsqlParameter("observacao", observacao));
			com.Parameters.Add(new NpgsqlParameter("ordem", ordem));

			ExecCommand(com);
		}

		public void LimparObservacoes()
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_observacoes");

			ExecCommand(com);
		}

		public bool GerenciaCalendarioDeTabelas()
		{
			NpgsqlCommand com = new NpgsqlCommand("select gerencia from calendario_tabelas");
			return getBool(com);
		}

		public void GerenciaCalendarioDeTabelas(bool gerencia)
		{
			NpgsqlCommand com = new NpgsqlCommand("update calendario_tabelas set gerencia = :gerencia");
			com.Parameters.Add(new NpgsqlParameter("gerencia", gerencia));

			ExecCommand(com);
		}

		public CalendarioDeTabelas CarregarCalendarioDeTabelas()
		{
			NpgsqlCommand com = new NpgsqlCommand("select gerencia, dom, seg, ter, qua, qui, sex, sab from calendario_tabelas", Conn);

			try
			{
				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					CalendarioDeTabelas calendario = new CalendarioDeTabelas();

					calendario.Gerencia = Convert.ToBoolean(dr["gerencia"]);
					calendario.Domingo = dr["dom"].ToString().Length > 0 ? Convert.ToInt32(dr["dom"]) : 1;
					calendario.Segunda = dr["seg"].ToString().Length > 0 ? Convert.ToInt32(dr["seg"]) : 1;
					calendario.Terca = dr["ter"].ToString().Length > 0 ? Convert.ToInt32(dr["ter"]) : 1;
					calendario.Quarta = dr["qua"].ToString().Length > 0 ? Convert.ToInt32(dr["qua"]) : 1;
					calendario.Quinta = dr["qui"].ToString().Length > 0 ? Convert.ToInt32(dr["qui"]) : 1;
					calendario.Sexta = dr["sex"].ToString().Length > 0 ? Convert.ToInt32(dr["sex"]) : 1;
					calendario.Sabado = dr["sab"].ToString().Length > 0 ? Convert.ToInt32(dr["sab"]) : 1;

					return calendario;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}
		}

		public bool isConnected()
		{
			if (Conn == null)
			{
				return false;
			}
			else
			{
				return Conn.State == ConnectionState.Open;
			}
		}

		public void AtualizarCalendarioDeTabelas(CalendarioDeTabelas calendario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update calendario_tabelas set gerencia = :gerencia, "
				+ "dom = :dom, seg = :seg, ter = :ter, qua = :qua, qui = :qui, sex = :sex, sab = :sab");
			com.Parameters.Add(new NpgsqlParameter("gerencia", calendario.Gerencia));
			com.Parameters.Add(new NpgsqlParameter("dom", calendario.Domingo));
			com.Parameters.Add(new NpgsqlParameter("seg", calendario.Segunda));
			com.Parameters.Add(new NpgsqlParameter("ter", calendario.Terca));
			com.Parameters.Add(new NpgsqlParameter("qua", calendario.Quarta));
			com.Parameters.Add(new NpgsqlParameter("qui", calendario.Quinta));
			com.Parameters.Add(new NpgsqlParameter("sex", calendario.Sexta));
			com.Parameters.Add(new NpgsqlParameter("sab", calendario.Sabado));

			ExecCommand(com);
		}

		public DataTable CarregarRecebimentos()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select recebimentos.indice, recebimentos.data, cad_clientes.nome, recebimentos.vencimento, "
				+ "recebimentos.valor, recebimentos.valor_pago, recebimentos.situacao, recebimentos_tipos.nome, recebimentos.pago_data from recebimentos "
				+"left join cad_clientes on (cad_clientes.codigo = recebimentos.cliente) left join recebimentos_tipos on (recebimentos_tipos.codigo = recebimentos.tipo) "
				+ "order by recebimentos.indice", Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null & ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public DataTable CarregarRecebimentos(DateTime inicial, DateTime final)
		{
			string comando = string.Format("select recebimentos.indice, recebimentos.data, cad_clientes.nome, recebimentos.vencimento, "
				+ "recebimentos.valor, recebimentos.valor_pago, recebimentos.situacao, recebimentos_tipos.nome, recebimentos.pago_data from recebimentos "
				+ "left join cad_clientes on (cad_clientes.codigo = recebimentos.cliente) left join recebimentos_tipos on (recebimentos_tipos.codigo = recebimentos.tipo) "
				+ "where vencimento between '{0}' and '{1}' and recebimentos.situacao <> 'C' "
				+ "order by recebimentos.indice", inicial.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"));

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(comando, Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null & ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public int IncluirRecebimento(Recebimento recebimento)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into recebimentos (tipo, cliente, valor, vencimento, usuario, observacao, situacao) "
				+ "values (:tipo, :cliente, :valor, :vencimento, :usuario, :observacao, :situacao) returning indice");

			com.Parameters.Add(new NpgsqlParameter("tipo", recebimento.Tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("cliente", recebimento.Cliente.Codigo));
			com.Parameters.Add(new NpgsqlParameter("valor", recebimento.Valor));
			com.Parameters.Add(new NpgsqlParameter("vencimento", recebimento.Vencimento));
			com.Parameters.Add(new NpgsqlParameter("usuario", recebimento.Usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("observacao", recebimento.Observacao));
			com.Parameters.Add(new NpgsqlParameter("situacao", "A"));

			return getInt(com);
		}

		public bool AlterarRecebimento(Recebimento recebimento)
		{
			NpgsqlCommand com = new NpgsqlCommand("update recebimentos set tipo = :tipo, cliente = :cliente, valor = :valor, vencimento = :vencimento, "
				+ "usuario = :usuario, observacao = :observacao where indice = :indice");

			com.Parameters.Add(new NpgsqlParameter("tipo", recebimento.Tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("cliente", recebimento.Cliente.Codigo));
			com.Parameters.Add(new NpgsqlParameter("valor", recebimento.Valor));
			com.Parameters.Add(new NpgsqlParameter("vencimento", recebimento.Vencimento));
			com.Parameters.Add(new NpgsqlParameter("usuario", recebimento.Usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("observacao", recebimento.Observacao));
			com.Parameters.Add(new NpgsqlParameter("indice", recebimento.Indice));

			return ExecCommand(com);
		}

		public bool CancelarRecebimento(Recebimento recebimento)
		{
			NpgsqlCommand com = new NpgsqlCommand("update recebimentos set situacao = 'C', cancelado_data = now(), cancelado_hora = now(), cancelado_usuario = :usuario "
				+ "where indice = :indice");

			com.Parameters.Add(new NpgsqlParameter("indice", recebimento.Indice));
			com.Parameters.Add(new NpgsqlParameter("usuario", recebimento.Usuario.Codigo));

			return ExecCommand(com);
		}

		public bool ConfirmarPagamento(Recebimento recebimento)
		{
			FluxoDeCaixa caixa = new DSoftModels.FluxoDeCaixa();
			caixa.Caixa = Caixa.Numero;
			caixa.Cliente = recebimento.Cliente.Codigo;
			caixa.Data = recebimento.Pagamento;
			caixa.Forma = 'D';
			caixa.Tipo = 'E';
			caixa.Valor = recebimento.ValorPago;
			caixa.Observacao = "ENTRADA EFETUADA PELA BAIXA DE RECEBIMENTO N. " + recebimento.Indice.ToString();

			int caixa_fluxo = LancarEntrada(caixa, Caixa.Numero, recebimento.Usuario.Codigo);

			NpgsqlCommand com = new NpgsqlCommand("update recebimentos set situacao = 'P', pago_data = :pago_data, pago_hora = now(), pago_usuario = :usuario, valor_pago = :valor_pago, "
				+ "caixa_fluxo = :caixa_fluxo where indice = :indice");

			com.Parameters.Add(new NpgsqlParameter("pago_data", recebimento.Pagamento));
			com.Parameters.Add(new NpgsqlParameter("usuario", recebimento.Usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("valor_pago", recebimento.ValorPago));
			com.Parameters.Add(new NpgsqlParameter("caixa_fluxo", caixa_fluxo));
			com.Parameters.Add(new NpgsqlParameter("indice", recebimento.Indice));

			return ExecCommand(com);
		}

		public Recebimento CarregarRecebimento(int indice)
		{
			NpgsqlCommand com = new NpgsqlCommand("select data, vencimento, situacao, cliente, tipo, valor, valor_pago, pago_data, usuario, pago_usuario, observacao from recebimentos where indice = :indice", Conn);
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				Recebimento recebimento = new Recebimento();

				recebimento.Indice = indice;
				recebimento.Data = Convert.ToDateTime(dr["data"]);
				recebimento.Vencimento = Convert.ToDateTime(dr["vencimento"]);
				recebimento.Situacao = (Situacoes)dr["situacao"].ToString()[0];
				recebimento.Cliente = CarregarCliente(Convert.ToInt64(dr["cliente"]));
				recebimento.Tipo = CarregarRecebimentoTipo(Convert.ToInt32(dr["tipo"]));
				recebimento.Valor = Convert.ToDecimal(dr["valor"]);
				recebimento.Observacao = dr["observacao"].ToString();

				if (recebimento.Situacao == Situacoes.Pago)
				{
					recebimento.ValorPago = Convert.ToDecimal(dr["valor_pago"]);
					recebimento.Pagamento = Convert.ToDateTime(dr["pago_data"]);
				}

				return recebimento;
			}
			else
			{
				return null;
			}
		}

		public bool IncluirRecebimentoTipo(RecebimentoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into recebimentos_tipos(codigo, nome) values(:codigo, :nome);");
			com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
			return ExecCommand(com);
		}

		public bool AlterarRecebimentoTipo(RecebimentoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("update recebimentos_tipos set nome = :nome where codigo = :codigo;");
			com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("nome", tipo.Nome));
			return ExecCommand(com);
		}

		public bool IncluirOuAlterar(RecebimentoTipo tipo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(nome) from recebimentos_tipos where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("codigo", tipo.Codigo));

			if (getInt(com) > 0)
			{
				return AlterarRecebimentoTipo(tipo);
			}
			else
			{
				return IncluirRecebimentoTipo(tipo);
			}
		}

		public DataTable CarregarRecebimentosTipos()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, nome from recebimentos_tipos order by codigo", Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public RecebimentoTipo CarregarRecebimentoTipo(int codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select nome from recebimentos_tipos where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				RecebimentoTipo tipo = new RecebimentoTipo();
				tipo.Codigo = codigo;
				tipo.Nome = dr["nome"].ToString();
				return tipo;
			}
			else
			{
				return null;
			}
		}

		public List<RecebimentoTipo> RecebimentosTipos()
		{
			NpgsqlCommand com = new NpgsqlCommand("select codigo, nome from recebimentos_tipos order by codigo", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<RecebimentoTipo> recebimentos = new List<RecebimentoTipo>();

			while (dr.Read())
			{
				RecebimentoTipo tipo = new RecebimentoTipo();

				tipo.Codigo = Convert.ToInt32(dr["codigo"]);
				tipo.Nome = dr["nome"].ToString();

				recebimentos.Add(tipo);
			}

			return recebimentos;
		}

		public int ProximaComanda()
		{
			NpgsqlCommand com = new NpgsqlCommand("select comanda from pedidos where fechamento is null and comanda is not null order by comanda desc limit 1");
			return getInt(com) + 1;
		}

		public int PedidoPorComanda(int comanda, DateTime data)
		{
			NpgsqlCommand com = new NpgsqlCommand("select indice from pedidos where comanda = :comanda and data = :data");
			com.Parameters.Add(new NpgsqlParameter("comanda", comanda));
			com.Parameters.Add(new NpgsqlParameter("data", data));

			return getInt(com);
		}

		public DateTime PrimeiroPedidoAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select data from pedidos where fechamento is null order by data limit 1");
			return getDateTime(com);
		}

		public int ExcluirRegistrosDuplicados()
		{
			NpgsqlCommand com = new NpgsqlCommand("select codcli, codigo from imported order by codigo", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			long anterior = 0;
			List<int> duplicados = new List<int>();

			while (dr.Read())
			{
				long atual = Convert.ToInt64(dr["codigo"]);

				if (atual == anterior)
				{
					duplicados.Add(Convert.ToInt32(dr["codcli"]));
				}

				anterior = atual;
			}

			foreach (int dup in duplicados)
			{
				com = new NpgsqlCommand("delete from imported where codcli = :dup", Conn);
				com.Parameters.Add(new NpgsqlParameter("dup", dup));
				com.ExecuteNonQuery();
			}

			return duplicados.Count;
		}

		public DataSet ClientesInativos(DateTime inicio, DateTime final)
		{
			try
			{
				string query = string.Format("select codigo, nome, tel1, tel2, celular from cad_clientes where codigo not in "
					+ "(select distinct cliente from pedidos where data between '{0}' and '{1}' and cliente is not null) order by nome", inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"));

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				return ds;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public DataSet ClientesPorQuantidadeDePedidos(DateTime inicio, DateTime final)
		{
			try
			{
				string query = string.Format("select distinct pedidos.cliente, " +
					"cad_clientes.nome, " +
					"pedidos_qtd(pedidos.cliente, '{0}', '{1}') as quantidade, " +
					"pedidos_valor(pedidos.cliente, '{0}', '{1}') as total " +
					"from pedidos left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
					"where pedidos.cliente is not null and pedidos.cliente > 0 and data between '{0}' and '{1}' and pedidos.situacao <> 'C' " +
					"order by quantidade desc", inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"));

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				if (ds != null && ds.Tables.Count > 0)
				{
					return ds;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public DataSet ClientesPorValorDePedidos(DateTime inicio, DateTime final)
		{
			try
			{
				string query = string.Format("select distinct pedidos.cliente, " +
					"cad_clientes.nome, " +
					"pedidos_qtd(pedidos.cliente, '{0}', '{1}') as quantidade, " +
					"pedidos_valor(pedidos.cliente, '{0}', '{1}') as total " +
					"from pedidos left join cad_clientes on (cad_clientes.codigo = pedidos.cliente) " +
					"where pedidos.cliente is not null and pedidos.cliente > 0 and data between '{0}' and '{1}' and pedidos.situacao <> 'C' " +
					"order by total desc", inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"));

				NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, Conn);

				DataSet ds = new DataSet();

				da.Fill(ds);

				if (ds != null && ds.Tables.Count > 0)
				{
					return ds;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public int ProximoCodigoClienteGrupo()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo from clientes_grupos order by codigo desc limit 1");

				return getInt(com) + 1;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return 0;
			}
		}

		public Dictionary<int, DateTime> UltimosPedidos(Cliente cliente, int maximo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select data, indice from pedidos where cliente = :cliente and situacao <> 'C' order by indice desc limit :maximo", Conn);
				com.Parameters.Add(new NpgsqlParameter("cliente", cliente.Codigo));
				com.Parameters.Add(new NpgsqlParameter("maximo", maximo));

				NpgsqlDataReader dr = com.ExecuteReader();

				Dictionary<int, DateTime> historico = new Dictionary<int, DateTime>();

				while (dr.Read())
				{
					DateTime data = Convert.ToDateTime(dr[0]);
					int indice = Convert.ToInt32(dr[1]);

					historico.Add(indice, data);
				}

				return historico;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public ProdutoTipo CarregarProdutoTipo(int tipo)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select nome, descricao, producao, estoque, soma, impressora_externa, adicionais, meio, fracao, imprime_total, situacao "
					+ "from produtos_tipos where codigo = " + tipo, Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				if (dr.Read())
				{
					ProdutoTipo produtoTipo = new ProdutoTipo();
					produtoTipo.Codigo = tipo;
					produtoTipo.Nome = dr["nome"].ToString();
					produtoTipo.Descricao = dr["descricao"].ToString();
					produtoTipo.Producao = Convert.ToBoolean(dr["producao"]);
					produtoTipo.Estoque = Convert.ToBoolean(dr["estoque"]);
					produtoTipo.Soma = Convert.ToBoolean(dr["soma"]);
					produtoTipo.Adicionais = Convert.ToBoolean(dr["adicionais"]);
					produtoTipo.MeioAMeio = Convert.ToBoolean(dr["meio"]);
					produtoTipo.Fracionado = Convert.ToBoolean(dr["fracao"]);
					produtoTipo.ImprimeQuantidadeTotal = Convert.ToBoolean(dr["imprime_total"]);
					produtoTipo.Situacao = dr["situacao"].ToString()[0];

					return produtoTipo;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<ProdutoTipo> ProdutosTipos()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo, nome, descricao, producao, estoque, soma, impressora_externa, adicionais, meio, fracao, imprime_total, situacao "
					+ "from produtos_tipos order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<ProdutoTipo> _produtos = new List<ProdutoTipo>();

				while (dr.Read())
				{
					ProdutoTipo produtoTipo = new ProdutoTipo();

					produtoTipo.Codigo = Convert.ToInt32(dr["codigo"]);
					produtoTipo.Nome = dr["nome"].ToString();
					produtoTipo.Descricao = dr["descricao"].ToString();
					produtoTipo.Producao = Convert.ToBoolean(dr["producao"]);
					produtoTipo.Estoque = Convert.ToBoolean(dr["estoque"]);
					produtoTipo.Soma = Convert.ToBoolean(dr["soma"]);
					produtoTipo.Adicionais = Convert.ToBoolean(dr["adicionais"]);
					produtoTipo.MeioAMeio = Convert.ToBoolean(dr["meio"]);
					produtoTipo.Fracionado = Convert.ToBoolean(dr["fracao"]);
					produtoTipo.ImprimeQuantidadeTotal = Convert.ToBoolean(dr["imprime_total"]);
					produtoTipo.Situacao = dr["situacao"].ToString()[0];

					_produtos.Add(produtoTipo);
				}

				return _produtos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<ProdutoGrupo> ProdutosGrupos()
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select codigo, descricao from produtos_grupos where situacao = 'A' order by codigo", Conn);

				NpgsqlDataReader dr = com.ExecuteReader();

				List<ProdutoGrupo> _grupos = new List<ProdutoGrupo>();

				while (dr.Read())
				{
					ProdutoGrupo grupo = new ProdutoGrupo();
					grupo.Codigo = Convert.ToInt32(dr["codigo"]);
					grupo.Descricao = dr["descricao"].ToString();

					_grupos.Add(grupo);
				}

				return _grupos;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void RedefinirBairrosPeloCep()
		{
			NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_clientes where situacao = 'A' order by codigo", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			while (dr.Read())
			{
				Cliente cliente = CarregarCliente(Convert.ToInt64(dr[0]));

				if (cliente != null && cliente.Cep.Length > 0)
				{
					Endereco endereco = BuscaEndereco(Convert.ToInt32(cliente.Cep));

					if (endereco != null)
					{
						cliente.Bairro = endereco.Bairro.ToUpper();
						cliente.Estado = endereco.UF;
						cliente.Cidade = endereco.Cidade.ToUpper();
						cliente.Tipo = 'F';

						ClienteGrupo grupo = ClienteGrupo(endereco.Bairro.ToUpper(), endereco.Cidade.ToUpper());

						if (grupo == null)
						{
							grupo = new DSoftModels.ClienteGrupo();
							grupo.Codigo = ProximoCodigoClienteGrupo();
							grupo.Nome = endereco.Bairro.ToUpper();
							grupo.Cidade = endereco.Cidade.ToUpper();
							grupo.Estado = endereco.UFCompleto;

							NovoGrupoClientes(grupo);
						}

						cliente.Grupo = grupo.Codigo;

						AlterarCliente(cliente);
					}
				}
			}
		}

		public int QuantidadeDeClientesAtivos()
		{
			NpgsqlCommand com = new NpgsqlCommand("select count(codigo) from cad_clientes where situacao = 'A'");
			return getInt(com);
		}

		public decimal TaxaDeEntrega(Cliente cliente)
		{
			if (cliente != null)
			{
				NpgsqlCommand com = new NpgsqlCommand("select taxa_de_entrega from cad_clientes where codigo = :codigo");
				com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));
				return getDecimal(com);
			}
			else
			{
				return 0;
			}
		}

		public List<FormaDePagamento> PagamentosDoPedido(Pedido pedido)
		{
			try
			{
				NpgsqlCommand com = new NpgsqlCommand("select pagamentos.tipo, pagamentos_formas.descricao, pagamentos.valor from pagamentos left join pagamentos_formas on (pagamentos_formas.codigo = pagamentos.tipo) "
					+ "where pagamentos.pedido = :pedido and situacao = 'A'", Conn);
				com.Parameters.Add(new NpgsqlParameter("pedido", pedido.Numero));

				List<FormaDePagamento> formasDePagamento = new List<FormaDePagamento>();

				NpgsqlDataReader dr = com.ExecuteReader();

				while (dr.Read())
				{
					FormaDePagamento formaDePagamento = new FormaDePagamento();
					formaDePagamento.Codigo = dr["tipo"].ToString()[0];
					formaDePagamento.Descricao = dr["descricao"].ToString();

					formasDePagamento.Add(formaDePagamento);
				}

				return formasDePagamento;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public List<PagamentoNovo> PagamentosNovoDoPedido(Pedido pedido)
		{
			NpgsqlCommand com = new NpgsqlCommand(string.Format("select pagamentos.tipo, pagamentos.documento, pagamentos.valor " +
													"from pagamentos where pedido = {0} and situacao = 'A'", pedido.Numero), Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			List<PagamentoNovo> pagamentos = new List<PagamentoNovo>();

			while (dr.Read())
			{
				PagamentoNovo p = new PagamentoNovo();

				p.Forma = dr["tipo"].ToString();
				p.Documento = dr["documento"].ToString();
				p.Valor = Convert.ToDecimal(dr["valor"].ToString());

				pagamentos.Add(p);
			}

			return pagamentos;
		}

		public string PagamentoForma(string tipo)
		{
			return getString(string.Format("select descricao from pagamentos_formas where codigo = '{0}'", tipo));
		}

		public void RegistraTroco(Pedido pedido, decimal troco)
		{
			NpgsqlCommand com = new NpgsqlCommand("update pedidos set troco = :troco where indice = :indice");
			com.Parameters.Add(new NpgsqlParameter("troco", troco));
			com.Parameters.Add(new NpgsqlParameter("indice", pedido.Numero));

			ExecCommand(com);
		}

		public Dictionary<Recurso, decimal> PagamentosEntregadoresEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select cad_recursos.codigo, sum(pedidos.taxa_entrega) "
					+ "from pedidos "
					+ "left join entregas on (entregas.pedido = pedidos.indice) "
					+ "left join cad_recursos on (cad_recursos.codigo = entregas.recurso) "
					+ "where pedidos.fechamento is null and pedidos.situacao != 'C' "
					+ "group by cad_recursos.codigo order by cad_recursos.codigo", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			Dictionary<Recurso, decimal> pagamentos = new Dictionary<Recurso, decimal>();

			while (dr.Read())
			{
				if (dr[0].ToString().Length > 0)
				{
					Recurso entregador = CarregarRecurso(Convert.ToInt32(dr[0]));
					decimal valor = Convert.ToDecimal(dr[1]);

					pagamentos.Add(entregador, valor);
			
				}
			}

			return pagamentos;
		}

		public Dictionary<Recurso, decimal> PagamentosEntregadoresEmAbertoEspecial()
		{
			NpgsqlCommand com = new NpgsqlCommand("select cad_recursos.codigo, sum(pedidos.taxa_entregador) "
					+ "from pedidos "
					+ "left join entregas on (entregas.pedido = pedidos.indice) "
					+ "left join cad_recursos on (cad_recursos.codigo = entregas.recurso) "
					+ "where pedidos.fechamento is null and pedidos.situacao != 'C' "
					+ "group by cad_recursos.codigo order by cad_recursos.codigo", Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			Dictionary<Recurso, decimal> pagamentos = new Dictionary<Recurso, decimal>();

			while (dr.Read())
			{
				if (dr[0].ToString().Length > 0)
				{
					Recurso entregador = CarregarRecurso(Convert.ToInt32(dr[0]));
					decimal valor = Convert.ToDecimal(dr[1]);

					pagamentos.Add(entregador, valor);

				}
			}

			return pagamentos;
		}

		public FechamentoDiario CarregarFechamentoDiario(DateTime dia)
		{
			return CarregarFechamentoDiario(FechamentoDiario(dia), dia);
		}

		public FechamentoDiario CarregarFechamentoDiario(int indice, DateTime data)
		{
			FechamentoDiario fechamento = new FechamentoDiario();

			fechamento.Data = data;

			NpgsqlCommand com = new NpgsqlCommand(string.Format("select saldo_anterior, saldo, entrada, saida, despesas, vales, pagamentos, "
				+ "vendas, volume, venda_direta, cliente_interno, delivery "
				+ "from resumos where indice = {0}", indice), Conn);

			NpgsqlDataReader dr = com.ExecuteReader();

			if (!dr.Read())
			{
				return null;
			}

			fechamento.SaldoAnterior = Util.TryParseDecimal(dr["saldo_anterior"]);
			fechamento.SaldoAtual = Util.TryParseDecimal(dr["saldo"]);
			fechamento.Entradas = Util.TryParseDecimal(dr["entrada"]);
			fechamento.Saidas = Util.TryParseDecimal(dr["saida"]);
			fechamento.Despesas = Util.TryParseDecimal(dr["despesas"]);
			fechamento.Vales = Util.TryParseDecimal(dr["vales"]);
			fechamento.Pagamentos = Util.TryParseDecimal(dr["pagamentos"]);
			fechamento.VendaDireta = Util.TryParseDecimal(dr["venda_direta"]);
			fechamento.Volume = Util.TryParseInt(dr["volume"]);
			fechamento.Vendas = Util.TryParseDecimal(dr["vendas"]);
			fechamento.ClienteInterno = Util.TryParseDecimal(dr["cliente_interno"]);
			fechamento.Delivery = Util.TryParseDecimal(dr["delivery"]);

			List<FormaDePagamento> formasDePagamento = FormasDePagamento();

			fechamento.FormasDePagamento = new Dictionary<FormaDePagamento, decimal>();

			foreach (FormaDePagamento formaDePagamento in formasDePagamento)
			{
				fechamento.FormasDePagamento.Add(formaDePagamento, CaixaFluxoEntradasPorFechamentoDiario(indice, formaDePagamento.Codigo));
			}

			return fechamento;
		}

		public int FechamentoDiario(DateTime data)
		{
			NpgsqlCommand com = new NpgsqlCommand("select indice from resumos where data = :data and situacao = 'A'");
			com.Parameters.Add(new NpgsqlParameter("data", data));

			return getInt(com);
		}

		public DataTable FechamentosDiarios(DateTime inicio, DateTime final)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select indice, data, entrada, despesas, vales, pagamentos, saida from resumos where data between '{0}-{1}-{2}' and '{3}-{4}-{5}' and situacao = 'A' order by data",
				inicio.ToString("yyyy"), inicio.Month.ToString("00"), inicio.Day.ToString("00"), final.ToString("yyyy"), final.Month.ToString("00"), final.Day.ToString("00")), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public DataTable CarregarDetalhesFechamento(int fechamento)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select pedidos.comanda, pedidos.data, pedidos.hora, caixa_fluxo.forma, pedidos.total "
				+ "from pedidos "
				+ "left join caixa_fluxo on (caixa_fluxo.pedido = pedidos.indice) "
				+ "where pedidos.fechamento = {0} and pedidos.situacao <> 'C' "
				+ "order by pedidos.indice", fechamento), Conn);

			DataSet ds = new DataSet(); ;
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public decimal DiariaEntregador()
		{
			return getDecimal("select diaria from recursos_tipos where entrega = true order by codigo limit 1");
		}

		public decimal PagamentoPorEntrega()
		{
			return getDecimal("select valor_entrega from recursos_tipos where entrega = true order by codigo limit 1");
		}

		public int QuantidadeEntregasEmAberto()
		{
			return getInt("select count(indice) from pedidos where (situacao = 'P' or situacao = 'E') and fechamento is null and entrega is not null;");
		}

		public int QuantidadeEntregasEmAberto(Recurso entregador)
		{
			return getInt(string.Format("select count(pedidos.indice) "
				+ "from pedidos left join entregas on (entregas.situacao = 'E' and entregas.pedido = pedidos.indice) "
				+ "where (pedidos.situacao = 'P' or pedidos.situacao = 'E') and fechamento is null and entregas.recurso = {0}", entregador.Codigo));
		}

		public int QuantidadeEntregadoresAtivosNoDia()
		{
			return getInt("select distinct(entregas.recurso) from pedidos left join entregas on (entregas.situacao = 'E' and entregas.pedido = pedidos.indice) "
				+ "where pedidos.situacao <> 'C' and fechamento is null and pedidos.entrega is not null");
		}

		public decimal SaldoAtual(Recurso funcionario)
		{
			return getDecimal(string.Format("select saldo from cad_recursos where codigo = {0}", funcionario.Codigo));
		}

		public bool SaldoAtual(Recurso funcionario, decimal saldo)
		{
			NpgsqlCommand com = new NpgsqlCommand("update cad_recursos set saldo = :saldo where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("saldo", saldo));
			com.Parameters.Add(new NpgsqlParameter("codigo", funcionario.Codigo));

			return ExecCommand(com); 
		}

		public decimal PagamentosEmAberto(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select sum(caixa_fluxo.valor) "
				+ "from caixa left join caixa_fluxo on (caixa_fluxo.fechamento = caixa.indice) "
				+ "where caixa.fechamento is null and caixa.situacao = 'A' and caixa_fluxo.situacao <> 'C' and caixa_fluxo.recurso = :codigo and caixa_fluxo.tipo = 'P'");
			com.Parameters.Add(new NpgsqlParameter("codigo", funcionario.Codigo));

			return getDecimal(com);
		}

		public decimal ValesEmAberto(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select sum(caixa_fluxo.valor) "
				+ "from caixa left join caixa_fluxo on (caixa_fluxo.fechamento = caixa.indice) "
				+ "where caixa.fechamento is null and caixa.situacao = 'A' and caixa_fluxo.situacao <> 'C' and caixa_fluxo.recurso = :codigo and caixa_fluxo.tipo = 'V'");
			com.Parameters.Add(new NpgsqlParameter("codigo", funcionario.Codigo));

			return getDecimal(com);
		}

		public decimal PagamentosEmAberto()
		{
			NpgsqlCommand com = new NpgsqlCommand("select sum(caixa_fluxo.valor) "
				+ "from caixa left join caixa_fluxo on (caixa_fluxo.fechamento = caixa.indice) "
				+ "where caixa.fechamento is null and caixa.situacao = 'A' and caixa_fluxo.situacao <> 'C'  and (caixa_fluxo.tipo = 'P' or caixa_fluxo.tipo = 'V')");

			return getDecimal(com);
		}

		public decimal PagamentosSemFechamento(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select sum(valor) from caixa_fluxo where fechamento is null and recurso = :codigo and (tipo = 'V' or tipo = 'P') and situacao = 'A'");
			com.Parameters.Add(new NpgsqlParameter("codigo", funcionario.Codigo));

			return getDecimal(com);
		}

		public decimal PagamentosSemFechamento()
		{
			return getDecimal("select sum(valor) from caixa_fluxo where fechamento is null and (tipo = 'V' or tipo = 'P') and situacao = 'A'");
		}

		public decimal ValorPago(Pedido pedido)
		{
			return getDecimal(string.Format("select sum(valor) from pagamentos where pedido = {0} and situacao = 'A'", pedido.Numero));
		}

		public long ClienteCodigoAuxiliar(string auxiliar)
		{
			return getLong(string.Format("select codigo from cad_clientes where aux_tel = '{0}'", auxiliar));
		}

		public bool TrocarCliente(Pedido pedido, Cliente cliente)
		{
			return ExecCommand(string.Format("update pedidos set cliente = {0} where indice = {1}", cliente.Codigo, pedido.Numero));
		}

		public int PedidosEmAberto()
		{
			return getInt("select count(indice) from pedidos where situacao not in ('P', 'C')");
		}

		public bool CaixaEstaAberto(Caixa caixa)
		{
			return getBool(string.Format("select aberto from cad_caixa where codigo = {0}", caixa.Codigo));
		}

		public bool AbrirCaixa(Caixa caixa, Usuario usuario)
		{
			return ExecCommand(string.Format("update cad_caixa set aberto = true, aberto_usuario = {0}, aberto_hora = now(), aberto_data = now() where codigo = {1}", usuario.Codigo, caixa.Codigo));
		}

		public bool LogarAberturaDeCaixa(Caixa caixa, Usuario usuario, decimal saldo, decimal entrada)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into log_caixas(caixa, tipo, usuario, saldo, entrada) values(:caixa, 'A', :usuario, :saldo, :entrada);");
			com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("saldo", saldo));
			com.Parameters.Add(new NpgsqlParameter("entrada", entrada));

			return ExecCommand(com);
		}

		public bool LogarFechamentoDeCaixa(Caixa caixa, Usuario usuario, decimal saldo)
		{
			ExecCommand(string.Format("update cad_caixa set aberto = false where codigo = {0}", caixa.Codigo));

			NpgsqlCommand com = new NpgsqlCommand("insert into log_caixas(caixa, tipo, usuario, saldo) values(:caixa, 'F', :usuario, :saldo);");
			com.Parameters.Add(new NpgsqlParameter("caixa", caixa.Codigo));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("saldo", saldo));

			return ExecCommand(com);
		}

		public DataTable ConsultarSaidas(DateTime inicio, DateTime final)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select caixa_fluxo.indice, caixa_fluxo.data, caixa_fluxo.hora, cad_caixa.descricao, "
				+ "caixa_fluxo.valor, caixa_fluxo.observacao, cad_usuarios.nome from caixa_fluxo left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) "
				+ "left join cad_usuarios on (cad_usuarios.codigo = caixa_fluxo.usuario) where caixa_fluxo.data between '{0}' and '{1}' and caixa_fluxo.situacao <> 'C' "
				+ "and caixa_fluxo.tipo = 'S' order by caixa_fluxo.indice", inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd")), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public DataTable ConsultarSaidas(DateTime inicio, DateTime final, Caixa caixa, Usuario usuario)
		{
			if (caixa == null || usuario == null)
			{
				return null;
			}

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select caixa_fluxo.indice, caixa_fluxo.data, caixa_fluxo.hora, cad_caixa.descricao, "
				+ "caixa_fluxo.valor, caixa_fluxo.observacao, cad_usuarios.nome from caixa_fluxo left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) "
				+ "left join cad_usuarios on (cad_usuarios.codigo = caixa_fluxo.usuario) where caixa_fluxo.data between '{0}' and '{1}' and caixa_fluxo.situacao <> 'C' "
				+ "and caixa_fluxo.tipo = 'S' and caixa_fluxo.caixa = {2} and caixa_fluxo.usuario = {3} order by caixa_fluxo.indice"
				, inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"), caixa.Codigo, usuario.Codigo), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public DataTable ConsultarSaidas(DateTime inicio, DateTime final, Caixa caixa)
		{
			if (caixa == null)
			{
				return null;
			}

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select caixa_fluxo.indice, caixa_fluxo.data, caixa_fluxo.hora, cad_caixa.descricao, "
				+ "caixa_fluxo.valor, caixa_fluxo.observacao, cad_usuarios.nome from caixa_fluxo left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) "
				+ "left join cad_usuarios on (cad_usuarios.codigo = caixa_fluxo.usuario) where caixa_fluxo.data between '{0}' and '{1}' and caixa_fluxo.situacao <> 'C' "
				+ "and caixa_fluxo.tipo = 'S' and caixa_fluxo.caixa = {2} order by caixa_fluxo.indice"
				, inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"), caixa.Codigo), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public DataTable ConsultarSaidas(DateTime inicio, DateTime final, Usuario usuario)
		{
			if (usuario == null)
			{
				return null;
			}

			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select caixa_fluxo.indice, caixa_fluxo.data, caixa_fluxo.hora, cad_caixa.descricao, "
				+ "caixa_fluxo.valor, caixa_fluxo.observacao, cad_usuarios.nome from caixa_fluxo left join cad_caixa on (cad_caixa.codigo = caixa_fluxo.caixa) "
				+ "left join cad_usuarios on (cad_usuarios.codigo = caixa_fluxo.usuario) where caixa_fluxo.data between '{0}' and '{1}' and caixa_fluxo.situacao <> 'C' "
				+ "and caixa_fluxo.tipo = 'S' and caixa_fluxo.usuario = {2} order by caixa_fluxo.indice"
				, inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd"), usuario.Codigo), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		#region OrdemDeServico

		public bool InsertOrUpdate(TipoDeServico tipoDeServico)
		{
			ResetarEquipamentos(tipoDeServico);

			NpgsqlCommand com = new NpgsqlCommand("update tipo_de_servico set descricao = :descricao, valor = :valor, custo = :custo where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", tipoDeServico.Codigo));
			com.Parameters.Add(new NpgsqlParameter("descricao", tipoDeServico.Descricao));
			com.Parameters.Add(new NpgsqlParameter("valor", tipoDeServico.Valor));
			com.Parameters.Add(new NpgsqlParameter("custo", tipoDeServico.Custo));

			try
			{
				if (com.ExecuteNonQuery() < 1)
				{
					com.CommandText = "insert into tipo_de_servico (codigo, descricao, valor, custo) values (:codigo, :descricao, :valor, :custo)";

					if (com.ExecuteNonQuery() > 0)
						return true;
					else
						return false;
				}

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e, _usuario);
				MessageBox.Show(e.Message, "DSoft BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public bool ResetarEquipamentos(TipoDeServico tipoDeServico)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from produtos_servicos where servico = :servico");
			com.Parameters.Add(new NpgsqlParameter("servico", tipoDeServico.Codigo));

			ExecCommand(com);

			if (tipoDeServico.Equipamentos != null)
			{
				foreach (Equipamentos equipamento in tipoDeServico.Equipamentos)
				{
					com = new NpgsqlCommand("insert into produtos_servicos (produto, servico, quantidade) values (:produto, :servico, :quantidade);");
					com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
					com.Parameters.Add(new NpgsqlParameter("servico", tipoDeServico.Codigo));
					com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));

					ExecCommand(com);
				}
			}

			return true;
		}

		public void CarregarEquipamentos(TipoDeServico tipoDeServico)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produto, quantidade from produtos_servicos where servico = :servico", Conn);
			com.Parameters.Add(new NpgsqlParameter("servico", tipoDeServico.Codigo));
			NpgsqlDataReader dr = com.ExecuteReader();

			tipoDeServico.Equipamentos = new List<Equipamentos>();

			while (dr.Read())
			{
				Equipamentos equipamento = new Equipamentos();

				equipamento.Produto = CarregarProduto(Convert.ToInt32(dr["produto"]));
				equipamento.Quantidade = (float)Convert.ToDouble(dr["quantidade"]);

				tipoDeServico.Equipamentos.Add(equipamento);
			}
		}

		public DataTable CarregarTiposDeServico()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select codigo, descricao, valor, custo from tipo_de_servico order by codigo", Conn);
			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public List<TipoDeServico> TiposDeServico()
		{
			NpgsqlCommand com = new NpgsqlCommand("select codigo, descricao, valor, custo from tipo_de_servico order by codigo", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<TipoDeServico> tiposDeServico = new List<TipoDeServico>();

			while (dr.Read())
			{
				TipoDeServico servico = new TipoDeServico();

				servico.Codigo = dr["codigo"].ToString();
				servico.Descricao = dr["descricao"].ToString();

				if (dr["valor"].ToString().Length > 0)
				{
					servico.Valor = Convert.ToDecimal(dr["valor"]);
				}

				if (dr["custo"].ToString().Length > 0)
				{
					servico.Custo = Convert.ToDecimal(dr["custo"]);
				}

				CarregarEquipamentos(servico);

				tiposDeServico.Add(servico);
			}

			return tiposDeServico;
		}

		public TipoDeServico CarregarTipoDeServico(string codigo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select descricao, custo, valor from tipo_de_servico where codigo = :codigo", Conn);
			com.Parameters.Add(new NpgsqlParameter("codigo", codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				TipoDeServico tipo = new TipoDeServico();

				tipo.Codigo = codigo;
				tipo.Descricao = dr["descricao"].ToString();

				if (dr["valor"].ToString().Length > 0)
				{
					tipo.Valor = Convert.ToDecimal(dr["valor"]);
				}

				if (dr["custo"].ToString().Length > 0)
				{
					tipo.Custo = Convert.ToDecimal(dr["custo"]);
				}

				CarregarEquipamentos(tipo);

				return tipo;
			}
			else
			{
				return null;
			}
		}

		public DataTable CarregarOS()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select numero, abertura, ordem_de_servico.tipo, tipo_de_servico.descricao as tipo_descricao, "
															+ "status, funcionario, cad_recursos.nome as funcionario_nome, fechamento, periodo, "
															+ "cliente, observacao, ordem_de_servico.usuario, cad_usuarios.nome as usuario_nome "
															+ "from ordem_de_servico left join tipo_de_servico on (tipo_de_servico.codigo = ordem_de_servico.tipo) "
															+ "left join cad_recursos on (ordem_de_servico.funcionario = cad_recursos.codigo) "
															+ "left join cad_usuarios on (ordem_de_servico.usuario = cad_usuarios.codigo) "
															+ "order by ordem_de_servico.numero", Conn);

			DataSet ds = new DataSet();

			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public bool IncluirOS(OrdemDeServico ordemDeServico, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into ordem_de_servico (numero, abertura, tipo, status, funcionario, periodo, cliente, observacao, usuario) "
				+ "values (:numero, :abertura, :tipo, :status, :funcionario, :periodo, :cliente, :observacao, :usuario)");

			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));
			com.Parameters.Add(new NpgsqlParameter("abertura", ordemDeServico.Abertura));
			com.Parameters.Add(new NpgsqlParameter("tipo", ordemDeServico.Tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("status", ordemDeServico.Status));
			com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("periodo", ordemDeServico.Periodo.Id));
			com.Parameters.Add(new NpgsqlParameter("cliente", ordemDeServico.Cliente));
			com.Parameters.Add(new NpgsqlParameter("observacao", ordemDeServico.Observacao));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			if (ExecCommand(com))
			{
				CriarNecessidadesDeEquipamentos(ordemDeServico);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool AlterarOS(OrdemDeServico ordemDeServico, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set abertura = :abertura, tipo = :tipo, status = :status, funcionario = :funcionario, periodo = :periodo, "
				+ "cliente = :cliente, observacao = :observacao, usuario = :usuario where numero = :numero");

			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));
			com.Parameters.Add(new NpgsqlParameter("abertura", ordemDeServico.Abertura));
			com.Parameters.Add(new NpgsqlParameter("tipo", ordemDeServico.Tipo.Codigo));
			com.Parameters.Add(new NpgsqlParameter("status", ordemDeServico.Status));
			com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("periodo", ordemDeServico.Periodo.Id));
			com.Parameters.Add(new NpgsqlParameter("cliente", ordemDeServico.Cliente));
			com.Parameters.Add(new NpgsqlParameter("observacao", ordemDeServico.Observacao));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			return ExecCommand(com);
		}

		public bool CriarNecessidadesDeEquipamentos(OrdemDeServico ordemDeServico)
		{
			List<Equipamentos> equipamentos = new List<Equipamentos>();

			foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
			{
				if (equipamentos.Contains(equipamento))
				{
					equipamentos.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo).Quantidade += equipamento.Quantidade;
				}
				else
				{
					equipamentos.Add(equipamento);
				}
			}

			foreach (Equipamentos equipamento in equipamentos)
			{
				if (ordemDeServico.Funcionario != null)
				{
					NpgsqlCommand com = new NpgsqlCommand("select criar_necessidade_equipamento(:funcionario, :produto, :quantidade);", Conn);
					com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));
					com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
					com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
					getBool(com);
				}
			}

			return true;
		}

		public bool ExcluirNecessidadeEquipamento(Equipamentos equipamento, Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select excluir_necessidade_equipamento(:funcionario, :produto, :quantidade)");
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
			com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));

			return getBool(com);
		}

		public bool BaixarOS(OrdemDeServico ordemDeServico, DateTime data, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set status = 'E', fechamento = :fechamento, fechamento_usuario = :usuario where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("fechamento", data));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));

			return ExecCommand(com);
		}

		public bool BaixarEstoqueOS(OrdemDeServico ordemDeServico, List<Equipamentos> utilizados, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set equipamentos_entregues = true, equipamentos_entregues_usuario = :usuario, equipamentos_entregues_data = now(), equipamentos_entregues_hora = now() "
				+ "where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			if (ExecCommand(com))
			{
				if (ordemDeServico.Funcionario == null)
				{
					if (utilizados == null)
					{
						foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
						{
							com = new NpgsqlCommand("update estoque set quantidade = quantidade - :quantidade where produto = :produto and local = 1");
							com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
							com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

							ExecCommand(com);
						}
					}
					else
					{
						foreach (Equipamentos equipamento in utilizados)
						{
							com = new NpgsqlCommand("update estoque set quantidade = quantidade - :quantidade where produto = :produto and local = 1");
							com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
							com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

							ExecCommand(com);
						}
					}
				}
				else
				{
					if (utilizados == null)
					{
						foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
						{
							com = new NpgsqlCommand("update estoque_funcionarios set quantidade = quantidade - :quantidade where produto = :produto and funcionario = :funcionario");
							com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
							com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
							com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));

							ExecCommand(com);
						}
					}
					else
					{
						foreach (Equipamentos equipamento in utilizados)
						{
							com = new NpgsqlCommand("update estoque_funcionarios set quantidade = quantidade - :quantidade where produto = :produto and funcionario = :funcionario");
							com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
							com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
							com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));

							ExecCommand(com);
						}
					}
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ReabrirOS(OrdemDeServico ordemDeServico, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set status = 'A', fechamento = null, fechamento_usuario = null where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));

			ExecCommand(com);

			CriarNecessidadesDeEquipamentos(ordemDeServico);

			if (ordemDeServico.Funcionario == null)
			{
				foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
				{
					com = new NpgsqlCommand("update estoque set quantidade = quantidade + :quantidade where produto = :produto and local = 1");
					com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
					com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

					ExecCommand(com);
				}
			}
			else
			{
				foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
				{
					com = new NpgsqlCommand("update estoque_funcionarios set quantidade = quantidade + :quantidade where produto = :produto and funcionario = :funcionario");
					com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
					com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
					com.Parameters.Add(new NpgsqlParameter("funcionario", ordemDeServico.Funcionario.Codigo));

					ExecCommand(com);
				}
			}

			return true;
		}

		public bool ReagendarOS(OrdemDeServico ordemDeServico, DateTime data, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set status = 'R', abertura = :data, usuario = :usuario where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("data", data));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));

			return ExecCommand(com);
		}

		public bool CancelarOS(OrdemDeServico ordemDeServico, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set status = 'C', cancelado_usuario = :usuario where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));

			if (ExecCommand(com))
			{
				if (ordemDeServico.Funcionario != null)
				{
					List<Equipamentos> equipamentos = new List<Equipamentos>();

					foreach (Equipamentos equipamento in ordemDeServico.Tipo.Equipamentos)
					{
						if (equipamentos.Contains(equipamento))
						{
							equipamentos.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo).Quantidade += equipamento.Quantidade;
						}
						else
						{
							equipamentos.Add(equipamento);
						}
					}

					foreach (Equipamentos equipamento in equipamentos)
					{
						ExcluirNecessidadeEquipamento(equipamento, ordemDeServico.Funcionario);
					}
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ReativarOS(OrdemDeServico ordemDeServico, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set status = 'A' where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico.Numero));

			return ExecCommand(com);
		}

		public List<Equipamentos> EquipamentosNecessarios(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produto, quantidade from equipamentos_necessarios where funcionario = :funcionario", Conn);
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Equipamentos> equipamentos = new List<Equipamentos>();

			while (dr.Read())
			{
				Equipamentos equipamento = new Equipamentos();
				equipamento.Produto = CarregarProduto(Convert.ToInt64(dr["produto"]));
				equipamento.Quantidade = (float)Convert.ToDouble(dr["quantidade"]);

				if (equipamentos.Contains(equipamento))
				{
					equipamentos.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo).Quantidade += equipamento.Quantidade;
				}
				else
				{
					equipamentos.Add(equipamento);
				}
			}

			return equipamentos;
		}

		public List<Equipamentos> EquipamentosNecessarios(long numero)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produtos_servicos.produto, produtos_servicos.quantidade from ordem_de_servico left join produtos_servicos on (produtos_servicos.servico = ordem_de_servico.tipo) "
				+ "where ordem_de_servico.numero = :numero", Conn);
			com.Parameters.Add(new NpgsqlParameter("numero", numero));
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Equipamentos> equipamentos = new List<Equipamentos>();

			while (dr.Read())
			{
				Equipamentos equipamento = new Equipamentos();
				equipamento.Produto = CarregarProduto(Convert.ToInt64(dr["produto"]));
				equipamento.Quantidade = (float)Convert.ToDouble(dr["quantidade"]);

				equipamentos.Add(equipamento);
			}

			return equipamentos;
		}

		public List<Equipamentos> EquipamentosNecessariosReal(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select tipo from ordem_de_servico where equipamentos_entregues = false and funcionario = :funcionario", Conn);
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			List<Equipamentos> equipamentos = new List<Equipamentos>();

			List<TipoDeServico> servicos = TiposDeServico();

			while (dr.Read())
			{
				TipoDeServico servico = servicos.First(s => s.Codigo == dr["tipo"].ToString());

				if (servico != null)
				{
					foreach (Equipamentos equipamento in servico.Equipamentos)
					{
						if (equipamentos.Contains(equipamento))
						{
							equipamentos.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo).Quantidade += equipamento.Quantidade;
						}
						else
						{
							equipamentos.Add(equipamento);
						}
					}
				}
			}

			return equipamentos;
		}

		public bool EntregarEquipamentos(Recurso funcionario, List<Equipamentos> equipamentos, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set equipamentos_entregues = true, equipamentos_entregues_usuario = :usuario, "
				+ "equipamentos_entregues_data = now(), equipamentos_entregues_hora = now() where (status = 'A' or status = 'R') and funcionario = :funcionario");
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));

			ExecCommand(com);

			//Baixa no estoque e lança entrega do produto
			foreach (Equipamentos equipamento in equipamentos)
			{
				com = new NpgsqlCommand("update estoque set quantidade = quantidade - :quantidade where produto = :produto and local = 1");
				com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
				com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

				ExecCommand(com);

				LancaEstoqueFuncionario(funcionario, equipamento, usuario);

				ExcluirNecessidadeEquipamento(equipamento, funcionario);

				if (equipamento.Id != string.Empty)
				{
					com = new NpgsqlCommand("update cad_equipamentos set status = 'E' where id = :id");
					com.Parameters.Add(new NpgsqlParameter("id", equipamento.Id));
					ExecCommand(com);
				}
			}

			return true;
		}

		public bool ConfirmarUsoEquipamentos(Recurso funcionario, long ordemDeServico, List<Equipamentos> equipamentos, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set equipamentos_entregues = true, equipamentos_entregues_usuario = :usuario, "
				+ "equipamentos_entregues_data = now(), equipamentos_entregues_hora = now() where numero = :numero");
			com.Parameters.Add(new NpgsqlParameter("numero", ordemDeServico));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			if (funcionario != null && ExecCommand(com))
			{
				foreach (Equipamentos equipamento in equipamentos)
				{
					com = new NpgsqlCommand("select confirmar_uso_equipamento(:funcionario, :produto, :quantidade);");
					com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
					com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
					com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));

					ExecCommand(com);
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		public bool AbaterNecessidadeEquipamentos(Recurso funcionario, List<Equipamentos> equipamentos, Usuario usuario)
		{
			foreach (Equipamentos equipamento in equipamentos)
			{
				NpgsqlCommand com = new NpgsqlCommand("select abater_necessidades_equipamentos(:funcionario, :produto, :quantidade);");
				com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
				com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));

				ExecCommand(com);
			}

			return true;
		}

		public bool EntregarEquipamento(Recurso funcionario, Equipamentos equipamento, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update estoque set quantidade = quantidade - :quantidade where produto = :produto and local = 1");
			com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

			ExecCommand(com);

			LancaEstoqueFuncionario(funcionario, equipamento, usuario);

			ExcluirNecessidadeEquipamento(equipamento, funcionario);

			return true;
		}

		public void LancaEstoqueFuncionario(Recurso funcionario, Equipamentos equipamento, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select indice from estoque_funcionarios where funcionario = :funcionario and produto = :produto");
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

			if (getInt(com) > 0)
			{
				com = new NpgsqlCommand("update estoque_funcionarios set quantidade = quantidade + :quantidade where funcionario = :funcionario and produto = :produto");
				com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
				com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

				ExecCommand(com);
			}
			else
			{
				com = new NpgsqlCommand("insert into estoque_funcionarios(funcionario, produto, quantidade) values (:funcionario, :produto, :quantidade)");
				com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
				com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

				ExecCommand(com);
			}

			com = new NpgsqlCommand("select entregar_equipamento_funcionario (:funcionario, :produto, :equipamento, :quantidade, :usuario)");
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
			com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
			com.Parameters.Add(new NpgsqlParameter("equipamento", equipamento.Id));
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			getBool(com);
		}

		public List<Equipamentos> EstoqueFuncionario(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produto, quantidade from estoque_funcionarios where funcionario = :funcionario", Conn);
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Equipamentos> estoque = new List<Equipamentos>();

			while (dr.Read())
			{
				Equipamentos equipamento = new Equipamentos();
				equipamento.Produto = CarregarProduto(Convert.ToInt64(dr["produto"]));
				equipamento.Quantidade = (float)Convert.ToDouble(dr["quantidade"]);
				estoque.Add(equipamento);
			}

			return estoque;
		}

		public List<PagamentoFuncionario> GerarPagamentos(DateTime inicial, DateTime final)
		{
			List<TipoDeServico> servicos = TiposDeServico();

			NpgsqlCommand com = new NpgsqlCommand("select codigo from cad_recursos where situacao = 'A' order by codigo", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<PagamentoFuncionario> pagamentos = new List<PagamentoFuncionario>();

			while (dr.Read())
			{
				PagamentoFuncionario pagamento = new PagamentoFuncionario();
				pagamento.Funcionario = CarregarRecurso(Convert.ToInt32(dr[0]));

				NpgsqlCommand com2 = new NpgsqlCommand("select tipo, numero from ordem_de_servico where pago = false and status = 'E' and funcionario = :funcionario "
					+ "and fechamento between :inicio and :final", Conn);
				com2.Parameters.Add(new NpgsqlParameter("funcionario", Convert.ToInt32(dr[0])));
				com2.Parameters.Add(new NpgsqlParameter("inicio", inicial));
				com2.Parameters.Add(new NpgsqlParameter("final", final));
				NpgsqlDataReader dr2 = com2.ExecuteReader();

				pagamento.OrdensDeServico = new List<int>();

				while (dr2.Read())
				{
					TipoDeServico servico = servicos.FirstOrDefault(s => s.Codigo == dr2[0].ToString());

					pagamento.Valor += servico.Custo;
					pagamento.OrdensDeServico.Add(Convert.ToInt32(dr2[1]));
				}

				pagamento.Observacao = string.Format("{0} serviços executados entre {1} e {2}.", pagamento.OrdensDeServico.Count, inicial.ToShortDateString(), final.ToShortDateString());

				pagamentos.Add(pagamento);
			}

			return pagamentos;
		}

		public bool EfetuarPagamento(PagamentoFuncionario pagamento, Usuario usuario)
		{
			foreach (int numero in pagamento.OrdensDeServico)
			{
				NpgsqlCommand com = new NpgsqlCommand("update ordem_de_servico set pago = true, pago_usuario = :usuario, pago_data = now() where numero = :numero");
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("numero", numero));
				ExecCommand(com);
			}

			if (pagamento.Valor > 0)
			{
				NpgsqlCommand com2 = new NpgsqlCommand("insert into caixa_fluxo (tipo, caixa, valor, usuario, recurso, observacao) "
					+ "values ('P', 1, :valor, :usuario, :recurso, :observacao)");
				com2.Parameters.Add(new NpgsqlParameter("valor", pagamento.Valor));
				com2.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com2.Parameters.Add(new NpgsqlParameter("recurso", pagamento.Funcionario.Codigo));
				com2.Parameters.Add(new NpgsqlParameter("observacao", pagamento.Observacao));

				return ExecCommand(com2);
			}

			return true;
		}

		public bool ReceberEquipamentos(Equipamentos equipamento, Usuario usuario)
		{
			if (equipamento.Id != string.Empty)
			{
				NpgsqlCommand com_add = new NpgsqlCommand("select incluir_novo_equipamento(:produto, :id, :usuario);");
				com_add.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
				com_add.Parameters.Add(new NpgsqlParameter("id", equipamento.Id));
				com_add.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

				//if (getBool(com_add) == false)
				//{
				//    return false;
				//}

				getBool(com_add);
			}

			NpgsqlCommand com = new NpgsqlCommand("update estoque set quantidade = quantidade + :quantidade where produto = :produto and local = 1");
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));
			com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));

			return ExecCommand(com);
		}

		public bool Delete(Equipamentos equipamento, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("update estoque set quantidade = quantidade - :quantidade where produto = :produto and local = 1");
			com.Parameters.Add(new NpgsqlParameter("quantidade", equipamento.Quantidade));
			com.Parameters.Add(new NpgsqlParameter("produto", equipamento.Produto.Codigo));

			if (ExecCommand(com) == false)
			{
				return false;
			}

			com = new NpgsqlCommand("insert into log_equipamentos(equipamento, evento, usuario) values (:equipamento, :evento, :usuario);");
			com.Parameters.Add(new NpgsqlParameter("equipamento", equipamento.Id));
			com.Parameters.Add(new NpgsqlParameter("evento", "D"));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

			ExecCommand(com);

			com = new NpgsqlCommand("delete from cad_equipamentos where id = :id;");
			com.Parameters.Add(new NpgsqlParameter("id", equipamento.Id));

			return ExecCommand(com);
		}

		public DataTable ConsultaServicosEfetuados(DateTime inicio, DateTime final)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select numero, tipo_de_servico.descricao, tipo_de_servico.custo, tipo_de_servico.valor, abertura, fechamento, observacao "
				+ "from ordem_de_servico left join tipo_de_servico on (tipo_de_servico.codigo = ordem_de_servico.tipo) where fechamento between '{0}' and '{1}' order by ordem_de_servico.indice",
				inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd")), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public DataTable ConsultaServicosPorFuncionarios(DateTime inicio, DateTime final)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select funcionario, cad_recursos.nome, count(ordem_de_servico.indice) as quantidade, sum(tipo_de_servico.custo) as custos, sum(tipo_de_servico.valor) as valores "
				+ "from ordem_de_servico "
				+ "left join tipo_de_servico on (tipo_de_servico.codigo = ordem_de_servico.tipo) "
				+ "left join cad_recursos on (cad_recursos.codigo = ordem_de_servico.funcionario) "
				+ "where fechamento between '{0}' and '{1}' "
				+ "group by cad_recursos.nome, funcionario", inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd")), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public DataTable ConsultaServicosPorFuncionario(Recurso funcionario, DateTime inicio, DateTime final)
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter(string.Format("select ordem_de_servico.fechamento, tipo_de_servico.descricao, tipo_de_servico.custo, tipo_de_servico.valor "
				+ "from ordem_de_servico left join tipo_de_servico on (ordem_de_servico.tipo = tipo_de_servico.codigo) where fechamento between '{0}' and '{1}' order by ordem_de_servico.indice",
				inicio.ToString("yyyy-MM-dd"), final.ToString("yyyy-MM-dd")), Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public List<Equipamentos> CarregarEquipamentos(Produto produto)
		{
			NpgsqlCommand com = new NpgsqlCommand("select id, quantidade from cad_equipamentos where produto = :produto and status = 'A'", Conn);
			com.Parameters.Add(new NpgsqlParameter("produto", produto.Codigo));
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Equipamentos> equipamentos = new List<Equipamentos>();

			while (dr.Read())
			{
				Equipamentos equipamento = new Equipamentos();
				equipamento.Produto = produto;
				equipamento.Id = dr[0].ToString();
				equipamento.Quantidade = dr["quantidade"].ToString().Length > 0 ? (float)Convert.ToDouble(dr["quantidade"]) : 0;

				equipamentos.Add(equipamento);
			}

			return equipamentos;
		}

		public Equipamentos CarregarEquipamento(string id)
		{
			NpgsqlCommand com = new NpgsqlCommand("select produto from cad_equipamentos where id = :id and status = 'A'");
			com.Parameters.Add(new NpgsqlParameter("id", id));

			long codigo = getLong(com);

			if (codigo > 0)
			{
				Produto produto = CarregarProduto(codigo);

				if (produto != null)
				{
					Equipamentos equipamento = new Equipamentos();
					equipamento.Id = id;
					equipamento.Produto = produto;
					equipamento.Quantidade = 1;

					return equipamento;
				}
			}

			return null;
		}

		public bool InsertOrUpdate(Cliente cliente)
		{
			NpgsqlCommand com = new NpgsqlCommand("select nome from cad_clientes where codigo = :codigo");
			com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));

			string comando;

			if (getString(com).Length > 0)
			{
				comando = "update cad_clientes set nome = :nome, cep = :cep, numero = :numero, tel1 = :telefone, endereco = :endereco, bairro = :bairro, cidade = :cidade, estado = :estado "
					+ "where codigo = :codigo";
			}
			else
			{
				comando = "insert into cad_clientes(codigo, nome, cep, numero, tel1, endereco, bairro, cidade, estado) values (:codigo, :nome, :cep, :numero, :telefone, :endereco, :bairro, :cidade, :estado);";
			}

			com = new NpgsqlCommand(comando);

			com.Parameters.Add(new NpgsqlParameter("nome", cliente.Nome));
			com.Parameters.Add(new NpgsqlParameter("cep", cliente.Cep));
			com.Parameters.Add(new NpgsqlParameter("numero", cliente.Numero));
			com.Parameters.Add(new NpgsqlParameter("telefone", cliente.Telefone1));
			com.Parameters.Add(new NpgsqlParameter("endereco", cliente.Endereco));
			com.Parameters.Add(new NpgsqlParameter("bairro", cliente.Bairro));
			com.Parameters.Add(new NpgsqlParameter("cidade", cliente.Cidade));
			com.Parameters.Add(new NpgsqlParameter("estado", cliente.Estado));
			com.Parameters.Add(new NpgsqlParameter("codigo", cliente.Codigo));

			return ExecCommand(com);
		}

		public DataTable CarregarPeriodos()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select id, descricao, inicial, final from cad_periodos order by inicial", Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}

			return null;
		}

		public List<Periodo> Periodos()
		{
			NpgsqlCommand com = new NpgsqlCommand("select id, descricao, inicial, final from cad_periodos order by inicial", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Periodo> periodos = new List<Periodo>();

			while (dr.Read())
			{
				Periodo periodo = new Periodo();

				periodo.Id = dr["id"].ToString();
				periodo.Descricao = dr["descricao"].ToString();
				periodo.Inicio = Convert.ToDateTime(dr["inicial"]);
				periodo.Final = Convert.ToDateTime(dr["final"]);

				periodos.Add(periodo);
			}

			return periodos;
		}

		public bool InsertOrUpdate(Periodo periodo)
		{
			NpgsqlCommand com = new NpgsqlCommand("select descricao from cad_periodos where id = :id");
			com.Parameters.Add(new NpgsqlParameter("id", periodo.Id));

			string comando = string.Empty;

			if (getString(com) == string.Empty)
			{
				comando = "insert into cad_periodos(id, descricao, inicial, final) values (:id, :descricao, :inicial, :final);";
			}
			else
			{
				comando = "update cad_periodos set descricao = :descricao, inicial = :inicial, final = :final where id = :id;";
			}

			com = new NpgsqlCommand(comando);
			
			com.Parameters.Add(new NpgsqlParameter("id", periodo.Id));
			com.Parameters.Add(new NpgsqlParameter("descricao", periodo.Descricao));
			com.Parameters.Add(new NpgsqlParameter("inicial", periodo.Inicio));
			com.Parameters.Add(new NpgsqlParameter("final", periodo.Final));

			return ExecCommand(com);
		}

		public bool Delete(Periodo periodo)
		{
			NpgsqlCommand com = new NpgsqlCommand("delete from cad_periodos where id = :id");
			com.Parameters.Add(new NpgsqlParameter("id", periodo.Id));
			return ExecCommand(com);
		}

		public List<long> CarregarOSNaoEntregues(Recurso funcionario)
		{
			NpgsqlCommand com = new NpgsqlCommand("select numero from ordem_de_servico where funcionario = :funcionario and equipamentos_entregues = false order by numero;", Conn);
			com.Parameters.Add(new NpgsqlParameter("funcionario", funcionario.Codigo));

			NpgsqlDataReader dr = com.ExecuteReader();

			List<long> os = new List<long>();

			while (dr.Read())
			{
				os.Add(Convert.ToInt64(dr[0]));
			}

			return os;
		}

		public bool EnviarEquipamentos(Filial filial, List<Equipamentos> equipamentos, Usuario usuario)
		{
			foreach (Equipamentos equipamento in equipamentos)
			{
				NpgsqlCommand com = new NpgsqlCommand("select enviar_equipamento_filial(:filial, :equipamento, :usuario);");
				com.Parameters.Add(new NpgsqlParameter("filial", filial.Codigo));
				com.Parameters.Add(new NpgsqlParameter("equipamento", equipamento.Id));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));

				if (getBool(com) == false)
				{
					return false;
				}
			}

			return true;
		}

		#endregion OrdemDeServico

		#region DSoftManager

		public bool TableExists(string tableName)
		{
			return getBool(string.Format("select true from pg_tables where tablename = '{0}'", tableName));
		}

		public bool InsertOrUpdate(Lead lead, Usuario usuario)
		{
			if (lead.Indice > 0 && getInt(string.Format("select count(indice) from cad_leads where indice = {0}", lead.Indice)) > 0)
			{
				return AlterarLead(lead, usuario);
			}
			else
			{
				return IncluirLead(lead, usuario);
			}
		}

		public bool AlterarLead(Lead lead, Usuario usuario)
		{
			if (lead.Indice > 0)
			{
				NpgsqlCommand com = new NpgsqlCommand("update cad_leads set nome = :nome, endereco = :endereco, numero = :numero, bairro = :bairro, cidade = :cidade, estado = :estado, pais = :pais, cep = :cep, "
					+ "tel1 = :tel1, tel2 = :tel2, celular = :celular, contato = :contato, ramo = :ramo, origem = :origem, usuario = :usuario, obs = :obs, situacao = :situacao where indice = :indice");

				com.Parameters.Add(new NpgsqlParameter("nome", lead.Nome));
				com.Parameters.Add(new NpgsqlParameter("endereco", lead.Endereco));
				com.Parameters.Add(new NpgsqlParameter("numero", lead.Numero));
				com.Parameters.Add(new NpgsqlParameter("bairro", lead.Bairro));
				com.Parameters.Add(new NpgsqlParameter("cidade", lead.Cidade));
				com.Parameters.Add(new NpgsqlParameter("estado", lead.Estado));
				com.Parameters.Add(new NpgsqlParameter("pais", lead.Pais));
				com.Parameters.Add(new NpgsqlParameter("cep", lead.Cep));
				com.Parameters.Add(new NpgsqlParameter("tel1", lead.Tel1));
				com.Parameters.Add(new NpgsqlParameter("tel2", lead.Tel2));
				com.Parameters.Add(new NpgsqlParameter("celular", lead.Celular));
				com.Parameters.Add(new NpgsqlParameter("contato", lead.Contato));
				com.Parameters.Add(new NpgsqlParameter("ramo", lead.Ramo));
				com.Parameters.Add(new NpgsqlParameter("origem", lead.Origem));
				com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
				com.Parameters.Add(new NpgsqlParameter("obs", lead.Observacao));
				com.Parameters.Add(new NpgsqlParameter("indice", lead.Indice));
				com.Parameters.Add(new NpgsqlParameter("situacao", lead.Situacao.ToString()));

				return ExecCommand(com);
			}
			else
			{
				if (!ExistsName(lead))
				{
					return IncluirLead(lead, usuario);
				}
				else
				{
					return false;
				}
			}
		}

		public bool ExistsName(Lead lead)
		{
			return getInt(string.Format("select indice from cad_leads where nome = '{0}'", lead.Nome)) > 0;
		}

		public bool IncluirLead(Lead lead, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into cad_leads (nome, endereco, numero, bairro, cidade, estado, pais, cep, tel1, tel2, celular, contato, ramo, origem, usuario, obs, situacao) "
				+ "values (:nome, :endereco, :numero, :bairro, :cidade, :estado, :pais, :cep, :tel1, :tel2, :celular, :contato, :ramo, :origem, :usuario, :obs, :situacao) returning indice");
			com.Parameters.Add(new NpgsqlParameter("nome", lead.Nome));
			com.Parameters.Add(new NpgsqlParameter("endereco", lead.Endereco));
			com.Parameters.Add(new NpgsqlParameter("numero", lead.Numero));
			com.Parameters.Add(new NpgsqlParameter("bairro", lead.Bairro));
			com.Parameters.Add(new NpgsqlParameter("cidade", lead.Cidade));
			com.Parameters.Add(new NpgsqlParameter("estado", lead.Estado));
			com.Parameters.Add(new NpgsqlParameter("pais", lead.Pais));
			com.Parameters.Add(new NpgsqlParameter("cep", lead.Cep));
			com.Parameters.Add(new NpgsqlParameter("tel1", lead.Tel1));
			com.Parameters.Add(new NpgsqlParameter("tel2", lead.Tel2));
			com.Parameters.Add(new NpgsqlParameter("celular", lead.Celular));
			com.Parameters.Add(new NpgsqlParameter("contato", lead.Contato));
			com.Parameters.Add(new NpgsqlParameter("ramo", lead.Ramo));
			com.Parameters.Add(new NpgsqlParameter("origem", lead.Origem));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("obs", lead.Observacao));
			com.Parameters.Add(new NpgsqlParameter("situacao", lead.Situacao.ToString()));

			return (lead.Indice = getInt(com)) > 0;
		}

		public Lead CarregarLead(int indice)
		{
			if (indice < 1)
				return null;

			NpgsqlCommand com = new NpgsqlCommand("select * from cad_leads where indice = :indice", Conn);
			com.Parameters.Add(new NpgsqlParameter("indice", indice));

			Lead lead = new Lead();
			lead.Indice = indice;

			NpgsqlDataReader dr = com.ExecuteReader();

			if (dr.Read())
			{
				lead.Nome = dr["nome"].ToString();
				lead.Endereco = dr["endereco"].ToString();
				lead.Numero = dr["numero"].ToString();
				lead.Bairro = dr["bairro"].ToString();
				lead.Cidade = dr["cidade"].ToString();
				lead.Estado = dr["estado"].ToString();
				lead.Pais = dr["pais"].ToString();
				lead.Cep = dr["cep"].ToString();
				lead.Tel1 = Util.TryParseLong(dr["tel1"].ToString());
				lead.Tel2 = Util.TryParseLong(dr["tel2"].ToString());
				lead.Celular = Util.TryParseLong(dr["celular"].ToString());
				lead.Contato = dr["contato"].ToString();
				lead.Ramo = dr["ramo"].ToString();
				lead.Origem = dr["origem"].ToString();
				lead.Observacao = dr["obs"].ToString();
				lead.Situacao = Util.TryGetChar(dr["situacao"]);
			}

			return lead;
		}

		public DataTable CarregarLeads()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select indice, nome, endereco, numero, bairro, cidade, estado, pais, cep, tel1, tel2, celular, contato, ramo, origem, obs, situacao from cad_leads order by indice", Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public List<Lead> LeadsAtivos()
		{
			NpgsqlCommand com = new NpgsqlCommand("select indice from cad_leads where situacao in ('A', '1', '2', '3') order by indice", Conn);
			NpgsqlDataReader dr = com.ExecuteReader();

			List<Lead> leads = new List<Lead>();

			while (dr.Read())
			{
				Lead lead = CarregarLead(Convert.ToInt32(dr[0]));

				if (lead != null)
				{
					leads.Add(lead);
				}
			}

			return leads;
		}

		public bool IncluirContactLog(ContactLog log, Usuario usuario)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into contacts_log (data, hora, usuario, lead, motivo, descricao, conclusao, retorno, retorno_hora, temperatura) values "
				+ "(:data, :hora, :usuario, :lead, :motivo, :descricao, :conclusao, :retorno, :retorno_hora, :temperatura) returning indice", Conn);

			com.Parameters.Add(new NpgsqlParameter("data", log.Data));
			com.Parameters.Add(new NpgsqlParameter("hora", log.Hora));
			com.Parameters.Add(new NpgsqlParameter("usuario", usuario.Codigo));
			com.Parameters.Add(new NpgsqlParameter("lead", log.Lead.Indice));
			com.Parameters.Add(new NpgsqlParameter("motivo", log.Motivo));
			com.Parameters.Add(new NpgsqlParameter("descricao", log.Descricao));
			com.Parameters.Add(new NpgsqlParameter("conclusao", log.Conclusao));
			com.Parameters.Add(new NpgsqlParameter("temperatura", ((char)log.Temperatura).ToString()));

			if (log.Retorno)
			{
				com.Parameters.Add(new NpgsqlParameter("retorno", log.RetornoData));
				com.Parameters.Add(new NpgsqlParameter("retorno_hora", log.RetornoHora));
			}
			else
			{
				com.Parameters.Add(new NpgsqlParameter("retorno", null));
				com.Parameters.Add(new NpgsqlParameter("retorno_hora", null));
			}

			if ((log.Indice = getInt(com)) > 0)
			{
				AjustarTemperaturaLead(log.Lead, log.Temperatura);

				return true;
			}
			else
			{
				return false;
			}
		}

		public void AjustarTemperaturaLead(Lead lead, Temperaturas temperatura)
		{
			ExecCommand(string.Format("update cad_leads set situacao = '{0}' where indice = {1}", (char)temperatura, lead.Indice));
		}

		public DataTable CarregarContactsLog()
		{
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("select contacts_log.indice, data, hora, lead, cad_leads.nome, motivo, descricao, conclusao, retorno, retorno_hora, temperatura, contacts_log.situacao, contacts_log.usuario from contacts_log "
				+ " left join cad_leads on (cad_leads.indice = contacts_log.lead) order by contacts_log.indice", Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			if (ds != null && ds.Tables.Count > 0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}

		public bool CriarAlerta(Alerta alerta)
		{
			NpgsqlCommand com = new NpgsqlCommand("insert into alertas (usuario_origem, usuario_destino, data, hora, lead, titulo, observacao) "
				+ "values (:usuario_origem, :usuario_destino, :data, :hora, :lead, :titulo, :observacao)");
			com.Parameters.Add(new NpgsqlParameter("usuario_origem", alerta.UsuarioOrigem.Codigo));
			com.Parameters.Add(new NpgsqlParameter("usuario_destino", alerta.UsuarioDestino.Codigo));
			com.Parameters.Add(new NpgsqlParameter("data", alerta.Data));
			com.Parameters.Add(new NpgsqlParameter("hora", alerta.Hora));
			com.Parameters.Add(new NpgsqlParameter("lead", alerta.Lead.Indice));
			com.Parameters.Add(new NpgsqlParameter("titulo", alerta.Titulo));
			com.Parameters.Add(new NpgsqlParameter("observacao", alerta.Observacao));

			return ExecCommand(com);
		}

		#endregion DSoftManager

		#endregion Methods
	}
}