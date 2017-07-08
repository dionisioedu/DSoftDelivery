using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using DSoftBd;

namespace DSoft_Server.Messages
{
	public class Teste1 : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get
			{
				return "<TESTE>OK</TESTE>";
			}
		}

		public string Id
		{
			get
			{
				return "TESTE";
			}
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(Bd bd, XmlElement element, out string answer, out int handle)
		{
			answer = string.Empty;
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