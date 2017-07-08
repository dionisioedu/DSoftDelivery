using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class detEvento
	{
		#region Constructors

		public detEvento()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlAttribute(AttributeName = "versaoEvento")]
		public string versaoEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "evCancCTe")]
		public evCancCTe evCancCTe
		{
			get;
			set;
		}

		[XmlElement(ElementName = "evCCeCTe")]
		public evCCeCTe evCCeCTe
		{
			get;
			set;
		}

		#endregion Properties
	}
}