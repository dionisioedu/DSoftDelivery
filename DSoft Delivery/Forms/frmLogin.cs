using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftModels;
using DSoftForms;

namespace DSoft_Delivery
{
	public partial class frmLogin : Form
	{
		#region Fields

		private DSoftBd.Bd _dsoftBd;
		private Usuario _usuario;

		private bool _alteraSenha = false;

		#endregion Fields

		#region Constructors

		public frmLogin(DSoftBd.Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			lbVersao.Text = string.Format("Versão {0}", Information.VERSION);

			enterButton1.Click += new EventHandler((s, e) => { Confirmar(); });
			exitButton1.Click += new EventHandler((s, e) => { Sair(); });

			tbUsuario.TextChanged += new EventHandler(textBox1_TextChanged);
			mbSenha.TextChanged += new EventHandler(maskedTextBox1_TextChanged);
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

		private void CarregarImagem()
		{
			pbFundo.Image = Image.FromFile(DSoftParameters.Preferencias.ImagemLogin);
		}

		private void Confirmar()
		{
			try
			{
				int codigo;
				char nivel;
				string nova = "";

				if (tbUsuario.Text == string.Empty || !int.TryParse(tbUsuario.Text, out codigo))
				{
					codigo = _dsoftBd.UsuarioCodigo(tbUsuario.Text);

					if (codigo == 0)
					{
						lbUsuarioInvalido.Visible = true;
						tbUsuario.SelectAll();
						tbUsuario.Focus();
						return;
					}
				}

				if (lbUsuarioInvalido.Visible)
				{
					lbUsuarioInvalido.Visible = false;
				}

				if (mbSenha.Text.Length == 0)
				{
					lbSenhaInvalida.Visible = true;
					mbSenha.Focus();
					return;
				}

				if (lbSenhaInvalida.Visible)
				{
					lbSenhaInvalida.Visible = false;
				}

				if (_alteraSenha)
				{
					if (mbNovaSenha.Text != mbConfirmacao.Text)
					{
						lbSenhasNaoConferem.Visible = true;

						mbNovaSenha.SelectAll();
						mbNovaSenha.Focus();

						return;
					}
					else
					{
						nova = mbConfirmacao.Text;
					}
				}

				if ((nivel = _dsoftBd.UsuarioCadastrado(codigo, mbSenha.Text, nova)) == '0')
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
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			CarregarImagem();

			if (Licenca.Instance.Demo)
			{
				lbDemo.Visible = true;
			}

			if (_dsoftBd.UsuariosCadastrados() > 1)
			{
				btNovoUsuario.Visible = false;
			}
			else
			{
				btNovoUsuario.Visible = true;
			}

			tbUsuario.Focus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			mbNovaSenha.Visible = true;
			label3.Visible = true;
			mbConfirmacao.Visible = true;
			label7.Visible = true;
			llCancelar.Visible = true;

			llAlterarSenha.Visible = false;

			_alteraSenha = true;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			mbNovaSenha.Visible = false;
			label3.Visible = false;
			llCancelar.Visible = false;
			mbConfirmacao.Visible = false;
			label7.Visible = false;

			llAlterarSenha.Visible = true;

			_alteraSenha = false;
		}

		private void maskedTextBox1_Enter(object sender, EventArgs e)
		{
			mbSenha.SelectAll();
		}

		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (_alteraSenha)
				{
					mbNovaSenha.Focus();
				}
				else
				{
					enterButton1.Focus();
				}
			}
		}

		void maskedTextBox1_TextChanged(object sender, EventArgs e)
		{
			if (lbSenhaInvalida.Visible)
			{
				lbSenhaInvalida.Visible = false;
			}
		}

		private void Sair()
		{
			DialogResult = DialogResult.Cancel;

			Application.Exit();

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
			tbUsuario.SelectAll();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				mbSenha.Focus();
			}
			//else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			//{
			//    e.Handled = true;
			//}
		}

		void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (lbUsuarioInvalido.Visible)
			{
				lbUsuarioInvalido.Visible = false;
			}
		}

		private void mbNovaSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbConfirmacao.Focus();
			}
		}

		private void mbConfirmacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				enterButton1.Focus();
			}
		}

		private void llTerminal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			TerminalForm form = new TerminalForm();
			form.Show();
		}

		private void btNovoUsuario_Click(object sender, EventArgs e)
		{
			DSoftForms.NovoUsuario form = new NovoUsuario(_dsoftBd, _usuario);
			form.ShowDialog();
		}

		#endregion Methods
	}
}