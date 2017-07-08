using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftCore;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmCompras : Form
	{
		#region Fields

		private static Compra CompraAtual;

		private decimal PrecoAtual = 0;
		private int TabelaPrecos = 0;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCompras(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarCompras(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

				dataGridView1.Columns["codigo"].Width = 40;
				dataGridView1.Columns["data"].Width = 68;
				dataGridView1.Columns["hora"].Width = 68;
				dataGridView1.Columns["fornecedor"].Width = 68;
				dataGridView1.Columns["nome"].Width = 172;
				dataGridView1.Columns["itens"].Width = 40;
				dataGridView1.Columns["valor"].Width = 60;
				dataGridView1.Columns["situacao"].Width = 60;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
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

					case "P":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
					//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void AtualizarLista()
		{
			string linha;

			try
			{
				listBox1.Items.Clear();

				if (CompraAtual.Itens > 0)
				{
					for (int i = 0; i < CompraAtual.Itens; i++)
					{
						linha = CompraAtual.Item[i].Numero.ToString("000") + "\t";
						linha += CompraAtual.Item[i].Produto.Codigo.ToString("000000") + " - " + Util.Formata(CompraAtual.Item[i].Produto.Nome, 12) + "\t";
						linha += CompraAtual.Item[i].Unitario.ToString("0.00") + "\t";
						linha += CompraAtual.Item[i].Quantidade.ToString("00.0") + "\t";
						linha += CompraAtual.Item[i].Total.ToString("0.00");

						listBox1.Items.Add(linha);
					}

					listBox1.SetSelected(listBox1.Items.Count - 1, true);
				}

				textBox6.Text = CompraAtual.Valor.ToString("0.00");
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex >= 0)
			{
				ExcluirItem(listBox1.SelectedIndex);
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			LimparLista();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ConfirmarItem();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Entregar();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarCompra(int codigo)
		{
			try
			{
				CompraAtual = new Compra();

				CompraAtual.Codigo = codigo;

				if (!_dsoftBd.CarregarCompra(CompraAtual))
				{
					MessageBox.Show("Não foi possivel carregar os dados!" + Environment.NewLine + "Entre em contato com o suporte.", this.Text);

					return;
				}

				textBox1.Text = CompraAtual.Fornecedor.ToString();
				lbFornecedor.Text = _dsoftBd.FornecedorNome(CompraAtual.Fornecedor);

				dateTimePicker1.Value = CompraAtual.Data;

				//groupBox1.Enabled = true;

				AtualizarLista();

				switch (CompraAtual.Situacao)
				{
				case 'A':
					button4.Text = "&Confirmar - F2";
					button5.Enabled = true;
					button6.Enabled = true;
					button7.Enabled = true;

					groupBox1.Enabled = true;

					break;

				case 'C':
					button4.Enabled = false;

					button7.Enabled = true;
					button7.Text = "&Reativar - F4";

					break;

				case 'E':
					button4.Enabled = false;

					button5.Enabled = true;
					button5.Text = "&Retornar - F5";

					button6.Enabled = true;

					//groupBox1.Enabled = false;

					break;

				case 'N':
					button4.Enabled = false;

					button5.Enabled = true;

					button6.Enabled = true;
					button6.Text = "&Desfazer - F6";

					break;

				case 'P':
					button4.Enabled = false;

					button5.Enabled = true;
					button5.Text = "&Retornar - F5";

					button6.Enabled = true;
					button6.Text = "&Desfazer - F6";

					break;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void Confirmar()
		{
			try
			{
				if (!button4.Enabled)
				{
					return;
				}

				if (button4.Text == "&Nova - F2")
				{
					button4.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					textBox1.Focus();

					CompraAtual = new Compra();

					return;
				}

				if (CompraAtual.Itens < 1)
				{
					return;
				}

				if (!int.TryParse(textBox1.Text, out CompraAtual.Fornecedor))
				{
					MessageBox.Show("Campo 'código do fornecedor' inválido!" + Environment.NewLine + "Campo deve ser numérico.", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				if (_dsoftBd.FornecedorNome(CompraAtual.Fornecedor) == string.Empty)
				{
					MessageBox.Show("Fornecedor não encontrado!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				if (CompraAtual.Codigo == 0)
				{
					if (_dsoftBd.NovaCompra(CompraAtual, _usuario.Autorizado))
					{
						LimparDados();

						Atualizar();
					}
				}
				else
				{
					if (_dsoftBd.AlterarCompra(CompraAtual, _usuario.Autorizado))
					{
						LimparDados();

						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void ConfirmarItem()
		{
			string linha;

			try
			{
				CompraItem item = new CompraItem();
				Produto produto = cbProduto.SelectedItem as Produto;

				if (produto == null)
				{
					MessageBox.Show("Produto inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					cbProduto.SelectAll();
					cbProduto.Focus();
					return;
				}

				item.Produto = produto;

				if (!decimal.TryParse(textBox3.Text, out item.Unitario))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					textBox3.SelectAll();

					textBox3.Focus();

					return;
				}

				// Atualizamos a tabela de preços
				if (item.Unitario != PrecoAtual)
				{
					if (MessageBox.Show("Deseja atualizar a tabela de preços?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{
						_dsoftBd.AlterarPreco(item.Produto.Codigo, TabelaPrecos, item.Unitario, item.Unitario, 0, _usuario.Autorizado);
					}
				}

				if (!float.TryParse(textBox4.Text, out item.Quantidade))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					textBox4.SelectAll();

					textBox4.Focus();

					return;
				}

				item.Total = item.Unitario * (decimal)item.Quantidade;

				if (CompraAtual.NovoItem(item) > 0)
				{
					LimparCampos();

					//AtualizarLista();

					linha = string.Format("{0} {1,-21} {2} {3} {4}", item.Numero.ToString("000"), item.Produto.ToString(), item.Unitario.ToString("##0.00"), item.Quantidade.ToString("00.0"), item.Total.ToString("##0.00"));

					listBox1.Items.Add(linha);

					listBox1.SetSelected(listBox1.Items.Count - 1, true);

					textBox6.Text = CompraAtual.Valor.ToString("0.00");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow.Index >= 0)
			{
				CarregarCompra(int.Parse(dataGridView1.CurrentRow.Cells["codigo"].Value.ToString()));
			}
		}

		private void Entregar()
		{
			if (!button5.Enabled)
			{
				return;
			}

			if (button5.Text == "&Entregar - F5")
			{
				if (_dsoftBd.EntregarCompra(CompraAtual.Codigo, _usuario.Autorizado))
				{
					//Sync
					if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
					{
						Sync.EntradaEstoque(ref CompraAtual, _usuario.Autorizado);
					}

					LimparDados();

					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.RetornarCompra(CompraAtual.Codigo))
				{
					//Sync
					if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
					{
						Sync.CancelaEntradaEstoque(CompraAtual, _usuario.Autorizado);
					}

					LimparDados();

					Atualizar();
				}
			}
		}

		private void ExcluirItem(int item)
		{
			CompraAtual.ExcluirItem(item);

			AtualizarLista();
		}

		private void frmCompras_Load(object sender, EventArgs e)
		{
			string[] tabelas;

			if (_dsoftBd.CarregarTabelas(out tabelas))
			{
				for (int i = 0; i < tabelas.Length; i++)
				{
					cbTabela.Items.Add(tabelas[i]);
				}

				cbTabela.Text = cbTabela.Items[1].ToString();
			}

			Atualizar();

			CarregarProdutos();

			LimparDados();
		}

		private void CarregarProdutos()
		{
			List<Produto> produtos = _dsoftBd.CarregarProdutos(true);

			cbProduto.Items.Clear();

			if (produtos != null)
			{
				cbProduto.Items.AddRange(produtos.ToArray());
			}
		}

		private void LimparCampos()
		{
			cbProduto.SelectedItem = null;
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();

			cbProduto.Focus();
		}

		private void LimparDados()
		{
			button4.Text = "&Nova - F2";
			button5.Text = "&Entregar - F5";
			button6.Text = "&Pagar - F6";
			button7.Text = "&Cancelar - F4";

			button4.Enabled = true;
			button5.Enabled = false;
			button6.Enabled = false;
			button7.Enabled = false;

			textBox1.Clear();
			lbFornecedor.Text = string.Empty;

			dateTimePicker1.Value = DateTime.Now;

			cbProduto.SelectedItem = null;

			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			textBox6.Clear();

			listBox1.Items.Clear();

			groupBox1.Enabled = false;

			CompraAtual = null;
		}

		private void LimparLista()
		{
			CompraAtual.LimparItens();

			AtualizarLista();

			LimparCampos();
		}

		private void novaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Pagar()
		{
			if (!button6.Enabled)
			{
				return;
			}

			if (button6.Text == "&Pagar - F6")
			{
				if (_dsoftBd.PagarCompra(CompraAtual.Codigo, _usuario.Autorizado, Caixa.Numero))
				{
					LimparDados();

					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.DesfazerCompra(CompraAtual.Codigo, Caixa.Numero))
				{
					LimparDados();

					Atualizar();
				}
			}
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && textBox1.Text.Length > 0)
			{
				cbProduto.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int numero;

			if (textBox1.Text.Length > 0)
			{
				if (!int.TryParse(textBox1.Text, out numero))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				if ((lbFornecedor.Text = _dsoftBd.FornecedorNome(numero)) == string.Empty)
				{
					MessageBox.Show("Fornecedor não encontrado!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();
				}
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && textBox3.Text.Length > 0)
			{
				textBox4.Focus();
			}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			double numero;
			float quantidade;

			if (textBox3.Text.Length > 0)
			{
				if (!double.TryParse(textBox3.Text, out numero))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					textBox3.SelectAll();

					textBox3.Focus();

					return;
				}

				textBox3.Text = numero.ToString("0.00");

				if (textBox4.Text.Length > 0)
				{
					quantidade = float.Parse(textBox4.Text);

					numero = (numero * (double)quantidade);

					textBox5.Text = numero.ToString("0.00");
				}
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && textBox4.Text.Length > 0)
			{
				button3.Focus();
			}
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			float quantidade;
			double valor;

			if (textBox4.Text.Length > 0)
			{
				if (!float.TryParse(textBox4.Text, out quantidade))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					textBox4.SelectAll();

					textBox4.Focus();

					return;
				}

				textBox4.Text = quantidade.ToString();

				if (textBox3.Text.Length > 0)
				{
					valor = double.Parse(textBox3.Text);

					valor = (valor * (double)quantidade);

					textBox5.Text = valor.ToString("0.00");
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Entregar();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void cbProduto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbProduto.SelectedItem != null)
				{
					int tabela;
					Produto produto = cbProduto.SelectedItem as Produto;

					if (produto != null)
					{
						if (int.TryParse(cbTabela.Text.Split(" - ".ToCharArray(), 2)[0], out tabela))
						{
							string nome, descricao;
							decimal preco;

							_dsoftBd.CarregarProduto(tabela, produto.Codigo, out nome, out descricao, out preco);

							PrecoAtual = preco;
							TabelaPrecos = tabela;

							textBox3.Text = preco.ToString("##,###,##0.00");
						}

						textBox3.Focus();
					}
				}
				else if (CompraAtual.Itens > 0)
				{
					button4.Focus();
				}
			}
		}

		#endregion Methods
	}
}