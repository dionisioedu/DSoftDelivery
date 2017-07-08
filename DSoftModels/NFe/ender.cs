using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class ender
	{
		#region Constructors

		public ender()
		{
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "CEP")]
		public string CEP
		{
			get; set;
		}

		[XmlElement(ElementName = "cMun")]
		public int cMun
		{
			get; set;
		}

		[XmlElement(ElementName = "cPais")]
		public string cPais
		{
			get; set;
		}

		[XmlElement(ElementName = "fone")]
		public string fone
		{
			get; set;
		}

		[XmlElement(ElementName = "nro")]
		public string nro
		{
			get; set;
		}

		[XmlElement(ElementName = "UF")]
		public string UF
		{
			get; set;
		}

		[XmlElement(ElementName = "xBairro")]
		public string xBairro
		{
			get; set;
		}

		[XmlElement(ElementName = "xLgr")]
		public string xLgr
		{
			get; set;
		}

		[XmlElement(ElementName = "xMun")]
		public string xMun
		{
			get; set;
		}

		[XmlElement(ElementName = "xPais")]
		public string xPais
		{
			get; set;
		}

		#endregion Properties
	}
}