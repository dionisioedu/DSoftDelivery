using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class ICMSTot
	{
		#region Constructors

		public ICMSTot()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Base de Cálculo do ICMS
		/// </summary>
		[XmlElement(ElementName = "vBC")]
		public string vBC
		{
			get; set;
		}

		/// <summary>
		/// Base de Cálculo do ICMS ST
		/// </summary>
		[XmlElement(ElementName = "vBCST")]
		public string vBCST
		{
			get; set;
		}

		/// <summary>
		/// Valor do COFINS
		/// </summary>
		[XmlElement(ElementName = "vCOFINS")]
		public string vCOFINS
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do Desconto
		/// </summary>
		[XmlElement(ElementName = "vDesc")]
		public string vDesc
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do Frete
		/// </summary>
		[XmlElement(ElementName = "vFrete")]
		public string vFrete
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do ICMS
		/// </summary>
		[XmlElement(ElementName = "vICMS")]
		public string vICMS
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do II
		/// </summary>
		[XmlElement(ElementName = "vII")]
		public string vII
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do IPI
		/// </summary>
		[XmlElement(ElementName = "vIPI")]
		public string vIPI
		{
			get; set;
		}

		/// <summary>
		/// Valor Total da NF-e
		/// </summary>
		[XmlElement(ElementName = "vNF")]
		public string vNF
		{
			get; set;
		}

		/// <summary>
		/// Outras Despesas acessórias
		/// </summary>
		[XmlElement(ElementName = "vOutro")]
		public string vOutro
		{
			get; set;
		}

		/// <summary>
		/// Valor do PIS
		/// </summary>
		[XmlElement(ElementName = "vPIS")]
		public string vPIS
		{
			get; set;
		}

		/// <summary>
		/// Valor Total dos produtos e serviços
		/// </summary>
		[XmlElement(ElementName = "vProd")]
		public string vProd
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do Seguro
		/// </summary>
		[XmlElement(ElementName = "vSeg")]
		public string vSeg
		{
			get; set;
		}

		/// <summary>
		/// Valor Total do ICMS ST
		/// </summary>
		[XmlElement(ElementName = "vST")]
		public string vST
		{
			get; set;
		}

		#endregion Properties
	}
}