using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class tot
	{
		#region Constructors

		public tot()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cUnid", Order = 6)]
		public string cUnid
		{
			get;
			set;
		}

		/// <summary>
		/// Peso Bruto Total da Carga / Mercadoria 
		/// Transportada 
		/// </summary>
		[XmlElement(ElementName = "qCarga", Order = 7)]
		public string qCarga
		{
			get;
			set;
		}

		//[XmlElement(ElementName = "qCT", Order = 2)]
		//public int qCT
		//{
		//    get;
		//    set;
		//}

		[XmlElement(ElementName = "qCTe", Order = 1)]
		public int qCTe
		{
			get;
			set;
		}

		//[XmlElement(ElementName = "qNF", Order = 4)]
		//public int qNF
		//{
		//    get;
		//    set;
		//}

		//[XmlElement(ElementName = "qNFe", Order = 3)]
		//public int qNFe
		//{
		//    get;
		//    set;
		//}

		[XmlElement(ElementName = "vCarga", Order = 5)]
		public string vCarga
		{
			get;
			set;
		}

		#endregion Properties
	}
}