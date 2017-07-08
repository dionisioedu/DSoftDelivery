using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	[XmlRoot(ElementName = "eventoCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
	public class eventoCTe
	{
		#region Constructors

		public eventoCTe()
		{
			infEvento = new infEvento();
		}

		#endregion Constructors

		#region Properties

		public infEvento infEvento
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