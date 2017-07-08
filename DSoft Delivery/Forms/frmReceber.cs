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
	public partial class frmReceber : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private frmCadRecebimentosTipos _cadRecebimentos;
		private Recebimento _recebimento;

		public frmReceber(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmReceber_Load(object sender, EventArgs e)
		{
			CarregarTipos();
			CarregarClientes();
			CarregarRecebimentos();
		}

		private void CarregarRecebimentos()
		{
			DataTable recebimentos = _dsoftBd.CarregarRecebimentos();

			dgRecebimentos.DataSource = recebimentos;

			dgRecebimentos.Columns["indice"].HeaderText = "Índice";
			dgRecebimentos.Columns["data"].HeaderText = "Data";
			dgRecebimentos.Columns["nome"].HeaderText = "Cliente";
			dgRecebimentos.Columns["vencimento"].HeaderText = "Vencimento";
			dgRecebimentos.Columns["valor"].HeaderText = "Valor (R$)";
			dgRecebimentos.Columns["valor"].DefaultCellStyle.Format = "##,###,##0.00";
			dgRecebimentos.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgRecebimentos.Columns["valor_pago"].HeaderText = "Pago (R$)";
			dgRecebimentos.Columns["valor_pago"].DefaultCellStyle.Format = "##,###,##0.00";
			dgRecebimentos.Columns["valor_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgRecebimentos.Columns["situacao"].HeaderText = "Situação";
			dgRecebimentos.Columns["nome1"].HeaderText = "Tipo";
			dgRecebimentos.Columns["pago_data"].HeaderText = "Pagamento";

			Util.Pintar(ref dgRecebimentos);

			if (dgRecebimentos.Rows.Count > 1)
			{
				dgRecebimentos.FirstDisplayedScrollingRowIndex = dgRecebimentos.Rows.Count - 1;
			}
		}

		private void CarregarTipos()
		{
			List<RecebimentoTipo> tipos = _dsoftBd.RecebimentosTipos();

			cbTipo.Items.Clear();

			cbTipo.Items.AddRange(tipos.ToArray());

			if (cbTipo.Items.Count > 0)
			{
				cbTipo.SelectedIndex = 0;
			}
		}

		private void CarregarClientes()
		{
			List<Cliente> clientes = _dsoftBd.CarregarClientes();

			cbCliente.Items.Add("");
			cbCliente.Items.AddRange(clientes.ToArray());

			cbCliente.SelectedIndex = 0;
		}

		private void Novo()
		{
			if (tbValor.Text.Length > 0 && cbCliente.SelectedItem != null && cbCliente.SelectedItem.ToString() != "")
			{
				decimal valor;

				if (decimal.TryParse(tbValor.Text, out valor) && valor > 0)
				{
					Recebimento rec = new Recebimento();
					rec.Tipo = (RecebimentoTipo)cbTipo.SelectedItem;
					rec.Cliente = (Cliente)cbCliente.SelectedItem;
					rec.Valor = valor;
					rec.Vencimento = dtVencimento.Value;
					rec.Observacao = tbObservacao.Text;
					rec.Hora = DateTime.Now;
					rec.Usuario = _usuario;

					if (_dsoftBd.IncluirRecebimento(rec) > 0)
					{
						CarregarRecebimentos();
						Limpar();
					}
				}
			}
		}

		private void Cancelar()
		{
			if (_recebimento != null && _recebimento.Situacao == Situacoes.Ativo)
			{
				if (MessageBox.Show("Confirmar cancelamento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
					== System.Windows.Forms.DialogResult.Yes)
				{
					_recebimento.Usuario = _usuario;

					if (_dsoftBd.CancelarRecebimento(_recebimento))
					{
						Limpar();
						CarregarRecebimentos();
					}
				}
			}
		}

		private void Pagar()
		{
			if (_recebimento != null && _recebimento.Situacao == Situacoes.Ativo)
			{
				if (MessageBox.Show("Confirmar pagamento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
					== System.Windows.Forms.DialogResult.Yes)
				{
					_recebimento.Usuario = _usuario;
					_recebimento.Pagamento = DateTime.Now;
					_recebimento.ValorPago = _recebimento.Valor;

					if (_dsoftBd.ConfirmarPagamento(_recebimento))
					{
						Limpar();
						CarregarRecebimentos();
					}
				}
			}
		}

		private void Limpar()
		{
			cbCliente.SelectedIndex = 0;
			dtVencimento.Value = DateTime.Today;
			tbValor.Text = string.Empty;
			tbObservacao.Text = string.Empty;

			_recebimento = null;

			btNovo.Text = "&Novo - F2";
			btNovo.Enabled = true;

			btCancelar.Enabled = false;
			btPagar.Enabled = false;
		}

		private void Sair()
		{
			this.Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Novo();
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (_cadRecebimentos == null)
			{
				_cadRecebimentos = new frmCadRecebimentosTipos(_dsoftBd, _usuario);
				_cadRecebimentos.Show();

				_cadRecebimentos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_cadRecebimentos.Dispose();
					_cadRecebimentos = null;

					CarregarTipos();
				});
			}
			else
			{
				_cadRecebimentos.Focus();
			}
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btNovo_Click(object sender, EventArgs e)
		{
			Novo();
		}

		private void btPagar_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void frmReceber_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_cadRecebimentos != null)
			{
				_cadRecebimentos.Close();
			}
		}

		private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void CarregarRecebimento(int indice)
		{
			_recebimento = _dsoftBd.CarregarRecebimento(indice);

			cbTipo.SelectedItem = _recebimento.Tipo;
			cbCliente.SelectedItem = _recebimento.Cliente;
			dtVencimento.Value = _recebimento.Vencimento;
			tbValor.Text = _recebimento.Valor.ToString("##,###,##0.00");
			tbObservacao.Text = _recebimento.Observacao;

			if (_recebimento.Situacao == Situacoes.Ativo)
			{
				btNovo.Text = "&Confirmar F2";
				btPagar.Enabled = true;
				btCancelar.Enabled = true;
			}
			else
			{
				btNovo.Text = "&Novo - F2";
				btNovo.Enabled = false;
				btPagar.Enabled = false;
				btCancelar.Enabled = false;
			}
		}

		private void dgRecebimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			CarregarRecebimento(Convert.ToInt32(dgRecebimentos[0, e.RowIndex].Value));
		}

		private void consultaDeContasÀReceberToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConRecebimentos form = new frmConRecebimentos(_dsoftBd, _usuario);
			form.Show();
		}
	}
}
