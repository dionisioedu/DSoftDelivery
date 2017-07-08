using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using DSoftCore;
using DSoftParameters;
using DSPrintingHelper;

namespace DSoftForms
{
	public partial class TerminalForm : Form
	{
		#region Constructors

		public TerminalForm()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void btBackup_Click(object sender, EventArgs e)
		{
		}

		private void btResetar_Click(object sender, EventArgs e)
		{
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_ResetaImpressora());
		}

		private void btTesteECF_Click(object sender, EventArgs e)
		{
			System.IO.Ports.SerialPort porta = new System.IO.Ports.SerialPort(cbECFPorta.Text);

			porta.Open();

			byte[] msg = new byte[12];

			msg[0] = 2;
			msg[1] = 42;
			msg[2] = 49;
			msg[3] = 53;
			msg[4] = 3;
			msg[5] = 149;

			//porta.Write(msg, 0, 6);
			porta.Write("/x2/x42/x49/x53/x3/x149");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();

			folderDialog.SelectedPath = tbPostreSql.Text;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPostreSql.Text = folderDialog.SelectedPath;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();

			folderDialog.SelectedPath = tbBackup.Text;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbBackup.Text = folderDialog.SelectedPath;
			}
		}

		private void Carregar()
		{
			string impressora;

			cbImpressora.Items.Add("");
			cbImpressoraExterna1.Items.Add("");
			cbImpressoraExterna2.Items.Add("");
			cbImpressoraDelivery.Items.Add("");

			for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
			{
				impressora = PrinterSettings.InstalledPrinters[i];

				cbImpressora.Items.Add(impressora);
				cbImpressoraExterna1.Items.Add(impressora);
				cbImpressoraExterna2.Items.Add(impressora);
				cbImpressoraDelivery.Items.Add(impressora);
			}

			CarregarPortasSeriais();

			tbNumeroCaixa.Text = Terminal.NumeroCaixa().ToString();
			tbSaldoInicial.Text = Terminal.SaldoInicial().ToString("##,###,##0.00");
			cbImpressora.Text = Terminal.Impressora();
			cbImpressoraExterna1.Text = Terminal.ImpressoraExterna1;
			cbImpressoraExterna2.Text = Terminal.ImpressoraExterna2;
			cbImpressoraDelivery.Text = Terminal.ImpressoraDelivery;
			cb2vias.Checked = Terminal.Imprime2Via();
			tbPromocao1.Text = Terminal.Promocao1();
			tbPromocao2.Text = Terminal.Promocao2();
			cbECF.Text = Terminal.ECF();
			cbECFPorta.Text = Terminal.ECFPorta();
			tbPostreSql.Text = Terminal.PostgreSql();
			tbBackup.Text = Terminal.Backup();
			tbBrowser.Text = Terminal.Browser;
			cbRelatoriosMatricial.Checked = Terminal.RelatoriosMatricial;
			nmColunas.Value = Terminal.ImpressoraColunas;
			cbImpressoraCorte.Checked = Terminal.ImpressoraCorte;

			cbVerificaArquivos.Checked = Terminal.VerificaArquivos;

			cbMapasOnline.Checked = Terminal.MapasOnline;

			tbDownloadMF.Text = Terminal.DownloadMF;

			cbVersaoPostgresql.Text = Terminal.VersaoPostgreSql;
			cbProcessadorPostgreSql.Text = Terminal.ProcessadorPostgreSql;
		}

		private void CarregarPortasSeriais()
		{
			string[] portas = System.IO.Ports.SerialPort.GetPortNames();

			cbECFPorta.Items.Clear();

			foreach (string p in portas)
			{
				cbECFPorta.Items.Add(p);
			}
		}

		private void Confirmar()
		{
			try
			{
				int caixa;

				if (!int.TryParse(tbNumeroCaixa.Text, out caixa))
				{
					MessageBox.Show("Campo inválido!", this.Text);

					tbNumeroCaixa.SelectAll();

					tbNumeroCaixa.Focus();

					return;
				}

				Terminal.NumeroCaixa(caixa);
				Terminal.SaldoInicial(Convert.ToDouble(tbSaldoInicial.Text));
				Terminal.Impressora(cbImpressora.Text);
				Terminal.ImpressoraExterna1 = cbImpressoraExterna1.Text;
				Terminal.ImpressoraExterna2 = cbImpressoraExterna2.Text;
				Terminal.ImpressoraDelivery = cbImpressoraDelivery.Text;
				Terminal.Imprime2Via(cb2vias.Checked);
				Terminal.Promocao1(tbPromocao1.Text);
				Terminal.Promocao2(tbPromocao2.Text);
				Terminal.ECF(cbECF.Text);
				Terminal.ECFPorta(cbECFPorta.Text);
				Terminal.PostgreSql(tbPostreSql.Text);
				Terminal.Backup(tbBackup.Text);
				Terminal.Browser = tbBrowser.Text;
				Terminal.RelatoriosMatricial = cbRelatoriosMatricial.Checked;
				Terminal.ImpressoraColunas = (int)nmColunas.Value;
				Terminal.ImpressoraCorte = cbImpressoraCorte.Checked;

				Terminal.VerificaArquivos = cbVerificaArquivos.Checked;

				Terminal.MapasOnline = cbMapasOnline.Checked;

				Terminal.DownloadMF = tbDownloadMF.Text;

				Terminal.VersaoPostgreSql = cbVersaoPostgresql.Text;
				Terminal.ProcessadorPostgreSql = cbProcessadorPostgreSql.Text;

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
			PrinterHelper.Print(cbImpressora.Text, "123456789012345678901234567890123456789012345678901234567890\n123\n123\n123\t123\t123\n\n\n123\n\n\n");
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbNumeroCaixa.Text != string.Empty)
			{
				button1.Focus();
			}
		}

		#endregion Methods
	}
}