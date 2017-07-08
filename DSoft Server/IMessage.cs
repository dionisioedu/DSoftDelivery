using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using DSoftBd;

namespace DSoft_Server
{
	interface IMessage
	{
		#region Properties

		string DefaultResponse
		{
			get;
		}

		string Id
		{
			get;
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Processa o xml enviado pelo dispositivo
		/// </summary>
		/// <param name="xml">Xml enviado pelo dispositivo</param>
		/// <param name="answer">Resposta para o dispositivo</param>
		/// <param name="handle">A mensagem deve gerar um handle para o caso de ser necessária uma confirmação posterior</param>
		/// <returns>Deve encerrar a transação?</returns>
		bool ProcessXml(Bd bd, XmlElement element, out string answer, out int handle);

		/// <summary>
		/// Processa a confirmação da transação por parte do dispositivo
		/// </summary>
		/// <param name="handle">Handle anteriormente gerado pelo metodo que processou a solicitação</param>
		/// <returns>Deve encerrar a transação?</returns>
		bool ProcessConfirmation(DSoftBd.Bd bd, int handle);

		/// <summary>
		/// Processa a limpeza dos dados previamente enviados pelo dispositivo
		/// </summary>
		/// <param name="handle">Handle anteriormente criado pelo método que processou a solicitação</param>
		/// <returns>Deve encerrar a transação?</returns>
		bool ProcessDisposing(int handle);

		#endregion Methods
	}
}