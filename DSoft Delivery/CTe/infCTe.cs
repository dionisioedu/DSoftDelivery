using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infCTe
	{
		#region Constructors

		public infCTe()
		{
			ide = new ide();
			emit = new emit();
			rem = new rem();
			exped = new exped();
			dest = new dest();
			vPrest = new vPrest();
			imp = new imp();
			infCTeNorm = new infCTeNorm();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "dest", Order = 6)]
		public dest dest
		{
			get;
			set;
		}

		[XmlElement(ElementName = "emit", Order = 3)]
		public emit emit
		{
			get;
			set;
		}

		[XmlElement(ElementName = "exped", Order = 5)]
		public exped exped
		{
			get;
			set;
		}

		[XmlElement(ElementName="compl", Order = 2)]
		public compl compl
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName = "Id")]
		public string Id
		{
			get;
			set;
		}

		[XmlElement(ElementName = "ide", Order = 1)]
		public ide ide
		{
			get;
			set;
		}

		[XmlElement(ElementName = "imp", Order = 8)]
		public imp imp
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infCTeNorm", Order = 9)]
		public infCTeNorm infCTeNorm
		{
			get;
			set;
		}

		[XmlElement(ElementName = "rem", Order = 4)]
		public rem rem
		{
			get;
			set;
		}

		[XmlAttribute(AttributeName = "versao")]
		public string versao
		{
			get;
			set;
		}

		[XmlElement(ElementName = "vPrest", Order = 7)]
		public vPrest vPrest
		{
			get;
			set;
		}

		#endregion Properties
	}
}