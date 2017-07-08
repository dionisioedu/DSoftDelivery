using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Endereco
	{
		public int CEP;
		public string Logradouro;
		public int Numero;
		public string Bairro;
		public string Cidade;
		public string Estado;
		public string UF;

		public string UFCompleto
		{
			get
			{
				return string.Format("{0} - {1}", UF, Estado);
			}
		}
	}
}
