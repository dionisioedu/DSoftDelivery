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
	public partial class frmConPedidosPorVendedor : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConPedidosPorVendedor(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		void Confirmar()
		{
			DataSet ds = new DataSet();

			tbTotal.Text = _DSoftBd.PedidosPorVendedor(int.Parse(tbCodigo.Text), dtInicial.Value, dtFinal.Value, ds).ToString("###,###,##0.00#");

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["pedido"].Width = 60;
			dataGridView1.Columns["pedido"].HeaderText = "Pedido";
			dataGridView1.Columns["data"].Width = 60;
			dataGridView1.Columns["data"].HeaderText = "Data";
			dataGridView1.Columns["caixa"].Visible = false;
			dataGridView1.Columns["descricao"].HeaderText = "Caixa";
			dataGridView1.Columns["itens"].Width = 40;
			dataGridView1.Columns["itens"].HeaderText = "Itens";
			dataGridView1.Columns["total"].Width = 60;
			dataGridView1.Columns["total"].HeaderText = "Valor";
			dataGridView1.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			tbCodigo.SelectAll();
			tbCodigo.Focus();
		}

		private void dtFinal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Confirmar();
			}
		}

		private void dtInicial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtFinal.Focus();
			}
		}

		private void frmConPedidosPorVendedor_Load(object sender, EventArgs e)
		{
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			int codigo;

			if (e.KeyCode == Keys.Enter)
			{
				if (tbCodigo.Text.Length == 0)
				{
					btSair.Focus();
				}

				if (!int.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Código deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}

				if (!_DSoftBd.RecursoAtivo(codigo))
				{
					MessageBox.Show("Código inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}

				lbNome.Text = _DSoftBd.RecursoNome(codigo);

				dtInicial.Focus();
			}
		}

		#endregion Methods
	}
}