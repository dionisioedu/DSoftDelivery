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
	public partial class frmCadRecursosGrupos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadRecursosGrupos(Bd bd, Usuario usuario)
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

				_DSoftBd.GruposRecursos(ds);

				dataGridView1.DataSource = ds.Tables[0];

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
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
			Cancelar();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void Confirmar()
		{
			try
			{
				int codigo;
				string nome;

				if (tbCodigo.Text != string.Empty && int.TryParse(tbCodigo.Text, out codigo))
				{
					if (tbDescricao.Text == string.Empty)
					{
						MessageBox.Show("Campo 'descrição' deve ser preenchido!");

						return;
					}

					nome = string.Copy(tbDescricao.Text);

					if (_DSoftBd.GrupoRecursosExiste(codigo))
					{
						if (_DSoftBd.AlterarGrupoRecursos(codigo, nome))
						{
							Atualizar();

							LimparDados();
						}
					}
					else
					{
						if (_DSoftBd.NovoGrupoRecursos(codigo, nome))
						{
							Atualizar();

							LimparDados();
						}
					}
				}
				else
				{
					MessageBox.Show("Campo 'código' inválido!");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void frmCadRecursosGrupos_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void LimparDados()
		{
			tbCodigo.Clear();
			tbDescricao.Clear();

			tbCodigo.Focus();
		}

		private void listagemDeGruposDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.CarregarRecursosGrupos(ds);

				RelatorioHtml relatorio = new RelatorioHtml();

				relatorio.Titulo = relatorio.Arquivo = "Listagem Grupos Recursos";

				relatorio.Descricao = "Listagem de todos os grupos de recursos cadastrados no sistema. Relatorio emitido em " + DateTime.Now.ToShortDateString() + " as " + DateTime.Now.ToShortTimeString();

				relatorio.Gerar(ds);
			}
			catch (Exception erro)
			{
				MessageBox.Show(erro.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbDescricao.Focus();
			}
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbDescricao.Text.Length > 0)
			{
				btConfirmar.Focus();
			}
		}
	}
}