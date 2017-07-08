using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class emit
	{
		#region Constructors

		public emit()
		{
			enderEmit = new enderEmit();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CNPJ", Order = 1)]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName="enderEmit", Order = 5)]
		public enderEmit enderEmit
		{
			get;
			set;
		}

		[XmlElement(ElementName = "IE", Order = 2)]
		public string IE
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xFant", Order = 4)]
		public string xFant
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

		#endregion Properties
	}
}