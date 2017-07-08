using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class occ
	{
		#region Constructors

		public occ()
		{
			emiOcc = new emiOcc();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "dEmi")]
		public string dEmi
		{
			get;
			set;
		}

		[XmlElement(ElementName = "emiOCc")]
		public emiOcc emiOcc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nOcc")]
		public string nOcc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "serie")]
		public string serie
		{
			get;
			set;
		}

		#endregion Properties
	}
}