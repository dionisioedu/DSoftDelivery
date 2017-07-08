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

namespace DSoft_Delivery.Pedidos
{
	public partial class PedidoDetalhado : Form
	{
		public Pedido Pedido;

		private Bd _dsoftBd;
		private Usuario _usuario;

		public PedidoDetalhado(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void PedidoDetalhado_Load(object sender, EventArgs e)
		{
			if (Pedido != null)
			{
				CarregarDetalhes(Pedido);
			}
		}

		private void CarregarDetalhes(int numero)
		{
			Pedido pedido = new Pedido();

			tbDetalhes.Clear();

			if (_dsoftBd.CarregarPedido(numero, pedido))
			{
				CarregarDetalhes(pedido);
			}
		}

		private void CarregarDetalhes(Pedido pedido)
		{
			Cliente cliente = _dsoftBd.CarregarCliente(pedido.Cliente);

			tbDetalhes.AppendText(cliente.ToString());
			tbDetalhes.AppendText(Environment.NewLine + Environment.NewLine);
			tbDetalhes.AppendText(pedido.ToString());
			tbDetalhes.AppendText(Environment.NewLine + Environment.NewLine);

			foreach (ItemPedido i in pedido.ItensPedido)
			{
				tbDetalhes.AppendText(i.ToString());

				Recurso recurso = _dsoftBd.CarregarRecurso(i.Recurso);

				if (recurso != null)
				{
					tbDetalhes.AppendText(string.Format(" ({0})", recurso.ToString()));
				}

				tbDetalhes.AppendText(Environment.NewLine);
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbPedido_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int pedido;
				int.TryParse(tbPedido.Text, out pedido);

				if (pedido > 0)
				{
					CarregarDetalhes(pedido);
				}
			}
		}
	}
}
