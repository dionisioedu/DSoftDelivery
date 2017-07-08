using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class COFINSOutr
	{
		#region Constructors

		public COFINSOutr()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Código de Situação Tributária da COFINS
		/// 
		/// 99 - Outras operações.
		/// </summary>
		[XmlElement(ElementName = "CST")]
		public string CST
		{
			get; set;
		}

		/// <summary>
		/// Quantidade Vendida
		/// </summary>
		[XmlElement(ElementName = "qBCProd")]
		public string qBCProd
		{
			get; set;
		}

		/// <summary>
		/// Alíquota da COFINS (em reais)
		/// </summary>
		[XmlElement(ElementName = "vAliqProd")]
		public string vAliqProd
		{
			get; set;
		}

		/// <summary>
		/// Valor da COFINS
		/// </summary>
		[XmlElement(ElementName = "vCOFINS")]
		public string vCOFINS
		{
			get; set;
		}

		#endregion Properties
	}
}