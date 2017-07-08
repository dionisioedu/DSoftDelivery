using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class TipoDeServico
	{
		public string Codigo;
		public string Descricao;
		public decimal Valor;
		public decimal Custo;
		public List<Equipamentos> Equipamentos;

		public override string ToString()
		{
			return string.Format("{0}", Descricao);
		}
	}
}
