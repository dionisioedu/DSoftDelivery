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

namespace DSoft_Delivery
{
	public partial class frmCapturaPonto2 : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Usuario usuario_ponto;

		public frmCapturaPonto2(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCapturaPonto2_Load(object sender, EventArgs e)
		{
			btConfirmar.Enabled = false;
			cbTipo.SelectedIndex = 0;

			tbUsuario.Text = _usuario.Codigo.ToString();
			tbUsuario.SelectAll();
			tbUsuario.Focus();
		}

		public void Sair()
		{
			this.Close();
		}

		private void ValidarUsuario()
		{
			int usuario;
			int.TryParse(tbUsuario.Text, out usuario);

			if (usuario < 1)
			{
				tbUsuario.SelectAll();

				btConfirmar.Enabled = false;

				return;
			}

			if (tbSenha.Text.Length < 1)
			{
				tbSenha.SelectAll();

				btConfirmar.Enabled = false;

				return;
			}

			usuario_ponto = _dsoftBd.CarregarUsuario(usuario, tbSenha.Text);

			if (usuario_ponto != null)
			{
				cbTipo.Text = _dsoftBd.ProximoSentidoPonto(usuario_ponto);

				btConfirmar.Enabled = true;
			}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbUsuario_KeyDown(object sender, KeyEventArgs e)
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
				ValidarUsuario();

				btConfirmar.Focus();
			}
		}

		private void tbUsuario_Leave(object sender, EventArgs e)
		{
			ValidarUsuario();
		}

		private void tbSenha_Leave(object sender, EventArgs e)
		{
			ValidarUsuario();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			if (_dsoftBd.MarcarPonto(usuario_ponto, cbTipo.Text, dtData.Value, dtHora.Value))
			{
				this.Close();
			}
		}
	}
}
