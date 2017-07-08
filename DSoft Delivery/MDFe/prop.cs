using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class prop
	{
		#region Constructors

		public prop()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNPJ", Order = 1)]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "RNTRC", Order = 2)]
		public string RNTRC
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xNome", Order = 3)]
		public string xNome
		{
			get;
			set;
		}

		[XmlElement(ElementName = "IE", Order = 4)]
		public string IE
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF", Order = 5)]
		public string UF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpProp", Order = 6)]
		public string tpProp
		{
			get;
			set;
		}

		#endregion Properties
	}
}