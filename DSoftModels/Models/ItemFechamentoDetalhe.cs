using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ItemFechamentoDetalhe
	{
		public int Comanda
		{
			get;
			set;
		}

		public DateTime DataHora
		{
			get;
			set;
		}

		public string FormaDePagamento
		{
			get;
			set;
		}

		public decimal Valor
		{
			get;
			set;
		}
	}
}
