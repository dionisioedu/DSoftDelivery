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

namespace DSoft_Delivery.Forms
{
	public partial class frmCadMedidas : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadMedidas(Bd bd, Usuario usuario)
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

			if (_DSoftBd.CarregarMedidas(ds))
			{
				dataGridView1.DataSource = ds.Tables[0];
			}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarRegistro(int registro)
		{
			Limpar();

			tbCodigo.Text = dataGridView1.Rows[registro].Cells["codigo"].Value.ToString();
			tbDescricao.Text = dataGridView1.Rows[registro].Cells["descricao"].Value.ToString();
			tbAbreviatura.Text = dataGridView1.Rows[registro].Cells["abreviatura"].Value.ToString();

			tbCodigo.ReadOnly = true;
		}

		private void Confirmar()
		{
			Medida medida = new Medida();
			int codigo;

			if (tbCodigo.Text.Length < 1 || !int.TryParse(tbCodigo.Text, out codigo))
			{
				lbErroCodigo.Visible = true;
				tbCodigo.Focus();
				return;
			}

			medida.Codigo = codigo;

			if (tbDescricao.Text.Length < 1)
			{
				lbErroDescricao.Visible = true;
				tbDescricao.Focus();
				return;
			}

			medida.Descricao = tbDescricao.Text;

			if (tbAbreviatura.Text.Length < 1)
			{
				lbErroAbreviatura.Visible = true;
				tbAbreviatura.Focus();
				return;
			}

			medida.Abreviatura = tbAbreviatura.Text;

			if (!tbCodigo.ReadOnly)
			{
				if (_DSoftBd.IncluirMedida(medida))
				{
					Atualizar();
					Limpar();
				}
			}
			else
			{
				if (_DSoftBd.AlterarMedida(medida))
				{
					Atualizar();
					Limpar();
				}
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				CarregarRegistro(dataGridView1.SelectedRows[0].Index);
			}
		}

		private void frmCadMedidas_Load(object sender, EventArgs e)
		{
			Inicializar();
		}

		private void Inicializar()
		{
			Atualizar();
		}

		private void Limpar()
		{
			tbCodigo.Clear();
			tbCodigo.ReadOnly = false;
			tbDescricao.Clear();
			tbAbreviatura.Clear();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbAbreviatura_TextChanged(object sender, EventArgs e)
		{
			if (lbErroAbreviatura.Visible)
			{
				lbErroAbreviatura.Visible = false;
			}
		}

		private void tbCodigo_TextChanged(object sender, EventArgs e)
		{
			if (lbErroCodigo.Visible)
			{
				lbErroCodigo.Visible = false;
			}
		}

		private void tbDescricao_TextChanged(object sender, EventArgs e)
		{
			if (lbErroDescricao.Visible)
			{
				lbErroDescricao.Visible = false;
			}
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbCodigo.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
			{
				tbDescricao.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbAbreviatura.Focus();
			}
		}

		private void tbAbreviatura_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		#endregion Methods
	}
}