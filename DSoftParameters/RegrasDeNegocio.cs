using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DSoftParameters
{
	public class RegrasDeNegocio
	{
		#region Fields

		private static RegrasDeNegocio _instance;

		private int _avisoEstoque;
		private bool _bloqueiaClienteAnonimo;
		private bool _bloqueiaEstoque;
		private bool _controlaEntregas;
		private bool _controlaProcessos;
		private bool _emiteCupomFiscal;
		private bool _entregaAutomaticaClientesInternosPagamento;
		private bool _fechaCaixaAutomaticamente;
		private int _ordemDeColetaVias;
		private string _ramo;
		private bool _registraVendedor;
		private bool _taxaEntregaPorGrupo;
		private string _termoDeResponsabilidade;
		private string _reciboDeDevolucao;
		private int _avisoAtraso;
		private int _segundosAlerta;
		private bool _produtoFracionadoPrecoMedio;
		private bool _buscaEnderecoPorCep;
		private bool _gerenciaDisponibilidadeDeEntregadores;
		private bool _controlaPorComandas;
		private bool _baixaPedidosNoFechamentoDiario;
		private bool _itensAdicionaisPorProduto;
		private bool _itensAdicionaisPorTipoDeProduto;
		private string _modeloImpressao;
		private bool _imprimirLinhaEntreItens;
		private bool _agrupaProdutosPorTipo;
		private bool _imprimirUsuarioNaComanda;
		private bool _imprimirVendedorNaComanda;
		private bool _observacaoObrigatoriaNoPedido;
		private bool _taxaDeEntregaPorCliente;
		private bool _motivoObrigatorioNoCancelamento;
		private bool _pagamentoNoLancamento;
		private bool _duasViasNoBalcao;
		private bool _pagamentoAutomaticoDeEntregadores;
		private bool _precosEmAberto;
		private bool _permiteFechamentoComPedidosEmAberto;
		private bool _taxaPagaPorEntrega;

		#endregion Fields

		#region Events

		public event EventHandler RulesChanged;

		#endregion Events

		#region Properties

		public static RegrasDeNegocio Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new RegrasDeNegocio();
				}

				return _instance;
			}
		}

		/// <summary>
		/// Quando o estoque chegar nessa quantidade de itens, deve informar ao usuário.
		/// </summary>
		public int AvisoEstoque
		{
			get
			{
				return _avisoEstoque;
			}
			set
			{
				if (_avisoEstoque != value)
				{
					_avisoEstoque = value;
					OnPropertyChanged("aviso_estoque");
				}
			}
		}

		/// <summary>
		/// Define se o sistema deve bloquear pedidos para clientes não identificados
		/// </summary>
		public bool BloqueiaClienteAnonimo
		{
			get
			{
				return _bloqueiaClienteAnonimo;
			}
			set
			{
				if (_bloqueiaClienteAnonimo != value)
				{
					_bloqueiaClienteAnonimo = value;
					OnPropertyChanged("bloqueia_cliente_anonimo");
				}
			}
		}

		/// <summary>
		/// Indica que a venda de produtos que não tenha quantidade suficiente no estoque deve ser bloqueada.
		/// </summary>
		public bool BloqueiaEstoque
		{
			get
			{
				return _bloqueiaEstoque;
			}
			set
			{
				if (_bloqueiaEstoque != value)
				{
					_bloqueiaEstoque = value;
					OnPropertyChanged("bloqueia_estoque");
				}
			}
		}

		public bool ControlaEntregas
		{
			get
			{
				return _controlaEntregas;
			}
			set
			{
				if (_controlaEntregas != value)
				{
					_controlaEntregas = value;
					OnPropertyChanged("controla_entregas");
				}
			}
		}

		public bool ControlaProcessos
		{
			get
			{
				return _controlaProcessos;
			}
			set
			{
				if (_controlaProcessos != value)
				{
					_controlaProcessos = value;
					OnPropertyChanged("controla_processos");
				}
			}
		}

		public bool EmiteCupomFiscal
		{
			get
			{
				return _emiteCupomFiscal;
			}
			set
			{
				if (_emiteCupomFiscal != value)
				{
					_emiteCupomFiscal = value;
					OnPropertyChanged("emite_cupom_fiscal");
				}
			}
		}

		public bool EntregaAutomaticaClientesInternosPagamento
		{
			get
			{
				return _entregaAutomaticaClientesInternosPagamento;
			}
			set
			{
				if (_entregaAutomaticaClientesInternosPagamento != value)
				{
					_entregaAutomaticaClientesInternosPagamento = value;
					OnPropertyChanged("entrega_automatica_cliente_interno_pagamento");
				}
			}
		}

		public bool FechaCaixaAutomaticamente
		{
			get
			{
				return _fechaCaixaAutomaticamente;
			}
			set
			{
				if (_fechaCaixaAutomaticamente != value)
				{
					_fechaCaixaAutomaticamente = value;
					OnPropertyChanged("fecha_caixa_automaticamente");
				}
			}
		}

		/// <summary>
		/// Quantidade de vias a serem impressas de Ordens de Coleta. Para empresas de transporte.
		/// </summary>
		public int OrdemDeColetaVias
		{
			get
			{
				return _ordemDeColetaVias;
			}
			set
			{
				if (_ordemDeColetaVias != value)
				{
					_ordemDeColetaVias = value;
					OnPropertyChanged("ordem_coleta_vias");
				}
			}
		}

		public string Ramo
		{
			get
			{
				return _ramo;
			}
			set
			{
				if (_ramo != value)
				{
					_ramo = value;
					OnPropertyChanged("ramo");
				}
			}
		}

		public bool RegistraVendedor
		{
			get
			{
				return _registraVendedor;
			}
			set
			{
				if (_registraVendedor != value)
				{
					_registraVendedor = value;
					OnPropertyChanged("registra_vendedor");
				}
			}
		}

		public bool TaxaEntregaPorGrupo
		{
			get
			{
				return _taxaEntregaPorGrupo;
			}
			set
			{
				if (_taxaEntregaPorGrupo != value)
				{
					_taxaEntregaPorGrupo = value;
					OnPropertyChanged("taxa_entrega_grupo");
				}
			}
		}

		public string TermoDeResponsabilidade
		{
			get
			{
				return _termoDeResponsabilidade;
			}
			set
			{
				if (_termoDeResponsabilidade != value)
				{
					_termoDeResponsabilidade = value;
					OnPropertyChanged("termo_de_responsabilidade");
				}
			}
		}

		public string ReciboDeDevolucao
		{
			get
			{
				return _reciboDeDevolucao;
			}
			set
			{
				if (_reciboDeDevolucao != value)
				{
					_reciboDeDevolucao = value;
					OnPropertyChanged("recibo_de_devolucao");
				}
			}
		}

		public int AvisoAtraso
		{
			get
			{
				return _avisoAtraso;
			}
			set
			{
				if (_avisoAtraso != value)
				{
					_avisoAtraso = value;
					OnPropertyChanged("aviso_atraso");
				}

			}
		}

		public int SegundosAlerta
		{
			get
			{
				return _segundosAlerta;
			}
			set
			{
				if (_segundosAlerta != value)
				{
					_segundosAlerta = value;
					OnPropertyChanged("segundos_alerta");
				}
			}
		}

		public bool ProdutoFracionadoPrecoMedio
		{
			get
			{
				return _produtoFracionadoPrecoMedio;
			}
			set
			{
				if (_produtoFracionadoPrecoMedio != value)
				{
					_produtoFracionadoPrecoMedio = value;
					OnPropertyChanged("produto_fracionado_preco_medio");
				}
			}
		}

		public bool BuscaEnderecoPorCep
		{
			get
			{
				return _buscaEnderecoPorCep;
			}
			set
			{
				if (_buscaEnderecoPorCep != value)
				{
					_buscaEnderecoPorCep = value;
					OnPropertyChanged("busca_endereco_por_cep");
				}
			}
		}

		public bool GerenciaDisponibilidadeDeEntregadores
		{
			get
			{
				return _gerenciaDisponibilidadeDeEntregadores;
			}
			set
			{
				if (_gerenciaDisponibilidadeDeEntregadores != value)
				{
					_gerenciaDisponibilidadeDeEntregadores = value;
					OnPropertyChanged("gerencia_disponibilidade_de_entregadores");
				}
			}
		}

		public bool ControlaPedidosPorComanda
		{
			get
			{
				return _controlaPorComandas;
			}
			set
			{
				if (_controlaPorComandas != value)
				{
					_controlaPorComandas = value;
					OnPropertyChanged("controla_por_comandas");
				}
			}
		}

		public bool BaixaPedidosNoFechamentoDiario
		{
			get
			{
				return _baixaPedidosNoFechamentoDiario;
			}
			set
			{
				if (_baixaPedidosNoFechamentoDiario != value)
				{
					_baixaPedidosNoFechamentoDiario = value;
					OnPropertyChanged("baixa_pedidos_fechamento_diario");
				}
			}
		}

		/// <summary>
		/// Significa que os itens adicionais serão individuais para cada produto
		/// </summary>
		public bool ItensAdicionaisPorProduto
		{
			get
			{
				return _itensAdicionaisPorProduto;
			}
			set
			{
				if (_itensAdicionaisPorProduto != value)
				{
					_itensAdicionaisPorProduto = value;
					OnPropertyChanged("itens_adicionais_por_produto");
				}
			}
		}

		public bool ItensAdicionaisPorTipoDeProduto
		{
			get
			{
				return _itensAdicionaisPorTipoDeProduto;
			}
			set
			{
				if (_itensAdicionaisPorTipoDeProduto != value)
				{
					_itensAdicionaisPorTipoDeProduto = value;
					OnPropertyChanged("itens_adicionais_por_tipo_de_produto");
				}
			}
		}

		public string ModeloImpressao
		{
			get
			{
				return _modeloImpressao;
			}
			set
			{
				if (_modeloImpressao != value)
				{
					_modeloImpressao = value;
					OnPropertyChanged("modelo_impressao");
				}
			}
		}

		public bool ImprimirLinhaEntreItens
		{
			get
			{
				return _imprimirLinhaEntreItens;
			}
			set
			{
				if (_imprimirLinhaEntreItens != value)
				{
					_imprimirLinhaEntreItens = value;
					OnPropertyChanged("imprimir_linha_entre_itens");
				}
			}
		}

		/// <summary>
		/// Indica se o sistema deve agrupar os produtos pelo tipo nos pedidos
		/// </summary>
		public bool AgrupaProdutosPorTipo
		{
			get
			{
				return _agrupaProdutosPorTipo;
			}
			set
			{
				if (_agrupaProdutosPorTipo != value)
				{
					_agrupaProdutosPorTipo = value;
					OnPropertyChanged("agrupa_produtos_por_tipo");
				}
			}
		}

		public bool ImprimirUsuarioNaComanda
		{
			get
			{
				return _imprimirUsuarioNaComanda;
			}
			set
			{
				if (_imprimirUsuarioNaComanda != value)
				{
					_imprimirUsuarioNaComanda = value;
					OnPropertyChanged("imprimir_usuario_na_comanda");
				}
			}
		}

		public bool ImprimirVendedorNaComanda
		{
			get
			{
				return _imprimirVendedorNaComanda;
			}
			set
			{
				if (_imprimirVendedorNaComanda != value)
				{
					_imprimirVendedorNaComanda = value;
					OnPropertyChanged("imprimir_vendedor_na_comanda");
				}
			}
		}

		public bool ObservacaoObrigatoriaNoPedido
		{
			get
			{
				return _observacaoObrigatoriaNoPedido;
			}
			set
			{
				if (_observacaoObrigatoriaNoPedido != value)
				{
					_observacaoObrigatoriaNoPedido = value;
					OnPropertyChanged("observacao_obrigatoria_no_pedido");
				}
			}
		}

		public bool TaxaDeEntregaPorCliente
		{
			get
			{
				return _taxaDeEntregaPorCliente;
			}
			set
			{
				if (_taxaDeEntregaPorCliente != value)
				{
					_taxaDeEntregaPorCliente = value;
					OnPropertyChanged("taxa_de_entrega_por_cliente");
				}
			}
		}

		public bool MotivoObrigatorioNoCancelamento
		{
			get
			{
				return _motivoObrigatorioNoCancelamento;
			}
			set
			{
				if (_motivoObrigatorioNoCancelamento != value)
				{
					_motivoObrigatorioNoCancelamento = value;
					OnPropertyChanged("motivo_obrigatorio_no_cancelamento");
				}
			}
		}

		public bool PagamentoNoLancamento
		{
			get
			{
				return _pagamentoNoLancamento;
			}
			set
			{
				if (_pagamentoNoLancamento != value)
				{
					_pagamentoNoLancamento = value;
					OnPropertyChanged("pagamento_no_lancamento");
				}
			}
		}

		public bool DuasViasNoBalcao
		{
			get
			{
				return _duasViasNoBalcao;
			}
			set
			{
				if (_duasViasNoBalcao != value)
				{
					_duasViasNoBalcao = value;
					OnPropertyChanged("duas_vias_no_balcao");
				}
			}
		}

		public bool PagamentoAutomaticoDeEntregadores
		{
			get
			{
				return _pagamentoAutomaticoDeEntregadores;
			}
			set
			{
				if (_pagamentoAutomaticoDeEntregadores != value)
				{
					_pagamentoAutomaticoDeEntregadores = value;
					OnPropertyChanged("pagamento_automatico_de_entregadores");
				}
			}
		}

		public bool PrecosEmAberto
		{
			get
			{
				return _precosEmAberto;
			}
			set
			{
				if (_precosEmAberto != value)
				{
					_precosEmAberto = value;
					OnPropertyChanged("precos_em_aberto");
				}
			}
		}

		public bool PermiteFechamentoComPedidosEmAberto
		{
			get
			{
				return _permiteFechamentoComPedidosEmAberto;
			}
			set
			{
				if (_permiteFechamentoComPedidosEmAberto != value)
				{
					_permiteFechamentoComPedidosEmAberto = value;
					OnPropertyChanged("permite_fechamento_com_pedidos_em_aberto");
				}
			}
		}

		public bool TaxaPagaPorEntrega
		{
			get
			{
				return _taxaPagaPorEntrega;
			}
			set
			{
				if (_taxaPagaPorEntrega != value)
				{
					_taxaPagaPorEntrega = value;
					OnPropertyChanged("taxa_paga_por_entrega");
				}
			}
		}

		public bool isPizza
		{
			get
			{
				return string.Equals(_ramo, "PIZZARIA");
			}
		}

		#endregion Properties

		#region Methods

		private void OnPropertyChanged(string chave)
		{
			if (RulesChanged != null)
			{
				RulesChanged.Invoke(chave, new EventArgs());
			}
		}

		#endregion Methods
	}
}