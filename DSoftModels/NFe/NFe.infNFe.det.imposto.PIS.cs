using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class PIS
	{
		#region Constructors

		public PIS()
		{
			PISOutr = new PISOutr();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "PISOutr")]
		public PISOutr PISOutr
		{
			get; set;
		}

		#endregion Properties
	}
}