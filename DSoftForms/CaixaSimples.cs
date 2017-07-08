using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftModels;
using DSoftParameters;
using DSoftCore;

namespace DSoftForms
{
	public partial class CaixaSimples : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Pedido _pedido;

		public Locacao Locacao;
		public decimal Valor;
		public string Referencia;

		private decimal _pago;
		private decimal _valor1;
		private decimal _valor2;
		private decimal _valor3;
		private decimal _valor4;
		private decimal _valor5;
		private decimal _troco;

		public CaixaSimples(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		public CaixaSimples(Bd bd, Usuario usuario, Pedido pedido)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_pedido = pedido;
		}

		private void frmCaixaSimples_Load(object sender, EventArgs e)
		{
			this.Activate();

			if (_pedido != null)
			{
				Valor = _pedido.TotalPedido;
			}

			_pago = _dsoftBd.ValorPago(_pedido);

			tbTotalPedido.Text = Valor.ToString("##,###,##0.00");
			tbValorPago.Text = _pago.ToString("##,###,##0.00");
			tbReferencia.Text = Referencia;

			CarregarFormasDePagamento();

			cbForma1.SelectedIndex = 0;
			cbForma1.Focus();
		}

		private void Confirmar()
		{
			if (_troco > 0)
			{
				if (MessageBox.Show(string.Format("Confirma a entrega do troco ao cliente no valor de R$ {0} ?", _troco.ToString("##,###,##0.00")), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
					== System.Windows.Forms.DialogResult.Yes)
				{
					_pedido.Troco = _troco + _pedido.TotalPedido;

					List<PagamentoNovo> pagamentos = GravarPagamentos();

					EmitirCupomFiscal(pagamentos);

					this.DialogResult = System.Windows.Forms.DialogResult.OK;

					this.Close();
				}
			}
			else if ((_valor1 + _valor2 + _valor3 + _valor4 + _valor5 + _pago) >= Math.Round(Valor, 2))
			{
				if (_pedido != null || MessageBox.Show(string.Format("Confirma o recebimento no valor total de R$ {0} ?", (_valor1 + _valor2 + _valor3 + _valor4 + _valor5).ToString("##,###,##0.00")), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
					== System.Windows.Forms.DialogResult.Yes)
				{
					List<PagamentoNovo> pagamentos = GravarPagamentos();

					EmitirCupomFiscal(pagamentos);

					this.DialogResult = System.Windows.Forms.DialogResult.OK;

					this.Close();
				}
			}
			else
			{
				MessageBox.Show("Valor incompleto! Por favor, complete o pagamento!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private List<PagamentoNovo> GravarPagamentos()
		{
			List<PagamentoNovo> pagamentos = new List<PagamentoNovo>();

			if (_valor1 > 0)
			{
				PagamentoNovo pag = new PagamentoNovo();
				pag.Forma = cbForma1.SelectedItem.ToString();
				pag.Documento = tbNumero1.Text;
				pag.Valor = _valor1;

				pagamentos.Add(pag);
			}

			if (_valor2 > 0)
			{
				PagamentoNovo pag = new PagamentoNovo();
				pag.Forma = cbForma2.SelectedItem.ToString();
				pag.Documento = tbNumero2.Text;

				pag.Valor = _valor2;

				pagamentos.Add(pag);
			}

			if (_valor3 > 0)
			{
				PagamentoNovo pag = new PagamentoNovo();
				pag.Forma = cbForma3.SelectedItem.ToString();
				pag.Documento = tbNumero3.Text;

				pag.Valor = _valor3;

				pagamentos.Add(pag);
			}

			if (_valor4 > 0)
			{
				PagamentoNovo pag = new PagamentoNovo();
				pag.Forma = cbForma4.SelectedItem.ToString();
				pag.Documento = tbNumero4.Text;

				pag.Valor = _valor4;

				pagamentos.Add(pag);
			}

			if (_valor5 > 0)
			{
				PagamentoNovo pag = new PagamentoNovo();
				pag.Forma = cbForma5.SelectedItem.ToString();
				pag.Documento = tbNumero5.Text;

				pag.Valor = _valor5;

				pagamentos.Add(pag);
			}

			if (_troco > 0)
			{
				PagamentoNovo dinheiro = pagamentos.Find(p => p.Forma.StartsWith("D"));

				if (dinheiro != null)
				{
					if (dinheiro.Valor > _troco)
					{
						dinheiro.Valor -= _troco;
						_troco = 0;
					}
					else
					{
						_troco -= dinheiro.Valor;
						dinheiro.Valor = 0;
					}
				}

				if (_troco > 0)
				{
					for (int i = 0; i < pagamentos.Count; i++)
					{
						if (_troco <= 0)
						{
							break;
						}

						if (pagamentos[i].Valor > _troco)
						{
							pagamentos[i].Valor -= _troco;
							_troco = 0;
						}
						else
						{
							_troco -= pagamentos[i].Valor;
							pagamentos[i].Valor = 0;
						}
					}
				}
			}

			foreach (PagamentoNovo p in pagamentos)
			{
				if (_pedido != null)
				{
					_dsoftBd.PagarPedido(_pedido.Numero, p.Forma[0], p.Documento, (double)p.Valor, Caixa.Numero, _usuario.Autorizado);
				}
				else if (Locacao != null)
				{
					_dsoftBd.PagarLocacao(Locacao, p, _usuario);
				}

				if (p.Forma.StartsWith("A"))
				{
					_pedido.Debito = true;
				}
			}

			return pagamentos;
		}

		private void Sair()
		{
			this.Close();
		}

		private void EmitirCupomFiscal(List<PagamentoNovo> pagamentos)
		{
			if (!RegrasDeNegocio.Instance.EmiteCupomFiscal)
				return;

			CapturaCPFNota form = new CapturaCPFNota();

			if (form.ShowDialog() == DialogResult.Cancel)
				return;

			try
			{
				Pedido pedido = new Pedido();

				_dsoftBd.CarregarPedido(_pedido.Numero, pedido);

				PrepararValoresECF(pedido);

				if (Terminal.ECF() == "BEMATECH MP-2100 TH FI")
				{
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_AbreCupom(form.Cpf));

					foreach (ItemPedido item in pedido.ItensPedido)
					{
						if (item == null)
							continue;

						decimal valor_adicional = 0;

						if (item.ItensAdicionais != null && item.ItensAdicionais.Count > 0)
						{
							foreach (var ia in item.ItensAdicionais)
							{
								valor_adicional += ia.Valor;
							}
						}

						if (item.Unitario == 0)
							item.Unitario = 0.01M;

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_VendeItem(item.Produto.ToString(), _dsoftBd.ProdutoNome(item.Produto, 29), "FF", "I", item.Quantidade.ToString("0000"), 2, (item.Unitario + valor_adicional).ToString("00000.00"), "%", item.Desconto.ToString("0000")));
					}

					if (pedido.TaxaDeEntrega > 0)
					{
						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_VendeItem("001", "TAXA DE ENTREGA", "1200", "I", "1", 2, pedido.TaxaDeEntrega.ToString("00000.00"), "%", "0000"));
					}

					//BemaFI64.Bematech_FI_FechaCupomResumido("Dinheiro", "");

					//if (FormaDePagamento[0] == 'P' || FormaDePagamento[1] == 'P' || FormaDePagamento[2] == 'P')
					//{
					//    string valor = "0,00";

					//    if (FormaDePagamento[0] == 'P')
					//        valor = tbValor1.Text;
					//    else if (FormaDePagamento[1] == 'P')
					//        valor = tbValor2.Text;
					//    else if (FormaDePagamento[2] == 'P')
					//        valor = tbValor3.Text;

					//    BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_IniciaFechamentoCupom("D", "$", valor));
					//}

					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_IniciaFechamentoCupom("A", "%", "0"));

					for (int i = 0; i < pagamentos.Count; i++)
					{
						string desc;
						string valor;

						if (pagamentos[i].Forma.StartsWith("P"))
							desc = "Crediário";
						else if (pagamentos[i].Forma.StartsWith("X"))
							desc = "Cheque";
						else if (pagamentos[i].Forma.StartsWith("C"))
							desc = "Crédito";
						else if (pagamentos[i].Forma.StartsWith("M"))
							desc = "Master Card";
						else if (pagamentos[i].Forma.StartsWith("V"))
							desc = "Visa";
						else if (pagamentos[i].Forma.StartsWith("R"))
							desc = "VR";
						else
							desc = "Dinheiro";

						if (i == 0)
						{
							valor = tbValor1.Text;
						}
						else if (i == 1)
						{
							valor = tbValor2.Text;
						}
						else if (i == 2)
						{
							valor = tbValor3.Text;
						}
						else if (i == 3)
						{
							valor = tbValor4.Text;
						}
						else
						{
							valor = tbValor5.Text;
						}

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_EfetuaFormaPagamento(desc, valor));
					}

					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_TerminaFechamentoCupom("Obrigado. Volte sempre!"));

					string Loja = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroLoja(ref Loja));

					string Caixa = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCaixa(ref Caixa));

