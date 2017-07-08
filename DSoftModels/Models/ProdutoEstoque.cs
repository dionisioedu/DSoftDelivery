using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ProdutoEstoque
	{
		#region Fields

		public long Codigo;
		public long Fornecedor;
		public int Maximo;
		public int Minimo;
		public string Nome;
		public int Quantidade;

		#endregion Fields
	}
}