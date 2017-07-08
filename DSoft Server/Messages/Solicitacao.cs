using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using DSoftBd;

namespace DSoft_Server.Messages
{
	public class Solicitacao : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get
			{
				return "";
			}
		}

		public string Id
		{
			get
			{
				return "SOLICITACAO";
			}
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(Bd bd, XmlElement element, out string answer, out int handle)
		{
			try
			{
				XmlNode node = element.GetElementsByTagName("ID")[0];

				if (bd.RecursoAtivo(Convert.ToInt32(node.InnerText)))
				{
					answer = "<SOLICITACAO><AUTORIZADO>1</AUTORIZADO></SOLICITACAO>";
					handle = 0;

					return true;
				}
				else
				{
					answer = "<SOLICITACAO><AUTORIZADO>0</AUTORIZADO></SOLICITACAO>";
					handle = 0;

					return true;
				}
			}
			catch (Exception)
			{
				answer = "<SOLICITACAO><AUTORIZADO>0</AUTORIZADO></SOLICITACAO>";
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