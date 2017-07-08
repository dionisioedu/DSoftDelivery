using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class condutor
	{
		#region Constructors

		public condutor()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CPF", Order=2)]
		public string CPF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xNome", Order=1)]
		public string xNome
		{
			get;
			set;
		}

		#endregion Properties
	}
}