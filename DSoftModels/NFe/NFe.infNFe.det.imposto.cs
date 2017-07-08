using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class imposto
	{
		#region Constructors

		public imposto()
		{
			ICMS = new ICMS();
			PIS = new PIS();
			COFINS = new COFINS();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "COFINS")]
		public COFINS COFINS
		{
			get; set;
		}

		[XmlElement(ElementName = "ICMS")]
		public ICMS ICMS
		{
			get; set;
		}

		[XmlElement(ElementName = "PIS")]
		public PIS PIS
		{
			get; set;
		}

		#endregion Properties
	}
}