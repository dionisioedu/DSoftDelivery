using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	[XmlRoot(ElementName = "NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
	public class NFe
	{
		#region Constructors

		public NFe()
		{
			infNFe = new infNFe();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infNFe")]
		public infNFe infNFe
		{
			get; set;
		}

		#endregion Properties
	}
}