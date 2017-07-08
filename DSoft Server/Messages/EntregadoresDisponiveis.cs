using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSoftModels;

namespace DSoft_Server.Messages
{
	public class EntregadoresDisponiveis : IMessage
	{
		#region Fields

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "ENTREGADORES"; }
		}

		#endregion

		#region Methods

		public bool ProcessXml(DSoftBd.Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			StringBuilder builder = new StringBuilder();

			List<Recurso> entregadores = bd.EntregadoresDisponiveis();

			builder.Append("<ENTREGADORES>");

			foreach (Recurso r in entregadores)
			{
				builder.AppendFormat("<RECURSO><CODIGO>{0}</CODIGO><NOME>{1}</NOME></RECURSO>", r.Codigo, r.Nome);
			}

			builder.Append("</ENTREGADORES>");

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
