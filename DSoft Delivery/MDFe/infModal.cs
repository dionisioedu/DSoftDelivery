using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
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

		[XmlElement(ElementName="rodo", Namespace = "http://www.portalfiscal.inf.br/mdfe")]
		public rodo rodo
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName="versaoModal")]
		public string versaoModal
		{
			get;
			set;
		}

		#endregion Properties
	}
}