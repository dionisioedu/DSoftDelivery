using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class FormaDePagamento : IEquatable<FormaDePagamento>
	{
		public char Codigo;
		public string Descricao;
		public bool Debito;
		public bool Ativo;

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Descricao);
		}

		public bool Equals(FormaDePagamento other)
		{
			return this.Codigo == other.Codigo;
		}
	}
}
