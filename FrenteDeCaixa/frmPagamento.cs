using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftModels;
using DSoftCore;

namespace FrenteDeCaixa
{
	public partial class frmPagamento : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private int _caixa;
		private Pedido _pedido;

		public frmPagamento(Bd bd, Usuario usuario, int caixa, Pedido pedido)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_caixa = caixa;
			_pedido = pedido;
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmPagamento_Load(object sender, EventArgs e)
		{
			List<FormaDePagamento> formas = _dsoftBd.FormasDePagamento();

			if (formas != null)
			{
				foreach (FormaDePagamento f in formas)
				{
					if (f.Ativo && !f.Debito)
					{
						cbFormaPagamento.Items.Add(f);
					}
				}

				cbFormaPagamento.SelectedIndex = 0;
				cbFormaPagamento.Focus();
			}

			tbTotal.Text = _pedido.TotalPedido.ToString(Constants.FORMATO_MOEDA);
		}

		private void cbFormaPagamento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbFormaPagamento.Items.Contains(cbFormaPagamento.Text))
			{
				tbPago.SelectAll();
				tbPago.Focus();
			}
		}

		private void tbPago_KeyDown(object sender, KeyEventArgs e)
		{
			double pago;

			if (e.KeyCode == Keys.Enter && tbPago.Text.Length > 0 && double.TryParse(tbPago.Text, out pago))
			{
				double total = double.Parse(tbTotal.Text);

				tbTroco.Text = (pago - total).ToString(Constants.FORMATO_MOEDA);

				tbTroco.Focus();
			}
		}

		private void tbTroco_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (_dsoftBd.PagarPedido(_pedido.Numero, cbFormaPagamento.Text[0], string.Empty, double.Parse(tbPago.Text) - double.Parse(tbTroco.Text), _usuario.Autorizado, _caixa))
				{
					this.DialogResult = DialogResult.Yes;
				}
				else
				{
					this.DialogResult = DialogResult.No;
				}

				this.Close();
			}
		}
	}
}
