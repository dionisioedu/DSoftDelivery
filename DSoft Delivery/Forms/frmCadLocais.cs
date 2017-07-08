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
	public partial class frmCadLocais : Form
	{
		#region Fields

		public static bool Editando = false;

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadLocais(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.CarregarLocais(ds);

			dataGridView1.DataSource = ds.Tables[0];

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "C":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					break;
				}
			}
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btIncluir_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (dataGridView1.SelectedRows.Count > 0)
				{
					if (_DSoftBd.CancelarLocal(int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString())))
					{
						Atualizar();
					}
				}
			}
			else
			{
				if (dataGridView1.SelectedRows.Count > 0)
				{
					if (_DSoftBd.ReativarLocal(int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString())))
					{
						Atualizar();
					}
				}
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void Confirmar()
		{
			if (btIncluir.Text == "&Incluir - F2")
			{
				HabilitarCampos();
				Limpar();

				btIncluir.Text = "&Confirmar - F2";

				Editando = false;

				tbCodigo.Focus();
			}
			else
			{
				Local local = new Local();

				if (tbCodigo.Text.Length < 1)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.Focus();

					return;
				}

				if (!int.TryParse(tbCodigo.Text, out local.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}

				if (tbNome.Text.Length < 1)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbNome.Focus();

					return;
				}

				local.Nome = tbNome.Text;
				local.Descricao = tbDescricao.Text;

				if (Editando)
				{
					if (_DSoftBd.AlterarLocal(local))
					{
						Atualizar();

						Limpar();

						Editando = false;
					}
				}
				else
				{
					if (_DSoftBd.IncluirLocal(local))
					{
						Atualizar();

						Limpar();
					}
				}
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int row = dataGridView1.SelectedRows[0].Index;

				tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
				tbNome.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();
				tbDescricao.Text = dataGridView1.Rows[row].Cells["descricao"].Value.ToString();

				tbNome.Enabled = true;
				tbDescricao.Enabled = true;

				tbNome.Focus();

				btIncluir.Text = "Confirmar - F2";

				Editando = true;
			}
		}

		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 0)
				return;

			if (dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["situacao"].Value.ToString() == "C")
			{
				btCancelar.Text = "&Reativar - F4";
			}
			else
			{
				btCancelar.Text = "&Cancelar - F4";
			}
		}

		private void DesabilitarCampos()
		{
			tbCodigo.Enabled = false;
			tbNome.Enabled = false;
			tbDescricao.Enabled = false;
		}

		private void frmCadLocais_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void HabilitarCampos()
		{
			tbCodigo.Enabled = true;
			tbNome.Enabled = true;
			tbDescricao.Enabled = true;
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Limpar()
		{
			tbCodigo.Clear();

			tbNome.Clear();
			tbDescricao.Clear();

			btIncluir.Text = "&Incluir - F2";
			btCancelar.Text = "&Cancelar - F4";
		}

		private void limparToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				tbNome.Focus();
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbDescricao_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btIncluir.Focus();
		}

		private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				tbDescricao.Focus();
		}

		#endregion Methods
	}
}