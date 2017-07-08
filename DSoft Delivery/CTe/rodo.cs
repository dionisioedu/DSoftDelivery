using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class rodo
	{
		#region Constructors

		public rodo()
		{
			//occ = new occ();
			//valePed = new valePed();
			veic = new veic();
			moto = new moto();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CIOT", Order = 6)]
		public string CIOT
		{
			get;
			set;
		}

		[XmlElement(ElementName = "dPrev", Order = 2)]
		public string dPrev
		{
			get;
			set;
		}

		[XmlElement(ElementName = "lota", Order = 3)]
		public string lota
		{
			get;
			set;
		}

		[XmlElement(ElementName = "moto", Order = 5)]
		public moto moto
		{
			get;
			set;
		}

		[XmlElement(ElementName = "occ", Order = 7)]
		public occ occ
		{
			get;
			set;
		}

		[XmlElement(ElementName = "RNTRC", Order = 1)]
		public string RNTRC
		{
			get;
			set;
		}

		[XmlElement(ElementName = "valePed", Order = 8)]
		public valePed valePed
		{
			get;
			set;
		}

		[XmlElement(ElementName = "veic", Order = 4)]
		public veic veic
		{
			get;
			set;
		}

		#endregion Properties
	}
}