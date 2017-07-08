using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class evCCeCTe
	{
		#region Constructors

		public evCCeCTe()
		{
			infCorrecao = new List<infCorrecao>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "descEvento")]
		public string descEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infCorrecao")]
		public List<infCorrecao> infCorrecao
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xCondUso")]
		public string xCondUso
		{
			get;
			set;
		}

		#endregion Properties
	}
}