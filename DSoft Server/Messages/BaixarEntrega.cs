using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoft_Server.Messages
{
	class BaixarEntrega : IMessage
	{
		#region Fields

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "BAIXA"; }
		}

		#endregion

		#region Methods

		public bool ProcessXml(DSoftBd.Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			int indice = Convert.ToInt32(element.GetElementsByTagName("INDICE")[0].InnerText);
			int entregador = Convert.ToInt32(element.GetElementsByTagName("ENTREGADOR")[0].InnerText);
			int usuario = 1;

			if (bd.SaidaPedido(indice, entregador, usuario))
			{
			}

			answer = "<BAIXA>OK</BAIXA>";
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

		#endregion
	}
}
