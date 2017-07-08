using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Recebimento
	{
		public int Indice;
		public DateTime Data;
		public DateTime Hora;
		public Cliente Cliente;
		public decimal Valor;
		public Situacoes Situacao;
		public string Observacao;
		public RecebimentoTipo Tipo;
		public DateTime Vencimento;
		public DateTime Pagamento;
		public decimal ValorPago;
		public Usuario Usuario;
	}
}
