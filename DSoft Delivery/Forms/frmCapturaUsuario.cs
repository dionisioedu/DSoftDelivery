using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class frmCapturaUsuario : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCapturaUsuario(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Confirmar()
		{
			int usuario;

			if (tbUsuario.Text.Length == 0)
			{
				MessageBox.Show("Digite o código do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbUsuario.Focus();

				return;
			}

			if (!int.TryParse(tbUsuario.Text, out usuario) || usuario == 0)
			{
				MessageBox.Show("Código de usuário inválido! Código deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbUsuario.SelectAll();
				tbUsuario.Focus();

				return;
			}

			if (_dsoftBd.UsuarioCadastrado(usuario, tbSenha.Text) == '0')
			{
				MessageBox.Show("Usuário inválido/senha incorreta!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbUsuario.SelectAll();
				tbUsuario.Focus();

				return;
			}

			//Globais.UsuarioTemporario = usuario;

			DialogResult = DialogResult.OK;

			Close();
		}

		private void frmCapturaUsuario_Load(object sender, EventArgs e)
		{
		}

		private void Sair()
		{
			DialogResult = DialogResult.Cancel;

			Close();
		}

		private void tbSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btConfirmar.Focus();
		}

		private void tbUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				tbSenha.Focus();
		}

		#endregion Methods
	}
}