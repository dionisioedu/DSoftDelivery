using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSoftCore;
using DSoftBd;
using DSoftModels;
using DSoftParameters;
using DSoftForms;

namespace DSoft_Delivery
{
	public partial class frmCaixa : Form
	{
		#region Fields

		public bool Debito = false;
		public int NumeroPedido;

		private long? Cliente;
		private char[] FormaDePagamento = new char[3];
		private string[] NumeroDoPagamento = new string[3];
		private Parcela[] Parcelas;
		private double TotalDePagamentos = 0;
		private double Troco = 0;
		private double[] ValorDePagamento = new double[3];
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCaixa(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private bool AjustaValores()
		{
			try
			{
				double valor;
				double total = 0;
				double troco;

				if (tbValor1.Text != string.Empty)
				{
					if (!double.TryParse(tbValor1.Text, out valor))
					{
						MessageBox.Show("Valor inválido!");

						tbValor1.SelectAll();

						tbValor1.Focus();

						return false;
					}
					else
					{
						tbValor1.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor2.Text != string.Empty)
				{
					if (!double.TryParse(tbValor2.Text, out valor))
					{
						MessageBox.Show("Valor inválido!");

						tbValor2.SelectAll();

						tbValor2.Focus();

						return false;
					}
					else
					{
						tbValor2.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				if (tbValor3.Text != string.Empty)
				{
					if (!double.TryParse(tbValor3.Text, out valor))
					{
						MessageBox.Show("Valor inválido!");

						tbValor3.SelectAll();

						tbValor3.Focus();

						return false;
					}
					else
					{
						tbValor3.Text = valor.ToString("0.00");

						total += valor;
					}
				}

				tbTotal.Text = total.ToString("0.00");

				troco = total - (double.Parse(lbValorTotal.Text) - double.Parse(lbValorPago.Text));

				tbTroco.Text = troco.ToString("0.00");

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarPedidos(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

				dataGridView1.Columns["indice"].Width = 42;
				dataGridView1.Columns["data"].Width = 60;
				dataGridView1.Columns["hora"].Width = 60;
				dataGridView1.Columns["cliente"].Width = 60;
				dataGridView1.Columns["itens"].Width = 42;
				dataGridView1.Columns["total"].Width = 60;
				dataGridView1.Columns["observacao"].Width = 210;
				dataGridView1.Columns["situacao"].Width = 60;

				dataGridView1.Columns["itens"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "E":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "N":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "O":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "P":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "S":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;
					}
				}

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void AtualizarFormasDePagamento()
		{
			cbForma1.Items.Clear();
			cbForma2.Items.Clear();
			cbForma3.Items.Clear();

			List<string> formas = _dsoftBd.PagamentosFormas(Cliente);

			cbForma1.Items.AddRange(formas.ToArray());
			cbForma2.Items.AddRange(formas.ToArray());
			cbForma3.Items.AddRange(formas.ToArray());
		}

		private void btCrediario_Click(object sender, EventArgs e)
		{
			//if (tbPedido.Text.Length == 0)
			//    return;

			//if (MessageBox.Show("Deseja imprimir demonstrativo do crediário?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//{
			//    frmRelatorio form = new frmRelatorio();

			//    demCrediario2 report = new demCrediario2();

			//    string DadosFilial;

			//    DadosFilial = Filial.Nome + "   CNPJ: " + Filial.Cnpj + "  IE: " + Filial.IE + Environment.NewLine;
			//    DadosFilial += Filial.Endereco + " - " + Filial.Bairro + " - " + Filial.Cidade + " / " + Filial.Estado + "   ";
			//    DadosFilial += "TEL: " + Filial.Telefone;

			//    report.ParameterFields["pedido"].CurrentValues.AddValue(int.Parse(tbPedido.Text));
			//    report.ParameterFields["Filial"].CurrentValues.AddValue(DadosFilial);

			//    form.Text = "Demonstrativo de Crediário";

			//    //form.crystalReportViewer1.ReportSource = report;

			//    form.Show();
			//}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar(false);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarPedido(int pedido)
		{
			try
			{
				char situacao = 'A';
				char situacao_cliente = 'A';
				long cliente = 0;
				string nome = string.Empty;
				DateTime data;
				int itens;
				decimal valor;
				decimal valor_pago;

				tbPedido.Text = pedido.ToString();

				if ((situacao =_dsoftBd.PedidoSituacao(pedido)) == default(char))
				{
					MessageBox.Show("Pedido não encontrado!");

					tbPedido.SelectAll();

					tbPedido.Focus();

					return;
				}

				switch (situacao)
				{
				case 'A':
					lbSituacao.Text = "Em aberto!";
					break;

				case 'B':
					lbSituacao.Text = "Bloqueado!";
					break;

				case 'C':
					lbSituacao.Text = "Cancelado!";
					break;

				case 'E':
					lbSituacao.Text = "Entregue!";
					break;

				case 'N':
					lbSituacao.Text = "Pago!";
					break;

				case 'O':
					lbSituacao.Text = "Pago / Saída!";
					break;

				case 'P':
					lbSituacao.Text = "Pago / Entregue!";
					break;

				case 'S':
					lbSituacao.Text = "Saída!";
					break;
				}

				if (_dsoftBd.PedidoData(pedido, out data))
				{
					dtData.Value = data;
				}
				else
				{
					dtData.Value = DateTime.Now;
				}

				if (_dsoftBd.PedidoCliente(pedido, cliente))
				{
					Cliente = cliente;

					tbCliente.Text = cliente.ToString();

					_dsoftBd.ClienteNome(cliente, out nome, out situacao_cliente);

					lbCliente.Text = nome;
				}

				DataSet ds = new DataSet();

				itens = _dsoftBd.CarregarItensPedido(pedido, ds);

				dataGridView2.DataSource = ds.Tables[0];

				dataGridView2.Columns["numero"].Width = 48;
				dataGridView2.Columns["numero"].DefaultCellStyle.Format = "000";
				dataGridView2.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				dataGridView2.Columns["produto"].Width = 48;
				dataGridView2.Columns["produto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

				dataGridView2.Columns["fracao"].Width = 48;
				dataGridView2.Columns["preco"].Width = 60;

				lbQuantidade.Text = itens.ToString();

				valor = _dsoftBd.PedidoValor(pedido);

				lbValorTotal.Text = valor.ToString("0.00");

				DataSet ds2 = new DataSet();

				valor_pago = _dsoftBd.CarregarPagamentosPedido(pedido, ds2);

				dataGridView3.DataSource = ds2.Tables[0];

				dataGridView3.Columns["codigo"].Width = 42;
				dataGridView3.Columns["tipo"].Width = 42;
				dataGridView3.Columns["descricao"].Width = 120;

				lbValorPago.Text = valor_pago.ToString("0.00");

				if (situacao == 'A' || situacao == 'E' || situacao == 'S')
				{
					btConfirmar.Enabled = true;

					cbForma1.Enabled = true;

					cbForma1.Focus();
				}

				if (_dsoftBd.PagamentoCrediario(pedido))
					btCrediario.Visible = true;
				else
					btCrediario.Visible = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma1.Text == string.Empty)
				{
					MessageBox.Show("Campo 'forma de pagamento' deve ser preenchido!");
					cbForma1.Focus();
					return;
				}

				if (!cbForma1.Items.Contains(cbForma1.Text))
				{
					MessageBox.Show("Selecione um item!");
					cbForma1.SelectAll();
					cbForma1.Focus();
					return;
				}

				tbNumero1.Enabled = true;

				if (cbForma1.Text[0] == 'P')
				{
					double total;
					double pago;

					if (tbCliente.Text == string.Empty)
					{
						MessageBox.Show("Forma de pagamento não permitida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbForma1.SelectAll();
						cbForma1.Focus();

						return;
					}

					frmCrediario form = new frmCrediario(_dsoftBd, _usuario);

					form.Cliente = long.Parse(tbCliente.Text);

					if (!double.TryParse(lbValorTotal.Text, out total))
						total = 0;

					if (!double.TryParse(lbValorPago.Text, out pago))
						pago = 0;

					form.Valor = total - pago;

					if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
					{
						cbForma1.SelectAll();
						cbForma1.Focus();

						return;
					}

					Parcelas = form.Parcelas;

					tbValor1.Text = form.Valor.ToString("###,###,##0.00");

					AjustaValores();

					if (form.Valor < total - pago)
					{
						cbForma2.Enabled = true;
						cbForma2.Focus();
					}
					else
					{
						btConfirmar.Focus();
					}
				}
				else
				{
					decimal total;
					decimal pago;
					decimal pagto2, pagto3;

					decimal.TryParse(lbValorTotal.Text, out total);
					decimal.TryParse(lbValorPago.Text, out pago);
					decimal.TryParse(tbValor2.Text, out pagto2);
					decimal.TryParse(tbValor3.Text, out pagto3);

					tbValor1.Enabled = true;
					tbValor1.Text = (total - pago - pagto2 - pagto3).ToString("##,###,##0.00");

					tbValor1.Focus();
				}
			}
		}

		private void comboBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma2.Text == string.Empty)
				{
					if (double.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (!cbForma2.Items.Contains(cbForma2.Text))
				{
					MessageBox.Show("Selecione um item!");
					cbForma2.SelectAll();
					cbForma2.Focus();
					return;
				}

				tbNumero2.Enabled = true;

				if (cbForma2.Text[0] == 'P')
				{
					double total;
					double pago;
					double pago2;

					if (tbCliente.Text == string.Empty)
					{
						MessageBox.Show("Forma de pagamento não permitida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbForma2.SelectAll();
						cbForma2.Focus();

						return;
					}

					frmCrediario form = new frmCrediario(_dsoftBd, _usuario);

					form.Cliente = long.Parse(tbCliente.Text);

					if (!double.TryParse(lbValorTotal.Text, out total))
						total = 0;

					if (!double.TryParse(lbValorPago.Text, out pago))
						pago = 0;

					if (!double.TryParse(tbTotal.Text, out pago2))
						pago2 = 0;

					form.Valor = total - pago - pago2;

					if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
					{
						cbForma2.SelectAll();
						cbForma2.Focus();

						return;
					}

					Parcelas = form.Parcelas;

					tbValor2.Text = form.Valor.ToString("###,###,##0.00");

					AjustaValores();

					if (form.Valor < total - pago)
					{
						cbForma3.Enabled = true;
						cbForma3.Focus();
					}
					else
					{
						btConfirmar.Focus();
					}
				}
				else
				{
					decimal pago;
					decimal total;
					decimal pagto1;
					decimal pagto3;

					decimal.TryParse(lbValorPago.Text, out pago);
					decimal.TryParse(lbValorTotal.Text, out total);
					decimal.TryParse(tbValor1.Text, out pagto1);
					decimal.TryParse(tbValor3.Text, out pagto3);

					tbValor2.Enabled = true;
					tbValor2.Text = (total - pago - pagto1 - pagto3).ToString("##,###,##0.00");

					tbValor2.Focus();
				}
			}
		}

		private void comboBox3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbForma3.Text == string.Empty)
				{
					if (double.Parse(tbTroco.Text) >= 0)
					{
						btConfirmar.Focus();
						return;
					}
				}

				if (!cbForma3.Items.Contains(cbForma3.Text))
				{
					MessageBox.Show("Selecione um item!");
					cbForma3.SelectAll();
					cbForma3.Focus();
					return;
				}

				tbNumero3.Enabled = true;

				if (cbForma3.Text[0] == 'P')
				{
					double total;
					double pago;

					if (tbCliente.Text == string.Empty)
					{
						MessageBox.Show("Forma de pagamento não permitida!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						cbForma3.SelectAll();
						cbForma3.Focus();

						return;
					}

					frmCrediario form = new frmCrediario(_dsoftBd, _usuario);

					form.Cliente = long.Parse(tbCliente.Text);

					if (!double.TryParse(lbValorTotal.Text, out total))
						total = 0;

					if (!double.TryParse(lbValorPago.Text, out pago))
						pago = 0;

					form.Valor = total - pago;

					if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
					{
						cbForma3.SelectAll();
						cbForma3.Focus();

						return;
					}

					Parcelas = form.Parcelas;

					tbValor3.Text = form.Valor.ToString("###,###,##0.00");

					AjustaValores();

					btConfirmar.Focus();
				}
				else
				{
					decimal total;
					decimal pago;
					decimal pagto1;
					decimal pagto2;

					decimal.TryParse(lbValorTotal.Text, out total);
					decimal.TryParse(lbValorPago.Text, out pago);
					decimal.TryParse(tbValor1.Text, out pagto1);
					decimal.TryParse(tbValor2.Text, out pagto2);

					tbValor3.Enabled = true;
					tbValor3.Text = (total - pago - pagto1 - pagto2).ToString("##,###,##0.00");

					tbValor3.Focus();
				}
			}
		}

		private void Confirmar(bool fechar = true)
		{
			if (btConfirmar.Enabled)
			{
				if ((cbForma1.Text[0] == 'P' || (cbForma2.Text.Length > 0 && cbForma2.Text[0] == 'P') || (cbForma3.Text.Length > 0 && cbForma3.Text[0] == 'P'))
					&& ConfirmarCrediario() && ConfirmarPagamentos())
				{
					//if ((FormaDePagamento[0] != 'P' && FormaDePagamento[0] != '\0') || (FormaDePagamento[1] != 'P' && FormaDePagamento[1] != '\0') || (FormaDePagamento[2] != 'P' && FormaDePagamento[2] != '\0'))
						EmitirCupomFiscal();

					if (NumeroPedido > 0)
					{
						Sair();
					}

					//Atualizar();

					LimparDados();
				}
				else if (ConfirmarPagamentos())
				{
					EmitirCupomFiscal();

					//Atualizar();

					if (fechar)
					{
						this.DialogResult = System.Windows.Forms.DialogResult.OK;
						this.Close();
					}
					else
					{
						LimparDados();
					}
				}
			}
		}

		private bool ConfirmarCrediario()
		{
			int i;
			long l;
			Pedido pedido = new Pedido();

			if (!int.TryParse(tbPedido.Text, out i))
			{
				MessageBox.Show("Número do pedido inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbPedido.SelectAll();
				tbPedido.Focus();

				return false;
			}

			pedido.NumeroPedido(i);

			if (!long.TryParse(tbCliente.Text, out l))
			{
				MessageBox.Show("Cliente deve ser identificado para pagamento com crediário.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return false;
			}

			pedido.ClientePedido(l);

			pedido.Data = dtData.Value;
			pedido.Hora = DateTime.Now;

			foreach (Parcela p in Parcelas)
			{
				long numero = _dsoftBd.NovoPagamento(pedido, p, _usuario.Autorizado);

				//Sync
				if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
				{
					Sync.NovaParcela(ref pedido, p, numero);
				}
			}

			if (MessageBox.Show("Deseja imprimir demonstrativo do crediário?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				//frmRelatorio form = new frmRelatorio();

				//demCrediario2 report = new demCrediario2();

				//string DadosFilial;

				//DadosFilial = Filial.Nome + "   CNPJ: " + Filial.Cnpj + "  IE: " + Filial.IE + Environment.NewLine;
				//DadosFilial += Filial.Endereco + " - " + Filial.Bairro + " - " + Filial.Cidade + " / " + Filial.Estado + "   ";
				//DadosFilial += "TEL: " + Filial.Telefone;

				//report.ParameterFields["pedido"].CurrentValues.AddValue(int.Parse(tbPedido.Text));
				//report.ParameterFields["Filial"].CurrentValues.AddValue(DadosFilial);

				//form.Text = "Demonstrativo de Crediário";

				////form.crystalReportViewer1.ReportSource = report;

				//form.Show();
			}

			return _dsoftBd.PagarPedidoCrediario(pedido.NumeroPedido(), _usuario.Autorizado);
		}

		private bool ConfirmarPagamentos()
		{
			try
			{
				int pedido;

				if (tbPedido.Text == string.Empty)
				{
					MessageBox.Show("Campo 'pedido' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbPedido.Focus();

					return false;
				}

				if (!int.TryParse(tbPedido.Text, out pedido))
				{
					MessageBox.Show("Campo 'pedido' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbPedido.SelectAll();
					tbPedido.Focus();

					return false;
				}

				// Verificamos se pelo menos uma forma de pagamento foi preenchida
				if (cbForma1.Text == string.Empty)
				{
					MessageBox.Show("Selecione ao menos uma forma de pagamento!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbForma1.Focus();

					return false;
				}

				if (!cbForma1.Items.Contains(cbForma1.Text))
				{
					MessageBox.Show("Selecione um item da lista!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbForma1.SelectAll();
					cbForma1.Focus();

					return false;
				}

				FormaDePagamento[0] = cbForma1.Text[0];

				NumeroDoPagamento[0] = tbNumero1.Text;

				if (tbValor1.Text == string.Empty || !double.TryParse(tbValor1.Text, out ValorDePagamento[0]) || ValorDePagamento[0] <= 0)
				{
					MessageBox.Show("Valor inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbValor1.SelectAll();
					tbValor1.Focus();

					return false;
				}

				// Carregamos os dados da segunda forma de pagamento, caso tenha sido preenchida
				if (cbForma2.Text.Length > 0 && cbForma2.Items.Contains(cbForma2.Text))
				{
					FormaDePagamento[1] = cbForma2.Text[0];
					NumeroDoPagamento[1] = tbNumero2.Text;

					if (tbValor2.Text.Length < 1 || !double.TryParse(tbValor2.Text, out ValorDePagamento[1]) || ValorDePagamento[1] <= 0)
					{
						MessageBox.Show("Valor inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						tbValor2.SelectAll();
						tbValor2.Focus();

						return false;
					}
				}

				if (cbForma3.Text.Length > 0 && cbForma3.Items.Contains(cbForma3.Text))
				{
					FormaDePagamento[2] = cbForma3.Text[0];
					NumeroDoPagamento[2] = tbNumero3.Text;

					if (tbValor3.Text.Length < 1 || !double.TryParse(tbValor3.Text, out ValorDePagamento[2]) || ValorDePagamento[2] <= 0)
					{
						MessageBox.Show("Valor inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						tbValor3.SelectAll();
						tbValor3.Focus();

						return false;
					}
				}

				TotalDePagamentos = double.Parse(tbTotal.Text);

				Troco = double.Parse(tbTroco.Text);

				if (Troco > 0)
				{
					if (MessageBox.Show("Confirma entrega do troco no valor de R$ " + Troco.ToString("0.00") + " ?", this.Text,
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						bool troco_entregue = false;

						for (int i = 0; i < FormaDePagamento.Length; i++)
						{
							if (FormaDePagamento[i] == 'D')
							{
								ValorDePagamento[i] -= Troco;
								troco_entregue = true;

								break;
							}
						}

						if (!troco_entregue)
						{
							MessageBox.Show("Troco somente disponível para pagamento em dinheiro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

							return false;
						}
					}
					else
					{
						return false;
					}
				}

				// Gravamos os pagamentos
				for (int i = 0; i < FormaDePagamento.Length; i++)
				{
					if (FormaDePagamento[i] != '\0' && FormaDePagamento[i] != 'P')
					{
						if (!_dsoftBd.PagarPedido(pedido, FormaDePagamento[i], NumeroDoPagamento[i], ValorDePagamento[i], _usuario.Autorizado, Caixa.Numero))
						{
							MessageBox.Show("Pagamento inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

							tbPedido.Focus();

							return false;
						}
					}

					if (FormaDePagamento[i] == 'A')
						Debito = true;
				}

				if (NumeroPedido > 0)
				{
					Sair();
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarPedido(int.Parse(dataGridView1.CurrentRow.Cells["codigo"].Value.ToString()));
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
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

		private void EmitirCupomFiscal()
		{
			if (!RegrasDeNegocio.Instance.EmiteCupomFiscal)
				return;

			CapturaCPFNota form = new CapturaCPFNota();

			if (form.ShowDialog() == DialogResult.Cancel)
				return;

			try
			{
				Pedido pedido = new Pedido();

				_dsoftBd.CarregarPedido(NumeroPedido, pedido);

				BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_AbreCupom(form.Cpf));

				PrepararValoresECF(pedido);

				if (Terminal.ECF() == "BEMATECH MP-2100 TH FI")
				{
					foreach (ItemPedido item in pedido.ItensPedido)
					{
						if (item == null)
							continue;

						if (item.Unitario == 0)
							item.Unitario = 0.01M;

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_VendeItem(item.Produto.ToString(), _dsoftBd.ProdutoNome(item.Produto, 29), "FF", "I", item.Quantidade.ToString("0000"), 2, item.Unitario.ToString("00000.00"), "%", item.Desconto.ToString("0000")));
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

					for (int i = 0; i < FormaDePagamento.Length; i++)
					{
						if (FormaDePagamento[i] == '\0')
							continue;

						string desc;
						string valor;

						if (FormaDePagamento[i] == 'P')
							desc = "Crediário";
						else if (FormaDePagamento[i] == 'X')
							desc = "Cheque";
						else if (FormaDePagamento[i] == 'C')
							desc = "Crédito";
						else if (FormaDePagamento[i] == 'M')
							desc = "Master Card";
						else if (FormaDePagamento[i] == 'V')
							desc = "Visa";
						else
							desc = "Dinheiro";

						if (i == 0)
							valor = tbValor1.Text;
						else if (i == 1)
							valor = tbValor2.Text;
						else
							valor = tbValor3.Text;

						BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_EfetuaFormaPagamento(desc, valor));
					}

					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_TerminaFechamentoCupom("Obrigado. Volte sempre!"));

					string Loja = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroLoja(ref Loja));

					string Caixa = new string('\x20', 4);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCaixa(ref Caixa));

					string Cupom = new string('\x20', 6);
					BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCupom(ref Cupom));

					_dsoftBd.AtribuiCupomFiscal(NumeroPedido, int.Parse(Loja), int.Parse(Caixa), long.Parse(Cupom));
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
						retorno = SwedaST120.ECF_VendeItem(item.Produto.ToString("000"), item.ProdutoNome, "1200", "I", item.Quantidade.ToString("0"), 2, item.Unitario.ToString("00000.00"), "%", "0000");
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

					for (int i = 0; i < FormaDePagamento.Length; i++)
					{
						if (FormaDePagamento[i] == '\0')
							continue;

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
							valor = tbValor1.Text;
						else if (i == 1)
							valor = tbValor2.Text;
						else
							valor = tbValor3.Text;

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

					_dsoftBd.AtribuiCupomFiscal(NumeroPedido, int.Parse(Loja.ToString()), int.Parse(Caixa.ToString()), long.Parse(Cupom.ToString()));
				}
			}
			catch (Exception e)
			{
				DSoftLogger.Logger.Instance.Error(e);
			}
		}

		private void frmCaixa_Load(object sender, EventArgs e)
		{
			//Atualizar();

			this.Activate();

			LimparDados();

			if (NumeroPedido > 0)
			{
				CarregarPedido(NumeroPedido);

				groupBox1.Enabled = true;

				cbForma1.Focus();
			}

			AtualizarFormasDePagamento();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void LimparDados()
		{
			foreach (Control c in groupBox1.Controls)
			{
				if (c is TextBox || c is ComboBox)
				{
					c.Text = string.Empty;
				}
			}

			lbCliente.Text = string.Empty;
			lbQuantidade.Text = string.Empty;
			lbValorTotal.Text = string.Empty;
			lbValorPago.Text = string.Empty;
			lbSituacao.Text = string.Empty;

			DataSet ds = new DataSet();

			ds.Tables.Add();

			dataGridView2.DataSource = ds.Tables[0];
			dataGridView3.DataSource = ds.Tables[0];

			btConfirmar.Enabled = false;
			btLimpar.Enabled = false;

			cbForma1.Enabled = false;
			cbForma2.Enabled = false;
			cbForma3.Enabled = false;

			tbNumero1.Enabled = false;
			tbValor1.Enabled = false;
			tbValor2.Enabled = false;
			tbNumero2.Enabled = false;
			tbValor3.Enabled = false;
			tbNumero3.Enabled = false;

			tbPedido.Focus();
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			int pedido;

			if (e.KeyChar == (char)Keys.Enter && tbPedido.Text != string.Empty)
			{
				if (!int.TryParse(tbPedido.Text, out pedido))
				{
					MessageBox.Show("Campo 'pedido' deve ser numérico!");

					tbPedido.SelectAll();

					tbPedido.Focus();

					return;
				}

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					int comanda = pedido;
					pedido = 0;
					int contador = 0;

					while (pedido == 0)
					{
						pedido = _dsoftBd.PedidoPorComanda(comanda, DateTime.Today.AddDays(contador));

						if (++contador > 3)
						{
							break;
						}
					}

					if (pedido == 0)
					{
						pedido = comanda;
					}
				}

				CarregarPedido(pedido);
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (btLimpar.Enabled == false)
			{
				btLimpar.Enabled = true;
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor1.Enabled = true;

				tbValor1.Focus();
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (AjustaValores())
				{
					cbForma2.Enabled = true;

					cbForma2.Focus();
				}
			}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (AjustaValores())
				{
					cbForma3.Enabled = true;

					cbForma3.Focus();
				}
			}
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor2.Enabled = true;

				tbValor2.Focus();
			}
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbValor3.Text != string.Empty && AjustaValores())
				{
					btConfirmar.Focus();
				}
			}
		}

		private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor3.Enabled = true;

				tbValor3.Focus();
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Confirmar(false);
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDeCaixa);

			form.ShowDialog();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			frmRecebimentos form = new frmRecebimentos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDiario);

			form.Text = "Fechamento Diário";

			form.ShowDialog();
		}

		private void toolStripMenuItem6_Click(object sender, EventArgs e)
		{
			string Loja = new string('\x20', 4);
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroLoja(ref Loja));

			string Caixa = new string('\x20', 4);
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCaixa(ref Caixa));

			string Cupom = new string('\x20', 6);
			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_NumeroCupom(ref Cupom));

			int pedido = _dsoftBd.PedidoDoCupomFiscal(int.Parse(Loja), int.Parse(Caixa), long.Parse(Cupom));

			BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_CancelaCupom());
		}

		#endregion Methods
	}
}