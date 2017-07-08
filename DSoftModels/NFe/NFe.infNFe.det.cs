using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class det
	{
		#region Constructors

		public det()
		{
			prod = new prod();
			imposto = new imposto();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "imposto")]
		public imposto imposto
		{
			get; set;
		}

		[XmlAttribute(AttributeName = "nItem")]
		public int nItem
		{
			get; set;
		}

		[XmlElement(ElementName = "prod")]
		public prod prod
		{
			get; set;
		}

		#endregion Properties
	}
}