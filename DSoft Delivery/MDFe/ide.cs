using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class ide
	{
		#region Constructors

		public ide()
		{
			infMunCarrega = new infMunCarrega();
			infPercurso = new List<infPercurso>();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cDV", Order = 8)]
		public string cDV
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMDF", Order = 7)]
		public string cMDF
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

		[XmlElement(ElementName = "dhEmi", Order = 10)]
		public string dhEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName="infMunCarrega", Order=16)]
		public infMunCarrega infMunCarrega
		{
			get;
			set;
		}

		[XmlElement(ElementName="infPercurso", Order=17)]
		public List<infPercurso> infPercurso
		{
			get;
			set;
		}

		[XmlElement(ElementName = "mod", Order = 4)]
		public string mod
		{
			get;
			set;
		}

		[XmlElement(ElementName = "modal", Order = 9)]
		public string modal
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nMDF", Order = 6)]
		public int nMDF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "procEmi", Order = 12)]
		public string procEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "serie", Order = 5)]
		public string serie
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpAmb", Order = 2)]
		public string tpAmb
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

		/// <summary>
		/// Tipo do Emitente.
		/// 1 - Prestador de serviço de transporte 
		/// 2 - Não prestador de serviço de transporte. 
		/// </summary>
		[XmlElement(ElementName = "tpEmit", Order = 3)]
		public string tpEmit
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UFFim", Order = 15)]
		public string UFFim
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UFIni", Order = 14)]
		public string UFIni
		{
			get;
			set;
		}

		[XmlElement(ElementName = "verProc", Order = 13)]
		public string verProc
		{
			get;
			set;
		}

		#endregion Properties
	}
}