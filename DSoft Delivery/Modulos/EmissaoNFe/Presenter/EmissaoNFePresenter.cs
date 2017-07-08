using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

using DSoft_Delivery.Modulos.EmissaoNFe.Model;
using DSoft_Delivery.Modulos.EmissaoNFe.View;

namespace DSoft_Delivery.Modulos.EmissaoNFe.Presenter
{
	class EmissaoNFePresenter
	{
		#region Fields

		private DataTable dtNotasFiscais;
		private bool FormLoaded = false;
		private EmissaoNFeModel Model;
		private Pedido PedidoAtual;
		private IEmissaoNFeView View;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public EmissaoNFePresenter(Bd bd, Usuario usuario, EmissaoNFeModel model, IEmissaoNFeView view)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			Model = model;
			View = view;

			View.PedidoSelected += new EventHandler(View_PedidoSelected);
			View.FormLoaded += new EventHandler(View_FormLoaded);
			View.GerarNFeClicked += new EventHandler(View_GerarNFeClicked);
		}

		#endregion Constructors

		#region Methods

		private void AtualizarNotasFiscais()
		{
			_dsoftBd.CarregarNotasFiscais(dtNotasFiscais);

			View.AtualizarNFe(dtNotasFiscais);
		}

		private void CarregarEmitentes()
		{
			_dsoftBd.CarregarEmitentesAsync(_usuario.Autorizado).ContinueWith((task) =>
				{
					if (task.IsCompleted)
					{
						List<string> emitentes = new List<string>();

						foreach (DataRow row in task.Result.Tables[0].Rows)
						{
							emitentes.Add(row["cnpj"].ToString() + " - " + row["razao_social"].ToString());
						}

						View.CarregarEmitentes(emitentes);
					}
				});
		}

		private void CarregarPedidos()
		{
			_dsoftBd.PedidosListaAsync().ContinueWith((task) =>
				{
					if (task.IsCompleted)
						View.CarregarPedidos(task.Result);
				});
		}

		private void Inicializar()
		{
			CarregarEmitentes();
			CarregarPedidos();

			AtualizarNotasFiscais();
		}

		private void LimparAvisos()
		{
			View.AvisoEmitente(false);
		}

		private void View_FormLoaded(object sender, EventArgs e)
		{
			Inicializar();
		}

		private void View_GerarNFeClicked(object sender, EventArgs e)
		{
			Emitente emitente;

			string emitenteSelecionado = View.EmitenteSelecionado();

			if (string.IsNullOrEmpty(emitenteSelecionado))
			{
				View.AvisoEmitente(true);

				return;
			}

			long cnpj;

			if (!long.TryParse(emitenteSelecionado.Split(" - ".ToCharArray(), 2)[0], out cnpj))
			{
				return;
			}

			if ((emitente = _dsoftBd.CarregarEmitente(cnpj)) == null)
			{
				return;
			}

			if (!_dsoftBd.CarregarEmitente(emitente))
			{
				return;
			}

			int[] selecionados = View.ItensSelecionados();

			if (selecionados != null)
			{
				for (int i = 0; i < PedidoAtual.ItensQtd; i++)
				{
					if (!selecionados.Contains(PedidoAtual.ItensPedido[i].Numero))
					{
						PedidoAtual.ItensPedido[i].Situacao = 'B';
					}
				}
			}

			NFe.NFeManager manager = new NFe.NFeManager();
			DSoftModels.NFe.NFe nfe = manager.GerarNFe(_dsoftBd, _usuario, emitente, PedidoAtual);

			if (nfe != null)
			{
				if (_dsoftBd.IncluirNFe(PedidoAtual, nfe, NFe.NFeManager.DATE_FORMAT))
				{
					if (_dsoftBd.PedidoNFe(PedidoAtual))
					{

					}
				}
			}
		}

		private void View_PedidoSelected(object sender, EventArgs e)
		{
			if ((sender as DataGridView).CurrentRow == null)
				return;

			int numero = Convert.ToInt32((sender as DataGridView).CurrentRow.Cells["codigo"].Value);

			PedidoAtual = new Pedido();

			_dsoftBd.CarregarPedido(numero, PedidoAtual);

			View.LimparItens();

			View.DefinirDadosPedido(PedidoAtual.Cliente, _dsoftBd.ClienteNome(PedidoAtual.Cliente), PedidoAtual.Numero, PedidoAtual.Data.ToShortDateString(), PedidoAtual.ItensQtd, PedidoAtual.TotalPedido);

			foreach (ItemPedido item in PedidoAtual.ItensPedido)
			{
				if (item == null)
					break;

				object[] o = new object[6];
				o[0] = item.Numero;
				o[1] = item.Produto;
				o[2] = _dsoftBd.ProdutoNome(item.Produto);
				o[3] = item.Quantidade;
				o[4] = item.Unitario;
				o[5] = item.Preco;

				View.AdicionarItem(o);
			}

			View.LimparItensSelecionados();
		}

		#endregion Methods
	}
}