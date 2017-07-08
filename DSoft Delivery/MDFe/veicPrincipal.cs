using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class veicPrincipal
	{
		#region Constructors

		public veicPrincipal()
		{
			condutor = new condutor();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "cInt", Order=1)]
		public string cInt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "condutor", Order=4)]
		public condutor condutor
		{
			get;
			set;
		}

		[XmlElement(ElementName = "placa", Order=2)]
		public string placa
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tara", Order=3)]
		public string tara
		{
			get;
			set;
		}

		[XmlElement(ElementName="tpRod", Order=5)]
		public string tpRod
		{
			get;
			set;
		}

		[XmlElement(ElementName = "tpCar", Order = 6)]
		public string tpCar
		{
			get;
			set;
		}

		[XmlElement(ElementName="UF", Order=7)]
		public string UF
		{
			get;
			set;
		}

		#endregion Properties
	}
}