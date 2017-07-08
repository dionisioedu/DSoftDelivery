using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoftCore.Controls
{
	public partial class TransparentPanelcs : Panel
	{
		public TransparentPanelcs()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;

				cp.ExStyle |= 0x00000020;

				return cp;
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
		}
	}
}
