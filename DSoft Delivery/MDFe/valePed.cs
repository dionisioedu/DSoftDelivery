using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class valePed
	{
		#region Constructors

		public valePed()
		{
			disp = new disp();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "disp")]
		public disp disp
		{
			get;
			set;
		}

		#endregion Properties
	}
}