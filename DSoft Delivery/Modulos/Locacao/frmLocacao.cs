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
using DSoft_Delivery.Forms;
using DSoftParameters;
using DSoftForms;

namespace DSoft_Delivery.Modulos.Locacao
{
	public partial class frmLocacao : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private TabelaDePrecos _tabela;
		private Cliente _cliente;
		private Produto _produto;
		private DSoftModels.Locacao _locacao;

		public frmLocacao(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmLocacao_Load(object sender, EventArgs e)
		{
			CarregarTabelas();
			CarregarClientesAutocomplete();
			CarregarProdutosLocacao();
			CarregarLocacoes();
			BloquearAcessos();

			LimparDados();
		}

		private void BloquearAcessos()
		{
			if (!_usuario.NivelUsuario.Administrador)
			{
				consultasToolStripMenuItem.Enabled = false;
			}
		}

		private void CarregarTabelas()
		{
			cbTabelas.Items.AddRange(_dsoftBd.CarregarTabelas().ToArray());

			cbTabelas.SelectedIndex = 0;
			_tabela = (TabelaDePrecos)cbTabelas.SelectedItem;
		}

		private void CarregarClientesAutocomplete()
		{
			DataSet ds = new DataSet();
			_dsoftBd.CarregarClientesNome(ds);

			string[] nomes = new string[ds.Tables[0].Rows.Count];

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				nomes[i] = ds.Tables[0].Rows[i][0].ToString();
			}

			tbCliente.AutoCompleteCustomSource.AddRange(nomes);
		}

		private void CarregarProdutosLocacao()
		{
			DataTable produtos = _dsoftBd.CarregarProdutosLocacao();

			dgProdutos.DataSource = produtos;
		}

