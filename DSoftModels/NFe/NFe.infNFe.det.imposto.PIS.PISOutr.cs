using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class PISOutr
	{
		#region Constructors

		public PISOutr()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Código de Situação Tributária do PIS
		/// 
		/// 99 - Outras Operações;
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
		/// Alíquota do PIS (em reais)
		/// </summary>
		[XmlElement(ElementName = "vAliqProd")]
		public string vAliqProd
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

		#endregion Properties
	}
}