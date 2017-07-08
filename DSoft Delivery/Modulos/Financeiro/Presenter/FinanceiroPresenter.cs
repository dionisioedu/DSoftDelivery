using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

using DSoftParameters;

using DSoft_Delivery.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace DSoft_Delivery.Financeiro
{
	class FinanceiroPresenter
	{
		#region Fields

		public string Titulo = "Controle Financeiro";

		private bool Finished = false;
		private int LoadedResources = 0;
		private FinanceiroModel _lancamento;
		CancellationTokenSource tokenSource;
		private IFinanceiroView View;
		private Bd _dsoftBd;
		private Usuario _usuario;

		private PrintDocument _printDocument;
		private PrintPreviewDialog _printPreview;

		#endregion Fields

		#region Constructors

		public FinanceiroPresenter(Bd bd, Usuario usuario, IFinanceiroModel model, IFinanceiroView view)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			_lancamento = (FinanceiroModel)model;

			tokenSource = new CancellationTokenSource();

			View = view;
			View.Initialize += OnInitialize;
			View.Novo += new EventHandler(View_Novo);
			View.Cancelar += new EventHandler(View_Cancelar);
		}

		#endregion Constructors

		#region Methods

		public void CarregarLancamento(FinanceiroModel model)
		{
			_lancamento = new FinanceiroModel();

			_lancamento.Indice = model.Indice;
			_lancamento.Tipo = model.Tipo;
			_lancamento.Codigo = model.Codigo;
			_lancamento.Nome = model.Nome;
			_lancamento.Forma = model.Forma;
			_lancamento.Valor = model.Valor;
			_lancamento.Data = model.Data;
			_lancamento.Observacao = model.Observacao;
			_lancamento.Situacao = model.Situacao;
		}

		public void DefinirCodigo(string codigo)
		{
			switch (_lancamento.LancamentoTipo)
			{
				case LancamentoTipo.Entrada:
					{
						if (codigo.Length > 0)
						{
							long cliente;

							if (long.TryParse(codigo.Split(" - ".ToCharArray(), 2)[0], out cliente))
							{
								_lancamento.Cliente = cliente;
							}
							else
							{
								_lancamento.Cliente = _dsoftBd.ClienteCodigo(codigo);
							}
						}

						break;
					}

				case LancamentoTipo.Despesa:
					{

						break;
					}

				case LancamentoTipo.Pagamento:
					{
						if (codigo.Length > 0)
						{
							int recurso;

							if (int.TryParse(codigo.Split(" - ".ToCharArray(), 2)[0], out recurso))
							{
								_lancamento.Recurso = recurso;
							}
							else
							{
								_lancamento.Recurso = _dsoftBd.RecursoCodigo(codigo);
							}
						}

						break;
					}

				case LancamentoTipo.Saida:
					{

						break;
					}

				case LancamentoTipo.Transferencia:
					{

						break;
					}

				case LancamentoTipo.Vale:
					{
						if (codigo.Length > 0)
						{
							int recurso;

							if (int.TryParse(codigo.Split(" - ".ToCharArray(), 2)[0], out recurso))
							{
								_lancamento.Recurso = recurso;
							}
							else
							{
								_lancamento.Recurso = _dsoftBd.RecursoCodigo(codigo);
							}
						}

						break;
					}
			}
		}

		public void DefinirFormaDePagamento(string forma)
		{
			_lancamento.Forma = forma[0];
		}

		public void DefinirLancamentoTipo(char tipo)
		{
			_lancamento.Tipo = tipo;
		}

		public void EmitirComprovante()
		{
			if (RegrasDeNegocio.Instance.Ramo == "ESCOLA")
			{
				Relatorios.ReciboEscolar.Gerar(_dsoftBd, _lancamento.Codigo, _lancamento.Nome, _lancamento.Valor, _lancamento.Data);
			}
			else
			{
				if (_lancamento.Tipo == 'P')
				{
					GerarRecibo();
				}
			}
		}

		private void GerarRecibo()
		{
			_printDocument = new PrintDocument();
			_printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);

			_printPreview = new PrintPreviewDialog();
			_printPreview.Document = _printDocument;
			_printPreview.Show();
		}

		private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			float yPos = 0;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			Font titleFont = new Font("Arial", 14, FontStyle.Bold);
			Font printFont = new Font("Arial", 10);

			yPos = topMargin;
			e.Graphics.DrawString("Comprovante de pagamento", titleFont, Brushes.Black, leftMargin, yPos, new StringFormat());
			yPos += titleFont.GetHeight(e.Graphics); 
			yPos += printFont.GetHeight(e.Graphics);
			e.Graphics.DrawString(string.Format("Eu, {0}, confirmo o recibemento do valor abaixo referente a", _lancamento.Nome), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
			yPos += printFont.GetHeight(e.Graphics);
			e.Graphics.DrawString(_lancamento.Observacao, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
			yPos += printFont.GetHeight(e.Graphics);
			yPos += printFont.GetHeight(e.Graphics);
			e.Graphics.DrawString(string.Format("R$ {0}", _lancamento.Valor.ToString("##,###,##0.00")), titleFont, Brushes.Black, leftMargin, yPos, new StringFormat());
			yPos += titleFont.GetHeight(e.Graphics);
			yPos += titleFont.GetHeight(e.Graphics);
			e.Graphics.DrawString(string.Format("{0}   Ass:____________________________________________", DateTime.Today.ToShortDateString()), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

			e.HasMorePages = false;
		}

		public void Finish()
		{
			Finished = true;

			tokenSource.Cancel();
		}

		public void LancamentosPeriodoDetalhado(Form view)
		{
			frmFiltroDataLancamento form = new frmFiltroDataLancamento("Lançamentos por período detalhado", view);

			if (form.ShowDialog() != DialogResult.OK)
				return;

			_dsoftBd.LancamentosPeriodoDetalhadoAsync(form.Inicial, form.Final, form.Lancamentos.ToArray(), form.Formas.ToArray(), _usuario.Autorizado).ContinueWith((task) =>
				{
					if (task.IsCompleted && !task.IsFaulted)
						Relatorios.LancamentosPeriodoDetalhado.Gerar(form.Inicial, form.Final, form.Lancamentos.ToArray(), form.Formas.ToArray(), task.Result.Tables[0]);
				});
		}

		public void LancarEntrada(long cliente, decimal valor)
		{
			Task.Factory.StartNew(() =>
				{
					for (int i = 0; i < 10; i++)
					{
						if (LoadedResources > 1)
						{
							View.PreencherLancarEntrada(cliente, valor);
						}
						else
						{
							Thread.Sleep(1000);
						}
					}
				});
		}

		public void RecalcularSaldosClientes()
		{
			if (MessageBox.Show("Esta operação não pode ser desfeita." + Environment.NewLine + "Tem certeza de que deseja recalcular o saldo de todos os cliente?",
				Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
			{
				_dsoftBd.RecalcularSaldosClientesAsync().ContinueWith((task) =>
					{
						if (task.Result)
						{
							MessageBox.Show("Operação realizada com sucesso!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Operação não realizada!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					});
			}
		}

		public void RelatorioFechamentoDiario()
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
				MessageBox.Show("Relatório não encontrado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			//ProdutoGrupo[] grupos;

			//_dsoftBd.ProdutosGrupoFechamento(fechamento.Indice, out grupos);

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

		private void OnInitialize(object sender, EventArgs e)
		{
			_dsoftBd.FluxoDeCaixaAsync().ContinueWith((task) =>
				{
					DataSet ds = task.Result;

					if (ds != null && !Finished)
						View.SetDataSource(ds);
				}, tokenSource.Token);

			_dsoftBd.PagamentosFormasAsync().ContinueWith((task) =>
				{
					if (task.Result == null || Finished)
						return;

					View.PreencherFormasDePagamento(task.Result);

					LoadedResources++;
				}, tokenSource.Token);

			_dsoftBd.CarregarClientesAsync(_usuario.Autorizado).ContinueWith((task) =>
				{
					if (task.Result == null || Finished)
						return;

					View.PreencherClientes(task.Result);

					LoadedResources++;
				}, tokenSource.Token);

			_dsoftBd.CarregarResursosAsync().ContinueWith((task) =>
				{
					if (task.Result == null || Finished)
						return;

					View.PreencherRecursos(task.Result);
				}, tokenSource.Token);
		}

		private void RefreshView()
		{
			_dsoftBd.FluxoDeCaixaAsync().ContinueWith((task) =>
				{
					DataSet ds = task.Result;

					if (ds != null && !Finished)
						View.SetDataSource(ds);
				}, tokenSource.Token);
		}

		void View_Cancelar(object sender, EventArgs e)
		{
			Button btCancelar = sender as Button;

			if (_lancamento.Indice == null)
			{
				MessageBox.Show("Selecione um lançamento!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			if (_lancamento.Situacao == 'A')
			{
				if (_dsoftBd.CancelarEntrada((int)_lancamento.Indice, Caixa.Numero, _usuario.Autorizado))
				{
					RefreshView();
					View.LimparDados();
				}

			}
			else if (_lancamento.Situacao == 'C')
			{
				MessageBox.Show("Não é possível reativar esse tipo de lançamento!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		void View_Novo(object sender, EventArgs e)
		{
			Button bt = (Button)sender;

			if (bt.Text == "&Novo - F2")
			{
				_lancamento = new FinanceiroModel();

				View.NovoLancamento();

				return;
			}

			if (!decimal.TryParse(View.LerValor(), out _lancamento.Valor))
			{
				MessageBox.Show("'Valor' deve ser um número válido!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}

			_lancamento.Data = View.LerData();

			_lancamento.Observacao = View.LerObservacoes();

			switch (_lancamento.LancamentoTipo)
			{
				case LancamentoTipo.NotSet:
					{
						MessageBox.Show("'Tipo de Lançamento' deve ser definido!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					}

				case LancamentoTipo.Entrada:
					{
						//if (_lancamento.Cliente == null)
						//{
						//    MessageBox.Show("No lançamento de Entrada, o Cliente deve ser definido!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						//    return;
						//}

						if (_lancamento.Forma == null)
						{
							MessageBox.Show("'Forma de Pagamento' deve ser definida!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}

						if (_lancamento.Indice == null)
						{
							if (_lancamento.isValid && (_lancamento.Indice = _dsoftBd.LancarEntrada(_lancamento.FluxoDeCaixa, Caixa.Numero, _usuario.Autorizado)) > 0)
							{
								if (RegrasDeNegocio.Instance.Ramo == "ESCOLA" && MessageBox.Show("Deseja emitir um recibo?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
									== DialogResult.Yes)
								{
									if (_lancamento.Nome == null || _lancamento.Nome == "")
										_lancamento.Nome = _dsoftBd.ClienteNome((long)_lancamento.Cliente);

									_lancamento.Codigo = (long)_lancamento.Cliente;

									EmitirComprovante();
								}

								View.LimparDados();

								RefreshView();
							}
						}
						else
						{
							if (_lancamento.isValid && _dsoftBd.AlterarEntrada(_lancamento.FluxoDeCaixa, Caixa.Numero))
							{
								View.LimparDados();

								RefreshView();
							}
						}

						break;
					}

				case LancamentoTipo.Pagamento:
					{
						if (_lancamento.Recurso == null)
						{
							MessageBox.Show("No lançamento de Pagamento, o Funcionário deve ser definido!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							return;
						}

						if (_lancamento.Indice == null)
						{
							if (_lancamento.isValid && _dsoftBd.LancarPagamento(_lancamento.FluxoDeCaixa, Caixa.Numero, _usuario.Autorizado))
							{
								View.LimparDados();

								RefreshView();
							}
						}
						else
						{
							if (_lancamento.isValid && _dsoftBd.AlterarPagamento(_lancamento.FluxoDeCaixa, Caixa.Numero))
							{
								View.LimparDados();

								RefreshView();
							}
						}

						break;
					}

				case LancamentoTipo.Saida:
					{
						if (_lancamento.Indice == null)
						{
							if (_lancamento.isValid && _dsoftBd.LancarSaida(_lancamento.FluxoDeCaixa, Caixa.Numero, _usuario.Autorizado))
							{
								View.LimparDados();

								RefreshView();
							}
						}
						else
						{
							if (_lancamento.isValid && _dsoftBd.AlterarSaida(_lancamento.FluxoDeCaixa, Caixa.Numero))
							{
								View.LimparDados();

								RefreshView();
							}
						}

						break;
					}

				case LancamentoTipo.Transferencia:
					{
						MessageBox.Show("Lançamento de Transferência não implementado nessa versão!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						break;
					}

				case LancamentoTipo.Vale:
					{
						if (_lancamento.Indice == null)
						{
							if (_lancamento.isValid && _dsoftBd.LancarVale(_lancamento.FluxoDeCaixa, Caixa.Numero, _usuario.Autorizado))
							{
								View.LimparDados();

								RefreshView();
							}
						}
						else
						{
							if (_lancamento.isValid && _dsoftBd.AlterarPagamento(_lancamento.FluxoDeCaixa, Caixa.Numero))
							{
								View.LimparDados();

								RefreshView();
							}
						}

						break;
					}
			}
		}

		#endregion Methods
	}
}