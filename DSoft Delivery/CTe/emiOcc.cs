using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class emiOcc
	{
		#region Constructors

		public emiOcc()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cInt")]
		public string cInt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CNPJ")]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "fone")]
		public string fone
		{
			get;
			set;
		}

		[XmlElement(ElementName = "IE")]
		public string IE
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF")]
		public string UF
		{
			get;
			set;
		}

		#endregion Properties
	}
}