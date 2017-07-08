using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DSoftCore;
using DSoftBd;
using DSoftModels;
using DSoftParameters;

using DSoft_Delivery.Despesas;
using DSoft_Delivery.Financeiro;
using DSoft_Delivery.Forms;
using DSoft_Delivery.Modulos.EmissaoNFe.View;
using DSoft_Delivery.Pedidos;
using DSoft_Delivery.Modulos.Locacao;
using DSoft_Delivery.Modulos.Alertas;
using DSoftForms;
using System.Threading.Tasks;
using DSoftConfig;
using DSoft_Delivery.Modulos.Notificacoes;
using System.Net;
using System.Net.Sockets;

namespace DSoft_Delivery
{
	public partial class frmMain : Form, IMain
	{
		#region Fields

		private CadClientes _cadClientes;
		private frmCadProdutos _cadProdutos;
		private EmissaoNFeView _emissaoNFe;
		private frmOrdemColeta _ordemColeta;
		private Pedidos.PedidosView _pedidos;
		private AlertaAtrasos _alertaAtrasos;
		private frmReceber _receber;
		private frmAberturaDeCaixa _aberturaDeCaixa;
		private frmCadTiposDeServicos _cadTiposDeServicos;
		private frmLancamentoOS _lancamentoOS;
		private frmEntregaDeEquipamentos _entregaDeEquipamentos;
		private frmEstoque _estoque;
		private frmFolhaDePagamentosServicos _folhaDePagamentosServicos;
		private FinanceiroView _financeiroView;
		private frmRecebimentoDeProdutos _recebimentoDeProdutos;
		private frmCadPeriodos _cadastroDePeriodos;
		private frmMsgDemonstracao _msgDemonstracao;

		private Bd _dsoftBd;
		private Usuario _usuario;
		private Caixa _caixa;

		private string[] _args;
		private System.Windows.Forms.Timer _logTimer;

		private Notificacoes _notificacoes;

		#endregion Fields

		#region Constructors

		public frmMain(string[] args)
		{
			InitializeComponent();

			_args = args;

			_dsoftBd = new Bd(0);
			_usuario = new Usuario();

			_logTimer = new System.Windows.Forms.Timer();
			_logTimer.Interval = 5000;
			_logTimer.Tick += new EventHandler(t_Tick);

			if (IniciaConexao())
			{
				_dsoftBd.ApplyPatches();

				frmLogin f = new frmLogin(_dsoftBd, _usuario);

				if (f.ShowDialog() != DialogResult.OK || _usuario == null || _usuario.Codigo < 1)
				{
					Application.Exit();
					return;
				}
			}
			else
			{
				MessageBox.Show("Não foi possivel se conectar ao banco-de-dados. Entre em contato com o suporte.", this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				Application.Exit();
			}
		}

		private void StartLoggingTimerCleanner()
		{
			_logTimer.Enabled = true;
			_logTimer.Start();
		}

		private void t_Tick(object sender, EventArgs e)
		{
			tsLog.Text = "";
		}

		#endregion Constructors

		#region Methods

		private void frmMain_Load(object sender, EventArgs e)
		{
			if (Licenca.Instance.Demo)
			{
				_msgDemonstracao = new frmMsgDemonstracao();
				_msgDemonstracao.ShowDialog();
			}

			if (_usuario == null || _usuario.Autorizado == 0)
			{
				this.Close();
				return;
			}

			if (DSConfig.Instance.MainLocationX != string.Empty)
			{
				this.Location = new Point(Util.TryParseInt(DSConfig.Instance.MainLocationX), Util.TryParseInt(DSConfig.Instance.MainLocationY));

				if (DSConfig.Instance.MainWidth != string.Empty)
				{
					this.Width = Util.TryParseInt(DSConfig.Instance.MainWidth);
					this.Height = Util.TryParseInt(DSConfig.Instance.MainHeight);
				}
			}

			tsLog.Text = "Carregando dados do usuário...";

			Task.Factory.StartNew(new Action(() =>
			{
				if ((toolStripStatusLabel2.Text = _dsoftBd.UsuarioNome(_usuario.Autorizado)) == string.Empty)
				{
					toolStripStatusLabel2.Text = "Acesso não autorizado!";

					foreach (Control c in Controls)
					{
						if (c is Button)
							c.Enabled = false;
					}

					menuStrip1.Enabled = false;
				}
			}));

			tsLog.Text = "Carregando nível do usuário...";

			Task.Factory.StartNew(new Action(() =>
			{
				_usuario = _dsoftBd.CarregarUsuario(_usuario.Autorizado);
				_usuario.Autorizado = _usuario.Codigo;
			})).Wait();

			tsLog.Text = "Carregando filial...";

			Task.Factory.StartNew(() =>
			{
				_dsoftBd.CarregarFilial();
			});

			tsLog.Text = "Inicializando eventos...";

			Task.Factory.StartNew(() =>
			{
				VincularEventos();
			});

			tsLog.Text = "Verificando licença...";

			Task.Factory.StartNew(() =>
			{
				VerificarLicenca();
			});

			tsLog.Text = "Carregando níveis...";

			Task.Factory.StartNew(() =>
			{
				CarregarNiveis();

				this.Invoke(new Action(() => { tsLog.Text = "Carregando preferências..."; }));

				CarregarPreferencias();

				this.Invoke(new Action(() => { tsLog.Text = "Carregando regras do negócio..."; }));

				CarregarRegrasDeNegocio();

				this.Invoke(new Action(() => { tsLog.Text = "Carregando terminal..."; }));

				CarregarTerminal();

				this.Invoke(new Action(() => { tsLog.Text = "Carregando imagem..."; }));

				CarregarImagem();
			}).ContinueWith((task) =>
			{
				tsLog.Text = "Inicialização completa!";

				this.Invoke(new Action(() => { StartLoggingTimerCleanner(); }));

				//Verifica abertura de caixa
				if (!_dsoftBd.CaixaEstaAberto(_caixa))
				{
					this.Invoke(new Action(() =>
					{
						frmAberturaDeCaixa form = new frmAberturaDeCaixa(_dsoftBd, _usuario);
						form.ShowDialog();
					}));
				}
			});

			if (_args != null && _args.Length > 0)
			{
				tsLog.Text = "Alterando regras do negócio...";

				Task.Factory.StartNew(() =>
				{
					AlterarRegrasDeNegocio(_args);
				});
			}

			MostrarMeuIp();

			_notificacoes = new Notificacoes(this);
			_notificacoes.Verificar();

			TestarConexaoWebserver();
		}

		private void TestarConexaoWebserver()
		{
			
		}

		private void VincularEventos()
		{
			orderButton1.Click += btPedidosNovo_Click;
			cashButton1.Click += caixa_Click;
			customersButton1.Click += clientes_Click;
			deliveryButton1.Click += entregas_Click;

			collectButton1.Click += btPedidosNovo_Click;
			manifestButton1.Click += entregas_Click;

			exitButton1.Click += sair_Click;
		}

		private void MostrarMeuIp()
		{
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());

			foreach (IPAddress ip in host.AddressList)
			{
				localIP = ip.ToString();

				string[] temp = localIP.Split('.');

				if (ip.AddressFamily == AddressFamily.InterNetwork && temp[0] == "192")
				{
					break;
				}
				else
				{
					localIP = null;
				}
			}

			slMeuIP.Text = "Meu IP: " + localIP;
		}

