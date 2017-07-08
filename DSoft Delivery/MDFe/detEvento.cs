using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class detEvento
	{
		public detEvento()
		{
			evEncMDFe = new evEncMDFe();
		}

		[XmlAttribute(AttributeName = "versaoEvento")]
		public string versaoEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "evEncMDFe")]
		public evEncMDFe evEncMDFe
		{
			get;
			set;
		}
	}
}
