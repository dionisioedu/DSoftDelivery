using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class ObsCont
	{
		[XmlAttribute(AttributeName = "xCampo")]
		public string xCampo
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xTexto", Order = 1)]
		public string xTexto
		{
			get;
			set;
		}
	}
}
