using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	[XmlRoot(ElementName = "MDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe")]
	public class MDFe
	{
		#region Fields

		public infMDFe infMDFe;

		#endregion Fields

		#region Constructors

		public MDFe()
		{
		}

		public MDFe(string versao, string id)
		{
			infMDFe = new infMDFe();
			infMDFe.versao = versao;
			infMDFe.id = id;
		}

		#endregion Constructors
	}
}