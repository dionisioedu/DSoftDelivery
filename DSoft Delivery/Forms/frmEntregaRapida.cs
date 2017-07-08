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
using DSoftParameters;
using DSoftCore;

namespace DSoft_Delivery.Forms
{
	public partial class frmEntregaRapida : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private Pedido _pedido;

		public frmEntregaRapida(Bd bd, Usuario usuario, Pedido pedido)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_pedido = pedido;
		}

		private void frmEntregaRapida_Load(object sender, EventArgs e)
		{
			tbPedido.Text = _pedido.Numero.ToString();

			StringBuilder builder = new StringBuilder();

			foreach (ItemPedido item in _pedido.ItensPedido)
			{
				builder.AppendLine(item.ToString());

				foreach (ItemAdicional adicional in item.ItensAdicionais)
				{
					builder.AppendLine(adicional.ToString());
				}

				if (item.Observacao != string.Empty)
				{
					builder.AppendLine(item.Observacao);
				}
			}

			tbDetalhes.Text = builder.ToString();

			tbTotal.Text = _pedido.TotalPedido.ToString("##,###,##0.00");

			decimal troco = 0;

			if (_pedido.Troco > 0)
			{
				troco = _pedido.Troco - _pedido.TotalPedido;
			}

			tbTroco.Text = troco.ToString("##,###,##0.00");

			cbEntregadores.Items.AddRange(_dsoftBd.EntregadoresDisponiveis().ToArray());

			if (RegrasDeNegocio.Instance.TaxaPagaPorEntrega)
			{
				pnlTaxaPagaPorEntrega.Visible = true;

				tbTaxaEntregador.Text = _pedido.TaxaDeEntrega.ToString(Constants.FORMATO_MOEDA);
			}

			cbEntregadores.Focus();
		}

		private void Confirmar()
		{
			Recurso recurso = (Recurso)cbEntregadores.SelectedItem;

			if (recurso != null)
			{
				if (RegrasDeNegocio.Instance.TaxaPagaPorEntrega)
				{
					decimal taxa_entregador;
					decimal.TryParse(tbTaxaEntregador.Text, out taxa_entregador);

					_pedido.TaxaEntregador = taxa_entregador;

					_dsoftBd.AlterarTaxaEntregador(_pedido, _usuario);
				}

				_dsoftBd.SaidaPedido(_pedido.Numero, recurso.Codigo, _usuario.Autorizado);

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void cbEntregadores_KeyDown(object sender, KeyEventArgs e)
		{
			if (cbEntregadores.SelectedItem != null && e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void frmEntregaRapida_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmEntregas form = new frmEntregas(_dsoftBd, _usuario);

			form.NumeroPedido = _pedido.NumeroPedido();

			this.Close();

			form.ShowDialog();
		}

		private void tbTaxaEntregador_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}
	}
}
