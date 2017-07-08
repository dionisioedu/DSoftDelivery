using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Despesa
	{
		#region Fields

		public DateTime Data;
		public string Documento;
		public long Fornecedor;
		public int Indice;
		public string Observacao;
		public DateTime Pagamento;
		public char Situacao;
		public int Tipo;
		public decimal Valor;
		public decimal ValorPago;
		public DateTime Vencimento;

		#endregion Fields
	}
}