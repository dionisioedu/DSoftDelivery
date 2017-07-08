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
	public partial class frmMsgDemonstracao : Form
	{
		public frmMsgDemonstracao()
		{
			InitializeComponent();
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("www.dsoftsistemas.com.br/produtos/registre-se");
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("www.dsoftsistemas.com.br");
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
