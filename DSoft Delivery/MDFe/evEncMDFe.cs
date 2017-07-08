using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class evEncMDFe
	{
		public evEncMDFe()
		{
		}

		[XmlElement(ElementName = "descEvento")]
		public string descEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nProt")]
		public string nProt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dtEnc")]
		public string dtEnc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cUF")]
		public string cUF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMun")]
		public string cMun
		{
			get;
			set;
		}
	}
}
