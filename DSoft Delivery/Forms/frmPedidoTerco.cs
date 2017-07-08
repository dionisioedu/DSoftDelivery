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

using DSoftParameters;

namespace DSoft_Delivery.Forms
{
	public partial class frmPedidoTerco : Form
	{
		#region Fields

		public List<ItemPedido> Itens;
		public decimal Preco;
		public int Tabela = 1;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmPedidoTerco(Bd bd, Usuario usuario)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void Cancelar()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void Carregar()
		{
			List<Produto> produtos = _dsoftBd.ProdutosMeioAMeio();

			if (produtos != null)
			{
				cbProduto1.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto3.DropDownStyle = ComboBoxStyle.DropDownList;

				foreach (Produto produto in produtos)
				{
					cbProduto1.Items.Add(produto);
					cbProduto2.Items.Add(produto);
					cbProduto3.Items.Add(produto);
				}

				if (Preferencias.ProdutoPorNome)
				{
					foreach (Produto produto in produtos)
					{
						cbProduto1.Items.Add(produto.Nome);
						cbProduto2.Items.Add(produto.Nome);
						cbProduto3.Items.Add(produto.Nome);
					}
				}

				cbProduto1.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto3.DropDownStyle = ComboBoxStyle.DropDown;
			}

			if (!RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarItensAdicionais(ds);

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					ItemAdicional item = new ItemAdicional();

					item.Descricao = dr["descricao"].ToString();

					decimal valor;
					decimal.TryParse(dr["adicional"].ToString(), out valor);

					if (valor != 0)
					{
						item.Valor = valor;
					}

					clItensAdicionais1.Items.Add(item);
					clItensAdicionais2.Items.Add(item);
					clItensAdicionais3.Items.Add(item);
				}
			}
		}

