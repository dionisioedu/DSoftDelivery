using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class COFINS
	{
		#region Constructors

		public COFINS()
		{
			COFINSOutr = new COFINSOutr();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CONFINSOutr")]
		public COFINSOutr COFINSOutr
		{
			get; set;
		}

		#endregion Properties
	}
}