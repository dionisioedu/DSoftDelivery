using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	[XmlRoot(ElementName = "eventoMDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe")]
	public class eventoMDFe
	{
		public eventoMDFe()
		{
			infEvento = new infEvento();
		}

		[XmlAttribute(AttributeName = "versao")]
		public string versao
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infEvento")]
		public infEvento infEvento
		{
			get;
			set;
		}
	}
}
