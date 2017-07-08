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
	public partial class frmCadCaixa : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadCaixa(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.CarregarCaixas(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["descricao"].Width = 200;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int row)
		{
			try
			{
				btNovo.Text = "&Confirmar - F2";

				groupBox1.Enabled = true;

				tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
				tbDescricao.Text = dataGridView1.Rows[row].Cells["descricao"].Value.ToString();

				tbCodigo.ReadOnly = true;

				tbDescricao.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void Confirmar()
		{
			if (btNovo.Text == "&Novo - F2")
			{
				btNovo.Text = "&Confirmar - F2";

				groupBox1.Enabled = true;

				tbCodigo.Focus();
			}
			else
			{
				Caixa caixa = new Caixa();

				if (!int.TryParse(tbCodigo.Text, out caixa.Codigo))
				{
					MessageBox.Show("Código inválido!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if ((caixa.Descricao = tbDescricao.Text) == string.Empty)
				{
					MessageBox.Show("Campo 'nome' não pode ser vazio!", this.Text);

					tbDescricao.Focus();

					return;
				}

				if (tbCodigo.ReadOnly)
				{
					if (!_DSoftBd.AlterarCaixa(caixa))
					{
						MessageBox.Show("Registro não foi alterado!", this.Text);

						return;
					}
				}
				else
				{
					if (!_DSoftBd.IncluirCaixa(caixa))
					{
						MessageBox.Show("Registro não foi incluído!", this.Text);

						return;
					}
				}

				LimparDados();

				Atualizar();
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarDados(dataGridView1.CurrentRow.Index);
		}

		private void frmCadCaixa_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void LimparDados()
		{
			tbCodigo.ReadOnly = false;
			tbCodigo.Clear();
			tbDescricao.Clear();

			groupBox1.Enabled = false;

			btNovo.Text = "&Novo - F2";
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text != string.Empty)
			{
				tbDescricao.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbDescricao.Text != string.Empty)
			{
				btNovo.Focus();
			}
		}

		#endregion Methods
	}
}