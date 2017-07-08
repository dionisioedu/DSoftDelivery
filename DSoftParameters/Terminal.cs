using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftParameters
{
	public class Terminal
	{
		#region Properties

		public static string Browser
		{
			get
			{
				Parametros p = new Parametros();
				return p.browser;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.browser != value)
				{
					p.browser = value;
					p.Save();
				}
			}
		}

		public static int ImpressoraColunas
		{
			get
			{
				Parametros p = new Parametros();
				return p.impressora_colunas;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.impressora_colunas != value)
				{
					p.impressora_colunas = value;
					p.Save();
				}
			}
		}

		public static string ImpressoraExterna1
		{
			get
			{
				Parametros p = new Parametros();
				return p.impressora_externa_1;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.impressora_externa_1 != value)
				{
					p.impressora_externa_1 = value;
					p.Save();
				}
			}
		}

		public static string ImpressoraExterna2
		{
			get
			{
				Parametros p = new Parametros();
				return p.impressora_externa_2;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.impressora_externa_2 != value)
				{
					p.impressora_externa_2 = value;
					p.Save();
				}
			}
		}

		//public static bool ImprimeUsuario
		//{
		//    get
		//    {
		//        Parametros p = new Parametros();
		//        return p.imprime_usuario;
		//    }
		//    set
		//    {
		//        Parametros p = new Parametros();

		//        if (p.imprime_usuario != value)
		//        {
		//            p.imprime_usuario = value;
		//            p.Save();
		//        }
		//    }
		//}

		/// <summary>
		/// Parâmetro que indica se os Mobiles são capazes de cancelar itens de pedido
		/// </summary>
		public static bool PermiteCancelamento
		{
			get
			{
				Parametros p = new Parametros();
				return p.permite_cancelamento;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.permite_cancelamento != value)
				{
					p.permite_cancelamento = value;
					p.Save();
				}
			}
		}

		public static bool RelatoriosMatricial
		{
			get
			{
				Parametros p = new Parametros();
				return p.relatorios_matricial;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.relatorios_matricial != value)
				{
					p.relatorios_matricial = value;
					p.Save();
				}
			}
		}

		public static bool VerificaArquivos
		{
			get
			{
				Parametros p = new Parametros();
				return p.verifica_arquivos;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.verifica_arquivos != value)
				{
					p.verifica_arquivos = value;
					p.Save();
				}
			}
		}

		#endregion Properties

		#region Methods

		public static void Backup(string backup)
		{
			Parametros p = new Parametros();

			p.backup = backup;

			p.Save();
		}

		public static string Backup()
		{
			Parametros p = new Parametros();

			return p.backup;
		}

		public static void ECF(string ecf)
		{
			Parametros p = new Parametros();

			p.ecf = ecf;

			p.Save();
		}

		public static string ECF()
		{
			Parametros p = new Parametros();

			return p.ecf;
		}

		public static void ECFPorta(string porta)
		{
			Parametros p = new Parametros();

			p.ecf_porta = porta;

			p.Save();
		}

		public static string ECFPorta()
		{
			Parametros p = new Parametros();

			return p.ecf_porta;
		}

		public static string Impressora()
		{
			Parametros p = new Parametros();

			return p.impressora;
		}

		public static void Impressora(string imp)
		{
			Parametros p = new Parametros();

			p.impressora = imp;

			p.Save();
		}

		public static bool Imprime2Via()
		{
			Parametros p = new Parametros();

			return p.imp2vias;
		}

		public static void Imprime2Via(bool imp2)
		{
			Parametros p = new Parametros();

			p.imp2vias = imp2;

			p.Save();
		}

		public static int NumeroCaixa()
		{
			Parametros p = new Parametros();

			return p.numero_caixa;
		}

		public static void NumeroCaixa(int numero)
		{
			Parametros p = new Parametros();

			p.numero_caixa = numero;

			p.Save();
		}

		public static void PostgreSql(string postgresql)
		{
			Parametros p = new Parametros();

			p.postgresql = postgresql;

			p.Save();
		}

		public static string PostgreSql()
		{
			Parametros p = new Parametros();

			return p.postgresql;
		}

		public static string Promocao1()
		{
			Parametros p = new Parametros();

			return p.promocao1;
		}

		public static void Promocao1(string prom)
		{
			Parametros p = new Parametros();

			p.promocao1 = prom;

			p.Save();
		}

		public static string Promocao2()
		{
			Parametros p = new Parametros();

			return p.promocao2;
		}

		public static void Promocao2(string prom)
		{
			Parametros p = new Parametros();

			p.promocao2 = prom;

			p.Save();
		}

		public static double SaldoInicial()
		{
			Parametros p = new Parametros();

			return p.caixa_inicial;
		}

		public static void SaldoInicial(double d)
		{
			Parametros p = new Parametros();

			p.caixa_inicial = d;

			p.Save();
		}

		public static bool MapasOnline
		{
			get
			{
				Parametros p = new Parametros();
				return p.mapas_online;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.mapas_online != value)
				{
					p.mapas_online = value;
					p.Save();
				}
			}
		}

		public static string ImpressoraDelivery
		{
			get
			{
				Parametros p = new Parametros();
				return p.impressora_delivery;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.impressora_delivery != value)
				{
					p.impressora_delivery = value;
					p.Save();
				}
			}
		}

		public static string DownloadMF
		{
			get
			{
				Parametros p = new Parametros();
				return p.ecf_downloadmf;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.ecf_downloadmf != value)
				{
					p.ecf_downloadmf = value;
					p.Save();
				}
			}
		}

		public static string VersaoPostgreSql
		{
			get
			{
				Parametros p = new Parametros();
				return p.versao_postgresql;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.versao_postgresql != value)
				{
					p.versao_postgresql = value;
					p.Save();
				}
			}
		}

		public static string ProcessadorPostgreSql
		{
			get
			{
				Parametros p = new Parametros();
				return p.processador_postgresql;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.processador_postgresql != value)
				{
					p.processador_postgresql = value;
					p.Save();
				}
			}
		}

		public static bool ImpressoraCorte
		{
			get
			{
				Parametros p = new Parametros();
				return p.impressora_corte;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.impressora_corte != value)
				{
					p.impressora_corte = value;
					p.Save();
				}
			}
		}

		#endregion Methods
	}
}