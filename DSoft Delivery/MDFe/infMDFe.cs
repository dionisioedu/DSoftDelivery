using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infMDFe
	{
		#region Constructors

		public infMDFe()
		{
			ide = new ide();
			emit = new emit();
			infModal = new infModal();
			infDoc = new infDoc();
			tot = new tot();
			lacres = new List<lacres>();
		}

		#endregion Constructors

		#region Properties

		[XmlAttribute(AttributeName="Id")]
		public string id
		{
			get;
			set;
		}

		[XmlElement(ElementName="ide", Order = 1)]
		public ide ide
		{
			get;
			set;
		}

		[XmlElement(ElementName = "emit", Order = 2)]
		public emit emit
		{
			get;
			set;
		}

		[XmlElement(ElementName="infDoc", Order = 4)]
		public infDoc infDoc
		{
			get;
			set;
		}

		[XmlElement(ElementName="infModal", Order = 3)]
		public infModal infModal
		{
			get;
			set;
		}

		[XmlElement(ElementName="lacres", Order=6)]
		public List<lacres> lacres
		{
			get;
			set;
		}

		[XmlElement(ElementName="tot", Order=5)]
		public tot tot
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName="versao")]
		public string versao
		{
			get;
			set;
		}

		#endregion Properties
	}
}