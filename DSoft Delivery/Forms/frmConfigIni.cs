using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DSoft_Delivery.Forms
{
	public partial class frmConfigIni : Form
	{
		public frmConfigIni()
		{
			InitializeComponent();
		}

		private void frmConfigIni_Load(object sender, EventArgs e)
		{
			CarregarConfiguracoes();
		}

		private void CarregarConfiguracoes()
		{
			FileStream file = new FileStream("dsoft.ini", FileMode.Open);

			byte [] conteudo = new byte[file.Length];

			file.Read(conteudo, 0, conteudo.Length);

			file.Close();

			string dados = System.Text.Encoding.ASCII.GetString(conteudo);

			string [] parametros = dados.Split(":".ToCharArray());

			tbIp.Text = parametros[0];
			tbPorta.Text = parametros[1];
			tbNome.Text = parametros[2];
		}

		private void confirmButton1_Click(object sender, EventArgs e)
		{
			string config;

			config = string.Format("{0}:{1}:{2}", tbIp.Text, tbPorta.Text, tbNome.Text);

			if (config.Length > 0)
			{
				File.Delete("dsoft.ini");

				StreamWriter writer = new StreamWriter("dsoft.ini");
				writer.Write(config);
				writer.Flush();
				writer.Close();
			}

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void cancelButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
	}
}
