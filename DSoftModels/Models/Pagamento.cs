using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Pagamento
	{
		#region Fields

		public Cliente Cliente;
		public DateTime Data;
		public string[] Documento;
		public char[] Forma;
		public double Multa;
		public long Numero;
		public char Situacao;
		public char Tipo;
		public double TotalPago;
		public double[] Valor;
		public DateTime Vencimento;

		#endregion Fields
	}
}