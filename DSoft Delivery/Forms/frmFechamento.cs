using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;
using DSoftCore;
using DSoftModels;
using DSoftParameters;
using DSoft_Delivery.Forms;
using DSoftModels.Enums;
using DSoftConfig;

namespace DSoft_Delivery
{
	public partial class frmFechamento : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;
		private DSoftModels.Enums.Fechamentos _tipo;

		private FechamentoDiario _fechamentoDiario;

		#endregion Fields

		#region Constructors

		public frmFechamento(Bd bd, Usuario usuario, Fechamentos tipo)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_tipo = tipo;

			confirmButton1.Click += button1_Click;
			quitButton1.Click += button2_Click;
			printLittleButton1.Click += btReimprimir_Click;
		}

		#endregion Constructors

		#region Methods

		private void btReimprimir_Click(object sender, EventArgs e)
		{
			Impressora.ImprimirTicket(tbTicket.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int numero)
		{
			FechamentoDeCaixa fechamento = _dsoftBd.ConsultaFechamentoDeCaixa(numero);

			tbTicket.Clear();

			tbTicket.AppendText(string.Format("FECHAMENTO DE CAIXA N.{0}\n", fechamento.Numero));
			tbTicket.AppendText(string.Format("{0} - {1}   {2}\n", dtData.Value.ToShortDateString(), DateTime.Now.ToShortTimeString(), fechamento.Caixa));
			tbTicket.AppendText(string.Format("{0}\n", new string('=', Terminal.ImpressoraColunas)));
			tbTicket.AppendText(string.Format("SALDO INICIAL{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 29), fechamento.SaldoAnterior.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("ENTRADAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), fechamento.Entradas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("SAIDAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), fechamento.Saidas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("DESPESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), fechamento.Despesas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("VALES{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), fechamento.Vales.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("PAGAMENTOS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 26), fechamento.Pagamentos.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("TRANSFERENCIAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 30), fechamento.Transferencias.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
			tbTicket.AppendText(string.Format("SALDO ATUAL{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 27), fechamento.SaldoAtual.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText("\n");

			foreach (var formaDePagamento in fechamento.FormasDePagamento)
			{
				tbTicket.AppendText(string.Format("{0}{1} R$ {2}\n", formaDePagamento.Key.Descricao, new string('.', Terminal.ImpressoraColunas - (16 + formaDePagamento.Key.Descricao.Length)), formaDePagamento.Value.ToString("##,###,##0.00").PadLeft(12)));
			}
		}

		private void CarregarDadosAberto(Caixa caixa)
		{
			FechamentoDeCaixa fechamento = _dsoftBd.CaixaAberto(caixa);

			tbTicket.Clear();

			tbTicket.AppendText("FECHAMENTO DE CAIXA\n");
			tbTicket.AppendText(string.Format("{0} - {1}   {2}\n", dtData.Value.ToShortDateString(), DateTime.Now.ToShortTimeString(), caixa));
			tbTicket.AppendText(string.Format("{0}\n", new string('=', Terminal.ImpressoraColunas)));
			tbTicket.AppendText(string.Format("SALDO INICIAL{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 29), fechamento.SaldoAnterior.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("ENTRADAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), fechamento.Entradas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("SAIDAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), fechamento.Saidas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("DESPESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), fechamento.Despesas.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("VALES{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), fechamento.Vales.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("PAGAMENTOS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 26), fechamento.Pagamentos.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("TRANSFERENCIAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 30), fechamento.Transferencias.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
			tbTicket.AppendText(string.Format("SALDO ATUAL{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 27), fechamento.SaldoAtual.ToString("##,###,##0.00").PadLeft(12)));
			tbTicket.AppendText("\n");

			foreach (var formaDePagamento in fechamento.FormasDePagamento)
			{
				tbTicket.AppendText(string.Format("{0}{1} R$ {2}\n", formaDePagamento.Key.Descricao, new string('.', Terminal.ImpressoraColunas - (16 + formaDePagamento.Key.Descricao.Length)), formaDePagamento.Value.ToString("##,###,##0.00").PadLeft(12)));
			}

			tbSenha.Focus();
		}

		private void CarregarDadosDia(DateTime data, bool somar_pagamentos_aberto = true)
		{
			_fechamentoDiario = _dsoftBd.MovimentoDiarioEmAberto();
			Dictionary<Recurso, decimal> pagamentos_entregadores = null;

			tbTicket.Clear();

			if (_fechamentoDiario != null)
			{
				decimal _diaria = 0;
				decimal _taxa_entrega = 0;
				List<Recurso> entregadores_ativos = null;

				if (RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores)
				{
					_diaria = _dsoftBd.DiariaEntregador();
					_taxa_entrega = _dsoftBd.PagamentoPorEntrega();
					decimal total_entregadores = 0;

					if (somar_pagamentos_aberto)
					{
						if (_diaria == 0 && _taxa_entrega == 0)
						{
							pagamentos_entregadores = _dsoftBd.PagamentosEntregadoresEmAberto();

							if (pagamentos_entregadores != null)
							{
								foreach (decimal valor in pagamentos_entregadores.Values)
								{
									total_entregadores += valor;
								}
							}
						}
						else
						{
							total_entregadores = (decimal)_dsoftBd.QuantidadeEntregasEmAberto() * _taxa_entrega;

							if (RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores)
							{
								entregadores_ativos = _dsoftBd.EntregadoresDisponiveis();

								total_entregadores += entregadores_ativos.Count * _diaria;
							}
							else
							{
								total_entregadores += _dsoftBd.QuantidadeEntregadoresAtivosNoDia() * _diaria;
							}
						}

						total_entregadores -= _dsoftBd.PagamentosEmAberto();

						_fechamentoDiario.Pagamentos += total_entregadores;
						_fechamentoDiario.SaldoAtual -= total_entregadores;
					}
				}

				tbTicket.AppendText("FECHAMENTO DIARIO\n");
				tbTicket.AppendText(string.Format("{0} - {1}\n", dtData.Value.ToShortDateString(), DateTime.Now.ToShortTimeString()));
				tbTicket.AppendText(string.Format("{0}\n", new string('=', Terminal.ImpressoraColunas)));
				tbTicket.AppendText(string.Format("SALDO ANTERIOR{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 30), _fechamentoDiario.SaldoAnterior.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("ENTRADAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Entradas.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("SAIDAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), _fechamentoDiario.Saidas.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("DESPESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Despesas.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("VALES{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.Vales.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("PAGAMENTOS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 26), _fechamentoDiario.Pagamentos.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				tbTicket.AppendText(string.Format("SALDO{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.SaldoAtual.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText("\n");

				foreach (var formaDePagamento in _fechamentoDiario.FormasDePagamento)
				{
					tbTicket.AppendText(string.Format("{0}{1} R$ {2}\n", formaDePagamento.Key.Descricao, new string('.', Terminal.ImpressoraColunas - (16 + formaDePagamento.Key.Descricao.Length)), formaDePagamento.Value.ToString("##,###,##0.00").PadLeft(12)));
				}

				tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				tbTicket.AppendText(string.Format("BALCAO{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), _fechamentoDiario.VendaDireta.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("MESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.ClienteInterno.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("DELIVERY{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Delivery.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				tbTicket.AppendText(string.Format("PEDIDOS CANCELADOS{0} {1}\n", new string('.', Terminal.ImpressoraColunas - 31), _fechamentoDiario.PedidosCancelados.ToString().PadLeft(12)));
				tbTicket.AppendText(string.Format("TOTAL CANCELADO {0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 32), _fechamentoDiario.TotalCancelado.ToString("##,###,##0.00").PadLeft(12)));
				tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				tbTicket.AppendText(string.Format("PRODUTOS{0}VOLUME  TOTAL          \n", new string(' ', Terminal.ImpressoraColunas - 31)));

				foreach (MovimentoTipoProduto m in _fechamentoDiario.Movimentos)
				{
					tbTicket.AppendText(string.Format("{0} {1,6}  R$ {2,12}\n", Util.Formata(m.Tipo.Nome, (Terminal.ImpressoraColunas - 24), ' '), m.Volume.ToString("0.00"), m.Total.ToString("#,###,##0.00")));
				}

				if (RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores)
				{
					tbTicket.AppendText("\n\n");
					tbTicket.AppendText(string.Format("ENTREGADORES {0}   VALES   PAGTOS\n", new string(' ', (Terminal.ImpressoraColunas - 30))));
					tbTicket.AppendText(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));

					if (_taxa_entrega == 0)
					{
						if (pagamentos_entregadores == null)
						{
							pagamentos_entregadores = _dsoftBd.PagamentosEntregadoresEmAberto();
						}

						foreach (var pagamento in pagamentos_entregadores)
						{
							decimal valor = 0;
							decimal vales = _dsoftBd.ValesEmAberto(pagamento.Key);

							if (somar_pagamentos_aberto)
							{
								valor = pagamento.Value;
							}
							else
							{
								valor = _dsoftBd.PagamentosEmAberto(pagamento.Key);
							}

							tbTicket.AppendText(string.Format("{0} {1} {2}\n", Util.Formata(pagamento.Key.ToString(), Terminal.ImpressoraColunas - 18, '.'), vales.ToString("#,##0.00").PadLeft(8), valor.ToString("#,##0.00").PadLeft(8)));
						}
					}
					else
					{
						if (entregadores_ativos == null)
						{
							entregadores_ativos = _dsoftBd.EntregadoresDisponiveis();
						}

						foreach (Recurso entregador in entregadores_ativos)
						{
							decimal total = _diaria;
							int quantidade_entregas = _dsoftBd.QuantidadeEntregasEmAberto(entregador);
							decimal vales = _dsoftBd.ValesEmAberto(entregador);

							if (RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores || quantidade_entregas > 0)
							{
								total += (quantidade_entregas * _taxa_entrega);

								if (somar_pagamentos_aberto)
								{
									total -= _dsoftBd.PagamentosEmAberto(entregador);
								}

								tbTicket.AppendText(string.Format("{0} {1} {2}\n", Util.Formata(entregador.Nome, Terminal.ImpressoraColunas - 18, '.'), vales.ToString("#,##0.00").PadLeft(8), total.ToString("#,##0.00").PadLeft(8)));
							}
						}
					}
				}
			}
		}

		private void Confirmar()
		{
			int numero;

			if (!int.TryParse(tbUsuario.Text, out numero) || _dsoftBd.UsuarioCadastrado(numero, tbSenha.Text) == '0')
			{
				MessageBox.Show("Usuário inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				tbUsuario.SelectAll();
				tbUsuario.Focus();

				return;
			}

			Usuario usuario = new Usuario(numero);

			if (_tipo == Fechamentos.FechamentoDeCaixa)
			{
				EfetuarFechamentoDeCaixa(usuario);
				Sair();
			}
			else
			{
				if (_dsoftBd.FechamentoDiario(dtData.Value) > 0)
				{
					MessageBox.Show("Fechamento de caixa já efetuado para esta data!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}

				if (RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores)
				{
					decimal diaria = _dsoftBd.DiariaEntregador();

					if (RegrasDeNegocio.Instance.TaxaPagaPorEntrega)
					{
						LancarPagamentosEntregadoresEspecial(diaria, usuario);
					}
					else
					{
						decimal _taxa_entrega = _dsoftBd.PagamentoPorEntrega();

						if (_taxa_entrega > 0)
						{
							LancarPagamentosEntregadores(diaria, _taxa_entrega, usuario);
						}
						else
						{
							LancarPagamentosEntregadores(diaria, usuario);
						}
					}
				}

				if (_dsoftBd.MovimentoEmAberto())
				{
					if (RegrasDeNegocio.Instance.FechaCaixaAutomaticamente)
					{
						EfetuarFechamentoDeCaixa(usuario, false);
						CarregarDadosDia(dtData.Value, false);
					}
				}

				if (RegrasDeNegocio.Instance.BaixaPedidosNoFechamentoDiario)
				{
					_dsoftBd.BaixaPedidosEmAberto();
				}

				int retorno;

				if ((retorno = _dsoftBd.EfetuarFechamentoDiario(dtData.Value, usuario)) > 0)
				{
					if (MessageBox.Show("Imprimir ticket?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
					{
						Impressora.ImprimirTicket(tbTicket.Text);
					}

					if (RegrasDeNegocio.Instance.EmiteCupomFiscal && cbReducaoZ.Checked)
					{
						if (MessageBox.Show(string.Format("Deseja efetuar a Redução Z? Esta operação não pode ser desfeita e impossibilitará o uso do ECF durante todo o dia corrente ({0}).", DateTime.Today.ToShortDateString()),
							"ECF", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
						{
							ECFHelper helper = new ECFHelper();
							helper.ReducaoZ(DateTime.Now, DateTime.Now);
						}
					}

					_dsoftBd.AlterarDisponibilidadeEntregadores(false);

					if (cbBackup.Checked)
					{
						_dsoftBd.Backup();
					}

					Sair();
				}
				else
				{
					if (retorno == -1)
					{
						MessageBox.Show("Existem caixas em aberto! Por favor, efetue os fechamentos de caixa antes de efetuar o fechamento diário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Fechamento de caixa já efetuado para esta data!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		private void LancarPagamentosEntregadores(decimal diaria, decimal taxa_entrega, Usuario usuario)
		{
			List<Recurso> entregadores_ativos = _dsoftBd.EntregadoresDisponiveis();

			foreach (Recurso entregador in entregadores_ativos)
			{
				decimal total = diaria;
				decimal pagamentos = _dsoftBd.PagamentosEmAberto(entregador);
				decimal vales = _dsoftBd.ValesEmAberto(entregador);
				int quantidade_entregas = _dsoftBd.QuantidadeEntregasEmAberto(entregador);

				if (RegrasDeNegocio.Instance.GerenciaDisponibilidadeDeEntregadores || quantidade_entregas > 0)
				{
					total += (quantidade_entregas * taxa_entrega);
					total -= (pagamentos + vales);

					tbTicket.AppendText(string.Format("{0} R$ {1}\n", Util.Formata(entregador.Nome, Terminal.ImpressoraColunas - 16, '.'), total.ToString("##,###,##0.00").PadLeft(12)));

					FluxoDeCaixa pagamento = new FluxoDeCaixa();
					pagamento.Caixa = Caixa.Numero;
					pagamento.Data = DateTime.Today;
					pagamento.Forma = 'D';
					pagamento.Recurso = entregador.Codigo;
					pagamento.Tipo = 'P';
					pagamento.Valor = total;
					pagamento.Observacao = string.Format("PAGAMENTO REFERENTE À DIÁRIA DE R$ {0} E {1} ENTREGAS. GERADO AUTOMATICAMENTE NO FECHAMENTO DIÁRIO.",
						diaria.ToString("##,###,##0.00"), quantidade_entregas);

					if ((pagamentos + vales) > 0)
					{
						pagamento.Observacao = string.Concat(pagamento.Observacao, string.Format(" DESCONTO DE R$ {0} REFERENTE À VALES OU PAGAMENTOS ANTERIORES.", (pagamentos + vales).ToString("##,###,##0.00")));
					}

					_dsoftBd.LancarPagamento(pagamento, Caixa.Numero, usuario.Codigo);
				}
			}
		}

		private void LancarPagamentosEntregadores(decimal diaria, Usuario usuario)
		{
			Dictionary<Recurso, decimal> pagamentos_entregadores = _dsoftBd.PagamentosEntregadoresEmAberto();

			if (pagamentos_entregadores != null && pagamentos_entregadores.Count > 0)
			{
				foreach (var pagamento_entregador in pagamentos_entregadores)
				{
					decimal pagamentos = _dsoftBd.PagamentosEmAberto(pagamento_entregador.Key);
					decimal vales = _dsoftBd.ValesEmAberto(pagamento_entregador.Key);

					FluxoDeCaixa pagamento = new FluxoDeCaixa();
					pagamento.Caixa = Caixa.Numero;
					pagamento.Data = DateTime.Today;
					pagamento.Forma = 'D';
					pagamento.Recurso = pagamento_entregador.Key.Codigo;
					pagamento.Tipo = 'P';
					pagamento.Valor = pagamento_entregador.Value + diaria;
					pagamento.Observacao = "PAGAMENTO REFERENTE À ENTREGAS. GERADO AUTOMATICAMENTE NO FECHAMENTO DIÁRIO.";

					if ((pagamentos + vales) > 0)
					{
						pagamento.Valor -= (pagamentos + vales);
						pagamento.Observacao = string.Concat(pagamento.Observacao, string.Format(" DESCONTO DE R$ {0} REFERENTE À VALES OU PAGAMENTOS ANTERIORES.", (pagamentos + vales).ToString("##,###,##0.00")));
					}

					_dsoftBd.LancarPagamento(pagamento, Caixa.Numero, usuario.Codigo);
				}
			}
		}

		private void LancarPagamentosEntregadoresEspecial(decimal diaria, Usuario usuario)
		{
			Dictionary<Recurso, decimal> pagamentos_entregadores = _dsoftBd.PagamentosEntregadoresEmAbertoEspecial();

			if (pagamentos_entregadores != null && pagamentos_entregadores.Count > 0)
			{
				foreach (var pagamento_entregador in pagamentos_entregadores)
				{
					decimal pagamentos = _dsoftBd.PagamentosEmAberto(pagamento_entregador.Key);
					decimal vales = _dsoftBd.ValesEmAberto(pagamento_entregador.Key);

					FluxoDeCaixa pagamento = new FluxoDeCaixa();
					pagamento.Caixa = Caixa.Numero;
					pagamento.Data = DateTime.Today;
					pagamento.Forma = 'D';
					pagamento.Recurso = pagamento_entregador.Key.Codigo;
					pagamento.Tipo = 'P';
					pagamento.Valor = pagamento_entregador.Value + diaria;
					pagamento.Observacao = "PAGAMENTO REFERENTE À ENTREGAS. GERADO AUTOMATICAMENTE NO FECHAMENTO DIÁRIO.";

					if ((pagamentos + vales) > 0)
					{
						pagamento.Valor -= (pagamentos + vales);
						pagamento.Observacao = string.Concat(pagamento.Observacao, string.Format(" DESCONTO DE R$ {0} REFERENTE À VALES OU PAGAMENTOS ANTERIORES.", (pagamentos + vales).ToString("##,###,##0.00")));
					}

					_dsoftBd.LancarPagamento(pagamento, Caixa.Numero, usuario.Codigo);
				}
			}
		}

		private void EfetuarFechamentoDeCaixa(Usuario usuario, bool imprime = true)
		{
			int numero;

			if (!int.TryParse(tbCaixa.Text, out numero) || !_dsoftBd.CaixaAtivo(numero))
			{
				MessageBox.Show("Caixa inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				tbCaixa.SelectAll();
				tbCaixa.Focus();

				return;
			}

			Caixa caixa = new Caixa();
			caixa.Codigo = numero;

			int fechamento;

			if (cbSaida.Checked)
			{
				decimal saldo;
				decimal.TryParse(tbSaldo.Text, out saldo);

				if ((fechamento = _dsoftBd.FechamentoDeCaixaSaida(caixa, saldo, usuario)) == 0)
				{
					MessageBox.Show("Não foi possível efetuar o fechamento!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}
			}
			else
			{
				if ((fechamento = _dsoftBd.FechamentoDeCaixa(caixa, usuario)) == 0)
				{
					MessageBox.Show("Não foi possível efetuar o fechamento!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}
			}

			CarregarDados(fechamento);

			if (imprime)
			{
				if (MessageBox.Show("Imprimir ticket?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					Impressora.ImprimirTicket(tbTicket.Text);
				}
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void LoadProperties()
		{
			WindowProperties properties = DSConfig.Instance.LoadWindowProperties(this.Name);

			if (properties != null)
			{
				this.Location = new Point(Util.TryParseInt(properties.X), Util.TryParseInt(properties.Y));
				this.Width = Util.TryParseInt(properties.Width);
				this.Height = Util.TryParseInt(properties.Height);
			}
		}

		private void frmFechamento_Load(object sender, EventArgs e)
		{
			LoadProperties();

			tbCaixa.Text = Caixa.Numero.ToString();
			lbCaixa.Text = _dsoftBd.CaixaDescricao(Caixa.Numero);

			tbUsuario.Text = _usuario.Autorizado.ToString();
			lbUsuario.Text = _dsoftBd.UsuarioNome(_usuario.Autorizado);

			tbSaldo.Text = Terminal.SaldoInicial().ToString("##,###,##0.00");

			this.Activate();

			if (_tipo == Fechamentos.FechamentoDeCaixa)
			{
				Caixa caixa = new Caixa();
				caixa = _dsoftBd.CarregarCaixa(Caixa.Numero);

				CarregarDadosAberto(caixa);
			}
			else
			{
				int pedidos_em_aberto = _dsoftBd.PedidosEmAberto();

				if (pedidos_em_aberto > 0)
				{
					lbAviso.Text = string.Format("Existem {0} pedidos em aberto.", pedidos_em_aberto);

					tbSaldo.Enabled = true;

					if (!RegrasDeNegocio.Instance.PermiteFechamentoComPedidosEmAberto)
					{
						confirmButton1.Enabled = false;
						confirmarToolStripMenuItem.Enabled = false;

						return;
					}
				}
				else
				{
					if (_usuario.Nivel == 'A')
						dtData.Enabled = true;

					DateTime primeiro_pedido = _dsoftBd.PrimeiroPedidoAberto();

					if (primeiro_pedido > DateTime.MinValue)
					{
						dtData.Value = primeiro_pedido;
					}

					CarregarDadosDia(dtData.Value);

					tbCaixa.Enabled = false;
					cbSaida.Enabled = false;

					cbReducaoZ.Checked = RegrasDeNegocio.Instance.EmiteCupomFiscal;
					cbReducaoZ.Enabled = true;

					cbBackup.Checked = Preferencias.BackupNoFechamento;
					cbBackup.Enabled = true;

					if (_dsoftBd.MovimentoEmAberto())
					{
						lbAviso.Text = "Existem movimentos em aberto!";
						tbSaldo.Enabled = true;
					}
					else
					{
						lbAviso.Text = string.Empty;
						tbSaldo.Enabled = false;
					}
				}
			}

			tbSenha.Focus();
		}

		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbSenha.Text.Length > 0)
			{
				confirmButton1.Focus();
			}
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbSaldo_KeyDown(object sender, KeyEventArgs e)
		{
			double valor;

			if (e.KeyCode == Keys.Enter)
			{
				if (double.TryParse(tbSaldo.Text, out valor))
				{
					tbSaldo.Text = valor.ToString("##,###,##0.00");
					Terminal.SaldoInicial(valor);

					tbSenha.Focus();
				}
				else
				{
					tbSaldo.Text = Terminal.SaldoInicial().ToString("##,###,##0.00");
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (Text == "Fechamento de Caixa")
			{

			}
			else if (Text == "Fechamento Diário")
			{
				//if (_usuario.Nivel != 'A')
				//{
				//    MessageBox.Show("Usuário não autorizado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				//    return;
				//}

				//frmData fdata = new frmData();

				//fdata.Text = "Selecione a data";

				//if (fdata.ShowDialog() == DialogResult.Cancel)
				//    return;

				//int fechamento;

				//if ((fechamento = _dsoftBd.ConsultaFechamentoDiario(fdata.dtData.Value)) < 1)
				//{
				//    MessageBox.Show("Fechamento não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				//    return;
				//}

				//if (_dsoftBd.DesfazerFechamentoDiario(fechamento, _usuario.Autorizado))
				//{
				//    //Sync
				//    if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
				//        Sync.CancelaFechamentoDia(fechamento);

				//    MessageBox.Show("Operação concluída!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				//}
				//else
				//{
				//    MessageBox.Show("Operação falhou!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//}
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			DateTime ultimo_fechamento = _dsoftBd.DataUltimoFechamentoDiario();

			if (ultimo_fechamento > DateTime.MinValue)
			{
				frmData form = new frmData();
				form.Titulo = "Data do fechamento";
				form.PermiteAlterarData = false;
				form.Data = ultimo_fechamento;

				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					_dsoftBd.DesfazerFechamentoDiarioAsync(form.Data).ContinueWith((task) =>
						{
							if (task.Result)
							{
								MessageBox.Show("Fechamento do dia " + ultimo_fechamento.ToShortDateString() + " desfeito com sucesso!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

								this.Invoke(new Action(() =>
								{
									dtData.Value = ultimo_fechamento;
									CarregarDadosDia(ultimo_fechamento);
								}));
							}
							else
							{
								MessageBox.Show("Operação não realizada!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						});
				}
			}
			else
			{
				MessageBox.Show("Não existem fechamentos diários registrados no sistema!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void dtData_ValueChanged(object sender, EventArgs e)
		{
			//CarregarDadosDia(dtData.Value);
		}

		private void cbBackup_CheckedChanged(object sender, EventArgs e)
		{
			Preferencias.BackupNoFechamento = cbBackup.Checked;
		}

		private void dtData_Leave(object sender, EventArgs e)
		{
			CarregarDadosDia(dtData.Value);
		}

		private void frmFechamento_FormClosing(object sender, FormClosingEventArgs e)
		{
			WindowProperties properties = new WindowProperties();
			properties.X = this.Location.X.ToString();
			properties.Y = this.Location.Y.ToString();
			properties.Width = this.Width.ToString();
			properties.Height = this.Height.ToString();
			properties.Name = this.Name;

			DSConfig.Instance.Save(properties);
		}

		#endregion Methods
	}
}