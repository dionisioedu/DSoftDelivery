using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class compl
	{
		public compl()
		{
		}

		[XmlElement(ElementName="xCaracAd", Order=0)]
		public string xCaracAd
		{
			get;
			set;
		}

		[XmlElement(ElementName="xCaracSer", Order=1)]
		public string xCaracSer
		{
			get;
			set;
		}

		[XmlElement(ElementName="xEmi", Order=2)]
		public string xEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "ObsCont", Order = 3)]
		public ObsCont ObsCont
		{
			get;
			set;
		}

		[XmlElement(ElementName = "ObsFisco", Order = 4)]
		public ObsFisco ObsFisco
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xObs", Order = 9)]
		public string xObs
		{
			get;
			set;
		}
	}
}
