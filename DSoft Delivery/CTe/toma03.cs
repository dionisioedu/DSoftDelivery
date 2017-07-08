using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class toma03
	{
		#region Constructors

		public toma03()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "toma")]
		public string toma
		{
			get;
			set;
		}

		#endregion Properties
	}
}