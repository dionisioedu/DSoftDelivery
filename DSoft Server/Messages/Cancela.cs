using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSoftBd;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Server.Messages
{
	public class Cancela : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "CANCELA"; }
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			try
			{
				if (!Terminal.PermiteCancelamento)
				{
					answer = "<CANCELA><RESULTADO>0</RESULTADO></CANCELA>";
					handle = 0;

					return true;
				}

				answer = string.Empty;

				int id = Convert.ToInt32(element.GetElementsByTagName("ID")[0].InnerText);
				long cliente = Convert.ToInt64(element.GetElementsByTagName("CLIENTE")[0].InnerText);
				int pedido = Convert.ToInt32(element.GetElementsByTagName("PEDIDO")[0].InnerText);
				int item = Convert.ToInt32(element.GetElementsByTagName("ITEM")[0].InnerText);
				List<ItemPedido> itens;

				if (bd.CancelarItemPedido(pedido, item, id, out itens))
				{
					DSPrintingHelper.PrinterHelper.PrintCancelItem(cliente, itens, bd);
				}

				answer = "<CANCELA><RESULTADO>1</RESULTADO></CANCELA>";
				handle = 0;

				return true;
			}
			catch (Exception)
			{
				answer = "<CANCELA><RESULTADO>0</RESULTADO></CANCELA>";
				handle = 0;

				return true;
			}
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