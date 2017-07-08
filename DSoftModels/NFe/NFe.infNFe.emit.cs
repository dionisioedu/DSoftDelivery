using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class emit
	{
		#region Constructors

		public emit()
		{
			enderEmit = new ender();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNAE")]
		public string CNAE
		{
			get; set;
		}

		[XmlElement(ElementName = "CNPJ")]
		public string CNPJ
		{
			get; set;
		}

		[XmlElement(ElementName = "CRT")]
		public string CRT
		{
			get; set;
		}

		[XmlElement(ElementName = "enderEmit")]
		public ender enderEmit
		{
			get; set;
		}

		[XmlElement(ElementName = "IE")]
		public string IE
		{
			get; set;
		}

		[XmlElement(ElementName = "IM")]
		public string IM
		{
			get; set;
		}

		[XmlElement(ElementName = "xFant")]
		public string xFant
		{
			get; set;
		}

		[XmlElement(ElementName = "xNome")]
		public string xNome
		{
			get; set;
		}

		#endregion Properties
	}
}