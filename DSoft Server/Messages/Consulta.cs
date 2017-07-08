using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSoftBd;
using DSoftModels;

namespace DSoft_Server.Messages
{
	public class Consulta : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "CONSULTA"; }
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			StringBuilder sb = new StringBuilder();

			Pedido pedido = new Pedido();

			long cliente = Convert.ToInt64(element.GetElementsByTagName("CLIENTE")[0].InnerText);

			pedido.Numero = bd.PedidoEmAberto(cliente);

			if (pedido.Numero > 0)
			{
				bd.CarregarPedido(pedido.Numero, pedido, false);

				decimal taxa_servico = bd.TaxaDeServicoGrupoClientes(bd.ClienteGrupo(pedido.Cliente));

				if (taxa_servico > 0)
				{
					pedido.TaxaDeServico = (pedido.TotalPedido * taxa_servico) / 100;
				}

				sb.AppendFormat("<CONSULTA><PEDIDO>{0}</PEDIDO><TOTAL>{1}</TOTAL>", pedido.Numero, pedido.TotalPedido);

				foreach (ItemPedido item in pedido.ItensPedido)
				{
					sb.AppendFormat("<ITEM><NUMERO>{0}</NUMERO><PRODUTO>{1}</PRODUTO><OBSERVACAO>{2}</OBSERVACAO><QUANTIDADE>{3}</QUANTIDADE><VALOR>{4}</VALOR><SECUNDARIO>{5}</SECUNDARIO></ITEM>"
						, item.Numero, item.Produto, item.Observacao, item.Quantidade, item.Preco, item.Secundario ? 1 : 0);
				}

				sb.Append("</CONSULTA>");
			}
			else
			{
				sb.Append("<CONSULTA><SITUACAO>F</SITUACAO></CONSULTA>");
			}

			answer = sb.ToString();
			handle = 0;

			return true;
		}

		public bool ProcessConfirmation(DSoftBd.Bd bd, int handle)
		{
			return true;
		}

		public bool ProcessDisposing(int handle)
		{
			return true;
		}

		#endregion Methods
	}
}