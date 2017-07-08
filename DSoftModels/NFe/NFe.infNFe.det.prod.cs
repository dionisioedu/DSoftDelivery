using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class prod
	{
		#region Constructors

		public prod()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cEAN")]
		public string cEAN
		{
			get; set;
		}

		[XmlElement(ElementName = "cEANTrib")]
		public string cEANTrib
		{
			get; set;
		}

		[XmlElement(ElementName = "CFOP")]
		public string CFOP
		{
			get; set;
		}

		[XmlElement(ElementName = "cProd")]
		public string cProd
		{
			get; set;
		}

		[XmlElement(ElementName = "indTot")]
		public string indTot
		{
			get; set;
		}

		[XmlElement(ElementName = "NCM")]
		public string NCM
		{
			get; set;
		}

		[XmlElement(ElementName = "qCom")]
		public string qCom
		{
			get; set;
		}

		[XmlElement(ElementName = "qTrib")]
		public string qTrib
		{
			get; set;
		}

		[XmlElement(ElementName = "uCom")]
		public string uCom
		{
			get; set;
		}

		[XmlElement(ElementName = "uTrib")]
		public string uTrib
		{
			get; set;
		}

		[XmlElement(ElementName = "vProd")]
		public string vProd
		{
			get; set;
		}

		[XmlElement(ElementName = "vUnCom")]
		public string vUnCom
		{
			get; set;
		}

		[XmlElement(ElementName = "vUnTrib")]
		public string vUnTrib
		{
			get; set;
		}

		[XmlElement(ElementName = "xProd")]
		public string xProd
		{
			get; set;
		}

		#endregion Properties
	}
}