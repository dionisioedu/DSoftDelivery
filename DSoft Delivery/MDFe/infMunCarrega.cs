using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infMunCarrega
	{
		#region Constructors

		public infMunCarrega()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName="cMunCarrega")]
		public int cMunCarrega
		{
			get;
			set;
		}

		[XmlElement(ElementName="xMunCarrega")]
		public string xMunCarrega
		{
			get;
			set;
		}

		#endregion Properties
	}
}