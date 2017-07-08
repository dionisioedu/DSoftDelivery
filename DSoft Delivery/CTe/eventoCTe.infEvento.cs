using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infEvento
	{
		#region Constructors

		public infEvento()
		{
			detEvento = new detEvento();
		}

		#endregion Constructors

		#region Properties

		[XmlAttribute(AttributeName = "Id")]
		public string Id
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cOrgao", Order = 0)]
		public string cOrgao
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpAmb", Order = 1)]
		public string tpAmb
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CNPJ", Order = 2)]
		public string CNPJ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "chCTe", Order = 3)]
		public string chCTe
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dhEvento", Order = 4)]
		public string dhEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpEvento", Order = 5)]
		public string tpEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nSeqEvento", Order = 6)]
		public string nSeqEvento
		{
			get;
			set;
		}

		[XmlElement(ElementName = "detEvento", Order = 7)]
		public detEvento detEvento
		{
			get;
			set;
		}

		#endregion Properties
	}
}