using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftModels;
using DSoftBd;

namespace DSoft_Delivery.Forms
{
	public partial class frmConServicosEfetuadosPorFuncionario : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConServicosEfetuadosPorFuncionario(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void Consultar()
		{
			Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

			if (funcionario == null)
			{
				DataTable dt = _dsoftBd.ConsultaServicosPorFuncionarios(dtInicio.Value, dtFinal.Value);
				dataGridView1.DataSource = dt;

				dataGridView1.Columns["funcionario"].HeaderText = "Funcionário";
				dataGridView1.Columns["funcionario"].Width = 80;
				dataGridView1.Columns["nome"].HeaderText = "Nome";
				dataGridView1.Columns["nome"].Width = 180;
				dataGridView1.Columns["quantidade"].HeaderText = "Serviços";
				dataGridView1.Columns["quantidade"].Width = 80;
				dataGridView1.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["custos"].HeaderText = "Custo R$";
				dataGridView1.Columns["custos"].Width = 80;
				dataGridView1.Columns["custos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["custos"].DefaultCellStyle.Format = "##,###,##0.00";
				dataGridView1.Columns["valores"].HeaderText = "Valor R$";
				dataGridView1.Columns["valores"].Width = 80;
				dataGridView1.Columns["valores"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["valores"].DefaultCellStyle.Format = "##,###,##0.00";

				int quantidade = 0;
				decimal custos = 0, valores = 0;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					quantidade += Convert.ToInt32(dataGridView1["quantidade", i].Value);
					custos += Convert.ToDecimal(dataGridView1["custos", i].Value);
					valores += Convert.ToDecimal(dataGridView1["valores", i].Value);
				}

				tbTotalServicos.Text = quantidade.ToString();
				tbCustoTotal.Text = custos.ToString("##,###,##0.00");
				tbValorTotal.Text = valores.ToString("##,###,##0.00");
			}
			else
			{
				DataTable dt = _dsoftBd.ConsultaServicosPorFuncionario(funcionario, dtInicio.Value, dtFinal.Value);
				dataGridView1.DataSource = dt;

				dataGridView1.Columns["fechamento"].HeaderText = "Fechamento";
				dataGridView1.Columns["descricao"].HeaderText = "Serviço";
				dataGridView1.Columns["custo"].HeaderText = "Custo R$";
				dataGridView1.Columns["custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["custo"].DefaultCellStyle.Format = "##,###,##0.00";
				dataGridView1.Columns["valor"].HeaderText = "Valor R$";
				dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["valor"].DefaultCellStyle.Format = "##,###,##0.00";

				decimal custos = 0, valores = 0;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					custos += Convert.ToDecimal(dataGridView1["custo", i].Value);
					valores += Convert.ToDecimal(dataGridView1["valor", i].Value);
				}

				tbTotalServicos.Text = dataGridView1.Rows.Count.ToString();
				tbCustoTotal.Text = custos.ToString("##,###,##0.00");
				tbValorTotal.Text = valores.ToString("##,###,##0.00");
			}
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

		private void btConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void frmConServicosEfetuadosPorFuncionario_Load(object sender, EventArgs e)
		{
			CarregarFuncionarios();
		}

		private void CarregarFuncionarios()
		{
			List<Recurso> funcionarios = _dsoftBd.CarregarRecursos();

			cbFuncionario.Items.AddRange(funcionarios.ToArray());
		}

		private void cbFuncionario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				cbFuncionario.SelectedItem = null;
			}
		}
	}
}
