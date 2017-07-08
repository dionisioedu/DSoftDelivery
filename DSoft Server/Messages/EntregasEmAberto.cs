using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSoftBd;
using DSoftModels;

namespace DSoft_Server.Messages
{
	public class EntregasEmAberto : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "ENTREGAS"; }
		}

		#endregion

		#region Methods

		public bool ProcessXml(DSoftBd.Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			StringBuilder builder = new StringBuilder();

			builder.Append("<ENTREGAS>");

			List<Entrega> entregas = bd.EntregasEmAberto();

			foreach (Entrega e in entregas)
			{
				builder.Append("<ENTREGA>");

				builder.AppendFormat("<INDICE>{0}</INDICE>", e.Indice);
				builder.AppendFormat("<DATA>{0}</DATA>", e.Data.ToShortDateString());
				builder.AppendFormat("<HORA>{0}</HORA>", e.Hora.ToShortTimeString());
				builder.AppendFormat("<CLIENTE>{0}</CLIENTE>", e.Cliente);
				builder.AppendFormat("<BAIRRO>{0}</BAIRRO>", e.Bairro);
				builder.AppendFormat("<ENDERECO>{0}</ENDERECO>", e.Endereco);

				builder.Append("</ENTREGA>");
			}

			builder.Append("</ENTREGAS>");

			answer = builder.ToString();
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
