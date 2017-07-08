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
	public partial class frmConsultaPrecos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private TabelaDePrecos _tabela;
		private IPedidosView _view;

		public frmConsultaPrecos(Bd bd, Usuario usuario, TabelaDePrecos tabela, IPedidosView view)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_tabela = tabela;
			_view = view;

			DataTable table = _dsoftBd.CarregarProdutosPrecos(tabela);

			dgProdutos.DataSource = table;
		}

		private void tbProduto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				int index = dgProdutos.SelectedRows[0].Index;

				dgProdutos.Focus();

				dgProdutos.CurrentCell = dgProdutos[0, index];
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				if (dgProdutos.SelectedRows.Count > 0)
				{
					Produto produto = _dsoftBd.CarregarProduto(Convert.ToInt64(dgProdutos.SelectedRows[0].Cells[0].Value));

					_view.DefinirProduto(produto);

					this.Close();
				}
			}
		}

		private void dgProdutos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				if (dgProdutos.SelectedRows.Count > 0 && dgProdutos.SelectedRows[0].Index == 0)
				{
					tbProduto.Focus();
				}
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				if (dgProdutos.SelectedRows.Count > 0)
				{
					Produto produto = _dsoftBd.CarregarProduto(Convert.ToInt64(dgProdutos.SelectedRows[0].Cells[0].Value));

					_view.DefinirProduto(produto);

					this.Close();
				}
			}
		}

		private void tbProduto_TextChanged(object sender, EventArgs e)
		{
			if (tbProduto.Text.Length > 0)
			{
				long codigo;

				if (long.TryParse(tbProduto.Text, out codigo))
				{
					//Buscamos por código
					if (dgProdutos.SortedColumn == null || dgProdutos.SortedColumn.Name != "codigo")
					{
						dgProdutos.Sort(dgProdutos.Columns[0], ListSortDirection.Ascending);
					}

					for (int i = 0; i < dgProdutos.Rows.Count; i++)
					{
						long? cursor = dgProdutos.Rows[i].Cells[0].Value as long?;

						if (cursor != null && cursor == codigo)
						{
							dgProdutos.Rows[i].Selected = true;
							dgProdutos.FirstDisplayedScrollingRowIndex = i;
							break;
						}
					}
				}
				else
				{
					//Buscamos por nome
					if (dgProdutos.SortedColumn == null || dgProdutos.SortedColumn.Name != "nome")
					{
						dgProdutos.Sort(dgProdutos.Columns[1], ListSortDirection.Ascending);
					}

					for (int i = 0; i < dgProdutos.Rows.Count; i++)
					{
						if (dgProdutos.Rows[i].Cells[1].Value.ToString().StartsWith(tbProduto.Text))
						{
							dgProdutos.Rows[i].Selected = true;
							dgProdutos.FirstDisplayedScrollingRowIndex = i;
							break;
						}
					}
				}
			}
			else
			{

			}
		}

		private void frmConsultaPrecos_Deactivate(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
