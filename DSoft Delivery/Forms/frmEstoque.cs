using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class frmEstoque : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmEstoque(Bd bd, Usuario usuario)
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

				_dsoftBd.CarregarEstoque(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["produto"].Width = 60;
				dataGridView1.Columns["nome"].Width = 130;
				dataGridView1.Columns["minimo"].Width = 60;
				dataGridView1.Columns["maximo"].Width = 60;
				dataGridView1.Columns["quantidade"].Width = 60;
				dataGridView1.Columns["fornecedor"].Visible = false;

				Pintar();

				CarregarLocais();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void Atualizar2()
		{
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				if (r.Cells["produto"].Value.ToString() == tbCodigo.Text)
				{
					r.Cells["minimo"].Value = tbMinimo.Text;
					r.Cells["maximo"].Value = tbMaximo.Text;

					if (double.Parse(r.Cells["quantidade"].Value.ToString()) == 0)
					{
						r.DefaultCellStyle.BackColor = Color.Red;
						r.DefaultCellStyle.ForeColor = Color.White;
					}
					else if (double.Parse(r.Cells["quantidade"].Value.ToString()) < double.Parse(r.Cells["minimo"].Value.ToString()))
					{
						r.DefaultCellStyle.BackColor = Color.Yellow;
						r.DefaultCellStyle.ForeColor = Color.Black;
					}
					else if (double.Parse(r.Cells["quantidade"].Value.ToString()) >= double.Parse(r.Cells["maximo"].Value.ToString()))
					{
						r.DefaultCellStyle.BackColor = Color.Green;
						r.DefaultCellStyle.ForeColor = Color.White;
					}
					else
					{
						r.DefaultCellStyle.BackColor = Color.White;
						r.DefaultCellStyle.ForeColor = Color.Black;
					}

					break;
				}
			}
		}

		private void AtualizarFornecedor(long fornecedor)
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarEstoqueFornecedor(fornecedor, ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["produto"].Width = 60;
				dataGridView1.Columns["nome"].Width = 130;
				dataGridView1.Columns["minimo"].Width = 60;
				dataGridView1.Columns["maximo"].Width = 60;
				dataGridView1.Columns["quantidade"].Width = 60;
				dataGridView1.Columns["fornecedor"].Visible = false;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					if (int.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString()) == 0)
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
					else if (int.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString())
						< int.Parse(dataGridView1.Rows[i].Cells["minimo"].Value.ToString()))
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
					}
					else if (int.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString())
						>= int.Parse(dataGridView1.Rows[i].Cells["maximo"].Value.ToString()))
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
				}

				CarregarLocais();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void btMover_Click(object sender, EventArgs e)
		{
			Mover();
		}

		private void btPesquisar_Click(object sender, EventArgs e)
		{
			if (cbFornecedor.Text.Length > 0)
			{
				AtualizarFornecedor(long.Parse(cbFornecedor.Text.Split(" - ".ToCharArray(), 2)[0]));
			}
			else
			{
				Atualizar();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int produto)
		{
			try
			{
				ProdutoEstoque estoque = new ProdutoEstoque();

				estoque.Codigo = produto;

				if (!_dsoftBd.CarregarEstoqueDados(estoque))
				{
					MessageBox.Show("Não foi possivel carregar os dados." + Environment.NewLine + "Entre em contato com o suporte.", this.Text);

					return;
				}

				tbCodigo.Text = estoque.Codigo.ToString();
				tbNome.Text = estoque.Nome;
				tbMinimo.Text = estoque.Minimo.ToString();
				tbMaximo.Text = estoque.Maximo.ToString();
				tbQuantidade.Text = estoque.Quantidade.ToString();

				if (estoque.Fornecedor > 0)
					cbFornecedor.Text = estoque.Fornecedor.ToString() + " - " + _dsoftBd.FornecedorNome(estoque.Fornecedor);
				else
					cbFornecedor.SelectedItem = null;

				tbMinimo.Focus();

				udQuantidade.Maximum = (decimal)estoque.Quantidade;
				udQuantidade.Value = (decimal)estoque.Quantidade;

				CarregarLocais();
				CarregarLocais(produto);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void CarregarFornecedores()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarFornecedores(ds);

			cbFornecedor.Items.Clear();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				cbFornecedor.Items.Add(r.ItemArray[0].ToString() + " - " + r.ItemArray[1].ToString());
			}
		}

		private void CarregarLocais()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarLocais(ds);

			cbDe.Items.Clear();
			cbPara.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbDe.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				cbPara.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
			}
		}

		private void CarregarLocais(int produto)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEstoqueLocais(produto, ds);

			dataGridView2.DataSource = ds.Tables[0];

			dataGridView2.Columns["local"].HeaderText = "Local";
			dataGridView2.Columns["local"].Width = 60;
			dataGridView2.Columns["nome"].HeaderText = "Nome";
			dataGridView2.Columns["nome"].Width = 150;
			dataGridView2.Columns["quantidade"].HeaderText = "Quantidade";
			dataGridView2.Columns["quantidade"].Width = 80;
		}

		private void cbFornecedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
				cbFornecedor.SelectedItem = null;
		}

		private void Confirmar()
		{
			try
			{
				ProdutoEstoque estoque = new ProdutoEstoque();

				if (tbCodigo.Text.Length == 0)
				{
					return;
				}

				if (!long.TryParse(tbCodigo.Text, out estoque.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if (!int.TryParse(tbMinimo.Text, out estoque.Minimo))
				{
					MessageBox.Show("Campo 'mínimo' deve ser numérico!", this.Text);

					tbMinimo.SelectAll();

					tbMinimo.Focus();

					return;
				}

				if (!int.TryParse(tbMaximo.Text, out estoque.Maximo))
				{
					MessageBox.Show("Campo 'máximo' deve ser numérico!", this.Text);

					tbMaximo.SelectAll();

					tbMaximo.Focus();

					return;
				}

				if (!_dsoftBd.AlterarEstoque(estoque))
				{
					MessageBox.Show("Não foi possivel alterar o estoque." + Environment.NewLine + "Entre em contato com o suporte", this.Text);

					return;
				}

				Atualizar2();

				tbCodigo.SelectAll();

				tbCodigo.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(int.Parse(dataGridView1.CurrentRow.Cells["produto"].Value.ToString()));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text);
			}
		}

		private void dataGridView1_Enter(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				if (dataGridView1.SelectedRows.Count > 0)
				{
					dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Selected = true;
				}
			}
		}

		private void dataGridView1_Sorted(object sender, EventArgs e)
		{
			Pintar();
		}

		private void ExportarEstoque()
		{
			try
			{
				string arquivo = /*Matriz.Pasta2() + */"\\estoque_" + Filial.Instance().Codigo.ToString("000") + ".xml";

				DataSet ds = new DataSet();

				_dsoftBd.CarregarEstoque(ds);

				ds.Tables[0].Columns.Remove("minimo");
				ds.Tables[0].Columns.Remove("maximo");

				ds.DataSetName = "estoque_" + Filial.Instance().Codigo.ToString("000");
				ds.Tables[0].TableName = "estoque";

				ds.Tables[0].WriteXml(arquivo);

				MessageBox.Show("Arquivo gerado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao criar arquivo de exportação." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Filtrar(string filtro)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEstoque(ds, filtro);

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["produto"].Width = 60;
			dataGridView1.Columns["nome"].Width = 130;
			dataGridView1.Columns["minimo"].Width = 60;
			dataGridView1.Columns["maximo"].Width = 60;
			dataGridView1.Columns["quantidade"].Width = 60;
			dataGridView1.Columns["fornecedor"].Visible = false;

			Pintar();
		}

		private void frmEstoque_Load(object sender, EventArgs e)
		{
			CarregarFornecedores();

			Atualizar();
		}

		private void listaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.frmFiltroEstoque form = new Forms.frmFiltroEstoque();

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				DataSet ds;

				if (form.SomenteEstoqueCritico())
				{
					if (form.OrdenadoPorCodigo())
					{
						ds = _dsoftBd.CarregarEstoqueCritico();
					}
					else
					{
						ds = _dsoftBd.CarregarEstoqueCritico("nome");
					}
				}
				else
				{
					if (form.OrdenadoPorCodigo())
					{
						ds = _dsoftBd.CarregarEstoque();
					}
					else
					{
						ds = _dsoftBd.CarregarEstoque("nome");
					}
				}

				RelatorioHtml relatorio = new RelatorioHtml();
				relatorio.Titulo = "Estoque";
				relatorio.Arquivo = "Estoque";
				relatorio.Descricao = "Listagem da situação atual do estoque.";
				relatorio.Gerar(ds);
			}
		}

		private void Mover()
		{
			int produto;
			int origem = 0;
			int destino;

			if (udQuantidade.Value == 0)
				return;

			if (cbPara.Text == string.Empty)
				return;

			produto = int.Parse(tbCodigo.Text);

			if (cbDe.Text.Length > 0 && !int.TryParse(cbDe.Text.Split(" - ".ToCharArray(), 2)[0], out origem))
			{
				MessageBox.Show("Origem inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbDe.SelectAll();
				cbDe.Focus();

				return;
			}

			if (cbPara.Text.Length < 1 || !int.TryParse(cbPara.Text.Split(" - ".ToCharArray(), 2)[0], out destino))
			{
				MessageBox.Show("Destino inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbPara.SelectAll();
				cbPara.Focus();

				return;
			}

			if (_dsoftBd.MoverEstoque(produto, (double)udQuantidade.Value, origem, destino))
			{
				cbDe.Text = string.Empty;
				cbPara.Text = string.Empty;

				CarregarLocais();
				CarregarLocais(produto);
			}
			else
			{
				MessageBox.Show("Operação inválida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void Pintar()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (float.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString()) == 0)
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
				else if (float.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString())
					< int.Parse(dataGridView1.Rows[i].Cells["minimo"].Value.ToString()))
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
				}
				else if (float.Parse(dataGridView1.Rows[i].Cells["quantidade"].Value.ToString())
					>= int.Parse(dataGridView1.Rows[i].Cells["maximo"].Value.ToString()))
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				dataGridView1.Sort(dataGridView1.Columns["produto"], ListSortDirection.Ascending);
			}
			else
			{
				dataGridView1.Sort(dataGridView1.Columns["nome"], ListSortDirection.Ascending);
			}

			tbPesquisa.SelectAll();
			tbPesquisa.Focus();

			Pintar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbFiltro_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				Filtrar(tbFiltro.Text);
			}
		}

		private void tbPesquisa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
				dataGridView1.Focus();
		}

		private void tbPesquisa_TextChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				int match = 0;
				long codigo;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					if (long.TryParse(tbPesquisa.Text, out codigo))
					{
						if (codigo >= long.Parse(dataGridView1.Rows[i].Cells["produto"].Value.ToString()))
						{
							match = i;
						}
						else
						{
							break;
						}
					}
				}

				dataGridView1.FirstDisplayedScrollingRowIndex = match;
				dataGridView1.Rows[match].Selected = true;
			}
			else
			{
				int match = 0;
				int r = 0;

				for (int i = 0; i < tbPesquisa.Text.Length; i++)
				{
					while (r < dataGridView1.Rows.Count)
					{
						if (dataGridView1.Rows[r].Cells["nome"].Value.ToString().Length > i && tbPesquisa.Text[i] == dataGridView1.Rows[r].Cells["nome"].Value.ToString()[i])
						{
							match = r;

							break;
						}

						r++;
					}
				}

				dataGridView1.FirstDisplayedScrollingRowIndex = match;
				dataGridView1.Rows[match].Selected = true;
			}
		}

		private void tbQuantidade_DoubleClick(object sender, EventArgs e)
		{
			if (tbQuantidade.ReadOnly == true)
			{
				tbQuantidade.ReadOnly = false;
				tbQuantidade.SelectAll();
				tbQuantidade.Focus();
			}
		}

		private void tbQuantidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbQuantidade.ReadOnly == false)
			{
				double qtd;

				if (!double.TryParse(tbQuantidade.Text, out qtd))
				{
					MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbQuantidade.SelectAll();
					tbQuantidade.Focus();

					return;
				}

				if (MessageBox.Show("Confirma alteração de estoque?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					_dsoftBd.AtualizarEstoque(long.Parse(tbCodigo.Text), qtd);

					tbQuantidade.ReadOnly = true;

					foreach (DataGridViewRow r in dataGridView1.Rows)
					{
						if (r.Cells["produto"].Value.ToString() == tbCodigo.Text)
						{
							r.Cells["quantidade"].Value = tbQuantidade.Text;

							if (double.Parse(r.Cells["quantidade"].Value.ToString()) == 0)
							{
								r.DefaultCellStyle.BackColor = Color.Red;
								r.DefaultCellStyle.ForeColor = Color.White;
							}
							else if (double.Parse(r.Cells["quantidade"].Value.ToString()) < double.Parse(r.Cells["minimo"].Value.ToString()))
							{
								r.DefaultCellStyle.BackColor = Color.Yellow;
								r.DefaultCellStyle.ForeColor = Color.Black;
							}
							else if (double.Parse(r.Cells["quantidade"].Value.ToString()) >= double.Parse(r.Cells["maximo"].Value.ToString()))
							{
								r.DefaultCellStyle.BackColor = Color.Green;
								r.DefaultCellStyle.ForeColor = Color.White;
							}
							else
							{
								r.DefaultCellStyle.BackColor = Color.White;
								r.DefaultCellStyle.ForeColor = Color.Black;
							}

							break;
						}
					}
				}
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int numero;

			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text.Length > 0)
			{
				if (!int.TryParse(tbCodigo.Text, out numero))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				CarregarDados(numero);
			}
		}

		private void textBox3_Enter(object sender, EventArgs e)
		{
			tbMinimo.SelectAll();
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbMinimo.Text.Length > 0)
			{
				tbMaximo.Focus();
			}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			int numero;

			if (tbMinimo.Text.Length == 0)
			{
				tbMinimo.Text = "0";

				return;
			}

			if (!int.TryParse(tbMinimo.Text, out numero))
			{
				MessageBox.Show("Campo 'mínimo' deve ser numérico!", this.Text);

				tbMinimo.SelectAll();

				tbMinimo.Focus();

				return;
			}
		}

		private void textBox4_Enter(object sender, EventArgs e)
		{
			tbMaximo.SelectAll();
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbMaximo.Text.Length > 0)
			{
				btConfirmar.Focus();
			}
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			int numero;

			if (tbMaximo.Text.Length == 0)
			{
				tbMaximo.Text = "0";

				return;
			}

			if (!int.TryParse(tbMaximo.Text, out numero))
			{
				MessageBox.Show("Campo 'mínimo' deve ser numérico!", this.Text);

				tbMaximo.SelectAll();

				tbMaximo.Focus();

				return;
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			frmCadLocais form = new frmCadLocais(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarLocais();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			DialogResult d = MessageBox.Show("Confirma criação de arquivo de exportação do estoque?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (d == DialogResult.No)
				return;

			ExportarEstoque();
		}

		#endregion Methods
	}
}