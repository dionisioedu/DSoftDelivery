using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class ICMS00
	{
		#region Constructors

		public ICMS00()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CST", Order = 1)]
		public string CST
		{
			get;
			set;
		}

		[XmlElement(ElementName = "pICMS", Order = 3)]
		public string pICMS
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vBC", Order = 2)]
		public string vBC
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vICMS", Order = 4)]
		public string vICMS
		{
			get;
			set;
		}

		#endregion Properties
	}
}