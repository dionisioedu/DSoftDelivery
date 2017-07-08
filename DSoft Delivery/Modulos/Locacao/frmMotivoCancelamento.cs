using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery.Modulos.Locacao
{
	public partial class frmMotivoCancelamento : Form
	{
		private DSoftBd.Bd _dsoftBd;
		private DSoftModels.Usuario _usuario;

		public DSoftModels.Usuario Usuario;
		public string Motivo;

		public frmMotivoCancelamento(DSoftBd.Bd bd, DSoftModels.Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		public void ValidarUsuario()
		{
			int usuario;
			int.TryParse(tbUsuario.Text, out usuario);

			if (usuario > 0
				&& tbSenha.Text.Length > 0
				&& (Usuario = _dsoftBd.CarregarUsuario(usuario, tbSenha.Text)) != null
				&& tbMotivo.Text.Length > 0)
			{
				this.Motivo = tbMotivo.Text;

				btConfirmar.Enabled = true;
			}
			else
			{
				btConfirmar.Enabled = false;
			}
		}

		private void HabilitaCancelamento()
		{
			if (Usuario != null && tbMotivo.Text.Length > 0)
			{
				btConfirmar.Enabled = true;
			}
			else
			{
				btConfirmar.Enabled = false;
			}
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
				tbMotivo.Focus();
			}
		}

		private void tbMotivo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
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

		private void tbMotivo_TextChanged(object sender, EventArgs e)
		{
			HabilitaCancelamento();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmMotivoCancelamento_Load(object sender, EventArgs e)
		{
			tbUsuario.Text = _usuario.Codigo.ToString();
			tbUsuario.Focus();
		}
	}
}
