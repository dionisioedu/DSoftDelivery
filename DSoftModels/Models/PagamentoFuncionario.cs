using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class PagamentoFuncionario
	{
		public Recurso Funcionario;
		public decimal Valor;
		public string Observacao;
		public List<int> OrdensDeServico;

		public override string ToString()
		{
			return string.Format("{0}\t   R$ {1} \t   {2} \t   {3}", Funcionario.ToString().Length > 30 ? Funcionario.ToString().Substring(0, 30) : Funcionario.ToString().PadRight(30)
				, Valor.ToString("##,###,##0.00"), Observacao, OrdensDeServico.Count);
		}
	}
}
