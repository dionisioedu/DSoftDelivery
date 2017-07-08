using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class FornecedorTipo
	{
		public int Codigo;
		public string Nome;

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}
	}
}
