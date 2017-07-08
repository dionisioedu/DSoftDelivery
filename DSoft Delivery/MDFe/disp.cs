using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class disp
	{
		#region Constructors

		public disp()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNPJForn")]
		public string CNPJForn
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CNPJPg")]
		public string CNPJPg
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nCompra")]
		public string nCompra
		{
			get;
			set;
		}

		#endregion Properties
	}
}