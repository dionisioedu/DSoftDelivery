using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class vPrest
	{
		#region Constructors

		public vPrest()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "Comp", Order = 3)]
		public List<Comp> Comp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vRec", Order = 2)]
		public string vRec
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vTPrest", Order = 1)]
		public string vTPrest
		{
			get;
			set;
		}

		#endregion Properties
	}
}