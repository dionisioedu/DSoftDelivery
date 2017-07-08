using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

using DSoftBd;

using DSoftCore;

using DSoftLogger;

using DSoftModels;
using DSoftModels.NFe;

using DSoftParameters;

namespace DSoft_Delivery.NFe
{
	public class NFeManager
	{
		#region Fields

		public const string DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";
		public const string DATE_FORMAT = "yyyy-MM-dd";
		public const string TIME_FORMAT = "HH:mm:ss";

		#endregion Fields

		#region Methods

		public static string Serializar<T>(T objeto)
		{
			XElement xml = null;

			try
			{
				XmlSerializer ser = new XmlSerializer(typeof(T));

				using (MemoryStream memory = new MemoryStream())
				{
					using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
					{
						ser.Serialize(memory, objeto);
						memory.Position = 0;
						xml = XElement.Load(tr);
						xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
					}
				}
			}
			catch
			{
				throw;
			}

			return xml.ToString();
		}

		public DSoftModels.NFe.NFe GerarNFe(Bd bd, Usuario usuario, Emitente emitente, Pedido pedido)
		{
			try
			{
				decimal total_prod = 0;
				string nnf = bd.NovaChaveNFe(usuario.Autorizado);
				string rnd = Util.Randomico(8);
				string chave = "";
				chave = bd.CodigoEstado(emitente.Uf.Substring(0, 2)).ToString("00");
				chave += (pedido.Data.Year % 100).ToString("00") + pedido.Data.Month.ToString("00");
				chave += emitente.Cnpj.ToString("00000000000000");
				chave += "55"; // Modelo
				chave += "001"; // Série
				chave += nnf.Trim();
				chave += "1"; // Tipo de Emissão
				chave += rnd;
				string dv = Util.Modulo11(chave);
				chave += dv;

				Cliente cliente = bd.CarregarCliente(pedido.Cliente);

				if (cliente == null)
				{
					return null;
				}

				DSoftModels.NFe.NFe nfe = new DSoftModels.NFe.NFe();

				nfe.infNFe.versao = "2.00";
				nfe.infNFe.Id = "NFe" + chave.Trim();

				nfe.infNFe.ide.cUF = bd.CodigoEstado(emitente.Uf.Substring(0, 2)).ToString();		// Código do estado do emitente. Seguir tabela do IBGE
				nfe.infNFe.ide.cNF = rnd;
				nfe.infNFe.ide.natOp = "VENDA";
				nfe.infNFe.ide.indPag = pedido.IndicadorPagamento;
				nfe.infNFe.ide.mod = "55";
				nfe.infNFe.ide.serie = "001";
				nfe.infNFe.ide.nNF = nnf;
				nfe.infNFe.ide.dEmi = DateTime.Now.ToString(DATE_FORMAT);
				nfe.infNFe.ide.dSaiEnt = DateTime.Now.ToString(DATE_FORMAT);
				nfe.infNFe.ide.hSaiEnt = DateTime.Now.ToString(TIME_FORMAT);
				nfe.infNFe.ide.tpNF = "1";
				nfe.infNFe.ide.tpEmis = "1";
				nfe.infNFe.ide.cDV = dv;
				nfe.infNFe.ide.tpAmb = "2";
				nfe.infNFe.ide.finNFe = "1";
				nfe.infNFe.ide.procEmi = "0";
				nfe.infNFe.ide.verProc = Assembly.GetExecutingAssembly().GetName().Version.ToString();

				nfe.infNFe.emit.CNPJ = emitente.Cnpj.ToString("00000000000000");
				nfe.infNFe.emit.xNome = emitente.RazaoSocial;
				nfe.infNFe.emit.xFant = emitente.NomeFantasia;
				nfe.infNFe.emit.enderEmit.xLgr = emitente.Logradouro;
				nfe.infNFe.emit.enderEmit.nro = emitente.Numero;
				nfe.infNFe.emit.enderEmit.xBairro = emitente.Bairro;
				nfe.infNFe.emit.enderEmit.cMun = bd.CodigoMunicipio(emitente.Municipio, emitente.Uf.Substring(0, 2));
				nfe.infNFe.emit.enderEmit.xMun = emitente.Municipio;
				nfe.infNFe.emit.enderEmit.UF = emitente.Uf.Substring(0, 2);
				nfe.infNFe.emit.enderEmit.CEP = Util.LimpaFormatacao(emitente.Cep);
				nfe.infNFe.emit.enderEmit.cPais = "1058";
				nfe.infNFe.emit.enderEmit.xPais = "BRASIL";
				nfe.infNFe.emit.enderEmit.fone = emitente.Telefone;
				nfe.infNFe.emit.IE = Util.LimpaFormatacao(emitente.InscricaoEstadual);
				nfe.infNFe.emit.IM = Util.LimpaFormatacao(emitente.InscricaoMunicipal);
				nfe.infNFe.emit.CNAE = emitente.CNAEFiscal;
				nfe.infNFe.emit.CRT = "1";

				if (cliente.Tipo == 'F')
				{
					nfe.infNFe.dest.CPF = Util.LimpaFormatacao(cliente.Documento);
				}
				else
				{
					nfe.infNFe.dest.CNPJ = Util.LimpaFormatacao(cliente.Documento);
				}

				nfe.infNFe.dest.xNome = cliente.Nome;

				if (cliente.InscricaoEstadual != "")
				{
					nfe.infNFe.dest.IE = cliente.InscricaoEstadual;
				}
				else
				{
					nfe.infNFe.dest.IE = "ISENTO";
				}

				nfe.infNFe.dest.enderDest.xLgr = cliente.Endereco;
				nfe.infNFe.dest.enderDest.nro = cliente.Numero;
				nfe.infNFe.dest.enderDest.xBairro = cliente.Bairro;
				nfe.infNFe.dest.enderDest.cMun = bd.CodigoMunicipio(cliente.Cidade, cliente.Estado.Substring(0, 2));
				nfe.infNFe.dest.enderDest.xMun = cliente.Cidade;
				nfe.infNFe.dest.enderDest.UF = cliente.Estado.Substring(0, 2);
				nfe.infNFe.dest.enderDest.CEP = Util.LimpaFormatacao(cliente.Cep);
				nfe.infNFe.dest.enderDest.cPais = "1058";
				nfe.infNFe.dest.enderDest.xPais = "BRASIL";

				for (int i = 0; i < pedido.ItensQtd; i++)
				{
					if (pedido.ItensPedido[i].Situacao != 'A')
						continue;

					det det = new det();

					det.nItem = i + 1;

					ItemPedido item = pedido.ItensPedido[i];

					det.prod.cProd = item.Produto.ToString();
					det.prod.cEAN = bd.ProdutoEAN(item.Produto);
					det.prod.xProd = bd.ProdutoNome(item.Produto);
					det.prod.NCM = bd.ProdutoNCM(item.Produto);
					det.prod.CFOP = bd.ProdutoCFOP(item.Produto);
					det.prod.uCom = bd.MedidaAbrev(bd.ProdutoMedida(item.Produto));
					det.prod.qCom = item.Quantidade.ToString();
					det.prod.vUnCom = item.Unitario.ToString();
					det.prod.vProd = item.Preco.ToString();
					det.prod.cEANTrib = bd.ProdutoEANTrib(item.Produto);
					det.prod.uTrib = bd.MedidaAbrev(bd.ProdutoMedidaTributavel(item.Produto));
					det.prod.qTrib = bd.ProdutoQuantidadeTributavel(item.Produto).ToString();
					det.prod.vUnTrib = bd.ProdutoPrecoTributavel(item.Produto, pedido.Tabela.Codigo).ToString();
					det.prod.indTot = "1";

					det.imposto.ICMS.ICMSSN102.orig = "0";
					det.imposto.ICMS.ICMSSN102.CSOSN = "400";

					det.imposto.PIS.PISOutr.CST = "99";
					det.imposto.PIS.PISOutr.qBCProd = "0";
					det.imposto.PIS.PISOutr.vAliqProd = "0";
					det.imposto.PIS.PISOutr.vPIS = "0";

					det.imposto.COFINS.COFINSOutr.CST = "99";
					det.imposto.COFINS.COFINSOutr.qBCProd = "0";
					det.imposto.COFINS.COFINSOutr.vAliqProd = "0";
					det.imposto.COFINS.COFINSOutr.vCOFINS = "0";

					total_prod += item.Preco;

					nfe.infNFe.det.Add(det);
				}

				nfe.infNFe.total.ICMSTot.vBC = "0";
				nfe.infNFe.total.ICMSTot.vICMS = "0";
				nfe.infNFe.total.ICMSTot.vBCST = "0";
				nfe.infNFe.total.ICMSTot.vST = "0";
				nfe.infNFe.total.ICMSTot.vProd = total_prod.ToString();
				nfe.infNFe.total.ICMSTot.vFrete = "0";
				nfe.infNFe.total.ICMSTot.vSeg = "0";
				nfe.infNFe.total.ICMSTot.vDesc = "0";
				nfe.infNFe.total.ICMSTot.vII = "0";
				nfe.infNFe.total.ICMSTot.vIPI = "0";
				nfe.infNFe.total.ICMSTot.vPIS = "0";
				nfe.infNFe.total.ICMSTot.vCOFINS = "0";
				nfe.infNFe.total.ICMSTot.vOutro = "0";
				nfe.infNFe.total.ICMSTot.vNF = total_prod.ToString();

				nfe.infNFe.transp.modFrete = "1";

				nfe.infNFe.infAdic.infAdFisco = "DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL NAO GERA CREDITO DE ISS OU IPI PERMITE O APROVEITAMENTO DE ICMS CONFORME ART 23 LC 123";

				string serializado = Serializar<DSoftModels.NFe.NFe>(nfe);

				StreamWriter writer = new StreamWriter(Preferencias.PastaNFe + "\\" + chave + "-nfe.xml");
				writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
				writer.Flush();
				writer.Close();

				pedido.NFe = chave;
				pedido.NFeSerializado = serializado;

				return nfe;
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e);
				MessageBox.Show(e.Message, "DSoft NFe");

				return null;
			}
		}

		#endregion Methods
	}
}