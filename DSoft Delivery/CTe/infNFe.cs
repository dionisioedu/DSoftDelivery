using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infNFe
	{
		#region Properties

		[XmlElement(ElementName = "chave")]
		public string chave
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dPrev")]
		public string dPrev
		{
			get;
			set;
		}

		[XmlElement(ElementName = "PIN")]
		public string PIN
		{
			get;
			set;
		}

		#endregion Properties
	}
}