		private void AlterarRegrasDeNegocio(string[] args)
		{
			foreach (string s in args)
			{
				if (s.ToUpper() == "PIZZARIA" || 
					s.ToUpper() == "ESCOLA" ||
					s.ToUpper() == "TRANPORTADORA" ||
					s.ToUpper() == "LOJA" ||
					s.ToUpper() == "ESCRITORIO")
				{
					RegrasDeNegocio.Instance.Ramo = s.ToUpper();
				}
			}
		}

		public void ShowAlert(string message)
		{
			//frmAlert alert = new frmAlert(message);
			//alert.Location = new Point((this.Location.X + this.Width - alert.Width), (this.Location.Y + this.Height - alert.Height));
			//alert.Show();

			niAlerts.BalloonTipText = message;
			niAlerts.ShowBalloonTip(RegrasDeNegocio.Instance.SegundosAlerta * 1000);
		}

		private void atendimentoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmAtendimento form = new frmAtendimento();

			form.ShowDialog();
		}

		private void backupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_dsoftBd.Backup();
		}

		private void btEmitirNFe_Click(object sender, EventArgs e)
		{
			EmitirNFe();
		}

		private void btEstoqueMatriz_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.Ramo == "LOJA")
			{
				frmEstoqueMatriz form = new frmEstoqueMatriz();
				form.Show();
			}
			else
			{
				frmConClientesSaldo form = new frmConClientesSaldo(_dsoftBd, _usuario);
				form.Show();
			}
		}

		private void btPedidosNovo_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.Ramo == "TRANSPORTADORA")
			{
				if (_ordemColeta == null)
				{
					_ordemColeta = new frmOrdemColeta(_dsoftBd, _usuario);

					CTe.Integrador.Instance.frmOrdemColeta = _ordemColeta;

					_ordemColeta.FormClosed += new FormClosedEventHandler((oSender, eArgs) =>
						{
							CTe.Integrador.Instance.frmOrdemColeta = null;
							_ordemColeta = null;
						});

					_ordemColeta.Show();
				}
				else
				{
					_ordemColeta.Focus();
				}
			}
			else
			{
				PedidosNovo();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Pedidos();
		}

		private void caixa_Click(object sender, EventArgs e)
		{
			frmCaixa form = new frmCaixa(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void clientes_Click(object sender, EventArgs e)
		{
			CadastroClientes();
		}

		private void entregas_Click(object sender, EventArgs e)
		{
			Entregas();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			frmAtendimento form = new frmAtendimento();

			form.ShowDialog();
		}

		private void sair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CadastroClientes()
		{
			if (_cadClientes == null)
			{
				_cadClientes = new CadClientes(_dsoftBd, _usuario, Licenca.Instance);

				tmRelogio.Enabled = false;

				_cadClientes.Show();

				_cadClientes.FormClosing += new FormClosingEventHandler((obj, ev) =>
				{
					_cadClientes = null;

					tmRelogio.Enabled = true;
				});
			}
			else
			{
				_cadClientes.Focus();
			}
		}

		private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.isPizza)
			{
				CadastroClientes();
			}
		}

		private void cadastroDeEmitentesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadEmitentes form = new frmCadEmitentes(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadFornecedores form = new frmCadFornecedores(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CadastroProdutos();
		}

		private void cadastroDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadRecursos form = new frmCadRecursos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadMateriais form = new frmCadMateriais(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_usuario.Nivel != 'A')
			{
				MessageBox.Show("Usuário não autorizado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			frmCadUsuarios form = new frmCadUsuarios(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadVeiculos form = new frmCadVeiculos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void CadastroProdutos()
		{
			if (_cadProdutos == null)
			{
				_cadProdutos = new frmCadProdutos(_dsoftBd, _usuario);

				_cadProdutos.FormClosing += new FormClosingEventHandler((obj, ev) =>
				{
					_cadProdutos = null;
				});

				_cadProdutos.Show();
			}
			else
			{
				_cadProdutos.Focus();
			}
		}

		private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void capturaDePontosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//frmCapturaPonto form = new frmCapturaPonto(_dsoftBd, _usuario);

			//form.dtData.Enabled = false;
			//form.dtHora.Enabled = false;

			//form.ShowDialog();

			frmCapturaPonto2 form = new frmCapturaPonto2(_dsoftBd, _usuario);
			form.ShowDialog();
		}

		private void CarregarImagem()
		{
			try
			{
				this.Invoke(new Action(() =>
				{
					pictureBox1.BackgroundImage = Image.FromFile(Preferencias.ImagemFundo);
				}));
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar imagem de fundo." + Environment.NewLine + e.Message,
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarNiveis()
		{
			DesabilitaTudo();

			if (_usuario.NivelUsuario != null)
			{
				if (_usuario.NivelUsuario.Administrador)
				{
					HabilitaTudo();
				}
				else
				{
					if (_usuario.NivelUsuario.LancarPedidos)
					{
						HabilitaPedidos();
					}

					if (_usuario.NivelUsuario.Caixa)
					{
						HabilitaCaixa();
					}

					if (_usuario.NivelUsuario.ControleFinanceiro)
					{
						HabilitaControleFinanceiro();
					}

					if (_usuario.NivelUsuario.Entregas)
					{
						HabilitaEntregas();
					}

					if (_usuario.NivelUsuario.Relatorios)
					{
						HabilitaRelatorios();
					}

					if (_usuario.NivelUsuario.CadastrarProdutos)
					{
						HabilitaCadastrarProdutos();
					}

					if (_usuario.NivelUsuario.AlterarPrecos)
					{
						HabilitaAlterarPrecos();
					}

					if (_usuario.NivelUsuario.Compras)
					{
						HabilitaCompras();
					}

					if (_usuario.NivelUsuario.CadastrarRecursos)
					{
						HabilitaCadastrarRecursos();
					}

					if (_usuario.NivelUsuario.CadastrarUsuarios)
					{
						HabilitaCadastrarUsuarios();
					}

					if (_usuario.NivelUsuario.AlterarEstoque)
					{
						HabilitaAlterarEstoque();
					}

					if (_usuario.NivelUsuario.ScriptBd)
					{
						HabilitaScriptBd();
					}

					if (_usuario.NivelUsuario.Preferencias)
					{
						HabilitaPreferencias();
					}

					if (_usuario.NivelUsuario.Terminal)
					{
						HabilitaTerminal();
					}

					if (_usuario.NivelUsuario.RegrasDeNegocio)
					{
						HabilitaRegrasNegocio();
					}

					if (_usuario.NivelUsuario.CadastrarGruposDeClientes)
					{
						HabilitaCadastrarGruposDeClientes();
					}

					if (_usuario.NivelUsuario.Escritorio)
					{
						HabilitaEscritorio();
					}

					if (_usuario.NivelUsuario.Almoxarifado)
					{
						HabilitaAlmoxarifado();
					}
				}
			}
		}

		private void CarregarPreferencias()
		{
			this.Invoke(new Action(() =>
			{
				this.Text = Preferencias.Titulo;
			}));

			CarregarImagem();
		}

		private void CarregarRegrasDeNegocio()
		{
			_dsoftBd.CarregarRegrasDeNegocios();

			RegrasDeNegocio.Instance.RulesChanged += new EventHandler((obj, e) => { _dsoftBd.SalvarRegrasDeNegocios(obj.ToString()); });

			this.Invoke(new Action(() =>
			{
				miProcessos.Enabled = RegrasDeNegocio.Instance.ControlaProcessos;
			}));

			if (RegrasDeNegocio.Instance.AvisoAtraso > 0 && RegrasDeNegocio.Instance.SegundosAlerta > 0)
			{
				niAlerts.Visible = true;

				_alertaAtrasos = new AlertaAtrasos(this, _dsoftBd);
			}

			this.Invoke(new Action(() =>
			{
				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto || RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					miCadItensAdicionais.Enabled = false;
				}
				else
				{
					miCadItensAdicionais.Enabled = true;
				}
			}));

			this.Invoke(new Action(() =>
			{
				switch (RegrasDeNegocio.Instance.Ramo)
				{
					case "TRANSPORTADORA":
						orderButton1.Visible = false;
						collectButton1.Visible = true;
						collectButton1.Location = orderButton1.Location;

						deliveryButton1.Visible = false;
						manifestButton1.Visible = true;
						manifestButton1.Location = deliveryButton1.Location;

						miEntregas.Text = "Montagem de Manifestos";

						cashButton1.Enabled = false;
						btAtendimento.Enabled = false;

						btLocacao.Visible = false;

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						CTe.Integrador.Instance.Inicia(_dsoftBd, _usuario);

						break;

					case "ESCOLA":
						btEstoqueMatriz.Text = "Clientes Saldo";
						btEstoqueMatriz.Visible = true;

						btEmitirNFe.Visible = false;

						btLocacao.Visible = false;

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;

					case "PIZZARIA":
						btEstoqueMatriz.Visible = false;

						orderButton1.Visible = true;
						cashButton1.Visible = true;
						customersButton1.Visible = true;
						deliveryButton1.Visible = true;

						collectButton1.Visible = false;
						manifestButton1.Visible = false;

						miEntregas.Text = "&Entregas";

						cashButton1.Enabled = true;

						btLocacao.Visible = false;

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;

					case "LOJA":

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;

					case "FÁBRICA":
						btEmitirNFe.Visible = true;

						NFe.Integrador.Instance.Inicia(_dsoftBd, _usuario);

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;

					case "LOCADORA":
						btLocacao.Visible = true;

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;

					//case "SKY":

					//    miProdutos.Visible = false;
					//    miRecursos.Visible = false;
					//    miFinanceiro.Visible = false;
					//    miClientes.Visible = false;
					//    miDelivery.Visible = false;
					//    miConsultas.Visible = false;
					//    miRelatorios.Visible = false;
					//    miECF.Visible = false;
					//    miAlmoxarifado.Visible = true;
					//    miEscritorio.Visible = true;

					//    btLancamentoOS.Location = btPedidosNovo.Location;
					//    btLancamentoOS.Visible = true;
					//    btPagamentos.Location = btCaixa.Location;
					//    btPagamentos.Visible = true;
					//    btEstoque.Location = btClientes.Location;
					//    btEstoque.Visible = true;
					//    btEntregaDeEquipamentos.Location = btEntregas.Location;
					//    btEntregaDeEquipamentos.Visible = true;

					//    btPedidosNovo.Visible = false;
					//    btCaixa.Visible = false;
					//    btClientes.Visible = false;
					//    btEntregas.Visible = false;

					//    break;

					default:

						miEntregas.Text = "&Entregas";

						cashButton1.Enabled = true;
						btAtendimento.Enabled = true;

						miEscritorio.Visible = false;
						miAlmoxarifado.Visible = false;

						break;
				}
			}));
		}

		private void CarregarTerminal()
		{
			Caixa.Numero = Terminal.NumeroCaixa();
			_caixa = _dsoftBd.CarregarCaixa(Caixa.Numero);
		}

		private void clientesPorSaldoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConClientesSaldo form = new frmConClientesSaldo(_dsoftBd, _usuario);

			form.Show();
		}

		private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void consultaDeEntregasEmAbertoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConEntregasEmAberto form = new frmConEntregasEmAberto(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void controleDeAcessosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConAcessos form = new frmConAcessos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void controleDeEntregasToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Entregas();
		}

		private void controleDeEntregasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PedidosNovo();
		}

		private void controleFinanceiroToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbrirControleFinanceiro();
		}

		private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void DesabilitaAlterarEstoque()
		{
			this.Invoke(new Action(() =>
			{
				miEstoque.Enabled = false;
			}));
		}

		private void DesabilitaAlterarPrecos()
		{
			this.Invoke(new Action(() =>
			{
				miTabelasPrecos.Enabled = false;
			}));
		}

		private void DesabilitaCadastrarProdutos()
		{
			this.Invoke(new Action(() =>
			{
				miCadProdutos.Enabled = false;
				miCadItensAdicionais.Enabled = false;
				miCadMateriais.Enabled = false;
				miGruposTributarios.Enabled = false;
				miMedidas.Enabled = false;
			}));
		}

		private void DesabilitaCadastrarRecursos()
		{
			this.Invoke(new Action(() =>
			{
				miCadRecursos.Enabled = false;
				miCadEmitentes.Enabled = false;
				miCadVeiculos.Enabled = false;
			}));
		}

		private void DesabilitaCadastrarUsuarios()
		{
			this.Invoke(new Action(() =>
			{
				miCadUsuarios.Enabled = false;
				miCadCaixas.Enabled = false;
				miControleAcesso.Enabled = false;
			}));
		}

		private void DesabilitaCaixa()
		{
			this.Invoke(new Action(() =>
			{
				cashButton1.Enabled = false;
				miCaixa.Enabled = false;
			}));
		}

		private void DesabilitaCompras()
		{
			this.Invoke(new Action(() =>
			{
				miCompras.Enabled = false;
			}));
		}

		private void DesabilitaControleFinanceiro()
		{
			this.Invoke(new Action(() =>
			{
				miControleFinanceiro.Enabled = false;
				miDespesas.Enabled = false;
				miFolhaPagamento.Enabled = false;
				miRecebimentos.Enabled = false;
				miCalendario.Enabled = false;
				miEntregasDeCompras.Enabled = false;
			}));
		}

		private void DesabilitaEntregas()
		{
			this.Invoke(new Action(() =>
			{
				deliveryButton1.Enabled = false;
				miEntregas.Enabled = false;
				miConsultaEntregasEmAberto.Enabled = false;
			}));
		}

		private void DesabilitaPedidos()
		{
			this.Invoke(new Action(() =>
			{
				orderButton1.Enabled = false;
				miPedidos.Enabled = false;
			}));
		}

		private void DesabilitaPreferencias()
		{
			this.Invoke(new Action(() =>
			{
				miPreferencias.Enabled = false;
			}));
		}

		private void DesabilitaRegrasNegocio()
		{
			this.Invoke(new Action(() =>
			{
				miRegrasNegocio.Enabled = false;
			}));
		}

		private void DesabilitaRelatorios()
		{
			this.Invoke(new Action(() =>
			{
				miRelatorios.Enabled = false;
				miConsultas.Enabled = false;
			}));
		}

		private void DesabilitaScriptBd()
		{
			this.Invoke(new Action(() =>
			{
				miBancoDeDados.Enabled = false;
			}));
		}

		private void DesabilitaTerminal()
		{
			this.Invoke(new Action(() =>
			{
				miTerminal.Enabled = false;
			}));
		}

		private void DesabilitaTudo()
		{
			DesabilitaPedidos();
			DesabilitaCaixa();
			DesabilitaControleFinanceiro();
			DesabilitaEntregas();
			DesabilitaRelatorios();
			DesabilitaCadastrarProdutos();
			DesabilitaAlterarPrecos();
			DesabilitaCompras();
			DesabilitaCadastrarRecursos();
			DesabilitaCadastrarUsuarios();
			DesabilitaAlterarEstoque();
			DesabilitaScriptBd();
			DesabilitaPreferencias();
			DesabilitaTerminal();
			DesabilitaRegrasNegocio();
			DesabilitaCadastrarGruposDeClientes();
			DesabilitaFormasDePagamento();
			DesabilitaEscritorio();
			DesabilitaAlmoxarifado();
		}

		private void DesabilitaFormasDePagamento()
		{
			this.Invoke(new Action(() =>
			{
				miFormasDePagamento.Enabled = false;
			}));
		}

		private void DesabilitaCadastrarGruposDeClientes()
		{
			this.Invoke(new Action(() =>
			{
				miGruposDeClientes.Enabled = false;
			}));
		}

		private void HabilitaCadastrarGruposDeClientes()
		{
			this.Invoke(new Action(() =>
			{
				miGruposDeClientes.Enabled = true;
			}));
		}

		private void HabilitaEscritorio()
		{
			if (RegrasDeNegocio.Instance.Ramo == "SKY")
			{
				this.Invoke(new Action(() =>
				{
					miEscritorio.Enabled = true;
					btLancamentoOS.Enabled = true;
					btPagamentos.Enabled = true;
				}));
			}
		}

		private void HabilitaAlmoxarifado()
		{
			if (RegrasDeNegocio.Instance.Ramo == "SKY")
			{
				this.Invoke(new Action(() =>
				{
					miAlmoxarifado.Enabled = true;
					btEstoque.Enabled = true;
					btEntregaDeEquipamentos.Enabled = true;
				}));
			}
		}

		private void DesabilitaEscritorio()
		{
			if (RegrasDeNegocio.Instance.Ramo == "SKY")
			{
				this.Invoke(new Action(() =>
				{
					miEscritorio.Enabled = false;
					btLancamentoOS.Enabled = false;
					btPagamentos.Enabled = false;
				}));
			}
		}

		private void DesabilitaAlmoxarifado()
		{
			if (RegrasDeNegocio.Instance.Ramo == "SKY")
			{
				this.Invoke(new Action(() =>
				{
					miAlmoxarifado.Enabled = false;
					btEstoque.Enabled = false;
					btEntregaDeEquipamentos.Enabled = false;
				}));
			}
		}

		private void despesasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//frmDespesas form = new frmDespesas();
			DespesasView form = new DespesasView(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void EmitirNFe()
		{
			if (_emissaoNFe == null)
			{
				_emissaoNFe = new EmissaoNFeView(_dsoftBd, _usuario);

				_emissaoNFe.FormClosed += new FormClosedEventHandler((o, e) => { _emissaoNFe = null; });

				NFe.Integrador.Instance.frmEmissaoNFe = _emissaoNFe;

				_emissaoNFe.StartPosition = FormStartPosition.Manual;
				_emissaoNFe.Location = new Point(Location.X, Location.Y + 20);
			}

			_emissaoNFe.Show();
		}

		private void Entregas()
		{
			if (RegrasDeNegocio.Instance.Ramo == "TRANSPORTADORA")
			{
				frmManifestos form = new frmManifestos(_dsoftBd, _usuario);

				form.ShowDialog();
			}
			else
			{
				if (RegrasDeNegocio.Instance.isPizza)
				{
					frmEntregas form = new frmEntregas(_dsoftBd, _usuario);

					form.ShowDialog();
				}
			}
		}

		private void entregasDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmEntregasCompras form = new frmEntregasCompras(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void entregasPorEntregadorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConEntregasPorEntregador form = new frmConEntregasPorEntregador(_dsoftBd, _usuario);
			form.Show();
		}

		private void estoqueToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AbrirEstoque();
		}

		private void fechamentoDiárioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_usuario.Nivel != 'A')
			{
				MessageBox.Show("Usuário não autorizado!", "Relatório de fechamento diário", MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			frmData fdata = new frmData();

			fdata.Titulo = "Relatório de fechamento diário";

			if (fdata.ShowDialog() == DialogResult.Cancel)
				return;

			Fechamento fechamento = new Fechamento();

			fechamento.Indice = _dsoftBd.ConsultaFechamentoDiario(fdata.Data);
			_dsoftBd.CarregarFechamento(fechamento);

			if (fechamento.Indice < 1)
			{
				MessageBox.Show("Relatório não encontrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			//ProdutoGrupo[] grupos;

			//Bd.ProdutosGrupoFechamento(fechamento.Indice, out grupos);

			int pedidos_volume;
			int pedidos_itens;
			decimal pedidos_total;

			_dsoftBd.FechamentoPedidos(fechamento.Indice, out pedidos_volume, out pedidos_itens, out pedidos_total, _usuario.Autorizado);

			DataTable caixas = _dsoftBd.FechamentoCaixas(fechamento.Indice, _usuario.Autorizado);
			DataTable entradas = _dsoftBd.FechamentoEntradas(fechamento.Indice, _usuario.Autorizado);

			if (Terminal.RelatoriosMatricial)
			{
				Impressora.ImprimirFechamento(fechamento, pedidos_volume, pedidos_itens, pedidos_total, caixas, entradas);
			}
			else
			{
				Relatorios.FechamentoDiario.Gerar(fechamento, pedidos_volume, pedidos_itens, pedidos_total, caixas, entradas);
			}
		}

		private void fechamentosDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConFechamentos form = new frmConFechamentos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void fecToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void fluxoDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.isPizza)
			{
				frmCaixa form = new frmCaixa(_dsoftBd, _usuario);

				form.ShowDialog();
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			DSConfig.Instance.MainLocationX = this.Location.X.ToString();
			DSConfig.Instance.MainLocationY = this.Location.Y.ToString();
			DSConfig.Instance.MainWidth = this.Width.ToString();
			DSConfig.Instance.MainHeight = this.Height.ToString();

			_dsoftBd.LogarSaida(_usuario.Autorizado);
		}

		private void gruposDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CadClientesGrupos form = new CadClientesGrupos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void gruposDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadRecursosGrupos form = new frmCadRecursosGrupos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void gruposTributáriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadGruposTributarios form = new frmCadGruposTributarios(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void HabilitaAlterarEstoque()
		{
			this.Invoke(new Action(() =>
			{
				miEstoque.Enabled = true;
			}));
		}

		private void HabilitaAlterarPrecos()
		{
			this.Invoke(new Action(() =>
			{
				miTabelasPrecos.Enabled = true;
			}));
		}

		private void HabilitaCadastrarProdutos()
		{
			this.Invoke(new Action(() =>
			{
				miCadProdutos.Enabled = true;
				miCadItensAdicionais.Enabled = true;
				miCadMateriais.Enabled = true;
				miGruposTributarios.Enabled = true;
				miMedidas.Enabled = true;
			}));
		}

		private void HabilitaCadastrarRecursos()
		{
			this.Invoke(new Action(() =>
			{
				miCadRecursos.Enabled = true;
				miCadEmitentes.Enabled = true;
				miCadVeiculos.Enabled = true;
			}));
		}

		private void HabilitaCadastrarUsuarios()
		{
			this.Invoke(new Action(() =>
			{
				miCadUsuarios.Enabled = true;
				miCadCaixas.Enabled = true;
				miControleAcesso.Enabled = true;
			}));
		}

		private void HabilitaCaixa()
		{
			this.Invoke(new Action(() =>
			{
				cashButton1.Enabled = true;
				miCaixa.Enabled = true;
			}));
		}

		private void HabilitaCompras()
		{
			this.Invoke(new Action(() =>
			{
				miCompras.Enabled = true;
			}));
		}

		private void HabilitaControleFinanceiro()
		{
			this.Invoke(new Action(() =>
			{
				miControleFinanceiro.Enabled = true;
				miDespesas.Enabled = true;
				miFolhaPagamento.Enabled = true;
				miRecebimentos.Enabled = true;
				miCalendario.Enabled = true;
				miEntregasDeCompras.Enabled = true;
			}));
		}

		private void HabilitaEntregas()
		{
			this.Invoke(new Action(() =>
			{
				deliveryButton1.Enabled = true;
				miEntregas.Enabled = true;
				miConsultaEntregasEmAberto.Enabled = true;
			}));
		}

		private void HabilitaPedidos()
		{
			this.Invoke(new Action(() =>
			{
				orderButton1.Enabled = true;
				miPedidos.Enabled = true;
			}));
		}

		private void HabilitaPreferencias()
		{
			this.Invoke(new Action(() =>
			{
				miPreferencias.Enabled = true;
			}));
		}

		private void HabilitaRegrasNegocio()
		{
			this.Invoke(new Action(() =>
			{
				miRegrasNegocio.Enabled = true;
			}));
		}

		private void HabilitaRelatorios()
		{
			this.Invoke(new Action(() =>
			{
				miRelatorios.Enabled = true;
				miConsultas.Enabled = true;
			}));
		}

		private void HabilitaScriptBd()
		{
			this.Invoke(new Action(() =>
			{
				miBancoDeDados.Enabled = true;
			}));
		}

		private void HabilitaTerminal()
		{
			this.Invoke(new Action(() =>
			{
				miTerminal.Enabled = true;
			}));
		}

		private void HabilitaFormasDePagamento()
		{
			this.Invoke(new Action(() =>
			{
				miFormasDePagamento.Enabled = true;
			}));
		}

		private void HabilitaTudo()
		{
			HabilitaPedidos();
			HabilitaCaixa();
			HabilitaControleFinanceiro();
			HabilitaEntregas();
			HabilitaRelatorios();
			HabilitaCadastrarProdutos();
			HabilitaAlterarPrecos();
			HabilitaCompras();
			HabilitaCadastrarRecursos();
			HabilitaCadastrarUsuarios();
			HabilitaAlterarEstoque();
			HabilitaScriptBd();
			HabilitaPreferencias();
			HabilitaTerminal();
			HabilitaRegrasNegocio();
			HabilitaCadastrarGruposDeClientes();
			HabilitaFormasDePagamento();
			HabilitaEscritorio();
			HabilitaAlmoxarifado();
		}

		private bool IniciaConexao()
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

				while (!_dsoftBd.Conecta(host, porta, banco))
				{
					if (!ConfigurarArquivoIni())
					{
						return false;
					}
					else
					{
						file = new FileStream("dsoft.ini", FileMode.Open);

						conteudo = new byte[file.Length];

						file.Read(conteudo, 0, conteudo.Length);

						file.Close();

						dados = System.Text.Encoding.ASCII.GetString(conteudo);

						parametros = dados.Split(":".ToCharArray());

						host = parametros[0];
						porta = parametros[1];
						banco = parametros[2];
					}
				}

				return true;
			}
			catch (Exception e)
			{
				if (e is System.NullReferenceException)
				{
					if (ConfigurarArquivoIni())
					{
						return IniciaConexao();
					}
				}
				else
				{
					MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				return false;
			}
		}

		private bool ConfigurarArquivoIni()
		{
			frmConfigIni form = new frmConfigIni();

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void leituraXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_LeituraX());
		}

		private void reduçãoZToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_ReducaoZ("", ""));
		}

		private void licençaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLicenca form = new frmLicenca();
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void margemDeLucrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConMargemLucro form = new frmConMargemLucro(_dsoftBd, _usuario);

			form.Show();
		}

		private void miMedidas_Click(object sender, EventArgs e)
		{
			frmCadMedidas form = new frmCadMedidas(_dsoftBd, _usuario);
			form.Show();
		}

		private void pagamentoDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCompras form = new frmCompras(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void Pedidos()
		{
			if (RegrasDeNegocio.Instance.Ramo == "TRANSPORTADORA")
			{
				frmOrdemColeta form = new frmOrdemColeta(_dsoftBd, _usuario);

				form.ShowDialog();
			}
			else
			{
				PedidosView form = new PedidosView(_dsoftBd, _usuario);

				form.ShowDialog();
			}
		}

		private void PedidosNovo()
		{
			if (RegrasDeNegocio.Instance.isPizza || RegrasDeNegocio.Instance.Ramo == "LOJA")
			{
				if (!_dsoftBd.isConnected())
				{
					MessageBox.Show("Não foi possível se conectar ao banco-de-dados. Isso pode ser uma falha na rede ou o servidor pode estar desligado!", this.Text,
						MessageBoxButtons.OK, MessageBoxIcon.Hand);

					return;
				}

				if (_pedidos == null)
				{
					_pedidos = new Pedidos.PedidosView(_dsoftBd, _usuario);
					_pedidos.StartPosition = FormStartPosition.Manual;
					_pedidos.Location = new Point(Location.X, Location.Y + 20);

					_pedidos.FormClosing += new FormClosingEventHandler((obj, ev) =>
					{
						_pedidos = null;
					});

					_pedidos.Show(this);
				}
				else
				{
					_pedidos.Focus();
				}
			}
			else if (RegrasDeNegocio.Instance.Ramo == "SKY")
			{
				LancamentoOS();
			}
		}

		private void pedidosPorVendedorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConPedidosPorVendedor form = new frmConPedidosPorVendedor(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void preferênciasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmPreferencias form = new frmPreferencias();

			form.ShowDialog();

			CarregarPreferencias();
		}

		private void produtosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConProdutosPeriodo form = new frmConProdutosPeriodo(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void promissóriasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConPromissorias form = new frmConPromissorias(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void regrasDeNegócioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RegrasDeNegocioForm form = new RegrasDeNegocioForm(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarRegrasDeNegocio();
		}

		private void relatórioGerencialToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_RelatorioGerencial(""));
		}

		private void Sair()
		{
			Close();

			Application.Exit();
		}

		private void sangriaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_Sangria("0,00"));
		}

		private void sincronizarFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_dsoftBd.SincronizeFunctions();
		}

		private void sincronizarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_dsoftBd.BaixarProdutos();
		}

		private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			frmSobre form = new frmSobre(_dsoftBd.Versao());
			form.Show();
		}

		private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void tabelasDePreçosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadTabelas form = new frmCadTabelas(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void tiposDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CadClientesTipos form = new CadClientesTipos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void tiposDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadRecursosTipos form = new frmCadRecursosTipos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void tmRelogio_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = DateTime.Now.ToLongTimeString();
		}

		private void toolStripMenuItem10_Click(object sender, EventArgs e)
		{
			_usuario.Autorizado = 0;

			frmLogin form = new frmLogin(_dsoftBd, _usuario);

			form.ShowDialog();

			if (_usuario.Autorizado == 0)
			{
				Application.Exit();
			}
			else
			{
				// Redefine as limitações do usuário
				CarregarNiveis();
			}
		}

		private void toolStripMenuItem12_Click(object sender, EventArgs e)
		{
			frmNotasLotes form = new frmNotasLotes(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void toolStripMenuItem15_Click(object sender, EventArgs e)
		{
			if (_receber == null)
			{
				_receber = new frmReceber(_dsoftBd, _usuario);
				_receber.Show();

				_receber.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_receber.Dispose();
					_receber = null;
				});
			}
			else
			{
				_receber.Focus();
			}

			//frmRecebimentos form = new frmRecebimentos(_dsoftBd, _usuario);
			//form.ShowDialog();
		}

		private void toolStripMenuItem19_Click(object sender, EventArgs e)
		{
			double dinheiro, cartao, cheques, debito, crediario;
			double cdinheiro, ccartao, ccheques;

			frmFiltroData frmData = new frmFiltroData(_dsoftBd, _usuario);

			frmData.Text = "Movimentos por Período";

			if (frmData.ShowDialog() == DialogResult.Cancel)
				return;

			_dsoftBd.VendasPeriodo(frmData.dateTimePicker1.Value, frmData.dateTimePicker2.Value, out dinheiro, out cartao, out cheques, out debito, out crediario, _usuario.Autorizado);

			_dsoftBd.CaixaPeriodo(frmData.dateTimePicker1.Value, frmData.dateTimePicker2.Value, out cdinheiro, out ccartao, out ccheques);

			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.GerarMovimentosPeriodo(frmData.dateTimePicker1.Value.ToString("dd/MM/yy"), frmData.dateTimePicker2.Value.ToString("dd/MM/yy"),
				dinheiro, cartao, cheques, debito, crediario, cdinheiro, ccartao, ccheques);
		}

		private void toolStripMenuItem21_Click(object sender, EventArgs e)
		{
			frmBDScripts form = new frmBDScripts(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem23_Click(object sender, EventArgs e)
		{
			frmCadAdicionais form = new frmCadAdicionais(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			AbrirTerminal();
		}

		public void AbrirTerminal()
		{
			TerminalForm form = new TerminalForm();

			form.ShowDialog();

			CarregarTerminal();
		}

		private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
		{
			frmMatriz form = new frmMatriz();

			form.ShowDialog();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			tmRelogio.Enabled = false;

			frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDeCaixa);

			form.ShowDialog();

			tmRelogio.Enabled = true;
		}

		private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			frmCadCaixa form = new frmCadCaixa(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
		{
			frmHistorico form = new frmHistorico();

			form.Show();
		}

		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{
		}

		private void tsControleDePontos_Click(object sender, EventArgs e)
		{
			//if (_usuario.Nivel != 'A')
			//{
			//    MessageBox.Show("Acesso não autorizado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

			//    return;
			//}

			//frmControlePontos form = new frmControlePontos(_dsoftBd, _usuario);

			//form.ShowDialog();
		}

		private void vendasPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//frmFiltroData frmData = new frmFiltroData();

			//frmData.Text = "Vendas por Período";

			//if (frmData.ShowDialog() == DialogResult.Cancel)
			//    return;

			//frmRelatorio form = new frmRelatorio();

			//grafVendasPeriodo report = new grafVendasPeriodo();

			//report.ParameterFields["inicial"].CurrentValues.AddValue(frmData.dateTimePicker1.Value);
			//report.ParameterFields["final"].CurrentValues.AddValue(frmData.dateTimePicker2.Value);

			////form.crystalReportViewer1.ReportSource = report;

			//form.Text = "Gráfico de Vendas por Período";

			//form.Show();
		}

		private void VerificarLicenca()
		{
			if (Licenca.Instance.Demo)
			{
				lbLicenca.Text = "*Software não licenciado. Liberado para demonstração.";
			}
			else if (Licenca.Instance.Expirou)
			{
				lbLicenca.Text = "*Licença expirou. Entre em contato com o suporte.";
			}
			else if (Licenca.Instance.DiasRestantes <= Preferencias.LicencaAviso)
			{
				lbLicenca.Text = "*Licença de uso expira em " + Licenca.Instance.DiasRestantes.ToString() + " dias.";
			}
		}

		private void toolStripMenuItem7_Click_2(object sender, EventArgs e)
		{
			frmCadProdutosTipos form = new frmCadProdutosTipos(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
		{
			frmCadProdutosGrupos form = new frmCadProdutosGrupos(_dsoftBd, _usuario);
			form.Show();
		}

		private void btLocacao_Click(object sender, EventArgs e)
		{
			frmLocacao form = new frmLocacao(_dsoftBd, _usuario);
			form.WindowState = FormWindowState.Maximized;
			form.Show();
		}

		private void leituraDaMemóriaFiscalPorDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);
			form.Text = "Leitura da memória fiscal";

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_LeituraMemoriaFiscalData(form.Inicial.ToShortDateString(), form.Final.ToShortDateString()));
			}
		}

		private void toolStripMenuItem24_Click(object sender, EventArgs e)
		{
			ShowAlert("Teste de mensagem de alerta");
		}

		private void niAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			frmEntregas form = new frmEntregas(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem25_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.isPizza || RegrasDeNegocio.Instance.Ramo == "LOJA")
			{
				frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDeCaixa);
				form.ShowDialog();
			}
		}

		private void toolStripMenuItem26_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.isPizza || RegrasDeNegocio.Instance.Ramo == "LOJA")
			{
				frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDiario);
				form.Text = "Fechamento Diário";
				form.ShowDialog();
			}
		}

		private void movimentoDiaADiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConDiaDia form = new frmConDiaDia(_dsoftBd, _usuario);
			form.Show();
		}

		private void pedidosPorGruposDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConPedidosPorGruposDeClientes form = new frmConPedidosPorGruposDeClientes(_dsoftBd, _usuario);
			form.Show();
		}

		private void entregadoresDisponíveisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmEntregadoresDisponiveis form = new frmEntregadoresDisponiveis(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem27_Click(object sender, EventArgs e)
		{
			frmCalendarioDeTabelas form = new frmCalendarioDeTabelas(_dsoftBd, _usuario);
			form.Show();
		}

		private void aberturaDoDiaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ECFHelper helper = new ECFHelper();
			helper.AberturaDoDia("0", "");
		}

		private void redefinirFormasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ECFHelper helper = new ECFHelper();

			List<FormaDePagamento> formas_de_pagamento = _dsoftBd.FormasDePagamento();
			List<string> descricoes = new List<string>();

			foreach (FormaDePagamento forma in formas_de_pagamento)
			{
				descricoes.Add(forma.Descricao);
			}

			helper.ProgramaFormasDePagamento(descricoes);
		}

		private void toolStripMenuItem29_Click(object sender, EventArgs e)
		{
			ECFHelper helper = new ECFHelper();
			helper.CancelaCupom();
		}

		private void toolStripMenuItem31_Click(object sender, EventArgs e)
		{
			ECFHelper helper = new ECFHelper();
			helper.LeituraX();
		}

		private void toolStripMenuItem32_Click(object sender, EventArgs e)
		{
			string confirma = string.Format("Confirma o fechamento do dia no ECF? "
				+ "(Esse procedimento só pode ser efetuado uma vez por dia ({0}) e o ECF só poderá ser utilizado novamente no dia seguinte)", DateTime.Today.ToShortDateString());

			if (MessageBox.Show(confirma, "ECF - Fechamento do dia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
				== System.Windows.Forms.DialogResult.Yes)
			{
				ECFHelper helper = new ECFHelper();
				helper.FechamentoDoDia();
			}
		}

		private void toolStripMenuItem33_Click(object sender, EventArgs e)
		{
			string confirma = string.Format("Confirma a Redução Z? "
				+ "(Esse procedimento só pode ser efetuado uma vez por dia ({0}) e o ECF só poderá ser utilizado novamente no dia seguinte)", DateTime.Today.ToShortDateString());

			if (MessageBox.Show(confirma, "ECF - Fechamento do dia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
				== System.Windows.Forms.DialogResult.Yes)
			{
				ECFHelper helper = new ECFHelper();
				helper.ReducaoZ(DateTime.Today, DateTime.Now);
			}
		}

		private void toolStripMenuItem34_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma o download da memória fiscal do ECF?", "ECF", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
				== System.Windows.Forms.DialogResult.Yes)
			{
				ECFHelper helper = new ECFHelper();
				helper.DownloadMF(Terminal.DownloadMF);
			}
		}

		private void toolStripMenuItem35_Click(object sender, EventArgs e)
		{
			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);
			form.Text = "Leitura da memória fiscal por data";
			form.dateTimePicker1.Value = DateTime.Today;
			form.dateTimePicker2.Value = DateTime.Today;

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				ECFHelper helper = new ECFHelper();
				helper.LeituraMemoriaFiscalData(form.dateTimePicker1.Value, form.dateTimePicker2.Value);
			}
		}

		private void excluirRegistrosDuplicadosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_dsoftBd.ExcluirRegistrosDuplicados();
		}

		private void toolStripMenuItem36_Click(object sender, EventArgs e)
		{
			frmConClientesPorPedidos form = new frmConClientesPorPedidos(_dsoftBd, _usuario);
			form.Show();
		}

		private void miBancoDeDadosRedefinirBairros_Click(object sender, EventArgs e)
		{
			_dsoftBd.RedefinirBairrosPeloCep();
		}

		private void miAberturaDeCaixa_Click(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.isPizza)
			{
				if (_aberturaDeCaixa == null)
				{
					_aberturaDeCaixa = new frmAberturaDeCaixa(_dsoftBd, _usuario);
					_aberturaDeCaixa.ShowDialog();

					_aberturaDeCaixa.Dispose();
					_aberturaDeCaixa = null;
				}
			}
		}

		private void miFormasDePagamento_Click(object sender, EventArgs e)
		{
			frmCadFormasDePagamento form = new frmCadFormasDePagamento(_dsoftBd, _usuario);
			form.ShowDialog();
		}

		private void toolStripMenuItem15_Click_1(object sender, EventArgs e)
		{
			_dsoftBd.VerificarBD();
		}

		private void cadastroDeRecursosToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			frmCadRecursos form = new frmCadRecursos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeUsuáriosToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (_usuario.Nivel != 'A')
			{
				MessageBox.Show("Usuário não autorizado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			frmCadUsuarios form = new frmCadUsuarios(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void cadastroDeProdutosToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			CadastroProdutos();
		}

		private void toolStripMenuItem15_Click_2(object sender, EventArgs e)
		{
			frmCadProdutosTipos form = new frmCadProdutosTipos(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem17_Click(object sender, EventArgs e)
		{
			frmCadProdutosGrupos form = new frmCadProdutosGrupos(_dsoftBd, _usuario);
			form.Show();
		}

		private void miTiposDeServicos_Click(object sender, EventArgs e)
		{
			if (_cadTiposDeServicos == null)
			{
				_cadTiposDeServicos = new frmCadTiposDeServicos(_dsoftBd, _usuario);

				_cadTiposDeServicos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_cadTiposDeServicos.Dispose();
					_cadTiposDeServicos = null;
				});

				_cadTiposDeServicos.Show();
			}
			else
			{
				_cadTiposDeServicos.Focus();
			}
		}

		private void lançamentoDeOSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LancamentoOS();
		}

		private void btLancamentoOS_Click(object sender, EventArgs e)
		{
			LancamentoOS();
		}

		private void LancamentoOS()
		{
			if (_lancamentoOS == null)
			{
				_lancamentoOS = new frmLancamentoOS(_dsoftBd, _usuario);

				_lancamentoOS.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_lancamentoOS.Dispose();
					_lancamentoOS = null;
				});

				_lancamentoOS.Show();
			}
			else
			{
				_lancamentoOS.Focus();
			}
		}

		private void entregaDeEquipamentosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbrirEntregaDeEquipamentos();
		}

		private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbrirEstoque();
		}

		private void AbrirEstoque()
		{
			if (_estoque == null)
			{
				_estoque = new frmEstoque(_dsoftBd, _usuario);

				_estoque.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_estoque.Dispose();
					_estoque = null;
				});

				_estoque.Show();
			}
			else
			{
				_estoque.Focus();
			}
		}

		private void pagamentosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbrirFolhaDePagamentosDeServicos();
		}

		private void AbrirFolhaDePagamentosDeServicos()
		{
			if (_folhaDePagamentosServicos == null)
			{
				_folhaDePagamentosServicos = new frmFolhaDePagamentosServicos(_dsoftBd, _usuario);

				_folhaDePagamentosServicos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_folhaDePagamentosServicos.Dispose();
					_folhaDePagamentosServicos = null;
				});

				_folhaDePagamentosServicos.Show();
			}
			else
			{
				_folhaDePagamentosServicos.Focus();
			}
		}

		private void AbrirEntregaDeEquipamentos()
		{
			if (_entregaDeEquipamentos == null)
			{
				_entregaDeEquipamentos = new frmEntregaDeEquipamentos(_dsoftBd, _usuario);

				_entregaDeEquipamentos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_entregaDeEquipamentos.Dispose();
					_entregaDeEquipamentos = null;
				});

				_entregaDeEquipamentos.Show();
			}
			else
			{
				_entregaDeEquipamentos.Focus();
			}
		}

		private void AbrirControleFinanceiro()
		{
			if (_financeiroView == null)
			{
				_financeiroView = new FinanceiroView(_dsoftBd, _usuario);

				_financeiroView.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_financeiroView.Dispose();
					_financeiroView = null;
				});

				_financeiroView.Show();
			}
			else
			{
				_financeiroView.Focus();
			}
		}

		private void controleFinanceiroToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			AbrirControleFinanceiro();
		}

		private void recebimentoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_recebimentoDeProdutos == null)
			{
				_recebimentoDeProdutos = new frmRecebimentoDeProdutos(_dsoftBd, _usuario);

				_recebimentoDeProdutos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_recebimentoDeProdutos.Dispose();
					_recebimentoDeProdutos = null;
				});

				_recebimentoDeProdutos.Show();
			}
			else
			{
				_recebimentoDeProdutos.Focus();
			}
		}

		private void btPagamentos_Click(object sender, EventArgs e)
		{
			AbrirFolhaDePagamentosDeServicos();
		}

		private void btEstoque_Click(object sender, EventArgs e)
		{
			AbrirEstoque();
		}

		private void btEntregaDeEquipamentos_Click(object sender, EventArgs e)
		{
			AbrirEntregaDeEquipamentos();
		}

		private void serviçosEfetuadosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConServicosEfetuadosPorPeriodo form = new frmConServicosEfetuadosPorPeriodo(_dsoftBd, _usuario);
			form.Show();
		}

		private void serviçosEfetuadosPorFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConServicosEfetuadosPorFuncionario form = new frmConServicosEfetuadosPorFuncionario(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
		{
			CadastroClientes();
		}

		private void toolStripMenuItem25_Click_1(object sender, EventArgs e)
		{
			CadastroDePeriodos();
		}

		private void CadastroDePeriodos()
		{
			if (_cadastroDePeriodos == null)
			{
				_cadastroDePeriodos = new frmCadPeriodos(_dsoftBd, _usuario);

				_cadastroDePeriodos.FormClosing += new FormClosingEventHandler((s, ev) =>
				{
					_cadastroDePeriodos.Dispose();
					_cadastroDePeriodos = null;
				});

				_cadastroDePeriodos.Show();
			}
			else
			{
				_cadastroDePeriodos.Focus();
			}
		}

		private void confirmarUsoDosEquipamentosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConfirmarUsoEquipamentos form = new frmConfirmarUsoEquipamentos(_dsoftBd, _usuario);
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void transferênciaDeEstoqueEntreFiliaisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmTransferenciaEstoque form = new frmTransferenciaEstoque(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem27_Click_1(object sender, EventArgs e)
		{
			frmCadFiliais form = new frmCadFiliais(_dsoftBd, _usuario);
			form.Show();
		}

		private void fechamentoDiárioDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConFechamentoDiarioDetalhado form = new frmConFechamentoDiarioDetalhado(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem38_Click(object sender, EventArgs e)
		{
			LancarSaida form = new LancarSaida(_dsoftBd, _usuario, _caixa);
			form.ShowDialog();
		}

		private void consultaDeSaídasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConSaidas form = new frmConSaidas(_dsoftBd, _usuario);
			form.Show();
		}

		private void toolStripMenuItem39_Click(object sender, EventArgs e)
		{
			LancarEntrada form = new LancarEntrada(_dsoftBd, _usuario, _caixa);
			form.Show();
		}

		public void MostrarNotificacao(string mensagem, EventHandler funcao)
		{
			lbNotificacao.Text = mensagem;
			llNotificacao.Click += funcao;
			pnlNotificacoes.Visible = true;
		}

		public void LimparNotificacoes()
		{
			lbNotificacao.Text = string.Empty;
			pnlNotificacoes.Visible = false;
		}

		#endregion Methods

		private void consultarSATToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Tanca.ConsultarSAT();
		}
	}
}