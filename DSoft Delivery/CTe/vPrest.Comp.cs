using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class Comp
	{
		#region Constructors

		public Comp()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "vComp", Order = 2)]
		public string vComp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xNome", Order = 1)]
		public string xNome
		{
			get;
			set;
		}

		#endregion Properties
	}
}