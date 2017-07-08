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
	public partial class frmFiltroDataLancamento : Form
	{
		#region Fields

		public DateTime Final;
		public List<string> Formas;
		public DateTime Inicial;
		public List<string> Lancamentos;

		#endregion Fields

		#region Constructors

		public frmFiltroDataLancamento()
		{
			InitializeComponent();
		}

		public frmFiltroDataLancamento(string titulo, Form owner)
		{
			InitializeComponent();

			this.Owner = owner;

			this.Text = titulo;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			Lancamentos = new List<string>();
			Formas = new List<string>();

			Inicial = dateTimePicker1.Value;
			Final = dateTimePicker2.Value;

			if (checkBox1.Checked)
				Lancamentos.Add("E");

			if (checkBox2.Checked)
				Lancamentos.Add("P");

			if (checkBox3.Checked)
				Lancamentos.Add("S");

			if (checkBox4.Checked)
				Lancamentos.Add("T");

			if (checkBox5.Checked)
				Lancamentos.Add("V");

			if (checkBox6.Checked)
				Formas.Add("A");

			if (checkBox7.Checked)
				Formas.Add("B");

			if (checkBox8.Checked)
				Formas.Add("C");

			if (checkBox9.Checked)
				Formas.Add("D");

			if (checkBox10.Checked)
				Formas.Add("M");

			if (checkBox11.Checked)
				Formas.Add("P");

			if (checkBox12.Checked)
				Formas.Add("V");

			if (checkBox13.Checked)
				Formas.Add("X");

			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Sair()
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods
	}
}