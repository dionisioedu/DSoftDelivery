using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class rodo
	{
		#region Constructors

		public rodo()
		{
			veicPrincipal = new veicPrincipal();
			veicReboque = new veicReboque();
			//valePed = new valePed();
		}

		#endregion Constructors

		#region Properties

		[XmlAttribute(AttributeName = "xxmlnsx")]
		public string Xmlns
		{
			get;
			set;
		}

		[XmlElement(ElementName="CIOT", Order=2)]
		public string CIOT
		{
			get;
			set;
		}

		[XmlElement(ElementName="RNTRC", Order=1)]
		public string RNTRC
		{
			get;
			set;
		}

		//[XmlElement(ElementName="valePed", Order=5)]
		//public valePed valePed
		//{
		//    get;
		//    set;
		//}

		[XmlElement(ElementName="veicTracao", Order=3)]
		public veicPrincipal veicPrincipal
		{
			get;
			set;
		}

		[XmlElement(ElementName="veicReboque", Order=4)]
		public veicReboque veicReboque
		{
			get;
			set;
		}

		#endregion Properties
	}
}