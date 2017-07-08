using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftModels;
using DSoftBd;

namespace FrenteDeCaixa
{
	public partial class frmLogin : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmLogin(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_usuario = usuario;
			_dsoftBd = bd;
		}

		private void label4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tbUsuario_KeyPress(object sender, KeyPressEventArgs e)
		{
			int usuario;

			if (e.KeyChar == (char)Keys.Enter && tbUsuario.Text.Length > 0 && int.TryParse(tbUsuario.Text, out usuario))
			{
				mbPassword.Focus();
			}
		}

		private void mbPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				try
				{
					int codigo;
					char nivel;
					string nova = "";

					if (tbUsuario.Text == string.Empty || !int.TryParse(tbUsuario.Text, out codigo))
					{
						tbUsuario.SelectAll();
						tbUsuario.Focus();
						return;
					}

					if (mbPassword.Text.Length == 0)
					{
						mbPassword.Focus();
						return;
					}

					if ((nivel = _dsoftBd.UsuarioCadastrado(codigo, mbPassword.Text, nova)) == '0')
					{
						MessageBox.Show("Acesso negado!", this.Text);

						tbUsuario.SelectAll();
						tbUsuario.Focus();

						return;
					}

					_usuario.Autorizado = codigo;

					_dsoftBd.LogarEntrada(codigo);

					DialogResult = DialogResult.OK;

					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, this.Text);
				}
			}
		}
	}
}
