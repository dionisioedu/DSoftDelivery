using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class dest
	{
		#region Constructors

		public dest()
		{
			enderDest = new ender();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNPJ")]
		public string CNPJ
		{
			get; set;
		}

		[XmlElement(ElementName = "CPF")]
		public string CPF
		{
			get; set;
		}

		[XmlElement(ElementName = "enderDest")]
		public ender enderDest
		{
			get; set;
		}

		[XmlElement(ElementName = "IE")]
		public string IE
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