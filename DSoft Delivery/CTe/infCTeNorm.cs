using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.CTe
{
	[Serializable]
	public class infCTeNorm
	{
		#region Constructors

		public infCTeNorm()
		{
			seg = new seg();
			infCarga = new infCarga();
			infModal = new infModal();
			infDoc = new infDoc();
		}

		#endregion Constructors

		#region Properties

		[XmlElement(ElementName = "docAnt", Order = 3)]
		public string docAnt
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infCarga", Order = 1)]
		public infCarga infCarga
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infDoc", Order = 2)]
		public infDoc infDoc
		{
			get;
			set;
		}

		[XmlElement(ElementName = "infModal", Order = 5)]
		public infModal infModal
		{
			get;
			set;
		}

		[XmlElement(ElementName = "peri", Order = 6)]
		public string peri
		{
			get;
			set;
		}

		[XmlElement(ElementName = "seg", Order = 4)]
		public seg seg
		{
			get;
			set;
		}

		#endregion Properties
	}
}