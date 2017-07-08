using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery.Forms
{
	public partial class frmUsuarioAutorizacao : Form
	{
		#region Fields

		public Usuario UsuarioAutorizado;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmUsuarioAutorizacao(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			int codigo;
			int.TryParse(tbCodigo.Text, out codigo);

			if (codigo < 1)
			{
				MessageBox.Show("Código inválido!");
				tbCodigo.SelectAll();
				tbCodigo.Focus();
				return;
			}

			if (_dsoftBd.UsuarioCadastrado(codigo, mbSenha.Text) == '0')
			{
				MessageBox.Show("Usuário inválido!");
				tbCodigo.SelectAll();
				tbCodigo.Focus();
				return;
			}

			UsuarioAutorizado = _dsoftBd.CarregarUsuario(codigo);

			DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void mbSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void Sair()
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbSenha.Focus();
			}
		}

		#endregion Methods
	}
}