using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery
{
	public partial class frmAtendimento : Form
	{
		#region Constructors

		public frmAtendimento()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void frmAtendimento_Load(object sender, EventArgs e)
		{
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
	}
}