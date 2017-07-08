using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace DSoftParameters
{
	public partial class Preferencias
	{
		#region Properties

		public static string Componente1
		{
			get
			{
				Pref p = new Pref();
				return p.componente1;
			}
			set
			{
				Pref p = new Pref();

				if (p.componente1 != value)
				{
					p.componente1 = value;
					p.Save();
				}
			}
		}

		public static string Componente2
		{
			get
			{
				Pref p = new Pref();
				return p.componente2;
			}
			set
			{
				Pref p = new Pref();

				if (p.componente2 != value)
				{
					p.componente2 = value;
					p.Save();
				}
			}
		}

		public static string Componente3
		{
			get
			{
				Pref p = new Pref();
				return p.componente3;
			}
			set
			{
				Pref p = new Pref();

				if (p.componente3 != value)
				{
					p.componente3 = value;
					p.Save();
				}
			}
		}

		public static string Componente4
		{
			get
			{
				Pref p = new Pref();
				return p.componente4;
			}
			set
			{
				Pref p = new Pref();

				if (p.componente4 != value)
				{
					p.componente4 = value;
					p.Save();
				}
			}
		}

		public static string ImagemFundo
		{
			get
			{
				Parametros p = new Parametros();
				return p.imagem_fundo;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.imagem_fundo != value)
				{
					p.imagem_fundo = value;
					p.Save();
				}
			}
		}

		public static string ImagemLogin
		{
			get
			{
				Parametros p = new Parametros();
				return p.imagem_login;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.imagem_login != value)
				{
					p.imagem_login = value;
					p.Save();
				}
			}
		}

		public static bool ImprimeProducao
		{
			get
			{
				Parametros p = new Parametros();
				return p.imprime_producao;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.imprime_producao != value)
				{
					p.imprime_producao = value;
					p.Save();
				}
			}
		}

		public static int LicencaAviso
		{
			get
			{
				Parametros p = new Parametros();
				return p.licenca_aviso;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.licenca_aviso != value)
				{
					p.licenca_aviso = value;
					p.Save();
				}
			}
		}

		public static string MensagemCupom
		{
			get
			{
				Parametros p = new Parametros();
				return p.mensagem_cupom;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.mensagem_cupom != value)
				{
					p.mensagem_cupom = value;
					p.Save();
				}
			}
		}

		public static string PastaCTe
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte != value)
				{
					p.pasta_cte = value;
					p.Save();
				}
			}
		}

		public static string PastaCteArquivo
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_arquivo;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_arquivo != value)
				{
					p.pasta_cte_arquivo = value;
					p.Save();
				}
			}
		}

		public static string PastaCteAssinadas
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_assinadas;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_assinadas != value)
				{
					p.pasta_cte_assinadas = value;
					p.Save();
				}
			}
		}

		public static string PastaCteEnviadas
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_enviadas;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_enviadas != value)
				{
					p.pasta_cte_enviadas = value;
					p.Save();
				}
			}
		}

		public static string PastaCteErro
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_erro;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_erro != value)
				{
					p.pasta_cte_erro = value;
					p.Save();
				}
			}
		}

		public static string PastaCteNegadas
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_negadas;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_negadas != value)
				{
					p.pasta_cte_negadas = value;
					p.Save();
				}
			}
		}

		public static string PastaCteRetorno
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_cte_retorno;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_cte_retorno != value)
				{
					p.pasta_cte_retorno = value;
					p.Save();
				}
			}
		}

		public static string PastaLog
		{
			get
			{
				Parametros p = new Parametros();
				return p.pasta_log;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.pasta_log != value)
				{
					p.pasta_log = value;
					p.Save();
				}
			}
		}

		public static string PastaNFe
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe != value)
				{
					p.nfe = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeBackup
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_backup;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_backup != value)
				{
					p.nfe_backup = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeBaixados
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_baixados;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_baixados != value)
				{
					p.nfe_baixados = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeEnviadas
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_enviadas;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_enviadas != value)
				{
					p.nfe_enviadas = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeGravados
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_gravados;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_gravados != value)
				{
					p.nfe_gravados = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeRetorno
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_retorno;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_retorno != value)
				{
					p.nfe_retorno = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeTemporarios
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_temporarios;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_temporarios != value)
				{
					p.nfe_temporarios = value;
					p.Save();
				}
			}
		}

		public static string PastaNFeValidados
		{
			get
			{
				Parametros p = new Parametros();
				return p.nfe_validados;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.nfe_validados != value)
				{
					p.nfe_validados = value;
					p.Save();
				}
			}
		}

		public static bool ProdutoPorNome
		{
			get
			{
				Parametros p = new Parametros();
				return p.produto_por_nome;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.produto_por_nome != value)
				{
					p.produto_por_nome = value;
					p.Save();
				}
			}
		}

		public static string RelatoriosPath
		{
			get
			{
				Parametros p = new Parametros();
				return p.relatorios;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.relatorios != value)
				{
					p.relatorios = value;
					p.Save();
				}
			}
		}

		public static string SchemaCTe
		{
			get
			{
				Parametros p = new Parametros();
				return p.schema_cte;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.schema_cte != value)
				{
					p.schema_cte = value;
					p.Save();
				}
			}
		}

		public static string SchemaNFe
		{
			get
			{
				Parametros p = new Parametros();
				return p.schema_nfe;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.schema_nfe != value)
				{
					p.schema_nfe = value;
					p.Save();
				}
			}
		}

		public static string SchemaStatusServico
		{
			get
			{
				Parametros p = new Parametros();
				return p.schema_status_servico;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.schema_status_servico != value)
				{
					p.schema_status_servico = value;
					p.Save();
				}
			}
		}

		public static string Titulo
		{
			get
			{
				Parametros p = new Parametros();
				return p.titulo;
			}
			set
			{
				Parametros p = new Parametros();

				if (p.titulo != value)
				{
					p.titulo = value;
					p.Save();
				}
			}
		}

		public static StringCollection PedidosColunas
		{
			get
			{
				Pref p = new Pref();
				return p.pedidos_colunas;
			}
			set
			{
				Pref p = new Pref();

				if (p.pedidos_colunas != value)
				{
					p.pedidos_colunas = value;
					p.Save();
				}
			}
		}

		public static StringCollection PedidosColunasWidth
		{
			get
			{
				Pref p = new Pref();
				return p.pedidos_colunas_width;
			}
			set
			{
				Pref p = new Pref();

				if (p.pedidos_colunas_width != value)
				{
					p.pedidos_colunas_width = value;
					p.Save();
				}
			}
		}

		/// <summary>
		/// Indica o intervalo em segundos para atualização automática dos pedidos
		/// </summary>
		public static int PedidosAtualiza
		{
			get
			{
				Pref p = new Pref();
				return p.pedidos_atualiza;
			}
			set
			{
				Pref p = new Pref();

				if (p.pedidos_atualiza != value)
				{
					p.pedidos_atualiza = value;
					p.Save();
				}
			}
		}

		public static bool BackupNoFechamento
		{
			get
			{
				Pref p = new Pref();
				return p.BackupNoFechamento;
			}
			set
			{
				Pref p = new Pref();

				if (p.BackupNoFechamento != value)
				{
					p.BackupNoFechamento = value;
					p.Save();
				}
			}
		}

		#endregion Properties
	}
}