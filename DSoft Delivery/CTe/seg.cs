using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class seg
	{
		#region Constructors

		public seg()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "nApol")]
		public string nApol
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nAver")]
		public string nAver
		{
			get;
			set;
		}

		[XmlElement(ElementName = "respSeg")]
		public string respSeg
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vCarga")]
		public string vCarga
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xSeg")]
		public string xSeg
		{
			get;
			set;
		}

		#endregion Properties
	}
}