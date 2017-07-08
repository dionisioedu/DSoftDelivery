using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery.Forms
{
	public partial class frmBDScripts : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmBDScripts(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btExecute_Click(object sender, EventArgs e)
		{
			Execute();
		}

		private void btExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Close()
		{
			base.Close();
		}

		private void executarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Execute();
		}

		private void Execute()
		{
			DataTable dtResult;

			tbMessages.Text = _DSoftBd.ScriptExecute(tbScript.Text, _usuario.Autorizado, out dtResult);

			dgResult.DataSource = dtResult;
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion Methods
	}
}