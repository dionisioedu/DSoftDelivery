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
	public partial class frmConServicosEfetuadosPorPeriodo : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConServicosEfetuadosPorPeriodo(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmConServicosEfetuadosPorPeriodo_Load(object sender, EventArgs e)
		{

		}

		private void Consultar()
		{
			DataTable dt = _dsoftBd.ConsultaServicosEfetuados(dtInicio.Value, dtFinal.Value);
			dataGridView1.DataSource = dt;

			dataGridView1.Columns["numero"].HeaderText = "OS";
			dataGridView1.Columns["numero"].Width = 80;
			dataGridView1.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["descricao"].HeaderText = "Tipo";
			dataGridView1.Columns["descricao"].Width = 80;
			dataGridView1.Columns["custo"].HeaderText = "Custo R$";
			dataGridView1.Columns["custo"].Width = 80;
			dataGridView1.Columns["custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["custo"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["valor"].HeaderText = "Valor R$";
			dataGridView1.Columns["valor"].Width = 80;
			dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["valor"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["abertura"].HeaderText = "Abertura";
			dataGridView1.Columns["abertura"].Width = 80;
			dataGridView1.Columns["fechamento"].HeaderText = "Fechamento";
			dataGridView1.Columns["fechamento"].Width = 80;
			dataGridView1.Columns["observacao"].HeaderText = "Observações";
			dataGridView1.Columns["observacao"].Width = 210;

			tbTotalServicos.Text = dt.Rows.Count.ToString();

			decimal custo = 0, total = 0;

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				custo += Convert.ToDecimal(dataGridView1["custo", i].Value);
				total += Convert.ToDecimal(dataGridView1["valor", i].Value);
			}

			tbCustoTotal.Text = custo.ToString("##,###,##0.00");
			tbValorTotal.Text = total.ToString("##,###,##0.00");
		}

		private void Sair()
		{
			this.Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtFinal.Focus();
			}
		}

		private void dtFinal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConsultar.Focus();
			}
		}
	}
}
