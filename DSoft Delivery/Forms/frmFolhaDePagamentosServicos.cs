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
	public partial class frmFolhaDePagamentosServicos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private List<PagamentoFuncionario> _pagamentos;

		public frmFolhaDePagamentosServicos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmFolhaDePagamentosServicos_Load(object sender, EventArgs e)
		{

		}

		private void Gerar()
		{
			_pagamentos = _dsoftBd.GerarPagamentos(dtInicial.Value, dtFinal.Value);

			DataTable table = new DataTable();
			table.Columns.Add("Codigo", typeof(long));
			table.Columns.Add("Funcionario");
			table.Columns.Add("Valor", typeof(decimal));
			table.Columns.Add("Observacao");
			table.Columns.Add("Efetuar", typeof(bool));

			if (_pagamentos != null && _pagamentos.Count > 0)
			{
				foreach (PagamentoFuncionario pagamento in _pagamentos)
				{
					DataRow row = table.NewRow();
					row["Codigo"] = pagamento.Funcionario.Codigo;
					row["Funcionario"] = pagamento.Funcionario.Nome;
					row["Valor"] = pagamento.Valor;
					row["Observacao"] = pagamento.Observacao;
					row["Efetuar"] = true;

					table.Rows.Add(row);
				}

				dataGridView1.DataSource = table;

				dataGridView1.Columns["Codigo"].Visible = false;
				dataGridView1.Columns["Funcionario"].Width = 210;
				dataGridView1.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["Valor"].DefaultCellStyle.Format = "##,###,##0.00";
				dataGridView1.Columns["Observacao"].Width = 300;
			}
		}

		private void Pagar()
		{
			if (_pagamentos != null && _pagamentos.Count > 0)
			{
				foreach (PagamentoFuncionario pagamento in _pagamentos)
				{
					_dsoftBd.EfetuarPagamento(pagamento, _usuario);
				}

				ImprimirComprovantes();

				dataGridView1.DataSource = null;
			}
		}

		private void ImprimirComprovantes()
		{
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.Show();
		}

		private void Sair()
		{
			this.Close();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Gerar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btGerar_Click(object sender, EventArgs e)
		{
			Gerar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void btPagar_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			float yPos = 0;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float width = e.MarginBounds.Width;
			Font printFont = new Font("Arial", 10);
			Font titleFont = new Font("Arial", 14, FontStyle.Bold);
			Font italicFont = new Font("Arial", 10, FontStyle.Italic);

			yPos = topMargin;

			e.Graphics.DrawString("Relatório de pagamentos", titleFont, Brushes.Black, leftMargin, yPos, new StringFormat());
			e.Graphics.DrawString(string.Format("{0} - {1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()), printFont, Brushes.Black, leftMargin + 500, yPos, new StringFormat());
			yPos += titleFont.GetHeight(e.Graphics);
			yPos += printFont.GetHeight(e.Graphics);
			e.Graphics.DrawLine(Pens.Black, new Point((int)leftMargin, (int)yPos), new Point(700, (int)yPos));
			yPos += printFont.GetHeight(e.Graphics);

			foreach (PagamentoFuncionario pagamento in _pagamentos)
			{
				if (pagamento.Valor > 0)
				{
					e.Graphics.DrawString(pagamento.Funcionario.Codigo.ToString(), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
					e.Graphics.DrawString(pagamento.Funcionario.Nome, printFont, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
					e.Graphics.DrawString(string.Format("R$ {0}", pagamento.Valor.ToString("##,###,##0.00")), printFont, Brushes.Black, leftMargin + 500, yPos, new StringFormat());

					yPos += printFont.GetHeight(e.Graphics);
				}
			}

			e.Graphics.DrawLine(Pens.Black, new Point((int)leftMargin, (int)yPos), new Point(700, (int)yPos));
			yPos += printFont.GetHeight(e.Graphics);

			e.HasMorePages = false;
		}
	}
}
