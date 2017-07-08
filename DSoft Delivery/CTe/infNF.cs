using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infNF
	{
		#region Constructors

		public infNF()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "dEmi", Order = 6)]
		public string dEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "mod", Order = 3)]
		public string mod
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nCFOP", Order = 13)]
		public string nCFOP
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nDoc", Order = 5)]
		public string nDoc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nPed",Order = 2)]
		public int nPed
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nPeso", Order = 14)]
		public string nPeso
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nRoma", Order = 1)]
		public int nRoma
		{
			get;
			set;
		}

		[XmlElement(ElementName = "serie", Order = 4)]
		public string serie
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vBC", Order = 7)]
		public string vBC
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vBCST", Order = 9)]
		public string vBCST
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vICMS", Order = 8)]
		public string vICMS
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vNF", Order = 12)]
		public string vNF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vProd", Order = 11)]
		public string vProd
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vST", Order = 10)]
		public string vST
		{
			get;
			set;
		}

		#endregion Properties
	}
}