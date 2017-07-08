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

namespace DSoft_Delivery.Forms
{
	public partial class frmAberturaDeCaixa : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Caixa _caixa;

		private decimal _saldoAnterior;

		public frmAberturaDeCaixa(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			_caixa = _dsoftBd.CarregarCaixa(Caixa.Numero);

			confirmButton1.Click += new EventHandler(confirmButton1_Click);
			cancelButton1.Click += new EventHandler(btSair_Click);
		}

		void confirmButton1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmAberturaDeCaixa_Load(object sender, EventArgs e)
		{
			if (_dsoftBd.CaixaEstaAberto(_caixa))
			{
				lbMensagem.Visible = true;
				confirmButton1.Enabled = false;
			}
			else
			{
				_saldoAnterior = _dsoftBd.CaixaSaldo(_caixa);

				tbSaldoAnterior.Text = _saldoAnterior.ToString(Constants.FORMATO_MOEDA);
				tbTotal.Text = tbSaldoAnterior.Text;

				tbEntrada.Focus();
			}
		}

		private void Confirmar()
		{
			decimal entrada;

			if (!decimal.TryParse(tbEntrada.Text, out entrada))
			{
				tbEntrada.Focus();
				tbEntrada.SelectAll();
				return;
			}
			else
			{
				if (entrada > 0)
				{
					if (MessageBox.Show(String.Format("Confirma o lançamento de uma entrada no caixa no valor de R$ {0} ?", entrada.ToString(Constants.FORMATO_MOEDA)), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						FluxoDeCaixa fluxo = new FluxoDeCaixa();
						fluxo.Caixa = _caixa.Codigo;
						fluxo.Forma = 'D';
						fluxo.Data = DateTime.Now;
						fluxo.Observacao = "LANÇAMENTO NA ABERTURA DE CAIXA";
						fluxo.Tipo = 'E';
						fluxo.Valor = entrada;

						_dsoftBd.LancarEntrada(fluxo, _caixa.Codigo, _usuario.Codigo);
					}
				}

				_dsoftBd.LogarAberturaDeCaixa(_caixa, _usuario, (_saldoAnterior + entrada), entrada);
				_dsoftBd.AbrirCaixa(_caixa, _usuario);

				this.Close();
			}
		}

		private void Sair()
		{
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

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbSaldo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				confirmButton1.Focus();
			}
		}

		private void tbSaldo_Leave(object sender, EventArgs e)
		{
			decimal saldo = Util.TryParseDecimal(tbSaldoAnterior.Text);
			decimal entrada = Util.TryParseDecimal(tbEntrada.Text);
			tbEntrada.Text = entrada.ToString(Constants.FORMATO_MOEDA);

			tbTotal.Text = (entrada + saldo).ToString(Constants.FORMATO_MOEDA);
		}
	}
}
