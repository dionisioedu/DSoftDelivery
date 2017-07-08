using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class ide
	{
		#region Constructors

		public ide()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// informar o código do dígito verificador - DV da Chave de Acesso da NF-e, o DV será calculado com a aplicação do algoritmo módulo 11 (base 2,9) da Chave de Acesso.
		/// </summary>
		[XmlElement(ElementName = "cDV")]
		public string cDV
		{
			get; set;
		}

		/// <summary>
		/// informar o código do Município de Ocorrência do Fato Gerador do ICMS, que é o local onde ocorre a entrada ou saída da mercadoria, utilizar a Tabela do IBGE
		/// </summary>
		[XmlElement(ElementName = "cMunFG")]
		public string cMunFG
		{
			get; set;
		}

		/// <summary>
		/// informar o código numérico que compõe a Chave de Acesso. Número aleatório gerado pelo emitente para cada NF-e para evitar acessos indevidos da NF-e.
		/// </summary>
		[XmlElement(ElementName = "cNF")]
		public string cNF
		{
			get; set;
		}

		/// <summary>
		/// informar o código da UF do emitente do Documento Fiscal, utilizar a codificação do IBGE (Ex. SP->35, RS->43, etc.)
		/// </summary>
		[XmlElement(ElementName = "cUF")]
		public string cUF
		{
			get; set;
		}

		/// <summary>
		/// informar a data de emissão do Documento Fiscal.
		/// </summary>
		[XmlElement(ElementName = "dEmi")]
		public string dEmi
		{
			get; set;
		}

		/// <summary>
		/// informar a data de saída ou entrada da mercadoria ou do produto, pode ser omitido.
		/// </summary>
		[XmlElement(ElementName = "dSaiEnt")]
		public string dSaiEnt
		{
			get; set;
		}

		/// <summary>
		/// infformar o código da finalidade de emissão da NF-e: 1- NF-e normal; 2-NF-e complementar; 3 - NF-e de ajuste.
		/// </summary>
		[XmlElement(ElementName = "finNFe")]
		public string finNFe
		{
			get; set;
		}

		/// <summary>
		/// Hora de Saída ou da Entrada da Mercadoria/Produto. Formato “HH:MM:SS” (v.2.0)
		/// </summary>
		[XmlElement(ElementName = "hSaiEnt")]
		public string hSaiEnt
		{
			get; set;
		}

		/// <summary>
		/// informar o indicador da forma de pagamento: 0 - pagamento à vista;1 - pagamento à prazo;2 - outros.
		/// </summary>
		[XmlElement(ElementName = "indPag")]
		public string indPag
		{
			get; set;
		}

		/// <summary>
		/// informar o código do Modelo do Documento Fiscal, código 55 para a NF-e.
		/// </summary>
		[XmlElement(ElementName = "mod")]
		public string mod
		{
			get; set;
		}

		/// <summary>
		/// informar a natureza da operação de que decorrer a saída ou a entrada, tais como: venda, compra, transferência, devolução, importação, consignação, remessa (para fins de demonstração, de industrialização outra), conforme previsto na alínea 'i', inciso I, art. 19 do CONVÊNIO S/Nº, de 15 de dezembro de 1970.
		/// </summary>
		[XmlElement(ElementName = "natOp")]
		public string natOp
		{
			get; set;
		}

		/// <summary>
		/// informar o Número do Documento Fiscal.
		/// </summary>
		[XmlElement(ElementName = "nNF")]
		public string nNF
		{
			get; set;
		}

		/// <summary>
		/// informar o código de identificação do processo de emissão da NF-e: Identificador do processo de emissão da NF-e: 0 - emissão de NF-e com aplicativo do contribuinte; 1 - emissão de NF-e avulsa pelo Fisco; 2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;3- emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.
		/// </summary>
		[XmlElement(ElementName = "procEmi")]
		public string procEmi
		{
			get; set;
		}

		/// <summary>
		/// informar a série do Documento Fiscal, informar 0 (zero) para série única. A emissão normal pode utilizar série de 0-889, a emissão em contingência SCAN deve utilizar série 900-999.
		/// </summary>
		[XmlElement(ElementName = "serie")]
		public string serie
		{
			get; set;
		}

		/// <summary>
		/// informar o código de identificação do Ambiente: 1-Produção/ 2-Homologação
		/// </summary>
		[XmlElement(ElementName = "tpAmb")]
		public string tpAmb
		{
			get; set;
		}

		/// <summary>
		/// informar o código da forma de emissão: 1 - Normal - emissão normal; 2 - Contingência FS - emissão em contingência com impressão do DANFE em Formulário de Segurança; 3 - Contingência SCAN - emissão em contingência no Sistema de Contingência do Ambiente Nacional - SCAN;4 - Contingência DPEC - emissão em contingência com envio da Declaração Prévia de Emissão em Contingência - DPEC;5 - Contingência FS-DA - emissão em contingência com impressão do DANFE em Formulário de Segurança para Impressão de Documento Auxiliar de Documento Fiscal Eletrônico (FS-DA).
		/// </summary>
		[XmlElement(ElementName = "tpEmis")]
		public string tpEmis
		{
			get; set;
		}

		/// <summary>
		/// informar o formato de impressão do DANFE: 1-retrato / 2-paisagem.
		/// </summary>
		[XmlElement(ElementName = "tpImp")]
		public string tpImp
		{
			get; set;
		}

		/// <summary>
		/// informar o código do tipo do Documento Fiscal: 0 - entrada / 1 - saída
		/// </summary>
		[XmlElement(ElementName = "tpNF")]
		public string tpNF
		{
			get; set;
		}

		/// <summary>
		/// informar a versão do processo de emissão da NF-e utilizada (aplicativo emissor de NF-e).
		/// </summary>
		[XmlElement(ElementName = "verProc")]
		public string verProc
		{
			get; set;
		}

		#endregion Properties
	}
}