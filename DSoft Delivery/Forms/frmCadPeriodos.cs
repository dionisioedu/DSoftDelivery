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
	public partial class frmCadPeriodos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Periodo _periodo;

		public frmCadPeriodos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCadPeriodos_Load(object sender, EventArgs e)
		{
			Limpar();
			CarregarPeriodos();
		}

		private void CarregarPeriodos()
		{
			DataTable dt = _dsoftBd.CarregarPeriodos();
			dataGridView1.DataSource = dt;

			dataGridView1.Columns["id"].HeaderText = "Código";
			dataGridView1.Columns["id"].Width = 60;
			dataGridView1.Columns["descricao"].HeaderText = "Descrição";
			dataGridView1.Columns["inicial"].HeaderText = "Inicial";
			dataGridView1.Columns["inicial"].Width = 80;
			dataGridView1.Columns["inicial"].DefaultCellStyle.Format = "HH:mm:ss";
			dataGridView1.Columns["final"].HeaderText = "Final";
			dataGridView1.Columns["final"].Width = 80;
			dataGridView1.Columns["final"].DefaultCellStyle.Format = "HH:mm:ss";
		}

		private void Confirmar()
		{
			Periodo periodo = new Periodo();

			periodo.Id = tbId.Text;
			periodo.Descricao = tbDescricao.Text;
			periodo.Inicio = dtInicial.Value;
			periodo.Final = dtFinal.Value;

			if (periodo.isValid)
			{
				if (_dsoftBd.InsertOrUpdate(periodo))
				{
					Limpar();
					CarregarPeriodos();
				}
			}
		}

		private void Excluir()
		{
			if (_periodo != null)
			{
				if (_dsoftBd.Delete(_periodo))
				{
					Limpar();
					CarregarPeriodos();
				}
			}
		}

		private void Limpar()
		{
			_periodo = null;

			tbId.Text = string.Empty;
			tbDescricao.Text = string.Empty;
			dtInicial.Value = DateTime.Today;
			dtFinal.Value = DateTime.Today;

			tbId.Enabled = true;
		}

		private void CarregarPeriodo(string id, string descricao, DateTime inicial, DateTime final)
		{
			_periodo = new Periodo();
			_periodo.Id = id;
			_periodo.Descricao = descricao;
			_periodo.Inicio = inicial;
			_periodo.Final = final;

			inicial = inicial.AddYears(DateTime.Today.Year);
			inicial = inicial.AddMonths(DateTime.Today.Month);
			inicial = inicial.AddDays(DateTime.Today.Day);

			final = final.AddYears(DateTime.Today.Year);
			final = final.AddMonths(DateTime.Today.Month);
			final = final.AddDays(DateTime.Today.Day);

			tbId.Text = id;
			tbDescricao.Text = descricao;
			dtInicial.Value = inicial;
			dtFinal.Value = final;

			tbId.Enabled = false;
		}

		private void Sair()
		{
			this.Close();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btExcluir_Click(object sender, EventArgs e)
		{
			Excluir();
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
			string id = dataGridView1["id", e.RowIndex].Value.ToString();
			string descricao = dataGridView1["descricao", e.RowIndex].Value.ToString();
			DateTime inicial = Convert.ToDateTime(dataGridView1["inicial", e.RowIndex].Value);
			DateTime final = Convert.ToDateTime(dataGridView1["final", e.RowIndex].Value);

			CarregarPeriodo(id, descricao, inicial, final);
		}
	}
}
