using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSoft_Delivery.Properties;

namespace DSoft_Delivery.Forms
{
	public partial class frmHistorico : Form
	{
		#region Constructors

		public frmHistorico()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void frmHistorico_Load(object sender, EventArgs e)
		{
			tbHistorico.Text = Resources.Historico;
			tbHistorico.SelectionStart = 0;
			tbHistorico.SelectionLength = 0;
		}

		#endregion Methods
	}
}