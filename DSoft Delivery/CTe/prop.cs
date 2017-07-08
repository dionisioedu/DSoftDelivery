using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
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

		[XmlElement(ElementName = "CNPJ", Order = 2)]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName="CPF", Order = 1)]
		public string CPF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "IE", Order = 5)]
		public string IE
		{
			get;
			set;
		}

		[XmlElement(ElementName = "RNTRC", Order = 3)]
		public string RNTRC
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpProp", Order = 7)]
		public string tpProp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF", Order = 6)]
		public string UF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xNome", Order = 4)]
		public string xNome
		{
			get;
			set;
		}

		#endregion Properties
	}
}