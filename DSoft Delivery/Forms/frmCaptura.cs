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
	public partial class frmCaptura : Form
	{
		#region Fields

		public long Captura;

		#endregion Fields

		#region Constructors

		public frmCaptura()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			if (!long.TryParse(textBox1.Text, out Captura))
			{
				MessageBox.Show("Número inválido!", Preferencias.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				textBox1.Focus();
				return;
			}

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				button1.Focus();
		}

		#endregion Methods
	}
}