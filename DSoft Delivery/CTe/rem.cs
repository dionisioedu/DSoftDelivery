using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class rem
	{
		#region Constructors

		public rem()
		{
			enderReme = new ender();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNPJ", Order = 1)]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CPF", Order = 2)]
		public string CPF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "email", Order = 9)]
		public string email
		{
			get;
			set;
		}

		[XmlElement(ElementName = "enderReme", Order = 7)]
		public ender enderReme
		{
			get;
			set;
		}

		[XmlElement(ElementName = "fone", Order = 6)]
		public string fone
		{
			get;
			set;
		}

		[XmlElement(ElementName = "IE", Order = 3)]
		public string IE
		{
			get;
			set;
		}

		[XmlElement(ElementName = "locColeta", Order = 10)]
		public string locColeta
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xFant", Order = 5)]
		public string xFant
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