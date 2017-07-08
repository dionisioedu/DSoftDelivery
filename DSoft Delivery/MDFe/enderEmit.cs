using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class enderEmit
	{
		#region Constructors

		public enderEmit()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CEP", Order=7)]
		public string CEP
		{
			get;
			set;
		}

		[XmlElement(ElementName = "cMun", Order=5)]
		public int cMun
		{
			get;
			set;
		}

		[XmlElement(ElementName = "email", Order=10)]
		public string email
		{
			get;
			set;
		}

		[XmlElement(ElementName = "fone", Order=9)]
		public string fone
		{
			get;
			set;
		}

		[XmlElement(ElementName = "nro", Order=2)]
		public string nro
		{
			get;
			set;
		}

		[XmlElement(ElementName = "UF", Order=8)]
		public string UF
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xBairro", Order=4)]
		public string xBairro
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xCpl", Order=3)]
		public string xCpl
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xLgr", Order=1)]
		public string xLgr
		{
			get;
			set;
		}

		[XmlElement(ElementName = "xMun", Order=6)]
		public string xMun
		{
			get;
			set;
		}

		#endregion Properties
	}
}