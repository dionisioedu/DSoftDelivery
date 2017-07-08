using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	[XmlRoot(ElementName = "consSitCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
	public class consSitCTe
	{
		public consSitCTe()
		{
		}

		[XmlAttribute(AttributeName = "versao")]
		public string versao
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpAmb")]
		public string tpAmb
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xServ")]
		public string xServ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "chCTe")]
		public string chCTe
		{
			get;
			set;
		}
	}
}
