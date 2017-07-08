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
	public partial class BuscaClientePorTelefone : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		public Cliente Cliente;

		#endregion

		#region Constructors

		public BuscaClientePorTelefone(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		public BuscaClientePorTelefone(Bd bd, Usuario usuario, long numero)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Buscar(numero);
		}

		#endregion

		#region Methods

		private void frmBuscaClientePorTelefone_Load(object sender, EventArgs e)
		{

		}

		private void Buscar()
		{
			long numero;
			long.TryParse(tbNumero.Text, out numero);

			if (numero == 0)
			{
				tbNumero.SelectAll();
				tbNumero.Focus();
				return;
			}

			Buscar(numero);
		}

		private void Buscar(long numero)
		{
			lbClientes.Items.Clear();

			List<Cliente> clientes = _dsoftBd.BuscaClientePorTelefone(numero);

			lbClientes.Items.AddRange(clientes.ToArray());
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btBuscar_Click(object sender, EventArgs e)
		{
			Buscar();
		}

		private void tbNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btBuscar.Focus();
			}
		}

		private void lbClientes_DoubleClick(object sender, EventArgs e)
		{
			if (lbClientes.SelectedItem != null)
			{
				this.Cliente = lbClientes.SelectedItem as Cliente;
				this.Close();
			}
		}

		private void tbNumero_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		#endregion
	}
}
