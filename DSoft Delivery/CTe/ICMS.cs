using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class ICMS
	{
		#region Constructors

		public ICMS()
		{
			//ICMS00 = new ICMS00();
			//ICMSSN101 = new ICMSSN101();

			ICMSSN = new ICMSSN();
		}

		#endregion Constructors

		#region Properties

		//[XmlElement(ElementName = "ICMS00")]
		//public ICMS00 ICMS00
		//{
		//    get;
		//    set;
		//}

		//[XmlElement(ElementName = "ICMSSN101")]
		//public ICMSSN101 ICMSSN101
		//{
		//    get;
		//    set;
		//}

		[XmlElement(ElementName = "ICMSSN", Order = 1)]
		public ICMSSN ICMSSN
		{
			get;
			set;
		}

		#endregion Properties
	}
}