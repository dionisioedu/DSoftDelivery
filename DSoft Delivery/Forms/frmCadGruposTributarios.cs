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
	public partial class frmCadGruposTributarios : Form
	{
		#region Fields

		static bool Editando = false;

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadGruposTributarios(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btConfimar_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			GrupoTributario grupo;

			if (dataGridView1.SelectedRows.Count < 1)
			{
				return;
			}

			grupo = new GrupoTributario();

			if (!int.TryParse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString(), out grupo.Codigo))
			{
				MessageBox.Show("Erro ao ler registro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}

			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (MessageBox.Show("Confirmar cancelamento do registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					== DialogResult.No)
				{
					return;
				}

				if (!_DSoftBd.CancelarGrupoTributario(grupo))
				{
					MessageBox.Show("Não foi possível cancelar o registro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Carregar();
				}
			}
			else
			{
				if (MessageBox.Show("Confirmar reativamento do registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					== DialogResult.No)
				{
					return;
				}

				if (!_DSoftBd.ReativarGrupoTributario(grupo))
				{
					MessageBox.Show("Não foi possível reativar o registro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					Carregar();
				}
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void Carregar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.CarregarGruposTributarios(ds);

			dataGridView1.DataSource = ds.Tables[0];

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "A":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
					break;

				case "C":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					break;
				}
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count < 1)
			{
				return;
			}

			tbCodigo.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString();
			tbNome.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["nome"].Value.ToString();
			tbIcms.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["icms"].Value.ToString();
			tbIpi.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ipi"].Value.ToString();
			tbPis.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["pis"].Value.ToString();
			tbCofins.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["cofins"].Value.ToString();
			tbCsll.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["csll"].Value.ToString();
			tbIrrf.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["irrf"].Value.ToString();

			tbCodigo.Focus();

			HabilitarCampos();

			btConfimar.Text = "Confirmar - F2";

			Editando = true;
		}

		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count < 1)
			{
				return;
			}

			if (dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["situacao"].Value.ToString() == "A")
			{
				btCancelar.Text = "&Cancelar - F4";
			}
			else
			{
				btCancelar.Text = "&Reativar - F4";
			}
		}

		private void DesabilitarCampos()
		{
			tbCodigo.Enabled = false;
			tbNome.Enabled = false;
			tbIcms.Enabled = false;
			tbIpi.Enabled = false;
			tbPis.Enabled = false;
			tbCofins.Enabled = false;
			tbCsll.Enabled = false;
			tbIrrf.Enabled = false;
		}

		private void frmCadGruposTributarios_Load(object sender, EventArgs e)
		{
			Carregar();
		}

		private void HabilitarCampos()
		{
			tbCodigo.Enabled = true;
			tbNome.Enabled = true;
			tbIcms.Enabled = true;
			tbIpi.Enabled = true;
			tbPis.Enabled = true;
			tbCofins.Enabled = true;
			tbCsll.Enabled = true;
			tbIrrf.Enabled = true;
		}

		private void Incluir()
		{
			GrupoTributario grupo;

			if (btConfimar.Text == "&Incluir - F2")
			{
				HabilitarCampos();

				tbCodigo.Focus();

				btConfimar.Text = "Confirmar - F2";
			}
			else
			{
				grupo = new GrupoTributario();

				if (tbCodigo.Text.Length < 1)
				{
					MessageBox.Show("Campo 'código' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCodigo.Focus();

					return;
				}

				if (!int.TryParse(tbCodigo.Text, out grupo.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}
				else if (grupo.Codigo < 0)
				{
					MessageBox.Show("Campo 'código' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}
				else if (grupo.Codigo == 0)
				{
					MessageBox.Show("Campo 'código' deve ser diferente de zero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}

				if (tbNome.Text.Length < 1)
				{
					MessageBox.Show("Campo 'nome' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbNome.Focus();

					return;
				}

				grupo.Nome = tbNome.Text;

				if (tbIcms.Text.Length < 1)
				{
					grupo.ICMS = 0;
				}
				else if (!float.TryParse(tbIcms.Text, out grupo.ICMS))
				{
					MessageBox.Show("Campo 'icms' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIcms.SelectAll();
					tbIcms.Focus();

					return;
				}
				else if (grupo.ICMS < 0)
				{
					MessageBox.Show("Campo 'icms' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIcms.SelectAll();
					tbIcms.Focus();

					return;
				}

				if (tbIpi.Text.Length < 1)
				{
					grupo.IPI = 0;
				}
				else if (!float.TryParse(tbIpi.Text, out grupo.IPI))
				{
					MessageBox.Show("Campo 'ipi' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIpi.SelectAll();
					tbIpi.Focus();

					return;
				}
				else if (grupo.IPI < 0)
				{
					MessageBox.Show("Campo 'ipi' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIpi.SelectAll();
					tbIpi.Focus();

					return;
				}

				if (tbPis.Text.Length < 1)
				{
					grupo.PIS = 0;
				}
				else if (!float.TryParse(tbPis.Text, out grupo.PIS))
				{
					MessageBox.Show("Campo 'pis' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbPis.SelectAll();
					tbPis.Focus();

					return;
				}
				else if (grupo.PIS < 0)
				{
					MessageBox.Show("Campo 'pis' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbPis.SelectAll();
					tbPis.Focus();

					return;
				}

				if (tbCofins.Text.Length < 1)
				{
					grupo.COFINS = 0;
				}
				else if (!float.TryParse(tbCofins.Text, out grupo.COFINS))
				{
					MessageBox.Show("Campo 'cofins' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCofins.SelectAll();
					tbCofins.Focus();

					return;
				}
				else if (grupo.COFINS < 0)
				{
					MessageBox.Show("Campo 'cofins' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCofins.SelectAll();
					tbCofins.Focus();

					return;
				}

				if (tbCsll.Text.Length < 1)
				{
					grupo.CSLL = 0;
				}
				else if (!float.TryParse(tbCsll.Text, out grupo.CSLL))
				{
					MessageBox.Show("Campo 'csll' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCsll.SelectAll();
					tbCsll.Focus();

					return;
				}
				else if (grupo.CSLL < 0)
				{
					MessageBox.Show("Campo 'csll' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbCsll.SelectAll();
					tbCsll.Focus();

					return;
				}

				if (tbIrrf.Text.Length < 1)
				{
					grupo.IRRF = 0;
				}
				else if (!float.TryParse(tbIrrf.Text, out grupo.IRRF))
				{
					MessageBox.Show("Campo 'irrf' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIrrf.SelectAll();
					tbIrrf.Focus();

					return;
				}
				else if (grupo.IRRF < 0)
				{
					MessageBox.Show("Campo 'irrf' não pode ser negativo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					tbIrrf.SelectAll();
					tbIrrf.Focus();

					return;
				}

				if (Editando)
				{
					if (_DSoftBd.AlterarGrupoTributario(grupo))
					{
						LimparCampos();

						DesabilitarCampos();

						Carregar();

						btConfimar.Text = "&Incluir - F2";

						Editando = false;
					}
					else
					{
						MessageBox.Show("Não foi possível salvar os dados no sistema.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						return;
					}
				}
				else
				{
					if (_DSoftBd.NovoGrupoTributario(grupo))
					{
						LimparCampos();

						DesabilitarCampos();

						Carregar();

						btConfimar.Text = "&Incluir - F2";
					}
					else
					{
						MessageBox.Show("Não foi possível adicionar os dados ao sistema.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						return;
					}
				}
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			tbIcms.Clear();
			tbIpi.Clear();
			tbPis.Clear();
			tbCofins.Clear();
			tbCsll.Clear();
			tbIrrf.Clear();
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
			int codigo;

			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbCodigo.Text.Length < 1)
				{
					MessageBox.Show("Campo 'código' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}

				if (!int.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}

				tbNome.Focus();
			}
		}

		private void tbCofins_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbCsll.Focus();
			}
		}

		private void tbCsll_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbIrrf.Focus();
			}
		}

		private void tbIcms_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbPis.Focus();
			}
		}

		private void tbIpi_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbIcms.Focus();
			}
		}

		private void tbIrrf_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfimar.Focus();
			}
		}

		private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbNome.Text.Length < 1)
				{
					MessageBox.Show("Campo 'nome' não pode ser vazio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}

				tbIpi.Focus();
			}
		}

		private void tbPis_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbCofins.Focus();
			}
		}

		#endregion Methods
	}
}