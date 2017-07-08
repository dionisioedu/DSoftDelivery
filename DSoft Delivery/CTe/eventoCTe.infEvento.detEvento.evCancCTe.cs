using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class evCancCTe
	{
		#region Constructors

		public evCancCTe()
		{
		}

		#endregion Constructors

		#region Properties

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

		[XmlElement(ElementName = "xJust")]
		public string xJust
		{
			get;
			set;
		}

		#endregion Properties
	}
}