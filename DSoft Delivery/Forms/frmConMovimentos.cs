using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class frmConMovimentos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConMovimentos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			try
			{
				double dinheiro;
				double visa;
				double master;
				double cheques;
				double entrada;
				double saida;
				double pagamento;
				double vale;
				double despesa;
				double tranferencia;
				double total_saida;
				double saldo;

				dinheiro = _DSoftBd.EntradasDinheiroPeriodo(dtInicial.Value, dtFinal.Value);
				visa = _DSoftBd.EntradasVisaPeriodo(dtInicial.Value, dtFinal.Value);
				master = _DSoftBd.EntradasMasterPeriodo(dtInicial.Value, dtFinal.Value);
				cheques = _DSoftBd.EntradasChequesPeriodo(dtInicial.Value, dtFinal.Value);
				entrada = _DSoftBd.EntradasPeriodo(dtInicial.Value, dtFinal.Value);
				saida = _DSoftBd.SaidasPeriodo(dtInicial.Value, dtFinal.Value);
				pagamento = _DSoftBd.PagamentosPeriodo(dtInicial.Value, dtFinal.Value);
				vale = _DSoftBd.ValesPeriodo(dtInicial.Value, dtFinal.Value);
				despesa = _DSoftBd.DespesasPeriodo(dtInicial.Value, dtFinal.Value);
				tranferencia = _DSoftBd.TransferenciasPeriodo(dtInicial.Value, dtFinal.Value);
				total_saida = saida + pagamento + vale + despesa + tranferencia;
				saldo = entrada - total_saida;

				tbDinheiro.Text = dinheiro.ToString("###,###,##0.00");
				tbVisa.Text = visa.ToString("###,###,##0.00");
				tbMaster.Text = master.ToString("###,###,##0.00");
				tbCheque.Text = cheques.ToString("###,###,##0.00");
				tbEntrada.Text = entrada.ToString("###,###,##0.00");
				tbSaida.Text = saida.ToString("###,###,##0.00");
				tbPagamento.Text = pagamento.ToString("###,###,##0.00");
				tbVale.Text = vale.ToString("###,###,##0.00");
				tbDespesa.Text = despesa.ToString("###,###,##0.00");
				tbTransferencia.Text = tranferencia.ToString("###,###,##0.00");
				tbTotalSaidas.Text = total_saida.ToString("###,###,##0.00");
				tbCaixasSaldo.Text = saldo.ToString("###,###,##0.00");
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dtInicial_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dtFinal.Focus();
			}
		}

		private void fecharF10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void frmConMovimentos_Load(object sender, EventArgs e)
		{
		}

		private void Sair()
		{
			Close();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		#endregion Methods
	}
}