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
	public partial class frmConPedidosCliente : Form
	{
		#region Fields

		public long Cliente;

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConPedidosCliente(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Carregar()
		{
			DataSet ds = new DataSet();

			tbCliente.AutoCompleteCustomSource.Clear();

			_DSoftBd.CarregarClientes(ds);

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				tbCliente.AutoCompleteCustomSource.Add(ds.Tables[0].Rows[i].ToString());
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int pedido;
				int.TryParse(dataGridView1.SelectedRows[0].Cells["pedido"].Value.ToString(), out pedido);

				if (pedido > 0)
				{
					frmDemonstraPedido form = new frmDemonstraPedido(_DSoftBd, _usuario, pedido);
					form.Show();
				}
			}
		}

		private void frmConPedidosCliente_Load(object sender, EventArgs e)
		{
			//Carregar();

			//if (Cliente != null)
			//{
				tbCliente.Text = Cliente.ToString();
				lbCliente.Text = _DSoftBd.ClienteNome(Cliente);

				DataSet ds = new DataSet();

				if (_DSoftBd.PedidosPorCliente(Cliente, ds))
				{
					dataGridView1.DataSource = ds.Tables[0];

					dataGridView1.Columns["pedido"].HeaderText = "Pedido";
					dataGridView1.Columns["pedido"].Width = 60;
					dataGridView1.Columns["data"].HeaderText = "Data";
					dataGridView1.Columns["data"].Width = 60;
					dataGridView1.Columns["hora"].HeaderText = "Hora";
					dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
					dataGridView1.Columns["hora"].Width = 60;
					dataGridView1.Columns["saida"].HeaderText = "Saida";
					dataGridView1.Columns["saida"].DefaultCellStyle.Format = "HH:mm:ss";
					dataGridView1.Columns["saida"].Width = 60;
					dataGridView1.Columns["entrega"].HeaderText = "Entrega";
					dataGridView1.Columns["entrega"].DefaultCellStyle.Format = "HH:mm:ss";
					dataGridView1.Columns["entrega"].Width = 60;
					dataGridView1.Columns["valor"].HeaderText = "Valor";
					dataGridView1.Columns["valor"].Width = 60;
					dataGridView1.Columns["situacao"].HeaderText = "Situacao";
					dataGridView1.Columns["situacao"].Width = 60;
					dataGridView1.Columns["recurso"].HeaderText = "Recurso";
					dataGridView1.Columns["recurso"].Width = 60;
					dataGridView1.Columns["entregador"].HeaderText = "Nome";
					dataGridView1.Columns["entregador"].Width = 150;

					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
						{
						case "A":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
							break;

						case "B":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
							break;

						case "C":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
							break;

						case "E":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
							break;

						case "N":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
							break;

						case "O":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
							break;

						case "P":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
							break;

						case "S":
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
							break;
						}
					}

					if (dataGridView1.Rows.Count > 1)
					{
						dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
						//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
					}
				}
			//}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbSair_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmConPedidosCliente_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.Close();
		}

		private void tbCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		#endregion Methods
	}
}