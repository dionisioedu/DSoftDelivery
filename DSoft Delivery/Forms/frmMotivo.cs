using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftParameters;

namespace DSoft_Delivery.Forms
{
	public partial class frmMotivo : Form
	{
		public string Motivo = string.Empty;

		public frmMotivo()
		{
			InitializeComponent();
		}

		private void frmMotivo_Load(object sender, EventArgs e)
		{

		}

		private void Confirmar()
		{
			if (RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento)
			{
				if (tbMotivo.Text.Length < 1)
				{
					lbErro.Text = "Motivo obrigatório";
					tbMotivo.Focus();
					return;
				}
			}

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void tbMotivo_KeyDown(object sender, KeyEventArgs e)
		{
			lbErro.Text = string.Empty;

			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void siarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbMotivo_TextChanged(object sender, EventArgs e)
		{
			Motivo = tbMotivo.Text;
		}
	}
}
