using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ProdutoGrupo
	{
		#region Fields

		public long Codigo;
		public string Descricao;
		public double Quantidade;
		public double Valor;

		#endregion Fields

		#region Methods

		public override bool Equals(object obj)
		{
			ProdutoGrupo other = obj as ProdutoGrupo;

			if (other == null)
			{
				return false;
			}

			return Codigo == other.Codigo;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Descricao);
		}

		#endregion Methods
	}
}