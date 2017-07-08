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

namespace DSoft_Delivery.Forms
{
	public partial class frmCadFormasDePagamento : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private FormaDePagamento _formaDePagamento = null;

		public frmCadFormasDePagamento(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCadFormasDePagamento_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void Atualizar()
		{
			DataTable dt = _dsoftBd.CarregarFormasDePagamento();

			dataGridView1.DataSource = dt;
		}

		private void Confirmar()
		{
			if (tbCodigo.Text.Length > 0)
			{
				//if (tbCodigo.Text == "A" || tbCodigo.Text == "D")
				//{
				//    MessageBox.Show("Forma de pagamento reservada do sistema, não pode ser alterada!");
				//    return;
				//}

				_formaDePagamento = new FormaDePagamento();
				_formaDePagamento.Codigo = tbCodigo.Text[0];
				_formaDePagamento.Descricao = tbDescricao.Text;
				_formaDePagamento.Debito = cbDebito.Checked;
				_formaDePagamento.Ativo = cbAtivo.Checked;

				if (_dsoftBd.InsertOrUpdate(_formaDePagamento))
				{
					Limpar();
					Atualizar();
				}
			}
		}

		private void Limpar()
		{
			tbCodigo.Text = string.Empty;
			tbDescricao.Text = string.Empty;
			cbDebito.Checked = false;
			cbAtivo.Checked = false;
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

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			tbCodigo.Text = dataGridView1["codigo", e.RowIndex].Value.ToString();
			tbDescricao.Text = dataGridView1["descricao", e.RowIndex].Value.ToString();
			cbDebito.Checked = Convert.ToBoolean(dataGridView1["debito", e.RowIndex].Value);
			cbAtivo.Checked = Convert.ToBoolean(dataGridView1["ativo", e.RowIndex].Value);

			tbDescricao.Focus();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbDescricao.Focus();
			}
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}
	}
}
