using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class veicReboque
	{
		#region Constructors

		public veicReboque()
		{
			prop = new prop();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cInt", Order = 1)]
		public string cInt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "placa", Order = 2)]
		public string placa
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tara", Order = 3)]
		public string tara
		{
			get;
			set;
		}

		[XmlElement(ElementName = "capKG", Order = 4)]
		public string capKG
		{
			get;
			set;
		}

		[XmlElement(ElementName = "capM3", Order = 5)]
		public string capM3
		{
			get;
			set;
		}

		[XmlElement(ElementName = "prop", Order = 6)]
		public prop prop
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpCar", Order = 7)]
		public string tpCar
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF", Order = 8)]
		public string UF
		{
			get;
			set;
		}

		#endregion Properties
	}
}
