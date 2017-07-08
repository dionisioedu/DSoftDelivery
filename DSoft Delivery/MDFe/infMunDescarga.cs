using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infMunDescarga : IComparable<infMunDescarga>
	{
		#region Constructors

		public infMunDescarga()
		{
			infCTe = new List<infCTe>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName="cMunDescarga", Order=1)]
		public int cMunDescarga
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xMunDescarga", Order=2)]
		public string xMunDescarga
		{
			get;
			set;
		}

		[XmlElement(ElementName="infCTe", Order=3)]
		public List<infCTe> infCTe
		{
			get;
			set;
		}

		#endregion Properties

		public int CompareTo(infMunDescarga other)
		{
			return this.xMunDescarga.CompareTo(other.xMunDescarga);
		}
	}
}