		private void CarregarLocacoes()
		{
			dgLocacao.DataSource = _dsoftBd.Locacoes();

			dgLocacao.Columns["indice"].HeaderText = "Índice";
			dgLocacao.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgLocacao.Columns["cliente"].HeaderText = "Cliente";
			dgLocacao.Columns["inicio_data"].HeaderText = "Início (data)";
			dgLocacao.Columns["inicio_hora"].HeaderText = "Início (hora)";
			dgLocacao.Columns["inicio_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgLocacao.Columns["previsao_data"].HeaderText = "Previsão (data)";
			dgLocacao.Columns["previsao_hora"].HeaderText = "Previsão (hora)";
			dgLocacao.Columns["previsao_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgLocacao.Columns["valor_previsto"].HeaderText = "Valor previsto (R$)";
			dgLocacao.Columns["valor_previsto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgLocacao.Columns["valor_previsto"].DefaultCellStyle.Format = "##,###,##0.00";
			dgLocacao.Columns["devolucao_data"].HeaderText = "Devolução (data)";
			dgLocacao.Columns["devolucao_hora"].HeaderText = "Devolução (hora)";
			dgLocacao.Columns["devolucao_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgLocacao.Columns["valor_real"].HeaderText = "Valor real (R$)";
			dgLocacao.Columns["valor_real"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgLocacao.Columns["valor_real"].DefaultCellStyle.Format = "##,###,##0.00";
			dgLocacao.Columns["usuario_inicio"].HeaderText = "Usuário (locação)";
			dgLocacao.Columns["usuario_recepcao"].HeaderText = "Usuário (recepção)";
			dgLocacao.Columns["observacao"].HeaderText = "Observação";
			dgLocacao.Columns["tabela"].HeaderText = "Tabela de preços";
			dgLocacao.Columns["situacao"].HeaderText = "Situação";

			DSoftCore.Util.Pintar(ref dgLocacao);

			if (dgLocacao.Rows.Count > 1)
			{
				dgLocacao.FirstDisplayedScrollingRowIndex = dgLocacao.Rows.Count - 1;
			}
		}

		private void Confirmar()
		{
			DSoftModels.Locacao locacao = new DSoftModels.Locacao();
			locacao.Cliente = _cliente;
			locacao.Produtos.Add(_produto);
			locacao.Observacao = tbObservacao.Text;
			locacao.InicioData = dtInicioData.Value;
			locacao.InicioHora = dtInicioHora.Value;
			locacao.PrevisaoData = dtPrevisaoData.Value;
			locacao.PrevisaoHora = dtPrevisaoHora.Value;
			locacao.UsuarioInicio = _usuario;
			locacao.Tabela = _tabela;

			decimal valor_previsto;
			decimal.TryParse(tbValorPrevisto.Text, out valor_previsto);
			locacao.ValorPrevisto = valor_previsto;

			if (MessageBox.Show("Imprimir Termo de Responsabilidade?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
				== System.Windows.Forms.DialogResult.Yes)
			{
				ImprimirTermoDeResponsabilidade();
			}

			if (_dsoftBd.IncluirLocacao(locacao, _usuario))
			{
				LimparDados();
				CarregarLocacoes();
			}
			else
			{
				MessageBox.Show("Não foi possível gravar os dados. Se o erro persistir, entre em contato com o suporte!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void ImprimirTermoDeResponsabilidade()
		{
			string termo = RegrasDeNegocio.Instance.TermoDeResponsabilidade;

			termo = termo.Replace("[DATA]", DateTime.Now.ToShortDateString());
			termo = termo.Replace("[CLIENTE]", _cliente.Nome);
			termo = termo.Replace("[PRODUTO]", _produto.Nome);

			Impressora.Imprimir(termo);
		}

		private void ImprimirReciboDeDevolucao()
		{
			string recibo = RegrasDeNegocio.Instance.ReciboDeDevolucao;

			recibo = recibo.Replace("[DATA]", _locacao.InicioData.ToShortDateString());
			recibo = recibo.Replace("[CLIENTE]", _locacao.Cliente.Nome);
			recibo = recibo.Replace("[PRODUTO]", _locacao.Produtos[0].Nome);
			recibo = recibo.Replace("[VOLTA]", _locacao.DevolucaoHora.ToShortTimeString());

			Impressora.Imprimir(recibo);
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void Sair()
		{
			this.Close();
		}

		private void tbCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				long codigo = _dsoftBd.ClienteCodigo(tbCliente.Text);

				if (codigo > 0)
				{
					_cliente = _dsoftBd.CarregarCliente(codigo);
					lbCliente.Text = _cliente.ToString();
				}
				else
				{
					DialogResult resposta = MessageBox.Show("Cliente não cadastrado. Deseja cadastrar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (resposta == System.Windows.Forms.DialogResult.Yes)
					{
						NovoCliente(tbCliente.Text);
					}
				}
			}
		}

		private void NovoCliente(string nome)
		{
			frmCadRapido form = new frmCadRapido(_dsoftBd, _usuario, nome);

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_cliente = _dsoftBd.CarregarCliente(form.Codigo);
			}
		}

		private void CarregarProduto(long produto)
		{
			_produto = _dsoftBd.CarregarProduto(produto);

			if (_produto != null)
			{
				lbProduto.Text = _produto.ToString();

				CalculaValorPrevisto();
			}
		}

		private void CalculaValorPrevisto()
		{
			if (_produto == null)
				return;

			int intervalo = _dsoftBd.IntervaloLocacao(_produto);
			decimal valor = _dsoftBd.ValorLocacao(_produto, _tabela);

			DateTime inicio = dtInicioData.Value.Date;
			inicio = inicio.AddHours(dtInicioHora.Value.Hour);
			inicio = inicio.AddMinutes(dtInicioHora.Value.Minute);

			DateTime previsao = dtPrevisaoData.Value.Date;
			previsao = previsao.AddHours(dtPrevisaoHora.Value.Hour);
			previsao = previsao.AddMinutes(dtPrevisaoHora.Value.Minute);

			TimeSpan diferenca = previsao.Subtract(inicio);

			double minutos = diferenca.TotalMinutes;

			List<LocacaoEspecialPreco> especiais = _dsoftBd.CarregarLocacoesEspeciaisPrecos(_tabela.Codigo, _produto.Codigo);

			// Tendo os minutos que usaremos para o cálculo, vamos buscar na lista dos períodos especiais qual deles se encaixa no período
			if (especiais != null)
			{
				especiais = especiais.OrderBy(o => o.Periodo).ToList();

				foreach (LocacaoEspecialPreco l in especiais)
				{
					if (minutos < l.Periodo)
					{
						tbValorPrevisto.Text = l.Preco.ToString("##,###,##0.00");
						return;
					}
				}

				// Caso não tenhamos encontrado nenhum período especial na qual nossa locação se encaixe, pegamos a maior e calculamos os períodos extra
				LocacaoEspecialPreco ultimo = especiais[especiais.Count - 1];

				minutos -= ultimo.Periodo;
				decimal preco = ultimo.Preco + (valor * (int)(((int)minutos / intervalo) + 1));

				tbValorPrevisto.Text = preco.ToString("##,###,##0.00");
			}
			else
			{
				decimal valor_previsto = valor * (int)(((int)minutos / intervalo) + 1);

				tbValorPrevisto.Text = valor_previsto.ToString("##,###,##0.00");
			}
		}

		private void LimparDados()
		{
			tbCliente.Text = string.Empty;
			_cliente = null;
			lbCliente.Text = string.Empty;
			_produto = null;
			lbProduto.Text = string.Empty;
			tbObservacao.Text = string.Empty;

			dtInicioData.Enabled = true;
			dtInicioHora.Enabled = true;
			dtInicioData.Value = DateTime.Now;
			dtInicioHora.Value = DateTime.Now;

			dtPrevisaoData.Enabled = true;
			dtPrevisaoHora.Enabled = true;
			dtPrevisaoData.Value = DateTime.Now;
			dtPrevisaoHora.Value = DateTime.Now.AddMinutes(30);

			dtChegadaData.Enabled = false;
			dtChegadaHora.Enabled = false;
			dtChegadaData.Value = DateTime.Now;
			dtChegadaHora.Value = DateTime.Now;

			tbValorPrevisto.Text = string.Empty;
			tbValorReal.Text = string.Empty;

			btConfirmar.Enabled = true;
			btCancelar.Enabled = false;
			btReceber.Enabled = false;
		}

		private void CarregarLocacao(int indice)
		{
			_locacao = new DSoftModels.Locacao();

			_locacao.Indice = Convert.ToInt32(dgLocacao.Rows[indice].Cells["indice"].Value);
			_locacao.InicioData = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["inicio_data"].Value);
			_locacao.InicioHora = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["inicio_hora"].Value);
			_locacao.InicioHora = _locacao.InicioHora.AddYears(_locacao.InicioData.Year - 1);
			_locacao.InicioHora = _locacao.InicioHora.AddMonths(_locacao.InicioData.Month - 1);
			_locacao.InicioHora = _locacao.InicioHora.AddDays(_locacao.InicioData.Day - 1);

			_locacao.PrevisaoData = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["previsao_data"].Value);
			_locacao.PrevisaoHora = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["previsao_hora"].Value);
			_locacao.PrevisaoHora = _locacao.PrevisaoHora.AddYears(_locacao.PrevisaoData.Year - 1);
			_locacao.PrevisaoHora = _locacao.PrevisaoHora.AddMonths(_locacao.PrevisaoData.Month - 1);
			_locacao.PrevisaoHora = _locacao.PrevisaoHora.AddDays(_locacao.PrevisaoData.Day - 1);

			_locacao.Situacao = dgLocacao.Rows[indice].Cells["situacao"].Value.ToString();

			_locacao.Cliente = _dsoftBd.CarregarCliente(Convert.ToInt64(dgLocacao.Rows[indice].Cells["cliente"].Value));
			_locacao.Observacao = dgLocacao.Rows[indice].Cells["observacao"].Value.ToString();

			if (dgLocacao.Rows[indice].Cells["devolucao_data"].Value != null && dgLocacao.Rows[indice].Cells["devolucao_data"].Value.ToString().Length > 0)
			{
				_locacao.DevolucaoData = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["devolucao_data"].Value);
			}

			if (dgLocacao.Rows[indice].Cells["devolucao_hora"].Value != null && dgLocacao.Rows[indice].Cells["devolucao_hora"].Value.ToString().Length > 0)
			{
				_locacao.DevolucaoHora = Convert.ToDateTime(dgLocacao.Rows[indice].Cells["devolucao_hora"].Value);
				_locacao.DevolucaoHora = _locacao.DevolucaoHora.AddYears(_locacao.DevolucaoData.Year - 1);
				_locacao.DevolucaoHora = _locacao.DevolucaoHora.AddMonths(_locacao.DevolucaoData.Month - 1);
				_locacao.DevolucaoHora = _locacao.DevolucaoHora.AddDays(_locacao.DevolucaoData.Day - 1);
			}

			_locacao.ValorPrevisto = Convert.ToDecimal(dgLocacao.Rows[indice].Cells["valor_previsto"].Value);

			if (dgLocacao.Rows[indice].Cells["valor_real"].Value != null && dgLocacao.Rows[indice].Cells["valor_real"].Value.ToString().Length > 0)
			{
				_locacao.Valor = Convert.ToDecimal(dgLocacao.Rows[indice].Cells["valor_real"].Value);
			}

			_locacao.Produtos = _dsoftBd.LocacaoItens(_locacao.Indice);

			_cliente = _locacao.Cliente;

			if (_locacao.Produtos.Count > 0)
			{
				_produto = _locacao.Produtos[0];
			}

			if (_cliente != null)
			{
				lbCliente.Text = _cliente.ToString();
			}

			if (_produto != null)
			{
				lbProduto.Text = _produto.ToString();
			}

			tbObservacao.Text = _locacao.Observacao;
			dtInicioData.Value = _locacao.InicioData;
			dtInicioHora.Value = _locacao.InicioHora;
			dtPrevisaoData.Value = _locacao.PrevisaoData;
			dtPrevisaoHora.Value = _locacao.PrevisaoHora;
			tbValorPrevisto.Text = _locacao.ValorPrevisto.ToString("##,###,##0.00");

			dtInicioData.Enabled = false;
			dtInicioHora.Enabled = false;
			dtPrevisaoData.Enabled = false;
			dtPrevisaoHora.Enabled = false;

			btConfirmar.Enabled = false;

			if (_locacao.Situacao == "C")
			{
				dtChegadaData.Enabled = false;
				dtChegadaHora.Enabled = false;

				btCancelar.Enabled = false;
				btReceber.Enabled = false;
			}
			else
			{
				if (_locacao.DevolucaoData > DateTime.MinValue)
				{
					dtChegadaData.Value = _locacao.DevolucaoData;
					dtChegadaHora.Value = _locacao.DevolucaoHora;

					dtChegadaData.Enabled = false;
					dtChegadaHora.Enabled = false;

					tbValorReal.Text = _locacao.Valor.ToString("##,###,##0.00");

					btReceber.Enabled = false;
					btCancelar.Enabled = false;
				}
				else
				{
					dtChegadaData.Value = DateTime.Now;
					dtChegadaHora.Value = DateTime.Now;

					CalculaValorReal();

					btReceber.Enabled = true;
					btCancelar.Enabled = true;
				}
			}
		}

		private void CalculaValorReal()
		{
			if (_produto == null)
				return;

			int intervalo = _dsoftBd.IntervaloLocacao(_produto);
			decimal valor = _dsoftBd.ValorLocacao(_produto, _tabela);

			DateTime inicio = dtInicioData.Value.Date;
			inicio = inicio.AddHours(dtInicioHora.Value.Hour);
			inicio = inicio.AddMinutes(dtInicioHora.Value.Minute);

			DateTime chegada = dtChegadaData.Value.Date;
			chegada = chegada.AddHours(dtChegadaHora.Value.Hour);
			chegada = chegada.AddMinutes(dtChegadaHora.Value.Minute);

			TimeSpan diferenca = chegada.Subtract(inicio);

			double minutos = diferenca.TotalMinutes;

			List<LocacaoEspecialPreco> especiais = _dsoftBd.CarregarLocacoesEspeciaisPrecos(_tabela.Codigo, _produto.Codigo);

			// Tendo os minutos que usaremos para o cálculo, vamos buscar na lista dos períodos especiais qual deles se encaixa no período
			if (especiais != null)
			{
				especiais = especiais.OrderBy(o => o.Periodo).ToList();

				foreach (LocacaoEspecialPreco l in especiais)
				{
					if (minutos < l.Periodo)
					{
						_locacao.Valor = l.Preco;
						tbValorReal.Text = l.Preco.ToString("##,###,##0.00");
						return;
					}
				}

				// Caso não tenhamos encontrado nenhum período especial na qual nossa locação se encaixe, pegamos a maior e calculamos os períodos extra
				LocacaoEspecialPreco ultimo = especiais[especiais.Count - 1];

				minutos -= ultimo.Periodo;
				decimal preco = ultimo.Preco + (valor * (int)(((int)minutos / intervalo) + 1));

				_locacao.Valor = preco;
				tbValorReal.Text = preco.ToString("##,###,##0.00");
			}
			else
			{
				decimal valor_previsto = valor * (int)(((int)minutos / intervalo) + 1);

				_locacao.Valor = valor_previsto;
				tbValorReal.Text = valor_previsto.ToString("##,###,##0.00");
			}
		}

		private void Cancelar()
		{
			if (_locacao != null)
			{
				if (MessageBox.Show("Confirma o cancelamento do registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					frmMotivoCancelamento motivo = new frmMotivoCancelamento(_dsoftBd, _usuario);

					if (motivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						if (_dsoftBd.CancelarLocacao(_locacao, motivo.Usuario, motivo.Motivo))
						{
							for (int i = dgLocacao.Rows.Count - 1; i > 0; i--)
							{
								if ((int)dgLocacao.Rows[i].Cells["indice"].Value == _locacao.Indice)
								{
									dgLocacao.Rows[i].DefaultCellStyle.BackColor = Color.Red;
									dgLocacao.Rows[i].DefaultCellStyle.ForeColor = Color.White;

									dgLocacao.Rows[i].Cells["situacao"].Value = "C";
								}
							}
						}
					}
				}
			}
		}

		private void Receber()
		{
			if (_locacao != null)
			{
				if (MessageBox.Show(string.Format("Confirmar recepção do produto ({0})?", _locacao.Produtos[0].Nome), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== System.Windows.Forms.DialogResult.Yes)
				{
					_locacao.DevolucaoData = DateTime.Now;
					_locacao.DevolucaoHora = DateTime.Now;

					CaixaSimples caixa = new CaixaSimples(_dsoftBd, _usuario);
					caixa.Locacao = _locacao;
					caixa.Valor = _locacao.Valor;
					caixa.Referencia = string.Format("VALOR REFERENTE AO PAGAMENTO DA LOCAÇÃO DO PRODUTO ({0}) NO PERÍDO DE {1} {2} À {3} {4}.", _locacao.Produtos[0].Nome,
						_locacao.InicioData.ToShortDateString(), _locacao.InicioHora.ToShortTimeString(),DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());

					if (caixa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						if (_dsoftBd.ReceberLocacao(_locacao, _usuario))
						{
							for (int i = dgLocacao.Rows.Count - 1; i > 0; i--)
							{
								if ((int)dgLocacao.Rows[i].Cells["indice"].Value == _locacao.Indice)
								{
									dgLocacao.Rows[i].DefaultCellStyle.BackColor = Color.Green;
									dgLocacao.Rows[i].DefaultCellStyle.ForeColor = Color.White;

									dgLocacao.Rows[i].Cells["situacao"].Value = "P";
									dgLocacao.Rows[i].Cells["valor_real"].Value = _locacao.Valor.ToString("##,###,##0.00");
								}
							}
						}
					}
					else
					{
						MessageBox.Show("Operação não realizada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

					if (MessageBox.Show("Deseja imprimir o recibo de devolução?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
						== System.Windows.Forms.DialogResult.Yes)
					{
						ImprimirReciboDeDevolucao();
					}
				}
			}
		}

		private void btNovoCliente_Click(object sender, EventArgs e)
		{
			NovoCliente(tbCliente.Text);
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void llAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			dtInicioData.Value = DateTime.Now;
			dtInicioHora.Value = DateTime.Now;

			dtPrevisaoData.Value = DateTime.Now;
			dtPrevisaoHora.Value = DateTime.Now.AddMinutes(30);

			dtChegadaData.Value = DateTime.Now;
			dtChegadaHora.Value = DateTime.Now;
		}

		private void dgProdutos_DoubleClick(object sender, EventArgs e)
		{
			long produto;
			long.TryParse(dgProdutos.CurrentRow.Cells["codigo"].Value.ToString(), out produto);

			if (produto > 0)
			{
				CarregarProduto(produto);
			}
		}

		private void cbTabelas_SelectedIndexChanged(object sender, EventArgs e)
		{
			_tabela = (TabelaDePrecos)cbTabelas.SelectedItem;
		}

		private void dtInicioData_ValueChanged(object sender, EventArgs e)
		{
			CalculaValorPrevisto();
		}

		private void dtInicioHora_ValueChanged(object sender, EventArgs e)
		{
			CalculaValorPrevisto();
		}

		private void dtPrevisaoData_ValueChanged(object sender, EventArgs e)
		{
			CalculaValorPrevisto();
		}

		private void dtPrevisaoHora_ValueChanged(object sender, EventArgs e)
		{
			CalculaValorPrevisto();
		}

		private void dgLocacao_DoubleClick(object sender, EventArgs e)
		{
			if (dgLocacao.CurrentRow != null)
			{
				CarregarLocacao(dgLocacao.CurrentRow.Index);
			}
		}

		private void btReceber_Click(object sender, EventArgs e)
		{
			Receber();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btTermoDeResponsabilidade_Click(object sender, EventArgs e)
		{
			ImprimirTermoDeResponsabilidade();
		}

		private void locaçõesPorUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConsulta form = new frmConsulta(_dsoftBd, _usuario);
			form.Show();
		}
	}
}
