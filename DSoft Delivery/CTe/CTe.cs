using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	[XmlRoot(ElementName = "CTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
	public class CTe
	{
		#region Fields

		private infCTe _infCTe;

		#endregion Fields

		#region Constructors

		public CTe()
		{
		}

		public CTe(string chave, string versao)
		{
			_infCTe = new infCTe();
			_infCTe.Id = chave;
			_infCTe.versao = versao;
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "infCte")]
		public infCTe infCTe
		{
			get
			{
				return _infCTe;
			}
			set
			{
				_infCTe = value;
			}
		}

		#endregion Properties
	}
}