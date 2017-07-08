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
	public partial class frmAlert : Form
	{
		public frmAlert(string message)
		{
			InitializeComponent();

			label1.Text = message;
		}

		private void frmAlert_Load(object sender, EventArgs e)
		{
			tmClose.Interval = RegrasDeNegocio.Instance.SegundosAlerta > 0 ? RegrasDeNegocio.Instance.SegundosAlerta * 1000 : 1000;
			tmClose.Tick += new EventHandler((o, ev) =>
			{
				this.Close();
			});

			tmClose.Enabled = true;
		}
	}
}
