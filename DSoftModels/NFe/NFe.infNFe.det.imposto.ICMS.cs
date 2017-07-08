using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class ICMS
	{
		#region Constructors

		public ICMS()
		{
			ICMSSN102 = new ICMSSN102();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "ICMSSN102")]
		public ICMSSN102 ICMSSN102
		{
			get; set;
		}

		#endregion Properties
	}
}