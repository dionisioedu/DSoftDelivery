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
	public partial class frmFiltroPedidosPeriodo : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmFiltroPedidosPeriodo(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
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
			int caixa;
			double soma;

			RelatorioHtml relatorio = new RelatorioHtml();

			DataSet ds = new DataSet();

			relatorio.Arquivo = "Pedidos_por_Periodo";
			relatorio.Titulo = "Pedidos por Periodo";

			if (textBox1.Text.Length == 0)
			{
				relatorio.Descricao = "Pedidos efetuados em todos os caixas no periodo de " + dateTimePicker1.Value.ToShortDateString() +
										" e " + dateTimePicker2.Value.ToShortDateString();

				soma = _DSoftBd.PedidosPorPeriodo(dateTimePicker1.Value, dateTimePicker2.Value, ds);

				relatorio.Rodape = "TOTAL REAL :   R$" + soma.ToString("###,###,##0.00");
			}
			else
			{
				if (!int.TryParse(textBox1.Text, out caixa) || !_DSoftBd.CaixaAtivo(caixa))
				{
					MessageBox.Show("Caixa inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				relatorio.Descricao = "Pedidos efetuados no caixa " + textBox1.Text + " - " + _DSoftBd.CaixaDescricao(int.Parse(textBox1.Text)) +
					" no periodo de " + dateTimePicker1.Value.ToShortDateString() + " e " + dateTimePicker2.Value.ToShortDateString();

				soma = _DSoftBd.PedidosPorPeriodo(dateTimePicker1.Value, dateTimePicker2.Value, caixa, ds);

				relatorio.Rodape = "VALOR TOTAL :   R$ " + soma.ToString("###,###,##0.00");
			}

			relatorio.Gerar(ds);

			Sair();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dateTimePicker2.Focus();
			}
		}

		private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox1.Focus();
			}
		}

		private void frmFiltroPedidosPeriodo_Load(object sender, EventArgs e)
		{
			dateTimePicker1.Focus();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 0)
			{
				textBox1.SelectAll();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int numero;

			if (textBox1.Text.Length > 0)
			{
				if (!int.TryParse(textBox1.Text, out numero))
				{
					MessageBox.Show("Campo 'caixa' deve ser numérico!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				if ((label4.Text = _DSoftBd.CaixaDescricao(numero)) == string.Empty)
				{
					MessageBox.Show("Caixa não encontrado!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}
			}
		}

		#endregion Methods
	}
}