using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class ICMSSN101
	{
		#region Constructors

		public ICMSSN101()
		{
		}

		#endregion

		#region Properties

		[XmlElement(ElementName = "orig", Order = 1)]
		public string orig
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CSOSN", Order = 2)]
		public string CSOSN
		{
			get;
			set;
		}

		[XmlElement(ElementName = "pCredSN", Order = 3)]
		public string pCredSN
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vCredICMSSN", Order = 4)]
		public string vCredICMSSN
		{
			get;
			set;
		}

		#endregion
	}
}
