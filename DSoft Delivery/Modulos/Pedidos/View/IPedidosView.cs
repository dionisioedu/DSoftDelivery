using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using DSoftModels;
using DSoftBd;
using System.Windows.Forms;

namespace DSoft_Delivery.Pedidos
{
	public interface IPedidosView
	{
		#region Events

		event EventHandler AlterarTotalPedido;
		event EventHandler CadClientesClicked;
		event EventHandler CancelarClicked;
		event EventHandler CarregarDadosCliente;
		event EventHandler CarregarPedidosAnteriores;
		event EventHandler ConfirmarItemClicked;
		event EventHandler DefinirDataRaised;
		event EventHandler DescontoChanged;
		event EventHandler EntregarClicked;
		event EventHandler EventNew;
		event EventHandler EventSubmit;
		event EventHandler ExcluirItemClicked;
		event EventHandler HistoricoClienteRaised;
		event EventHandler Initialize;
		event EventHandler ItemAdicionalClicked;
		event EventHandler ItemTresTercosClicked;
		event EventHandler ItemQuatroQuartosClicked;
		event EventHandler LimparPedidoClicked;
		event EventHandler LimparListaClicked;
		event EventHandler PagarClicked;
		event EventHandler PedidoClicked;
		event EventHandler PrecoChanged;
		event EventHandler ProdutoDuploClicked;
		event EventHandler ProdutoFracionadoClicked;
		event EventHandler ProdutoPressed;
		event EventHandler QuantidadeChanged;
		event EventHandler RefreshClicked;
		event EventHandler ReimprimirClicked;
		event EventHandler TabelaChanged;
		event EventHandler ShowDetailsClicked;
		event EventHandler ConsultaPrecosClicked;
		event EventHandler CadastroDeObservacoesClicked;
		event EventHandler ProdutosTextChanged;
		event EventHandler TaxaChanged;
		event EventHandler AumentarQuantidadeClicked;
		event EventHandler DiminuirQuantidadeClicked;
		event EventHandler CadAdicionaisRapidoClicked;
		event EventHandler EditarItem;
		event EventHandler RetirarCheckedChanged;
		event EventHandler EmitirECFClicked;
		event EventHandler ExibirMapaClicked;
		event EventHandler TrocarClienteClicked;

		#endregion Events

		#region Methods

		void AddRows(DataTable table);
		void AdicionarItem(object item, decimal total_pedido);
		void AjustarTotalPedido(decimal total_pedido);
		void AvisoEstoque(double itens);
		void BloqueiaEstoque();
		void CancelarItensPedido(int[] item);
		void CarregarProdutos(string[] produtos);
		void CarregarProduto(string produto);
		void BloquearProdutos();
		void LiberarProdutos();
		void ConfirmarFocus();
		void DefinirDadosCliente(string nome, string endereco, string bairro, bool ok = true);
		void DefinirDadosCliente(long codigo, string nome, string endereco, string bairro, bool ok = true);
		void MostrarHistorico(string historico);
		void DefinirObservacao(string observacao);
		void DefinirPreco(decimal preco);
		void DefinirTabela(int tabela);
		void DefinirTabelas(List<TabelaDePrecos> tabelas);
		void DefinirTaxaEntrega(decimal taxa_entrega, bool desabilita = false);
		void DefinirTroco(decimal troco);
		void DefinirTotal(decimal total);
		void LiberaEstoque();
		void LimparAviso();
		void LimparLista();
		void MostrarProduto(Image imagem);
		string Observacao();
		void PermitirItensAdicionais(bool permitir);
		void PreencherItensAdicionais(List<ItemAdicional> itens);
		void PreencherPedido(char situacao);
		void PreencherPrecoUnitario(decimal preco, bool bloqueia = true);
		void PrepareNew();
		void SetCodigoCliente(long codigo);
		void SetDataSource(DataSet ds, bool reset);
		decimal Troco();
		void ViewClean();
		void DefinirProduto(Produto produto);
		void DefinirObservacoes(List<string> observacoes);
		void PermitirTabelasDePrecos(bool permitir);
		void ShowDropDown();
		void HideDropDown();
		void MostrarNomeProduto(string nome);
		void RedesenharLista(List<ItemPedido> itens);
		void AdicionarItemAdicional(ItemAdicional item);
		string ObservacaoItem();
		void ClearFields();
		void Sair();
		void BloquearConfirma();
		void HabilitarConfirma();
		void PreencherMotivoDoCancelamento(string motivo);
		void DefinirRetirar(bool retirar);
		bool Retirar();
		void HabilitaPedido();
		void DesabilitaPedido();
		void EsconderECF();
		void MostrarECF();
		void MostrarRota(Bd bd, Usuario usuario, Cliente cliente);
		void Loaded();
		void TrocarClienteVisivel(bool visivel);
		Form FormHandler();
		void MostrarSaldo(decimal saldo);
		void OcultarSaldo();

		#endregion Methods
	}
}