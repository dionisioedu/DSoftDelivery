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
	public partial class frmCadRecebimentosTipos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmCadRecebimentosTipos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCadRecebimentosTipos_Load(object sender, EventArgs e)
		{
			CarregarTipos();
		}

		private void CarregarTipos()
		{
			DataTable tipos = _dsoftBd.CarregarRecebimentosTipos();

			dgRecebimentos.DataSource = tipos;
		}

		private void Confirmar()
		{
			if (tbCodigo.Text.Length > 0 && tbNome.Text.Length > 0)
			{
				int codigo;

				if (int.TryParse(tbCodigo.Text, out codigo) && codigo > 0)
				{
					RecebimentoTipo tipo = new RecebimentoTipo();
					tipo.Codigo = codigo;
					tipo.Nome = tbNome.Text;

					if (_dsoftBd.IncluirOuAlterar(tipo))
					{
						Limpar();
						CarregarTipos();
					}
				}
			}
		}

		private void Limpar()
		{
			tbCodigo.Text = string.Empty;
			tbNome.Text = string.Empty;

			tbCodigo.Focus();
		}

		private void Sair()
		{
			this.Close();
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
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
				btConfirmar.Focus();
			}
		}
	}
}
