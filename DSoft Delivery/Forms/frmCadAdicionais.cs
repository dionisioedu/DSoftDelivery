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
	public partial class frmCadAdicionais : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadAdicionais(Bd bd, Usuario usuario)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarItensAdicionais(ds);

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["descricao"].HeaderText = "Descrição";
			dataGridView1.Columns["descricao"].Width = 240;
			dataGridView1.Columns["adicional"].HeaderText = "Valor Adicional";
			dataGridView1.Columns["adicional"].Width = 120;
			dataGridView1.Columns["adicional"].DefaultCellStyle.Format = "###,###,##0.00";
			dataGridView1.Columns["adicional"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Excluir();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Excluir()
		{
			decimal valor;

			if (tbDescricao.Text.Length < 1 || !decimal.TryParse(tbValor.Text, out valor))
			{
				return;
			}

			ItemAdicional itemAdicional = new ItemAdicional();

			itemAdicional.Descricao = tbDescricao.Text;
			itemAdicional.Valor = valor;

			if (_dsoftBd.ExcluirItemAdicional(itemAdicional))
			{
				Atualizar();
				Limpar();
			}
		}

		private void Confirmar()
		{
			decimal valor;

			if (tbDescricao.Text.Length < 1)
			{
				MessageBox.Show("Descrição inválida!");
				tbDescricao.Focus();
				return;
			}

			if (!decimal.TryParse(tbValor.Text, out valor))
			{
				MessageBox.Show("Valor inválido!");
				tbValor.SelectAll();
				tbValor.Focus();
				return;
			}

			ItemAdicional itemAdicional = new ItemAdicional();

			itemAdicional.Descricao = tbDescricao.Text;
			itemAdicional.Valor = valor;

			if (_dsoftBd.AdicionarItemAdicional(itemAdicional))
			{
				Limpar();
				Atualizar();
				tbDescricao.Focus();
			}
			else
			{
				MessageBox.Show("Erro ao gravar dados!");
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				tbDescricao.Text = dataGridView1.SelectedRows[0].Cells["descricao"].Value.ToString();
				tbValor.Text = dataGridView1.SelectedRows[0].Cells["adicional"].Value.ToString();
			}
		}

		private void frmCadAdicionais_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void Limpar()
		{
			tbDescricao.Clear();
			tbValor.Clear();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor.Focus();
			}
		}

		private void tbValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Excluir();
		}

		#endregion Methods
	}
}