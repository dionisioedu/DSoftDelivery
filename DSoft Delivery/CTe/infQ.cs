using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infQ
	{
		#region Constructors

		public infQ()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cUnid", Order = 1)]
		public string cUnid
		{
			get;
			set;
		}

		[XmlElement(ElementName = "qCarga", Order = 3)]
		public string qCarga
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpMed", Order = 2)]
		public string tpMed
		{
			get;
			set;
		}

		#endregion Properties
	}
}