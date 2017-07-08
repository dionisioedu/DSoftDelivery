using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infDoc
	{
		#region Constructors

		public infDoc()
		{
			infNF = new List<infNF>();
			infNFe = new List<infNFe>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infNF")]
		public List<infNF> infNF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infNFe")]
		public List<infNFe> infNFe
		{
			get;
			set;
		}

		#endregion Properties
	}
}