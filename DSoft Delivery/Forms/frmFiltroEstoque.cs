using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery.Forms
{
	public partial class frmFiltroEstoque : Form
	{
		public frmFiltroEstoque()
		{
			InitializeComponent();
		}

		private void frmFiltroEstoque_Load(object sender, EventArgs e)
		{

		}

		private void Confirmar()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		public bool SomenteEstoqueCritico()
		{
			return cbSomenteCritico.Checked;
		}

		public bool OrdenadoPorCodigo()
		{
			return rbCodigo.Checked;
		}

		public bool OrdenadoPorNome()
		{
			return rbNome.Checked;
		}

		private void frmFiltroEstoque_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Confirmar();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}
	}
}
