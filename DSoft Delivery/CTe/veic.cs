using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class veic
	{
		#region Constructors

		public veic()
		{
			prop = new prop();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "capKG", Order = 5)]
		public string capKG
		{
			get;
			set;
		}

		[XmlElement(ElementName = "capM3", Order = 6)]
		public string capM3
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cInt", Order = 1)]
		public string cInt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "placa", Order = 3)]
		public string placa
		{
			get;
			set;
		}

		[XmlElement(ElementName = "prop", Order = 12)]
		public prop prop
		{
			get;
			set;
		}

		[XmlElement(ElementName = "RENAVAM", Order = 2)]
		public string RENAVAM
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tara", Order = 4)]
		public string tara
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpCar", Order = 10)]
		public string tpCar
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpProp", Order = 7)]
		public string tpProp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpRod", Order = 9)]
		public string tpRod
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpVeic", Order = 8)]
		public string tpVeic
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF", Order = 11)]
		public string UF
		{
			get;
			set;
		}

		#endregion Properties
	}
}