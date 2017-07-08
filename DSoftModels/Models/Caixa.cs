using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Caixa
	{
		#region Fields

		public static int Numero;

		public double Cartao;
		public double Cheque;
		public int Codigo;
		public double Debito;
		public string Descricao;
		public double Dinheiro;
		public double SaldoAtual;
		public double SaldoInicial;
		public char Situacao;

		#endregion Fields

		#region Methods

		public void Somar()
		{
			SaldoAtual = SaldoInicial + Dinheiro + Cheque + Cartao;
		}

		public void Somar(double saldo)
		{
			if (Dinheiro > saldo)
			{
				SaldoAtual = saldo;
				Dinheiro -= saldo;
			}
			else
			{
				SaldoAtual = Dinheiro;
				Dinheiro = 0;
			}
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Descricao);
		}

		#endregion Methods
	}
}