					string Cupom = new string('\x20', 6);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCupom(ref Cupom));

					_dsoftBd.AtribuiCupomFiscal(_pedido.Numero, int.Parse(Loja), int.Parse(Caixa), long.Parse(Cupom));
				}
				else if (Terminal.ECF() == "SWEDA ST120")
				{
					int retorno;

					ECFHelper helper = new ECFHelper();

					retorno = SwedaST120.ECF_AbreCupom(form.Cpf);
					helper.Analisa_Retorno_ECF();

					if (retorno < 1)
					{
						MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
						return;
					}

					foreach (ItemPedido item in pedido.ItensPedido)
					{
						decimal valor_adicional = 0;

						if (item.ItensAdicionais != null && item.ItensAdicionais.Count > 0)
						{
							foreach (var ia in item.ItensAdicionais)
							{
								valor_adicional += ia.Valor;
							}
						}

						retorno = SwedaST120.ECF_VendeItem(item.Produto.ToString("000"), item.ProdutoNome, "1200", "I", item.Quantidade.ToString("0"), 2, (item.Unitario + valor_adicional).ToString("00000.00"), "%", "0000");
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					if (pedido.TaxaDeEntrega > 0)
					{
						retorno = SwedaST120.ECF_VendeItem("001", "TAXA DE ENTREGA", "1200", "I", "1", 2, pedido.TaxaDeEntrega.ToString("00000.00"), "%", "0000");
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					//retorno = SwedaST120.ECF_IniciaFechamentoCupom("A", "%", "0");
					//helper.Analisa_Retorno_ECF();

					//if (retorno < 1)
					//{
					//    MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
					//    return;
					//}

					for (int i = 0; i < pagamentos.Count; i++)
					{
						string desc;
						string valor;

						//if (pagamentos[i].Forma.StartsWith("P"))
						//    desc = "CREDIARIO";
						//else if (pagamentos[i].Forma.StartsWith("X"))
						//    desc = "CHEQUE";
						//else if (pagamentos[i].Forma.StartsWith("C"))
						//    desc = "CREDITO";
						//else if (pagamentos[i].Forma.StartsWith("M"))
						//    desc = "MASTER CARD";
						//else if (pagamentos[i].Forma.StartsWith("V"))
						//    desc = "VISA";
						//else if (pagamentos[i].Forma.StartsWith("R"))
						//    desc = "VR";
						//else
							desc = "DINHEIRO";

							if (i == 0)
							{
								valor = tbValor1.Text;
							}
							else if (i == 1)
							{
								valor = tbValor2.Text;
							}
							else if (i == 2)
							{
								valor = tbValor3.Text;
							}
							else if (i == 3)
							{
								valor = tbValor4.Text;
							}
							else
							{
								valor = tbValor5.Text;
							}

						retorno = SwedaST120.ECF_EfetuaFormaPagamento(desc, valor);
						helper.Analisa_Retorno_ECF();

						if (retorno < 1)
						{
							MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
							return;
						}
					}

					retorno = SwedaST120.ECF_TerminaFechamentoCupom("Obrigado. Volte sempre!");
					helper.Analisa_Retorno_ECF();

					if (retorno < 1)
					{
						MessageBox.Show(SwedaST120.Analisa_Retorno_Dll(retorno));
						return;
					}

					StringBuilder Loja = new StringBuilder();
					SwedaST120.ECF_NumeroLoja(Loja);

					StringBuilder Caixa = new StringBuilder();
					SwedaST120.ECF_NumeroCaixa(Caixa);

					StringBuilder Cupom = new StringBuilder();
					SwedaST120.ECF_NumeroCupom(Cupom);

					_dsoftBd.AtribuiCupomFiscal(_pedido.Numero, int.Parse(Loja.ToString()), int.Parse(Caixa.ToString()), long.Parse(Cupom.ToString()));
				}
			}
			catch (Exception e)
			{
				DSoftLogger.Logger.Instance.Error(e);
			}
		}

		private void PrepararValoresECF(Pedido pedido)
		{
			for (int i = 0; i < pedido.ItensPedido.Count; i++)
			{
				if (pedido.ItensPedido[i].Unitario == 0)
				{
					if (pedido.ItensPedido[i].Preco != 0)
					{
						pedido.ItensPedido[i].Unitario = pedido.ItensPedido[i].Preco;
					}
					else
					{
						// Achamos o valor principal
						int item = pedido.ItensPedido[i].Numero;
						int principal = 0;

						for (int j = 0; j < pedido.ItensPedido.Count; j++)
						{
							if (pedido.ItensPedido[j].Numero == item && !pedido.ItensPedido[j].Secundario)
							{
								principal = j;
								break;
							}
						}

						pedido.ItensPedido[principal].Unitario -= 0.01M;
						pedido.ItensPedido[i].Unitario = 0.01M;
					}
				}
			}
		}

		private void CarregarFormasDePagamento()
		{
			cbForma1.Items.Clear();
			cbForma2.Items.Clear();
			cbForma3.Items.Clear();
			cbForma4.Items.Clear();
			cbForma5.Items.Clear();

			List<FormaDePagamento> formas = _dsoftBd.FormasDePagamento();

			foreach (FormaDePagamento forma in formas)
			{
				if (forma.Ativo && (_pedido.Cliente > 0 || forma.Debito == false))
				{
					cbForma1.Items.Add(forma);
					cbForma2.Items.Add(forma);
					cbForma3.Items.Add(forma);
					cbForma4.Items.Add(forma);
					cbForma5.Items.Add(forma);
				}
			}
		}

		private bool CalculaSaldo()
		{
			try
			{
				decimal valor;
				decimal total = _pago;
				decimal troco;

				if (tbValor1.Text != string.Empty)
				{
					if (!decimal.TryParse(tbValor1.Text, out valor))
					{
						_valor1 = 0;

						MessageBox.Show("Valor inválido!");

						tbValor1.SelectAll();
						tbValor1.Focus();

						return false;
					}
					else
					{
						_valor1 = valor;

						tbValor1.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor2.Text != string.Empty)
				{
					if (!decimal.TryParse(tbValor2.Text, out valor))
					{
						_valor2 = 0;

						MessageBox.Show("Valor inválido!");

						tbValor2.SelectAll();
						tbValor2.Focus();

						return false;
					}
					else
					{
						_valor2 = valor;

						tbValor2.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor3.Text != string.Empty)
				{
					if (!decimal.TryParse(tbValor3.Text, out valor))
					{
						_valor3 = 0;

						MessageBox.Show("Valor inválido!");

						tbValor3.SelectAll();
						tbValor3.Focus();

						return false;
					}
					else
					{
						_valor3 = valor;

						tbValor3.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor4.Text != string.Empty)
				{
					if (!decimal.TryParse(tbValor4.Text, out valor))
					{
						_valor4 = 0;

						MessageBox.Show("Valor inválido!");

						tbValor4.SelectAll();
						tbValor4.Focus();

						return false;
					}
					else
					{
						_valor4 = valor;

						tbValor4.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor5.Text != string.Empty)
				{
					if (!decimal.TryParse(tbValor5.Text, out valor))
					{
						_valor5 = 0;

						MessageBox.Show("Valor inválido!");

						tbValor5.SelectAll();
						tbValor5.Focus();

						return false;
					}
					else
					{
						_valor5 = valor;

						tbValor5.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				tbTotal.Text = total.ToString("0.00");

				troco = total - Valor;

				_troco = troco;

				tbTroco.Text = troco.ToString("0.00");

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private decimal Saldo()
		{
			decimal total, pago, pagto1, pagto2, pagto3, pagto4, pagto5;

			decimal.TryParse(tbTotalPedido.Text, out total);
			decimal.TryParse(tbValorPago.Text, out pago);
			decimal.TryParse(tbValor1.Text, out pagto1);
			decimal.TryParse(tbValor2.Text, out pagto2);
			decimal.TryParse(tbValor3.Text, out pagto3);
			decimal.TryParse(tbValor4.Text, out pagto4);
			decimal.TryParse(tbValor5.Text, out pagto5);

			return total - pago - pagto1 - pagto2 - pagto3 - pagto4 - pagto5;
		}

		private void cbForma1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma1.SelectedItem == null)
				{
					MessageBox.Show("Campo 'forma de pagamento' deve ser preenchido!");
					cbForma1.Focus();

					return;
				}

				if (cbForma1.Text[0] == 'X')
				{
					tbNumero1.Enabled = true;

					tbNumero1.Focus();
				}
				else
				{
					tbValor1.Enabled = true;
					tbValor1.Text = Saldo().ToString();

					tbValor1.Focus();
				}
			}
		}

		private void tbNumero1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor1.Focus();
			}
		}

		private void tbValor1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (CalculaSaldo())
				{
					cbForma2.Enabled = true;
					cbForma2.Focus();
				}
			}
		}

		private void cbForma2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma2.SelectedItem == null)
				{
					if (decimal.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (cbForma2.SelectedItem != null)
				{
					if (cbForma2.Text[0] == 'X')
					{
						tbNumero2.Enabled = true;
						tbNumero2.Focus();
					}
					else
					{
						tbValor2.Enabled = true;
						tbValor2.Text = Saldo().ToString();
						tbValor2.Focus();
					}
				}
			}
		}

		private void tbNumero2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor2.Focus();
			}
		}

		private void tbValor2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (CalculaSaldo())
				{
					cbForma3.Enabled = true;
					cbForma3.Focus();
				}
			}
		}

		private void cbForma3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma3.SelectedItem == null)
				{
					if (decimal.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (cbForma3.SelectedItem != null)
				{
					if (cbForma3.Text[0] == 'X')
					{
						tbNumero3.Enabled = true;
						tbNumero3.Focus();
					}
					else
					{
						tbValor3.Enabled = true;
						tbValor3.Text = Saldo().ToString();
						tbValor3.Focus();
					}
				}
			}
		}

		private void tbNumero3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor3.Focus();
			}
		}

		private void tbValor3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbValor3.Text != string.Empty && CalculaSaldo())
				{
					cbForma4.Enabled = true;
					cbForma4.Focus();
				}
			}
		}

		private void cbForma4_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma4.SelectedItem == null)
				{
					if (decimal.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (cbForma4.SelectedItem != null)
				{
					if (cbForma4.Text[0] == 'X')
					{
						tbNumero4.Enabled = true;
						tbNumero4.Focus();
					}
					else
					{
						tbValor4.Enabled = true;
						tbValor4.Text = Saldo().ToString();
						tbValor4.Focus();
					}
				}
			}
		}

		private void tbNumero4_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor4.Focus();
			}
		}

		private void tbValor4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (CalculaSaldo())
				{
					cbForma5.Enabled = true;
					cbForma5.Focus();
				}
			}
		}

		private void cbForma5_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma5.SelectedItem == null)
				{
					if (decimal.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (cbForma5.SelectedItem != null)
				{
					if (cbForma5.Text[0] == 'X')
					{
						tbNumero5.Enabled = true;
						tbNumero5.Focus();
					}
					else
					{
						tbValor5.Enabled = true;
						tbValor5.Text = Saldo().ToString();
						tbValor5.Focus();
					}
				}
			}
		}

		private void tbNumero5_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor5.Focus();
			}
		}

		private void tbValor5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (CalculaSaldo())
				{
					btConfirmar.Focus();
				}
			}
		}
	}
}
