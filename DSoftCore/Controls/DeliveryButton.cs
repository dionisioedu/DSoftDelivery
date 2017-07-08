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
	public partial class DeliveryButton : UserControl
	{
		new public event EventHandler Click;

		public DeliveryButton()
		{
			InitializeComponent();

			pictureBox1.Click += button1_Click;
			label1.Click += button1_Click;
			label2.Click += button1_Click;

			button1.MouseDown += new MouseEventHandler(button1_MouseDown);
			button1.MouseUp += new MouseEventHandler(button1_MouseUp);
			button1.MouseEnter += new EventHandler(button1_MouseEnter);
			button1.MouseHover += new EventHandler(button1_MouseHover);

			pictureBox1.MouseEnter += button1_MouseEnter;
			pictureBox1.MouseDown += button1_MouseDown;
			pictureBox1.MouseUp += button1_MouseUp;
			pictureBox1.MouseHover += button1_MouseHover;

			label1.MouseEnter += button1_MouseEnter;
			label1.MouseHover += button1_MouseHover;
			label1.MouseDown += button1_MouseDown;
			label1.MouseUp += button1_MouseUp;

			label2.MouseEnter += button1_MouseEnter;
			label2.MouseHover += button1_MouseHover;
			label2.MouseDown += button1_MouseDown;
			label2.MouseUp += button1_MouseUp;
		}

		void button1_MouseHover(object sender, EventArgs e)
		{
			base.OnMouseHover(e);
		}

		void button1_MouseEnter(object sender, EventArgs e)
		{
			base.OnMouseEnter(e);
		}

		void button1_MouseUp(object sender, MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}

		void button1_MouseDown(object sender, MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Click != null)
				Click.Invoke(sender, e);
		}
	}
}
