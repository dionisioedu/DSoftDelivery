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
	public partial class frmCapturaPonto : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCapturaPonto(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			int funcionario;

			if (!int.TryParse(tbFuncionario.Text, out funcionario))
			{
				return;
			}

			if (_DSoftBd.NovoPonto(funcionario, dtData.Value, dtHora.Value, false, _usuario.Autorizado))
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;

				Close();
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbFuncionario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (tbFuncionario.Text.Length == 0)
					btSair.Focus();
				else
					btConfirmar.Focus();
			}
		}

		private void tbFuncionario_Leave(object sender, EventArgs e)
		{
			int funcionario;

			if (tbFuncionario.Text.Length == 0)
				return;

			if (!int.TryParse(tbFuncionario.Text, out funcionario))
			{
				lbFuncionario.Text = "Código inválido!";

				return;
			}

			if ((lbFuncionario.Text = _DSoftBd.RecursoNome(funcionario)) == string.Empty)
			{
				lbFuncionario.Text = "Código não encontrado!";

				return;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			dtData.Value = DateTime.Now;
			dtHora.Value = DateTime.Now;
		}

		#endregion Methods
	}
}