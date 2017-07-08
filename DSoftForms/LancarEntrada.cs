using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftCore;
using DSoftModels;

namespace DSoftForms
{
	public partial class LancarEntrada : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private Usuario _usuarioOperacao;
		private Caixa _caixa;

		public LancarEntrada(Bd bd, Usuario usuario, Caixa caixa)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_caixa = caixa;

			confirmButton1.Click += confirmarToolStripMenuItem_Click;
			cancelButton1.Click += sairToolStripMenuItem_Click;
		}

		private void LancarSaida_Load(object sender, EventArgs e)
		{
			CarregarCaixas();
			CarregarFormasDePagamento();

			tbValor.Focus();
		}

		private void CarregarCaixas()
		{
			List<Caixa> caixas = _dsoftBd.CarregarCaixas();

			cbCaixa.Items.AddRange(caixas.ToArray());

			cbCaixa.SelectedIndex = cbCaixa.FindString(_caixa.ToString());
		}

		private void CarregarFormasDePagamento()
		{
			List<FormaDePagamento> formas = _dsoftBd.FormasDePagamento();

			cbForma.Items.AddRange(formas.ToArray());

			cbForma.SelectedIndex = 0;
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			decimal valor;
			decimal.TryParse(tbValor.Text, out valor);

			if (valor > 0)
			{
				if (tbObs.Text.Length < 3)
				{
					lbMensagemObs.Text = "Observação precisa ser preenchida!";
					tbObs.Focus();
					return;
				}

				Caixa caixa = cbCaixa.SelectedItem as Caixa;

				if (caixa != null)
				{
					FluxoDeCaixa entrada = new FluxoDeCaixa();
					entrada.Caixa = caixa.Codigo;
					entrada.Data = DateTime.Now;
					entrada.Forma = 'D';
					entrada.Observacao = tbObs.Text;
					entrada.Tipo = 'S';
					entrada.Valor = valor;

					if (_dsoftBd.LancarEntrada(entrada, caixa.Codigo, _usuario.Codigo) > 0)
					{
						this.Close();
					}
					else
					{
						MessageBox.Show("Não foi possível efetuar a operação!");
					}
				}
			}
		}

		private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbObs.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void tbObs_TextChanged(object sender, EventArgs e)
		{
			if (tbObs.Text.Length > 0)
			{
				if (lbMensagemObs.Text != string.Empty)
				{
					lbMensagemObs.Text = string.Empty;
				}
			}
			else
			{
				lbMensagemObs.Text = "Observação precisa ser preenchida!";
			}
		}

		private void tbObs_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbObs.Lines.Count() > 1)
			{
				confirmButton1.Focus();
			}
		}
	}
}
