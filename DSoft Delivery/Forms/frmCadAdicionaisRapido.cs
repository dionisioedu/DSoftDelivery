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
	public partial class frmCadAdicionaisRapido : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public ItemAdicional ItemAdicional;

		public frmCadAdicionaisRapido(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbDescricao.Text.Length > 0)
			{
				tbValor.Focus();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
		}

		private void tbValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbValor.Text.Length > 0)
			{
				decimal valor;

				if (decimal.TryParse(tbValor.Text, out valor))
				{
					btConfirma.Focus();
				}
			}
		}

		private void btConfirma_Click(object sender, EventArgs e)
		{
			if (tbDescricao.Text.Length > 0 && tbValor.Text.Length > 0)
			{
				decimal valor;

				if (decimal.TryParse(tbValor.Text, out valor))
				{
					ItemAdicional = new ItemAdicional();
					ItemAdicional.Descricao = tbDescricao.Text;
					ItemAdicional.Valor = valor;
				}
			}
			else
			{
				ItemAdicional = null;
			}

			this.Close();
		}

		private void frmCadAdicionaisRapido_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
		}
	}
}
