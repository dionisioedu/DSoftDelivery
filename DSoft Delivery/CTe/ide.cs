using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class ide
	{
		#region Constructors

		public ide()
		{
			toma03 = new toma03();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cCT", Order = 2)]
		public string cCT
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cDV", Order = 12)]
		public string cDV
		{
			get;
			set;
		}

		[XmlElement(ElementName = "CFOP", Order = 3)]
		public int CFOP
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMunEnv", Order = 17)]
		public int cMunEnv
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMunFim", Order = 25)]
		public int cMunFim
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMunIni", Order = 22)]
		public int cMunIni
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cUF", Order = 1)]
		public int cUF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dhEmi", Order = 9)]
		public string dhEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "forPag", Order = 5)]
		public int forPag
		{
			get;
			set;
		}

		[XmlElement(ElementName = "mod", Order = 6)]
		public int mod
		{
			get;
			set;
		}

		[XmlElement(ElementName = "modal", Order = 20)]
		public string modal
		{
			get;
			set;
		}

		[XmlElement(ElementName = "natOp", Order = 4)]
		public string natOp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nCT", Order = 8)]
		public string nCT
		{
			get;
			set;
		}

		[XmlElement(ElementName = "procEmi", Order = 15)]
		public string procEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "retira", Order = 28)]
		public string retira
		{
			get;
			set;
		}

		[XmlElement(ElementName = "serie", Order = 7)]
		public string serie
		{
			get;
			set;
		}

		[XmlElement(ElementName = "toma03", Order = 29)]
		public toma03 toma03
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpAmb", Order = 13)]
		public string tpAmb
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpCTe", Order = 14)]
		public string tpCTe
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpEmis", Order = 11)]
		public string tpEmis
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpImp", Order = 10)]
		public string tpImp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpServ", Order = 21)]
		public string tpServ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UFEnv", Order = 19)]
		public string UFEnv
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UFFim", Order = 27)]
		public string UFFim
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UFIni", Order = 24)]
		public string UFIni
		{
			get;
			set;
		}

		[XmlElement(ElementName = "verProc", Order = 16)]
		public string verProc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xMunEnv", Order = 18)]
		public string xMunEnv
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xMunFim", Order = 26)]
		public string xMunFim
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xMunIni", Order = 23)]
		public string xMunIni
		{
			get;
			set;
		}

		#endregion Properties
	}
}