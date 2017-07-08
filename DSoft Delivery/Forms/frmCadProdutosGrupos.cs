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
	public partial class frmCadProdutosGrupos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadProdutosGrupos(Bd bd, Usuario usuario)
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

				_DSoftBd.GruposProdutos(ds);

				dataGridView1.DataSource = ds.Tables[0];

				for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
				{
					switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
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
			tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
			tbDescricao.Text = dataGridView1.Rows[row].Cells["descricao"].Value.ToString();

			groupBox1.Enabled = true;

			tbCodigo.ReadOnly = true;

			btConfirmar.Text = "&Confirmar - F2";
		}

		private void Confirmar()
		{
			int codigo;

			try
			{
				if (btConfirmar.Text == "&Novo - F2")
				{
					btConfirmar.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					tbCodigo.Focus();
				}
				else
				{
					if (tbCodigo.Text == string.Empty)
					{
						MessageBox.Show("Campo 'código' deve ser preenchido!", this.Text);

						tbCodigo.Focus();

						return;
					}

					if (!int.TryParse(tbCodigo.Text, out codigo))
					{
						MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

						tbCodigo.SelectAll();

						tbCodigo.Focus();

						return;
					}

					if (tbDescricao.Text == string.Empty)
					{
						MessageBox.Show("Campo 'descrição' deve ser preenchido!", this.Text);

						tbDescricao.Focus();

						return;
					}

					if (tbCodigo.ReadOnly) // Se o ReadOnly for true, quer dizer que se trata de alteração
					{
						if (_DSoftBd.AlterarProdutoGrupo(codigo, tbDescricao.Text))
						{
							LimparCampos();

							Atualizar();
						}
					}
					else
					{
						if (_DSoftBd.NovoProdutoGrupo(codigo, tbDescricao.Text))
						{
							LimparCampos();

							Atualizar();
						}
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

		private void frmCadGruposProdutos_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparCampos();
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbDescricao.Clear();

			btConfirmar.Text = "&Novo - F2";

			groupBox1.Enabled = false;

			tbCodigo.ReadOnly = false;
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
				tbDescricao.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbDescricao.Text.Length > 0)
			{
				btConfirmar.Focus();
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		#endregion Methods
	}
}