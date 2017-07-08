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
	public partial class frmDemonstraPedido : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private int _pedido;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmDemonstraPedido(Bd bd, Usuario usuario, int pedido)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_pedido = pedido;
		}

		#endregion Constructors

		#region Methods

		private void frmDemonstraPedido_Load(object sender, EventArgs e)
		{
			Pedido pedido = new Pedido();

			if (_dsoftBd.CarregarPedido(_pedido, pedido))
			{
				string ticket = DSPrintingHelper.PrinterHelper.PrintOrder(pedido, new Caixa() { Codigo = 1, Descricao = "" }, _usuario.Codigo, _dsoftBd, Licenca.Instance, false);

				ticket = ticket.Replace("\n", Environment.NewLine);

				tbPedido.Text = ticket;

				tbPedido.SelectionStart = 0;
				tbPedido.SelectionLength = 0;
			}
		}

		private void frmDemonstraPedido_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void tbPedido_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		#endregion Methods
	}
}