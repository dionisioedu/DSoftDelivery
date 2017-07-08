using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;
using System.Windows.Forms.DataVisualization.Charting;
using DSoftCore;
using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmConFechamentos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		private FechamentoDiario _fechamentoDiario;

		#endregion Fields

		#region Constructors

		public frmConFechamentos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			refreshButton1.Click += button1_Click;
			quitButton1.Click += button2_Click;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				int caixa;
				int usuario;

				if (tbCaixa.Text.Length == 0)
				{
					caixa = 0;
				}
				else if (!int.TryParse(tbCaixa.Text, out caixa))
				{
					MessageBox.Show("Campo 'caixa' deve ser numérico!", this.Text);

					tbCaixa.SelectAll();

					tbCaixa.Focus();

					return;
				}

				if (tbUsuario.Text.Length == 0)
				{
					usuario = 0;
				}
				else if (!int.TryParse(tbUsuario.Text, out usuario))
				{
					MessageBox.Show("Campo 'usuario' deve ser numérico!", this.Text);

					tbUsuario.SelectAll();

					tbUsuario.Focus();

					return;
				}

				DataSet ds = new DataSet();

				_dsoftBd.CarregarFechamentos(ds, caixa, usuario, dtInicio.Value, dtFinal.Value);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["indice"].Width = 42;
				dataGridView1.Columns["indice"].HeaderText = "Índice";
				dataGridView1.Columns["data"].Width = 60;
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["hora"].Width = 60;
				dataGridView1.Columns["hora"].HeaderText = "Hora";
				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
				dataGridView1.Columns["caixa"].Width = 42;
				dataGridView1.Columns["caixa"].HeaderText = "Caixa";
				dataGridView1.Columns["descricao"].HeaderText = "Descrição";
				dataGridView1.Columns["saldo"].HeaderText = "Saldo R$";
				dataGridView1.Columns["entrada"].HeaderText = "Entrada R$";
				dataGridView1.Columns["saida"].HeaderText = "Saída R$";
				dataGridView1.Columns["despesa"].HeaderText = "Despesas R$";
				dataGridView1.Columns["vale"].HeaderText = "Vales R$";
				dataGridView1.Columns["pagamento"].HeaderText = "Pagtos R$";
				dataGridView1.Columns["transferencia"].HeaderText = "Transf. R$";
				dataGridView1.Columns["situacao"].Width = 60;
				dataGridView1.Columns["situacao"].HeaderText = "Sit.";
				dataGridView1.Columns["usuario"].Width = 60;
				dataGridView1.Columns["usuario"].HeaderText = "Usuário";
				dataGridView1.Columns["nome"].HeaderText = "Nome";

				dataGridView1.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["despesa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["vale"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["pagamento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["transferencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
					//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
				}

				CarregarFechamentosDiarios(dtInicio.Value, dtFinal.Value);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void CarregarFechamentosDiarios(DateTime inicio, DateTime final)
		{
			decimal entrada = 0;
			decimal despesas = 0;
			decimal pagamentos = 0;
			decimal saida = 0;

			DataTable dt = _dsoftBd.FechamentosDiarios(inicio, final);

			dgvDiarios.DataSource = dt;

			dgvDiarios.Columns["indice"].HeaderText = "ìndice";
			dgvDiarios.Columns["indice"].Visible = false;
			dgvDiarios.Columns["data"].HeaderText = "Data";
			dgvDiarios.Columns["data"].Width = 80;
			dgvDiarios.Columns["entrada"].HeaderText = "Entrada R$";
			dgvDiarios.Columns["entrada"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dgvDiarios.Columns["entrada"].Width = 80;
			dgvDiarios.Columns["entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvDiarios.Columns["despesas"].HeaderText = "Despesas R$";
			dgvDiarios.Columns["despesas"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dgvDiarios.Columns["despesas"].Width = 80;
			dgvDiarios.Columns["despesas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvDiarios.Columns["vales"].HeaderText = "Vales R$";
			dgvDiarios.Columns["vales"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dgvDiarios.Columns["vales"].Width = 80;
			dgvDiarios.Columns["vales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvDiarios.Columns["pagamentos"].HeaderText = "Pagamentos R$";
			dgvDiarios.Columns["pagamentos"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dgvDiarios.Columns["pagamentos"].Width = 80;
			dgvDiarios.Columns["pagamentos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvDiarios.Columns["saida"].HeaderText = "Saída R$";
			dgvDiarios.Columns["saida"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dgvDiarios.Columns["saida"].Width = 80;
			dgvDiarios.Columns["saida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			// Gráfico
			chtFechamentosDiarios.Series.Clear();

			Series serie = chtFechamentosDiarios.Series.Add("Entrada");
			serie.ChartType = SeriesChartType.Line;
			serie.BorderWidth = 4;

			for (int i = 0; i < dgvDiarios.Rows.Count; i++)
			{
				entrada += Util.TryParseDecimal(dgvDiarios["entrada", i].Value);
				despesas += Util.TryParseDecimal(dgvDiarios["despesas", i].Value);
				pagamentos += Util.TryParseDecimal(dgvDiarios["vales", i].Value);
				pagamentos += Util.TryParseDecimal(dgvDiarios["pagamentos", i].Value);
				saida += Util.TryParseDecimal(dgvDiarios["saida", i].Value);

				serie.Points.AddXY(dgvDiarios["data", i].Value, dgvDiarios["entrada", i].Value);
			}

			chtFechamentosDiarios.Invalidate();

			tbDiarioTotalEntrada.Text = entrada.ToString(Constants.FORMATO_MOEDA);
			tbDiarioTotalDespesas.Text = despesas.ToString(Constants.FORMATO_MOEDA);
			tbDiarioTotalPagamentos.Text = pagamentos.ToString(Constants.FORMATO_MOEDA);
			tbDiarioTotalSaida.Text = saida.ToString(Constants.FORMATO_MOEDA);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarCaixa(int row)
		{
			try
			{
				double saida;
				double pagamento;
				double vale;
				double despesa;
				double transferencia;
				double total_saida;
				double entrada;
				double saldo_anterior;
				double saldo;

				if (row < 0)
					return;

				tbCaixasCaixa.Text = dataGridView1.Rows[row].Cells["caixa"].Value.ToString();
				lbCaixasCaixa.Text = dataGridView1.Rows[row].Cells["descricao"].Value.ToString();

				tbCaixasUsuario.Text = dataGridView1.Rows[row].Cells["usuario"].Value.ToString();
				lbCaixasUsuario.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();

				saida = double.Parse(dataGridView1.Rows[row].Cells["saida"].Value.ToString());
				pagamento = double.Parse(dataGridView1.Rows[row].Cells["pagamento"].Value.ToString());
				vale = double.Parse(dataGridView1.Rows[row].Cells["vale"].Value.ToString());
				despesa = double.Parse(dataGridView1.Rows[row].Cells["despesa"].Value.ToString());
				transferencia = double.Parse(dataGridView1.Rows[row].Cells["transferencia"].Value.ToString());

				total_saida = saida + pagamento + vale + despesa + transferencia;

				entrada = double.Parse(dataGridView1.Rows[row].Cells["entrada"].Value.ToString());

				saldo = double.Parse(dataGridView1.Rows[row].Cells["saldo"].Value.ToString());

				saldo_anterior = saldo + total_saida - entrada;

				tbCaixasSaida.Text = saida.ToString("0.00");
				tbCaixasPagamento.Text = pagamento.ToString("0.00");
				tbCaixasVale.Text = vale.ToString("0.00");
				tbCaixasDespesa.Text = despesa.ToString("0.00");
				tbCaixasTransferencia.Text = transferencia.ToString("0.00");

				dtCaixas.Value = DateTime.Parse(dataGridView1.Rows[row].Cells["data"].Value.ToString());

				tbCaixasSaldoAnterior.Text = saldo_anterior.ToString("0.00");
				tbCaixasEntrada.Text = entrada.ToString("0.00");
				tbCaixasTotalSaidas.Text = total_saida.ToString("0.00");
				tbCaixasSaldo.Text = saldo.ToString("0.00");

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void Confirmar()
		{
			Atualizar();

			tbCaixa.Focus();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarCaixa(dataGridView1.CurrentRow.Index);
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dtFinal.Focus();
			}
		}

		private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				refreshButton1.Focus();
			}
		}

		private void frmConFechamentos_Load(object sender, EventArgs e)
		{
			dtInicio.Value = DateTime.Today.AddMonths(-1);

			Atualizar();

			refreshButton1.Focus();
		}

		private void LimparDados()
		{
			tbCaixa.Clear();
			tbUsuario.Clear();
			lbCaixa.Text = string.Empty;
			lbUsuario.Text = string.Empty;

			dtInicio.Value = DateTime.Now;
			dtFinal.Value = DateTime.Now;

			tbCaixa.Focus();
		}

		private void LimparDetalhes()
		{
			tbCaixasCaixa.Clear();
			lbCaixasCaixa.Text = string.Empty;

			tbCaixasUsuario.Clear();
			lbCaixasUsuario.Text = string.Empty;

			tbCaixasSaida.Clear();
			tbCaixasPagamento.Clear();
			tbCaixasVale.Clear();
			tbCaixasDespesa.Clear();
			tbCaixasTransferencia.Clear();

			tbCaixasSaldoAnterior.Clear();
			tbCaixasEntrada.Clear();
			tbCaixasTotalSaidas.Clear();
			tbCaixasSaldo.Clear();

			dtCaixas.Value = DateTime.Now;
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_Enter(object sender, EventArgs e)
		{
			tbCaixa.SelectAll();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbUsuario.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int numero;

			if (tbCaixa.Text.Length > 0)
			{
				if (!int.TryParse(tbCaixa.Text, out numero))
				{
					MessageBox.Show("Campo 'caixa' deve ser numérico!", this.Text);

					tbCaixa.SelectAll();

					tbCaixa.Focus();

					return;
				}

				if ((lbCaixa.Text = _dsoftBd.CaixaDescricao(numero)) == string.Empty)
				{
					MessageBox.Show("Código de caixa não encontrado!", this.Text);

					tbCaixa.SelectAll();

					tbCaixa.Focus();

					return;
				}
			}
		}

		private void textBox2_Enter(object sender, EventArgs e)
		{
			tbUsuario.SelectAll();
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dtInicio.Focus();
			}
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			int numero;

			if (tbUsuario.Text.Length > 0)
			{
				if (!int.TryParse(tbUsuario.Text, out numero))
				{
					MessageBox.Show("Campo 'usuário' deve ser numérico!", this.Text);

					tbUsuario.SelectAll();

					tbUsuario.Focus();

					return;
				}

				if ((lbUsuario.Text = _dsoftBd.UsuarioNome(numero)) == string.Empty)
				{
					MessageBox.Show("Código de usuário não encontrado!", this.Text);

					tbUsuario.SelectAll();

					tbUsuario.Focus();

					return;
				}
			}
		}

		private void dgvDiarios_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			DateTime dia = (DateTime)dgvDiarios["data", e.RowIndex].Value;

			if (dia != null)
			{
				CarregarFechamentoDiarioDia(dia);
			}
		}

		private void CarregarFechamentoDiarioDia(DateTime dia)
		{
			_fechamentoDiario = _dsoftBd.CarregarFechamentoDiario(dia);

			if (_fechamentoDiario != null)
			{
				tbDiarioSaldoAnterior.Text = _fechamentoDiario.SaldoAnterior.ToString(Constants.FORMATO_MOEDA);
				tbDiarioEntrada.Text = _fechamentoDiario.Entradas.ToString(Constants.FORMATO_MOEDA);
				tbDiarioTotalSaidas.Text = _fechamentoDiario.TotalSaidas.ToString(Constants.FORMATO_MOEDA);
				tbDiarioSaldo.Text = _fechamentoDiario.SaldoAtual.ToString(Constants.FORMATO_MOEDA);

				tbDiarioDespesas.Text = _fechamentoDiario.Despesas.ToString(Constants.FORMATO_MOEDA);
				tbDiarioPagamentos.Text = _fechamentoDiario.Pagamentos.ToString(Constants.FORMATO_MOEDA);
				tbDiarioVales.Text = _fechamentoDiario.Vales.ToString(Constants.FORMATO_MOEDA);
				tbDiarioSaida.Text = _fechamentoDiario.Saidas.ToString(Constants.FORMATO_MOEDA);

				tbDiarioVendaDireta.Text = _fechamentoDiario.VendaDireta.ToString(Constants.FORMATO_MOEDA);
				tbDiarioClienteInterno.Text = _fechamentoDiario.ClienteInterno.ToString(Constants.FORMATO_MOEDA);
				tbDiarioDelivery.Text = _fechamentoDiario.Delivery.ToString(Constants.FORMATO_MOEDA);
			}
		}

		private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			CarregarCaixa(e.RowIndex);
		}

		private void ReimprimirFechamento(bool somar_pagamentos_aberto = true)
		{
			if (_fechamentoDiario != null)
			{
				decimal _diaria = 0;
				decimal _taxa_entrega = 0;
				List<Recurso> entregadores_ativos = null;

				Dictionary<Recurso, decimal> pagamentos_entregadores = null;

				StringBuilder ticket = new StringBuilder();

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

				ticket.Append("FECHAMENTO DIARIO\n");
				ticket.AppendFormat(string.Format("{0} - {1}\n", _fechamentoDiario.Data.ToShortDateString(), DateTime.Now.ToShortTimeString()));
				ticket.AppendFormat(string.Format("{0}\n", new string('=', Terminal.ImpressoraColunas)));
				ticket.AppendFormat(string.Format("SALDO ANTERIOR{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 30), _fechamentoDiario.SaldoAnterior.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("ENTRADAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Entradas.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("SAIDAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), _fechamentoDiario.Saidas.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("DESPESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Despesas.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("VALES{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.Vales.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("PAGAMENTOS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 26), _fechamentoDiario.Pagamentos.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				ticket.AppendFormat(string.Format("SALDO{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.SaldoAtual.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat("\n");

				foreach (var formaDePagamento in _fechamentoDiario.FormasDePagamento)
				{
					ticket.AppendFormat(string.Format("{0}{1} R$ {2}\n", formaDePagamento.Key.Descricao, new string('.', Terminal.ImpressoraColunas - (16 + formaDePagamento.Key.Descricao.Length)), formaDePagamento.Value.ToString("##,###,##0.00").PadLeft(12)));
				}

				ticket.AppendFormat(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				ticket.AppendFormat(string.Format("BALCAO{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 22), _fechamentoDiario.VendaDireta.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("MESAS{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 21), _fechamentoDiario.ClienteInterno.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("DELIVERY{0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 24), _fechamentoDiario.Delivery.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				ticket.AppendFormat(string.Format("PEDIDOS CANCELADOS{0} {1}\n", new string('.', Terminal.ImpressoraColunas - 31), _fechamentoDiario.PedidosCancelados.ToString().PadLeft(12)));
				ticket.AppendFormat(string.Format("TOTAL CANCELADO {0} R$ {1}\n", new string('.', Terminal.ImpressoraColunas - 32), _fechamentoDiario.TotalCancelado.ToString("##,###,##0.00").PadLeft(12)));
				ticket.AppendFormat(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				ticket.AppendFormat(string.Format("PRODUTOS{0}VOLUME  TOTAL          \n", new string(' ', Terminal.ImpressoraColunas - 31)));

				//foreach (MovimentoTipoProduto m in _fechamentoDiario.Movimentos)
				//{
				//    ticket.AppendFormat(string.Format("{0} {1,6}  R$ {2,12}\n", Util.Formata(m.Tipo.Nome, (Terminal.ImpressoraColunas - 24), ' '), m.Volume.ToString("0.00"), m.Total.ToString("#,###,##0.00")));
				//}

				if (RegrasDeNegocio.Instance.PagamentoAutomaticoDeEntregadores)
				{
					ticket.AppendFormat("\n\n");
					ticket.AppendFormat(string.Format("ENTREGADORES {0}   VALES   PAGTOS\n", new string(' ', (Terminal.ImpressoraColunas - 30))));
					ticket.AppendFormat(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));

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

							ticket.AppendFormat(string.Format("{0} {1} {2}\n", Util.Formata(pagamento.Key.ToString(), Terminal.ImpressoraColunas - 18, '.'), vales.ToString("#,##0.00").PadLeft(8), valor.ToString("#,##0.00").PadLeft(8)));
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

								ticket.AppendFormat(string.Format("{0} {1} {2}\n", Util.Formata(entregador.Nome, Terminal.ImpressoraColunas - 18, '.'), vales.ToString("#,##0.00").PadLeft(8), total.ToString("#,##0.00").PadLeft(8)));
							}
						}
					}
				}

				DSPrintingHelper.PrinterHelper.PrintTicket(ticket.ToString(), Licenca.Instance);
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			ReimprimirFechamento();
		}

		private void printLittleButton1_Click(object sender, EventArgs e)
		{
			ReimprimirFechamento();
		}

		#endregion Methods
	}
}