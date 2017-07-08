using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery
{
	public partial class frmData : Form
	{
		#region Fields

		public bool PermiteAlterarData = true;
		public DateTime Data = DateTime.Now;
		public string Titulo = "Data";

		#endregion

		#region Constructors

		public frmData()
		{
			InitializeComponent();
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
			DialogResult = DialogResult.OK;

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dtData_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btConfirmar.Focus();
		}

		private void frmData_Load(object sender, EventArgs e)
		{
			this.Text = Titulo;

			dtData.Value = Data;
			dtData.Enabled = PermiteAlterarData;

			dtData.Focus();
		}

		private void Sair()
		{
			DialogResult = DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void dtData_ValueChanged(object sender, EventArgs e)
		{
			Data = dtData.Value;
		}

		#endregion Methods
	}
}