using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSoft_Server
{
	public partial class frmMain : Form, IFormConfig
	{
		#region Fields

		private bool _canClose = false;

		#endregion Fields

		#region Constructors

		public frmMain()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		public void Log(string log)
		{
			this.Invoke(new Action(() =>
			{
				tbLog.AppendText(log + Environment.NewLine);

				if (tbLog.Text.Length > 3000)
				{
					tbLog.Text.Remove(0, 2000);
				}
			}));
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			tbLog.Clear();
		}

		private void btQuit_Click(object sender, EventArgs e)
		{
			Quit();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_canClose)
			{
				this.Visible = false;

				e.Cancel = true;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			notifyIcon1.ShowBalloonTip(3000);
			string ip = string.Empty;
			int porta = 0;

			try
			{
				string file = File.ReadAllText("dsoft_server.ini");

				ip = file.Split(":".ToCharArray())[0];
				porta = Convert.ToInt32(file.Split(":".ToCharArray())[1]);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);

				Quit();
				return;
			}

			Task.Factory.StartNew(() =>
			{
				ServerBase.StartListening(ip, porta, this);
			});
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Visible = true;

			this.WindowState = FormWindowState.Normal;
		}

		private void Quit()
		{
			_canClose = true;

			Application.Exit();
		}

		private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmTerminal form = new frmTerminal();
			form.Show();
		}

		private void btSalvarArquivo_Click(object sender, EventArgs e)
		{
			string file_name = string.Format("log_{0}.txt", DateTime.Now.ToString("yyMMdd_HHmmss"));
			File.WriteAllText(file_name, tbLog.Text);
		}

		#endregion Methods
	}
}