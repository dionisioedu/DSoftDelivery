using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class total
	{
		#region Constructors

		public total()
		{
			ICMSTot = new ICMSTot();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "ICMSTot")]
		public ICMSTot ICMSTot
		{
			get; set;
		}

		#endregion Properties
	}
}