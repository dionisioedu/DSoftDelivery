using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery.Modulos.EmissaoNFe.View
{
	interface IEmissaoNFeView
	{
		#region Events

		event EventHandler FormLoaded;

		event EventHandler GerarNFeClicked;

		event EventHandler PedidoSelected;

		#endregion Events

		#region Methods

		void AdicionarItem(object[] itens);

		void AtualizarNFe(DataTable dt);

		void AvisoEmitente(bool visible);

		void CarregarEmitentes(List<string> emitentes);

		void CarregarPedidos(DataSet ds);

		void DefinirDadosPedido(long codigo, string cliente, int pedido, string data, int itens, decimal valor);

		string EmitenteSelecionado();

		void InicializarListaItens(string[] cols);

		int[] ItensSelecionados();

		void LimparItens();

		void LimparItensSelecionados();

		#endregion Methods
	}
}