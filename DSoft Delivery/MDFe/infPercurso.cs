using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoft_Delivery.MDFe
{
	[Serializable]
	public class infPercurso
	{
		#region Constructors

		public infPercurso()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Sigla das Unidades da Federação do percurso do veículo. 
		/// </summary>
		[XmlElement(ElementName = "UFPer")]
		public string UFPer
		{
			get;
			set;
		}

		#endregion Properties
	}
}