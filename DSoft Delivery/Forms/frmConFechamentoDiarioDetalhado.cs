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
	public partial class frmConFechamentoDiarioDetalhado : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConFechamentoDiarioDetalhado(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void Consultar()
		{
			int fechamento = _dsoftBd.FechamentoDiario(dtData.Value);

			if (fechamento > 0)
			{
				DataTable dt = _dsoftBd.CarregarDetalhesFechamento(fechamento);

				dataGridView1.DataSource = dt;

				dataGridView1.Columns["comanda"].HeaderText = "Comanda";
				dataGridView1.Columns["comanda"].Width = 80;
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["data"].Width = 80;
				dataGridView1.Columns["hora"].HeaderText = "Hora";
				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
				dataGridView1.Columns["hora"].Width = 80;
				dataGridView1.Columns["forma"].HeaderText = "Forma";
				dataGridView1.Columns["forma"].Width = 60;
				dataGridView1.Columns["total"].HeaderText = "Valor R$";
				dataGridView1.Columns["total"].Width = 90;
				dataGridView1.Columns["total"].DefaultCellStyle.Format = "##,###,##0.00";
			}
			else
			{
				MessageBox.Show("Não foi possível localizar um fechamento diário para a data solicitada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				dtData.Focus();
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void Imprimir()
		{
			if (dataGridView1.Rows.Count > 0)
			{
				List<ItemFechamentoDetalhe> itens = new List<ItemFechamentoDetalhe>();

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					ItemFechamentoDetalhe item = new ItemFechamentoDetalhe();

					item.Comanda = Convert.ToInt32(dataGridView1["comanda", i].Value);
					item.DataHora = Convert.ToDateTime(dataGridView1["data", i].Value);
					DateTime hora = Convert.ToDateTime(dataGridView1["hora", i].Value);
					item.DataHora = item.DataHora.AddHours(hora.Hour);
					item.DataHora = item.DataHora.AddMinutes(hora.Minute);
					item.DataHora = item.DataHora.AddSeconds(hora.Second);
					item.FormaDePagamento = dataGridView1["forma", i].Value.ToString();
					item.Valor = Convert.ToDecimal(dataGridView1["total", i].Value);

					itens.Add(item);
				}

				Impressora.ImprimirFechamentoDetalhado(dtData.Value, itens);
			}
		}

		private void Exportar()
		{
			if (dataGridView1.Rows.Count > 0)
			{
				//Microsoft.Office.Interop.Excel.Application xlApp;
				//Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
				//Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
				//object missValue = System.Reflection.Missing.Value;

				//xlApp = new Microsoft.Office.Interop.Excel.Application();
				//xlWorkBook = xlApp.Workbooks.Add(missValue);
			}
		}

		private void btConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btImprmir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btExportar_Click(object sender, EventArgs e)
		{
			Exportar();
		}

		private void dtData_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConsultar.Focus();
			}
		}

		private void dtData_ValueChanged(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
		}
	}
}
