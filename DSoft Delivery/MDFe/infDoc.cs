using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infDoc
	{
		#region Constructors

		public infDoc()
		{
			infMunDescarga = new List<infMunDescarga>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName="infMunDescarga")]
		public List<infMunDescarga> infMunDescarga
		{
			get;
			set;
		}

		#endregion Properties
	}
}