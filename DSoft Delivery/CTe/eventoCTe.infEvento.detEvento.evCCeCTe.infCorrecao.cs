using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infCorrecao
	{
		#region Constructors

		public infCorrecao()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "campoAlterado")]
		public string campoAlterado
		{
			get;
			set;
		}

		[XmlElement(ElementName = "grupoAlterado")]
		public string grupoAlterado
		{
			get;
			set;
		}

		[XmlElement(ElementName = "valorAlterado")]
		public string valorAlterado
		{
			get;
			set;
		}

		#endregion Properties
	}
}