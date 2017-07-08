using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infCanc
	{
		#region Constructors

		public infCanc()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "chCTe")]
		public string chCTe
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName = "Id")]
		public string Id
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nProt")]
		public string nProt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpAmb")]
		public string tpAmb
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xJust")]
		public string xJust
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xServ")]
		public string xServ
		{
			get;
			set;
		}

		#endregion Properties
	}
}