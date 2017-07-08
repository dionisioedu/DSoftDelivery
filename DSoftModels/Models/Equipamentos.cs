using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Equipamentos : IEquatable<Equipamentos>, ICloneable
	{
		public Produto Produto;
		public float Quantidade;
		public string Id;

		public override string ToString()
		{
			return string.Format("{0} - {1} {2}   {3}", Produto.Codigo.ToString("000"), Produto.Nome.PadRight(20), Quantidade.ToString("0.0"), Id);
		}

		public bool Equals(Equipamentos other)
		{
			if (other == null || other.Produto == null)
			{
				return false;
			}
			else
			{
				return this.Produto.Codigo == other.Produto.Codigo;
			}
		}

		public object Clone()
		{
			Equipamentos clone = new Equipamentos();
			clone.Produto = this.Produto;
			clone.Id = this.Id;
			clone.Quantidade = this.Quantidade;

			return clone;
		}
	}
}
