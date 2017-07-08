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

namespace DSoft_Delivery
{
	public partial class frmPedidoFracao : Form
	{
		#region Fields

		public List<ItemPedido> Itens;
		public int Tabela;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmPedidoFracao(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			List<Produto> produtos = _dsoftBd.ProdutosFracionados();

			if (produtos != null)
			{
				cbProduto1.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto3.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto4.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto5.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto6.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto7.DropDownStyle = ComboBoxStyle.DropDownList;
				cbProduto8.DropDownStyle = ComboBoxStyle.DropDownList;

				foreach (Produto produto in produtos)
				{
					cbProduto1.Items.Add(produto);
					cbProduto2.Items.Add(produto);
					cbProduto3.Items.Add(produto);
					cbProduto4.Items.Add(produto);
					cbProduto5.Items.Add(produto);
					cbProduto6.Items.Add(produto);
					cbProduto7.Items.Add(produto);
					cbProduto8.Items.Add(produto);
				}

				if (Preferencias.ProdutoPorNome)
				{
					foreach (Produto produto in produtos)
					{
						cbProduto1.Items.Add(produto.Nome);
						cbProduto2.Items.Add(produto.Nome);
						cbProduto3.Items.Add(produto.Nome);
						cbProduto4.Items.Add(produto.Nome);
						cbProduto5.Items.Add(produto.Nome);
						cbProduto6.Items.Add(produto.Nome);
						cbProduto7.Items.Add(produto.Nome);
						cbProduto8.Items.Add(produto.Nome);
					}
				}

				cbProduto1.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto2.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto3.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto4.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto5.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto6.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto7.DropDownStyle = ComboBoxStyle.DropDown;
				cbProduto8.DropDownStyle = ComboBoxStyle.DropDown;
			}

			cbProduto1.Focus();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbProduto1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto1.Text != string.Empty)
			{
				tbQuantidade1.Focus();
			}
		}

