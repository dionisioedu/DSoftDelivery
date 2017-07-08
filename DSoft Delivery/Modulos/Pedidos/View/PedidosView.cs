using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using DSoftBd;
using DSoftLogger;
using DSoftModels;
using DSoftParameters;
using DSoft_Delivery.Forms;
using System.Collections.Specialized;
using DSoftConfig;
using DSoftCore;
using System.Threading.Tasks;

namespace DSoft_Delivery.Pedidos
{
	public partial class PedidosView : Form, IPedidosView
	{
		#region Fields

		private DataTable ListaPedidos = null;
		private PedidosModel Model;
		private PedidosPresenter Presenter;
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Task _savingPreferencesTask;
		private CancellationTokenSource savePreferencesCancellationToken;
		private bool _loadingOrders = false;

		#endregion Fields

		#region Constructors

		public PedidosView(Bd bd, Usuario usuario)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			InitializeComponent();

			Model = new PedidosModel();
			Presenter = new PedidosPresenter(bd, usuario, Model, this);

			dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
			dataGridView1.UseWaitCursor = true;

			this.FormClosing += new FormClosingEventHandler(frmPedidos_FormClosing);
		}

		#endregion Constructors

		#region Events

		public event EventHandler AlterarTotalPedido;
		public event EventHandler CadClientesClicked;
		public event EventHandler CancelarClicked;
		public event EventHandler CarregarDadosCliente;
		public event EventHandler CarregarPedidosAnteriores;
		public event EventHandler ConfirmarItemClicked;
		public event EventHandler DefinirDataRaised;
		public event EventHandler DescontoChanged;
		public event EventHandler EntregarClicked;
		public event EventHandler EventNew;
		public event EventHandler EventSubmit;
		public event EventHandler ExcluirItemClicked;
		public event EventHandler HistoricoClienteRaised;
		public event EventHandler Initialize;
		public event EventHandler ItemAdicionalClicked;
		public event EventHandler ItemTresTercosClicked;
		public event EventHandler ItemQuatroQuartosClicked;
		public event EventHandler LimparPedidoClicked;
		public event EventHandler LimparListaClicked;
		public event EventHandler PagarClicked;
		public event EventHandler PedidoClicked;
		public event EventHandler PrecoChanged;
		public event EventHandler ProdutoDuploClicked;
		public event EventHandler ProdutoFracionadoClicked;
		public event EventHandler ProdutoPressed;
		public event EventHandler QuantidadeChanged;
		public event EventHandler RefreshClicked;
		public event EventHandler ReimprimirClicked;
		public event EventHandler TabelaChanged;
		public event EventHandler ShowDetailsClicked;
		public event EventHandler ConsultaPrecosClicked;
		public event EventHandler CadastroDeObservacoesClicked;
		public event EventHandler ProdutosTextChanged;
		public event EventHandler TaxaChanged;
		public event EventHandler AumentarQuantidadeClicked;
		public event EventHandler DiminuirQuantidadeClicked;
		public event EventHandler CadAdicionaisRapidoClicked;
		public event EventHandler HistoricoClicked;
		public event EventHandler EditarItem;
		public event EventHandler RetirarCheckedChanged;
		public event EventHandler EmitirECFClicked;
		public event EventHandler ExibirMapaClicked;
		public event EventHandler TrocarClienteClicked;

		#endregion Events

		#region Methods

		public Form FormHandler()
		{
			return this;
		}

