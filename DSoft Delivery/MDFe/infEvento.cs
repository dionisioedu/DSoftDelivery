using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infEvento
	{
		public infEvento()
		{
			detEvento = new detEvento();
		}

		[XmlAttribute(AttributeName = "Id")]
		public string Id
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cOrgao")]
		public string cOrgao
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

		[XmlElement(ElementName = "CNPJ")]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "chMDFe")]
		public string chMDFe
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dhEvento")]
		public string dhEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpEvento")]
		public string tpEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nSeqEvento")]
		public int nSeqEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "detEvento")]
		public detEvento detEvento
		{
			get;
			set;
		}
	}
}
