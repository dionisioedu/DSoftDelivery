using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class PagamentoNovo
	{
		public PagamentoNovo()
		{
		}

		public string Forma
		{
			get;
			set;
		}

		public string Documento
		{
			get;
			set;
		}

		public decimal Valor
		{
			get;
			set;
		}

		public string Observacao
		{
			get;
			set;
		}
	}
}
