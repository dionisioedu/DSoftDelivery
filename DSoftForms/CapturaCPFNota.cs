using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSoftForms
{
	public partial class CapturaCPFNota : Form
	{
		#region Fields

		public string Cpf = string.Empty;

		#endregion Fields

		#region Constructors

		public CapturaCPFNota()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void btEmitir_Click(object sender, EventArgs e)
		{
			Emitir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Emitir()
		{
			Cpf = mtCpf.Text;

			if (Cpf.Contains(" ") || Cpf.Contains("_"))
			{
				Cpf = "";
			}

			DialogResult = DialogResult.OK;

			Close();
		}

		private void emitirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Emitir();
		}

		private void frmCapturaCPFNota_Load(object sender, EventArgs e)
		{
			mtCpf.Focus();
		}

		private void Sair()
		{
			DialogResult = DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void rbCpf_CheckedChanged(object sender, EventArgs e)
		{
			AjustaMascara();
		}

		private void rbCNPJ_CheckedChanged(object sender, EventArgs e)
		{
			AjustaMascara();
		}

		private void AjustaMascara()
		{
			if (rbCpf.Checked)
			{
				mtCpf.Mask = "999.999.999-99";
			}
			else
			{
				mtCpf.Mask = "99.999.999/9999-99";
			}
		}

		#endregion Methods
	}
}