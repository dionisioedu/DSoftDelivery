using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	[XmlRoot(ElementName = "cancCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
	public class cancCTe
	{
		#region Constructors

		public cancCTe()
		{
			infCanc = new infCanc();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infCanc")]
		public infCanc infCanc
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName = "versao")]
		public string versao
		{
			get;
			set;
		}

		#endregion Properties
	}
}