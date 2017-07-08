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
using System.Windows.Forms.DataVisualization.Charting;

namespace DSoft_Delivery.Forms
{
	public partial class frmConDiaDia : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConDiaDia(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void Atualizar()
		{
			DataTable movimentos = _dsoftBd.ConsultaMovimentoDiaDia(dtInicio.Value, dtFinal.Value);

			dgConsulta.DataSource = movimentos;

			// Design da grid
			dgConsulta.Columns["data"].HeaderText = "Data";
			dgConsulta.Columns["data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgConsulta.Columns["entrada"].HeaderText = "Entrada (R$)";
			dgConsulta.Columns["entrada"].DefaultCellStyle.Format = "#,###,##0.00";
			dgConsulta.Columns["entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgConsulta.Columns["entrada"].Width = 80;
			dgConsulta.Columns["venda_direta"].HeaderText = "Balcão (R$)";
			dgConsulta.Columns["venda_direta"].DefaultCellStyle.Format = "#,###,##0.00";
			dgConsulta.Columns["venda_direta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgConsulta.Columns["venda_direta"].Width = 80;
			dgConsulta.Columns["cliente_interno"].HeaderText = "Mesas (R$)";
			dgConsulta.Columns["cliente_interno"].DefaultCellStyle.Format = "#,###,##0.00";
			dgConsulta.Columns["cliente_interno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgConsulta.Columns["cliente_interno"].Width = 80;
			dgConsulta.Columns["delivery"].HeaderText = "Delivery (R$)";
			dgConsulta.Columns["delivery"].DefaultCellStyle.Format = "#,###,##0.00";
			dgConsulta.Columns["delivery"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgConsulta.Columns["delivery"].Width = 80;

			if (movimentos != null)
			{
				Series serieEntrada = chMovimento.Series[0];
				Series serieBalcao = chMovimento.Series[1];
				Series serieMesas = chMovimento.Series[2];
				Series serieDelivery = chMovimento.Series[3];

				serieEntrada.Points.Clear();
				serieBalcao.Points.Clear();
				serieMesas.Points.Clear();
				serieDelivery.Points.Clear();

				foreach (DataRow r in movimentos.Rows)
				{
					DateTime date_value = Convert.ToDateTime(r["data"]);

					serieEntrada.Points.AddXY(date_value.ToShortDateString(), Convert.ToDouble(r["entrada"]));
					serieBalcao.Points.AddXY(date_value.ToShortDateString(), Convert.ToDouble(r["venda_direta"]));
					serieMesas.Points.AddXY(date_value.ToShortDateString(), Convert.ToDouble(r["cliente_interno"]));
					serieDelivery.Points.AddXY(date_value.ToShortDateString(), Convert.ToDouble(r["delivery"]));
				}
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void siarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btAtualizar_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void frmConDiaDia_Load(object sender, EventArgs e)
		{
			dtInicio.Value = dtFinal.Value.AddMonths(-1);
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
				btAtualizar.Focus();
			}
		}
	}
}
