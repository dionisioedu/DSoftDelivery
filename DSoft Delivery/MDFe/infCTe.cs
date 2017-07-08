using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infCTe
	{
		#region Constructors

		public infCTe()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName="chCTe", Order=1)]
		public string chCTe
		{
			get;
			set;
		}

		[XmlElement(ElementName="segCodBarra", Order=2)]
		public string segCodBarra
		{
			get;
			set;
		}

		#endregion Properties
	}
}