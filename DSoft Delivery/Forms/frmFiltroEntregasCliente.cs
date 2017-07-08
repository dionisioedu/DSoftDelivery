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
	public partial class frmFiltroEntregasCliente : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmFiltroEntregasCliente(Bd bd, Usuario usuario)
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
			string nome = string.Empty;
			char situacao = ' ';

			RelatorioHtml relatorio = new RelatorioHtml();

			DataSet ds = new DataSet();

			relatorio.Arquivo = "Entregas_por_Cliente";
			relatorio.Titulo = "Entregas por Cliente";

			if (textBox1.Text.Length == 0)
			{
				relatorio.Descricao = "Entregas realizadas para todos os clientes entre " + dateTimePicker1.Value.ToShortDateString() +
										" e " + dateTimePicker2.Value.ToShortDateString();

				_DSoftBd.EntregasPorCliente(dateTimePicker1.Value, dateTimePicker2.Value, ds);
			}
			else
			{
				_DSoftBd.ClienteNome(int.Parse(textBox1.Text), out nome, out situacao);

				relatorio.Descricao = "Entregas realizadas para cliente " + textBox1.Text + " - " + nome + " entre " + dateTimePicker1.Value.ToShortDateString() +
						" e " + dateTimePicker2.Value.ToShortDateString();

				_DSoftBd.EntregasPorCliente(dateTimePicker1.Value, dateTimePicker2.Value, int.Parse(textBox1.Text), ds);
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

		private void frmFiltroEntregasCliente_Load(object sender, EventArgs e)
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

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int numero;
			string nome = string.Empty;
			char situacao = ' ';

			if (textBox1.Text.Length > 0)
			{
				if (!int.TryParse(textBox1.Text, out numero))
				{
					MessageBox.Show("Campo 'cliente' deve ser numérico!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				if (!_DSoftBd.ClienteNome((numero), out nome, out situacao))
				{
					MessageBox.Show("Cliente não encontrado!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				label4.Text = nome;
			}
		}

		#endregion Methods
	}
}