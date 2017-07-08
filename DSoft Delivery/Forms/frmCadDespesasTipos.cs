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
	public partial class frmCadDespesasTipos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadDespesasTipos(Bd bd, Usuario usuario)
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

				_DSoftBd.CarregarDespesasTipos(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["nome"].Width = 210;
				dataGridView1.Columns["descricao"].Width = 300;
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
			LimparCampos();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int row)
		{
			btConfirmar.Text = "&Confirmar - F2";

			groupBox1.Enabled = true;

			tbCodigo.ReadOnly = true;

			tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
			tbNome.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();
			tbDescricao.Text = dataGridView1.Rows[row].Cells["descricao"].Value.ToString();

			tbNome.Focus();
		}

		private void Confirmar()
		{
			try
			{
				DespesaTipo tipo = new DespesaTipo();

				if (btConfirmar.Text == "&Novo - F2")
				{
					btConfirmar.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					tbCodigo.Focus();

					return;
				}

				if (tbCodigo.Text.Length < 1)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!", this.Text);

					tbCodigo.Focus();

					return;
				}

				if (!long.TryParse(tbCodigo.Text, out tipo.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if (tbNome.Text.Length < 1)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!", this.Text);

					tbNome.Focus();

					return;
				}

				tipo.Nome = tbNome.Text;
				tipo.Descricao = tbDescricao.Text;

				if (tbCodigo.ReadOnly)
				{
					if (_DSoftBd.AlterarDespesaTipo(tipo))
					{
						LimparCampos();

						Atualizar();
					}
				}
				else
				{
					if (_DSoftBd.NovoDespesaTipo(tipo))
					{
						LimparCampos();

						Atualizar();
					}
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(dataGridView1.CurrentRow.Index);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text);
			}
		}

		private void frmCadDespesasTipos_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparCampos();
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			tbDescricao.Clear();

			btConfirmar.Text = "&Novo - F2";

			groupBox1.Enabled = false;

			tbCodigo.ReadOnly = false;
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
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
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long codigo;

			if (tbCodigo.Text.Length > 0)
			{
				if (!long.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();
				}
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbNome.Text.Length > 0)
			{
				tbDescricao.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		#endregion Methods
	}
}