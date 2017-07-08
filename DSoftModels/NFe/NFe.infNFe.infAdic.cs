using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class infAdic
	{
		#region Constructors

		public infAdic()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infAdFisco")]
		public string infAdFisco
		{
			get; set;
		}

		#endregion Properties
	}
}