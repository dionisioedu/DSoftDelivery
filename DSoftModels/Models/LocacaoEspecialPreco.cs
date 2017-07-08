using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class LocacaoEspecialPreco
	{
		public LocacaoEspecialPreco()
		{
		}

		public int Indice
		{
			get;
			set;
		}

		public int Tabela
		{
			get;
			set;
		}

		public long Produto
		{
			get;
			set;
		}

		public decimal Preco
		{
			get;
			set;
		}

		public string Descricao
		{
			get;
			set;
		}

		public int Periodo
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", Descricao, Preco);
		}
	}
}