		private void cbProduto1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cbProduto2.Focus();
		}

		private void cbProduto1_Leave(object sender, EventArgs e)
		{
			if (cbProduto1.Text.Length > 1)
			{
				string nome, descricao;
				long prod1;
				decimal preco;

				if (!long.TryParse(cbProduto1.Text.Split(" - ".ToCharArray(), 2)[0], out prod1))
				{
					if (!Preferencias.ProdutoPorNome || ((prod1 = _dsoftBd.ProdutoCodigo(cbProduto1.Text)) == 0))
					{
						MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbProduto1.Focus();

						return;
					}
				}

				_dsoftBd.CarregarProduto(Tabela, prod1, out nome, out descricao, out preco);

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					clItensAdicionais1.Items.Clear();
					List<ItemAdicional> itens = _dsoftBd.CarregarItensAdicionais(prod1);
					clItensAdicionais1.Items.AddRange(itens.ToArray());
				}

				tbPreco1.Text = preco.ToString("###,###,##0.00");

				SomaTotal();
			}
		}

		private void cbProduto1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Produto produto = cbProduto1.SelectedItem as Produto;

			if (produto != null)
			{
				clItensAdicionais1.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(produto.Codigo);
			}
			else
			{
				clItensAdicionais1.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(_dsoftBd.ProdutoCodigo(cbProduto1.Text));
			}
		}

		private void cbProduto2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cbProduto3.Focus();
		}

		private void cbProduto2_Leave(object sender, EventArgs e)
		{
			if (cbProduto2.Text.Length > 1)
			{
				string nome, descricao;
				long prod1;
				decimal preco;

				if (!long.TryParse(cbProduto2.Text.Split(" - ".ToCharArray(), 2)[0], out prod1))
				{
					if (!Preferencias.ProdutoPorNome || ((prod1 = _dsoftBd.ProdutoCodigo(cbProduto2.Text)) == 0))
					{
						MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbProduto2.Focus();

						return;
					}
				}

				_dsoftBd.CarregarProduto(Tabela, prod1, out nome, out descricao, out preco);

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					clItensAdicionais2.Items.Clear();
					List<ItemAdicional> itens = _dsoftBd.CarregarItensAdicionais(prod1);
					clItensAdicionais2.Items.AddRange(itens.ToArray());
				}

				tbPreco2.Text = preco.ToString("###,###,##0.00");

				SomaTotal();
			}
		}

		private void cbProduto2_SelectedIndexChanged(object sender, EventArgs e)
		{
			Produto produto = cbProduto2.SelectedItem as Produto;

			if (produto != null)
			{
				clItensAdicionais2.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(produto.Codigo);
			}
			else
			{
				clItensAdicionais2.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(_dsoftBd.ProdutoCodigo(cbProduto2.Text));
			}
		}

		private void cbProduto3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				tbQuantidade.Focus();
		}

		private void cbProduto3_Leave(object sender, EventArgs e)
		{
			if (cbProduto3.Text.Length > 1)
			{
				string nome, descricao;
				long prod1;
				decimal preco;

				if (!long.TryParse(cbProduto3.Text.Split(" - ".ToCharArray(), 2)[0], out prod1))
				{
					if (!Preferencias.ProdutoPorNome || ((prod1 = _dsoftBd.ProdutoCodigo(cbProduto3.Text)) == 0))
					{
						MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbProduto3.Focus();

						return;
					}
				}

				_dsoftBd.CarregarProduto(Tabela, prod1, out nome, out descricao, out preco);

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					clItensAdicionais3.Items.Clear();
					List<ItemAdicional> itens = _dsoftBd.CarregarItensAdicionais(prod1);
					clItensAdicionais3.Items.AddRange(itens.ToArray());
				}

				tbPreco3.Text = preco.ToString("###,###,##0.00");

				SomaTotal();
			}
		}

		private void cbProduto3_SelectedIndexChanged(object sender, EventArgs e)
		{
			Produto produto = cbProduto3.SelectedItem as Produto;

			if (produto != null)
			{
				clItensAdicionais3.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(produto.Codigo);
			}
			else
			{
				clItensAdicionais3.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(_dsoftBd.ProdutoCodigo(cbProduto3.Text));
			}
		}

		private void clItensAdicionais1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke(new MethodInvoker(SomaTotal));
		}

		private void clItensAdicionais2_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke(new MethodInvoker(SomaTotal));
		}

		private void clItensAdicionais3_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke(new MethodInvoker(SomaTotal));
		}

		private void Confirmar()
		{
			long prod1, prod2, prod3;
			decimal preco1, preco2, preco3, preco_adicionais = 0;
			float quantidade;
			decimal desconto;

			Itens = new List<ItemPedido>(3);

			if (!long.TryParse(cbProduto1.Text.Split(" - ".ToCharArray(), 2)[0], out prod1))
			{
				if (!Preferencias.ProdutoPorNome || ((prod1 = _dsoftBd.ProdutoCodigo(cbProduto1.Text)) == 0))
				{
					MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbProduto1.Focus();

					return;
				}
			}

			if (!long.TryParse(cbProduto2.Text.Split(" - ".ToCharArray(), 2)[0], out prod2))
			{
				if (!Preferencias.ProdutoPorNome || ((prod2 = _dsoftBd.ProdutoCodigo(cbProduto2.Text)) == 0))
				{
					MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbProduto2.Focus();

					return;
				}
			}

			if (!long.TryParse(cbProduto3.Text.Split(" - ".ToCharArray(), 2)[0], out prod3))
			{
				if (!Preferencias.ProdutoPorNome || ((prod3 = _dsoftBd.ProdutoCodigo(cbProduto3.Text)) == 0))
				{
					MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbProduto3.Focus();

					return;
				}
			}

			decimal.TryParse(tbPreco1.Text, out preco1);
			decimal.TryParse(tbPreco2.Text, out preco2);
			decimal.TryParse(tbPreco3.Text, out preco3);

			if (!float.TryParse(tbQuantidade.Text, out quantidade) || quantidade <= 0)
			{
				MessageBox.Show("Quantidade inválida!");
				tbQuantidade.SelectAll();
				tbQuantidade.Focus();
				return;
			}

			decimal.TryParse(tbDesconto.Text, out desconto);

			if (desconto != 0)
			{
				preco1 = preco1 - ((preco1 * desconto) / 100);
				preco2 = preco2 - ((preco2 * desconto) / 100);
				preco3 = preco3 - ((preco3 * desconto) / 100);
			}

			ItemPedido item1 = new ItemPedido();
			item1.Produto = prod1;
			item1.ProdutoNome = _dsoftBd.ProdutoNome(prod1);
			item1.Quantidade = quantidade / 3;
			item1.Preco = preco1;
			item1.Observacao = tbObservacao.Text;

			for (int i = 0; i < clItensAdicionais1.Items.Count; i++)
			{
				if (clItensAdicionais1.GetSelected(i))
				{
					preco_adicionais += ((ItemAdicional)clItensAdicionais1.Items[i]).Valor;

					item1.ItensAdicionais.Add((ItemAdicional)clItensAdicionais1.Items[i]);
				}
			}

			ItemPedido item2 = new ItemPedido();
			item2.Produto = prod2;
			item2.ProdutoNome = _dsoftBd.ProdutoNome(prod2);
			item2.Quantidade = quantidade / 3;
			item2.Preco = preco2;
			item2.Observacao = tbObservacao2.Text;

			for (int i = 0; i < clItensAdicionais2.Items.Count; i++)
			{
				if (clItensAdicionais2.GetSelected(i))
				{
					preco_adicionais += ((ItemAdicional)clItensAdicionais2.Items[i]).Valor;

					item2.ItensAdicionais.Add((ItemAdicional)clItensAdicionais2.Items[i]);
				}
			}

			ItemPedido item3 = new ItemPedido();
			item3.Produto = prod3;
			item3.ProdutoNome = _dsoftBd.ProdutoNome(prod3);
			item3.Quantidade = quantidade / 3;
			item3.Preco = preco3;
			item3.Observacao = tbObservacao3.Text;

			for (int i = 0; i < clItensAdicionais3.Items.Count; i++)
			{
				if (clItensAdicionais3.GetSelected(i))
				{
					preco_adicionais += ((ItemAdicional)clItensAdicionais3.Items[i]).Valor;

					item3.ItensAdicionais.Add((ItemAdicional)clItensAdicionais3.Items[i]);
				}
			}

			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				item1.Preco = (item1.Preco + item2.Preco + item3.Preco) / 3;
				item1.Preco += preco_adicionais;

				Itens.Add(item1);

				item2.Preco = 0;
				item2.Secundario = true;

				Itens.Add(item2);

				item3.Preco = 0;
				item3.Secundario = true;

				Itens.Add(item3);
			}
			else
			{
				if (preco1 >= preco2 && preco1 >= preco3)
				{
					item1.Preco += preco_adicionais;

					Itens.Add(item1);

					item2.Secundario = true;
					item2.Preco = 0;
					Itens.Add(item2);

					item3.Secundario = true;
					item3.Preco = 0;
					Itens.Add(item3);
				}
				else if (preco2 >= preco1 && preco2 >= preco3)
				{
					item2.Preco += preco_adicionais;

					Itens.Add(item2);

					item1.Secundario = true;
					item1.Preco = 0;
					Itens.Add(item1);

					item3.Secundario = true;
					item3.Preco = 0;
					Itens.Add(item3);
				}
				else
				{
					item3.Preco += preco_adicionais;

					Itens.Add(item3);

					item1.Secundario = true;
					item1.Preco = 0;
					Itens.Add(item1);

					item2.Secundario = true;
					item2.Preco = 0;
					Itens.Add(item2);
				}
			}

			this.DialogResult = DialogResult.OK;

			SomaTotal();

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmPedidoTerco_Load(object sender, EventArgs e)
		{
			Carregar();
		}

		private void SomaTotal()
		{
			decimal qtd;
			decimal desconto;
			decimal val1, val2, val3, maior, total;

			if (!decimal.TryParse(tbQuantidade.Text, out qtd))
			{
				qtd = 1;
				tbQuantidade.Text = "1";
			}

			decimal.TryParse(tbDesconto.Text, out desconto);

			decimal.TryParse(tbPreco1.Text, out val1);
			decimal.TryParse(tbPreco2.Text, out val2);
			decimal.TryParse(tbPreco3.Text, out val3);

			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				maior = (val1 + val2 + val3) / 3;
			}
			else
			{
				// Fica com o maior valor entre os 3
				maior = (val1 > val2 ? val1 : val2);
				maior = (maior > val3 ? maior : val3);
			}

			total = maior * qtd;

			if (desconto != 0)
				total -= ((total * desconto) / 100);

			if (clItensAdicionais1.Enabled)
			{
				for (int i = 0; i < clItensAdicionais1.Items.Count; i++)
				{
					if (clItensAdicionais1.GetItemChecked(i))
					{
						ItemAdicional item = clItensAdicionais1.Items[i] as ItemAdicional;

						if (item != null && item.Valor != 0)
						{
							total += item.Valor;
						}
					}
				}
			}

			if (clItensAdicionais2.Enabled)
			{
				for (int i = 0; i < clItensAdicionais2.Items.Count; i++)
				{
					if (clItensAdicionais2.GetItemChecked(i))
					{
						ItemAdicional item = clItensAdicionais2.Items[i] as ItemAdicional;

						if (item != null && item.Valor != 0)
						{
							total += item.Valor;
						}
					}
				}
			}

			if (clItensAdicionais3.Enabled)
			{
				for (int i = 0; i < clItensAdicionais3.Items.Count; i++)
				{
					if (clItensAdicionais3.GetItemChecked(i))
					{
						ItemAdicional item = clItensAdicionais3.Items[i] as ItemAdicional;

						if (item != null && item.Valor != 0)
						{
							total += item.Valor;
						}
					}
				}
			}

			Preco = total;
			tbPreco.Text = total.ToString("##,###,##0.00");
		}

		private void tbQuantidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmCadAdicionaisRapido form = new frmCadAdicionaisRapido(_dsoftBd, _usuario);
			form.ShowDialog();

			if (form.ItemAdicional != null)
			{
				ItemAdicional item = form.ItemAdicional;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					Produto prod = cbProduto1.SelectedItem as Produto;

					if (prod != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, prod.Codigo);
					}
					else if (cbProduto1.Text.Length > 0)
					{
						_dsoftBd.AdicionarItemAdicional(item, _dsoftBd.ProdutoCodigo(cbProduto1.Text));
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clItensAdicionais1.Items.Add(item);
				clItensAdicionais1.SetItemChecked(clItensAdicionais1.Items.Count - 1, true);
				this.BeginInvoke(new MethodInvoker(SomaTotal));
			}
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmCadAdicionaisRapido form = new frmCadAdicionaisRapido(_dsoftBd, _usuario);
			form.ShowDialog();

			if (form.ItemAdicional != null)
			{
				ItemAdicional item = form.ItemAdicional;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					Produto prod = cbProduto2.SelectedItem as Produto;

					if (prod != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, prod.Codigo);
					}
					else if (cbProduto2.Text.Length > 0)
					{
						_dsoftBd.AdicionarItemAdicional(item, _dsoftBd.ProdutoCodigo(cbProduto2.Text));
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clItensAdicionais2.Items.Add(item);
				clItensAdicionais2.SetItemChecked(clItensAdicionais2.Items.Count - 1, true);
				this.BeginInvoke(new MethodInvoker(SomaTotal));
			}
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmCadAdicionaisRapido form = new frmCadAdicionaisRapido(_dsoftBd, _usuario);
			form.ShowDialog();

			if (form.ItemAdicional != null)
			{
				ItemAdicional item = form.ItemAdicional;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					Produto prod = cbProduto3.SelectedItem as Produto;

					if (prod != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, prod.Codigo);
					}
					else if (cbProduto3.Text.Length > 0)
					{
						_dsoftBd.AdicionarItemAdicional(item, _dsoftBd.ProdutoCodigo(cbProduto3.Text));
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clItensAdicionais3.Items.Add(item);
				clItensAdicionais3.SetItemChecked(clItensAdicionais3.Items.Count - 1, true);
				this.BeginInvoke(new MethodInvoker(SomaTotal));
			}
		}

		#endregion Methods
	}
}