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
	public partial class frmEntregasCompras : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmEntregasCompras(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.CarregarEntregasCompras(ds);

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["indice"].HeaderText = "Índice";
			dataGridView1.Columns["indice"].Width = 60;
			dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["previsao_data"].HeaderText = "Previsão";
			dataGridView1.Columns["previsao_data"].Width = 60;
			dataGridView1.Columns["previsao_hora"].HeaderText = "Hora";
			dataGridView1.Columns["previsao_hora"].Width = 60;
			dataGridView1.Columns["previsao_hora"].DefaultCellStyle.Format = "hh:mm:ss";
			dataGridView1.Columns["fornecedor_nome"].HeaderText = "Fornecedor";
			dataGridView1.Columns["fornecedor_nome"].Width = 120;
			dataGridView1.Columns["produto"].HeaderText = "Produto";
			dataGridView1.Columns["produto"].Width = 60;
			dataGridView1.Columns["produto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["nome"].HeaderText = "Nome";
			dataGridView1.Columns["nome"].Width = 150;
			dataGridView1.Columns["quantidade"].HeaderText = "Quant.";
			dataGridView1.Columns["quantidade"].Width = 60;
			dataGridView1.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["entrega_data"].HeaderText = "Entrega";
			dataGridView1.Columns["entrega_data"].Width = 60;
			dataGridView1.Columns["entrega_hora"].HeaderText = "Hora";
			dataGridView1.Columns["entrega_hora"].Width = 60;
			dataGridView1.Columns["entrega_hora"].DefaultCellStyle.Format = "hh:mm:ss";
			dataGridView1.Columns["situacao"].HeaderText = "Sit.";
			dataGridView1.Columns["situacao"].Width = 30;

			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				if (r.Cells["situacao"].Value.ToString() == "E")
				{
					r.DefaultCellStyle.BackColor = Color.DarkBlue;
					r.DefaultCellStyle.ForeColor = Color.White;
				}
			}

			if (dataGridView1.Rows.Count > 0)
				dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Confirmar()
		{
			if (tbIndice.Text.Length == 0)
				return;

			if (MessageBox.Show("Confirma o recebimento de " + tbQuantidade.Text + " do produto " + tbProduto.Text + " ?", this.Text,
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				return;

			if (_DSoftBd.ConfirmarEntregaCompra(int.Parse(tbIndice.Text), _usuario.Autorizado))
			{
				tbIndice.Clear();
				tbFornecedor.Clear();
				tbProduto.Clear();
				tbQuantidade.Clear();

				Atualizar();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 0)
				return;

			int r = dataGridView1.SelectedRows[0].Index;

			tbIndice.Text = dataGridView1.Rows[r].Cells["indice"].Value.ToString();
			tbFornecedor.Text = dataGridView1.Rows[r].Cells["fornecedor_nome"].Value.ToString();
			tbProduto.Text = dataGridView1.Rows[r].Cells["nome"].Value.ToString();
			tbQuantidade.Text = dataGridView1.Rows[r].Cells["quantidade"].Value.ToString();

			if (dataGridView1.Rows[r].Cells["situacao"].Value.ToString() == "A")
			{
				btConfirmar.Enabled = true;
				btConfirmar.Focus();
			}
			else
			{
				btConfirmar.Enabled = false;
			}
		}

		private void frmEntregasCompras_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods
	}
}