using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class FechamentoDiario
	{
		public int Numero;
		public DateTime Data;
		public Usuario Usuario;
		public Situacoes Situacao;

		public decimal SaldoAnterior;
		public decimal Entradas;
		public decimal Saidas;
		public decimal Despesas;
		public decimal Vales;
		public decimal Pagamentos;
		public decimal SaldoAtual;

		public decimal TotalSaidas
		{
			get
			{
				return Saidas + Despesas + Vales + Pagamentos;
			}
		}

		public Dictionary<FormaDePagamento, decimal> FormasDePagamento;

		public int Volume;
		public decimal Vendas;
		public decimal VendaDireta;
		public decimal ClienteInterno;
		public decimal Delivery;
		public decimal ClienteMensalista;

		public int PedidosCancelados;
		public decimal TotalCancelado;

		public List<MovimentoTipoProduto> Movimentos;
	}
}
