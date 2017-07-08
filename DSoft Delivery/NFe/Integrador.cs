using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

using DSoftBd;

using DSoftLogger;

using DSoftModels;
using DSoftModels;

using DSoftParameters;

using DSoft_Delivery.Modulos.EmissaoNFe.View;

namespace DSoft_Delivery.NFe
{
	public class Integrador
	{
		#region Fields

		public EmissaoNFeView frmEmissaoNFe;

		private const int NFE_EXT = 8;
		private const int NFE_LEN = 44;

		private static Integrador _instance;

		private Bd _dsoftBd;
		private Timer _timer;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public Integrador()
		{
			_timer = new Timer(2000);
			_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
		}

		#endregion Constructors

		#region Properties

		public static Integrador Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Integrador();
				}

				return _instance;
			}
		}

		#endregion Properties

		#region Methods

		public void Inicia(Bd bd, Usuario usuario)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			_timer.Start();
		}

		public void Parar()
		{
			_timer.Stop();
		}

		private void ProcessaAutorizados()
		{
			string[] arquivos = Directory.GetFiles(Preferencias.PastaNFeValidados + "\\" + DateTime.Now.ToString("yyyyMM"));
			const string proc = "-procNFe.xml";

			if (arquivos != null && arquivos.Length > 0)
			{
				foreach (string arquivo in arquivos)
				{
					// Caso seja o arquivo NFe,

					// Caso seja o retorno autorizado, registramos no BD, alteramos o status e movemos o arquivo para a pasta de Arquivo
					if (arquivo.Substring(arquivo.Length - proc.Length, proc.Length) == proc)
					{
						string nfe = arquivo.Substring(arquivo.Length - (proc.Length + NFE_LEN), NFE_LEN);
						string destino = Preferencias.PastaNFeBackup + "\\" + nfe + proc;
						int indice = 0;

						if ((indice = _dsoftBd.NFeAutorizada(nfe)) > 0)
						{
							if (frmEmissaoNFe != null && indice > 0)
							{
								frmEmissaoNFe.AtualizaNFe(indice, "U");
							}

							if (File.Exists(destino))
							{
								File.Delete(destino);
							}

							File.Move(arquivo, destino);
							File.Delete(arquivo);
						}
					}
				}
			}
		}

		private void ProcessaErros()
		{
			try
			{
				string[] arquivos = Directory.GetFiles(Preferencias.PastaNFeRetorno, "*.err");

				if (arquivos != null && arquivos.Length > 0)
				{
					foreach (string arquivo in arquivos)
					{
						string nfe = arquivo.Substring(arquivo.Length - (NFE_LEN + NFE_EXT), NFE_LEN);
						string msg = File.ReadAllText(arquivo);
						int indice = _dsoftBd.AtribuirErroNFe(nfe, msg);
						string destino = Preferencias.PastaNFeRetorno + "\\" + nfe + "-cte.err";

						if (frmEmissaoNFe != null && indice > 0)
						{
							frmEmissaoNFe.AtualizaNFe(indice, "E");
						}

						if (File.Exists(destino))
						{
							File.Delete(destino);
						}

						File.Move(arquivo, destino);
						File.Delete(arquivo);
					}
				}
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e);
			}
		}

		private void ProcessaRetornos()
		{
			string[] arquivos = Directory.GetFiles(Preferencias.PastaNFeRetorno);

			if (arquivos != null && arquivos.Length > 0)
			{
				foreach (string arquivo in arquivos)
				{
				}
			}
		}

		private void VerificaArquivos()
		{
			try
			{
				VerificaEnvios();
				ProcessaErros();
				ProcessaRetornos();
				ProcessaAutorizados();
			}
			catch (Exception)
			{
				Terminal.VerificaArquivos = false;
			}
		}

		private void VerificaEnvios()
		{
		}

		private void _timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (Terminal.VerificaArquivos)
			{
				VerificaArquivos();
			}
		}

		#endregion Methods
	}
}