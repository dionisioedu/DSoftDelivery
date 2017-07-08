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
	public partial class frmConClientesPorPedidos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private DataSet _dados;

		public frmConClientesPorPedidos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmConClientesPorPedidos_Load(object sender, EventArgs e)
		{
			dtInicio.Value = DateTime.Today.AddMonths(-1);
		}

		private void Consultar()
		{
			if (radioButton1.Checked)
			{
				_dados = _dsoftBd.ClientesPorQuantidadeDePedidos(dtInicio.Value, dtFinal.Value);
			}
			else
			{
				_dados = _dsoftBd.ClientesPorValorDePedidos(dtInicio.Value, dtFinal.Value);
			}

			if (_dados != null && _dados.Tables.Count > 0)
			{
				dataGridView1.DataSource = _dados.Tables[0];

				dataGridView1.Columns["cliente"].HeaderText = "Código";
				dataGridView1.Columns["cliente"].Width = 80;
				dataGridView1.Columns["nome"].HeaderText = "Cliente";
				dataGridView1.Columns["nome"].Width = 180;
				dataGridView1.Columns["quantidade"].HeaderText = "Qtd.";
				dataGridView1.Columns["quantidade"].Width = 60;
				dataGridView1.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["total"].HeaderText = "Total (R$)";
				dataGridView1.Columns["total"].Width = 90;
				dataGridView1.Columns["total"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void btConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void dtInicio_KeyDown(object sender, KeyEventArgs e)
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

		private void btImprimir_Click(object sender, EventArgs e)
		{
			if (_dados != null)
			{
				RelatorioHtml relatorio = new RelatorioHtml();
				relatorio.Titulo = "Clientes por pedidos";
				relatorio.Arquivo = "ClientesPorPedidos";
				relatorio.Descricao = string.Format("Consulta de clientes por pedidos no período de {0} à {1}.", dtInicio.Value.ToShortDateString(), dtFinal.Value.ToShortDateString());

				relatorio.Gerar(_dados);
			}
		}
	}
}
