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
using DSoftCore;

namespace DSoft_Delivery.Forms
{
	public partial class frmConRecebimentos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConRecebimentos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmConRecebimentos_Load(object sender, EventArgs e)
		{
			dtInicial.Value = dtFinal.Value.AddMonths(-1);
			Consultar();
		}

		private void Consultar()
		{
			DataTable recebimentos = _dsoftBd.CarregarRecebimentos(dtInicial.Value, dtFinal.Value);

			dataGridView1.DataSource = recebimentos;

			if (dataGridView1.Rows.Count > 0)
			{
				decimal valor = 0;
				decimal valor_pago = 0;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					valor += Util.TryParseDecimal(dataGridView1["valor", i].Value);
					valor_pago += Util.TryParseDecimal(dataGridView1["valor_pago", i].Value);
				}

				tbQuantidade.Text = dataGridView1.Rows.Count.ToString();
				tbPagas.Text = valor_pago.ToString(Constants.FORMATO_MOEDA);
				tbTotal.Text = valor.ToString(Constants.FORMATO_MOEDA);
				tbAberto.Text = (valor - valor_pago).ToString(Constants.FORMATO_MOEDA);
			}
		}

		private void Imprimir()
		{

		}

		private void Sair()
		{
			this.Close();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConsultar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}
	}
}
