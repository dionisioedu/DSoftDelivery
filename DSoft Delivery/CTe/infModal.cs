using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infModal
	{
		#region Constructors

		public infModal()
		{
			rodo = new rodo();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "rodo")]
		public rodo rodo
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName = "versaoModal")]
		public string versaoModal
		{
			get;
			set;
		}

		#endregion Properties
	}
}