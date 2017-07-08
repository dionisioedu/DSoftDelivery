using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSKey
{
	[Serializable]
	public class DSKey
	{
		#region Properties

		public string CNPJ
		{
			get; set;
		}

		public string Endereco
		{
			get; set;
		}

		public string Nome
		{
			get; set;
		}

		public int Numero
		{
			get; set;
		}

		public string Telefone
		{
			get; set;
		}

		public DateTime Validade
		{
			get; set;
		}

		#endregion Properties
	}
}