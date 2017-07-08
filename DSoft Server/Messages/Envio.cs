using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using DSoftModels;
using System.Globalization;
using DSoftParameters;

namespace DSoft_Server.Messages
{
	public class Envio : IMessage
	{
		#region Fields

		private Dictionary<int, Pedido> _pedidos = new Dictionary<int, Pedido>();

		#endregion

		#region Properties

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "ENVIO"; }
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(DSoftBd.Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			try
			{
				Pedido pedido = new Pedido();
				pedido.Tabela = bd.CarregarTabela(1);

				XmlNode nodeDispositivo = element.GetElementsByTagName("ID")[0];

				pedido.Vendedor = bd.CarregarRecurso(Convert.ToInt32(nodeDispositivo.InnerText));

				XmlNode nodeMesa = element.GetElementsByTagName("CLIENTE")[0];

				pedido.Cliente = Convert.ToInt64(nodeMesa.InnerText);

				XmlNodeList itens = element.GetElementsByTagName("ITEM");

				foreach (XmlNode item in itens)
				{
					ItemPedido item_pedido = new ItemPedido();
					item_pedido.Situacao = 'A';

					foreach (XmlNode childNode in item.ChildNodes)
					{
						switch (childNode.Name)
						{
							case "PRODUTO":
								item_pedido.Produto = Convert.ToInt64(childNode.InnerText);
								item_pedido.ProdutoNome = bd.ProdutoNome(item_pedido.Produto);
								item_pedido.Unitario = (decimal)bd.ProdutoPreco(item_pedido.Produto, 1);
								break;

							case "OBSERVACAO":
								item_pedido.Observacao = childNode.InnerText;
								break;

							case "QUANTIDADE":
								item_pedido.Quantidade = (float)double.Parse(childNode.InnerText.Replace(",", "."), CultureInfo.InvariantCulture);
								break;

							case "SECUNDARIO":
								item_pedido.Secundario = childNode.InnerText == "1" ? true : false;
								break;
						}
					}

					if (item_pedido.Quantidade >= 1 && item_pedido.Quantidade % 1 == 0)
					{
						item_pedido.Preco = item_pedido.Unitario * (decimal)item_pedido.Quantidade;
					}

					ObservacaoParaAdicionais(bd, item_pedido);

					pedido.ItensPedido.Add(item_pedido);
				}

				pedido.ResetarNumeros();
				pedido.RecalcularProdutosMultiplos();

				SomaValoresAdicionais(pedido);

				int numero_pedido;

				numero_pedido = bd.PedidoEmAberto(pedido.Cliente);

				if (numero_pedido > 0)
				{
					pedido.Numero = numero_pedido;
				}

				handle = NewHandle();

				_pedidos.Add(handle, pedido);

				answer = "<ENVIO>1</ENVIO>";

				return false;
			}
			catch (Exception e)
			{
				answer = "<ENVIO>0</ENVIO>";
				handle = 0;

				return true;
			}
		}

		private int NewHandle()
		{
			int i = 0;

			while (_pedidos.ContainsKey(i))
				i++;

			return i;
		}

		private void ReordenarItens(Pedido pedido, DSoftBd.Bd bd)
		{
			Dictionary<ItemPedido, int> itens_tipo = new Dictionary<ItemPedido, int>();

			foreach (ItemPedido item in pedido.ItensPedido)
			{
				itens_tipo.Add(item, bd.ProdutoTipo(item.Produto));
			}

			pedido.ItensPedido.Clear();

			foreach (var item in itens_tipo.OrderBy(a => a.Value))
			{
				bool novo = true;

				if (item.Key.Quantidade % 1 == 0)
				{
					for (int i = 0; i < pedido.ItensPedido.Count; i++)
					{
						if (pedido.ItensPedido[i].Quantidade % 1 == 0)
						{
							if (pedido.ItensPedido[i].Equals(item.Key))
							{
								pedido.ItensPedido[i].Quantidade += item.Key.Quantidade;
								pedido.ItensPedido[i].Preco += item.Key.Preco;

								novo = false;
								break;
							}
						}
					}
				}

				if (novo)
				{
					pedido.ItensPedido.Add(item.Key);
				}
			}

			pedido.ResetarNumeros();
		}

