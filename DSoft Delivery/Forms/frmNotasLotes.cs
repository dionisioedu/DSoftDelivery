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
	public partial class frmNotasLotes : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmNotasLotes(Bd bd, Usuario usuario)
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

			_DSoftBd.CarregarLotesNotas(ds);

			dataGridView1.DataSource = ds.Tables[0];

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "A":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
					break;

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

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (dataGridView1.SelectedRows.Count < 1)
			{
				return;
			}

			if (_DSoftBd.CancelarLoteNotas(int.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["indice"].Value.ToString())))
			{
				Atualizar();
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void cbSerie_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbTipo.Focus();
			}
		}

		private void cbTipo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void DesabilitarCampos()
		{
			tbInicial.Enabled = false;
			tbFinal.Enabled = false;
			cbSerie.Enabled = false;
			cbTipo.Enabled = false;
		}

		private void frmNotasLotes_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void HabilitarCampos()
		{
			tbInicial.Enabled = true;
			tbFinal.Enabled = true;
			cbSerie.Enabled = true;
			cbTipo.Enabled = true;
		}

		private void Incluir()
		{
			if (btConfirmar.Text == "&Incluir - F2")
			{
				btConfirmar.Text = "&Confirmar - F2";

				HabilitarCampos();

				tbInicial.Focus();
			}
			else
			{
				int inicial;
				int final;
				char serie;
				char tipo;

				if (tbInicial.Text.Length < 1)
				{
					MessageBox.Show("Campo 'inicial' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbInicial.Focus();

					return;
				}

				if (!int.TryParse(tbInicial.Text, out inicial) || inicial < 0)
				{
					MessageBox.Show("Campo 'inicial' deve ser numérico e positivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbInicial.SelectAll();
					tbInicial.Focus();

					return;
				}

				if (tbFinal.Text.Length < 1)
				{
					MessageBox.Show("Campo 'final' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbFinal.Focus();

					return;
				}

				if (!int.TryParse(tbFinal.Text, out final) || final < 0)
				{
					MessageBox.Show("Campo 'final' deve ser numérico e positivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbFinal.SelectAll();
					tbFinal.Focus();

					return;
				}

				if (cbSerie.Text == string.Empty)
				{
					MessageBox.Show("Campo 'serie' deve ser definido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbSerie.Focus();

					return;
				}

				serie = cbSerie.Text[0];

				tipo = cbTipo.Text[0];

				if (_DSoftBd.NovoLoteNotas(inicial, final, serie, tipo))
				{
					LimparCampos();

					DesabilitarCampos();

					btConfirmar.Text = "&Incluir - F2";
					btConfirmar.Focus();

					Atualizar();
				}
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void LimparCampos()
		{
			tbInicial.Clear();
			tbFinal.Clear();
			cbSerie.Text = string.Empty;
			cbTipo.Text = string.Empty;
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbFinal_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbSerie.Focus();
			}
		}

		private void tbInicial_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbFinal.Focus();
			}
		}

		#endregion Methods
	}
}