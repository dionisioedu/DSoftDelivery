using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using DSoftBd;

namespace DSoft_Server
{
	public class ServerBase
	{
		#region Fields

		private static IFormConfig _formConfig;

		#endregion Fields

		#region Methods

		public static void StartListening(string ip, int port, IFormConfig formConfig)
		{
			_formConfig = formConfig;

			Bd bd = new Bd(1);

			if (StartConnection(bd))
			{
				formConfig.Log("Iniciando conexão com banco-de-dados...");
			}
			else
			{
				formConfig.Log("Não foi possível abrir o banco-de-dados!");
				return;
			}

			bd.CarregarRegrasDeNegocios();

			IPAddress ipAddress = IPAddress.Parse(ip);

			TcpListener listener = new TcpListener(ipAddress, port);

			try
			{
				listener.Start();
			}
			catch (Exception)
			{
				formConfig.Log("Endereço de IP inválido! Edite o arquivo dsoft_server.ini e reinicie o aplicativo, ou entre em contato com o suporte.");
				return;
			}

			formConfig.Log("Recebendo dados...");

			while (true)
			{
				Thread.Sleep(150);

				if (listener.Pending())
				{
					Socket socket = listener.AcceptSocket();

					TransactionHelper helper = new TransactionHelper();

					formConfig.Log("Conexão recebida : " + socket.LocalEndPoint.ToString());

					helper.Process(bd, socket, _formConfig);
				}
			}
		}

		private static bool StartConnection(Bd bd)
		{
			byte []conteudo;
			string dados;
			string host;
			string porta;
			string banco;
			string[] parametros;

			try
			{
				FileStream file = new FileStream("dsoft.ini", FileMode.Open);

				conteudo = new byte[file.Length];

				file.Read(conteudo, 0, conteudo.Length);
				file.Close();

				dados = System.Text.Encoding.ASCII.GetString(conteudo);

				parametros = dados.Split(":".ToCharArray());

				host = parametros[0];
				porta = parametros[1];
				banco = parametros[2];

				return bd.Conecta(host, porta, banco);
			}
			catch (Exception e)
			{
				return false;
			}
		}

		#endregion Methods
	}
}