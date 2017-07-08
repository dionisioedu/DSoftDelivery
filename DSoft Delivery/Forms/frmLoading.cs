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
	public partial class frmLoading : Form
	{
		#region Constructors

		public frmLoading()
		{
			InitializeComponent();
		}

		public frmLoading(string titulo, string legenda)
		{
			InitializeComponent();

			Text = titulo;
			label1.Text = legenda;
		}

		#endregion Constructors

		#region Methods

		private void frmLoading_Load(object sender, EventArgs e)
		{

		}

		public void Legenda(string legenda)
		{
			label1.Text = legenda;
		}

		#endregion Methods
	}
}