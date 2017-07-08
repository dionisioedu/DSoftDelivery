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
	public partial class frmFiltroData : Form
	{
		#region Fields

		public DateTime Final;
		public DateTime Inicial;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmFiltroData(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			if (this.Text == "Entregas por Período")
			{
				RelatorioHtml relatorio = new RelatorioHtml();

				relatorio.Arquivo = "Entregas_por_Periodo";
				relatorio.Titulo = "Entregas por Período";
				relatorio.Descricao = "Entregas realizadas por todos os entregadores dentro do período especificado.";

				DataSet ds = new DataSet();

				_dsoftBd.EntregasPorPeriodo(dateTimePicker1.Value, dateTimePicker2.Value, ds);

				relatorio.Gerar(ds);
			}
			else if (this.Text == "Pedidos em Aberto")
			{
				double total;

				RelatorioHtml relatorio = new RelatorioHtml();

				relatorio.Arquivo = "Pedidos_Aberto";
				relatorio.Titulo = "Pedidos em Aberto";
				relatorio.Descricao = "Pedidos em Aberto dentro do período especificado.";

				DataSet ds = new DataSet();

				total = _dsoftBd.PedidosEmAberto(dateTimePicker1.Value, dateTimePicker2.Value, ds);

				relatorio.Rodape = "A soma total dos pedidos é de R$ " + total.ToString("#,###,##0.00") + ".";

				relatorio.Gerar(ds);
			}

			Inicial = dateTimePicker1.Value;
			Final = dateTimePicker2.Value;

			DialogResult = DialogResult.OK;

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dateTimePicker2.Focus();
			}
		}

		private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void frmFiltroData_Load(object sender, EventArgs e)
		{
		}

		private void Sair()
		{
			DialogResult = DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods
	}
}