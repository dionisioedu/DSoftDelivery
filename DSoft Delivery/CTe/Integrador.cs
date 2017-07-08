using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

using DSoftBd;

using DSoftLogger;

using DSoftModels;

using DSoftParameters;
using System.Xml;
using System.Xml.Linq;
using DSoftCore;

namespace DSoft_Delivery.CTe
{
	public class Integrador
	{
		#region Fields

		public frmOrdemColeta frmOrdemColeta;

		private const int CTE_EXT = 8;
		private const int CTE_LEN = 44;

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
			string[] arquivos = Directory.GetFiles(Preferencias.PastaCteAssinadas + "\\" + DateTime.Now.ToString("yyyyMM"));
			const string proc = "-procCTe.xml";
			const string procMDFe = "-procMDFe.xml";

			if (arquivos != null && arquivos.Length > 0)
			{
				foreach (string arquivo in arquivos)
				{
					// Caso seja o arquivo CTe,

					// Caso seja o retorno autorizado, registramos no BD, alteramos o status e movemos o arquivo para a pasta de Arquivo
					if (arquivo.Substring(arquivo.Length - proc.Length, proc.Length) == proc)
					{
						string cte = arquivo.Substring(arquivo.Length - (proc.Length + CTE_LEN), CTE_LEN);
						string destino = Preferencias.PastaCteArquivo + "\\" + cte + proc;
						int indice = 0;

						if ((indice = _dsoftBd.ConhecimentoMarcarAutorizado(cte)) > 0)
						{
							if (frmOrdemColeta != null && indice > 0)
							{
								frmOrdemColeta.AtualizaConhecimento(indice, "U");
							}

							if (File.Exists(destino))
							{
								destino = destino + "(1)";
							}

							File.Move(arquivo, destino);
							File.Delete(arquivo);
						}
					}
					// Caso seja o retorno autorizado de MDFe (Manifesto de Transporte Eletrônico), registramos no BD, alteramos o status e movemos o arquivo para a pasta de Arquivo
					else if (arquivo.Substring(arquivo.Length - procMDFe.Length, procMDFe.Length) == procMDFe)
					{
						string mdfe = arquivo.Substring(arquivo.Length - (procMDFe.Length + CTE_LEN), CTE_LEN);
						string destino = Preferencias.PastaCteArquivo + "\\" + mdfe + procMDFe;
						int indice = 0;

						// Buscamos pelo número do protocolo de autorização no arquivo. Vai estar na tag nProt
						string conteudo = File.ReadAllText(arquivo);

						string nMDF = Util.ReadFromTag(conteudo, "<nMDF>", "</nMDF>");
						string cMDF = Util.ReadFromTag(conteudo, "<cMDF>", "</cMDF>");
						string cStat = Util.ReadFromTag(conteudo, "<cStat>", "</cStat>");
						string nProt = Util.ReadFromTag(conteudo, "<nProt>", "</nProt>");

						// Se estiver autorizado
						if (cStat == "100")
						{
							_dsoftBd.AutorizarManifesto(int.Parse(nMDF), int.Parse(cMDF), nProt, destino);

							if (File.Exists(destino))
							{
								destino = destino + "(1)";
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
				string[] arquivos = Directory.GetFiles(Preferencias.PastaCteRetorno, "*.err");

				if (arquivos != null && arquivos.Length > 0)
				{
					foreach (string arquivo in arquivos)
					{
						string cte = arquivo.Substring(arquivo.Length - (CTE_LEN + CTE_EXT), CTE_LEN);
						string msg = File.ReadAllText(arquivo);
						int indice = _dsoftBd.ConhecimentoAtribuirErro(cte, msg);
						string destino = Preferencias.PastaCteArquivo + "\\" + cte + "-cte.err";

						if (frmOrdemColeta != null && indice > 0)
						{
							frmOrdemColeta.AtualizaConhecimento(indice, "E");
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
			string[] arquivos = Directory.GetFiles(Preferencias.PastaCteRetorno);

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

				if (frmOrdemColeta != null)
				{
					frmOrdemColeta.UpdateVerificationStatus();
				}
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