		private decimal ObservacaoParaAdicionais(DSoftBd.Bd bd, ItemPedido item)
		{
			decimal total = 0;

			if (item.Observacao != null && item.Observacao.Length > 0)
			{
				string[] adicionais = item.Observacao.Split(";".ToCharArray());

				foreach (string adc in adicionais)
				{
					if (adc.Trim().Length > 0)
					{
						ItemAdicional item_adicional = new ItemAdicional();

						if (adc.Contains("(+"))
						{
							decimal valor;

							item_adicional.Descricao = adc.Remove(adc.IndexOf('('), adc.Length - adc.IndexOf('('));
							decimal.TryParse(adc.Substring(adc.IndexOf("(+") + 2, (adc.Length - adc.IndexOf("(") - 1) - 2), out valor);

							item_adicional.Valor = valor;

							total += valor;
						}
						else if (adc.Contains("(-"))
						{
							decimal valor;

							item_adicional.Descricao = adc.Remove(adc.IndexOf('('), adc.Length - adc.IndexOf('('));
							decimal.TryParse(adc.Substring(adc.IndexOf("(-") + 2, (adc.Length - adc.IndexOf("(") - 1) - 2), out valor);

							item_adicional.Valor = -valor;

							total += valor;
						}
						else
						{
							item_adicional.Descricao = adc;
							item_adicional.Valor = 0;
						}

						if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
						{
							bd.AdicionarItemAdicional(item_adicional, item.Produto);
						}
						else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
						{
							bd.AdicionarItemAdicional(item_adicional, bd.CarregarProdutoTipo(bd.ProdutoTipo(item.Produto)));
						}
						else
						{
							bd.AdicionarItemAdicional(item_adicional);
						}

						item.ItensAdicionais.Add(item_adicional);
					}
				}

				item.Observacao = string.Empty;
			}

			return total;
		}

		private void SomaValoresAdicionais(Pedido pedido)
		{
			for (int i = 0; i < pedido.ItensPedido.Count; i++)
			{
				if (pedido.ItensPedido[i].Secundario)
				{
					decimal total = 0;

					foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					{
						total += adicional.Valor;
					}

					int j = i;

					while (j > 0)
					{
						j--;

						if (!pedido.ItensPedido[j].Secundario)
						{
							pedido.ItensPedido[j].Preco += total;
							break;
						}
					}
				}
				else
				{
					decimal total = 0;

					foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					{
						total += adicional.Valor;
					}

					pedido.ItensPedido[i].Preco += total;
				}
			}
		}

		public bool ProcessConfirmation(DSoftBd.Bd bd, int handle)
		{
			Pedido pedido = _pedidos[handle];

			if (pedido != null)
			{
				if (pedido.Numero > 0)
				{
					bd.AdicionaItensPedido(pedido, 1);

					DSPrintingHelper.PrinterHelper.PrintItemOrder(pedido, bd);

					pedido = bd.CarregarPedido(pedido.Numero);
					ReordenarItens(pedido, bd);

					bd.AlterarPedido(pedido, new Usuario() { Codigo = 1 });
				}
				else
				{
					ReordenarItens(pedido, bd);

					int novo = bd.NovoPedido(pedido, 1, 1);
					pedido.Numero = novo;

					//DSPrintingHelper.PrinterHelper.PrintOrder(pedido, new Caixa() { Codigo = 1, Descricao = bd.CaixaDescricao(1) }, 1, bd, null, true, true);

					DSPrintingHelper.PrinterHelper.PrintItemOrder(pedido, bd);
				}
			}

			return true;
		}

		public bool ProcessDisposing(int handle)
		{
			_pedidos.Remove(handle);

			return true;
		}

		#endregion Methods
	}
}