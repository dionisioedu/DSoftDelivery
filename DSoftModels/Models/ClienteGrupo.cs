using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ClienteGrupo
	{
		public int Codigo;
		public string Nome;
		public decimal Taxa;
		public decimal TaxaDeServico;
		public string Cidade;
		public string Estado;

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}

		public override bool Equals(object obj)
		{
			ClienteGrupo other = obj as ClienteGrupo;

			if (other == null)
			{
				return false;
			}

			return Codigo == other.Codigo;
		}
	}
}
