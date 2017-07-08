using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DSoftBd;
using DSoftModels;
using DSoftParameters;
using DSoftCore;
using DSoft_Delivery.Relatorios;

namespace DSoft_Delivery
{
	public partial class CadClientes : Form
	{
		#region Fields

		public long? Codigo;
		public bool Consulta = false;
		public bool Editando = false;
		public string sCodigo;

		private Cliente _cliente;
		private Bd _dsoftBd;
		private Usuario _usuario;
		private ILicenca _licenca;

		private List<Recurso> _recursos;

		public Cliente Cliente
		{
			get
			{
				return _cliente;
			}
		}

		#endregion Fields

		#region Constructors

		public CadClientes(Bd bd, Usuario usuario, ILicenca licenca)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_licenca = licenca;
		}

		public CadClientes(Bd bd, Usuario usuario, ILicenca licenca, long? codigo = null, bool consulta = false, string scodigo = null)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_licenca = licenca;

			Codigo = codigo;
			Consulta = consulta;
			sCodigo = scodigo;
		}

		#endregion Constructors

		#region Methods

		private bool AlterarCliente()
		{
			try
			{
				_cliente = new Cliente();

				if (!long.TryParse(tbCodigo.Text, out _cliente.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!");

					return false;
				}

				_cliente.Nome = tbNome.Text;
				_cliente.Nascimento = dtNascimento.Value;

				if (cbTipo.Text != string.Empty && (cbTipo.Text[0] == 'F' || cbTipo.Text[0] == 'J'))
				{
					_cliente.Tipo = cbTipo.Text[0];
				}

				_cliente.Documento = mbDocumento.Text;
				_cliente.Rg = mbRG.Text;

				_cliente.InscricaoEstadual = tbInscricaoEstadual.Text;
				_cliente.InscricaoSuframa = tbInscricaoSuframa.Text;

				if (cbTipoCliente.SelectedItem == null)
				{
					MessageBox.Show("Selecione um Tipo para o cliente!");
					return false;
				}

				_cliente.ClienteTipo = (ClienteTipo)cbTipoCliente.SelectedItem;

				int.TryParse(cbGrupo.Text.Split(" - ".ToCharArray(), 2)[0], out _cliente.Grupo);

				if (tbTelefone1.Text != string.Empty && !long.TryParse(tbTelefone1.Text, out _cliente.Telefone1))
				{
					MessageBox.Show("Campo 'telefone 1' deve ser numérico!");

					tbTelefone1.SelectAll();

					tbTelefone1.Focus();

					return false;
				}

				if (tbTelefone2.Text != string.Empty && !long.TryParse(tbTelefone2.Text, out _cliente.Telefone2))
				{
					MessageBox.Show("Campo 'telefone 2' deve ser numérico!");

					tbTelefone2.SelectAll();

					tbTelefone2.Focus();

					return false;
				}

				if (tbCelular.Text != string.Empty && !long.TryParse(tbCelular.Text, out _cliente.Celular))
				{
					MessageBox.Show("Campo 'celular' deve ser numérico!");

					tbCelular.SelectAll();

					tbCelular.Focus();

					return false;
				}

				_cliente.Endereco = tbEndereco.Text;
				_cliente.Numero = tbNumero.Text;
				_cliente.Bairro = tbBairro.Text;

				if (tbCidade.Text.Length > 0)
				{
					if (_dsoftBd.CodigoMunicipio(tbCidade.Text) < 0)
					{
						tbCidade.SelectAll();
						tbCidade.Focus();
						return false;
					}
				}

				_cliente.Cidade = tbCidade.Text;

				_cliente.Estado = cbEstado.Text;
				_cliente.Pais = tbPais.Text;

				_cliente.Cep = mtCep.Text;

				// Validamos a IE
				//if (cliente.InscricaoEstadual.Length > 0 && cliente.Estado.Length > 0)
				//{
				//    if (!ValidadorIE.Validar(cliente.InscricaoEstadual, cliente.Estado.Substring(0, 2)))
				//    {
				//        MessageBox.Show("Inscrição Estadual inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//        tbInscricaoEstadual.SelectAll();
				//        tbInscricaoEstadual.Focus();
				//        return false;
				//    }
				//}

				_cliente.Referencia = tbReferencia.Text;
				_cliente.Observacao = tbObservacao.Text;

				_cliente.Pai = tbPai.Text;
				_cliente.Mae = tbMae.Text;
				_cliente.Conjuge = tbConjuge.Text;
				_cliente.Profissao = tbProfissao.Text;
				_cliente.Contato = tbContato.Text;
				_cliente.Email = tbEmail.Text;
				_cliente.Site = tbSite.Text;

				decimal taxa_de_entrega;
				decimal.TryParse(tbTaxaDeEntrega.Text, out taxa_de_entrega);
				_cliente.TaxaDeEntrega = taxa_de_entrega;

				int vencimento;
				int.TryParse(tbVencimentoMensalidade.Text, out vencimento);
				_cliente.VencimentoMensalidade = vencimento;

				decimal valor;
				decimal.TryParse(tbValorMensalidade.Text, out valor);
				_cliente.ValorMensalidade = valor;

				if (!double.TryParse(tbLimite.Text, out _cliente.Limite))
				{
					_cliente.Limite = 0;
				}

				if (cbTabelaPrecos.Text == "")
				{
					_cliente.Tabela = null;
				}
				else
				{
					if (cbTabelaPrecos.Text == "[Nova]")
					{
						_cliente.Tabela = GravarNovaTabelaPrecos();
					}
					else
					{
						_cliente.Tabela = Convert.ToInt32(cbTabelaPrecos.Text.Split(" - ".ToCharArray())[0]);
					}
				}

				_cliente.Funcionario = cbFuncionario.SelectedItem as Recurso;

				if (_dsoftBd.AlterarCliente(_cliente) && _dsoftBd.ClienteLimite(_cliente.Codigo, _cliente.Limite))
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
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void Atualizar(Cliente cliente)
		{
			for (int i = 0; i < dgClientes.Rows.Count; i++)
			{
				if (dgClientes["codigo", i].Value.ToString() == cliente.Codigo.ToString())
				{
					dgClientes["nome", i].Value = cliente.Nome;
					dgClientes["tel1", i].Value = cliente.Telefone1;
					dgClientes["tel2", i].Value = cliente.Telefone2;
					dgClientes["celular", i].Value = cliente.Celular;
					dgClientes["endereco", i].Value = cliente.Endereco;
					dgClientes["bairro", i].Value = cliente.Bairro;
					dgClientes["cidade", i].Value = cliente.Cidade;
					dgClientes["estado", i].Value = cliente.Estado;
					dgClientes["situacao", i].Value = cliente.Situacao;
					dgClientes["observacao", i].Value = cliente.Observacao;

					if (cliente.Situacao == 'A')
					{
						dgClientes.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgClientes.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
					}
					else if (cliente.Situacao == 'C')
					{
						dgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgClientes.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}

					break;
				}
			}
		}

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarClientes(ds);

			dgClientes.DataSource = ds.Tables[0];

			dgClientes.Columns["codigo"].Width = 60;
			dgClientes.Columns["nome"].Width = 180;
			dgClientes.Columns["tel1"].Width = 60;
			dgClientes.Columns["tel2"].Width = 60;
			dgClientes.Columns["celular"].Width = 60;
			dgClientes.Columns["endereco"].Width = 180;
			dgClientes.Columns["bairro"].Width = 90;
			dgClientes.Columns["cidade"].Width = 90;
			dgClientes.Columns["estado"].Width = 60;
			dgClientes.Columns["situacao"].Width = 60;

			Util.Pintar(ref dgClientes);

			CarregarClientesTipos();
			CarregarGrupos();

			cbTipo.Text = cbTipo.Items[0].ToString();
		}

		private void Atualizar(string filtro)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarClientes(ds, filtro);

			dgClientes.DataSource = ds.Tables[0];

			dgClientes.Columns["codigo"].Width = 60;
			dgClientes.Columns["nome"].Width = 180;
			dgClientes.Columns["tel1"].Width = 60;
			dgClientes.Columns["tel2"].Width = 60;
			dgClientes.Columns["celular"].Width = 60;
			dgClientes.Columns["endereco"].Width = 180;
			dgClientes.Columns["bairro"].Width = 90;
			dgClientes.Columns["cidade"].Width = 90;
			dgClientes.Columns["estado"].Width = 60;
			dgClientes.Columns["situacao"].Width = 60;

			for (int i = 0; i < dgClientes.Rows.Count; i++)
			{
				switch (dgClientes.Rows[i].Cells["situacao"].Value.ToString())
				{
					case "A":
						dgClientes.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgClientes.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dgClientes.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgClientes.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
				}
			}

			//CarregarGrupos();

			//cbTipo.Text = cbTipo.Items[0].ToString();
		}

		private void Bloquear()
		{
			try
			{
				if (!btBloquear.Enabled)
				{
					return;
				}

				if (btBloquear.Text == "&Bloquear")
				{
					if (_dsoftBd.BloquearCliente(int.Parse(tbCodigo.Text)))
					{
						Atualizar();

						LimparDados();
					}
				}
				else
				{
					if (_dsoftBd.DesbloquearCliente(int.Parse(tbCodigo.Text), _usuario.Autorizado))
					{
						Atualizar();

						LimparDados();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void bloquearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void btConfPreco_Click(object sender, EventArgs e)
		{
			decimal tributavel = 0;
			decimal preco = 0;

			if (!decimal.TryParse(tbTributavel.Text, out tributavel))
			{
				tbTributavel.Focus();
				return;
			}

			if (!decimal.TryParse(tbPreco.Text, out preco))
			{
				tbPreco.Focus();
				return;
			}

			for (int i = 0; i < dgProdutosPrecos.Rows.Count; i++)
			{
				if (dgProdutosPrecos.Rows[i].Cells[0].Value.ToString() == tbCodProd.Text)
				{
					if (cbTabelaPrecos.Text != "[Nova]")
					{
						int tabela = Convert.ToInt32(cbTabelaPrecos.Text.Split(" - ".ToCharArray())[0]);
						_dsoftBd.AlterarPreco(Convert.ToInt64(tbCodProd.Text), tabela, preco, tributavel, 0, _usuario.Autorizado);
					}

					dgProdutosPrecos.Rows[i].Cells["preco"].Value = preco.ToString("0.00");
					dgProdutosPrecos.Rows[i].Cells["tributavel"].Value = tributavel.ToString("0.00");

					break;
				}
			}
		}

		private void btLancarEntrada_Click(object sender, EventArgs e)
		{
			//long codigo;

			//if (tbCodigo.Text.Length < 1)
			//{
			//    MessageBox.Show("Selecione o cliente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//    return;
			//}

			//if (!long.TryParse(tbCodigo.Text, out codigo) || !_dsoftBd.ClienteCadastrado(codigo))
			//{
			//    return;
			//}

			//FinanceiroView view = new FinanceiroView(_dsoftBd, _usuario, codigo, -Convert.ToDecimal(tbSaldo.Text));

			//view.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			try
			{
				if (!btCancelar.Enabled)
				{
					return;
				}

				if (btCancelar.Text == "&Cancelar - F4")
				{
					if (_dsoftBd.CancelarCliente(long.Parse(tbCodigo.Text)))
					{
						_cliente.Situacao = 'C';

						Atualizar(_cliente);

						LimparDados();
					}
				}
				else
				{
					if (_dsoftBd.ReativarCliente(long.Parse(tbCodigo.Text)))
					{
						_cliente.Situacao = 'A';

						Atualizar(_cliente);

						LimparDados();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarCliente(long codigo)
		{
			try
			{
				_cliente = new Cliente();

				_cliente.Codigo = codigo;

				if (!_dsoftBd.CarregarDadosCliente(_cliente))
				{
					return;
				}

				tabControl1.Enabled = true;

				tbCodigo.Text = _cliente.Codigo.ToString();
				tbNome.Text = _cliente.Nome;
				dtNascimento.Value = (_cliente.Nascimento > DateTime.MinValue) ? _cliente.Nascimento : DateTime.MinValue;

				if (_cliente.Tipo == 'F')
				{
					cbTipo.Text = "Física";
					mbDocumento.Mask = "999.999.999-99";
				}
				else
				{
					cbTipo.Text = "Jurídica";
					mbDocumento.Mask = "99.999.999/9999-99";
				}

				mbDocumento.Text = _cliente.Documento;
				tbInscricaoEstadual.Text = _cliente.InscricaoEstadual;
				tbInscricaoSuframa.Text = _cliente.InscricaoSuframa;
				mbRG.Text = _cliente.Rg;
				cbIsentoICMS.Checked = _cliente.IsentoICMS;

				if (_cliente.Grupo != 0)
				{
					cbGrupo.Text = _cliente.Grupo.ToString() + " - " + _dsoftBd.ClienteGrupoDescricao(_cliente.Grupo);
				}
				else
				{
					cbGrupo.SelectedIndex = 0;
				}

				if (_cliente != null && _cliente.ClienteTipo != null)
				{
					cbTipoCliente.SelectedIndex = cbTipoCliente.Items.IndexOf(_cliente.ClienteTipo);
				}
				else
				{
					cbTipoCliente.SelectedIndex = 0;
				}

				if (_cliente.Telefone1 > 0)
				{
					tbTelefone1.Text = _cliente.Telefone1.ToString();
				}
				else
				{
					tbTelefone1.Text = string.Empty;
				}

				if (_cliente.Telefone2 > 0)
				{
					tbTelefone2.Text = _cliente.Telefone2.ToString();
				}
				else
				{
					tbTelefone2.Text = string.Empty;
				}

				if (_cliente.Celular > 0)
				{
					tbCelular.Text = _cliente.Celular.ToString();
				}
				else
				{
					tbCelular.Text = string.Empty;
				}

				tbEndereco.Text = _cliente.Endereco;
				tbNumero.Text = _cliente.Numero;
				tbComplemento.Text = _cliente.Complemento;
				tbBairro.Text = _cliente.Bairro;
				tbCidade.Text = _cliente.Cidade;
				cbEstado.Text = _cliente.Estado;
				tbPais.Text = _cliente.Pais;
				mtCep.Text = _cliente.Cep;
				tbReferencia.Text = _cliente.Referencia;
				tbObservacao.Text = _cliente.Observacao;
				tbSaldo.Text = _dsoftBd.ClienteSaldo(_cliente.Codigo).ToString("###,###,##0.00");
				tbLimite.Text = _dsoftBd.ClienteLimite(_cliente.Codigo).ToString("###,###,##0.00");
				tbPai.Text = _cliente.Pai;
				tbMae.Text = _cliente.Mae;
				tbConjuge.Text = _cliente.Conjuge;
				tbProfissao.Text = _cliente.Profissao;

				tbContato.Text = _cliente.Contato;
				tbEmail.Text = _cliente.Email;
				tbSite.Text = _cliente.Site;
				tbTaxaDeEntrega.Text = _cliente.TaxaDeEntrega.ToString("##,###,##0.00");

				if (_cliente.VencimentoMensalidade > 0)
				{
					tbVencimentoMensalidade.Text = _cliente.VencimentoMensalidade.ToString();
				}
				else
				{
					tbVencimentoMensalidade.Text = string.Empty;
				}

				tbValorMensalidade.Text = _cliente.ValorMensalidade.ToString("##,###,##0.00");

				if (_cliente.Funcionario == null)
				{
					cbFuncionario.SelectedItem = null;
				}
				else
				{
					cbFuncionario.SelectedIndex = cbFuncionario.FindString(_cliente.Funcionario.ToString());
				}

				cbTabelaPrecos.Text = "";

				if (_cliente.Tabela != null)
				{
					foreach (object o in cbTabelaPrecos.Items)
					{
						if (o.ToString().Split(" - ".ToCharArray())[0] == _cliente.Tabela.ToString())
						{
							cbTabelaPrecos.Text = o.ToString();
							break;
						}
					}
				}

				CarregarPromissorias(codigo);
				CarregarPedidos(codigo);

				btIncluir.Enabled = true;
				tbCodigo.ReadOnly = true;

				btBloquear.Enabled = true;
				btCancelar.Enabled = true;
				btLimpar.Enabled = true;

				btIncluir.Text = "&Confirmar - F2";
				Editando = true;

				if (_cliente.Situacao == 'B')
				{
					btBloquear.Text = "Desbloquear";
				}
				else if (_cliente.Situacao == 'C')
				{
					btBloquear.Enabled = false;

					btCancelar.Text = "Reativar - F4";
				}

				CarregarNiveis();

				if (tabControl1.SelectedTab.Text == "Mapa")
				{
					CarregarMapa();
				}

				tbNome.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void CarregarMapa()
		{
			if (Terminal.MapasOnline)
			{
				string origem = "";
				string destino;
				string estado;

				List<Emitente> emitentes = _dsoftBd.CarregarEmitentes();

				if (emitentes != null && emitentes.Count > 0)
				{
					origem = string.Format("{0}, {1} - {2} - {3} - {4}", emitentes[0].Logradouro, emitentes[0].Numero, emitentes[0].Bairro, emitentes[0].Municipio, emitentes[0].Uf.Substring(0, 2));
				}

				if (_cliente.Estado.Length > 2)
				{
					estado = _cliente.Estado.Substring(0, 2);
				}
				else
				{
					estado = _cliente.Estado;
				}

				destino = string.Format("{0}, {1} - {2} - {3} - {4}", _cliente.Endereco, _cliente.Numero, _cliente.Bairro, _cliente.Cidade, estado);

				string mapa = "<!DOCTYPE html>" +
										"<html> " +
										"<head> " +
										"   <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\"/> " +
										"   <title>Google Maps API v3 Directions Example</title> " +
										"   <script type=\"text/javascript\" " +
										"           src=\"http://maps.google.com/maps/api/js?sensor=false\"></script>" +
										"</head> " +
										"<body style=\"font-family: Arial; font-size: 12px;\"> " +
										"   <div style=\"width: 740px;\">" +
										"     <div id=\"map\" style=\"width: 420px; height: 240px; float: left;\"></div> " +
										"     <div id=\"panel\" style=\"width: 300px; float: right;\"></div> " +
										"   </div>" +
										"   <script type=\"text/javascript\"> " +
										"     var directionsService = new google.maps.DirectionsService();" +
										"     var directionsDisplay = new google.maps.DirectionsRenderer();" +
										"     var map = new google.maps.Map(document.getElementById('map'), {" +
										"       zoom:7," +
										"       mapTypeId: google.maps.MapTypeId.ROADMAP" +
										"     });" +
										"     directionsDisplay.setMap(map);" +
										"     directionsDisplay.setPanel(document.getElementById('panel'));" +
										"     var request = {" +
										"       origin: '" + origem + "', " +
										"       destination: '" + destino + "'," +
										"       travelMode: google.maps.DirectionsTravelMode.DRIVING" +
										"     };" +
										"     directionsService.route(request, function(response, status) {" +
										"       if (status == google.maps.DirectionsStatus.OK) {" +
										"         directionsDisplay.setDirections(response);" +
										"       }" +
										"     });" +
										"   </script> " +
										"</body> " +
										"</html>";

				try
				{
					wbMap.Navigate("about:blank");

					if (wbMap.Document != null)
					{
						wbMap.Document.Write(string.Empty);
					}

					wbMap.DocumentText = mapa;
				}
				catch (Exception e)
				{
					DSoftLogger.Logger.Instance.Error(e);
				}

				/*wbMap.DocumentText = "<!DOCTYPE html>" +
										"<html>" +
										"<head>" +
										"<script " +
										"src=\"http://maps.googleapis.com/maps/api/js\">" +
										"</script>" +
										"<script>" +
										"function initialize() {" +
										"  var mapProp = {" +
										"    center:new google.maps.LatLng(51.508742,-0.120850)," +
										"    zoom:5," +
										"    mapTypeId:google.maps.MapTypeId.ROADMAP" +
										"  };" +
										"  var map=new google.maps.Map(document.getElementById(\"googleMap\"), mapProp);" +
										"}" +
										"google.maps.event.addDomListener(window, 'load', initialize);" +
										"</script>" +
										"</head>" +
										"<body>" +
										"<div id=\"googleMap\" style=\"width:500px;height:380px;\"></div>" +
										"</body>" +
										"</html>";*/
			}
		}

		private void CarregarClientesTipos()
		{
			DataSet ds = new DataSet();

			_dsoftBd.TiposClientes(ds);

			cbTipoCliente.Items.Clear();

			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				ClienteTipo tipo = new ClienteTipo();
				tipo.Codigo = Convert.ToInt32(dr["codigo"]);
				tipo.Nome = dr["nome"].ToString();
				tipo.Interno = Convert.ToBoolean(dr["cliente_interno"]);

				cbTipoCliente.Items.Add(tipo);
			}

			if (cbTipoCliente.Items.Count > 0)
			{
				cbTipoCliente.SelectedIndex = 0;
			}
		}

		private void CarregarGrupos()
		{
			DataSet ds = new DataSet();

			_dsoftBd.GruposClientes(ds);

			cbGrupo.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbGrupo.Items.Add(ds.Tables[0].Rows[i].ItemArray[0] + " - " + ds.Tables[0].Rows[i].ItemArray[1]);
			}

			if (cbGrupo.Items.Count > 0)
			{
				cbGrupo.Text = cbGrupo.Items[0].ToString();
			}
		}

		private void CarregarNiveis()
		{
			if (_usuario.NivelUsuario.Administrador || _usuario.NivelUsuario.CadastrarGruposDeClientes)
			{
				miGruposDeClientes.Enabled = true;
			}
			else
			{
				miGruposDeClientes.Enabled = false;
			}

			switch (_usuario.Nivel)
			{
			case 'C':
				btIncluir.Enabled = false;
				incluirToolStripMenuItem.Enabled = false;
				bloquearToolStripMenuItem.Enabled = false;
				cancelarToolStripMenuItem.Enabled = false;
				toolStripMenuItem5.Enabled = false;
				toolStripMenuItem4.Enabled = false;
				miGruposDeClientes.Enabled = false;
				relatóriosToolStripMenuItem.Enabled = false;
				btCancelar.Enabled = false;
				btLimpar.Enabled = false;
				break;
			}
		}

		private void CarregarPedidos(long cliente)
		{
			try
			{
				double valor = 0;

				DataSet ds = new DataSet();

				Task.Factory.StartNew(() =>
				{
					_dsoftBd.CarregarPedidos(ds, cliente);
				}).ContinueWith((task) =>
				{
					if (task.IsFaulted || task.IsCanceled)
						return;

					this.Invoke(new Action(() =>
					{
						dataGridView3.DataSource = ds.Tables[0];

						dataGridView3.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

						dataGridView3.Columns["codigo"].Width = 45;
						dataGridView3.Columns["codigo"].HeaderText = "Código";
						dataGridView3.Columns["data"].Width = 68;
						dataGridView3.Columns["data"].HeaderText = "Data";
						dataGridView3.Columns["hora"].Width = 68;
						dataGridView3.Columns["hora"].HeaderText = "Hora";
						dataGridView3.Columns["itens"].Width = 40;
						dataGridView3.Columns["itens"].HeaderText = "Itens";
						dataGridView3.Columns["valor"].Width = 60;
						dataGridView3.Columns["valor"].HeaderText = "Valor R$";
						dataGridView3.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
						dataGridView3.Columns["situacao"].Width = 30;
						dataGridView3.Columns["situacao"].HeaderText = "Sit.";
						dataGridView3.Columns["observacao"].Width = 172;
						dataGridView3.Columns["observacao"].HeaderText = "Observação";

						dataGridView3.Refresh();

						tbVolumeVendas.Text = dataGridView3.Rows.Count.ToString();

						for (int i = 0; i < dataGridView3.Rows.Count; i++)
						{
							switch (dataGridView3.Rows[i].Cells["situacao"].Value.ToString())
							{
								case "A":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.White;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
									break;

								case "B":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
									break;

								case "C":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									break;

								case "E":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									break;

								case "N":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
									break;

								case "O":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									break;

								case "P":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Green;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									break;

								case "S":
									dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
									dataGridView3.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
									break;
							}

							valor += double.Parse(dataGridView3.Rows[i].Cells["valor"].Value.ToString());
						}

						tbTotalVendas.Text = valor.ToString("0.00");

						if (dataGridView3.Rows.Count > 1)
						{
							dataGridView3.FirstDisplayedScrollingRowIndex = dataGridView3.Rows.Count - 1;
							//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
						}
					}));
				});
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar pedidos." + Environment.NewLine + e.Message);
			}
		}

		private void CarregarPromissorias(long cliente)
		{
			try
			{
				double valor;
				double pago = 0;
				double pendente = 0;

				DataSet ds = new DataSet();

				_dsoftBd.CarregarPromissorias(cliente, ds);

				dataGridView2.DataSource = ds.Tables[0];

				dataGridView2.Columns["indice"].HeaderText = "Pagto";
				dataGridView2.Columns["indice"].Width = 120;
				dataGridView2.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView2.Columns["data"].HeaderText = "Data";
				dataGridView2.Columns["data"].Width = 70;
				dataGridView2.Columns["vencimento"].HeaderText = "Vencto";
				dataGridView2.Columns["vencimento"].Width = 70;
				dataGridView2.Columns["pago_data"].HeaderText = "Pago";
				dataGridView2.Columns["pago_data"].Width = 70;
				dataGridView2.Columns["valor"].HeaderText = "Valor R$";
				dataGridView2.Columns["valor"].Width = 90;
				dataGridView2.Columns["valor"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView2.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView2.Columns["parcela"].HeaderText = "Parcela";
				dataGridView2.Columns["parcela"].Width = 60;
				dataGridView2.Columns["parcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView2.Columns["multa"].HeaderText = "Multa R$";
				dataGridView2.Columns["multa"].Width = 90;
				dataGridView2.Columns["multa"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView2.Columns["multa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView2.Columns["total_pago"].HeaderText = "Pago R$";
				dataGridView2.Columns["total_pago"].Width = 90;
				dataGridView2.Columns["total_pago"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView2.Columns["total_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView2.Columns["pedido"].HeaderText = "Pedido";

				dataGridView2.Refresh();

				for (int i = 0; i < dataGridView2.Rows.Count; i++)
				{
					switch (dataGridView2.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "P":
						if (!double.TryParse(dataGridView2.Rows[i].Cells["total_pago"].Value.ToString(), out valor))
							valor = 0;

						pago += valor;
						dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						break;

					case "R":
						if (double.TryParse(dataGridView2.Rows[i].Cells["total_pago"].Value.ToString(), out valor))
						{
							pago += valor;
						}

						dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
						break;

					case "A":
						if (!double.TryParse(dataGridView2.Rows[i].Cells["valor"].Value.ToString(), out valor))
							valor = 0;

						pendente += valor;

						if (DateTime.Compare(DateTime.Parse(dataGridView2.Rows[i].Cells["vencimento"].Value.ToString()), DateTime.Now) < 0)
						{
							dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						}

						break;

					case "C":
						dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						break;
					}
				}

				tbPago.Text = pago.ToString("###,###,##0.00");
				tbPendente.Text = pendente.ToString("###,###,##0.00");
				tbTotal.Text = (pago + pendente).ToString("###,###,##0.00");
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar promissórias." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		private void CarregarTabelas()
		{
			_dsoftBd.CarregarTabelasAsync().ContinueWith((task) =>
				{
					if (task.IsCompleted)
					{
						this.Invoke(new Action(() =>
							{
								cbTabelaPrecos.Items.Clear();

								cbTabelaPrecos.Items.Add("");
								cbTabelaPrecos.Items.Add("[Nova]");

								cbTabelaPrecos.Items.AddRange(task.Result.ToArray());
							}));
					}
				});
		}

		private void cbGrupo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTelefone1.Focus();
			}
		}

		private void cbIsentoICMS_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbGrupo.Focus();
			}
		}

		private void cbTabelaPrecos_SelectedIndexChanged(object sender, EventArgs e)
		{
			int tabela = 0;

			if (cbTabelaPrecos.Text == "")
			{
				dgProdutosPrecos.DataSource = null;
				return;
			}

			if (cbTabelaPrecos.Text == "[Nova]")
			{
				tabela = 1; //Por padrão peagmos os valores da tabela padrão de vendas - 1
			}
			else
			{
				tabela = Convert.ToInt32(cbTabelaPrecos.Text.Split(" - ".ToCharArray())[0]);
			}

			DataSet ds = new DataSet();

			_dsoftBd.ProdutosPrecos(tabela, ds);

			dgProdutosPrecos.DataSource = ds.Tables[0];

			dgProdutosPrecos.Columns["codigo"].Width = 80;
			dgProdutosPrecos.Columns["codigo"].HeaderText = "Código";
			dgProdutosPrecos.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgProdutosPrecos.Columns["codigo"].DisplayIndex = 0;
			dgProdutosPrecos.Columns["nome"].Width = 180;
			dgProdutosPrecos.Columns["nome"].HeaderText = "Nome";
			dgProdutosPrecos.Columns["nome"].DisplayIndex = 1;
			dgProdutosPrecos.Columns["descricao"].Width = 180;
			dgProdutosPrecos.Columns["descricao"].Visible = false;
			dgProdutosPrecos.Columns["preco"].Width = 80;
			dgProdutosPrecos.Columns["preco"].HeaderText = "Preço(R$)";
			dgProdutosPrecos.Columns["preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgProdutosPrecos.Columns["preco"].DefaultCellStyle.Format = "###,###,##0.00";
			dgProdutosPrecos.Columns["preco"].DisplayIndex = 3;
			dgProdutosPrecos.Columns["tributavel"].Width = 80;
			dgProdutosPrecos.Columns["tributavel"].HeaderText = "Trib.(R$)";
			dgProdutosPrecos.Columns["tributavel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgProdutosPrecos.Columns["tributavel"].DefaultCellStyle.Format = "###,###,##0.00";
			dgProdutosPrecos.Columns["tributavel"].DisplayIndex = 4;

			dgProdutosPrecos.Columns["situacao"].Width = 60;
			dgProdutosPrecos.Columns["situacao"].Visible = false;
		}

		private void cbTipo_Leave(object sender, EventArgs e)
		{
			if (cbTipo.Text == "Física")
			{
				mbDocumento.Mask = "999.999.999-99";
			}
			else
			{
				mbDocumento.Mask = "99.999.999/9999-99";
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbDocumento.Focus();
			}
		}

		private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				mbDocumento.Focus();
			}
		}

		private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbPais.Focus();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarCliente(long.Parse(dgClientes.CurrentRow.Cells["codigo"].Value.ToString()));
		}

		private void dataGridView2_DoubleClick(object sender, EventArgs e)
		{
			//if (dataGridView2.SelectedRows.Count > 0)
			//{
			//    frmRecebimentos form = new frmRecebimentos(_dsoftBd, _usuario);

			//    form.NumeroPagamento = long.Parse(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells["indice"].Value.ToString());

			//    form.ShowDialog();

			//    CarregarPromissorias(_cliente.Codigo);
			//}
		}

		private void dataGridView3_SelectionChanged(object sender, EventArgs e)
		{
			int pedido;

			if (dataGridView3.SelectedRows.Count == 0)
				return;

			if (!int.TryParse(dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells["codigo"].Value.ToString(), out pedido) || pedido == 0)
				return;

			DataSet ds = new DataSet();

			_dsoftBd.CarregarItensPedido(pedido, ds);

			dataGridView4.DataSource = ds.Tables[0];

			dataGridView4.Columns["numero"].Width = 48;
			dataGridView4.Columns["numero"].DefaultCellStyle.Format = "000";
			dataGridView4.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dataGridView4.Columns["produto"].Width = 48;
			dataGridView4.Columns["produto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dataGridView4.Columns["fracao"].Width = 48;
			dataGridView4.Columns["preco"].Width = 60;
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbTipo.Focus();
			}
		}

		private void dgProdutosPrecos_DoubleClick(object sender, EventArgs e)
		{
			if (dgProdutosPrecos.SelectedRows.Count == 0)
				return;

			tbCodProd.Text = dgProdutosPrecos.SelectedRows[0].Cells["codigo"].Value.ToString();
			tbProd.Text = dgProdutosPrecos.SelectedRows[0].Cells["nome"].Value.ToString();
			tbPreco.Text = dgProdutosPrecos.SelectedRows[0].Cells["preco"].Value.ToString();
			tbTributavel.Text = dgProdutosPrecos.SelectedRows[0].Cells["tributavel"].Value.ToString();

			tbPreco.Focus();
		}

		private void dgProdutosPrecos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			DataGridViewRow r = grid.Rows[e.RowIndex];

			DataGridViewCellStyle style = new DataGridViewCellStyle(r.DefaultCellStyle);

			switch (r.Cells["situacao"].Value.ToString())
			{
				case "A":
					style.BackColor = Color.White;
					style.ForeColor = Color.Black;
					break;

				case "B":
					style.BackColor = Color.Yellow;
					style.ForeColor = Color.Black;
					break;

				case "C":
					style.BackColor = Color.Red;
					style.ForeColor = Color.White;
					break;
			}

			r.DefaultCellStyle = style;
		}

		private void ExportarCadastro()
		{
			try
			{
				string arquivo = /*Matriz.Pasta2() +*/ "\\cadastroClientes_" + Filial.Instance().Codigo.ToString("000") + ".xml";

				DataSet ds = new DataSet();

				_dsoftBd.CarregarClientesCompleto(ds);

				ds.DataSetName = "cadastroClientes_" + Filial.Instance().Codigo.ToString("000");
				ds.Tables[0].TableName = "cad_clientes";

				ds.Tables[0].WriteXml(arquivo);

				MessageBox.Show("Arquivo gerado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao criar arquivo de exportação." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void extratoFinanceiroPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			long codigo;

			if (tbCodigo.Text.Length < 1)
			{
				MessageBox.Show("Selecione o cliente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (!long.TryParse(tbCodigo.Text, out codigo) || !_dsoftBd.ClienteCadastrado(codigo))
			{
				return;
			}

			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);

			if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			Cliente cliente = new Cliente();

			cliente.Codigo = codigo;

			_dsoftBd.CarregarDadosCliente(cliente);

			cliente.GrupoDescricao = _dsoftBd.ClienteGrupoDescricao(cliente.Grupo);

			DataSet ds = new DataSet();

			_dsoftBd.ExtratoFinanceiro(codigo, form.dateTimePicker1.Value, form.dateTimePicker2.Value, ds);

			ExtratoFinanceiroPeriodo.Gerar(cliente, form.dateTimePicker1.Value, form.dateTimePicker2.Value, ref ds);
		}

		private void extratoPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			long codigo;
			double pago;
			double entrada;

			if (tbCodigo.Text.Length < 1)
			{
				MessageBox.Show("Selecione o cliente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (!long.TryParse(tbCodigo.Text, out codigo) || !_dsoftBd.ClienteCadastrado(codigo))
			{
				return;
			}

			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);

			if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			Cliente cliente = new Cliente();

			cliente.Codigo = codigo;

			_dsoftBd.CarregarDadosCliente(cliente);
			_dsoftBd.CarregarPagamentosPeriodo(cliente.Codigo, form.dateTimePicker1.Value, form.dateTimePicker2.Value, out pago, out entrada);

			DataSet ds = new DataSet();

			_dsoftBd.PedidosItensPorCliente(form.dateTimePicker1.Value, form.dateTimePicker2.Value, codigo, ds);

			RelatorioHtml.GerarExtratoPedidosItensPeriodo(cliente, form.dateTimePicker1.Value, form.dateTimePicker2.Value, ref ds, pago, entrada);
		}

		private void frmCadClientes_Load(object sender, EventArgs e)
		{
			Atualizar();

			if (Codigo != null)
			{
				CarregarCliente((long)Codigo);
			}
			else if (sCodigo != null)
			{
				Incluir();
			}

			CarregarNiveis();
			CarregarTabelas();
			CarregarRecursos();
			//Ordenar();

			dgClientes.Focus();
		}

		private void CarregarRecursos()
		{
			_recursos = _dsoftBd.CarregarRecursos();

			if (_recursos != null && _recursos.Count > 0)
			{
				cbFuncionario.Items.AddRange(_recursos.ToArray());
			}
		}

		private int GravarNovaTabelaPrecos()
		{
			if (cbTabelaPrecos.Text == "[Nova]")
			{
				DataTable dt = (DataTable)dgProdutosPrecos.DataSource;

				return _dsoftBd.CriarNovaTabelaPrecos(tbNome.Text, dt);
			}

			return 0;
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void Incluir()
		{
			try
			{
				if (!btIncluir.Enabled)
				{
					return;
				}

				if (btIncluir.Text == "&Incluir - F2")
				{
					Editando = false;

					btIncluir.Text = "Confirmar - F2";

					tabControl1.Enabled = true;

					btLimpar.Enabled = true;

					if (sCodigo != null)
					{
						tbCodigo.Text = sCodigo;
					}

					tbCodigo.Focus();
				}
				else
				{
					if (Editando)
					{
						if (AlterarCliente())
						{
							//Sync
							//if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
							//    Sync.AlteraCliente(ref _cliente);

							if (Consulta)
							{
								this.DialogResult = System.Windows.Forms.DialogResult.OK;
								Sair();
								return;
							}

							Atualizar(_cliente);

							LimparDados();

							Editando = false;
							btIncluir.Text = "&Incluir - F2";
						}
					}
					else
					{
						if (NovoCliente())
						{
							//Sync
							//if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
							//    Sync.NovoCliente(ref _cliente);

							if (Consulta)
							{
								this.DialogResult = System.Windows.Forms.DialogResult.OK;
								Sair();
								return;
							}

							Atualizar();

							LimparDados();
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return;
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void LimparDados()
		{
			foreach(Control t in tabControl1.TabPages[0].Controls)
			{
				if (t is TextBox || t is ComboBox || t is MaskedTextBox)
				{
					t.Text = string.Empty;
				}
			}

			foreach (Control t in tabControl1.TabPages[1].Controls)
			{
				if (t is TextBox || t is ComboBox || t is MaskedTextBox)
				{
					t.Text = string.Empty;
				}
			}

			cbTabelaPrecos.SelectedItem = null;
			tbProd.Text = "";
			tbCodProd.Text = "";
			tbPreco.Text = "";
			tbTributavel.Text = "";

			btIncluir.Enabled = true;
			tbCodigo.ReadOnly = false;

			cbTipo.Text = cbTipo.Items[1].ToString();
			cbTipoCliente.SelectedItem = cbTipoCliente.Items[0];
			cbGrupo.Text = cbGrupo.Items[0].ToString();
			tbPais.Text = "BRASIL";

			tbValorMensalidade.Text = string.Empty;
			tbVencimentoMensalidade.Text = string.Empty;

			btBloquear.Enabled = false;
			btCancelar.Enabled = false;
			btLimpar.Enabled = false;

			btIncluir.Text = "&Incluir - F2";
			btBloquear.Text = "&Bloquear";
			btCancelar.Text = "&Cancelar - F4";

			sCodigo = null;

			//tabControl1.TabPages[0].Show();
			tabControl1.SelectTab(0);

			tabControl1.Enabled = false;

			_cliente = null;

			CarregarNiveis();
			CarregarTabelas();

			dgClientes.Focus();
		}

		private void listagemDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//try
			//{
			//    DataSet ds = new DataSet();

			//    _dsoftBd.CarregarClientesAtivos(ds);

			//    if (ds != null && ds.Tables.Count > 0)
			//    {
			//        RelatorioHtml relatorio = new RelatorioHtml();

			//        relatorio.Titulo = "Relatório de clientes";
			//        relatorio.Arquivo = "RelatorioDeClientes";

			//        relatorio.Descricao = "Relatório de clientes ativos no sistema. Emitido em " + DateTime.Now.ToShortDateString() + " as " + DateTime.Now.ToShortTimeString();

			//        relatorio.Gerar(ds);
			//    }
			//}
			//catch (Exception erro)
			//{
			//    MessageBox.Show(erro.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbReferencia.Focus();
			}
		}

		private void mbDocumento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbInscricaoEstadual.Focus();
			}
		}

		private void mbRG_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbIsentoICMS.Focus();
			}
		}

		private bool NovoCliente()
		{
			try
			{
				_cliente = new Cliente();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!");

					tbCodigo.Focus();

					return false;
				}

				if (!long.TryParse(tbCodigo.Text, out _cliente.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!");

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return false;
				}

				_cliente.Nome = tbNome.Text;

				if (dtNascimento.Value < DateTime.Now)
				{
					_cliente.Nascimento = dtNascimento.Value;
				}

				if (cbTipo.Text != string.Empty && (cbTipo.Text[0] == 'F' || cbTipo.Text[0] == 'J'))
				{
					_cliente.Tipo = cbTipo.Text[0];
				}

				_cliente.Documento = mbDocumento.Text;
				_cliente.InscricaoEstadual = tbInscricaoEstadual.Text;
				_cliente.InscricaoSuframa = tbInscricaoSuframa.Text;
				_cliente.Rg = mbRG.Text;
				_cliente.IsentoICMS = cbIsentoICMS.Checked;

				if (cbTipoCliente.SelectedItem == null)
				{
					MessageBox.Show("Selecione um tipo para o cliente!");
					return false;
				}

				_cliente.ClienteTipo = (ClienteTipo)cbTipoCliente.SelectedItem;

				int.TryParse(cbGrupo.Text.Split(" - ".ToCharArray(), 2)[0], out _cliente.Grupo);

				if (tbTelefone1.Text != string.Empty && !long.TryParse(tbTelefone1.Text, out _cliente.Telefone1))
				{
					MessageBox.Show("Campo 'telefone 1' deve ser numérico!");

					tbTelefone1.SelectAll();

					tbTelefone1.Focus();

					return false;
				}

				if (tbTelefone2.Text != string.Empty && !long.TryParse(tbTelefone2.Text, out _cliente.Telefone2))
				{
					MessageBox.Show("Campo 'telefone 2' deve ser numérico!");

					tbTelefone2.SelectAll();

					tbTelefone2.Focus();

					return false;
				}

				if (tbCelular.Text != string.Empty && !long.TryParse(tbCelular.Text, out _cliente.Celular))
				{
					MessageBox.Show("Campo 'celular' deve ser numérico!");

					tbCelular.SelectAll();

					tbCelular.Focus();

					return false;
				}

				_cliente.Endereco = tbEndereco.Text;
				_cliente.Numero = tbNumero.Text;
				_cliente.Bairro = tbBairro.Text;

				if (tbCidade.Text.Length > 0)
				{
					if (_dsoftBd.CodigoMunicipio(tbCidade.Text) < 0)
					{
						tbCidade.SelectAll();
						tbCidade.Focus();
						return false;
					}
				}

				_cliente.Cidade = tbCidade.Text;
				_cliente.Estado = cbEstado.Text;
				_cliente.Pais = tbPais.Text;
				_cliente.Cep = mtCep.Text;

				//// Validamos a IE
				//if (cliente.InscricaoEstadual.Length > 0 && cliente.Estado.Length > 0)
				//{
				//    if (!ValidadorIE.Validar(cliente.InscricaoEstadual, cliente.Estado.Substring(0, 2)))
				//    {
				//        MessageBox.Show("Inscrição Estadual inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//        tbInscricaoEstadual.SelectAll();
				//        tbInscricaoEstadual.Focus();
				//        return false;
				//    }
				//}

				_cliente.Referencia = tbReferencia.Text;
				_cliente.Observacao = tbObservacao.Text;

				_cliente.Pai = tbPai.Text;
				_cliente.Mae = tbMae.Text;
				_cliente.Conjuge = tbConjuge.Text;
				_cliente.Mae = tbMae.Text;
				_cliente.Profissao = tbProfissao.Text;
				_cliente.Contato = tbContato.Text;
				_cliente.Email = tbEmail.Text;
				_cliente.Site = tbSite.Text;

				decimal taxa_de_entrega;
				decimal.TryParse(tbTaxaDeEntrega.Text, out taxa_de_entrega);
				_cliente.TaxaDeEntrega = taxa_de_entrega;

				int vencimento;
				int.TryParse(tbVencimentoMensalidade.Text, out vencimento);
				_cliente.VencimentoMensalidade = vencimento;

				decimal valor;
				decimal.TryParse(tbValorMensalidade.Text, out valor);
				_cliente.ValorMensalidade = valor;

				if (cbTabelaPrecos.Text == "")
				{
					_cliente.Tabela = null;
				}
				else
				{
					if (cbTabelaPrecos.Text == "[Nova]")
					{
						_cliente.Tabela = GravarNovaTabelaPrecos();
					}
					else
					{
						_cliente.Tabela = Convert.ToInt32(cbTabelaPrecos.Text.Split(" - ".ToCharArray())[0]);
					}
				}

				if (!double.TryParse(tbLimite.Text, out _cliente.Limite))
				{
					_cliente.Limite = 0;
				}

				_cliente.Funcionario = cbFuncionario.SelectedItem as Recurso;

				if (_dsoftBd.NovoCliente(_cliente, _licenca) && _dsoftBd.ClienteLimite(_cliente.Codigo, _cliente.Limite))
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
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void Ordenar()
		{
			if (radioButton1.Checked)
			{
				dgClientes.Sort(dgClientes.Columns["codigo"], ListSortDirection.Ascending);
			}
			else
			{
				dgClientes.Sort(dgClientes.Columns["nome"], ListSortDirection.Ascending);
			}

			Util.Pintar(ref dgClientes);

			tbPesquisa.Focus();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			Ordenar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCidade_Leave(object sender, EventArgs e)
		{
			tbCidade.Text = tbCidade.Text.Trim();
		}

		private void tbComplemento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbBairro.Focus();
			}
		}

		private void tbInscricaoEstadual_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbInscricaoSuframa.Focus();
			}
		}

		private void tbInscricaoEstadual_Leave(object sender, EventArgs e)
		{
			if (tbInscricaoEstadual.Text.Length > 0)
			{
				// Validamos a IE
				if (!ValidadorIE.Validar(tbInscricaoEstadual.Text, cbEstado.Text.Substring(0, 2)))
				{
					MessageBox.Show("Inscrição Estadual inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void tbInscricaoSuframa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbRG.Focus();
			}
		}

		private void tbNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbComplemento.Focus();
			}
		}

		private void tbObservacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btIncluir.Focus();
			}
		}

		private void tbPesquisa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (tbPesquisa.Text.Length > 0)
					Atualizar(tbPesquisa.Text);
				else
					Atualizar();
				//if (dataGridView1.SelectedRows.Count > 0)
				//{
					//CarregarCliente(long.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString()));
				//}
			}
			else if (e.KeyCode == Keys.Down)
			{
				dgClientes.Select();
				dgClientes.Focus();
			}
		}

		private void tbPesquisa_TextChanged(object sender, EventArgs e)
		{
			if (dgClientes.Rows.Count < 1)
				return;

			if (radioButton1.Checked)
			{
				int match = 0;
				long codigo;

				for (int i = 0; i < dgClientes.Rows.Count; i++)
				{
					if (long.TryParse(tbPesquisa.Text, out codigo))
					{
						if (codigo >= long.Parse(dgClientes.Rows[i].Cells["codigo"].Value.ToString()))
						{
							match = i;
						}
						else
						{
							break;
						}
					}
				}

				dgClientes.FirstDisplayedScrollingRowIndex = match;
				dgClientes.Rows[match].Selected = true;
			}
			else
			{
				int match = 0;
				int r = 0;

				for (int i = 0; i < tbPesquisa.Text.Length; i++)
				{
					while (r < dgClientes.Rows.Count)
					{
						if (dgClientes.Rows[r].Cells["nome"].Value.ToString().Length > i && tbPesquisa.Text[i] == dgClientes.Rows[r].Cells["nome"].Value.ToString()[i])
						{
							match = r;

							break;
						}

						r++;
					}
				}

				dgClientes.FirstDisplayedScrollingRowIndex = match;
				dgClientes.Rows[match].Selected = true;
			}
		}

		private void tbReferencia_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbObservacao.Focus();
			}
		}

		private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbEstado.Focus();
			}
		}

		private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				mtCep.Focus();
			}
		}

		private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)Keys.Enter)
			//{
			//    tbObservacao.Focus();
			//}
		}

		private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)Keys.Enter)
			//{
			//    if (btIncluir.Enabled)
			//    {
			//        btIncluir.Focus();
			//    }
			//    else
			//    {
			//        //button2.Focus();
			//    }
			//}
		}

		private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbTelefone1.Focus();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbCodigo.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long numero = 0;

			if (tbCodigo.Text.Length > 0 && !long.TryParse(tbCodigo.Text, out numero))
			{
				MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);
				tbCodigo.SelectAll();
				tbCodigo.Focus();
				return;
			}

			if (_dsoftBd.ClienteCadastrado(numero))
			{
				MessageBox.Show("Código já cadastrado!", this.Text);
				tbCodigo.SelectAll();
				tbCodigo.Focus();
				return;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbNome.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
			{
				dtNascimento.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				mbRG.Focus();
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbGrupo.Focus();
			}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbTelefone2.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbCelular.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbEndereco.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbNumero.Focus();
			}
		}

		private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==(char)Keys.Enter)
			{
				tbCidade.Focus();
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			CadClientesGrupos form = new CadClientesGrupos(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarGrupos();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			CadClientesTipos form = new CadClientesTipos(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarClientesTipos();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Confirma criação de arquivo de exportação de clientes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (d == DialogResult.No)
				return;

			ExportarCadastro();
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			tbCodigo.Text = _dsoftBd.ProximoCodigoCliente().ToString();
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			if (_cliente == null)
			{
				MessageBox.Show("Selecione um cliente para realizar esta operação.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			CapturaCodigo form = new CapturaCodigo("Alteração de código", "Digite o novo código:");

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				long novo;
				long.TryParse(form.Codigo, out novo);

				if (novo == 0)
				{
					MessageBox.Show("Código inválido! O novo código deve ser numérico. Operação não foi realizada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}

				if (_dsoftBd.ClienteCadastrado(novo))
				{
					MessageBox.Show(string.Format("O código {0} já está sendo usado. Operação não pode ser realizada!", novo), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

					return;
				}

				if (MessageBox.Show("Atenção. Esta operação não poderá ser desfeita! Tem certeza que deseja alterar o código deste cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
					== System.Windows.Forms.DialogResult.Yes)
				{
					_dsoftBd.TrocarCodigoCliente(_cliente.Codigo, novo, _usuario);

					tbCodigo.Text = novo.ToString();
					tbNome.Focus();

					Atualizar();
				}
			}
		}

		private void toolStripMenuItem8_Click(object sender, EventArgs e)
		{
			BuscaClientePorTelefone form = new BuscaClientePorTelefone(_dsoftBd, _usuario);
			form.ShowDialog();

			if (form.Cliente != null)
			{
				CarregarCliente(form.Cliente.Codigo);
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab.Text == "Mapa")
			{
				CarregarMapa();
			}
		}

		private void tbProfissao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbContato.Focus();
			}
		}

		private void tbContato_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEmail.Focus();
			}
		}

		private void dgClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && dgClientes.SelectedRows.Count > 0)
			{
				CarregarCliente(Convert.ToInt64(dgClientes.SelectedRows[0].Cells["codigo"].Value));
			}
		}

		private void clientesInativosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//frmFiltroData filtro = new frmFiltroData(_dsoftBd, _usuario);

			//if (filtro.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			//{
			//    DataSet ds = _dsoftBd.ClientesInativos(filtro.dateTimePicker1.Value, filtro.dateTimePicker2.Value);

			//    if (ds != null && ds.Tables.Count > 0)
			//    {
			//        RelatorioHtml relatorio = new RelatorioHtml();
			//        relatorio.Titulo = "Clientes inativos";
			//        relatorio.Arquivo = "ClientesInativos";
			//        relatorio.Descricao = string.Format("Clientes sem histórico de pedidos no período de {0} até {1}.",
			//            filtro.dateTimePicker1.Value.ToShortDateString(), filtro.dateTimePicker2.Value.ToShortDateString());

			//        relatorio.Gerar(ds);
			//    }
			//}
		}

		#endregion Methods
	}
}