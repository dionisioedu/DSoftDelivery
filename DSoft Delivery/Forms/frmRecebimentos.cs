using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmRecebimentos : Form
	{
		#region Fields

		public long NumeroPagamento = 0;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmRecebimentos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			tbNumero.Focus();

			if (_usuario.Nivel != 'A')
				dtPagamento.Enabled = false;
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarPagamento(long pagamento)
		{
			Pagamento _pagamento = new Pagamento();

			_pagamento.Numero = pagamento;

			if (!_dsoftBd.CarregarPagamentoNumero(_pagamento))
			{
				MessageBox.Show("Pagamento inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbNumero.SelectAll();
				tbNumero.Focus();

				return;
			}

			switch (_pagamento.Situacao)
			{
			case 'P':
				MessageBox.Show("Pagamento já efetuado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				tbNumero.SelectAll();
				tbNumero.Focus();

				return;

			case 'C':
				MessageBox.Show("Pagamento cancelado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				tbNumero.SelectAll();
				tbNumero.Focus();

				return;
			}

			if (_pagamento.Situacao != 'A' && _pagamento.Situacao != 'R')
			{
				return;
			}

			if (_pagamento.Cliente != null)
			{
				_dsoftBd.CarregarDadosCliente(_pagamento.Cliente);

				tbCliente.Text = _pagamento.Cliente.Nome;
			}

			dtVencimento.Value = _pagamento.Vencimento;

			tbValor.Text = _pagamento.Valor[0].ToString("###,###,##0.00");
			tbMulta.Text = "0,00";
			tbPago.Text = _pagamento.TotalPago.ToString("###,###,##0.00");
			tbTotal.Text = (_pagamento.Valor[0] - _pagamento.TotalPago).ToString("###,###,##0.00");

			cbForma1.Enabled = true;
			cbForma1.Focus();
		}

		private void cbForma1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma1.Text.Length == 0)
					return;

				switch (cbForma1.Text[0])
				{
				case 'C':
				case 'c':
				case 'D':
				case 'd':
				case 'M':
				case 'm':
				case 'V':
				case 'v':
					tbVal1.Enabled = true;
					tbVal1.Focus();

					return;

				case 'X':
				case 'x':
					tbDoc1.Enabled = true;
					tbDoc1.Focus();

					return;

				default:
					MessageBox.Show("Selecione uma opção válida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbForma1.SelectAll();
					cbForma1.Focus();

					return;
				}
			}
		}

		private void Confirmar()
		{
			if (SomaTotal() > double.Parse(tbTotal.Text))
			{
				if (MessageBox.Show("Confirma a entrega do troco no valor de R$ " + tbTroco.Text + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					!= DialogResult.Yes)
				{
					return;
				}
			}
			else if (SomaTotal() < double.Parse(tbTotal.Text))
			{
				if (MessageBox.Show("Confirma o pagamento parcial da parcela?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					!= DialogResult.Yes)
				{
					return;
				}

				//MessageBox.Show("Não pe possível efetuar esse tipo de pagamento com valor incompleto!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				//return;
			}

			if (ConfirmarPagamento())
			{
				MessageBox.Show("Pagamento confirmado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				if (NumeroPagamento > 0)
					Sair();
				else
					Limpar();
			}
		}

		private bool ConfirmarPagamento()
		{
			int atual = 0;
			bool troco = false;
			double d;

			if (tbTroco.Text.Length > 0 && double.TryParse(tbTroco.Text, out d) && d > 0)
				troco = true;

			Pagamento pagamento = new Pagamento();

			pagamento.Numero = long.Parse(tbNumero.Text);
			pagamento.Multa = double.Parse(tbMulta.Text);
			pagamento.Data = dtPagamento.Value;

			pagamento.Forma = new char[3];
			pagamento.Documento = new string[3];
			pagamento.Valor = new double[3];

			if (cbForma1.Text.Length > 0 && cbForma1.Enabled)
			{
				pagamento.Forma[atual] = cbForma1.Text[0];
				pagamento.Documento[atual] = tbDoc1.Text;
				pagamento.Valor[atual++] = double.Parse(tbVal1.Text);

				if (troco && (cbForma1.Text[0] == 'D' || cbForma1.Text[0] == 'd'))
				{
					pagamento.Valor[atual - 1] -= double.Parse(tbTroco.Text);

					troco = false;
				}
			}
			else
			{
				pagamento.Forma[atual] = '0';
				pagamento.Documento[atual] = string.Empty;
				pagamento.Valor[atual++] = 0;
			}

			if (cbForma2.Text.Length > 0 && cbForma2.Enabled)
			{
				pagamento.Forma[atual] = cbForma2.Text[0];
				pagamento.Documento[atual] = tbDoc2.Text;
				pagamento.Valor[atual++] = double.Parse(tbVal2.Text);

				if (troco && (cbForma1.Text[0] == 'D' || cbForma1.Text[0] == 'd'))
				{
					pagamento.Valor[atual - 1] -= double.Parse(tbTroco.Text);

					troco = false;
				}
			}
			else
			{
				pagamento.Forma[atual] = '0';
				pagamento.Documento[atual] = string.Empty;
				pagamento.Valor[atual++] = 0;
			}

			if (cbForma3.Text.Length > 0 && cbForma3.Enabled)
			{
				pagamento.Forma[atual] = cbForma3.Text[0];
				pagamento.Documento[atual] = tbDoc3.Text;
				pagamento.Valor[atual++] = double.Parse(tbVal3.Text);

				if (troco && (cbForma1.Text[0] == 'D' || cbForma1.Text[0] == 'd'))
				{
					pagamento.Valor[atual - 1] -= double.Parse(tbTroco.Text);

					troco = false;
				}
			}
			else
			{
				pagamento.Forma[atual] = '0';
				pagamento.Documento[atual] = string.Empty;
				pagamento.Valor[atual++] = 0;
			}

			pagamento.TotalPago = double.Parse(tbTotal2.Text);

			if (troco)
			{
				MessageBox.Show("Troco só permito para pagamento em dinheiro!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				return false;
			}

			if (_dsoftBd.ConfirmarPagamento(pagamento, _usuario.Autorizado))
			{
				//Sync
				if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
				{
					Sync.PagaParcela(pagamento);
				}

				return true;
			}
			else
				return false;
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmRecebimentos_Load(object sender, EventArgs e)
		{
			if (NumeroPagamento > 0)
			{
				tbNumero.Text = NumeroPagamento.ToString();
			}

			Atualizar();
		}

		private void Limpar()
		{
			foreach (Control c in this.Controls)
			{
				if (c is TextBox || c is ComboBox)
					c.Text = string.Empty;
			}

			dtVencimento.Value = DateTime.Now;
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private double SomaTotal()
		{
			double v1, v2, v3, t, t2;

			if (tbVal1.Text.Length == 0 || !double.TryParse(tbVal1.Text, out v1))
			{
				v1 = 0;
			}

			if (tbVal2.Text.Length == 0 || !double.TryParse(tbVal2.Text, out v2))
			{
				v2 = 0;
			}

			if (tbVal3.Text.Length == 0 || !double.TryParse(tbVal3.Text, out v3))
			{
				v3 = 0;
			}

			if (!double.TryParse(tbTotal.Text, out t))
				t = 0;

			t2 = v1 + v2 + v3;

			if (t2 > t)
			{
				tbTotal2.Text = t.ToString("###,###,##0.00");
				tbTroco.Text = (t2 - t).ToString("###,###,##0.00");
			}
			else if (t2 == t)
			{
				tbTotal2.Text = t.ToString("###,###,##0.00");
				tbTroco.Text = "0,00";
			}
			else
			{
				tbTotal2.Text = t2.ToString("###,###,##0.00");
				tbTroco.Text = "0,00";
			}

			return t2;
		}

		private void tbDoc1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbVal1.Enabled = true;
				tbVal1.Focus();
			}
		}

		private void tbMulta_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cbForma1.Focus();
		}

		private void tbMulta_Leave(object sender, EventArgs e)
		{
			double multa;

			if (!double.TryParse(tbMulta.Text, out multa))
			{
				multa = 0;
			}

			tbMulta.Text = multa.ToString("0.00");

			double valor = double.Parse(tbValor.Text);
			double pago = double.Parse(tbPago.Text);
			double total;

			total = valor + multa - pago;

			tbTotal.Text = total.ToString("0.00");
		}

		private void tbNumero_KeyDown(object sender, KeyEventArgs e)
		{
			long pagamento;

			if (e.KeyCode != Keys.Enter)
				return;

			if (!long.TryParse(tbNumero.Text, out pagamento))
			{
				MessageBox.Show("Número inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbNumero.SelectAll();
				tbNumero.Focus();

				return;
			}

			CarregarPagamento(pagamento);
		}

		private void tbNumero_Leave(object sender, EventArgs e)
		{
			long numero;

			if (tbNumero.Text.Length > 0)
			{
				if (!long.TryParse(tbNumero.Text, out numero))
				{
					MessageBox.Show("Número inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbNumero.SelectAll();
					tbNumero.Focus();
				}
				else
				{
					CarregarPagamento(numero);
				}
			}
		}

		private void tbVal1_KeyDown(object sender, KeyEventArgs e)
		{
			double valor;

			if (e.KeyCode != Keys.Enter)
				return;

			if (tbVal1.Text.Length == 0)
				return;

			if (!double.TryParse(tbVal1.Text, out valor))
			{
				MessageBox.Show("Valor inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal1.SelectAll();
				tbVal1.Focus();

				return;
			}

			tbVal1.Text = valor.ToString("###,###,##0.00");

			if (SomaTotal() < double.Parse(tbTotal.Text))
			{
				cbForma2.Enabled = true;
				cbForma2.Focus();
			}
			else
			{
				btConfirmar.Focus();
			}
		}

		#endregion Methods
	}
}