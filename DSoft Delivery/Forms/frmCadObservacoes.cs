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
using DSoft_Delivery.Pedidos;

namespace DSoft_Delivery.Forms
{
	public partial class frmCadObservacoes : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private IPedidosView _view;

		public frmCadObservacoes(Bd bd, Usuario usuario, IPedidosView view)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_view = view;
		}

		private void frmCadObservacoes_Load(object sender, EventArgs e)
		{
			List<string> observacoes = _dsoftBd.CarregarObservacoes();

			if (observacoes != null)
			{
				if (observacoes.Count > 0)
				{
					tbObs1.Text = observacoes[0];
				}

				if (observacoes.Count > 1)
				{
					tbObs2.Text = observacoes[1];
				}

				if (observacoes.Count > 2)
				{
					tbObs3.Text = observacoes[2];
				}

				if (observacoes.Count > 3)
				{
					tbObs4.Text = observacoes[3];
				}
			}
		}

		private void Confirmar()
		{
			_dsoftBd.LimparObservacoes();

			if (tbObs1.Text.Length > 0)
			{
				_dsoftBd.IncluirObservacao(tbObs1.Text, 0);
			}

			if (tbObs2.Text.Length > 0)
			{
				_dsoftBd.IncluirObservacao(tbObs2.Text, 1);
			}

			if (tbObs3.Text.Length > 0)
			{
				_dsoftBd.IncluirObservacao(tbObs3.Text, 2);
			}

			if (tbObs4.Text.Length > 0)
			{
				_dsoftBd.IncluirObservacao(tbObs4.Text, 3);
			}

			if (tbObs5.Text.Length > 0)
			{
				_dsoftBd.IncluirObservacao(tbObs5.Text, 4);
			}

			List<string> observacoes = _dsoftBd.CarregarObservacoes();

			_view.DefinirObservacoes(observacoes);

			this.Close();
		}

		private void Sair()
		{
			this.Close();
		}

		private void frmCadObservacoes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
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

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}
	}
}
