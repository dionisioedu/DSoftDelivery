using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class transp
	{
		#region Constructors

		public transp()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Modalidade do frete
		/// 
		/// 0- Por conta do emitente;
		/// 1- Por conta do destinatário/remetente;
		/// 2- Por conta de terceiros;
		/// 9- Sem frete. (V2.0)
		/// </summary>
		[XmlElement(ElementName = "modFrete")]
		public string modFrete
		{
			get; set;
		}

		#endregion Properties
	}
}