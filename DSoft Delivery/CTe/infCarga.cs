using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infCarga
	{
		#region Constructors

		public infCarga()
		{
			infQ = new List<infQ>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infQ", Order = 4)]
		public List<infQ> infQ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "proPred", Order = 2)]
		public string proPred
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vCarga", Order = 1)]
		public string vCarga
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xOutCat", Order = 3)]
		public string xOutCat
		{
			get;
			set;
		}

		#endregion Properties
	}
}