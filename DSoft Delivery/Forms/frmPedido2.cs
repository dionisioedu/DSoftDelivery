using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

using DSoftParameters;
using DSoft_Delivery.Forms;

namespace DSoft_Delivery
{
	public partial class frmPedido2 : Form
	{
		#region Fields

		public List<ItemPedido> Itens;

		//public string Observacao;
		public decimal Preco;

		//public long ProdutoPrincipal;
		//public long ProdutoSecundario;
		public int Tabela;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmPedido2(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Itens = new List<ItemPedido>();
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Carregar()
		{
			List<Produto> produtos = _dsoftBd.ProdutosMeioAMeio();

			if (produtos != null)
			{
				cbProduto1.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDownList;

				foreach (Produto produto in produtos)
				{
					cbProduto1.Items.Add(produto);
					cbProduto2.Items.Add(produto);
				}

				if (Preferencias.ProdutoPorNome)
				{
					foreach (Produto produto in produtos)
					{
						cbProduto1.Items.Add(produto.Nome);
						cbProduto2.Items.Add(produto.Nome);
					}
				}

				cbProduto1.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDown;
			}

			DataSet ds = new DataSet();

			if (!RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
			{
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
				//btConfirmar.Focus();
				tbQuantidade.Focus();
		}

		private void cbProduto2_Leave(object sender, EventArgs e)
		{
			if (cbProduto2.Text.Length > 1)
			{
				string nome, descricao;
				long prod2;
				decimal preco;

				if (!long.TryParse(cbProduto2.Text.Split(" - ".ToCharArray(), 2)[0], out prod2))
				{
					if (!Preferencias.ProdutoPorNome || ((prod2 = _dsoftBd.ProdutoCodigo(cbProduto2.Text)) == 0))
					{
						MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbProduto2.Focus();

						return;
					}
				}

				_dsoftBd.CarregarProduto(Tabela, prod2, out nome, out descricao, out preco);

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					clItensAdicionais2.Items.Clear();
					List<ItemAdicional> itens = _dsoftBd.CarregarItensAdicionais(prod2);
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

		private void clItensAdicionais1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke(new MethodInvoker(SomaTotal));
		}

		private void clItensAdicionais2_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke(new MethodInvoker(SomaTotal));
		}

		private void Confirmar()
		{
			long prod1, prod2;
			decimal preco1, preco2, preco_adicionais = 0;
			float quantidade;
			decimal desconto;

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

			if (!decimal.TryParse(tbPreco1.Text, out preco1))
			{
				preco1 = 0;
			}

			if (!decimal.TryParse(tbPreco2.Text, out preco2))
			{
				preco2 = 0;
			}

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
			}

			ItemPedido item1 = new ItemPedido();
			item1.Produto = prod1;
			item1.ProdutoNome = _dsoftBd.ProdutoNome(prod1);
			item1.Quantidade = quantidade / 2;
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
			item2.Quantidade = quantidade / 2;
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

			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				item1.Preco = (item1.Preco + item2.Preco) / 2;
				item1.Preco += preco_adicionais;

				Itens.Add(item1);

				item2.Preco = 0;
				item2.Secundario = true;

				Itens.Add(item2);
			}
			else
			{
				if (preco1 >= preco2)
				{
					item1.Preco += preco_adicionais;

					Itens.Add(item1);

					item2.Secundario = true;
					item2.Preco = 0;
					Itens.Add(item2);
				}
				else
				{
					item2.Preco += preco_adicionais;

					Itens.Add(item2);

					item1.Secundario = true;
					item1.Preco = 0;
					Itens.Add(item1);
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

		private void frmPedido2_Load(object sender, EventArgs e)
		{
			Carregar();
		}

		private void Sair()
		{
			this.DialogResult = DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void SomaTotal()
		{
			decimal qtd;
			decimal desconto;
			decimal val1, val2, maior, total;

			if (!decimal.TryParse(tbQuantidade.Text, out qtd))
			{
				qtd = 1;
				tbQuantidade.Text = "1";
			}

			if (!decimal.TryParse(tbDesconto.Text, out desconto))
				desconto = 0;

			if (!decimal.TryParse(tbPreco1.Text, out val1))
				val1 = 0;

			if (!decimal.TryParse(tbPreco2.Text, out val2))
				val2 = 0;

			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				maior = (val1 + val2) / 2;
			}
			else
			{
				maior = (val1 > val2 ? val1 : val2);
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

			Preco = total;
			tbPreco.Text = total.ToString("##,###,##0.00");
		}

		private void tbDesconto_Enter(object sender, EventArgs e)
		{
			tbDesconto.SelectAll();
		}

		private void tbDesconto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btConfirmar.Focus();
		}

		private void tbDesconto_Leave(object sender, EventArgs e)
		{
			SomaTotal();
		}

		private void tbObservacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void tbQuantidade_Enter(object sender, EventArgs e)
		{
			tbQuantidade.SelectAll();
		}

		private void tbQuantidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				tbDesconto.Focus();
		}

		private void tbQuantidade_Leave(object sender, EventArgs e)
		{
			SomaTotal();
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

		#endregion Methods
	}
}