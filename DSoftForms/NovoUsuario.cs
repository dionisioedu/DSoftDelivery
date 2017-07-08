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

namespace DSoftForms
{
	public partial class NovoUsuario : Form
	{
		private DSoftBd.Bd _dsoftBd;
		private Usuario _usuario;

		public NovoUsuario(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void NovoUsuario_Load(object sender, EventArgs e)
		{
			PreencheProximoCodigo();

			tbUsuario.Focus();
		}

		private void confirmButton1_Click(object sender, EventArgs e)
		{
			if (tbUsuario.Text.Length < 3)
			{
				lbErroUsuario.Text = "*Usuário precisa ter mais de 3 caracteres!";
				tbUsuario.SelectAll();
				tbUsuario.Focus();
				return;
			}

			if (tbNome.Text.Length < 1)
			{
				lbErroNome.Text = "*Nome nãp pode ser vazio!";
				tbNome.Focus();
				return;
			}

			if (tbSenha.Text.Length < 3)
			{
				lbErroSenha.Text = "*Senha precisa ter mais de 3 caracteres!";
				tbSenha.Focus();
				return;
			}

			if (string.Compare(tbSenha.Text, tbConfirmacao.Text) != 0)
			{
				lbErroSenha.Text = "*Senha e confirmação não conferem!";
				tbSenha.Focus();
				return;
			}
			
			Usuario usuario = new Usuario();
			usuario.Codigo = Convert.ToInt32(tbCodigo.Text);
			usuario.Nome = tbUsuario.Text;
			usuario.Display = tbNome.Text;
			usuario.Senha = tbSenha.Text;
			usuario.Nivel = 'A';
			usuario.NivelUsuario.Nivel = "A";

			if (_dsoftBd.IncluirUsuario(usuario))
			{
				Recurso recurso = new Recurso();
				recurso.Codigo = Convert.ToInt32(tbCodigo.Text);
				recurso.Nome = tbNome.Text;
				recurso.Tipo = 'A';

				_dsoftBd.LogarEntrada(1);

				_dsoftBd.NovoRecurso(recurso);

				usuario = _dsoftBd.CarregarUsuario(usuario.Codigo);
				usuario.Recurso = _dsoftBd.CarregarRecurso(recurso.Codigo);

				_dsoftBd.AlterarUsuario(usuario);

				this.Close();
			}
		}

		private void cancelButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void PreencheProximoCodigo()
		{
			int codigo = 2;

			do
			{
				if (!_dsoftBd.UsuarioCadastrado(codigo))
				{
					break;
				}

				codigo++;
			} while (true);

			tbCodigo.Text = codigo.ToString();
		}

		private void tbUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbNome.Focus();
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbSenha.Focus();
			}
		}

		private void tbSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbConfirmacao.Focus();
			}
		}

		private void tbConfirmacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				confirmButton1.Focus();
			}
		}

		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{

		}

		private void tbUsuario_KeyPress(object sender, KeyPressEventArgs e)
		{
			lbErroUsuario.Text = string.Empty;
		}

		private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
		{
			lbErroNome.Text = string.Empty;
		}

		private void tbSenha_KeyPress(object sender, KeyPressEventArgs e)
		{
			lbErroSenha.Text = string.Empty;
		}

		private void tbConfirmacao_KeyPress(object sender, KeyPressEventArgs e)
		{
			lbErroSenha.Text = string.Empty;
		}
	}
}
