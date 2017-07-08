using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

using DSoftParameters;

namespace DSoft_Server
{
	public partial class frmTerminal : Form
	{
		#region Constructors

		public frmTerminal()
		{
			InitializeComponent();
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

		private void Carregar()
		{
			string impressora;

			for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
			{
				impressora = PrinterSettings.InstalledPrinters[i];

				cbImpressora.Items.Add(impressora);
				cbImpressoraExterna1.Items.Add(impressora);
				cbImpressoraExterna2.Items.Add(impressora);
			}

			cbPermiteCancelamento.Checked = Terminal.PermiteCancelamento;

			cbImpressora.Text = Terminal.Impressora();
			cbImpressoraExterna1.Text = Terminal.ImpressoraExterna1;
			cbImpressoraExterna2.Text = Terminal.ImpressoraExterna2;
			cb2vias.Checked = Terminal.Imprime2Via();
			cbRelatoriosMatricial.Checked = Terminal.RelatoriosMatricial;
			nmColunas.Value = Terminal.ImpressoraColunas;
		}

		private void Confirmar()
		{
			try
			{
				Terminal.PermiteCancelamento = cbPermiteCancelamento.Checked;

				Terminal.Impressora(cbImpressora.Text);
				Terminal.ImpressoraExterna1 = cbImpressoraExterna1.Text;
				Terminal.ImpressoraExterna2 = cbImpressoraExterna2.Text;
				Terminal.Imprime2Via(cb2vias.Checked);
				Terminal.RelatoriosMatricial = cbRelatoriosMatricial.Checked;
				Terminal.ImpressoraColunas = (int)nmColunas.Value;

				Sair();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmTerminal_Load(object sender, EventArgs e)
		{
			Carregar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbTeste_Click(object sender, EventArgs e)
		{
			DSPrintingHelper.PrinterHelper.Print(cbImpressora.Text, "123456789012345678901234567890123456789012345678901234567890\n123\n123\n123\t123\t123\n\n\n123\n\n\n");
		}

		#endregion Methods
	}
}