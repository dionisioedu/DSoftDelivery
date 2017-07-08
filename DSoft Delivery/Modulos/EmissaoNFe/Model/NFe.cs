using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DSoftBd;

using DSoftCore;

using DSoftLogger;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Modulos.EmissaoNFe.Model
{
	class NFe
	{
		#region Fields

		public DateTime Data;
		public Emitente Emitente;
		public Pedido Pedido;

		const string DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";
		const string DATE_FORMAT = "yyyy-MM-dd";

		#endregion Fields

		#region Constructors

		public NFe()
		{
		}

		#endregion Constructors

		#region Methods

		public bool Gerar(Bd bd, Usuario usuario)
		{
			try
			{
				if (Preferencias.SchemaNFe.Length < 1)
				{
					if (MessageBox.Show("Configurações incompletas. Schema NFe não definido!" + Environment.NewLine + "Deseja acessar as preferências agora?", "NFe", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
						== DialogResult.Yes)
					{
						frmPreferencias form = new frmPreferencias();
						form.Show();
					}

					return false;
				}

				string nf = bd.NovaChaveNFe(usuario.Autorizado);
				string rnd = Util.Randomico(9);
				string chave;
				string dv;

				chave = bd.CodigoEstado(Emitente.Uf.Substring(0, 2)).ToString("00");
				chave += (Data.Year % 100).ToString("00") + Data.Month.ToString("00");
				chave += Emitente.Cnpj.ToString("00000000000000");
				chave += "55"; // Modelo
				chave += "000"; // Série
				chave += nf.Trim();
				chave += rnd;
				dv = Util.Modulo11(chave);
				chave += dv;

				chave = "NFe" + chave;

				XmlWriterSettings writerSett = new XmlWriterSettings();
				writerSett.Indent = true;
				writerSett.IndentChars = "\t";
				//writerSett.CheckCharacters = true;
				writerSett.Encoding = Encoding.UTF8;
				writerSett.ConformanceLevel = ConformanceLevel.Document;

				XmlWriter xmlWriter = XmlWriter.Create(Preferencias.PastaNFe + "\\" + chave.Remove(0, 3) + "-nfe.xml", writerSett);

				DataSet ds = new DataSet();
				ds.ReadXmlSchema(Preferencias.SchemaNFe);
				ds.DataSetName = "NFe_";

				Cliente destinatario = new Cliente(Pedido.Cliente);

				if (!bd.CarregarDadosCliente(destinatario))
				{
					MessageBox.Show("Não é possível emitir NFe sem cliente identificado!", "DSoft NFe");
					return false;
				}

				//Tabela NFe
				DataRow drNFe = ds.Tables["NFe"].NewRow();
				ds.Tables["NFe"].Rows.Add(drNFe);

				DataRow drInfNFe = ds.Tables["infNFe"].NewRow();
				drInfNFe["id"] = "NFe" + chave.Remove(0, 3);
				drInfNFe["versao"] = "2.00";
				drInfNFe["NFe_Id"] = drNFe["NFe_Id"];
				ds.Tables["infNFe"].Rows.Add(drInfNFe);

				DataRow drIde = ds.Tables["ide"].NewRow();
				drIde["cUF"] = bd.CodigoEstado(Emitente.Uf.Substring(0, 2)); //Código da UF do emitente do Documento Fiscal. Utilizar a Tabela do IBGE de código de unidades da federação (Anexo IV - Tabela de UF, Município e País).
				drIde["cMunFG"] = bd.CodigoMunicipio(Emitente.Municipio); //Código do Município de Ocorrência do Fato Gerador
				drIde["cNF"] = rnd;
				drIde["natOp"] = "";			// Natureza da Operação
				drIde["indPag"] = "";			// Indicador da forma de pagamento:
												//0 – pagamento à vista;
												//1 – pagamento à prazo;
												//2 – outros.
				drIde["mod"] = "";				// Código do modelo do Documento Fiscal. Utilizar 55 para identificação da NF-e, emitida em substituição ao modelo 1 e 1A.
				drIde["serie"] = "";			// Série do documento fiscal.
				drIde["nNf"] = "";				// Número do documento fiscal
				drIde["dEmi"] = "";				// Data da emissão
				drIde["tpNF"] = "1";			// Tipo do Documento Fiscal (0 - entrada; 1 - saída)
				drIde["tpEmis"] = "1";			// Forma de emissão da NF-e
												//1 - Normal;
												//2 - Contingência FS
												//3 - Contingência SCAN
												//4 - Contingência DPEC
												//5 - Contingência FSDA
												//6 - Contingência SVC - AN
												//7 - Contingência SVC - RS
				drIde["cDV"] = dv;				// Digito Verificador da Chave de Acesso da NF-e
				drIde["tpAmb"] = "2";			// Identificação do Ambiente:
												//1 - Produção
												//2 - Homologação
				drIde["procEmi"] = "0";			// Processo de emissão utilizado com a seguinte codificação:
												//0 - emissão de NF-e com aplicativo do contribuinte;
												//1 - emissão de NF-e avulsa pelo Fisco;
												//2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
												//3- emissão de NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.
				drIde["dSaiEnt"] = Pedido.Data.ToString(DATE_FORMAT);
				drIde["tpImp"] = "1";			//Formato de Impressão do DANFE. 1-Retrato / 2-Paisagem
				drIde["finNFe"] = "1";			//Finalidade de emissão da NFe. 1-NFe normal / 2-NFe complementar / 3–NFe de ajuste
				drIde["dhCont"] = "";			// Data e hora da entrada em contingência. AAAA-MM-DDTHH:MM:SS
				drIde["xJust"] = "";
				drIde["verProc"] = "1.2";		// Versão do aplicativo utilizado no processo de emissão.

				drIde["infNFe_Id"] = drInfNFe["infNFe_Id"];
				ds.Tables["ide"].Rows.Add(drIde);

				DataRow drEmit = ds.Tables["emit"].NewRow();
				drEmit["CNPJ"] = Emitente.Cnpj.ToString();
				drEmit["CPF"] = "";
				drEmit["xNome"] = Emitente.RazaoSocial;
				drEmit["xFant"] = Emitente.NomeFantasia;
				//drEmit["enderEmit"] = Emitente.Logradouro + "," + Emitente.Numero + " - " + Emitente.Bairro;
				drEmit["IE"] = Emitente.InscricaoEstadual;
				drEmit["IM"] = Emitente.InscricaoMunicipal;
				drEmit["CNAE"] = Emitente.CNAEFiscal;
				drEmit["CRT"] = "3";				// Código de Regime Tributário.
												//Este campo será obrigatoriamente preenchido com:
												//1 – Simples Nacional;
												//2 – Simples Nacional – excesso de sublimite de receita bruta;
												//3 – Regime Normal. (v2.0).

				drEmit["infNFe_Id"] = drInfNFe["infNFe_Id"];
				ds.Tables["emit"].Rows.Add(drEmit);

				// Tabela 'enderEmit'
				DataRow drEnderEmit = ds.Tables["enderEmit"].NewRow();

				drEnderEmit["xLgr"] = Emitente.Logradouro;
				drEnderEmit["nro"] = Emitente.Numero;
				drEnderEmit["xCpl"] = (Emitente.Complemento.Length > 0 ? Emitente.Complemento : "-");
				drEnderEmit["xBairro"] = Emitente.Bairro;
				drEnderEmit["cMun"] = bd.CodigoMunicipio(Emitente.Municipio);		// Utilizar tabela do IBGE
				drEnderEmit["xMun"] = Emitente.Municipio;
				drEnderEmit["CEP"] = Util.LimpaFormatacao(Emitente.Cep);
				drEnderEmit["UF"] = Emitente.Uf.Substring(0, 2);
				//drEnderEmit["cPais"] = ;					// Utilizar tabela do BACEN
				drEnderEmit["xPais"] = Emitente.Pais;
				drEnderEmit["fone"] = Util.LimpaFormatacao(Emitente.Telefone);
				drEnderEmit["emit_Id"] = drEmit["emit_Id"];

				ds.Tables["enderEmit"].Rows.Add(drEnderEmit);

				// Tabela 'dest'
				DataRow drDest = ds.Tables["dest"].NewRow();

				drDest["CNPJ"] = Util.LimpaFormatacao(destinatario.Documento);
				drDest["CPF"] = "";

				if (destinatario.InscricaoEstadual == "ISENTO")
				{
					drDest["IE"] = "ISENTO";
				}
				else
				{
					drDest["IE"] = Util.LimpaFormatacao(destinatario.InscricaoEstadual);
				}

				drDest["xNome"] = destinatario.Nome;
				//drDest["ISUF"] = ""; // ??
				drDest["infNFe_Id"] = drInfNFe["infNFe_Id"];

				ds.Tables["dest"].Rows.Add(drDest);

				// Tabela 'enderDest'
				DataRow drEnderDest = ds.Tables["enderDest"].NewRow();

				drEnderDest["xLgr"] = destinatario.Endereco;
				drEnderDest["nro"] = destinatario.Numero;
				drEnderDest["xCpl"] = (destinatario.Complemento.Length > 0 ? destinatario.Complemento : "-");
				drEnderDest["xBairro"] = destinatario.Bairro;
				drEnderDest["cMun"] = bd.CodigoMunicipio(destinatario.Cidade);
				drEnderDest["xMun"] = destinatario.Cidade;
				drEnderDest["CEP"] = Util.LimpaFormatacao(destinatario.Cep);
				drEnderDest["UF"] = destinatario.Estado.Substring(0, 2);
				//drEnderDest["cPais"] = ;
				drEnderDest["xPais"] = destinatario.Pais;
				drEnderDest["fone"] = destinatario.Telefone1;
				drEnderDest["dest_Id"] = drDest["dest_Id"];

				ds.Tables["enderDest"].Rows.Add(drEnderDest);

				// Tabelas dos produtos
				for (int i = 0; i < Pedido.ItensQtd; i++)
				{
					Produto produto = bd.CarregarProduto(Pedido.ItensPedido[i].Produto);

					if (produto == null)
					{
						MessageBox.Show("Produto inválido!", "DSoft NFe");

						return false;
					}

					DataRow drDet = ds.Tables["det"].NewRow();

					drDet["nItem"] = (i + 1).ToString();

					drDet["infNFe_Id"] = drInfNFe["infNFe_Id"];

					ds.Tables["det"].Rows.Add(drDet);

					DataRow drProd = ds.Tables["prod"].NewRow();

					drProd["cProd"] = produto.Codigo.ToString();
					drProd["xProd"] = produto.Descricao;
					drProd["cEAN"] = produto.EAN;
					drProd["cEANTrib"] = produto.EANTrib;
					drProd["NCM"] = produto.NCM;
					drProd["CFOP"] = produto.CFOP;
					drProd["uCom"] = ""; // Unidade Tributável
					drProd["qCom"] = produto.QuantidadeTributavel.ToString(); // Quantidade Tributável
					drProd["vUnCom"] = ""; // Valor Unitário de Tributação
					drProd["uTrib"] = ""; // Unidade Tributável
					drProd["qTrib"] = ""; // Quantidade Tributável
					drProd["vUnTrib"] = ""; // Valor Unitário de Tributação

					drProd["det_Id"] = drDet["det_Id"];

					ds.Tables["prod"].Rows.Add(drProd);
				}

				XmlDocument xmlDoc = new XmlDocument();

				xmlDoc.LoadXml(ds.GetXml());

				xmlDoc.FirstChild.WriteContentTo(xmlWriter);

				xmlWriter.Flush();

				return true;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e);

				MessageBox.Show("Erro ao gerar NFe. " + e.Message, "DSoft NFe");

				return false;
			}
		}

		#endregion Methods
	}
}