		public void Loaded()
		{
			this.dataGridView1.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnDisplayIndexChanged);
			this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
		}

		public void AddRows(DataTable table)
		{
			this.Invoke(new Action(() =>
			{
				foreach (DataRow row in table.Rows)
				{
					ListaPedidos.Rows.Add(row.ItemArray);
				}

				dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
			}));
		}

		public void AdicionarItem(object item, decimal total_pedido)
		{
			this.Invoke(new Action(() =>
			{
				listBox1.Items.Add(item);
				tbTotal.Text = total_pedido.ToString("##,###,##0.00");
				LimparCampos();
			}));
		}

		public void AjustarTotalPedido(decimal total_pedido)
		{
			this.Invoke(new Action(() =>
			{
				tbTotal.Text = total_pedido.ToString("##,###,##0.00");
			}));
		}

		public void AvisoEstoque(double itens)
		{
			this.Invoke(new Action(() =>
			{
				lbAvisoEstoque.Text = "Restam " + itens.ToString() + " itens no estoque!";
				lbAvisoEstoque.Visible = true;
			}));
		}

		public void BloqueiaEstoque()
		{
			this.Invoke(new Action(() =>
			{
				lbAvisoEstoque.Text = "Item indisponível no estoque!";
				lbAvisoEstoque.Visible = true;
				btConfirmar.Enabled = false;
			}));
		}

		public void CancelarItensPedido(int[] itens)
		{
			this.Invoke(new Action(() =>
			{
				foreach (int i in itens)
				{
					listBox1.Items[i] = "C";
				}

				for (int i = listBox1.Items.Count - 1; i >= 0; i--)
				{
					if (listBox1.Items[i].ToString() == "C")
						listBox1.Items.RemoveAt(i);
				}
			}));
		}

		public void CarregarProdutos(string[] produtos)
		{
			try
			{
				this.Invoke(new Action(() =>
				{
					cbProduto.Items.Clear();
					cbProduto.Items.AddRange(produtos);
				}));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar produtos. Tente novamente, e se persistir entre em contato com o suporte.", this.Text);
				Logger.Instance.Error(e);
				Sair();
			}
		}

		public void CarregarProduto(string produto)
		{
			this.Invoke(new Action(() =>
				{
					cbProduto.Items.Add(produto);
				}));
		}

		public void ConfirmarFocus()
		{
			this.Invoke(new Action(() =>
			{
				btNovo.Focus();
			}));
		}

		public void BloquearProdutos()
		{
			this.Invoke(new Action(() =>
				{
					cbProduto.Enabled = false;
				}));
		}

		public void LiberarProdutos()
		{
			this.Invoke(new Action(() =>
			{
				cbProduto.Enabled = true;
			}));
		}

		public void DefinirDadosCliente(long codigo, string nome, string endereco, string bairro, bool ok = true)
		{
			this.Invoke(new Action(() =>
			{
				if (codigo > 0)
				{
					tbCliente.Text = codigo.ToString();
				}

				lbCliente.Text = nome;
				lbEndereco.Text = endereco + Environment.NewLine;
				lbEndereco.Text += bairro;

				if (ok)
				{
					cbProduto.Focus();
				}
				else
				{
					tbCliente.SelectAll();
					tbCliente.Focus();
				}
			}));
		}

		public void DefinirDadosCliente(string nome, string endereco, string bairro, bool ok = true)
		{
			this.Invoke(new Action(() =>
			{
				lbCliente.Text = nome;
				lbEndereco.Text = endereco + Environment.NewLine;
				lbEndereco.Text += bairro;

				if (ok)
				{
					cbProduto.Focus();
				}
				else
				{
					tbCliente.SelectAll();
					tbCliente.Focus();
				}
			}));
		}

		public void DefinirObservacao(string observacao)
		{
			this.Invoke(new Action(() =>
				{
					string[] obs = observacao.Split("\r\n".ToCharArray());

					foreach (string o in obs)
					{
						string s = o.Trim();

						if (s == cbObs1.Text)
						{
							cbObs1.Checked = true;
						}
						else if (s == cbObs2.Text)
						{
							cbObs2.Checked = true;
						}
						else if (s == cbObs3.Text)
						{
							cbObs3.Checked = true;
						}
						else if (s == cbObs4.Text)
						{
							cbObs4.Checked = true;
						}
						else if (s == cbObs5.Text)
						{
							cbObs5.Checked = true;
						}
						else
						{
							tbObservacao.AppendText(s);
						}
					}
				}));
		}

		public void DefinirPreco(decimal preco)
		{
			try
			{
				this.Invoke(new Action(() =>
				{
					tbPreco.Text = preco.ToString("##,###,##0.00");
				}));
			}
			catch (Exception)
			{
			}
		}

		public void DefinirTabela(int tabela)
		{
			this.Invoke(new Action(() =>
			{
				cbTabela.SelectedIndex = cbTabela.FindString(tabela.ToString() + " - ");
			}));
		}

		public void DefinirTabelas(List<TabelaDePrecos> tabelas)
		{
			this.Invoke(new Action(() =>
			{
				if (tabelas == null)
				{
					MessageBox.Show("Não foram encontradas tabelas de preço! Cadastre uma tabela de preços antes delançar pedidos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Close();
					return;
				}

				cbTabela.Items.Clear();
				cbTabela.Items.AddRange(tabelas.ToArray());
				cbTabela.SelectedItem = cbTabela.Items[0];
			}));
		}

		public void DefinirTaxaEntrega(decimal taxa_entrega, bool desabilita = false)
		{
			this.Invoke(new Action(() =>
			{
				tbTaxa.Text = taxa_entrega.ToString("##,###,##0.00");

				tbTaxa.Enabled = !desabilita;
			}));
		}

		public void DefinirTroco(decimal troco)
		{
			this.Invoke(new Action(() =>
				{
					tbTroco.Text = troco.ToString("##,###,##0.00");
				}));
		}

		public void DefinirTotal(decimal total)
		{
			this.Invoke(new Action(() =>
			{
				tbTotal.Text = total.ToString("##,###,##0.00");
			}));
		}

		public void LiberaEstoque()
		{
			this.Invoke(new Action(() =>
			{
				lbAvisoEstoque.Text = "";
				lbAvisoEstoque.Visible = false;
				btConfirmar.Enabled = true;
			}));
		}

		public void LimparAviso()
		{
			this.Invoke(new Action(() =>
			{
				lbAvisoEstoque.Text = "";
				lbAvisoEstoque.Visible = false;
			}));
		}

		public void LimparLista()
		{
			listBox1.Items.Clear();

			tbTotal.Text = "0,00";
		}

		public void MostrarProduto(Image imagem)
		{
			pbProduto.Image = imagem;
		}

		public string Observacao()
		{
			StringBuilder builder = new StringBuilder();

			if (tbObservacao.Text.Length > 0)
			{
				builder.AppendLine(tbObservacao.Text);
			}

			if (cbObs1.Checked)
			{
				builder.AppendLine(cbObs1.Text);
			}

			if (cbObs2.Checked)
			{
				builder.AppendLine(cbObs2.Text);
			}

			if (cbObs3.Checked)
			{
				builder.AppendLine(cbObs3.Text);
			}

			if (cbObs4.Checked)
			{
				builder.AppendLine(cbObs4.Text);
			}

			if (cbObs5.Checked)
			{
				builder.AppendLine(cbObs5.Text);
			}

			return builder.ToString();
		}

		public void PermitirItensAdicionais(bool permitir)
		{
			this.Invoke(new Action(() =>
			{
				clItensAdicionais.Enabled = permitir;
			}));
		}

		public void PreencherItensAdicionais(List<ItemAdicional> itens)
		{
			this.Invoke(new Action(() =>
			{
				clItensAdicionais.Items.Clear();

				foreach (ItemAdicional item in itens)
				{
					clItensAdicionais.Items.Add(item);
				}
			}));
		}

		public void PreencherPedido(char situacao)
		{
			this.Invoke(new Action(() =>
			{
				switch (situacao)
				{
					case 'A':
						gbPedido.Enabled = true;

						llItensMeioAMeio.Enabled = true;
						llItensTresTercos.Enabled = true;
						llItensQuatroQuartos.Enabled = true;
						llItensFracionados.Enabled = true;

						tbCliente.ReadOnly = false;

						btNovo.Text = "Co&nfirmar - F2";

						btEntregar.Enabled = true;
						btPagar.Enabled = true;
						btCancelar.Enabled = true;
						btNovo.Enabled = true;
						break;

					case 'B':

						break;

					case 'C':
						btCancelar.Text = "Reativar - F4";
						btCancelar.Enabled = true;
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;

					case 'E':
						btPagar.Enabled = true;
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;

					case 'N':
						btEntregar.Enabled = true;
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;

					case 'O':
						btEntregar.Enabled = true;
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;

					case 'P':
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;

					case 'S':
						btEntregar.Enabled = true;
						btPagar.Enabled = true;
						tbCliente.ReadOnly = true;
						btNovo.Enabled = false;
						break;
				}
			}));
		}

		public void PreencherPrecoUnitario(decimal preco, bool bloqueia = true)
		{
			if (preco > 0)
			{
				tbPrecoUnitario.Text = preco.ToString("##,###,##0.00");
				tbPreco.Text = preco.ToString("##,###,##0.00");

				if (bloqueia == false)
				{
					tbPrecoUnitario.ReadOnly = false;
				}

				tbQuantidade.Text = "1";
				tbQuantidade.Focus();
			}
			else
			{
				tbPrecoUnitario.ReadOnly = false;
				tbPrecoUnitario.Focus();
			}
		}

		public void PrepareNew()
		{
			this.Invoke(new Action(() =>
			{
				LimparDados();

				btNovo.Text = "Co&nfirmar - F2";
				gbPedido.Enabled = true;

				llItensMeioAMeio.Enabled = true;
				llItensTresTercos.Enabled = true;
				llItensQuatroQuartos.Enabled = true;
				llItensFracionados.Enabled = true;

				tbCliente.Focus();
			}));
		}

		public void SetCodigoCliente(long codigo)
		{
			tbCliente.Text = codigo.ToString();
			tbCliente.SelectAll();
			tbCliente.Focus();

			CarregarDadosCliente.Invoke(tbCliente, new EventArgs());
		}

		public void SetDataSource(DataSet ds, bool reset)
		{
			while (!this.IsHandleCreated)
			{
				Thread.Sleep(500);
			}

			if (reset)
			{
				ListaPedidos = ds.Tables[0].Copy();
				ListaPedidos.PrimaryKey = new DataColumn[] { ListaPedidos.Columns["indice"] };

				this.Invoke(new Action(() => { AtualizarPedidos(); }));
			}
			else
			{
				if (ds != null && ds.Tables.Count > 0)
				{
					bool alterou = false;
					DataTable atualizada = ds.Tables[0];

					foreach (DataRow row in atualizada.Rows)
					{
						bool existe = false;

						if (ListaPedidos != null)
						{
							for (int i = 0; i < ListaPedidos.Rows.Count; i++)
							{
								if (ListaPedidos.Rows[i]["indice"].ToString() == row["indice"].ToString())
								{
									existe = true;

									if (ListaPedidos.Rows[i]["situacao"].ToString() != row["situacao"].ToString())
									{
										ListaPedidos.Rows[i]["situacao"] = row["situacao"];
									}

									if (ListaPedidos.Rows[i]["saida"].ToString() != row["saida"].ToString())
									{
										ListaPedidos.Rows[i]["saida"] = row["saida"];
									}
								}
							}

							if (!existe)
							{
								ListaPedidos.Rows.Add(row.ItemArray);
								alterou = true;
							}
						}
					}

					if (alterou)
					{
						dataGridView1.Invalidate();
					}
				}
			}
		}

		public void SetItemPrice(decimal price)
		{
			tbPreco.Text = price.ToString("##,###,##0.00");
		}

		public decimal Troco()
		{
			decimal troco;

			if (!decimal.TryParse(tbTroco.Text, out troco))
				return 0;

			return troco;
		}

		public void ViewClean()
		{
			this.Invoke(new Action(() =>
			{
				LimparDados();
			}));
		}

		private void AtualizarPedidos()
		{
			try
			{
				if (ListaPedidos == null)
					return;

				_loadingOrders = true;

				dataGridView1.DataSource = ListaPedidos;

				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

				dataGridView1.Columns["indice"].Width = 45;
				dataGridView1.Columns["indice"].HeaderText = "Índice";
				dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["data"].Width = 68;
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["hora"].Width = 68;
				dataGridView1.Columns["hora"].HeaderText = "Hora";
				dataGridView1.Columns["cliente"].Width = 68;
				dataGridView1.Columns["cliente"].HeaderText = "Cliente";
				dataGridView1.Columns["endereco"].HeaderText = "Endereço";
				dataGridView1.Columns["endereco"].Width = 172;
				dataGridView1.Columns["nome"].Width = 172;
				dataGridView1.Columns["nome"].HeaderText = "Nome";
				dataGridView1.Columns["itens"].Width = 40;
				dataGridView1.Columns["itens"].HeaderText = "Itens";
				dataGridView1.Columns["total"].Width = 80;
				dataGridView1.Columns["total"].HeaderText = "Total R$";
				dataGridView1.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["taxa_entrega"].Width = 80;
				dataGridView1.Columns["taxa_entrega"].HeaderText = "Taxa R$";
				dataGridView1.Columns["taxa_entrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["saida"].HeaderText = "Saída";
				dataGridView1.Columns["saida"].DefaultCellStyle.Format = "HH:mm:ss";
				dataGridView1.Columns["saida"].Width = 68;
				dataGridView1.Columns["entrega"].HeaderText = "Entrega";
				dataGridView1.Columns["entrega"].DefaultCellStyle.Format = "HH:mm:ss";
				dataGridView1.Columns["entrega"].Width = 68;
				dataGridView1.Columns["vendedor"].HeaderText = "Vendedor";
				dataGridView1.Columns["situacao"].Width = 30;
				dataGridView1.Columns["situacao"].HeaderText = "Sit.";
				dataGridView1.Columns["observacao"].Width = 172;
				dataGridView1.Columns["observacao"].HeaderText = "Observação";
				dataGridView1.Columns["usuario"].Width = 68;
				dataGridView1.Columns["usuario"].HeaderText = "Usuário";
				dataGridView1.Columns["usuario_nome"].Width = 68;
				dataGridView1.Columns["usuario_nome"].HeaderText = "Nome";
				dataGridView1.Columns["comanda"].HeaderText = "Comanda";
				dataGridView1.Columns["comanda"].Width = 30;
				dataGridView1.Columns["comanda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					dataGridView1.Columns["comanda"].DisplayIndex = 0;
					dataGridView1.Columns["indice"].DisplayIndex = 11;

					dataGridView1.Columns["endereco"].DisplayIndex = 3;
				}

				CarregarPreferencias();

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
					//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
				}

				dataGridView1.UseWaitCursor = false;
				progressBar1.Visible = false;

				_loadingOrders = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void btReimprimir_Click(object sender, EventArgs e)
		{
			Reimprimir();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			LimparListaClicked.Invoke(null, null);

			LimparLista();
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex >= 0)
			{
				ExcluirItemClicked.Invoke(listBox1.SelectedItem, null);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Novo();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			RefreshClicked.Invoke(sender, e);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Entregar();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			LimparPedidoClicked.Invoke(null, null);

			LimparDados();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			CadClientes();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			ConfirmarItemClicked.Invoke(null, null);
		}

		private void CadClientes()
		{
			CadClientesClicked.Invoke(tbCliente, null);
		}

		private void Cancelar()
		{
			if (btCancelar.Enabled)
				CancelarClicked.Invoke(null, null);
		}

		private void CarregarPedido(int pedido)
		{
			PedidoClicked.Invoke(pedido, null);
		}

		private void cbProduto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				cbProduto.SelectedItem = null;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				ProdutoPressed.Invoke(cbProduto, e);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				cbProduto.SelectedItem = null;

				tbCliente.Text = string.Empty;
				lbCliente.Text = string.Empty;
				lbEndereco.Text = string.Empty;
				lbHistorico.Text = string.Empty;

				tbCliente.Focus();
			}
			else if (e.KeyCode == Keys.Up && cbProduto.Text.Length == 0)
			{
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Down && cbProduto.Text.Length == 0)
			{
				e.Handled = true;
			}
		}

		private void cbTabela_SelectedIndexChanged(object sender, EventArgs e)
		{
			TabelaChanged.Invoke(sender, e);
		}

		private void clItensAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ItemAdicionalClicked.Invoke(sender, e);
		}

		private void clItensAdicionais_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarPedido(int.Parse(dataGridView1.CurrentRow.Cells["indice"].Value.ToString()));
		}

		private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			try
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
			catch (Exception exception)
			{
				Logger.Instance.Error(exception);
			}
		}

		private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
		{
			if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
			{
				if (dataGridView1.Rows.Count >= 100 && !RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					if (dataGridView1.FirstDisplayedScrollingRowIndex < 3)
					{
						CarregarPedidosAnteriores.Invoke(sender, e);
					}
				}
			}
		}

		private void DefinirData()
		{
			DefinirDataRaised.Invoke(null, null);
		}

		private void Entregar()
		{
			if (btEntregar.Enabled)
				EntregarClicked.Invoke(null, null);
		}

		private void entregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Entregar();
		}

		private void frmPedidos_FormClosing(object sender, FormClosingEventArgs e)
		{
			Presenter.Finished = true;

			if (_savingPreferencesTask != null && !_savingPreferencesTask.IsCompleted)
			{
				this.Hide();
				e.Cancel = true;
				_savingPreferencesTask.Wait();
				this.Close();
			}
		}

		private void frmPedidos_Load(object sender, EventArgs e)
		{
			Initialize.Invoke(this, new EventArgs());

			if (RegrasDeNegocio.Instance.Ramo != "PIZZARIA")
			{
				llItensMeioAMeio.Visible = false;
				llItensFracionados.Visible = false;
				tsProdutosDuplos.Enabled = false;
				tsProdutosFracionados.Enabled = false;

				label27.Visible = false;
				tbTroco.Visible = false;
			}

			LimparDados();
		}

		private void CarregarPreferencias()
		{
			for (int i = dataGridView1.Columns.Count - 1; i >= 0; i--)
			{
				DataGridViewColumn col = dataGridView1.Columns[i];

				col.DisplayIndex = Util.TryParseInt(DSConfig.Instance.GetOrdersColumnOrder(col.Name));

				int width = Util.TryParseInt(DSConfig.Instance.GetOrdersColumnWidth(col.Name));

				if (width > 0)
				{
					col.Width = width;
				}
			}
		}

		private void SalvarPreferencias()
		{
			if (_loadingOrders == false)
			{
				if (savePreferencesCancellationToken != null)
				{
					savePreferencesCancellationToken.Cancel();
				}
				else
				{
					savePreferencesCancellationToken = new CancellationTokenSource();
				}

				_savingPreferencesTask = Task.Factory.StartNew(() =>
				{
					try
					{
						foreach (DataGridViewColumn col in dataGridView1.Columns)
						{
							DSConfig.Instance.SetOrdersColumnOrder(col.Name, col.DisplayIndex.ToString());
							DSConfig.Instance.SetOrdersColumnWidth(col.Name, col.Width.ToString());
						}
					}
					catch (Exception e)
					{
						return;
					}
				}, savePreferencesCancellationToken.Token).ContinueWith((task) =>
				{
					savePreferencesCancellationToken = null;
				});

				_savingPreferencesTask.Wait();
			}
		}

		private void ItemTerco()
		{
			if (llItensTresTercos.Enabled)
			{
				ItemTresTercosClicked.Invoke(this, new EventArgs());
			}
		}

		private void LimparCampos()
		{
			cbProduto.SelectedItem = null;
			cbProduto.Text = string.Empty;
			ProdutosTextChanged.Invoke(cbProduto, new EventArgs());

			tbPrecoUnitario.ReadOnly = true;
			tbPrecoUnitario.Clear();
			tbQuantidade.Text = "1";
			tbPreco.Text = string.Empty;

			tbPrecoUnitario.ReadOnly = true;

			lbProduto.Text = string.Empty;

			tbDesconto.Text = "0";
			tbObservacao.Text = string.Empty;

			for (int i = 0; i < clItensAdicionais.Items.Count; i++)
			{
				clItensAdicionais.SetItemChecked(i, false);
			}

			clItensAdicionais.Enabled = false;

			lbAvisoEstoque.Text = "";
			lbAvisoEstoque.Visible = false;

			btConfirmar.Enabled = true;

			cbProduto.Focus();
		}

		private void LimparDados()
		{
			gbPedido.Enabled = false;

			llItensMeioAMeio.Enabled = false;
			llItensTresTercos.Enabled = false;
			llItensQuatroQuartos.Enabled = false;
			llItensFracionados.Enabled = false;

			btNovo.Text = "&Novo - F2";
			btNovo.Enabled = true;

			btEntregar.Text = "&Entregar - F5";
			btEntregar.Enabled = false;

			btPagar.Text = "&Pagar - F6";
			btPagar.Enabled = false;

			btCancelar.Text = "&Cancelar - F4";
			btCancelar.Enabled = false;

			listBox1.Items.Clear();

			tbCliente.Text = string.Empty;
			tbCliente.ReadOnly = false;
			lbCliente.Text = string.Empty;
			lbEndereco.Text = string.Empty;

			cbRetirar.Checked = false;

			lbHistorico.Text = string.Empty;
			pnlSaldo.Visible = false;

			cbObs1.Checked = false;
			cbObs2.Checked = false;
			cbObs3.Checked = false;
			cbObs4.Checked = false;
			cbObs5.Checked = false;

			tbTaxa.Text = "0,00";
			tbTaxa.Enabled = true;
			tbTotal.Text = "0,00";

			tbTroco.Text = "0,00";

			lbMotivoDoCancelamento.Text = string.Empty;

			btEmitirECF.Visible = false;
			btTrocarCliente.Visible = false;

			LimparCampos();
		}

		public void ClearFields()
		{
			this.Invoke(new Action(() =>
			{
				LimparCampos();
			}));
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshClicked.Invoke(sender, e);
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CadClientes();
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ItemTerco();
		}

		private void llItensFracionados_Click(object sender, EventArgs e)
		{
			ProdutoFracionadoClicked.Invoke(null, null);
		}

		private void llProdutosDuplos_Click(object sender, EventArgs e)
		{
			ProdutoDuploClicked.Invoke(null, null);
		}

		private void Novo()
		{
			if (btNovo.Text == "&Novo - F2")
			{
				EventNew.Invoke(btNovo, null);
			}
			else
			{
				EventSubmit.Invoke(this, null);
			}
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Novo();
		}

		private void Pagar()
		{
			if (btPagar.Enabled)
				PagarClicked.Invoke(null, null);
		}

		private void pagarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void pedidosEmAbertoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);

			form.Text = "Pedidos em Aberto";

			form.ShowDialog();
		}

		private void pedidosPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tbCliente.Text != string.Empty)
			{
				frmConPedidosCliente form = new frmConPedidosCliente(_dsoftBd, _usuario);

				form.Cliente = int.Parse(tbCliente.Text);

				form.ShowDialog();
			}
		}

		private void pedidosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroPedidosPeriodo form = new frmFiltroPedidosPeriodo(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void produtosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);

			form.Text = "Produtos por período";

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Presenter.ImprimirProdutosPeriodo(form.dateTimePicker1.Value, form.dateTimePicker2.Value);
			}
		}

		private void Reimprimir()
		{
			ReimprimirClicked.Invoke(this, null);
		}

		public void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbDesconto_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void tbDesconto_TextChanged(object sender, EventArgs e)
		{
			DescontoChanged.Invoke(sender, e);
		}

		private void tbObservacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbProduto.SelectedItem == null)
				{
					btNovo.Focus();
				}
				else
				{
					btConfirmar.Focus();
				}
			}
		}

		private void tbPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
		{
			decimal preco;

			if (e.KeyChar == (char)Keys.Enter)
			{
				if (!decimal.TryParse(tbPrecoUnitario.Text, out preco))
				{
					tbPrecoUnitario.SelectAll();
				}
				else
				{
					tbPrecoUnitario.Text = preco.ToString("###,##0.00");
					PrecoChanged.Invoke(preco, null);

					tbQuantidade.Focus();
				}
			}
		}

		private void tbQuantidade_TextChanged(object sender, EventArgs e)
		{
			if (tbQuantidade.Text.Length > 0)
			{
				QuantidadeChanged.Invoke(tbQuantidade.Text, null);
			}
		}

		private void tbTotal_DoubleClick(object sender, EventArgs e)
		{
			DescontoTotal();
		}

		public void DescontoTotal()
		{
			tbTotal.ReadOnly = false;
			tbTotal.SelectAll();
			tbTotal.Focus();
		}

		private void tbTotal_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				decimal valor;

				if (decimal.TryParse(tbTotal.Text, out valor))
				{
					if (MessageBox.Show("Confirma alteração do valor total?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
					{
						AlterarTotalPedido.Invoke(valor, e);
						tbTotal.ReadOnly = true;
						btNovo.Focus();
					}
				}
			}
		}

		private void tbTroco_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btNovo.Focus();
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (_usuario.NivelUsuario.Administrador)
				{
					tbTotal.Focus();
				}
				else
				{
					tbTaxa.Focus();
				}
			}
			else if (e.KeyCode == Keys.Down)
			{
				btNovo.Focus();
			}
		}

		private void tbTroco_Leave(object sender, EventArgs e)
		{
			double troco;

			if (!double.TryParse(tbTroco.Text, out troco))
			{
				tbTroco.Text = "0,00";
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbQuantidade.Text == "")
					return;

				QuantidadeChanged.Invoke(tbQuantidade.Text, null);
				//tbDesconto.Focus();

				btConfirmar.Focus();
			}
		}

		private void toolStripMenuItem10_Click(object sender, EventArgs e)
		{
			ItemTerco();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (llItensMeioAMeio.Enabled)
			{
				ProdutoDuploClicked.Invoke(null, null);
			}
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (llItensFracionados.Enabled)
			{
				ProdutoFracionadoClicked.Invoke(null, null);
			}
		}

		private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
		{
			CadClientes();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			HistoricoClienteRaised.Invoke(null, null);
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			tbTroco.Focus();
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			Reimprimir();
		}

		private void toolStripMenuItem8_Click(object sender, EventArgs e)
		{
			DefinirData();
		}

		private void btDetalhes_Click(object sender, EventArgs e)
		{
			MostrarDetalhes();
		}

		private void MostrarDetalhes()
		{
			ShowDetailsClicked.Invoke(null, null);
		}

		private void tbCliente_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != '*')
			{
				e.Handled = true;
			}
		}

		private void tbCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CarregarDadosCliente.Invoke(tbCliente, e);
			}
		}

		private void ConsultaPrecos()
		{
			ConsultaPrecosClicked.Invoke(null, new EventArgs());
		}

		private void llConsultaPrecos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ConsultaPrecos();
		}

		private void toolStripMenuItem11_Click(object sender, EventArgs e)
		{
			ConsultaPrecos();
		}

		public void DefinirProduto(Produto produto)
		{
			cbProduto.Text = produto.ToString();
			ProdutoPressed.Invoke(cbProduto, new EventArgs());
		}

		public void MostrarNomeProduto(string nome)
		{
			this.Invoke(new Action(() =>
			{
				cbProduto.Text = nome;
			}));
		}

		private void llCadastroObservacoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CadastroDeObservacoesClicked.Invoke(sender, e);
		}

		public void DefinirObservacoes(List<string> observacoes)
		{
			if (observacoes != null)
			{
				if (observacoes.Count > 0)
				{
					cbObs1.Text = observacoes[0];
					cbObs1.Enabled = true;
				}
				else
				{
					cbObs1.Text = "";
					cbObs1.Enabled = false;
				}

				if (observacoes.Count > 1)
				{
					cbObs2.Text = observacoes[1];
					cbObs2.Enabled = true;
				}
				else
				{
					cbObs2.Text = "";
					cbObs2.Enabled = false;
				}

				if (observacoes.Count > 2)
				{
					cbObs3.Text = observacoes[2];
					cbObs3.Enabled = true;
				}
				else
				{
					cbObs3.Text = "";
					cbObs3.Enabled = false;
				}

				if (observacoes.Count > 3)
				{
					cbObs4.Text = observacoes[3];
					cbObs4.Enabled = true;
				}
				else
				{
					cbObs4.Text = "";
					cbObs4.Enabled = false;
				}

				if (observacoes.Count > 4)
				{
					cbObs5.Text = observacoes[4];
					cbObs5.Enabled = true;
				}
				else
				{
					cbObs5.Text = "";
					cbObs5.Enabled = false;
				}
			}
		}

		public void PermitirTabelasDePrecos(bool permitir)
		{
			this.Invoke(new Action(() =>
			{
				cbTabela.Enabled = permitir;
			}));
		}

		private void cbProduto_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
			{
				ProdutosTextChanged.Invoke(sender, e);

				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				tbCliente.Text = string.Empty;
				tbCliente.Focus();
			}
			else if (e.KeyCode == Keys.Up && cbProduto.Text.Length == 0)
			{
				tbCliente.Focus();
				cbProduto.SelectedItem = null;
			}
			else if (e.KeyCode == Keys.Down && cbProduto.Text.Length == 0)
			{
				if (listBox1.Items.Count > 0)
				{
					listBox1.Focus();
					listBox1.SetSelected(0, true);
				}
				else
				{
					btNovo.Focus();
				}
			}
		}

		private void cbProduto_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLower(e.KeyChar))
			{
				e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}

		public void ShowDropDown()
		{
			this.Invoke(new Action(() =>
			{
				this.cbProduto.DroppedDown = true;
			}));
		}

		public void HideDropDown()
		{
			this.Invoke(new Action(() =>
			{
				try
				{
					this.cbProduto.DroppedDown = false;
				}
				catch (ArgumentOutOfRangeException ae)
				{
					Logger.Instance.Error(ae);
				}
			}));
		}

		private void toolStripMenuItem12_Click(object sender, EventArgs e)
		{
			CadAdicionaisRapidoClicked.Invoke(sender, e);
		}

		public void AdicionarItemAdicional(ItemAdicional item)
		{
			this.Invoke(new Action(() =>
			{
				clItensAdicionais.Items.Add(item);
				clItensAdicionais.SetItemChecked(clItensAdicionais.Items.Count - 1, true);

				clItensAdicionais.ClearSelected();
				clItensAdicionais.SetSelected(clItensAdicionais.Items.Count - 1, true);

				ItemAdicionalClicked.Invoke(clItensAdicionais, null);
			}));
		}

		private void tbTaxa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
			else if (e.KeyCode == Keys.Up)
			{
				listBox1.Focus();
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (_usuario.NivelUsuario.Administrador)
				{
					tbTotal.Focus();
				}
				else
				{
					tbTroco.Focus();
				}
			}
		}

		private void btAumentarQuantidade_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem != null)
			{
				AumentarQuantidadeClicked.Invoke(listBox1.SelectedItem, e);
			}
		}

		private void btReduzirQuantidade_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem != null)
			{
				DiminuirQuantidadeClicked.Invoke(listBox1.SelectedItem, e);
			}
		}

		public void RedesenharLista(List<ItemPedido> itens)
		{
			int selected = listBox1.SelectedIndex;

			listBox1.Items.Clear();

			foreach (ItemPedido item in itens)
			{
				listBox1.Items.Add(item);

				if (item.ItensAdicionais.Count > 0)
				{
					foreach (ItemAdicional adicional in item.ItensAdicionais)
					{
						listBox1.Items.Add(adicional);
					}
				}

				if (item.Observacao != null && item.Observacao.Trim().Length > 0)
				{
					listBox1.Items.Add(item.Observacao);
				}
			}

			listBox1.SelectedIndex = selected;
		}

		public string ObservacaoItem()
		{
			return tbObservacao.Text;
		}

		private void PedidosView_FormClosing(object sender, FormClosingEventArgs e)
		{
			//SalvarPreferencias();
		}

		private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HistoricoClienteRaised.Invoke(sender, e);
		}

		private void toolStripMenuItem13_Click(object sender, EventArgs e)
		{
			if (llItensQuatroQuartos.Enabled)
			{
				ItemQuatroQuartosClicked.Invoke(sender, e);
			}
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ItemQuatroQuartosClicked.Invoke(sender, e);
		}

		public void MostrarHistorico(string historico)
		{
			this.Invoke(new Action(() =>
			{
				lbHistorico.Text = historico;
				lbHistorico.BringToFront();
			}));
		}

		private void toolStripMenuItem15_Click(object sender, EventArgs e)
		{
			tbTaxa.SelectAll();
			tbTaxa.Focus();
		}

		private void tbCliente_Enter(object sender, EventArgs e)
		{
			tbCliente.SelectAll();
		}

		private void listBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				if (listBox1.Items.Count > 0)
				{
					if (listBox1.GetSelected(0))
					{
						cbProduto.Focus();
					}
				}
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (listBox1.Items.Count == 0 || listBox1.GetSelected(listBox1.Items.Count - 1))
				{
					tbTaxa.Focus();
				}
			}
			else if (e.KeyCode == Keys.PageUp)
			{
				AumentarQuantidadeClicked.Invoke(listBox1.SelectedItem, e);
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.PageDown)
			{
				DiminuirQuantidadeClicked.Invoke(listBox1.SelectedItem, e);
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				ItemPedido item = listBox1.SelectedItem as ItemPedido;

				if (item != null)
				{
					EditarItem.Invoke(item, new EventArgs());

					e.Handled = true;
				}
			}
		}

		private void tbTaxa_Leave(object sender, EventArgs e)
		{
			decimal taxa;
			decimal.TryParse(tbTaxa.Text, out taxa);

			tbTaxa.Text = taxa.ToString("##,###,##0.00");

			TaxaChanged.Invoke(sender, e);
		}

		private void tbTroco_Enter(object sender, EventArgs e)
		{
			tbTroco.SelectAll();
		}

		private void tbTotal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				tbTaxa.Focus();
			}
			else if (e.KeyCode == Keys.Down)
			{
				tbTroco.Focus();
			}
		}

		private void btNovo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right)
			{
				if (btEntregar.Enabled)
				{
					btEntregar.Focus();
				}
				else
				{
					btLimpar.Focus();
				}
			}
			else if (e.KeyCode == Keys.Up)
			{
				tbTroco.Focus();
			}
		}

		private void btEntregar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				btNovo.Focus();
			}
			else if (e.KeyCode == Keys.Right)
			{
				if (btPagar.Enabled)
				{
					btPagar.Focus();
				}
				else
				{
					btLimpar.Focus();
				}
			}
		}

		private void btPagar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				if (btEntregar.Enabled)
				{
					btEntregar.Focus();
				}
				else
				{
					btNovo.Focus();
				}
			}
			else if (e.KeyCode == Keys.Right)
			{
				if (btCancelar.Enabled)
				{
					btCancelar.Focus();
				}
				else
				{
					btLimpar.Focus();
				}
			}
		}

		private void btCancelar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				if (btPagar.Enabled)
				{
					btPagar.Focus();
				}
				else
				{
					btNovo.Focus();
				}
			}
			else if (e.KeyCode == Keys.Right)
			{
				btLimpar.Focus();
			}
		}

		private void btLimpar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				if (btCancelar.Enabled)
				{
					btCancelar.Focus();
				}
				else
				{
					btNovo.Focus();
				}
			}
			else if (e.KeyCode == Keys.Right)
			{
				btSair.Focus();
			}
		}

		private void btSair_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				btLimpar.Focus();
			}
		}

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			ItemPedido item = listBox1.SelectedItem as ItemPedido;

			if (item != null)
			{
				EditarItem.Invoke(item, new EventArgs());
			}
		}

		private void tbCliente_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				cbProduto.Focus();
				e.Handled = true;
			}
		}

		public void BloquearConfirma()
		{
			this.Invoke(new Action(() =>
				{
					btNovo.Enabled = false;
				}));
		}

		public void HabilitarConfirma()
		{
			this.Invoke(new Action(() =>
				{
					btNovo.Enabled = true;
				}));
		}

		public void PreencherMotivoDoCancelamento(string motivo)
		{
			this.Invoke(new Action(() =>
				{
					lbMotivoDoCancelamento.Text = motivo;
				}));
		}

		public void DefinirRetirar(bool retirar)
		{
			this.Invoke(new Action(() =>
				{
					cbRetirar.Checked = retirar;
				}));
		}

		public bool Retirar()
		{
			return cbRetirar.Checked;
		}

		private void cbRetirar_CheckedChanged(object sender, EventArgs e)
		{
			RetirarCheckedChanged.Invoke(sender, e);
		}

		public void HabilitaPedido()
		{
			this.Invoke(new Action(() =>
				{
					gbPedido.Enabled = true;
				}));
		}

		public void DesabilitaPedido()
		{
			this.Invoke(new Action(() =>
			{
				gbPedido.Enabled = false;
			}));
		}

		private void btEmitirECF_Click(object sender, EventArgs e)
		{
			EmitirECFClicked.Invoke(sender, e);
		}

		public void EsconderECF()
		{
			this.Invoke(new Action(() =>
				{
					btEmitirECF.Visible = false;
				}));
		}

		public void MostrarECF()
		{
			this.Invoke(new Action(() =>
				{
					btEmitirECF.Visible = true;
				}));
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && dataGridView1.CurrentRow != null)
			{
				CarregarPedido(int.Parse(dataGridView1.CurrentRow.Cells["indice"].Value.ToString()));
			}
		}

		private void llRota_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ExibirMapaClicked.Invoke(sender, e);
		}

		public void MostrarRota(Bd bd, Usuario usuario, Cliente cliente)
		{
			this.Invoke(new Action(() =>
				{
					frmRota form = new frmRota(bd, usuario, cliente);
					form.Show();
				}));
		}

		private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			SalvarPreferencias();
		}

		private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
		{
			SalvarPreferencias();
		}

		private void btTrocarCliente_Click(object sender, EventArgs e)
		{
			TrocarClienteClicked.Invoke(sender, e);
		}

		public void TrocarClienteVisivel(bool visivel)
		{
			this.Invoke(new Action(() =>
			{
				btTrocarCliente.Visible = visivel;
			}));
		}

		public void MostrarSaldo(decimal saldo)
		{
			this.Invoke(new Action(() =>
			{
				pnlSaldo.Visible = true;
				tbSaldo.Text = saldo.ToString(Constants.FORMATO_MOEDA);

				if (saldo > 0)
				{
					tbSaldo.ForeColor = Color.DarkGreen;
				}
				else
				{
					tbSaldo.ForeColor = Color.DarkRed;
				}
			}));
		}

		public void OcultarSaldo()
		{
			this.Invoke(new Action(() =>
			{
				pnlSaldo.Visible = false;
			}));
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 2)
			{

			}
		}

		#endregion Methods
	}
}
