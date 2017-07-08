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

namespace DSoftForms
{
	public partial class RegrasDeNegocioForm : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		#region Constructors

		public RegrasDeNegocioForm(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarValores()
		{
			cbRamo.Text = RegrasDeNegocio.Instance.Ramo;

			nmAvisoEstoque.Value = RegrasDeNegocio.Instance.AvisoEstoque;
			cbBloqueiaEstoque.Checked = RegrasDeNegocio.Instance.BloqueiaEstoque;

			cbBloqueiaClienteAnonimo.Checked = RegrasDeNegocio.Instance.BloqueiaClienteAnonimo;

			cbRegistraVendedor.Checked = RegrasDeNegocio.Instance.RegistraVendedor;
			cbFechaCaixaAutomatico.Checked = RegrasDeNegocio.Instance.FechaCaixaAutomaticamente;

			cbControlaProcessos.Checked = RegrasDeNegocio.Instance.ControlaProcessos;

			cbControlaEntregas.Checked = RegrasDeNegocio.Instance.ControlaEntregas;
			cbTaxaEntregaGrupo.Checked = RegrasDeNegocio.Instance.TaxaEntregaPorGrupo;
			cbPermiteTaxaDeEntregaPorCliente.Checked = RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente;
			cbEntregaAutomaticaClienteInternoPagamento.Checked = RegrasDeNegocio.Instance.EntregaAutomaticaClientesInternosPagamento;

			cbEmiteCupomFiscal.Checked = RegrasDeNegocio.Instance.EmiteCupomFiscal;

			nmOrdemDeColetaVias.Value = RegrasDeNegocio.Instance.OrdemDeColetaVias;

			tbTermoDeResponsabilidade.Text = RegrasDeNegocio.Instance.TermoDeResponsabilidade;
			tbReciboDeDevolucao.Text = RegrasDeNegocio.Instance.ReciboDeDevolucao;

			nmAvisoAtraso.Value = RegrasDeNegocio.Instance.AvisoAtraso;

			nmSegundosAlerta.Value = RegrasDeNegocio.Instance.SegundosAlerta;

			cbProdutoFracionadoPrecoMedio.Checked = RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio;
			cbBuscaEnderecoPorCep.Checked = RegrasDeNegocio.Instance.BuscaEnderecoPorCep;
			cbGerenciaDisponibilidadeDeEntregadores.Checked = RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores;

			cbControlaPorComandas.Checked = RegrasDeNegocio.Instance.ControlaPedidosPorComanda;
			cbBaixaPedidosFechamentoDiario.Checked = RegrasDeNegocio.Instance.BaixaPedidosNoFechamentoDiario;

			rbItensAdicionaisPorProduto.Checked = RegrasDeNegocio.Instance.ItensAdicionaisPorProduto;
			rbItensAdicionaisPorTipoDeProduto.Checked = RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto;

			cbImpressaoModelo.Text = RegrasDeNegocio.Instance.ModeloImpressao;
			cbImprimirLinhaEntreItens.Checked = RegrasDeNegocio.Instance.ImprimirLinhaEntreItens;
			cbAgrupaProdutosPorTipo.Checked = RegrasDeNegocio.Instance.AgrupaProdutosPorTipo;
			cbObservacaoObrigatoriaNoPedido.Checked = RegrasDeNegocio.Instance.ObservacaoObrigatoriaNoPedido;
			cbMotivoObrigatorioNoCancelamento.Checked = RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento;

			rbImprimeUsuarioNaComanda.Checked = RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda;
			rbImprimeVendedorNaComanda.Checked = RegrasDeNegocio.Instance.ImprimirVendedorNaComanda;

			cbPagamentoNoLancamento.Checked = RegrasDeNegocio.Instance.PagamentoNoLancamento;
			cbPrecosEmAberto.Checked = RegrasDeNegocio.Instance.PrecosEmAberto;

			cbDuasViasNoBalcao.Checked = RegrasDeNegocio.Instance.DuasViasNoBalcao;

			cbPagamentoAutomaticoDeEntregadores.Checked = RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores;
			cbPermiteFechamentoComPedidosEmAberto.Checked = RegrasDeNegocio.Instance.PermiteFechamentoComPedidosEmAberto;
			cbTaxaPagaPorEntrega.Checked = RegrasDeNegocio.Instance.TaxaPagaPorEntrega;
		}

		private void Confirmar()
		{
			RegrasDeNegocio.Instance.Ramo = cbRamo.Text;

			RegrasDeNegocio.Instance.AvisoEstoque = (int)nmAvisoEstoque.Value;
			RegrasDeNegocio.Instance.BloqueiaEstoque = cbBloqueiaEstoque.Checked;

			RegrasDeNegocio.Instance.BloqueiaClienteAnonimo = cbBloqueiaClienteAnonimo.Checked;

			RegrasDeNegocio.Instance.RegistraVendedor = cbRegistraVendedor.Checked;
			RegrasDeNegocio.Instance.FechaCaixaAutomaticamente = cbFechaCaixaAutomatico.Checked;

			RegrasDeNegocio.Instance.ControlaProcessos = cbControlaProcessos.Checked;

			RegrasDeNegocio.Instance.ControlaEntregas = cbControlaEntregas.Checked;
			RegrasDeNegocio.Instance.TaxaEntregaPorGrupo = cbTaxaEntregaGrupo.Checked;
			RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente = cbPermiteTaxaDeEntregaPorCliente.Checked;
			RegrasDeNegocio.Instance.EntregaAutomaticaClientesInternosPagamento = cbEntregaAutomaticaClienteInternoPagamento.Checked;

			RegrasDeNegocio.Instance.EmiteCupomFiscal = cbEmiteCupomFiscal.Checked;

			RegrasDeNegocio.Instance.OrdemDeColetaVias = (int)nmOrdemDeColetaVias.Value;

			RegrasDeNegocio.Instance.TermoDeResponsabilidade = tbTermoDeResponsabilidade.Text;
			RegrasDeNegocio.Instance.ReciboDeDevolucao = tbReciboDeDevolucao.Text;

			RegrasDeNegocio.Instance.AvisoAtraso = (int)nmAvisoAtraso.Value;

			RegrasDeNegocio.Instance.SegundosAlerta = (int)nmSegundosAlerta.Value;

			RegrasDeNegocio.Instance.ProdutoFracionadoPrecoMedio = cbProdutoFracionadoPrecoMedio.Checked;
			RegrasDeNegocio.Instance.BuscaEnderecoPorCep = cbBuscaEnderecoPorCep.Checked;
			RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores = cbGerenciaDisponibilidadeDeEntregadores.Checked;

			RegrasDeNegocio.Instance.ControlaPedidosPorComanda = cbControlaPorComandas.Checked;
			RegrasDeNegocio.Instance.BaixaPedidosNoFechamentoDiario = cbBaixaPedidosFechamentoDiario.Checked;

			RegrasDeNegocio.Instance.ItensAdicionaisPorProduto = rbItensAdicionaisPorProduto.Checked;
			RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto = rbItensAdicionaisPorTipoDeProduto.Checked;

			RegrasDeNegocio.Instance.ModeloImpressao = cbImpressaoModelo.Text;
			RegrasDeNegocio.Instance.ImprimirLinhaEntreItens = cbImprimirLinhaEntreItens.Checked;
			RegrasDeNegocio.Instance.AgrupaProdutosPorTipo = cbAgrupaProdutosPorTipo.Checked;
			RegrasDeNegocio.Instance.ObservacaoObrigatoriaNoPedido = cbObservacaoObrigatoriaNoPedido.Checked;
			RegrasDeNegocio.Instance.MotivoObrigatorioNoCancelamento = cbMotivoObrigatorioNoCancelamento.Checked;

			RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda = rbImprimeUsuarioNaComanda.Checked;
			RegrasDeNegocio.Instance.ImprimirVendedorNaComanda = rbImprimeVendedorNaComanda.Checked;

			RegrasDeNegocio.Instance.PagamentoNoLancamento = cbPagamentoNoLancamento.Checked;
			RegrasDeNegocio.Instance.PrecosEmAberto = cbPrecosEmAberto.Checked;

			RegrasDeNegocio.Instance.DuasViasNoBalcao = cbDuasViasNoBalcao.Checked;

			RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores = cbPagamentoAutomaticoDeEntregadores.Checked;
			RegrasDeNegocio.Instance.PermiteFechamentoComPedidosEmAberto = cbPermiteFechamentoComPedidosEmAberto.Checked;
			RegrasDeNegocio.Instance.TaxaPagaPorEntrega = cbTaxaPagaPorEntrega.Checked;

			Sair();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmRegrasNegocio_Load(object sender, EventArgs e)
		{
			CarregarValores();

			CarregarBloqueios();
		}

		private void CarregarBloqueios()
		{
			if (!_usuario.NivelUsuario.Administrador)
			{
				cbRamo.Enabled = false;
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

		#endregion Methods
	}
}