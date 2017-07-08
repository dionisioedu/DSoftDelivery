using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftCore;
using DSoftModels;
using DSoftParameters;
using DSoft_Delivery.Forms;
using DSoft_Delivery.Relatorios;
using DSoftForms;

namespace DSoft_Delivery.Pedidos
{
	class PedidosPresenter
	{
		#region Fields

		public bool Finished = false;

		private Pedido _pedido;
		private Pedido _pedidoOriginal;
		private string Titulo = "Pedidos";
		private IPedidosView View;
		private Bd _dsoftBd;
		private ItemPedido _itemPedido;
		private int _primeiroPedido = 0;
		private decimal _totalAdicionais;
		private Usuario _usuario;
		private frmCadObservacoes _cadObservacoes;
		private CalendarioDeTabelas _calendario;
		private List<TabelaDePrecos> _tabelasDePrecos;
		private TabelaDePrecos _tabela;
		private List<string> _produtosString;
		private List<string> _produtosNome;
		private Timer _autoRefresh;
		private List<Produto> _produtos;
		private Dictionary<Produto, decimal> _produtosPrecos;

		#endregion Fields

		#region Constructors

		public PedidosPresenter(Bd bd, Usuario usuario, IPedidosModel model, IPedidosView view)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			_pedido = (PedidosModel)model;

			View = view;
			View.Initialize += new EventHandler(View_Initialize);
			View.EventNew += new EventHandler(View_EventNew);
			View.EventSubmit += new EventHandler(View_EventSubmit);
			View.CadClientesClicked += new EventHandler(View_OpenCadClientes);
			View.CarregarDadosCliente += new EventHandler(View_CarregarDadosCliente);
			View.ReimprimirClicked += new EventHandler(View_ReimprimirClicked);
			View.ProdutoPressed += new EventHandler(View_ProdutoPressed);
			View.TabelaChanged += new EventHandler(View_TabelaChanged);
			View.QuantidadeChanged += new EventHandler(View_QuantidadeChanged);
			View.ConfirmarItemClicked += new EventHandler(View_ConfirmarItemClicked);
			View.LimparPedidoClicked += new EventHandler(View_LimparPedidoClicked);
			View.LimparListaClicked += new EventHandler(View_LimparListaClicked);
			View.ExcluirItemClicked += new EventHandler(View_ExcluirItemClicked);
			View.DefinirDataRaised += new EventHandler(View_DefinirDataRaised);
			View.HistoricoClienteRaised += new EventHandler(View_HistoricoClienteRaised);
			View.ProdutoDuploClicked += new EventHandler(View_PedidosDuplosClicked);
			View.ProdutoFracionadoClicked += new EventHandler(View_PedidosMultiplosClicked);
			View.ItemTresTercosClicked += new EventHandler(View_ItemTresTercosClicked);
			View.ItemQuatroQuartosClicked += new EventHandler(View_ItemQuatroQuartosClicked);
			View.PedidoClicked += new EventHandler(View_PedidoClicked);
			View.EntregarClicked += new EventHandler(View_EntregarClicked);
			View.PagarClicked += new EventHandler(View_PagarClicked);
			View.CancelarClicked += new EventHandler(View_CancelarClicked);
			View.DescontoChanged += new EventHandler(View_DescontoChanged);
			View.AlterarTotalPedido += new EventHandler(View_AlterarTotalPedido);
			View.RefreshClicked += new EventHandler(View_RefreshClicked);
			View.PrecoChanged += new EventHandler(View_PrecoChanged);
			View.CarregarPedidosAnteriores += new EventHandler(View_CarregarPedidosAnteriores);
			View.ItemAdicionalClicked += new EventHandler(View_ItemAdicionalClicked);
			View.ShowDetailsClicked += new EventHandler(View_ShowDetailsClicked);
			View.ConsultaPrecosClicked += new EventHandler(View_ConsultaPrecosClicked);
			View.CadastroDeObservacoesClicked += new EventHandler(View_CadastroDeObservacoesClicked);
			View.ProdutosTextChanged += new EventHandler(View_ProdutosTextChanged);
			View.TaxaChanged += new EventHandler(View_TaxaChanged);
			View.AumentarQuantidadeClicked += new EventHandler(View_AumentarQuantidadeClicked);
			View.DiminuirQuantidadeClicked += new EventHandler(View_DiminuirQuantidadeClicked);
			View.CadAdicionaisRapidoClicked += new EventHandler(View_CadAdicionaisRapidoClicked);
			View.EditarItem += new EventHandler(View_EditarItem);
			View.RetirarCheckedChanged += new EventHandler(View_RetirarCheckedChanged);
			View.EmitirECFClicked += new EventHandler(View_EmitirECFClicked);
			View.ExibirMapaClicked += new EventHandler(View_ExibirMapaClicked);
			View.TrocarClienteClicked += new EventHandler(View_TrocarClienteClicked);

			if (Preferencias.PedidosAtualiza > 0)
			{
				_autoRefresh = new Timer();
				_autoRefresh.Enabled = true;
				_autoRefresh.Interval = Preferencias.PedidosAtualiza * 1000;
				_autoRefresh.Tick += new EventHandler(_autoRefresh_Tick);
				_autoRefresh.Start();
			}
		}

		#endregion Constructors

		#region Methods

		private void View_TrocarClienteClicked(object sender, EventArgs e)
		{
			CapturaCodigo form = new CapturaCodigo("Troca de cliente", "Digite o código do cliente:");

			if (form.ShowDialog() == DialogResult.OK)
			{
				long codigo;
				long.TryParse(form.Codigo, out codigo);

				if (codigo > 0)
				{
					Cliente cliente = _dsoftBd.CarregarCliente(codigo);

					if (cliente != null)
					{
						if (_dsoftBd.TrocarCliente(_pedido, cliente))
						{
							_pedido.Cliente = cliente.Codigo;

							View.DefinirDadosCliente(cliente.Nome, cliente.Endereco, cliente.Bairro);

							CarregarHistorico(cliente);

							if (cliente.Tabela != null)
							{
								View.DefinirTabela((int)cliente.Tabela);
							}

							CarregarTaxaDeEntregaEServico(cliente);
						}
						else
						{
							MessageBox.Show("Erro ao gravar os dados!");
						}
					}
					else
					{
						MessageBox.Show("Código de cliente não encontrado!");
					}
				}
				else
				{
					MessageBox.Show("Código inválido!");
				}
			}
		}

		private void View_ExibirMapaClicked(object sender, EventArgs e)
		{
			if (_pedido != null && _pedido.Cliente > 0)
			{
				Cliente cliente = _dsoftBd.CarregarCliente(_pedido.Cliente);

				View.MostrarRota(_dsoftBd, _usuario, cliente);
			}
		}

		private void View_EmitirECFClicked(object sender, EventArgs e)
		{
			if (_pedido != null)
			{
				List<PagamentoNovo> pagamentos = _dsoftBd.PagamentosNovoDoPedido(_pedido);

				if (pagamentos != null)
				{
					EmitirCupomFiscal(pagamentos);
				}
			}
		}

