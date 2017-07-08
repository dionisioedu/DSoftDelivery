using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class infNFe
	{
		#region Constructors

		public infNFe()
		{
			ide = new ide();
			emit = new emit();
			dest = new dest();
			det = new List<det>();
			total = new total();
			transp = new transp();
			infAdic = new infAdic();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "dest")]
		public dest dest
		{
			get; set;
		}

		[XmlElement(ElementName = "det")]
		public List<det> det
		{
			get; set;
		}

		[XmlElement(ElementName = "emit")]
		public emit emit
		{
			get; set;
		}

		[XmlAttribute(AttributeName = "Id")]
		public string Id
		{
			get; set;
		}

		[XmlElement(ElementName = "ide")]
		public ide ide
		{
			get; set;
		}

		[XmlElement(ElementName = "infAdFisco")]
		public infAdic infAdic
		{
			get; set;
		}

		[XmlElement(ElementName = "total")]
		public total total
		{
			get; set;
		}

		[XmlElement(ElementName = "transp")]
		public transp transp
		{
			get; set;
		}

		[XmlAttribute(AttributeName = "versao")]
		public string versao
		{
			get; set;
		}

		#endregion Properties
	}
}