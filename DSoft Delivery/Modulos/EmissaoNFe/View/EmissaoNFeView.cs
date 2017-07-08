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

using DSoft_Delivery.Modulos.EmissaoNFe.Model;
using DSoft_Delivery.Modulos.EmissaoNFe.Presenter;

namespace DSoft_Delivery.Modulos.EmissaoNFe.View
{
	public partial class EmissaoNFeView : Form, IEmissaoNFeView
	{
		#region Fields

		private DataSet dsNFe;
		private DataSet dsPedidos;
		private EmissaoNFeModel Model;
		private EmissaoNFePresenter Presenter;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public EmissaoNFeView(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Model = new EmissaoNFeModel();
			Presenter = new EmissaoNFePresenter(bd, usuario, Model, this);
		}

		#endregion Constructors

		#region Events

		public event EventHandler FormLoaded;

		public event EventHandler GerarNFeClicked;

		public event EventHandler PedidoSelected;

		#endregion Events

		#region Methods

		public void AdicionarItem(object[] itens)
		{
			this.Invoke(new Action(() =>
				{
					int r = dtItens.Rows.Add();
					int c = 0;

					foreach (object o in itens)
					{
						dtItens.Rows[r].Cells[c++].Value = o;
					}
				}));
		}

		public void AtualizaNFe(int indice, string situacao)
		{
			this.Invoke(new Action(() =>
			{
				string _indice = indice.ToString();

				for (int i = dtNFe.Rows.Count - 1; i >= 0; i--)
				{
					if (dtNFe.Rows[i].Cells["indice"].Value.ToString() == _indice)
					{
						dtNFe.Rows[i].Cells["situacao"].Value = situacao;

						if (situacao == "R")
						{
							dtNFe.Rows[i].DefaultCellStyle.BackColor = Color.Black;
							dtNFe.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
						else if (situacao == "U")
						{
							dtNFe.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
							dtNFe.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
					}
				}
			}));
		}

		public void AtualizarNFe(DataTable dt)
		{
			this.Invoke(new Action(() =>
			{
				dtNFe.DataSource = dt;
			}));
		}

		public void AvisoEmitente(bool visible)
		{
			this.Invoke(new Action(() =>
			{
				lbAvisoEmitente.Visible = visible;
			}));
		}

		public void CarregarEmitentes(List<string> emitentes)
		{
			this.Invoke(new Action(() =>
				{
					cbEmitente.Items.Clear();
					cbEmitente.Items.AddRange(emitentes.ToArray());

					if (cbEmitente.Items.Count > 0)
						cbEmitente.SelectedIndex = 0;
				}));
		}

		public void CarregarPedidos(DataSet ds)
		{
			dsPedidos = ds;

			this.Invoke(new Action(() => { Atualizar(); }));
		}

		public void DefinirDadosPedido(long codigo, string cliente, int pedido, string data, int itens, decimal valor)
		{
			this.Invoke(new Action(() =>
				{
					tbCodigo.Text = codigo.ToString();
					tbCliente.Text = cliente;
					tbPedido.Text = pedido.ToString();
					tbData.Text = data;
					tbQuantidade.Text = itens.ToString();
					tbValor.Text = valor.ToString("##,###,##0.00");
				}));
		}

		public string EmitenteSelecionado()
		{
			return cbEmitente.Text;
		}

		public void InicializarListaItens(string[] cols)
		{
		}

		public int[] ItensSelecionados()
		{
			int[] itens = null;

			if (dtItens.SelectedRows.Count > 0)
			{
				int i = 0;
				itens = new int[dtItens.SelectedRows.Count];

				foreach (DataGridViewRow row in dtItens.SelectedRows)
				{
					itens[i++] = Convert.ToInt32(row.Cells["Item"].Value);
				}
			}

			return itens;
		}

		public void LimparItens()
		{
			this.Invoke(new Action(() =>
				{
					dtItens.Rows.Clear();
				}));
		}

		public void LimparItensSelecionados()
		{
			dtItens.ClearSelection();
		}

		private void Atualizar()
		{
			if (dsPedidos == null)
				return;

			dtPedidos.DataSource = dsPedidos.Tables[0];

			dtPedidos.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

			dtPedidos.Columns["codigo"].Width = 45;
			dtPedidos.Columns["codigo"].HeaderText = "Código";
			dtPedidos.Columns["data"].Width = 68;
			dtPedidos.Columns["data"].HeaderText = "Data";
			dtPedidos.Columns["hora"].Width = 68;
			dtPedidos.Columns["hora"].HeaderText = "Hora";
			dtPedidos.Columns["cliente"].Width = 68;
			dtPedidos.Columns["cliente"].HeaderText = "Cliente";
			dtPedidos.Columns["nome"].Width = 172;
			dtPedidos.Columns["nome"].HeaderText = "Nome";
			dtPedidos.Columns["itens"].Width = 40;
			dtPedidos.Columns["itens"].HeaderText = "Itens";
			dtPedidos.Columns["total"].Width = 80;
			dtPedidos.Columns["total"].HeaderText = "Total R$";
			dtPedidos.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtPedidos.Columns["situacao"].Width = 30;
			dtPedidos.Columns["situacao"].HeaderText = "Sit.";
			dtPedidos.Columns["observacao"].Width = 172;
			dtPedidos.Columns["observacao"].HeaderText = "Observação";
			dtPedidos.Columns["usuario"].Width = 68;
			dtPedidos.Columns["usuario"].HeaderText = "Usuário";
			dtPedidos.Columns["nome1"].Width = 172;
			dtPedidos.Columns["nome1"].HeaderText = "Nome";
		}

		private void btGerarNFe_Click(object sender, EventArgs e)
		{
			GerarNFeClicked.Invoke(sender, e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dtItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			decimal d;

			if (decimal.TryParse((sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value.ToString(), out d))
			{
				(sender as DataGridView)[e.ColumnIndex, e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
			else
			{
				(sender as DataGridView)[e.ColumnIndex, e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			}
		}

		private void dtItens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dtPedidos_DoubleClick(object sender, EventArgs e)
		{
			PedidoSelected.Invoke(sender, e);
		}

		private void dtPedidos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			DataGridViewRow r = grid.Rows[e.RowIndex];

			DataGridViewCellStyle style = new DataGridViewCellStyle(r.DefaultCellStyle);

			switch (r.Cells["situacao"].Value.ToString())
			{
				case "A":
					style.BackColor = Color.White;
					style.ForeColor = Color.Black;
					break;

				case "B":
					style.BackColor = Color.Yellow;
					style.ForeColor = Color.Black;
					break;

				case "C":
					style.BackColor = Color.Red;
					style.ForeColor = Color.White;
					break;

				case "E":
					style.BackColor = Color.Blue;
					style.ForeColor = Color.White;
					break;

				case "N":
					style.BackColor = Color.LightGreen;
					style.ForeColor = Color.Black;
					break;

				case "O":
					style.BackColor = Color.Violet;
					style.ForeColor = Color.White;
					break;

				case "P":
					style.BackColor = Color.Green;
					style.ForeColor = Color.White;
					break;

				case "S":
					style.BackColor = Color.LightBlue;
					style.ForeColor = Color.Black;
					break;
			}

			r.DefaultCellStyle = style;
		}

		private void EmissaoNFeView_Load(object sender, EventArgs e)
		{
			FormLoaded.Invoke(sender, e);
		}

		#endregion Methods
	}
}