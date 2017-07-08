using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DSoftModels.NFe
{
	[Serializable]
	public class ICMSSN102
	{
		#region Constructors

		public ICMSSN102()
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Código de Situação da Operação – Simples Nacional
		/// 
		/// 102- Tributada pelo Simples Nacional sem permissão de crédito.
		/// 103 – Isenção do ICMS no Simples Nacional para faixa de receita bruta.
		/// 300 – Imune.
		/// 400 – Não tributada pelo Simples Nacional (v.2.0)
		/// </summary>
		[XmlElement(ElementName = "CSOSN")]
		public string CSOSN
		{
			get; set;
		}

		/// <summary>
		/// Origem da mercadoria: 
		/// 0 – Nacional; 
		/// 1 – Estrangeira – Importação direta; 
		/// 2 – Estrangeira – Adquirida no mercado interno.
		/// </summary>
		[XmlElement(ElementName = "orig")]
		public string orig
		{
			get; set;
		}

		#endregion Properties
	}
}