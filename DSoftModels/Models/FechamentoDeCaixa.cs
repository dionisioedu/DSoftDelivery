using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class FechamentoDeCaixa
	{
		public int Numero;
		public DateTime Data;
		public Usuario Usuario;
		public Situacoes Situacao;
		public Caixa Caixa;

		public decimal SaldoAnterior;
		public decimal Entradas;
		public decimal Saidas;
		public decimal Despesas;
		public decimal Vales;
		public decimal Pagamentos;
		public decimal Transferencias;
		public decimal SaldoAtual;

		public Dictionary<FormaDePagamento, decimal> FormasDePagamento;

		//public decimal Debito;
		//public decimal Boleto;
		//public decimal CartaoDeCredito;
		//public decimal Dinheiro;
		//public decimal MasterCard;
		//public decimal Crediario;
		//public decimal Visa;
		//public decimal VR;
		//public decimal Cheque;
		//public decimal Amex;
		//public decimal Outros;
		//public decimal Bitcoin;
		//public decimal Paypal;
	}
}
