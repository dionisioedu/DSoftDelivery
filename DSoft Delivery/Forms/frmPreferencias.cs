using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftParameters;
using DSoftConfig;
using DSoftCore;

namespace DSoft_Delivery
{
	public partial class frmPreferencias : Form
	{
		#region Constructors

		public frmPreferencias()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void button10_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeBackup.Text = folderDialog.SelectedPath;
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeTemporarios.Text = folderDialog.SelectedPath;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Schema Files (*.xsd)|*.xsd";
			fileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbSchemaNFe.Text = fileDialog.FileName;
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeErro.Text = folderDialog.SelectedPath;
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeRetorno.Text = folderDialog.SelectedPath;
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTe.Text = folderDialog.SelectedPath;
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Schema Files (*.xsd)|*.xsd";
			fileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbSchemaCTe.Text = fileDialog.FileName;
			}
		}

		private void button17_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeNegadas.Text = folderDialog.SelectedPath;
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeEnviadas.Text = folderDialog.SelectedPath;
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeAssinadas.Text = folderDialog.SelectedPath;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
			fileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbImagemFundo.Text = fileDialog.FileName;
			}
		}

		private void button20_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Schema Files (*.xsd)|*.xsd";
			fileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbSchemaStatus.Text = fileDialog.FileName;
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbPastaCTeArquivo.Text = folderDialog.SelectedPath;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
			fileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbImagemLogin.Text = fileDialog.FileName;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbRelatorios.Text = folderDialog.SelectedPath;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFe.Text = folderDialog.SelectedPath;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeEnviadas.Text = folderDialog.SelectedPath;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeRetorno.Text = folderDialog.SelectedPath;
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeGravados.Text = folderDialog.SelectedPath;
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeBaixados.Text = folderDialog.SelectedPath;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				tbNFeValidados.Text = folderDialog.SelectedPath;
			}
		}

		private void Carregar()
		{
			tbTitulo.Text = DSConfig.Instance.Title;

			tbImagemLogin.Text = DSConfig.Instance.LoginImage;
			tbImagemFundo.Text = DSConfig.Instance.BackgroundImage;

			numLicenca.Value = Util.TryParseDecimal(DSConfig.Instance.LicenceWarning);

			tbMensagemCupom.Text = DSConfig.Instance.TicketMsg;

			tbRelatorios.Text = Preferencias.RelatoriosPath;

			tbPastaCTe.Text = Preferencias.PastaCTe;
			tbPastaCTeRetorno.Text = Preferencias.PastaCteRetorno;
			tbPastaCTeErro.Text = Preferencias.PastaCteErro;
			tbPastaCTeEnviadas.Text = Preferencias.PastaCteEnviadas;
			tbPastaCTeAssinadas.Text = Preferencias.PastaCteAssinadas;
			tbPastaCTeNegadas.Text = Preferencias.PastaCteNegadas;
			tbPastaCTeArquivo.Text = Preferencias.PastaCteArquivo;
			tbSchemaCTe.Text = Preferencias.SchemaCTe;
			tbSchemaStatus.Text = Preferencias.SchemaStatusServico;

			tbNFe.Text = Preferencias.PastaNFe;
			tbNFeEnviadas.Text = Preferencias.PastaNFeEnviadas;
			tbNFeRetorno.Text = Preferencias.PastaNFeRetorno;
			tbNFeGravados.Text = Preferencias.PastaNFeGravados;
			tbNFeTemporarios.Text = Preferencias.PastaNFeTemporarios;
			tbNFeBackup.Text = Preferencias.PastaNFeBackup;
			tbNFeValidados.Text = Preferencias.PastaNFeValidados;
			tbNFeBaixados.Text = Preferencias.PastaNFeBaixados;
			tbSchemaNFe.Text = Preferencias.SchemaNFe;

			tbComp1.Text = Preferencias.Componente1;
			tbComp2.Text = Preferencias.Componente2;
			tbComp3.Text = Preferencias.Componente3;
			tbComp4.Text = Preferencias.Componente4;

			nmPedidosAtualiza.Value = Util.TryParseDecimal(DSConfig.Instance.OrdersRefresh);
		}

		private void Confirmar()
		{
			DSConfig.Instance.Title = tbTitulo.Text;
			DSConfig.Instance.LoginImage = tbImagemLogin.Text;
			DSConfig.Instance.BackgroundImage = tbImagemFundo.Text;
			DSConfig.Instance.LicenceWarning = numLicenca.Value.ToString();

			DSConfig.Instance.TicketMsg = tbMensagemCupom.Text;

			Preferencias.RelatoriosPath = tbRelatorios.Text;
			Preferencias.PastaCTe = tbPastaCTe.Text;
			Preferencias.PastaCteRetorno = tbPastaCTeRetorno.Text;
			Preferencias.PastaCteErro = tbPastaCTeErro.Text;
			Preferencias.PastaCteEnviadas = tbPastaCTeEnviadas.Text;
			Preferencias.PastaCteAssinadas = tbPastaCTeAssinadas.Text;
			Preferencias.PastaCteNegadas = tbPastaCTeNegadas.Text;
			Preferencias.PastaCteArquivo = tbPastaCTeArquivo.Text;
			Preferencias.SchemaCTe = tbSchemaCTe.Text;
			Preferencias.SchemaStatusServico = tbSchemaStatus.Text;

			Preferencias.PastaNFe = tbNFe.Text;
			Preferencias.PastaNFeEnviadas = tbNFeEnviadas.Text;
			Preferencias.PastaNFeRetorno = tbNFeRetorno.Text;
			Preferencias.PastaNFeGravados = tbNFeGravados.Text;
			Preferencias.PastaNFeTemporarios = tbNFeTemporarios.Text;
			Preferencias.PastaNFeBackup = tbNFeBackup.Text;
			Preferencias.PastaNFeValidados = tbNFeValidados.Text;
			Preferencias.PastaNFeBaixados = tbNFeBaixados.Text;
			Preferencias.SchemaNFe = tbSchemaNFe.Text;

			Preferencias.Componente1 = tbComp1.Text;
			Preferencias.Componente2 = tbComp2.Text;
			Preferencias.Componente3 = tbComp3.Text;
			Preferencias.Componente4 = tbComp4.Text;

			DSConfig.Instance.OrdersRefresh = nmPedidosAtualiza.Value.ToString();

			Sair();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmPreferencias_Load(object sender, EventArgs e)
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

		private void tbImagemFundo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void tbImagemFundo_TextChanged(object sender, EventArgs e)
		{
		}

		private void tbImagemLogin_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbImagemFundo.Focus();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbImagemLogin.Focus();
			}
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
		}

		private void btLimparPedidos_Click(object sender, EventArgs e)
		{
			//Preferencias.PedidosColunas = new System.Collections.Specialized.StringCollection();
			DSConfig.Instance.ClearOrdersColumnsPreferences();
		}

		#endregion Methods
	}
}