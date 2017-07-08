using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class imp
	{
		#region Constructors

		public imp()
		{
			ICMS = new ICMS();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "ICMS", Order = 1)]
		public ICMS ICMS
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vTotTrib", Order = 2)]
		public string vTotTrib
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infAdFisco", Order = 3)]
		public string infAdFisco
		{
			get;
			set;
		}

		#endregion Properties
	}
}