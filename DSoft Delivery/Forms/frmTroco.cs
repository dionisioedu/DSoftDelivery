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
	public partial class frmTroco : Form
	{
		public frmTroco()
		{
			InitializeComponent();
		}

		private void frmTroco_Load(object sender, EventArgs e)
		{
			this.Invoke(new Action(() =>
			{

				tbTroco.Text = "0,00";
				tbTroco.SelectAll();
				tbTroco.Focus();
			}));
		}

		private void tbTroco_Leave(object sender, EventArgs e)
		{
			decimal troco;
			decimal.TryParse(tbTroco.Text, out troco);
			tbTroco.Text = troco.ToString("##,###,##0.00");
		}

		public decimal Troco()
		{
			decimal troco;
			decimal.TryParse(tbTroco.Text, out troco);
			return troco;
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void tbTroco_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}
	}
}
