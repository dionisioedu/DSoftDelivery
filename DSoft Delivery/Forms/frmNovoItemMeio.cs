﻿using System;
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
using System.Threading;

namespace DSoft_Delivery.Forms
{
	public partial class frmNovoItemMeio : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private TabelaDePrecos _tabela;
		private long _produtoHerdado;

		private List<Produto> _produtos;
		private List<string> _produtosNome;
		private List<CheckedListBox> _listasAdicionais;
		private Dictionary<Produto, decimal> _precos;

		private bool _editando = false;
		private ItemPedido _original1;
		private ItemPedido _original2;

		public List<ItemPedido> Itens;
		public decimal Total;

		public frmNovoItemMeio(Bd bd, Usuario usuario, TabelaDePrecos tabela, List<Produto> produtos, Dictionary<Produto, decimal> precos, long produto = 0)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_tabela = tabela;
			_produtos = produtos;
			_precos = precos;

			_produtoHerdado = produto;

			Itens = new List<ItemPedido>(2);
			Itens.Add(new ItemPedido());
			Itens.Add(new ItemPedido());
		}

		public frmNovoItemMeio(Bd bd, Usuario usuario, TabelaDePrecos tabela, List<ItemPedido> itens)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_tabela = tabela;

			this.Text = "Editar item 2/2";

			cbProduto1.Text = string.Format("{0} - {1}", itens[0].Produto, itens[0].ProdutoNome);
			cbProduto2.Text = string.Format("{0} - {1}", itens[1].Produto, itens[1].ProdutoNome);

			cbProduto1.Enabled = false;
			cbProduto2.Enabled = false;

			_editando = true;

			Itens = new List<ItemPedido>(2);

			Itens.Add(itens[0]);
			_original1 = (ItemPedido)itens[0].Clone();
			Itens.Add(itens[1]);
			_original2 = (ItemPedido)itens[1].Clone();
		}

		private void frmNovoItemMeio_Load(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				lbModoCalculo.Text = "Preço médio";
			}
			else
			{
				lbModoCalculo.Text = "Preço da mais cara";
			}

			if (!_editando)
			{
				CarregarProdutos();

				if (_produtoHerdado > 0)
				{
					cbProduto1.SelectedItem = _produtos.First(p => p.Codigo == _produtoHerdado);
					ComboboxPressed(cbProduto1, new EventArgs(), 0);
					cbProduto2.Focus();
				}
			}

			_listasAdicionais = new List<CheckedListBox>();
			_listasAdicionais.Add(clItensAdicionais1);
			_listasAdicionais.Add(clItensAdicionais2);

			if (!RegrasDeNegocio.Instance.ItensAdicionaisPorProduto && !RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
			{
				CarregarItensAdicionais();
			}

			if (RegrasDeNegocio.Instance.PrecosEmAberto)
			{
				tbPreco.ReadOnly = false;
			}

			if (_editando)
			{
				Itens[0].Preco = (decimal)_dsoftBd.ProdutoPreco(Itens[0].Produto, _tabela.Codigo);
				Itens[1].Preco = (decimal)_dsoftBd.ProdutoPreco(Itens[1].Produto, _tabela.Codigo);

				tbPreco1.Text = Itens[0].Preco.ToString("##,###,##0.00");
				tbPreco2.Text = Itens[1].Preco.ToString("##,###,##0.00");

				tbObservacao1.Text = Itens[0].Observacao;
				tbObservacao2.Text = Itens[1].Observacao;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					List<ItemAdicional> adicionais = _dsoftBd.CarregarItensAdicionais(Itens[0].Produto);

					clItensAdicionais1.Items.Clear();
					clItensAdicionais1.Items.AddRange(adicionais.ToArray());

					adicionais = _dsoftBd.CarregarItensAdicionais(Itens[1].Produto);

					clItensAdicionais2.Items.Clear();
					clItensAdicionais2.Items.AddRange(adicionais.ToArray());
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					List<ItemAdicional> adicionais = _dsoftBd.CarregarItensAdicionais(_dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(Itens[0].Produto)));

					clItensAdicionais1.Items.Clear();
					clItensAdicionais1.Items.AddRange(adicionais.ToArray());

					clItensAdicionais2.Items.Clear();
					clItensAdicionais2.Items.AddRange(adicionais.ToArray());
				}

				MarcarItensSelecionados();

				CalculaTotal();
			}
		}

		private void MarcarItensSelecionados()
		{
			foreach (ItemAdicional itemAdicional in Itens[0].ItensAdicionais)
			{
				for (int i = 0; i < clItensAdicionais1.Items.Count; i++)
				{
					ItemAdicional adc = clItensAdicionais1.Items[i] as ItemAdicional;

					if (adc.Equals(itemAdicional))
					{
						clItensAdicionais1.SetItemChecked(i, true);

						break;
					}
				}
			}

			foreach (ItemAdicional itemAdicional in Itens[1].ItensAdicionais)
			{
				for (int i = 0; i < clItensAdicionais2.Items.Count; i++)
				{
					ItemAdicional adc = clItensAdicionais2.Items[i] as ItemAdicional;

					if (adc.Equals(itemAdicional))
					{
						clItensAdicionais2.SetItemChecked(i, true);

						break;
					}
				}
			}
		}

		private void CarregarProdutos()
		{
			if (_produtos == null)
			{
				_produtos = _dsoftBd.ProdutosMeioAMeio();
			}

			cbProduto1.Items.AddRange(_produtos.ToArray());
			cbProduto2.Items.AddRange(_produtos.ToArray());

			_produtosNome = new List<string>();

			foreach (Produto p in _produtos)
			{
				_produtosNome.Add(p.Nome);
			}
		}

		private void CarregarItensAdicionais()
		{
			List<ItemAdicional> itensAdicionais = _dsoftBd.CarregarItensAdicionais();

			foreach (CheckedListBox l in _listasAdicionais)
			{
				l.Items.Clear();
				l.Items.AddRange(itensAdicionais.ToArray());
			}
		}

		private void ComboboxTextChanged(object sender, KeyEventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;

			if (comboBox != null)
			{
				if (comboBox.Text.Length > 0)
				{
					string text = comboBox.Text.ToUpper();
					var search = from p in _produtos where p.ToString().Contains(text) select p;

					if (search.Count() > 0)
					{
						comboBox.Items.Clear();
						comboBox.Items.AddRange(search.ToArray());

						comboBox.DroppedDown = true;

						var suggestion = from s in _produtosNome where s.StartsWith(text) select s;

						if (suggestion.Count() > 0)
						{
							//comboBox.Text = suggestion.ToArray()[0];
							//comboBox.SelectionStart = text.Length;
							//comboBox.SelectionLength = comboBox.Text.Length - text.Length;

							comboBox.Text = text;
							comboBox.SelectionStart = text.Length;
							comboBox.SelectionLength = 0;
						}
						else
						{
							comboBox.Text = text;
							comboBox.SelectionStart = text.Length;
							comboBox.SelectionLength = 0;
						}
					}
					else
					{
						comboBox.DroppedDown = false;

						comboBox.Items.Clear();
						comboBox.SelectionStart = text.Length;
						comboBox.SelectionLength = 0;
					}
				}
				else
				{
					comboBox.DroppedDown = false;

					comboBox.Items.Clear();

					if (_produtos != null)
					{
						comboBox.Items.AddRange(_produtos.ToArray());
					}
				}
			}
		}

		private void ComboboxPressed(object sender, EventArgs e, int indice)
		{
			string nome;
			string descricao;
			decimal preco;
			ComboBox comboBox = sender as ComboBox;
			Control proximo;
			Produto produto = null;

			if (comboBox != null)
			{
				if (comboBox.SelectedItem != null)
				{
					produto = comboBox.SelectedItem as Produto;
				}
				else
				{
					if (comboBox.Items.Count > 0)
					{
						produto = comboBox.Items[0] as Produto;
					}
				}

				if (produto == null)
				{
					return;
				}

				Itens[indice].Produto = produto.Codigo;

				if (!_dsoftBd.CarregarProduto(_tabela.Codigo, Itens[indice].Produto, out nome, out descricao, out preco))
				{
					MessageBox.Show("Não foi possível carregar os dados do produto!", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Itens[indice].Preco = preco;
				Itens[indice].Unitario = preco;
				Itens[indice].ProdutoNome = nome;
				Itens[indice].Quantidade = (float)0.5;

				Produto prod = _dsoftBd.CarregarProduto(Itens[indice].Produto);

				comboBox.Text = prod.ToString();

				CheckedListBox listBox;

				switch (indice)
				{
					case 0:
						listBox = clItensAdicionais1;
						tbPreco1.Text = preco.ToString("##,###,##0.00");
						proximo = cbProduto2;
						break;

					case 1:
					default:
						listBox = clItensAdicionais2;
						tbPreco2.Text = preco.ToString("##,###,##0.00");
						proximo = btConfirmar;
						break;
				}

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					List<ItemAdicional> itens_adicionais = _dsoftBd.CarregarItensAdicionais(Itens[indice].Produto);

					listBox.Items.Clear();
					listBox.Items.AddRange(itens_adicionais.ToArray());
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					List<ItemAdicional> itens_adicionais = _dsoftBd.CarregarItensAdicionais(_dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(Itens[indice].Produto)));

					if (itens_adicionais != null)
					{
						listBox.Items.Clear();
						listBox.Items.AddRange(itens_adicionais.ToArray());
					}
				}

				listBox.Enabled = _dsoftBd.ProdutoPermiteItensAdicionais(Itens[indice].Produto);

				CalculaTotal();

				proximo.Focus();
			}
		}

		private void CalculaTotal()
		{
			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				decimal adicionais = 0;
				Total = 0;

				foreach (ItemPedido i in Itens)
				{
					if (i.Preco > 0)
					{
						Total += i.Preco / 2;
					}

					foreach (ItemAdicional a in i.ItensAdicionais)
					{
						adicionais += a.Valor;
					}
				}

				Total += adicionais;

				tbPreco.Text = Total.ToString("##,###,##0.00");
			}
			else
			{
				decimal adicionais = 0;
				Total = 0;

				foreach (ItemPedido i in Itens)
				{
					if (i.Preco > Total)
					{
						Total = i.Preco;
					}

					foreach (ItemAdicional a in i.ItensAdicionais)
					{
						adicionais += a.Valor;
					}
				}

				Total += adicionais;

				tbPreco.Text = Total.ToString("##,###,##0.00");
			}
		}

		private void Confirmar()
		{
			if (_editando)
			{
				if (RegrasDeNegocio.Instance.PrecosEmAberto)
				{
					decimal preco;
					decimal.TryParse(tbPreco.Text, out preco);

					if (preco > 0)
					{
						Itens[0].Preco = preco;
					}
					else
					{
						tbPreco.SelectAll();
						tbPreco.Focus();
						return;
					}
				}
				else
				{
					Itens[0].Preco = Total;
				}

				Itens[0].Unitario = 0;
				Itens[1].Preco = 0;
				Itens[1].Unitario = 0;

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			else
			{
				if (cbProduto1.SelectedItem == null)
				{
					cbProduto1.Focus();
					return;
				}

				if (cbProduto2.SelectedItem == null)
				{
					cbProduto2.Focus();
					return;
				}

				Itens[0].Observacao = tbObservacao1.Text;
				Itens[0].Secundario = false;
				Itens[0].Preco = Total;
				Itens[0].Unitario = 0;
				Itens[1].Observacao = tbObservacao2.Text;
				Itens[1].Secundario = true;
				Itens[1].Preco = 0;
				Itens[1].Unitario = 0;

				if (RegrasDeNegocio.Instance.PrecosEmAberto)
				{
					decimal preco;
					decimal.TryParse(tbPreco.Text, out preco);

					if (preco > 0)
					{
						Itens[0].Preco = preco;
					}
					else
					{
						tbPreco.SelectAll();
						tbPreco.Focus();
						return;
					}
				}

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		private void Sair()
		{
			if (_editando)
			{
				Itens[0] = _original1;
				Itens[1] = _original2;
			}

			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
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

		private void cbProduto_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
			{
				ComboboxTextChanged(sender, e);
				e.Handled = true;
			}
		}

		private void cbProduto_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLower(e.KeyChar))
			{
				e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}

		private void cbProduto1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				cbProduto1.SelectedItem = null;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				ComboboxPressed(sender, e, 0);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void cbProduto1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (cbProduto1.SelectedItem != null)
			//{
			//    ComboboxPressed(sender, e, 0);
			//}
		}

		private void cbProduto2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				cbProduto2.SelectedItem = null;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				ComboboxPressed(sender, e, 1);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void cbProduto2_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (cbProduto2.SelectedItem != null)
			//{
			//    ComboboxPressed(sender, e, 1);
			//}
		}

		private void clItensAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ItemPedido itemPedido;

			if (sender == clItensAdicionais1)
			{
				itemPedido = Itens[0];
			}
			else if (sender == clItensAdicionais2)
			{
				itemPedido = Itens[1];
			}
			else
			{
				itemPedido = Itens[3];
			}

			ItemAdicional itemAdicional = ((CheckedListBox)sender).SelectedItem as ItemAdicional;

			if (itemAdicional != null)
			{
				if (e.NewValue == CheckState.Checked)
				{
					itemPedido.ItensAdicionais.Add(itemAdicional);
				}
				else if (e.NewValue == CheckState.Unchecked)
				{
					itemPedido.ItensAdicionais.Remove(itemAdicional);
				}
			}

			CalculaTotal();
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
					_dsoftBd.AdicionarItemAdicional(item, Itens[0].Produto);
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					ProdutoTipo tipo = _dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(Itens[0].Produto));

					if (tipo != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, tipo);
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clItensAdicionais1.Items.Add(item);
				clItensAdicionais1.SetItemChecked(clItensAdicionais1.Items.Count - 1, true);

				clItensAdicionais1.ClearSelected();
				clItensAdicionais1.SetSelected(clItensAdicionais1.Items.Count - 1, true);

				ItemCheckEventArgs itemCheckEvent = new ItemCheckEventArgs(clItensAdicionais1.Items.Count - 1, CheckState.Checked, CheckState.Indeterminate);

				clItensAdicionais_ItemCheck(clItensAdicionais1, itemCheckEvent);
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
					_dsoftBd.AdicionarItemAdicional(item, Itens[1].Produto);
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					ProdutoTipo tipo = _dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(Itens[1].Produto));

					if (tipo != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, tipo);
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clItensAdicionais2.Items.Add(item);
				clItensAdicionais2.SetItemChecked(clItensAdicionais2.Items.Count - 1, true);

				clItensAdicionais2.ClearSelected();
				clItensAdicionais2.SetSelected(clItensAdicionais2.Items.Count - 1, true);

				ItemCheckEventArgs itemCheckEvent = new ItemCheckEventArgs(clItensAdicionais2.Items.Count - 1, CheckState.Checked, CheckState.Indeterminate);

				clItensAdicionais_ItemCheck(clItensAdicionais2, itemCheckEvent);
			}
		}

		private void frmNovoItemMeio_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void tbObservacao1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
			else if (e.KeyCode == Keys.Right)
			{
				clItensAdicionais1.Focus();
			}
		}

		private void clItensAdicionais1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void tbObservacao2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void clItensAdicionais2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Sair();
			}
		}

		private void tbObservacao1_TextChanged(object sender, EventArgs e)
		{
			if (_editando)
			{
				Itens[0].Observacao = tbObservacao1.Text;
			}
		}

		private void tbObservacao2_TextChanged(object sender, EventArgs e)
		{
			if (_editando)
			{
				Itens[1].Observacao = tbObservacao2.Text;
			}
		}

		private void tbPreco_KeyDown(object sender, KeyEventArgs e)
		{
			if (RegrasDeNegocio.Instance.PrecosEmAberto)
			{
				if (e.KeyCode == Keys.Enter)
				{
					decimal preco;
					decimal.TryParse(tbPreco.Text, out preco);

					if (preco > 0)
					{
						btConfirmar.Focus();
					}
					else
					{
						tbPreco.SelectAll();
					}
				}
			}
		}
	}
}