		private void EmitirCupomFiscal(List<PagamentoNovo> pagamentos)
		{
			if (!RegrasDeNegocio.Instance.EmiteCupomFiscal)
				return;

			CapturaCPFNota form = new CapturaCPFNota();

			if (form.ShowDialog() == DialogResult.Cancel)
				return;

			try
			{
				Pedido pedido = new Pedido();

				_dsoftBd.CarregarPedido(_pedido.Numero, pedido);

				PrepararValoresECF(pedido);

				if (Terminal.ECF() == "BEMATECH MP-2100 TH FI")
				{
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_AbreCupom(form.Cpf));

					foreach (ItemPedido item in pedido.ItensPedido)
					{
						if (item == null)
							continue;

						if (item.Unitario == 0)
							item.Unitario = 0.01M;

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_VendeItem(item.Produto.ToString(), _dsoftBd.ProdutoNome(item.Produto, 29), "FF", "I", item.Quantidade.ToString("0000"), 2, item.Unitario.ToString("00000.00"), "%", item.Desconto.ToString("0000")));
					}

					if (pedido.TaxaDeEntrega > 0)
					{
						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_VendeItem("001", "TAXA DE ENTREGA", "1200", "I", "1", 2, pedido.TaxaDeEntrega.ToString("00000.00"), "%", "0000"));
					}

					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_IniciaFechamentoCupom("A", "%", "0"));

					for (int i = 0; i < pagamentos.Count; i++)
					{
						string desc = _dsoftBd.PagamentoForma(pagamentos[i].Forma);
						string valor = pagamentos[i].Valor.ToString();

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_EfetuaFormaPagamento(desc, valor));
					}

					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_TerminaFechamentoCupom("Obrigado. Volte sempre!"));

					string Loja = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroLoja(ref Loja));

					string Caixa = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCaixa(ref Caixa));

					string Cupom = new string('\x20', 6);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCupom(ref Cupom));

					_dsoftBd.AtribuiCupomFiscal(_pedido.Numero, int.Parse(Loja), int.Parse(Caixa), long.Parse(Cupom));
				}
				else if (Terminal.ECF() == "SWEDA ST120")
				{
					int retorno;

					ECFHelper helper = new ECFHelper();

					retorno = SwedaST120.ECF_AbreCupom(form.Cpf);
					helper.Analisa_Retorno_ECF();

					if (retorno < 1)
					{
						MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
						return;
					}

					foreach (ItemPedido item in pedido.ItensPedido)
					{
						retorno = SwedaST120.ECF_VendeItem(item.Produto.ToString("000"), item.ProdutoNome, "1200", "I", item.Quantidade.ToString("0"), 2, item.Unitario.ToString("00000.00"), "%", "0000");
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					if (pedido.TaxaDeEntrega > 0)
					{
						retorno = SwedaST120.ECF_VendeItem("001", "TAXA DE ENTREGA", "1200", "I", "1", 2, pedido.TaxaDeEntrega.ToString("00000.00"), "%", "0000");
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					for (int i = 0; i < pagamentos.Count; i++)
					{
						string desc = _dsoftBd.PagamentoForma(pagamentos[i].Forma);
						string valor = pagamentos[i].Valor.ToString();

						retorno = SwedaST120.ECF_EfetuaFormaPagamento(desc, valor);
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					retorno = SwedaST120.ECF_TerminaFechamentoCupom("Obrigado. Volte sempre!");
					helper.Analisa_Retorno_ECF();

					if (retorno < 1)
					{
						MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
						return;
					}

					StringBuilder Loja = new StringBuilder();
					SwedaST120.ECF_NumeroLoja(Loja);

					StringBuilder Caixa = new StringBuilder();
					SwedaST120.ECF_NumeroCaixa(Caixa);

					StringBuilder Cupom = new StringBuilder();
					SwedaST120.ECF_NumeroCupom(Cupom);

					_dsoftBd.AtribuiCupomFiscal(_pedido.Numero, int.Parse(Loja.ToString()), int.Parse(Caixa.ToString()), long.Parse(Cupom.ToString()));
				}
			}
			catch (Exception e)
			{
				DSoftLogger.Logger.Instance.Error(e);
			}
		}

		private void PrepararValoresECF(Pedido pedido)
		{
			for (int i = 0; i < pedido.ItensPedido.Count; i++)
			{
				if (pedido.ItensPedido[i].Unitario == 0)
				{
					if (pedido.ItensPedido[i].Preco != 0)
					{
						pedido.ItensPedido[i].Unitario = pedido.ItensPedido[i].Preco;
					}
					else
					{
						// Achamos o valor principal
						int item = pedido.ItensPedido[i].Numero;
						int principal = 0;

						for (int j = 0; j < pedido.ItensPedido.Count; j++)
						{
							if (pedido.ItensPedido[j].Numero == item && !pedido.ItensPedido[j].Secundario)
							{
								principal = j;
								break;
							}
						}

						pedido.ItensPedido[principal].Unitario -= 0.01M;
						pedido.ItensPedido[i].Unitario = 0.01M;
					}
				}
			}
		}

		private void View_RetirarCheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;

			if (checkBox != null)
			{
				if (checkBox.Checked)
				{
					_pedido.TaxaDeEntrega = 0;

					if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
					{
						View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega, true);
					}
					else
					{
						View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega);
					}

					View.AjustarTotalPedido(_pedido.TotalPedido);
					_pedido.Retirar = true;
				}
				else
				{
					_pedido.Retirar = false;

					if (_pedido.Cliente > 0)
					{
						CarregarTaxaDeEntregaEServico(_dsoftBd.CarregarCliente(_pedido.Cliente));
					}
				}
			}
		}

		private void View_EditarItem(object sender, EventArgs e)
		{
			ItemPedido item = sender as ItemPedido;

			if (item != null)
			{
				if (item.Quantidade % 1 == 0)
				{
					frmEditarItem form = new frmEditarItem(_dsoftBd, _usuario, item);

					if (form.ShowDialog() == DialogResult.OK)
					{
						View.RedesenharLista(_pedido.ItensPedido);
					}
				}
				else
				{
					List<ItemPedido> itens = null;
					int fracoes;

					fracoes = ItemFracionado(item, ref itens);

					if (fracoes == 2)
					{
						frmNovoItemMeio form = new frmNovoItemMeio(_dsoftBd, _usuario, _tabela, itens);

						if (form.ShowDialog() == DialogResult.OK)
						{
							View.RedesenharLista(_pedido.ItensPedido);
							View.DefinirTotal(_pedido.TotalPedido);
						}
					}
					else if (fracoes == 3)
					{
						frmNovoItemTerco form = new frmNovoItemTerco(_dsoftBd, _usuario, _tabela, itens);

						if (form.ShowDialog() == DialogResult.OK)
						{
							View.RedesenharLista(_pedido.ItensPedido);
							View.DefinirTotal(_pedido.TotalPedido);
						}
					}
					else if (fracoes == 4)
					{
						frmNovoItemQuarto form = new frmNovoItemQuarto(_dsoftBd, _usuario, _tabela, itens);

						if (form.ShowDialog() == DialogResult.OK)
						{
							View.RedesenharLista(_pedido.ItensPedido);
							View.DefinirTotal(_pedido.TotalPedido);
						}
					}
				}
			}
		}

		private int ItemFracionado(ItemPedido item, ref List<ItemPedido> itens)
		{
			int ocorrencias = 0;

			itens = new List<ItemPedido>();

			for (int i = 0; i < _pedido.ItensPedido.Count; i++)
			{
				if (_pedido.ItensPedido[i].Numero == item.Numero)
				{
					itens.Add(_pedido.ItensPedido[i]);
					ocorrencias++;
				}
			}

			return ocorrencias;
		}

		private void View_ItemQuatroQuartosClicked(object sender, EventArgs e)
		{
			var lista = from l in _produtos where l.ProdutoTipo.Fracionado == true select l;

			frmNovoItemQuarto form = new frmNovoItemQuarto(_dsoftBd, _usuario, _pedido.Tabela, lista.ToList(), _produtosPrecos, _pedido.Produto);

			if (form.ShowDialog() == DialogResult.OK)
			{
				_pedido.NovoItem(form.Itens[0], form.Itens[1], form.Itens[2], form.Itens[3]);

				if (RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
				{
					AgruparProdutos();
					View.RedesenharLista(_pedido.ItensPedido);
					View.ClearFields();
					View.DefinirTotal(_pedido.TotalPedido);
				}
				else
				{
					View.AdicionarItem(form.Itens[0], 0);
					View.AdicionarItem(form.Itens[1], _pedido.TotalPedido);
					View.AdicionarItem(form.Itens[2], _pedido.TotalPedido);
					View.AdicionarItem(form.Itens[3], _pedido.TotalPedido);
				}
			}
		}

		private void _autoRefresh_Tick(object sender, EventArgs e)
		{
			RefreshView(false);
		}

		private void View_CadAdicionaisRapidoClicked(object sender, EventArgs e)
		{
			frmCadAdicionaisRapido form = new frmCadAdicionaisRapido(_dsoftBd, _usuario);

			form.ShowDialog();

			if (form.ItemAdicional != null)
			{
				ItemAdicional item = form.ItemAdicional;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					_dsoftBd.AdicionarItemAdicional(item, _pedido.Produto);
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					ProdutoTipo tipo = _dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(_pedido.Produto));

					if (tipo != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, tipo);
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				View.AdicionarItemAdicional(item);
			}
		}

		private void View_DiminuirQuantidadeClicked(object sender, EventArgs e)
		{
			ItemPedido item = sender as ItemPedido;

			if (item != null)
			{
				_pedido.ResetarTotalManual();

				if (--item.Quantidade == 0)
				{
					_pedido.ItensPedido.Remove(item);
					_pedido.ResetarNumeros();

					RemontarLista();
					RecalculaTaxaDeServico();
				}
				else
				{
					item.Preco = (item.Unitario * (decimal)item.Quantidade);

					if (item.ItensAdicionais.Count > 0)
					{
						foreach (ItemAdicional adicional in item.ItensAdicionais)
						{
							item.Preco += (adicional.Valor * (decimal)item.Quantidade);
						}
					}

					View.RedesenharLista(_pedido.ItensPedido);
					RecalculaTaxaDeServico();
					View.AjustarTotalPedido(_pedido.TotalPedido);
				}
			}
		}

		private void View_AumentarQuantidadeClicked(object sender, EventArgs e)
		{
			ItemPedido item = sender as ItemPedido;

			if (item != null)
			{
				item.Quantidade++;
				item.Preco = (item.Unitario * (Decimal)item.Quantidade);

				if (item.ItensAdicionais.Count > 0)
				{
					foreach (ItemAdicional adicional in item.ItensAdicionais)
					{
						item.Preco += (adicional.Valor * (decimal)item.Quantidade);
					}
				}

				View.RedesenharLista(_pedido.ItensPedido);

				_pedido.ResetarTotalManual();

				RecalculaTaxaDeServico();

				View.AjustarTotalPedido(_pedido.TotalPedido);
			}
		}

		private void View_TaxaChanged(object sender, EventArgs e)
		{
			TextBox tbTaxa = sender as TextBox;

			if (tbTaxa != null)
			{
				decimal taxa;
				decimal.TryParse(tbTaxa.Text, out taxa);

				if (_pedido.TaxaDeServico > 0)
				{
					_pedido.TaxaDeServico = (taxa - _pedido.TaxaDeEntrega);
				}
				else
				{
					_pedido.TaxaDeEntrega = taxa;
				}

				View.AjustarTotalPedido(_pedido.TotalPedido);
			}
		}

		private void View_ProdutosTextChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;

			if (comboBox != null)
			{
				if (comboBox.Text.Length > 0)
				{
					string text = comboBox.Text.ToUpper();
					var search = from p in _produtosString where p.Contains(text) select p;

					if (search.Count() > 0)
					{
						comboBox.Items.Clear();
						comboBox.Items.AddRange(search.ToArray());

						View.ShowDropDown();

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
						View.HideDropDown();

						comboBox.Items.Clear();
						comboBox.SelectionStart = text.Length;
						comboBox.SelectionLength = 0;
					}
				}
				else
				{
					View.HideDropDown();

					comboBox.Items.Clear();

					if (_produtosString != null)
					{
						comboBox.Items.AddRange(_produtosString.ToArray());
					}
				}
			}
		}

		private void View_CadastroDeObservacoesClicked(object sender, EventArgs e)
		{
			if (_usuario.NivelUsuario.Administrador)
			{
				if (_cadObservacoes == null)
				{
					_cadObservacoes = new frmCadObservacoes(_dsoftBd, _usuario, View);

					_cadObservacoes.FormClosing += new FormClosingEventHandler((obj, ev) =>
					{
						_cadObservacoes = null;
					});

					_cadObservacoes.Show();
				}
				else
				{
					_cadObservacoes.Focus();
				}
			}
		}

		private void View_ConsultaPrecosClicked(object sender, EventArgs e)
		{
			frmConsultaPrecos form = new frmConsultaPrecos(_dsoftBd, _usuario, _pedido.Tabela, View);
			form.Show();
		}

		private void View_ShowDetailsClicked(object sender, EventArgs e)
		{
			if (_pedido != null)
			{
				PedidoDetalhado form = new PedidoDetalhado(_dsoftBd, _usuario);
				form.Pedido = _pedido;
				form.Show();
			}
		}

		public void ImprimirProdutosPeriodo(DateTime inicial, DateTime final)
		{
			DataSet ds = new DataSet();

			_dsoftBd.ProdutosPeriodoAsync(inicial, final).ContinueWith((task) =>
				{
					if (task.IsFaulted || task.Result == null)
						return;

					DataTable dt = task.Result;

					Impressora.ImprimirBuffer("PRODUTOS POR PERIODO\nDE: " + inicial.ToShortDateString() + " ATE " + final.ToShortDateString());
					Impressora.ImprimirBuffer("\n------------------------------------------------\n");

					foreach (DataRow r in dt.Rows)
					{
						Impressora.ImprimirBuffer(r["produto"].ToString().PadLeft(4) + "   " + Util.Formata(Util.LimparCaracteresEspeciais(r["nome"].ToString()), 36) + r["quantidade"].ToString().PadLeft(5) + "\n");
					}

					Impressora.ImprimirBuffer("------------------------------------------------\n");

					Impressora.ImprimirBuffer();
				});
		}

		private void CarregarItensAdicionais()
		{
			List<ItemAdicional> itens_adicionais = _dsoftBd.CarregarItensAdicionais();

			View.PreencherItensAdicionais(itens_adicionais);
		}

		private void CarregarProdutos()
		{
			View.BloquearProdutos();

			_dsoftBd.CarregarProdutosAsync().ContinueWith((task) =>
				{
					if (task.IsFaulted)
						return;

					_produtos = task.Result;

					_produtosString = new List<string>();
					_produtosNome = new List<string>();
					_produtosPrecos = new Dictionary<Produto, decimal>();

					if (_produtos != null)
					{
						foreach (Produto prod in _produtos)
						{
							_produtosString.Add(prod.ToString());
							_produtosNome.Add(prod.Nome);
							_produtosPrecos.Add(prod, (decimal)_dsoftBd.ProdutoPreco(prod.Codigo, _tabela.Codigo));

							//View.CarregarProduto(prod.ToString());
						}

						View.CarregarProdutos(_produtosString.ToArray());
					}

					if (this.Finished)
						return;

					View.LiberarProdutos();
				});
		}

		private void RefreshView(bool reset = true)
		{
			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				_dsoftBd.PedidosSemFechamentoAsync().ContinueWith((task) =>
					{
						if (task.Exception == null)
						{
							if (task.Result != null)
							{
								View.SetDataSource(task.Result, reset);
							}
						}
					});
			}
			else
			{
				_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.Exception == null)
					{
						if (task.Result != null && !Finished)
						{
							View.SetDataSource(task.Result, reset);
						}
					}
				});
			}
		}

		private void RemontarLista()
		{
			View.LimparLista();

			foreach (ItemPedido item in _pedido.ItensPedido)
			{
				View.AdicionarItem(item, _pedido.TotalPedido);

				foreach (ItemAdicional adicional in item.ItensAdicionais)
				{
					View.AdicionarItem(adicional, _pedido.TotalPedido);
				}

				if (item.Observacao != string.Empty)
				{
					View.AdicionarItem(item.Observacao, _pedido.TotalPedido);
				}
			}
		}

		private void AgruparProdutos()
		{
			Dictionary<ItemPedido, int> itens_tipo = new Dictionary<ItemPedido, int>();

			foreach (ItemPedido item in _pedido.ItensPedido)
			{
				itens_tipo.Add(item, _dsoftBd.ProdutoTipo(item.Produto));
			}

			_pedido.ItensPedido.Clear();

			foreach (var item in itens_tipo.OrderBy(a => a.Value))
			{
				_pedido.ItensPedido.Add(item.Key);
			}

			_pedido.ResetarNumeros();
		}

		private void View_AlterarTotalPedido(object sender, EventArgs e)
		{
			_pedido.TotalPedido = (decimal)sender;
		}

		private void View_CancelarClicked(object sender, EventArgs e)
		{
			if (_pedido.Situacao == 'A')
			{
				Usuario usuario_alteracao = _usuario;

				if (!_usuario.NivelUsuario.Administrador && !_usuario.NivelUsuario.CancelarPedidos)
				{
					frmUsuarioAutorizacao form = new frmUsuarioAutorizacao(_dsoftBd, _usuario);

					if (form.ShowDialog() == DialogResult.Cancel || form.UsuarioAutorizado == null)
					{
						return;
					}

					if (!form.UsuarioAutorizado.NivelUsuario.Administrador && !form.UsuarioAutorizado.NivelUsuario.CancelarPedidos)
					{
						MessageBox.Show("Usuário não tem permissão para cancelar pedidos.");
						return;
					}

					usuario_alteracao = form.UsuarioAutorizado;
				}

				if (RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento)
				{
					frmMotivo form = new frmMotivo();

					if (form.ShowDialog() == DialogResult.OK)
					{
						_dsoftBd.CancelarPedido(_pedido.Numero, form.Motivo, usuario_alteracao.Codigo);
					}
				}
				else
				{
					DialogResult d = MessageBox.Show("Confirma o cancelamento do pedido?", Titulo,
						MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

					if (d == DialogResult.Yes && _dsoftBd.CancelarPedido(_pedido.NumeroPedido(), "", usuario_alteracao.Codigo))
					{
						//Sync
						//if (RegrasDeNegocio.Ramo() == "LOJA" && Matriz.Sincroniza())
						//{
						//    Sync.CancelaVenda((Pedido)PedidoAtual, _usuario.Autorizado);
						//}
					}
				}
			}
			else
			{
				DialogResult d = MessageBox.Show("Confirma a reativação do pedido?", Titulo,
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

				if (d == DialogResult.Yes && _dsoftBd.ReativarPedido(_pedido.NumeroPedido()))
				{

				}
			}

			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				_dsoftBd.PedidosSemFechamentoAsync().ContinueWith((task) =>
					{
						if (task.Result != null && !Finished)
						{
							View.SetDataSource(task.Result, false);
						}
					});
			}
			else
			{
				_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.Result != null && !Finished)
					{
						View.SetDataSource(task.Result, false);
					}
				});
			}

			View.ViewClean();
		}

		private void View_CarregarDadosCliente(object sender, EventArgs e)
		{
			string cliente = (sender as TextBox).Text;
			long codigo;

			if (cliente == string.Empty)
			{
				View.DefinirDadosCliente("Cliente não identificado.", "", "", !RegrasDeNegocio.Instance.BloqueiaClienteAnonimo);
				return;
			}

			if (!long.TryParse(cliente, out codigo))
			{
				if (!cliente.Contains('*'))
				{
					MessageBox.Show("Cliente inválido! Código deve ser numérico.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					View.DefinirDadosCliente("Cliente inválido!", "", "", false);
					return;
				}
				else
				{
					codigo = _dsoftBd.ClienteCodigoAuxiliar(cliente);
				}
			}

			Cliente Cliente = new Cliente(codigo);

			int pedido = _dsoftBd.UltimoPedidoAberto(Cliente);

			if (pedido > 0)
			{
				if (MessageBox.Show("Cliente possui um pedido em aberto. Deseja abrir o pedido?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
					== DialogResult.Yes)
				{
					CarregarPedido(pedido);

					return;
				}
			}

			if (!_dsoftBd.CarregarDadosCliente(Cliente))
			{
				if (Cliente.Codigo > 0)
				{
					List<Cliente> busca = _dsoftBd.BuscaClientePorTelefone(Cliente.Codigo);

					if (busca != null && busca.Count > 0)
					{
						//Caso somente um cliente possua o telefone no cadastro, abrimos direto, sem precisar de confirmação
						if (busca.Count == 1)
						{
							View.SetCodigoCliente(busca[0].Codigo);
							return;
						}
						else
						{
							if (MessageBox.Show("Código não encontrado, mas existem clientes com este número de telefone cadastrado. Gostaria de abrir estes clientes?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
								== DialogResult.Yes)
							{
								BuscaClientePorTelefone form = new BuscaClientePorTelefone(_dsoftBd, _usuario, Cliente.Codigo);
								form.ShowDialog();

								if (form.Cliente != null)
								{
									View.SetCodigoCliente(form.Cliente.Codigo);
									return;
								}
							}
						}
					}
				}

				if (MessageBox.Show("Código não encontrado! Deseja cadastrar um novo cliente?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
					== DialogResult.Yes)
				{
					View_OpenCadClientes(sender, e);
					return;
				}
				else
				{
					View.DefinirDadosCliente("Cliente inválido!", "", "", false);
					return;
				}
			}

			if (Cliente.Situacao == 'B')
			{
				MessageBox.Show("Cliente bloqueado! Operação não permitida para o cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				View.DefinirDadosCliente("Cliente bloqueado!", "", "", false);
				return;
			}
			else if (Cliente.Situacao == 'C')
			{
				MessageBox.Show("Cliente cancelado! Operação não permitida para o cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				View.DefinirDadosCliente("Cliente cancelado!", "", "", false);
				return;
			}

			_pedido.ClientePedido(codigo);

			View.DefinirDadosCliente(Cliente.Nome, Cliente.Endereco, Cliente.Bairro);

			CarregarHistorico(Cliente);

			if (Cliente.Tabela != null)
			{
				View.DefinirTabela((int)Cliente.Tabela);
			}

			if (Cliente.Saldo != 0)
			{
				View.MostrarSaldo(Cliente.Saldo);
			}
			else
			{
				View.OcultarSaldo();
			}

			CarregarTaxaDeEntregaEServico(Cliente);
		}

		private void CarregarTaxaDeEntregaEServico(Cliente cliente)
		{
			//if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
			//{

			if (_pedido.Retirar == false)
			{
				_pedido.TaxaDeEntrega = _dsoftBd.TaxaEntregaGrupoClientes(cliente.Grupo);
			}

			_pedido.PorcentagemServico = _dsoftBd.TaxaDeServicoGrupoClientes(cliente.Grupo);

			if (RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente && _dsoftBd.TaxaDeEntrega(cliente) > 0 && _pedido.Retirar == false)
			{
				_pedido.TaxaDeEntrega = _dsoftBd.TaxaDeEntrega(cliente);
			}

			if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
			{
				View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega + _pedido.TaxaDeServico, true);
			}
			else
			{
				View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega + _pedido.TaxaDeServico);
			}

			View.AjustarTotalPedido(_pedido.TotalPedido);
			//}
		}

		private void CarregarHistorico(Cliente cliente)
		{
			Dictionary<int, DateTime> historico = _dsoftBd.UltimosPedidos(cliente, 3);

			if (historico == null || historico.Count == 0)
			{
				View.MostrarHistorico("Cliente não possui pedidos no histórico.");
			}
			else
			{
				StringBuilder builder = new StringBuilder();
				builder.AppendLine("Últimos pedidos do cliente: ");

				foreach (var dt in historico)
				{
					builder.AppendLine(dt.Value.ToShortDateString());
				}

				View.MostrarHistorico(builder.ToString());
			}
		}

		private void View_CarregarPedidosAnteriores(object sender, EventArgs e)
		{
			_dsoftBd.PedidosListaAsync(_primeiroPedido).ContinueWith((task) =>
			{
				if (task.Result != null && !Finished)
				{
					_primeiroPedido = Convert.ToInt32(task.Result.Tables[0].Rows[0].ItemArray[0]);

					View.AddRows(task.Result.Tables[0]);
				}
			});
		}

		private void View_ConfirmarItemClicked(object sender, EventArgs e)
		{
			if (!_pedido.isItemValid)
				return;

			if (_usuario.Recurso == null)
			{
				MessageBox.Show("Usuário precisa estar vinculado a um Recurso para poder realizar esta operação.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			ItemPedido item = new ItemPedido();
			item.Numero = _pedido.ItensPedido.Count() + 1;
			item.Produto = _pedido.Produto;
			item.ProdutoNome = _dsoftBd.ProdutoNome(_pedido.Produto);
			item.Quantidade = _pedido.Quantidade;
			item.Preco = _pedido.TotalProduto();
			item.Unitario = _pedido.Valor;
			item.Situacao = 'A';
			item.Observacao = View.ObservacaoItem().Trim();
			item.Recurso = _usuario.Recurso.Codigo;
			item.ItensAdicionais = new List<ItemAdicional>(_pedido.ItensAdicionais);

			foreach (ItemPedido i in _pedido.ItensPedido)
			{
				if (i.Quantidade % 1 == 0)
				{
					if (i.Equals(item))
					{
						i.Quantidade += item.Quantidade;
						i.Preco += item.Preco;

						RemontarLista();
						RecalculaTaxaDeServico();

						_pedido.ResetarTotalManual();

						View.DefinirTotal(_pedido.TotalPedido);

						return;
					}
				}
			}

			_pedido.NovoItem(item);

			if (RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
			{
				AgruparProdutos();
				View.RedesenharLista(_pedido.ItensPedido);
			}
			else
			{
				View.AdicionarItem(item, _pedido.TotalPedido);

				foreach (ItemAdicional ad in item.ItensAdicionais)
				{
					View.AdicionarItem(ad, _pedido.TotalPedido);
				}
			}

			View.ClearFields();

			RecalculaTaxaDeServico();

			_pedido.ResetarTotalManual();

			View.DefinirTotal(_pedido.TotalPedido);

			_pedido.LimpaAtual();
		}

		private void RecalculaTaxaDeServico()
		{
			if (_pedido.PorcentagemServico > 0)
			{
				bool bloqueia = true;

				if (_usuario.NivelUsuario.Administrador)
					bloqueia = false;

				View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega + _pedido.TaxaDeServico, bloqueia);
			}
		}

		private void View_DefinirDataRaised(object sender, EventArgs e)
		{
			if (_usuario.Nivel != 'A')
			{
				MessageBox.Show("Operação não autorizada!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			frmData form = new frmData();

			form.Titulo = "Data do Pedido";

			if (form.ShowDialog() == DialogResult.OK)
				_pedido.Data = form.Data.Date;
		}

		private void View_DescontoChanged(object sender, EventArgs e)
		{
			string sdesconto = (sender as TextBox).Text;
			decimal desconto;

			if (sdesconto.Length < 1)
				return;

			if (!decimal.TryParse(sdesconto, out desconto))
				desconto = 0;

			_pedido.Desconto = desconto;

			View.DefinirPreco(_pedido.TotalProduto());
		}

		private void View_EntregarClicked(object sender, EventArgs e)
		{
			//frmEntregas form = new frmEntregas(_dsoftBd, _usuario);

			//form.NumeroPedido = PedidoAtual.NumeroPedido();

			//form.ShowDialog();

			frmEntregaRapida form = new frmEntregaRapida(_dsoftBd, _usuario, _pedido);
			form.ShowDialog();

			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				_dsoftBd.PedidosSemFechamentoAsync().ContinueWith((task) =>
					{
						if (task.Result != null && !Finished)
						{
							View.SetDataSource(task.Result, false);
						}
					});
			}
			else
			{
				_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.Result != null && !Finished)
					{
						View.SetDataSource(task.Result, false);
					}
				});
			}

			View.ViewClean();
		}

		private void View_EventNew(object sender, EventArgs e)
		{
			_pedido = new PedidosModel();

			_pedido.Tabela = _tabela;

			View.PrepareNew();
		}

		private void View_EventSubmit(object sender, EventArgs e)
		{
			GravarPedido();
		}

		private void GravarPedido()
		{
			string mensagem_impressao;

			if (_pedido.ItensQtd < 1)
			{
				MessageBox.Show("O Pedido não pode estar vazio!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			if (RegrasDeNegocio.Instance.BloqueiaClienteAnonimo && _pedido.Cliente == 0)
			{
				MessageBox.Show("Cliente precisa ser identificado!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			_pedido.Troco = View.Troco();
			_pedido.Observacao = View.Observacao();

			if (RegrasDeNegocio.Instance.ObservacaoObrigatoriaNoPedido)
			{
				if (_pedido.Cliente > 0 && !_dsoftBd.ClienteInterno(_pedido.Cliente))
				{
					frmSelecionarObservacao form = new frmSelecionarObservacao(_dsoftBd, _usuario, _pedido.Observacao);

					if (form.ShowDialog() == DialogResult.Cancel || form.Observacoes == null || form.Observacoes.Length == 0)
					{
						return;
					}

					_pedido.Observacao = form.Observacoes;

					if (_pedido.Observacao.Contains("DINHEIRO") && _pedido.Troco == 0)
					{
						frmTroco fTroco = new frmTroco();

						if (fTroco.ShowDialog() == DialogResult.OK)
						{
							_pedido.Troco = fTroco.Troco();
						}
					}
				}
			}

			_pedido.Usuario = _usuario.Codigo;

			if (_pedido.Numero == 0)
			{
				// Caso seja especificado nas Regras de Negócio, capturamos o código do vendedor
				if (RegrasDeNegocio.Instance.RegistraVendedor)
				{
					CapturaCodigo form = new CapturaCodigo("Captura de código do vendedor", "Digite o código do vendedor:");

					if (form.ShowDialog() == DialogResult.OK)
					{
						Recurso vendedor = _dsoftBd.CarregarRecurso(Convert.ToInt32(form.Codigo));

						if (vendedor != null)
						{
							_pedido.Vendedor = vendedor;
						}
						else
						{
							MessageBox.Show("Código de vendedor inválido! Não foi possível confirmar o pedido.");
							return;
						}
					}
					else
					{
						return;
					}
				}
				else
				{
					_pedido.Vendedor = _usuario.Recurso;
				}

				if ((_pedido.Numero = _dsoftBd.NovoPedido(_pedido, _usuario.Codigo, Caixa.Numero)) > 0)
				{
					// Caso não seja especificado o cliente, fazemos o pagamento instantaneamente
					// Caso o ramo de negócios seja "LOJA", faz o pagamento automaticamente tambem
					if (_pedido.ClientePedido() == 0 || RegrasDeNegocio.Instance.Ramo == "LOJA" || RegrasDeNegocio.Instance.Ramo == "ESCOLA"
						|| RegrasDeNegocio.Instance.PagamentoNoLancamento)
					{
						CaixaSimples form = new CaixaSimples(_dsoftBd, _usuario, _pedido);

						form.Valor = _pedido.Valor;

						StringBuilder builder = new StringBuilder();

						foreach (ItemPedido item in _pedido.ItensPedido)
						{
							builder.AppendLine(item.ToString());

							foreach (ItemAdicional adicional in item.ItensAdicionais)
							{
								builder.AppendLine(adicional.ToString());
							}

							if (item.Observacao != string.Empty)
							{
								builder.AppendLine(item.Observacao);
							}
						}

						form.Referencia = builder.ToString();

						//form.NumeroPedido = PedidoAtual.Numero;

						if (form.ShowDialog() == DialogResult.OK)
						{
							//PedidoAtual.Debito = form.Debito;

							_pedido.Situacao = _dsoftBd.PedidoSituacao(_pedido.Numero);

							// No caso de "PIZZARIA" fazemos a entrega simultaneamente
							if ((RegrasDeNegocio.Instance.Ramo == "PIZZARIA" || !RegrasDeNegocio.Instance.ControlaEntregas) && !_dsoftBd.EntregaPedido(_pedido.NumeroPedido(), _usuario.Autorizado))
							{
								MessageBox.Show("Houve um erro ao efetuar a entrega dos produtos!" + Environment.NewLine + "Entre em contato com o suporte.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
					}

					//Sync
					if (RegrasDeNegocio.Instance.Ramo == "LOJA" && Matriz.Sincroniza())
					{
						Sync.NovaVenda(_pedido, _usuario.Autorizado);
					}

					if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA" || RegrasDeNegocio.Instance.Ramo == "ESCOLA")
						mensagem_impressao = "Imprime ticket?";
					else
						mensagem_impressao = "Imprime Orçamento?";

					if (MessageBox.Show(mensagem_impressao, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Caixa caixa = new Caixa();

						caixa.Codigo = Caixa.Numero;
						caixa.Descricao = _dsoftBd.CaixaDescricao(caixa.Codigo);

						if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA" || RegrasDeNegocio.Instance.Ramo == "ESCOLA")
						{
							Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, true, Terminal.Impressora());

							if ((Terminal.Imprime2Via() && (_pedido.Cliente == 0 || !_dsoftBd.ClienteInterno(_pedido.Cliente))) || (RegrasDeNegocio.Instance.DuasViasNoBalcao && (_pedido.Cliente == 0 || _pedido.Retirar)))
							{
								Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, false, Terminal.Impressora());
							}
						}
						else
						{
							DemPedido dem = new DemPedido();
							dem.Gerar(_dsoftBd, _pedido);
						}
					}

					View.ViewClean();

					RefreshView();
				}
			}
			else
			{
				if (AlterarPedido())
				{
					View.ViewClean();

					RefreshView();
				}
			}
		}

		private bool AlterarPedido()
		{
			Usuario usuario_alteracao = _usuario;

			if (_pedido.Equals(_pedidoOriginal))
			{
				return true;
			}

			if (_pedido.AlterouCliente(_pedidoOriginal))
			{
				if (!_usuario.NivelUsuario.Administrador && !_usuario.NivelUsuario.AlterarClienteDoPedido)
				{
					frmUsuarioAutorizacao form = new frmUsuarioAutorizacao(_dsoftBd, _usuario);

					if (form.ShowDialog() == DialogResult.Cancel || form.UsuarioAutorizado == null)
					{
						return false;
					}

					if (!form.UsuarioAutorizado.NivelUsuario.Administrador && !form.UsuarioAutorizado.NivelUsuario.AlterarClienteDoPedido)
					{
						MessageBox.Show("Usuário não tem permissão para alterar cliente do pedido.");
						return false;
					}

					usuario_alteracao = form.UsuarioAutorizado;
				}
			}

			if (_pedidoOriginal.ApenasAdicionou(_pedido) == false)
			{
				if (!_usuario.NivelUsuario.Administrador && !_usuario.NivelUsuario.AlterarPedidos)
				{
					frmUsuarioAutorizacao form = new frmUsuarioAutorizacao(_dsoftBd, _usuario);

					if (form.ShowDialog() == DialogResult.Cancel || form.UsuarioAutorizado == null)
					{
						return false;
					}

					if (!form.UsuarioAutorizado.NivelUsuario.Administrador && !form.UsuarioAutorizado.NivelUsuario.AlterarPedidos)
					{
						MessageBox.Show("Usuário não tem permissão para alterar pedidos.");
						return false;
					}

					usuario_alteracao = form.UsuarioAutorizado;
				}
			}

			if (_dsoftBd.AlterarPedido(_pedido, usuario_alteracao))
			{
				//Sync
				if (RegrasDeNegocio.Instance.Ramo == "LOJA" && Matriz.Sincroniza())
				{
					Sync.AlteraVenda(_pedido, usuario_alteracao.Autorizado);
				}

				if (_pedido.Cliente > 0 && _dsoftBd.ClienteInterno(_pedido.Cliente))
				{
					List<ItemPedido> novosItens = new List<ItemPedido>();

					foreach (ItemPedido item in _pedido.ItensPedido)
					{
						if (!_pedidoOriginal.ItensPedido.Contains(item))
						{
							novosItens.Add(item);
						}
						else
						{
							ItemPedido itemOriginal = _pedidoOriginal.ItensPedido[_pedidoOriginal.ItensPedido.IndexOf(item)];

							if (itemOriginal.Quantidade != item.Quantidade)
							{
								ItemPedido itemParaAdicionar = (ItemPedido)item.Clone();
								itemParaAdicionar.Quantidade = item.Quantidade - itemOriginal.Quantidade;

								novosItens.Add(itemParaAdicionar);
							}
						}
					}

					if (novosItens.Count > 0)
					{
						if (MessageBox.Show("Imprimir produção?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
							== DialogResult.Yes)
						{
							Impressora.ImprimirProducao(_dsoftBd, _pedido, novosItens, _usuario);
						}
					}

					_pedidoOriginal = (Pedido)_pedido.Clone();
				}

				return true;
			}
			else
			{
				return false;
			}
		}

		private void View_ExcluirItemClicked(object sender, EventArgs e)
		{
			if (sender is ItemPedido)
			{
				ItemPedido itemPedido = sender as ItemPedido;

				_pedido.ItensPedido.RemoveAll(i => i.Numero == itemPedido.Numero);

				_pedido.ResetarNumeros();
				_pedido.ResetarTotalManual();

				RemontarLista();

				RecalculaTaxaDeServico();
				View.AjustarTotalPedido(_pedido.TotalPedido);
			}
			else if (sender is ItemAdicional)
			{

			}
		}

		private void View_HistoricoClienteRaised(object sender, EventArgs e)
		{
			if (_pedido.Cliente < 1)
				return;

			frmConPedidosCliente form = new frmConPedidosCliente(_dsoftBd, _usuario);

			form.Cliente = _pedido.Cliente;

			form.ShowDialog();
		}

		private void View_Initialize(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				_dsoftBd.PedidosSemFechamentoAsync().ContinueWith((task) =>
					{
						if (task.Result != null)
						{
							View.SetDataSource(task.Result, true);
						}
					});
			}
			else
			{
				_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.Result != null && !Finished)
					{
						if (task.Result.Tables[0].Rows.Count > 0)
						{
							_primeiroPedido = Convert.ToInt32(task.Result.Tables[0].Rows[0].ItemArray[0]);
						}
						else
						{
							_primeiroPedido = 0;
						}

						View.SetDataSource(task.Result, true);
					}
				});
			}

			_calendario = _dsoftBd.CarregarCalendarioDeTabelas();
			_tabelasDePrecos = _dsoftBd.CarregarTabelas();
			View.DefinirTabelas(_tabelasDePrecos);

			if (!RegrasDeNegocio.Instance.ItensAdicionaisPorProduto && !RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
			{
				CarregarItensAdicionais();
			}

			if (_calendario.Gerencia)
			{
				View.PermitirTabelasDePrecos(false);

				switch (DateTime.Now.DayOfWeek)
				{
					case DayOfWeek.Sunday:
						View.DefinirTabela(_calendario.Domingo);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Domingo);
						break;

					case DayOfWeek.Monday:
						View.DefinirTabela(_calendario.Segunda);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Segunda);
						break;

					case DayOfWeek.Tuesday:
						View.DefinirTabela(_calendario.Terca);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Terca);
						break;

					case DayOfWeek.Wednesday:
						View.DefinirTabela(_calendario.Quarta);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Quarta);
						break;

					case DayOfWeek.Thursday:
						View.DefinirTabela(_calendario.Quinta);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Quinta);
						break;

					case DayOfWeek.Friday:
						View.DefinirTabela(_calendario.Sexta);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Sexta);
						break;

					case DayOfWeek.Saturday:
						View.DefinirTabela(_calendario.Sabado);
						_tabela = _tabelasDePrecos.FirstOrDefault(t => t.Codigo == _calendario.Sabado);
						break;
				}
			}

			CarregarProdutos();
			CarregarObservacoes();

			View.Loaded();
		}

		private void CarregarObservacoes()
		{
			List<string> observacoes = _dsoftBd.CarregarObservacoes();
			View.DefinirObservacoes(observacoes);
		}

		private void View_ItemAdicionalClicked(object sender, EventArgs e)
		{
			ListBox list = sender as ListBox;

			if (list != null)
			{
				ItemAdicional item = list.SelectedItem as ItemAdicional;

				if (item != null)
				{
					if (e == null || ((ItemCheckEventArgs)e).NewValue == CheckState.Checked)
					{
						_pedido.ItensAdicionais.Add(item);
					}
					else
					{
						_pedido.ItensAdicionais.Remove(item);
					}

					View.DefinirPreco(_pedido.TotalProduto());
				}
			}
		}

		private void View_ItemTresTercosClicked(object sender, EventArgs e)
		{
			var lista = from l in _produtos where l.ProdutoTipo.Fracionado == true select l;

			frmNovoItemTerco form = new frmNovoItemTerco(_dsoftBd, _usuario, _pedido.Tabela, lista.ToList(), _produtosPrecos, _pedido.Produto);

			if (form.ShowDialog() == DialogResult.OK)
			{
				_pedido.NovoItem(form.Itens[0], form.Itens[1], form.Itens[2]);

				if (RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
				{
					AgruparProdutos();
					View.RedesenharLista(_pedido.ItensPedido);
					View.ClearFields();
					View.DefinirTotal(_pedido.TotalPedido);
				}
				else
				{
					View.AdicionarItem(form.Itens[0], 0);
					View.AdicionarItem(form.Itens[1], _pedido.TotalPedido);
					View.AdicionarItem(form.Itens[2], _pedido.TotalPedido);
				}
			}
		}

		private void View_LimparPedidoClicked(object sender, EventArgs e)
		{
			_pedido.Limpa();
			_pedido.Tabela = _tabela;

			View.CarregarProdutos(_produtosString.ToArray());

			_totalAdicionais = 0;
		}

		private void View_LimparListaClicked(object sender, EventArgs e)
		{
			_pedido.ItensPedido.Clear();

			_totalAdicionais = 0;
		}

		private void View_OpenCadClientes(object sender, EventArgs e)
		{
			string _cliente = (sender as TextBox).Text;
			long? codigo = null;

			if (_cliente.Length > 0)
			{
				long l;

				if (long.TryParse(_cliente, out l))
				{
					codigo = l;
				}
			}

			if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA")
			{
				frmCadRapido form = new frmCadRapido(_dsoftBd, _usuario);

				if (codigo != null)
				{
					form.Codigo = (long)codigo;
				}
				else if (_cliente.Contains('*'))
				{
					form.Auxiliar = _cliente;
				}

				if (form.ShowDialog() == DialogResult.OK && form.Cliente != null)
				{
					_pedido.Cliente = form.Cliente.Codigo;
				}
			}
			else
			{
				CadClientes form = new CadClientes(_dsoftBd, _usuario, Licenca.Instance, consulta: true, codigo: codigo, scodigo: _cliente);
				form.ShowDialog();
			}

			if (_pedido.Cliente > 0)
			{
				View.SetCodigoCliente(_pedido.Cliente);
			}
		}

		private bool PedidoAlterado()
		{
			return !_pedido.Equals(_pedidoOriginal);
		}

		private void View_PagarClicked(object sender, EventArgs e)
		{
			if (PedidoAlterado())
			{
				GravarPedido();
			}

			if (_pedido.TotalPedido == 0)
			{
				if (_dsoftBd.PagarPedidoZerado(_pedido, _usuario))
				{
					BaixaPagamento();
				}
			}
			else
			{
				CaixaSimples form = new CaixaSimples(_dsoftBd, _usuario, _pedido);

				StringBuilder builder = new StringBuilder();

				foreach (ItemPedido item in _pedido.ItensPedido)
				{
					builder.AppendLine(item.ToString());

					foreach (ItemAdicional adicional in item.ItensAdicionais)
					{
						builder.AppendLine(adicional.ToString());
					}

					if (item.Observacao != string.Empty)
					{
						builder.AppendLine(item.Observacao);
					}
				}

				if (_pedido.TaxaDeEntrega > 0)
				{
					builder.AppendLine("TAXA DE ENTREGA R$ " + _pedido.TaxaDeEntrega.ToString("##,##0.00"));
				}

				form.Referencia = builder.ToString();

				if (form.ShowDialog() == DialogResult.OK)
				{
					BaixaPagamento();
				}
			}
		}

		private void BaixaPagamento()
		{
			_pedido.Situacao = _dsoftBd.PedidoSituacao(_pedido.Numero);

			if (RegrasDeNegocio.Instance.EntregaAutomaticaClientesInternosPagamento)
			{
				if (_pedido.Cliente == 0 || _pedido.Retirar || _dsoftBd.ClienteInterno(_pedido.Cliente) || _pedido.Situacao == 'O')
				{
					if (_pedido.Situacao == 'N' || _pedido.Situacao == 'O')
					{
						if (_dsoftBd.EntregaPedido(_pedido.Numero, _usuario.Codigo))
						{
							_pedido.Situacao = 'P';
						}
					}
				}
			}

			if (RegrasDeNegocio.Instance.ControlaEntregas == false)
			{
				if (_pedido.Situacao == 'N' || _pedido.Situacao == 'O')
				{
					_dsoftBd.EntregaPedido(_pedido.Numero, _usuario.Codigo);
				}
			}

			//Clientes internos, imprimimos comanda no pagamento
			if (_pedido.Cliente == 0 || _dsoftBd.ClienteInterno(_pedido.Cliente))
			{
				if (MessageBox.Show("Imprimir comanda?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
					== DialogResult.Yes)
				{
					View_ReimprimirClicked(null, null);
				}
			}

			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				_dsoftBd.PedidosSemFechamentoAsync().ContinueWith((task) =>
				{
					if (task.Result != null && !Finished)
					{
						View.SetDataSource(task.Result, false);
					}
				});
			}
			else
			{
				_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.Result != null && !Finished)
					{
						View.SetDataSource(task.Result, false);
					}
				});
			}

			View.ViewClean();
		}

		private void View_PedidoClicked(object sender, EventArgs e)
		{
			int numero = (int)sender;

			CarregarPedido(numero);
		}

		private void CarregarPedido(int numero)
		{
			View.PrepareNew();

			Pedido pedido = new Pedido();

			if (!_dsoftBd.CarregarPedido(numero, pedido))
				return;

			_pedido = pedido;
			_pedidoOriginal = (Pedido)pedido.Clone();

			if (_pedido.Cliente == 0)
			{
				View.DefinirDadosCliente("Cliente não identificado.", "", "");
				View.MostrarHistorico(string.Empty);
			}
			else
			{
				Cliente cliente = new Cliente(_pedido.Cliente);

				if (!_dsoftBd.CarregarDadosCliente(cliente))
				{
					MessageBox.Show("Cliente inválido! Código não encontrado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					View.DefinirDadosCliente("Cliente inválido!", "", "", false);
					View.MostrarHistorico(string.Empty);
				}
				else
				{
					if (cliente.Situacao == 'B')
					{
						MessageBox.Show("Cliente bloqueado! Operação não permitida para o cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						View.DefinirDadosCliente("Cliente bloqueado!", "", "", false);
						return;
					}
					else if (cliente.Situacao == 'C')
					{
						MessageBox.Show("Cliente cancelado! Operação não permitida para o cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						View.DefinirDadosCliente("Cliente cancelado!", "", "", false);

						return;
					}

					View.DefinirDadosCliente(cliente.Codigo, cliente.Nome, cliente.Endereco, cliente.Bairro);

					CarregarHistorico(cliente);

					if (_pedido.TaxaDeEntrega > 0)
					{
						View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega);
					}
					else
					{
						CarregarTaxaDeEntregaEServico(cliente);
					}
				}
			}

			foreach (ItemPedido item in _pedido.ItensPedido)
			{
				View.AdicionarItem(item, _pedido.TotalPedido);

				foreach (ItemAdicional adicional in item.ItensAdicionais)
				{
					View.AdicionarItem(adicional, _pedido.TotalPedido);
				}

				if (item.Observacao != string.Empty)
				{
					View.AdicionarItem(item.Observacao, _pedido.TotalPedido);
				}
			}

			View.DefinirObservacao(_pedido.Observacao);

			View.DefinirRetirar(_pedido.Retirar);

			if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
			{
				View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega, true);
			}
			else
			{
				View.DefinirTaxaEntrega(_pedido.TaxaDeEntrega);
			}

			RecalculaTaxaDeServico();

			View.DefinirTroco(_pedido.Troco);
			View.DefinirTotal(_pedido.TotalPedido);
			View.PreencherPedido(_pedido.Situacao);

			if (_pedido.Situacao == 'A')
			{
				View.HabilitaPedido();
				View.TrocarClienteVisivel(true);
			}
			else
			{
				if (_pedido.Situacao == 'N' || _pedido.Situacao == 'O' || _pedido.Situacao == 'P')
				{
					View.MostrarECF();
				}

				View.DesabilitaPedido();
			}

			if (_pedido.Situacao == 'C' && _pedido.MotivoDoCancelamento.Length > 0)
			{
				View.PreencherMotivoDoCancelamento(string.Format("* {0}", _pedido.MotivoDoCancelamento));
			}
		}

		private void View_PedidosDuplosClicked(object sender, EventArgs e)
		{
			var lista = from l in _produtos where l.ProdutoTipo.MeioAMeio == true select l;

			frmNovoItemMeio form = new frmNovoItemMeio(_dsoftBd, _usuario, _pedido.Tabela, lista.ToList(), _produtosPrecos, _pedido.Produto);

			if (form.ShowDialog() == DialogResult.OK)
			{
				_pedido.NovoItem(form.Itens[0], form.Itens[1]);

				if (RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
				{
					AgruparProdutos();
					View.RedesenharLista(_pedido.ItensPedido);
					View.ClearFields();
					View.DefinirTotal(_pedido.TotalPedido);
				}
				else
				{
					View.AdicionarItem(form.Itens[0], 0);
					View.AdicionarItem(form.Itens[1], _pedido.TotalPedido);
				}
			}
		}

		private void View_PedidosMultiplosClicked(object sender, EventArgs e)
		{
			frmPedidoFracao form = new frmPedidoFracao(_dsoftBd, _usuario);

			form.Tabela = _pedido.Tabela.Codigo;

			if (form.ShowDialog() == DialogResult.OK)
			{
				int numero = 0;

				// Primeiro adicionamos o item principal, o de maior valor
				foreach (ItemPedido item in form.Itens)
				{
					if (item.Secundario == false)
					{
						numero = _pedido.NovoItem(item);

						if (!RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
						{
							View.AdicionarItem(item, _pedido.TotalPedido);
						}

						break;
					}
				}

				// Depois adicionamos os outros itens
				foreach (ItemPedido item in form.Itens)
				{
					if (item.Secundario)
					{
						_pedido.NovoItemSecundario(item, numero);

						if (!RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
						{
							View.AdicionarItem(item, _pedido.TotalPedido);
						}
					}
				}

				if (RegrasDeNegocio.Instance.AgrupaProdutosPorTipo)
				{
					AgruparProdutos();
					_pedido.ResetarNumeros();
					View.RedesenharLista(_pedido.ItensPedido);
					View.ClearFields();
					View.DefinirTotal(_pedido.TotalPedido);
				}
			}
		}

		private void View_PrecoChanged(object sender, EventArgs e)
		{
			_pedido.Valor = (decimal)sender;
		}

		private void View_ProdutoPressed(object sender, EventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			string imagem;
			string produto = string.Empty;
			Produto prod = null;

			if (comboBox != null)
			{
				if (comboBox.SelectedItem != null)
				{
					produto = comboBox.SelectedItem.ToString();
				}
				else if (comboBox.Text.Length > 0)
				{
					if (comboBox.Items.Count > 0)
					{
						produto = comboBox.Items[0].ToString();
					}
					else
					{
						produto = comboBox.Text;
					}
				}

				if (produto == null || produto == "")
				{
					if (_pedido.ItensQtd == 0)
					{
						return;
					}
					else
					{
						View.ConfirmarFocus();
						return;
					}
				}

				if (!long.TryParse(produto.Split(" - ".ToCharArray(), 2)[0], out _pedido.Produto))
				{
					prod = _produtos.First(p => p.Nome == produto);

					if (prod != null)
					{
						_pedido.Produto = prod.Codigo;
					}
					else
					{
						_pedido.Produto = _dsoftBd.ProdutoCodigo(produto);
					}
				}

				if (_pedido.Produto > 0)
				{
					if (prod == null)
					{
						prod = _produtos.FirstOrDefault(p => p.Codigo == _pedido.Produto);

						if (prod == null)
						{
							prod = _dsoftBd.CarregarProduto(_pedido.Produto);

							if (prod == null)
							{
								return;
							}
						}
					}

					View.MostrarNomeProduto(prod.ToString());

					if ((imagem = prod.Foto) != "")
					{
						Image image = Image.FromFile(imagem);

						View.MostrarProduto(image);
					}

					if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
					{
						List<ItemAdicional> itens_adicionais = _dsoftBd.CarregarItensAdicionais(_pedido.Produto);

						View.PreencherItensAdicionais(itens_adicionais);
					}
					else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
					{
						ProdutoTipo tipo = _dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(_pedido.Produto));

						if (tipo != null)
						{
							List<ItemAdicional> itens_adicionais = _dsoftBd.CarregarItensAdicionais(tipo);
							View.PreencherItensAdicionais(itens_adicionais);
						}
					}

					View.PermitirItensAdicionais(prod.ProdutoTipo.Adicionais);

					View.LiberaEstoque();
					View.LimparAviso();

					if (prod.ProdutoTipo.Estoque)
					{
						double estoque = _dsoftBd.ProdutoEstoque(_pedido.Produto);

						if (RegrasDeNegocio.Instance.BloqueiaEstoque && estoque < 1)
						{
							View.BloqueiaEstoque();
							return;
						}

						if (RegrasDeNegocio.Instance.AvisoEstoque >= estoque)
						{
							View.AvisoEstoque(estoque);
						}
					}

					if (_tabela.Codigo == 1)
					{
						_pedido.Valor = _produtosPrecos[prod];
					}
					else
					{
						_pedido.Valor = (decimal)_dsoftBd.ProdutoPreco(prod.Codigo, _tabela.Codigo);
					}

					_pedido.Quantidade = 1;
					_pedido.Desconto = 0;
					_pedido.Divisor = 1;

					_itemPedido = new ItemPedido();

					_itemPedido.Preco = _pedido.TotalProduto();

					View.PreencherPrecoUnitario(_pedido.Valor, !RegrasDeNegocio.Instance.PrecosEmAberto);
				}
			}
		}

		void View_QuantidadeChanged(object sender, EventArgs e)
		{
			string qtd = sender as string;

			if (qtd[0] == '/')
			{
				int d;

				if (int.TryParse(new string(qtd.ToCharArray(), 1, qtd.Length - 1), out d))
				{
					_pedido.Divisor = d;
				}
			}
			else
			{
				float q;

				if (float.TryParse(qtd, out q))
				{
					_pedido.Quantidade = q;
				}
			}

			if (RegrasDeNegocio.Instance.BloqueiaEstoque
				&& _dsoftBd.ProdutoControlaEstoque(_pedido.Produto)
				&& _pedido.Quantidade > _dsoftBd.ProdutoEstoque(_pedido.Produto))
			{
				View.BloqueiaEstoque();
				return;
			}
			else
			{
				View.LiberaEstoque();
			}

			View.DefinirPreco(_pedido.TotalProduto());
		}

		void View_RefreshClicked(object sender, EventArgs e)
		{
			RefreshView();
		}

		void View_ReimprimirClicked(object sender, EventArgs e)
		{
			if (_pedido.Numero < 1 || _pedido.ItensQtd < 1)
				return;

			if (_pedido.Equals(_pedidoOriginal) == false)
			{
				if (MessageBox.Show("Confirma a gravação do pedido?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					if (!AlterarPedido())
					{
						return;
					}
				}
				else
				{
					return;
				}
			}

			_pedido.Troco = View.Troco();

			if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA" || RegrasDeNegocio.Instance.Ramo == "ESCOLA")
			{
				Caixa caixa = new Caixa();

				caixa.Codigo = Caixa.Numero;
				caixa.Descricao = _dsoftBd.CaixaDescricao(caixa.Codigo);

				Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, false, Terminal.Impressora());

				//if (Terminal.Imprime2Via())
				//{
				//    Impressora.ImprimirPedido(_pedido, caixa, _usuario.Autorizado, _dsoftBd, false, Terminal.ImpressoraDelivery);
				//}
			}
			else
			{
				DemPedido dem = new DemPedido();
				dem.Gerar(_dsoftBd, _pedido);
			}
		}

		void View_TabelaChanged(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;

			if (cb.SelectedItem != null)
			{
				_tabela = (TabelaDePrecos)cb.SelectedItem;
				_pedido.Tabela = (TabelaDePrecos)cb.SelectedItem;
			}
		}

		#endregion Methods
	}
}