		private void cbProduto1_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto1, tbValor1);
		}

		private void cbProduto2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto2.Text != string.Empty)
			{
				tbQuantidade2.Focus();
			}
		}

		private void cbProduto2_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto2, tbValor2);
		}

		private void cbProduto3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto3.Text != string.Empty)
			{
				tbQuantidade3.Focus();
			}
		}

		private void cbProduto3_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto3, tbValor3);
		}

		private void cbProduto4_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto4.Text != string.Empty)
			{
				tbQuantidade4.Focus();
			}
		}

		private void cbProduto4_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto4, tbValor4);
		}

		private void cbProduto5_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto5.Text != string.Empty)
			{
				tbQuantidade5.Focus();
			}
		}

		private void cbProduto5_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto5, tbValor5);
		}

		private void cbProduto6_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto6.Text != string.Empty)
			{
				tbQuantidade6.Focus();
			}
		}

		private void cbProduto6_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto6, tbValor6);
		}

		private void cbProduto7_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto7.Text != string.Empty)
			{
				tbQuantidade7.Focus();
			}
		}

		private void cbProduto7_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto7, tbValor7);
		}

		private void cbProduto8_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbProduto8.Text != string.Empty)
			{
				tbQuantidade8.Focus();
			}
		}

		private void cbProduto8_Leave(object sender, EventArgs e)
		{
			LeaveProcess(cbProduto8, tbValor8);
		}

		private void Confirmar()
		{
			if (TotalFracoes() != 8 && TotalFracoes() != 9)
			{
				MessageBox.Show("Quantidade de frações inválida! Deve completar 8 ou 9 frações.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			Itens = new List<ItemPedido>();

			// Criamos o array de produtos
			ItemPedido item = SelectedItem(cbProduto1, tbQuantidade1, tbValor1);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto2, tbQuantidade2, tbValor2);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto3, tbQuantidade3, tbValor3);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto4, tbQuantidade4, tbValor4);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto5, tbQuantidade5, tbValor5);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto6, tbQuantidade6, tbValor6);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto7, tbQuantidade7, tbValor7);

			if (item != null)
			{
				Itens.Add(item);
			}

			item = SelectedItem(cbProduto8, tbQuantidade8, tbValor8);

			if (item != null)
			{
				Itens.Add(item);
			}

			if (RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio)
			{
				decimal valor = 0;

				foreach (ItemPedido i in Itens)
				{
					valor += i.Preco;

					i.Preco = 0;
					i.Secundario = true;
				}

				Itens[0].Preco = valor / Itens.Count;
				Itens[0].Secundario = false;
			}
			else
			{
				// Procuramos o produto principal
				ItemPedido itemPrincipal = null;

				foreach (ItemPedido i in Itens)
				{
					if (itemPrincipal == null)
					{
						itemPrincipal = i;
					}
					else
					{
						if (i.Preco > itemPrincipal.Preco)
						{
							itemPrincipal = i;
						}
					}
				}

				itemPrincipal.Secundario = false;

				foreach (ItemPedido i in Itens)
				{
					if (i.Secundario)
					{
						i.Preco = 0;
					}
				}
			}

			this.DialogResult = DialogResult.OK;

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmPedidoFracao_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void KeyPressProcess(TextBox textBox, Control nextControl)
		{
			int qtd;

			if (textBox.Text == string.Empty)
			{
				MessageBox.Show("Quantidade deve ser especificada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			if (!int.TryParse(textBox.Text, out qtd))
			{
				MessageBox.Show("Fração inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				textBox.SelectAll();

				return;
			}

			qtd = TotalFracoes();

			if (qtd == 8 || qtd == 9)
			{
				btConfirmar.Focus();
			}
			else if (qtd < 8)
			{
				nextControl.Focus();
			}
			else if (qtd > 9)
			{
				MessageBox.Show("Excedeu a quantidade total de frações!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				textBox.SelectAll();

				return;
			}
		}

		private void LeaveProcess(ComboBox comboBox, TextBox textBox)
		{
			if (comboBox.Text != string.Empty)
			{
				if (comboBox.SelectedItem != null || comboBox.Items.Contains(comboBox.Text))
				{
					long codigo;
					string nome;
					string descricao;
					decimal valor;

					if (!long.TryParse(comboBox.Text.Split(" - ".ToCharArray(), 2)[0], out codigo))
					{
						if (!Preferencias.ProdutoPorNome || ((codigo = _dsoftBd.ProdutoCodigo(comboBox.Text)) == 0))
						{
							MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

							comboBox.SelectAll();
							comboBox.Focus();

							return;
						}
					}

					if (!_dsoftBd.CarregarProduto(Tabela, codigo, out nome, out descricao, out valor))
					{
						MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						comboBox.SelectAll();
						comboBox.Focus();

						return;
					}

					textBox.Text = valor.ToString("###,###,##0.00");
				}
				else
				{
					MessageBox.Show("Produto não disponível!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					comboBox.SelectAll();
					comboBox.Focus();

					return;
				}
			}
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

		private ItemPedido SelectedItem(ComboBox comboBox, TextBox tbQuantidade, TextBox tbValor)
		{
			long produto;

			if (comboBox.SelectedItem == null)
			{
				return null;
			}

			if ((comboBox.Text != string.Empty && long.TryParse(comboBox.Text.Split(" - ".ToCharArray(), 2)[0], out produto))
				|| (Preferencias.ProdutoPorNome && (produto = _dsoftBd.ProdutoCodigo(comboBox.Text)) > 0))
			{
				int fracao;

				if (tbQuantidade.Text.Length == 0 || !int.TryParse(tbQuantidade.Text, out fracao) || fracao < 1)
				{
					MessageBox.Show("Quantidade inválida!");
					tbQuantidade.SelectAll();
					tbQuantidade.Focus();
					return null;
				}

				ItemPedido item = new ItemPedido();
				item.Produto = produto;
				item.ProdutoNome = _dsoftBd.ProdutoNome(produto);
				item.Quantidade = (float)fracao / 10;
				item.Preco = Convert.ToDecimal(tbValor.Text);
				item.Situacao = 'A';
				item.Secundario = true;

				return item;
			}

			return null;
		}

		private void tbQuantidade1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade1, cbProduto2);
			}
		}

		private void tbQuantidade2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade2, cbProduto3);
			}
		}

		private void tbQuantidade3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade3, cbProduto4);
			}
		}

		private void tbQuantidade4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade4, cbProduto5);
			}
		}

		private void tbQuantidade5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade5, cbProduto6);
			}
		}

		private void tbQuantidade6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade6, cbProduto7);
			}
		}

		private void tbQuantidade7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade7, cbProduto8);
			}
		}

		private void tbQuantidade8_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				KeyPressProcess(tbQuantidade8, btConfirmar);
			}
		}

		private int TotalFracoes()
		{
			int qtd;
			int total = 0;

			if (int.TryParse(tbQuantidade1.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade2.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade3.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade4.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade5.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade6.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade7.Text, out qtd))
				total += qtd;

			if (int.TryParse(tbQuantidade8.Text, out qtd))
				total += qtd;

			tbQuantidadeTotal.Text = total.ToString();

			return total;
		}

		#endregion Methods
	}
}