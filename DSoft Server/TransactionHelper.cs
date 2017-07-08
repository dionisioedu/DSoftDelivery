using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml;

using DSoftBd;

using DSoft_Server.Messages;

namespace DSoft_Server
{
	class TransactionHelper
	{
		#region Fields

		private List<IMessage> _messages;

		#endregion Fields

		#region Constructors

		public TransactionHelper()
		{
			_messages = new List<IMessage>();

			_messages.Add(new Teste1());
			_messages.Add(new Solicitacao());
			_messages.Add(new Tabelas());
			_messages.Add(new Envio());
			_messages.Add(new Consulta());
			_messages.Add(new Cancela());
			_messages.Add(new EntregasEmAberto());
			_messages.Add(new BaixarEntrega());
			_messages.Add(new EntregadoresDisponiveis());
		}

		#endregion Constructors

		#region Methods

		public void Process(Bd bd, Socket socket, IFormConfig _formConfig)
		{
			bool endTransaction = false;
			byte []recv = new byte[1024];

			try
			{
				socket.Receive(recv);

				string recvString = Encoding.ASCII.GetString(recv);

				Thread.Sleep(100);

				while (!endTransaction)
				{
					recvString = recvString.Replace('\0', ' ').Trim();

					_formConfig.Log(string.Format("{0} {1} [RECEBIDO] {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), recvString));

					if (recvString.Length > 0)
					{
						XmlDocument doc = new XmlDocument();
						doc.LoadXml(recvString);
						XmlElement elem = doc.DocumentElement;

						endTransaction = true;

						foreach (var msg in _messages)
						{
							if (elem.Name == msg.Id)
							{
								byte[] send;

								if (msg.DefaultResponse.Length > 0)
								{
									send = Encoding.ASCII.GetBytes(msg.DefaultResponse);
									socket.Send(send);

									break;
								}

								string answer;
								int handle;

								endTransaction = msg.ProcessXml(bd, elem, out answer, out handle);

								_formConfig.Log(string.Format("{0} {1} [ENVIADO] {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), answer));

								send = Encoding.ASCII.GetBytes(answer);

								if (socket.Connected)
								{
									socket.Send(send);
								}
								else
								{
									_formConfig.Log("Cliente desconectou!");
									return;
								}

								if (endTransaction == false)
								{
									// Vamos precisar de uma confirmação do celular antes de salvar alguns dados
									if (socket.Connected)
									{
										socket.Receive(recv);
										recvString = Encoding.ASCII.GetString(recv);

										endTransaction = msg.ProcessConfirmation(bd, handle);

										send = Encoding.ASCII.GetBytes("<OK>1</OK>");

										socket.Send(send);
									}
									else
									{
										msg.ProcessDisposing(handle);
									}
								}

								break;
							}
						}
					}
				}

				socket.Close();
			}
			catch (SocketException socketException)
			{
				_formConfig.Log(socketException.Message);
			}
		}

		#endregion Methods
	}
}
