using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DSoftBd;

using DSoftCore;

using DSoftModels;

using DSoftParameters;

using DSoft_Delivery.Forms;
using DSoft_Delivery.Relatorios;

namespace DSoft_Delivery
{
	public partial class frmOrdemColeta : Form
	{
		#region Fields

		private string NomeStatusServico = string.Empty;
		private OrdemDeColeta ordem;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmOrdemColeta(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		public void AtualizaConhecimento(int indice, string situacao)
		{
			this.Invoke(new Action(() =>
			{
				string _indice = indice.ToString();

				for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
				{
					if (dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString() == _indice)
					{
						dgvConhecimentos.Rows[i].Cells["situacao"].Value = situacao;

						if (situacao == "R")
						{
							dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Black;
							dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
						else if (situacao == "U")
						{
							dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
							dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
					}
				}
			}));
		}

		public void UpdateVerificationStatus()
		{
			VerificationStatus();
		}

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarOrdensServico(ds);

			dgvConhecimentos.DataSource = ds.Tables[0];

			dgvConhecimentos.Columns["indice"].HeaderText = "Indice";
			dgvConhecimentos.Columns["indice"].Width = 60;
			dgvConhecimentos.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvConhecimentos.Columns["abertura_data"].HeaderText = "Abertura";
			dgvConhecimentos.Columns["abertura_data"].Width = 60;
			dgvConhecimentos.Columns["abertura_hora"].HeaderText = "Hora";
			dgvConhecimentos.Columns["abertura_hora"].Width = 60;
			dgvConhecimentos.Columns["abertura_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgvConhecimentos.Columns["remetente"].HeaderText = "Remetente";
			dgvConhecimentos.Columns["remetente"].Width = 120;
			dgvConhecimentos.Columns["conhecimento"].HeaderText = "Conhecimento";
			dgvConhecimentos.Columns["conhecimento"].Width = 80;
			dgvConhecimentos.Columns["conhecimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvConhecimentos.Columns["manifesto"].HeaderText = "Manifesto";
			dgvConhecimentos.Columns["manifesto"].Width = 80;
			dgvConhecimentos.Columns["manifesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvConhecimentos.Columns["recebida_data"].HeaderText = "Recebida";
			dgvConhecimentos.Columns["recebida_data"].Width = 60;
			dgvConhecimentos.Columns["recebida_hora"].HeaderText = "Hora";
			dgvConhecimentos.Columns["recebida_hora"].Width = 60;
			dgvConhecimentos.Columns["recebida_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgvConhecimentos.Columns["conferida_data"].HeaderText = "Conferida";
			dgvConhecimentos.Columns["conferida_data"].Width = 60;
			dgvConhecimentos.Columns["conferida_hora"].HeaderText = "Hora";
			dgvConhecimentos.Columns["conferida_hora"].Width = 60;
			dgvConhecimentos.Columns["conferida_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgvConhecimentos.Columns["montagem_data"].HeaderText = "Montagem";
			dgvConhecimentos.Columns["montagem_data"].Width = 60;
			dgvConhecimentos.Columns["montagem_hora"].HeaderText = "Hora";
			dgvConhecimentos.Columns["montagem_hora"].Width = 60;
			dgvConhecimentos.Columns["montagem_hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgvConhecimentos.Columns["chegada_data"].HeaderText = "Chegada";
			dgvConhecimentos.Columns["chegada_data"].Width = 60;
			dgvConhecimentos.Columns["chegada_hora"].HeaderText = "Hora";
			dgvConhecimentos.Columns["chegada_hora"].Width = 60;
			dgvConhecimentos.Columns["chegada_hora"].DefaultCellStyle.Format = "HH:mm:ss";

			for (int i = 0; i < dgvConhecimentos.Rows.Count; i++)
			{
				switch (dgvConhecimentos.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "A":
					break;

				case "T":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
					break;

				case "E":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
					break;

				case "P":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
					break;

				case "C":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					break;

				case "U":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
					dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					break;

				case "R":
					dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Black;
					dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					break;
				}
			}

			if (dgvConhecimentos.Rows.Count > 1)
				dgvConhecimentos.FirstDisplayedScrollingRowIndex = dgvConhecimentos.Rows.Count - 1;

			CarregarEmitentes();
			CarregarClientes();
			CarregarMotoristas();
			CarregarVeiculos();
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btCorrecao_Click(object sender, EventArgs e)
		{
			if (tbCTe.Text.Length > 0)
			{
				frmCorrecaoCTe form = new frmCorrecaoCTe(_dsoftBd.EmitenteCnpj(cbEmitente.Text).ToString(), tbCTe.Text);

				form.Show();
			}
		}

		private void btEnviar_Click(object sender, EventArgs e)
		{
			Enviar();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btLimparTudo_Click(object sender, EventArgs e)
		{
			Limpar(true);
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btNovo_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btOrdemColeta_Click(object sender, EventArgs e)
		{
			ImprimirOC();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btStatus_Click(object sender, EventArgs e)
		{
			Terminal.VerificaArquivos = !Terminal.VerificaArquivos;

			VerificationStatus();

			//NomeStatusServico = CTeManager.ServicoAtivo();
			//tmStatusServico.Enabled = true;
		}

		private void Cancelar()
		{
			if (tbSituacao.Text == "Aberta")
			{
				if (_dsoftBd.CancelarConhecimento(int.Parse(tbConhecimento.Text)))
				{
					for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
					{
						if (dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString() == tbConhecimento.Text)
						{
							dgvConhecimentos.Rows[i].Cells["situacao"].Value = "C";
							dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
							dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
					}

					tbSituacao.Text = "Cancelada";

					btNovo.Enabled = false;
					btEnviar.Enabled = false;
					btCancelar.Enabled = false;
				}
			}
			else if (tbSituacao.Text == "Gerando" || tbSituacao.Text == "Autorizado para uso CTe")
			{
				if (tbCTe.Text.Length > 0)
				{
					frmCaptura form = new frmCaptura();
					form.Text = "Digite o número do protocolo:";

					if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						CTeManager manager = new CTeManager();
						string cnpj = _dsoftBd.EmitenteCnpj(cbEmitente.Text).ToString("00000000000000");

						if (manager.CancelarCTe200(cnpj, tbCTe.Text, form.Captura.ToString(), "ERRO DE DIGITAÇÃO"))
						{
							if (_dsoftBd.CancelarConhecimento(int.Parse(tbConhecimento.Text)))
							{
								for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
								{
									if (dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString() == tbConhecimento.Text)
									{
										dgvConhecimentos.Rows[i].Cells["situacao"].Value = "C";
										dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
										dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									}
								}

								tbSituacao.Text = "Cancelada";

								btNovo.Enabled = false;
								btEnviar.Enabled = false;
								btCancelar.Enabled = false;
							}
						}
					}
				}
			}
		}

		private void Carregar(int indice)
		{
			ordem = new OrdemDeColeta();

			ordem.Indice = indice;

			if (!_dsoftBd.CarregarOrdemTransporte(ordem))
			{
				return;
			}

			Limpar();

			_dsoftBd.PreencherEmitente(ordem.Emitente);

			cbEmitente.Text = ordem.Emitente.RazaoSocial;

			tbNumColeta.Text = ordem.NumeroColeta;
			tbNumColeta.Enabled = false;

			_dsoftBd.ClienteNome(ordem.Remetente.Codigo, out ordem.Remetente.Nome, out ordem.Remetente.Situacao);

			_dsoftBd.ClienteNome(ordem.Destinatario.Codigo, out ordem.Destinatario.Nome, out ordem.Destinatario.Situacao);

			tbConhecimento.Text = ordem.Indice.ToString();
			dtData.Value = ordem.Data.Date;
			cbRemetente.Text = ordem.Remetente.Nome;
			cbDestinatario.Text = ordem.Destinatario.Nome;

			tbProdPredominante.Text = ordem.ProdudoPredominante;
			tbOutrasCaracteristicas.Text = ordem.OutrasCaracteristicas;
			tbQtd1.Text = ordem.Quantidade[0].ToString();
			tbQtd2.Text = ordem.Quantidade[1].ToString();
			tbQtd3.Text = ordem.Quantidade[2].ToString();
			tbQtd4.Text = ordem.Quantidade[3].ToString();
			tbQtd5.Text = ordem.Quantidade[4].ToString();
			cbUnMed1.Text = ordem.UnidadeMedida[0];
			cbUnMed2.Text = ordem.UnidadeMedida[1];
			cbUnMed3.Text = ordem.UnidadeMedida[2];
			cbUnMed4.Text = ordem.UnidadeMedida[3];
			cbUnMed5.Text = ordem.UnidadeMedida[4];
			tbTipoMed1.Text = ordem.TipoMedida[0];
			tbTipoMed2.Text = ordem.TipoMedida[1];
			tbTipoMed3.Text = ordem.TipoMedida[2];
			tbTipoMed4.Text = ordem.TipoMedida[3];
			tbTipoMed5.Text = ordem.TipoMedida[4];
			tbValorMerc.Text = ordem.ValorMercadoria.ToString("###,###,##0.00");

			mtChave1.Text = ordem.ChaveAcesso[0];
			mtChave2.Text = ordem.ChaveAcesso[1];
			mtChave3.Text = ordem.ChaveAcesso[2];
			mtChave4.Text = ordem.ChaveAcesso[3];
			mtChave5.Text = ordem.ChaveAcesso[4];
			mtChave6.Text = ordem.ChaveAcesso[5];
			cbTipoDoc1.Text = ordem.DocTipo[0];
			cbTipoDoc2.Text = ordem.DocTipo[1];
			cbTipoDoc3.Text = ordem.DocTipo[2];
			cbTipoDoc4.Text = ordem.DocTipo[3];
			cbTipoDoc5.Text = ordem.DocTipo[4];
			cbTipoDoc6.Text = ordem.DocTipo[5];
			tbDocEmi1.Text = ordem.DocEmit[0];
			tbDocEmi2.Text = ordem.DocEmit[1];
			tbDocEmi3.Text = ordem.DocEmit[2];
			tbDocEmi4.Text = ordem.DocEmit[3];
			tbDocEmi5.Text = ordem.DocEmit[4];
			tbDocEmi6.Text = ordem.DocEmit[5];
			tbNota1.Text = ordem.DocNota[0];
			tbNota2.Text = ordem.DocNota[1];
			tbNota3.Text = ordem.DocNota[2];
			tbNota4.Text = ordem.DocNota[3];
			tbNota5.Text = ordem.DocNota[4];
			tbNota6.Text = ordem.DocNota[5];
			tbSerie1.Text = ordem.DocSerie[0];
			tbSerie2.Text = ordem.DocSerie[1];
			tbSerie3.Text = ordem.DocSerie[2];
			tbSerie4.Text = ordem.DocSerie[3];
			tbSerie5.Text = ordem.DocSerie[4];
			tbSerie6.Text = ordem.DocSerie[5];

			if (ordem.CFOP > 0)
				cbCFOP.Text = ordem.CFOP.ToString();

			tbNaturezaOperacao.Text = ordem.NaturezaDaOperacao;
			tbRNTRC.Text = ordem.RNTRC;

			if (ordem.PrevisaoEntrega.Date > DateTime.MinValue)
				dtPrevEntrega.Value = ordem.PrevisaoEntrega.Date;

			tbComp1.Text = ordem.Componente[0];
			tbComp2.Text = ordem.Componente[1];
			tbComp3.Text = ordem.Componente[2];
			tbComp4.Text = ordem.Componente[3];
			tbComp5.Text = ordem.Componente[4];
			tbComp6.Text = ordem.Componente[5];
			tbComp7.Text = ordem.Componente[6];
			tbComp8.Text = ordem.Componente[7];
			tbComp9.Text = ordem.Componente[8];
			tbComp10.Text = ordem.Componente[9];
			tbComp11.Text = ordem.Componente[10];
			tbComp12.Text = ordem.Componente[11];
			tbVal1.Text = ordem.ValorPrestacao[0].ToString("0.00");
			tbVal2.Text = ordem.ValorPrestacao[1].ToString("0.00");
			tbVal3.Text = ordem.ValorPrestacao[2].ToString("0.00");
			tbVal4.Text = ordem.ValorPrestacao[3].ToString("0.00");
			tbVal5.Text = ordem.ValorPrestacao[4].ToString("0.00");
			tbVal6.Text = ordem.ValorPrestacao[5].ToString("0.00");
			tbVal7.Text = ordem.ValorPrestacao[6].ToString("0.00");
			tbVal8.Text = ordem.ValorPrestacao[7].ToString("0.00");
			tbVal9.Text = ordem.ValorPrestacao[8].ToString("0.00");
			tbVal10.Text = ordem.ValorPrestacao[9].ToString("0.00");
			tbVal11.Text = ordem.ValorPrestacao[10].ToString("0.00");
			tbVal12.Text = ordem.ValorPrestacao[11].ToString("0.00");

			tbCST.Text = ordem.CST;

			if (ordem.Origem == string.Empty)
			{
				cbICMSOrig.SelectedIndex = 0;
			}
			else
			{
				
			}

			tbValBC.Text = ordem.ValorBCICMS.ToString("0.00");
			tbAliquotaICMS.Text = ordem.AliquotaICMS.ToString("0.00");
			tbValorICMS.Text = ordem.ValorICMS.ToString("0.00");
			tbRedBC.Text = ordem.RedBCICMS.ToString("0.00");
			tbICMSST.Text = ordem.ICMSST.ToString("0.00");

			tbObs1.Text = ordem.Observacoes[0];
			tbObs2.Text = ordem.Observacoes[1];
			tbObs3.Text = ordem.Observacoes[2];
			tbObs4.Text = ordem.Observacoes[3];
			tbObs5.Text = ordem.Observacoes[4];

			cbMotorista.Text = ordem.Motorista.Nome;
			cbVeiculo.Text = ordem.Veiculo.Placa;

			tbCaracAd.Text = ordem.CaracAd;
			tbCaracSer.Text = ordem.CaracSer;
			tbObsCont.Text = ordem.ObsCont;
			tbObsFisco.Text = ordem.ObsFisco;
			tbObs.Text = ordem.Obs;

			cbEmitente.Enabled = false;
			dtData.Enabled = false;
			cbRemetente.Enabled = false;
			cbDestinatario.Enabled = false;

			rbAPagar.Checked = !(rbPago.Checked = ordem.Pago);

			gbFrete.Enabled = false;
			tbValorFrete.Text = ordem.ValorFrete.ToString("###,###,##0.00");

			tbManifesto.Text = ordem.Manifesto.ToString();
			tbCTe.Text = ordem.CTe;

			switch (ordem.Situacao)
			{
			case 'A':
				tbSituacao.Text = "Aberta";

				btEnviar.Enabled = true;
				btCancelar.Enabled = true;
				btOrdemColeta.Enabled = true;
				break;

			case 'T':
				tbSituacao.Text = "Gerando";

				btNovo.Enabled = false;
				//btEnviar.Text = "&Enviar CTe - F3";
				btEnviar.Enabled = true;
				btCancelar.Enabled = true;
				btOrdemColeta.Enabled = true;
				break;

			case 'E':
				tbSituacao.Text = "Enviando";
				break;

			case 'P':
				tbSituacao.Text = "Processando";
				break;

			case 'C':
				btNovo.Enabled = false;
				btEnviar.Enabled = false;
				btCancelar.Enabled = false;
				tbSituacao.Text = "Cancelada";
				break;

			case 'U':
				//cbCFOP.Enabled = false;
				//tbNaturezaOperacao.Enabled = false;
				//tbRNTRC.Enabled = false;
				//dtPrevEntrega.Enabled = false;
				//tbCST.Enabled = false;
				//tbValBC.Enabled = false;
				//tbAliquotaICMS.Enabled = false;
				//tbValorICMS.Enabled = false;
				//tbProdPredominante.Enabled = false;
				//tbQtd1.Enabled = false;
				//tbTipoMed1.Enabled = false;
				//tbPeso.Enabled = false;
				//tbM3L.Enabled = false;
				//tbNota1.Enabled = false;
				//tbSerie1.Enabled = false;
				//tbValorMerc.Enabled = false;
				//tbValorFrete.Enabled = false;

				btNovo.Enabled = false;
				btEnviar.Enabled = false;
				btImprimir.Enabled = true;
				btCancelar.Enabled = true;

				tbSituacao.Text = "Autorizado para uso CTe";
				break;

			case 'R':
				tbSituacao.Text = "Erro";
				tbMsgErro.Text = _dsoftBd.CTeMensagemErro(indice);
				btOrdemColeta.Enabled = true;
				break;
			}
		}

		private void CarregarClientes()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarClientesNomeCodigo(ds);

			cbRemetente.Items.Clear();
			cbDestinatario.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbRemetente.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
				cbDestinatario.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
			}
		}

		private void CarregarEmitentes()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEmitentes(ds);

			cbEmitente.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				if (ds.Tables[0].Rows[i].ItemArray[16].ToString() == "A")
					cbEmitente.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
			}

			if (cbEmitente.Items.Count > 0)
				cbEmitente.Text = cbEmitente.Items[0].ToString();
		}

		private void CarregarMotoristas()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarMotoristas(ds);

			cbMotorista.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbMotorista.Items.Add(ds.Tables[0].Rows[i].ItemArray[1]);
			}
		}

		private void CarregarVeiculos()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarVeiculos(ds);

			cbVeiculo.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbVeiculo.Items.Add(ds.Tables[0].Rows[i].ItemArray[0]);
			}
		}

		private void cbCFOP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string codigo;
			string texto;

			if (cbCFOP.Text.Length < 1)
				return;

			if (!cbCFOP.Items.Contains(cbCFOP.Text))
				return;

			codigo = cbCFOP.Text.Split(" - ".ToCharArray(), 2)[0];
			texto = cbCFOP.Text.Split(" - ".ToCharArray(), 2)[1];

			cbCFOP.Text = codigo;
			tbNaturezaOperacao.Text = texto.Remove(0, 2);
		}

		private void cbDestinatario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				rbAPagar.Focus();
			}
		}

		private void cbEmitente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtData.Focus();
			}
		}

		private void cbEmitente_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void cbRemetente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbDestinatario.Focus();
			}
		}

		private void Confirmar(bool atualizar = true)
		{
			// Criamos uma nova instância da Ordem de Serviço
			ordem = new OrdemDeColeta();

			ordem.Emitente.RazaoSocial = cbEmitente.Text;

			_dsoftBd.PreencherEmitente(ordem.Emitente);

			ordem.Data = dtData.Value;
			ordem.NumeroColeta = tbNumColeta.Text;

			if (cbRemetente.Text.Length == 0)
			{
				MessageBox.Show("Campo 'remetente' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbRemetente.Focus();

				return;
			}

			if (!cbRemetente.Items.Contains(cbRemetente.Text))
			{
				MessageBox.Show("Campo 'remetente' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbRemetente.Focus();

				return;
			}

			ordem.Remetente.Nome = cbRemetente.Text;

			ordem.Remetente.Codigo = _dsoftBd.ClienteCodigo(ordem.Remetente.Nome);

			if (cbDestinatario.Text.Length == 0)
			{
				MessageBox.Show("Campo 'destinatario' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbDestinatario.Focus();

				return;
			}

			if (!cbDestinatario.Items.Contains(cbDestinatario.Text))
			{
				MessageBox.Show("Campo 'destinatario' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbDestinatario.Focus();

				return;
			}

			ordem.Destinatario.Nome = cbDestinatario.Text;

			ordem.Destinatario.Codigo = _dsoftBd.ClienteCodigo(ordem.Destinatario.Nome);

			ordem.PrevisaoColeta = dtPrevColeta.Value;
			ordem.Pago = rbPago.Checked;

			// Caso seja uma nova Ordem de Coleta
			if (tbConhecimento.Text.Length == 0)
			{
				if ((ordem.Indice = _dsoftBd.NovaOrdemColeta(ordem.Emitente.Cnpj, ordem.Data, ordem.NumeroColeta, ordem.Remetente.Codigo, ordem.Destinatario.Codigo, ordem.PrevisaoColeta, ordem.Pago,
					_usuario.Autorizado)) > 0)
				{
					cbEmitente.Enabled = false;
					dtData.Enabled = false;
					tbNumColeta.Enabled = false;
					cbRemetente.Enabled = false;
					cbDestinatario.Enabled = false;
					dtPrevColeta.Enabled = false;

					tbConhecimento.Text = ordem.Indice.ToString();

					if (MessageBox.Show("Deseja imprimir a Ordem de Coleta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						btOrdemColeta.Enabled = true;

						ImprimirOC();
					}
				}
				else
				{
					return;
				}
			}
			else
			{
				ordem.Indice = int.Parse(tbConhecimento.Text);
			}

			if (TemMercadoriasTransportadas())
			{
				ordem.ProdudoPredominante = tbProdPredominante.Text;
				ordem.OutrasCaracteristicas = tbOutrasCaracteristicas.Text;

				if (tbQtd1.Text.Length > 0)
				{
					if (!double.TryParse(tbQtd1.Text, out ordem.Quantidade[0]))
					{
						MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbQtd1.Focus();
						return;
					}
				}
				else
					ordem.Quantidade[0] = 0;

				if (tbQtd2.Text.Length > 0)
				{
					if (!double.TryParse(tbQtd2.Text, out ordem.Quantidade[1]))
					{
						MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbQtd2.Focus();
						return;
					}
				}
				else
					ordem.Quantidade[1] = 0;

				if (tbQtd3.Text.Length > 0)
				{
					if (!double.TryParse(tbQtd3.Text, out ordem.Quantidade[2]))
					{
						MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbQtd3.Focus();
						return;
					}
				}
				else
					ordem.Quantidade[2] = 0;

				if (tbQtd4.Text.Length > 0)
				{
					if (!double.TryParse(tbQtd4.Text, out ordem.Quantidade[3]))
					{
						MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbQtd4.Focus();
						return;
					}
				}
				else
					ordem.Quantidade[3] = 0;

				if (tbQtd5.Text.Length > 0)
				{
					if (!double.TryParse(tbQtd5.Text, out ordem.Quantidade[4]))
					{
						MessageBox.Show("Campo 'quantidade' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbQtd5.Focus();
						return;
					}
				}
				else
					ordem.Quantidade[4] = 0;

				ordem.UnidadeMedida[0] = cbUnMed1.Text;
				ordem.UnidadeMedida[1] = cbUnMed2.Text;
				ordem.UnidadeMedida[2] = cbUnMed3.Text;
				ordem.UnidadeMedida[3] = cbUnMed4.Text;
				ordem.UnidadeMedida[4] = cbUnMed5.Text;

				ordem.TipoMedida[0] = tbTipoMed1.Text;
				ordem.TipoMedida[1] = tbTipoMed2.Text;
				ordem.TipoMedida[2] = tbTipoMed3.Text;
				ordem.TipoMedida[3] = tbTipoMed4.Text;
				ordem.TipoMedida[4] = tbTipoMed5.Text;

				if (tbValorMerc.Text.Length > 0 && !double.TryParse(tbValorMerc.Text, out ordem.ValorMercadoria))
				{
					MessageBox.Show("Campo 'valor mercadoria' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbValorMerc.Focus();
					return;
				}

				if (!_dsoftBd.OCMercadoriasTransportadas(ordem))
				{
					return;
				}
			}

			if (TemDocumentosOriginarios())
			{
				if (Util.LimpaFormatacao(mtChave1.Text).Length > 0)
					ordem.ChaveAcesso[0] = Util.LimpaFormatacao(mtChave1.Text);

				if (Util.LimpaFormatacao(mtChave2.Text).Length > 0)
					ordem.ChaveAcesso[1] = Util.LimpaFormatacao(mtChave2.Text);

				if (Util.LimpaFormatacao(mtChave3.Text).Length > 0)
					ordem.ChaveAcesso[2] = Util.LimpaFormatacao(mtChave3.Text);

				if (Util.LimpaFormatacao(mtChave4.Text).Length > 0)
					ordem.ChaveAcesso[3] = Util.LimpaFormatacao(mtChave4.Text);

				if (Util.LimpaFormatacao(mtChave5.Text).Length > 0)
					ordem.ChaveAcesso[4] = Util.LimpaFormatacao(mtChave5.Text);

				if (Util.LimpaFormatacao(mtChave6.Text).Length > 0)
					ordem.ChaveAcesso[5] = Util.LimpaFormatacao(mtChave6.Text);

				ordem.DocTipo[0] = cbTipoDoc1.Text;
				ordem.DocTipo[1] = cbTipoDoc2.Text;
				ordem.DocTipo[2] = cbTipoDoc3.Text;
				ordem.DocTipo[3] = cbTipoDoc4.Text;
				ordem.DocTipo[4] = cbTipoDoc5.Text;
				ordem.DocTipo[5] = cbTipoDoc6.Text;

				ordem.DocEmit[0] = tbDocEmi1.Text;
				ordem.DocEmit[1] = tbDocEmi2.Text;
				ordem.DocEmit[2] = tbDocEmi3.Text;
				ordem.DocEmit[3] = tbDocEmi4.Text;
				ordem.DocEmit[4] = tbDocEmi5.Text;
				ordem.DocEmit[5] = tbDocEmi6.Text;

				ordem.DocNota[0] = tbNota1.Text;
				ordem.DocNota[1] = tbNota2.Text;
				ordem.DocNota[2] = tbNota3.Text;
				ordem.DocNota[3] = tbNota4.Text;
				ordem.DocNota[4] = tbNota5.Text;
				ordem.DocNota[5] = tbNota6.Text;

				ordem.DocSerie[0] = tbSerie1.Text;
				ordem.DocSerie[1] = tbSerie2.Text;
				ordem.DocSerie[2] = tbSerie3.Text;
				ordem.DocSerie[3] = tbSerie4.Text;
				ordem.DocSerie[4] = tbSerie5.Text;
				ordem.DocSerie[5] = tbSerie6.Text;

				if (!_dsoftBd.OCDocumentosOriginarios(ordem))
				{
					return;
				}
			}

			if (TemPrestacaoServico())
			{
				if (!cbCFOP.Items.Contains(cbCFOP.Text) && !cbCFOP.Items.Contains(cbCFOP.Text + " - " + tbNaturezaOperacao.Text))
				{
					MessageBox.Show("Campo 'cfop' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbCFOP.Focus();

					return;
				}

				ordem.CFOP = int.Parse(cbCFOP.Text.Split(" - ".ToCharArray(), 2)[0]);

				ordem.NaturezaDaOperacao = tbNaturezaOperacao.Text;

				//if (tbRNTRC.Text.Length != 14)
				//{
				//    MessageBox.Show("Campo 'RNTRC' deve ter exatamente 14 dígitos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//    tbRNTRC.SelectAll();
				//    tbRNTRC.Focus();
				//    return;
				//}

				ordem.RNTRC = tbRNTRC.Text;
				ordem.PrevisaoEntrega = dtPrevEntrega.Value;

				ordem.Componente[0] = tbComp1.Text;
				ordem.Componente[1] = tbComp2.Text;
				ordem.Componente[2] = tbComp3.Text;
				ordem.Componente[3] = tbComp4.Text;
				ordem.Componente[4] = tbComp5.Text;
				ordem.Componente[5] = tbComp6.Text;
				ordem.Componente[6] = tbComp7.Text;
				ordem.Componente[7] = tbComp8.Text;
				ordem.Componente[8] = tbComp9.Text;
				ordem.Componente[9] = tbComp10.Text;
				ordem.Componente[10] = tbComp11.Text;
				ordem.Componente[11] = tbComp12.Text;

				if (tbVal1.Text.Length > 0 && !double.TryParse(tbVal1.Text, out ordem.ValorPrestacao[0]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal1.Focus();
					return;
				}

				if (tbVal2.Text.Length > 0 && !double.TryParse(tbVal2.Text, out ordem.ValorPrestacao[1]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal2.Focus();
					return;
				}

				if (tbVal3.Text.Length > 0 && !double.TryParse(tbVal3.Text, out ordem.ValorPrestacao[2]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal3.Focus();
					return;
				}

				if (tbVal4.Text.Length > 0 && !double.TryParse(tbVal4.Text, out ordem.ValorPrestacao[3]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal4.Focus();
					return;
				}

				if (tbVal5.Text.Length > 0 && !double.TryParse(tbVal5.Text, out ordem.ValorPrestacao[4]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal5.Focus();
					return;
				}

				if (tbVal6.Text.Length > 0 && !double.TryParse(tbVal6.Text, out ordem.ValorPrestacao[5]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal6.Focus();
					return;
				}

				if (tbVal7.Text.Length > 0 && !double.TryParse(tbVal7.Text, out ordem.ValorPrestacao[6]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal7.Focus();
					return;
				}

				if (tbVal8.Text.Length > 0 && !double.TryParse(tbVal8.Text, out ordem.ValorPrestacao[7]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal8.Focus();
					return;
				}

				if (tbVal9.Text.Length > 0 && !double.TryParse(tbVal9.Text, out ordem.ValorPrestacao[8]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal9.Focus();
					return;
				}

				if (tbVal10.Text.Length > 0 && !double.TryParse(tbVal10.Text, out ordem.ValorPrestacao[9]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal10.Focus();
					return;
				}

				if (tbVal11.Text.Length > 0 && !double.TryParse(tbVal11.Text, out ordem.ValorPrestacao[10]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal11.Focus();
					return;
				}

				if (tbVal12.Text.Length > 0 && !double.TryParse(tbVal12.Text, out ordem.ValorPrestacao[11]))
				{
					MessageBox.Show("Campo 'valor da prestação' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbVal12.Focus();
					return;
				}

				if (tbValorFrete.Text.Length > 0 && !double.TryParse(tbValorFrete.Text, out ordem.ValorFrete))
				{
					MessageBox.Show("Campo 'valor frete' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbValorFrete.Focus();
					return;
				}

				if (!_dsoftBd.OCPrestacaoServicos(ordem))
				{
					return;
				}
			}

			if (TemImpostos())
			{
				ordem.CST = tbCST.Text;

				if (cbICMSOrig.Text.Length > 0)
				{
					ordem.Origem = cbICMSOrig.Text[0].ToString();
				}

				if (tbValBC.Text.Length > 0 && !double.TryParse(tbValBC.Text, out ordem.ValorBCICMS))
				{
					MessageBox.Show("Campo 'bc icms' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbValBC.Focus();
					return;
				}

				if (tbAliquotaICMS.Text.Length > 0 && !double.TryParse(tbAliquotaICMS.Text, out ordem.AliquotaICMS))
				{
					MessageBox.Show("Campo 'aliquota icms' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbAliquotaICMS.Focus();
					return;
				}

				if (tbValorICMS.Text.Length > 0 && !double.TryParse(tbValorICMS.Text, out ordem.ValorICMS))
				{
					MessageBox.Show("Campo 'valor icms' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbValorICMS.Focus();
					return;
				}

				if (tbRedBC.Text.Length > 0 && !double.TryParse(tbRedBC.Text, out ordem.RedBCICMS))
				{
					MessageBox.Show("Campo 'red bc' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbRedBC.Focus();
					return;
				}

				if (tbICMSST.Text.Length > 0 && !double.TryParse(tbICMSST.Text, out ordem.ICMSST))
				{
					MessageBox.Show("Campo 'icms st' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbICMSST.Focus();
					return;
				}

				if (!_dsoftBd.OCImpostos(ordem))
				{
					return;
				}
			}

			if (TemOutros())
			{
				if (tbObs1.TextLength > 0)
					ordem.Observacoes[0] = tbObs1.Text;

				if (tbObs2.TextLength > 0)
					ordem.Observacoes[1] = tbObs2.Text;

				if (tbObs3.TextLength > 0)
					ordem.Observacoes[2] = tbObs3.Text;

				if (tbObs4.TextLength > 0)
					ordem.Observacoes[3] = tbObs4.Text;

				if (tbObs5.TextLength > 0)
					ordem.Observacoes[4] = tbObs5.Text;

				if (!_dsoftBd.OCOutros(ordem))
				{
					return;
				}
			}

			if (TemRodoviaria())
			{
				ordem.Motorista.Nome = cbMotorista.Text;

				if (ordem.Motorista.Nome != ""
					&& (ordem.Motorista.Codigo = _dsoftBd.RecursoCodigo(ordem.Motorista.Nome)) == 0)
				{
					MessageBox.Show("Motorista inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbMotorista.SelectAll();
					cbMotorista.Focus();

					return;
				}

				ordem.Veiculo.Placa = cbVeiculo.Text;

				if (ordem.Veiculo.Placa != "" && !_dsoftBd.VeiculoAtivo(ordem.Veiculo.Placa))
				{
					MessageBox.Show("Veículo inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbVeiculo.SelectAll();
					cbVeiculo.Focus();

					return;
				}

				if (!_dsoftBd.OCRodoviaria(ordem))
				{
					return;
				}
			}

			ordem.CaracAd = tbCaracAd.Text;
			ordem.CaracSer = tbCaracSer.Text;
			ordem.ObsCont = tbObsCont.Text;
			ordem.ObsFisco = tbObsFisco.Text;
			ordem.Obs = tbObs.Text;
			_dsoftBd.Compl(ordem);

			if (tbSituacao.Text == "Aberta")
			{

			}
			else if (tbSituacao.Text == "Erro")
			{
				ordem.Situacao = 'R';
			}

			if (ordem.Situacao == 'R')
			{
				if (_dsoftBd.AbrirConhecimento(ordem.Indice))
				{
					for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
					{
						if (dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString() == ordem.Indice.ToString())
						{
							dgvConhecimentos.Rows[i].Cells["situacao"].Value = "A";
							dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.White;
							dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

							return;
						}
					}
				}
			}

			if (atualizar)
			{
				Atualizar();
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			int indice;

			if (dgvConhecimentos.SelectedRows.Count > 0)
			{
				if (int.TryParse(dgvConhecimentos.Rows[dgvConhecimentos.SelectedRows[0].Index].Cells["indice"].Value.ToString(), out indice))
				{
					Carregar(indice);
				}
			}
		}

		private void dtData_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbRemetente.Focus();
			}
		}

		private void Enviar()
		{
			if (btEnviar.Text == "&Gerar CTe - F3")
			{
				GerarCTe();
			}
			else
			{
				EnviarCTe();
			}
		}

		private void EnviarCTe()
		{
		}

		private void frmOrdemServico_Load(object sender, EventArgs e)
		{
			VerificationStatus();

			Atualizar();

			Limpar();

			cbEmitente.Text = cbEmitente.Items[0].ToString();
		}

		private void GerarCTe()
		{
			try
			{
				Confirmar(false);

				_dsoftBd.CarregarEmitente(ordem.Emitente);
				_dsoftBd.CarregarDadosCliente(ordem.Remetente);
				_dsoftBd.CarregarDadosCliente(ordem.Destinatario);
				_dsoftBd.CarregarVeiculo(ordem.Veiculo);

				CTeManager cte = new CTeManager();

				if (cte.GerarCTe(_dsoftBd, ordem, _usuario.Autorizado))
				{
					_dsoftBd.TransmitirOrdemTransporte(ordem);

					tbCTe.Text = ordem.CTe;
					tbSituacao.Text = "Transmitindo";

					//tbProdPredominante.Enabled = false;
					//tbQtd1.Enabled = false;
					//tbTipoMed1.Enabled = false;
					//tbPeso.Enabled = false;
					//tbM3L.Enabled = false;
					//tbNota1.Enabled = false;
					//tbSerie1.Enabled = false;
					//tbValorMerc.Enabled = false;
					//tbValorFrete.Enabled = false;

					btNovo.Enabled = false;
					//btEnviar.Text = "&Enviar CTe - F3";
					btEnviar.Enabled = false;

					/*if (MessageBox.Show("Deseja se conectar ao SEFAZ agora?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
					{
						EnviarCTe();
					}*/

					for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
					{
						if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == ordem.Indice)
						{
							dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Violet;

							break;
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao gerar/transmitir CTe." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Imprimir()
		{
			if (tbCTe.Text.Length > 0)
			{
				if (!CTeManager.ImprimirCTe(tbCTe.Text))
				{
					MessageBox.Show("Não foi possível localizar o arquivo para impressão!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void ImprimirOC()
		{
			if (!btOrdemColeta.Enabled)
				return;

			//relOrdemColeta report = new relOrdemColeta();

			//frmRelatorio form = new frmRelatorio();

			_dsoftBd.CarregarDadosCliente(ordem.Remetente);
			_dsoftBd.CarregarDadosCliente(ordem.Destinatario);

			DemOrdemDeColeta dem = new DemOrdemDeColeta();
			dem.Gerar(ordem, RegrasDeNegocio.Instance.OrdemDeColetaVias);

			//report.ParameterFields["indice"].CurrentValues.AddValue(ordem.Indice);
			//report.ParameterFields["data"].CurrentValues.AddValue(ordem.Data.ToString("dd/MM/yyyy"));
			//report.ParameterFields["remetente_nome"].CurrentValues.AddValue(ordem.Remetente.Nome);
			//report.ParameterFields["remetente_endereco"].CurrentValues.AddValue(ordem.Remetente.Endereco + ", " + ordem.Remetente.Numero);
			//report.ParameterFields["remetente_cnpj"].CurrentValues.AddValue(ordem.Remetente.Documento);
			//report.ParameterFields["remetente_cidade"].CurrentValues.AddValue(ordem.Remetente.Cidade);
			//report.ParameterFields["remetente_insc"].CurrentValues.AddValue(ordem.Remetente.InscricaoEstadual);
			//report.ParameterFields["destinatario_nome"].CurrentValues.AddValue(ordem.Destinatario.Nome);
			//report.ParameterFields["destinatario_cnpj"].CurrentValues.AddValue(ordem.Destinatario.Documento);
			//report.ParameterFields["destinatario_endereco"].CurrentValues.AddValue(ordem.Destinatario.Endereco + ", " + ordem.Destinatario.Numero);
			//report.ParameterFields["destinatario_cidade"].CurrentValues.AddValue(ordem.Destinatario.Cidade);
			//report.ParameterFields["destinatario_insc"].CurrentValues.AddValue(ordem.Destinatario.InscricaoEstadual);
			//report.ParameterFields["consignatario_nome"].CurrentValues.AddValue("");
			//report.ParameterFields["consignatario_endereco"].CurrentValues.AddValue("");
			//report.ParameterFields["conteudo"].CurrentValues.AddValue(ordem.ProdudoPredominante);
			//report.ParameterFields["nota_fiscal"].CurrentValues.AddValue(ordem.DocNota[0]);
			//report.ParameterFields["valor_nota"].CurrentValues.AddValue(ordem.ValorMercadoria.ToString("R$ ###,###,##0.00"));
			//report.ParameterFields["peso"].CurrentValues.AddValue(ordem.Quantidade[1].ToString() + " KG");
			//report.ParameterFields["quantidade"].CurrentValues.AddValue(ordem.Quantidade[0].ToString());
			//report.ParameterFields["especie"].CurrentValues.AddValue(ordem.TipoMedida[0]);
			//report.ParameterFields["marca"].CurrentValues.AddValue(ordem.OutrasCaracteristicas);
			//report.ParameterFields["numero"].CurrentValues.AddValue("");
			//report.ParameterFields["frete_peso"].CurrentValues.AddValue("");
			//report.ParameterFields["frete_valor"].CurrentValues.AddValue(ordem.ValorFrete.ToString("R$ ###,###,##0.00"));
			//report.ParameterFields["cat"].CurrentValues.AddValue("");
			//report.ParameterFields["despacho"].CurrentValues.AddValue("");
			//report.ParameterFields["itr"].CurrentValues.AddValue("");
			//report.ParameterFields["ademe"].CurrentValues.AddValue("");
			//report.ParameterFields["total_prest"].CurrentValues.AddValue(ordem.ValorFrete.ToString("R$ ###,###,##0.00"));
			//report.ParameterFields["observacoes"].CurrentValues.AddValue(ordem.Observacoes[0] + Environment.NewLine + ordem.Observacoes[1]);
			//report.ParameterFields["pago"].CurrentValues.AddValue(ordem.Pago);

			//form.crystalReportViewer1.ReportSource = report;

			//form.Show();
		}

		private void Limpar(bool tudo = true)
		{
			//cbEmitente.Text = string.Empty;
			cbEmitente.Enabled = true;

			dtData.Enabled = true;

			cbRemetente.Text = string.Empty;
			cbRemetente.Enabled = true;
			cbDestinatario.Text = string.Empty;
			cbDestinatario.Enabled = true;

			tbNumColeta.Text = string.Empty;
			tbNumColeta.Enabled = true;

			btOrdemColeta.Enabled = false;

			LimparMercadoriasTransportadas();
			LimparPrestacaoDoServico(tudo);
			LimparDocumentosOriginarios();
			LimparImpostos();
			LimparOutros();

			btNovo.Enabled = true;
			btEnviar.Enabled = false;
			btImprimir.Enabled = false;
			btCancelar.Enabled = false;

			btEnviar.Text = "&Gerar CTe - F3";

			gbFrete.Enabled = true;
			tbValorFrete.Clear();
			tbConhecimento.Clear();
			tbManifesto.Clear();
			tbSituacao.Clear();
			tbCTe.Clear();

			tbMsgErro.Clear();

			dtData.Focus();
		}

		private void LimparDocumentosOriginarios()
		{
			mtChave1.Clear();
			mtChave2.Clear();
			mtChave3.Clear();
			mtChave4.Clear();
			mtChave5.Clear();
			mtChave6.Clear();
			cbTipoDoc1.Text = string.Empty;
			cbTipoDoc2.Text = string.Empty;
			cbTipoDoc3.Text = string.Empty;
			cbTipoDoc4.Text = string.Empty;
			cbTipoDoc5.Text = string.Empty;
			cbTipoDoc6.Text = string.Empty;
			tbDocEmi1.Clear();
			tbDocEmi2.Clear();
			tbDocEmi3.Clear();
			tbDocEmi4.Clear();
			tbDocEmi5.Clear();
			tbDocEmi6.Clear();
			tbNota1.Clear();
			tbNota2.Clear();
			tbNota3.Clear();
			tbNota4.Clear();
			tbNota5.Clear();
			tbNota6.Clear();
			tbSerie1.Clear();
			tbSerie2.Clear();
			tbSerie3.Clear();
			tbSerie4.Clear();
			tbSerie5.Clear();
			tbSerie6.Clear();
		}

		private void LimparImpostos()
		{
			tbCST.Text = "101";
			cbICMSOrig.SelectedIndex = 0;
			tbValBC.Text = "0,00";
			tbAliquotaICMS.Text = "0,00";
			tbValorICMS.Text = "0,00";
			tbRedBC.Text = "0,00";
			tbICMSST.Text = "0,00";
		}

		private void LimparMercadoriasTransportadas()
		{
			tbProdPredominante.Clear();
			tbOutrasCaracteristicas.Clear();
			tbQtd1.Clear();
			tbQtd2.Clear();
			tbQtd3.Clear();
			tbQtd4.Clear();
			tbQtd5.Clear();
			cbUnMed1.SelectedItem = cbUnMed1.Items[0];
			cbUnMed2.SelectedItem = cbUnMed2.Items[1];
			cbUnMed3.SelectedItem = cbUnMed3.Items[2];
			cbUnMed4.SelectedItem = cbUnMed4.Items[3];
			cbUnMed5.SelectedItem = cbUnMed5.Items[4];
			tbTipoMed1.Clear();
			tbTipoMed2.Clear();
			tbTipoMed3.Clear();
			tbTipoMed4.Clear();
			tbTipoMed5.Clear();
			tbValorMerc.Clear();
		}

		private void LimparOutros()
		{
			tbObs1.Clear();
			tbObs2.Clear();
			tbObs3.Clear();
			tbObs4.Clear();
			tbObs5.Clear();
		}

		private void LimparPrestacaoDoServico(bool tudo = true)
		{
			if (tudo)
			{
				cbCFOP.Text = string.Empty;
				tbNaturezaOperacao.Clear();
				tbRNTRC.Clear();
			}

			tbComp1.Text = Preferencias.Componente1;
			tbComp2.Text = Preferencias.Componente2;
			tbComp3.Text = Preferencias.Componente3;
			tbComp4.Text = Preferencias.Componente4;
			tbComp5.Clear();
			tbComp6.Clear();
			tbComp7.Clear();
			tbComp8.Clear();
			tbComp9.Clear();
			tbComp10.Clear();
			tbComp11.Clear();
			tbComp12.Clear();
			tbVal1.Clear();
			tbVal2.Clear();
			tbVal3.Clear();
			tbVal4.Clear();
			tbVal5.Clear();
			tbVal6.Clear();
			tbVal7.Clear();
			tbVal8.Clear();
			tbVal9.Clear();
			tbVal10.Clear();
			tbVal11.Clear();
			tbVal12.Clear();
		}

		private void mtChave5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
		}

		private void rbAPagar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbProdPredominante.Focus();
			}
		}

		private void rbPago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbProdPredominante.Focus();
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

		private void tbEspecie_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.Enter)
			//{
			//    tbPeso.Focus();
			//}
		}

		private void tbM3L_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbNota1.Focus();
			}
		}

		private void tbNatureza_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbOutrasCaracteristicas.Focus();
			}
		}

		private void tbNotaFiscal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbSerie1.Focus();
			}
		}

		private void tbOutrasCaracteristicas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbQtd1.Focus();
			}
		}

		private void tbPeso_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.Enter)
			//{
			//    tbM3L.Focus();
			//}
		}

		private void tbQtd_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTipoMed1.Focus();
			}
		}

		private void tbSerie_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValorMerc.Focus();
			}
		}

		private void tbVal1_Leave(object sender, EventArgs e)
		{
			double v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12;

			if (tbVal1.Text.Length == 0)
			{
				v1 = 0;
			}
			else if (!double.TryParse(tbVal1.Text, out v1))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal1.SelectAll();
				tbVal1.Focus();

				return;
			}

			if (tbVal2.Text.Length == 0)
			{
				v2 = 0;
			}
			else if (!double.TryParse(tbVal2.Text, out v2))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal2.SelectAll();
				tbVal2.Focus();

				return;
			}

			if (tbVal3.Text.Length == 0)
			{
				v3 = 0;
			}
			else if (!double.TryParse(tbVal3.Text, out v3))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal3.SelectAll();
				tbVal3.Focus();

				return;
			}

			if (tbVal4.Text.Length == 0)
			{
				v4 = 0;
			}
			else if (!double.TryParse(tbVal4.Text, out v4))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal4.SelectAll();
				tbVal4.Focus();

				return;
			}

			if (tbVal5.Text.Length == 0)
			{
				v5 = 0;
			}
			else if (!double.TryParse(tbVal5.Text, out v5))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal5.SelectAll();
				tbVal5.Focus();

				return;
			}

			if (tbVal6.Text.Length == 0)
			{
				v6 = 0;
			}
			else if (!double.TryParse(tbVal6.Text, out v6))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal6.SelectAll();
				tbVal6.Focus();

				return;
			}

			if (tbVal7.Text.Length == 0)
			{
				v7 = 0;
			}
			else if (!double.TryParse(tbVal7.Text, out v7))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal7.SelectAll();
				tbVal7.Focus();

				return;
			}

			if (tbVal8.Text.Length == 0)
			{
				v8 = 0;
			}
			else if (!double.TryParse(tbVal8.Text, out v8))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal8.SelectAll();
				tbVal8.Focus();

				return;
			}

			if (tbVal9.Text.Length == 0)
			{
				v9 = 0;
			}
			else if (!double.TryParse(tbVal9.Text, out v9))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal9.SelectAll();
				tbVal9.Focus();

				return;
			}

			if (tbVal10.Text.Length == 0)
			{
				v10 = 0;
			}
			else if (!double.TryParse(tbVal10.Text, out v10))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal10.SelectAll();
				tbVal10.Focus();

				return;
			}

			if (tbVal11.Text.Length == 0)
			{
				v11 = 0;
			}
			else if (!double.TryParse(tbVal11.Text, out v11))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal11.SelectAll();
				tbVal11.Focus();

				return;
			}

			if (tbVal12.Text.Length == 0)
			{
				v12 = 0;
			}
			else if (!double.TryParse(tbVal12.Text, out v12))
			{
				MessageBox.Show("Campo 'valor' inválido! Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbVal12.SelectAll();
				tbVal12.Focus();

				return;
			}

			tbValorFrete.Text = (v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8 + v9 + v10 + v11 + v12).ToString("###,###,##0.00");
		}

		private void tbValorFrete_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btNovo.Focus();
			}
		}

		private void tbValorFrete_Leave(object sender, EventArgs e)
		{
			double valor;

			if (tbValorFrete.Text.Length > 0 && double.TryParse(tbValorFrete.Text, out valor))
			{
				tbValorFrete.Text = valor.ToString("###,###,##0.00");
			}
		}

		private void tbValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValorFrete.Focus();
			}
		}

		private void tbValor_Leave(object sender, EventArgs e)
		{
			double valor;

			if (tbValorMerc.Text.Length > 0 && double.TryParse(tbValorMerc.Text, out valor))
			{
				tbValorMerc.Text = valor.ToString("###,###,##0.00");
			}
		}

		private bool TemDocumentosOriginarios()
		{
			if (Util.LimpaFormatacao(mtChave1.Text).Length > 0 ||
				Util.LimpaFormatacao(mtChave2.Text).Length > 0 ||
				Util.LimpaFormatacao(mtChave3.Text).Length > 0 ||
				Util.LimpaFormatacao(mtChave4.Text).Length > 0 ||
				Util.LimpaFormatacao(mtChave5.Text).Length > 0 ||
				Util.LimpaFormatacao(mtChave6.Text).Length > 0 ||
				cbTipoDoc1.Text.Length > 0 || tbDocEmi1.Text.Length > 0 || tbNota1.Text.Length > 0 || tbSerie1.Text.Length > 0 ||
				cbTipoDoc2.Text.Length > 0 || tbDocEmi2.Text.Length > 0 || tbNota2.Text.Length > 0 || tbSerie2.Text.Length > 0 ||
				cbTipoDoc3.Text.Length > 0 || tbDocEmi3.Text.Length > 0 || tbNota3.Text.Length > 0 || tbSerie3.Text.Length > 0 ||
				cbTipoDoc4.Text.Length > 0 || tbDocEmi4.Text.Length > 0 || tbNota4.Text.Length > 0 || tbSerie4.Text.Length > 0 ||
				cbTipoDoc5.Text.Length > 0 || tbDocEmi5.Text.Length > 0 || tbNota5.Text.Length > 0 || tbSerie5.Text.Length > 0 ||
				cbTipoDoc6.Text.Length > 0 || tbDocEmi6.Text.Length > 0 || tbNota6.Text.Length > 0 || tbSerie6.Text.Length > 0)
				return true;
			else
				return false;
		}

		private bool TemImpostos()
		{
			if (tbCST.Text != "00" ||
				tbValBC.Text != "0.00" ||
				tbAliquotaICMS.Text != "0.00" ||
				tbValorICMS.Text != "0.00" ||
				tbRedBC.Text != "0.00" ||
				tbICMSST.Text != "0.00")
				return true;
			else
				return false;
		}

		private bool TemMercadoriasTransportadas()
		{
			double d;

			if (tbProdPredominante.Text.Length > 0 ||
				tbOutrasCaracteristicas.Text.Length > 0 ||
				(tbQtd1.Text.Length > 0 && double.TryParse(tbQtd1.Text, out d) && d > 0) ||
				(tbQtd2.Text.Length > 0 && double.TryParse(tbQtd2.Text, out d) && d > 0) ||
				(tbQtd3.Text.Length > 0 && double.TryParse(tbQtd3.Text, out d) && d > 0) ||
				(tbQtd4.Text.Length > 0 && double.TryParse(tbQtd4.Text, out d) && d > 0) ||
				(tbQtd5.Text.Length > 0 && double.TryParse(tbQtd5.Text, out d) && d > 0) ||
				tbValorMerc.Text.Length > 0)
				return true;
			else
				return false;
		}

		private bool TemOutros()
		{
			if (tbObs1.Text.Length > 0 ||
				tbObs2.Text.Length > 0 ||
				tbObs3.Text.Length > 0 ||
				tbObs4.Text.Length > 0 ||
				tbObs5.Text.Length > 0)
				return true;
			else
				return false;
		}

		private bool TemPrestacaoServico()
		{
			if (cbCFOP.Text.Length > 0 ||
				tbNaturezaOperacao.Text.Length > 0 ||
				tbRNTRC.Text.Length > 0 ||
				tbComp1.Text.Length > 0 || tbVal1.Text.Length > 0 ||
				tbComp2.Text.Length > 0 || tbVal2.Text.Length > 0 ||
				tbComp3.Text.Length > 0 || tbVal3.Text.Length > 0 ||
				tbComp4.Text.Length > 0 || tbVal4.Text.Length > 0 ||
				tbComp5.Text.Length > 0 || tbVal5.Text.Length > 0 ||
				tbComp6.Text.Length > 0 || tbVal6.Text.Length > 0 ||
				tbComp7.Text.Length > 0 || tbVal7.Text.Length > 0 ||
				tbComp8.Text.Length > 0 || tbVal8.Text.Length > 0 ||
				tbComp9.Text.Length > 0 || tbVal9.Text.Length > 0 ||
				tbComp10.Text.Length > 0 || tbVal10.Text.Length > 0 ||
				tbComp11.Text.Length > 0 || tbVal11.Text.Length > 0 ||
				tbComp12.Text.Length > 0 || tbVal12.Text.Length > 0)
				return true;
			else
				return false;
		}

		private bool TemRodoviaria()
		{
			if (cbMotorista.Text.Length > 0
				|| cbVeiculo.Text.Length > 0)
				return true;
			else
				return false;
		}

		private void tmStatusCTe_Tick(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarOrdensColetaTransmitindo(ds);

			foreach (DataRow d in ds.Tables[0].Rows)
			{
				if (d[1].ToString() == "T") // Se está como Transmitindo, verificamos se o arquivo foi enviado
				{							// E no caso se ter sido criado o lote, marcamos como enviado
					if (!File.Exists(Preferencias.PastaCTe + d[2].ToString() + "-cte.xml") && File.Exists(Preferencias.PastaCteRetorno + d[2].ToString() + "-num-lot.xml"))
					{
						XmlDocument xmlDoc = new XmlDocument();

						xmlDoc.Load(Preferencias.PastaCteRetorno + d[2].ToString() + "-num-lot.xml");

						_dsoftBd.OrdemColetaLote(int.Parse(d[0].ToString()), int.Parse(xmlDoc.FirstChild.NextSibling.InnerText));

						if (_dsoftBd.OrdemColetaEnviada(int.Parse(d[0].ToString())))
						{
							for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
							{
								if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == int.Parse(d[0].ToString()))
								{
									dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Purple;
									dgvConhecimentos.Rows[i].Cells["situacao"].Value = "E";
									dgvConhecimentos.Rows[i].Cells["lote"].Value = xmlDoc.FirstChild.NextSibling.InnerText;
									break;
								}
							}
						}
					}
				}
				else if (d[1].ToString() == "E") // Se enviou, verificamos se tem erro
				{
					// Primeiro verificamos se deu erro
					if (File.Exists(Preferencias.PastaCteRetorno + d[2].ToString() + "-cte.err"))
					{
						string msg = File.ReadAllText(Preferencias.PastaCteRetorno + d[2].ToString() + "-cte.err");

						MessageBox.Show("Erro no envido do arquivo " + d[2].ToString() + Environment.NewLine + msg, this.Text,
							MessageBoxButtons.OK, MessageBoxIcon.Error);

						if (_dsoftBd.OrdemColetaErro(int.Parse(d[0].ToString()), msg))
						{
							for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
							{
								if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == int.Parse(d[0].ToString()))
								{
									dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Black;
									dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
									dgvConhecimentos.Rows[i].Cells["situacao"].Value = "R";

									break;
								}
							}
						}
					}
					else if (d[4].ToString().Length > 0)
					{
						string arq = Preferencias.PastaCteRetorno + int.Parse(d[4].ToString()).ToString("000000000000000") + "-rec.xml"; // Verificamos se o lote foi processado e qual a mensagem
						string arq_err = Preferencias.PastaCteRetorno + int.Parse(d[4].ToString()).ToString("000000000000000") + "-rec.err"; // Verificamos se o lote foi processado e qual a mensagem

						if (File.Exists(arq))
						{
							DataSet ds_lote = new DataSet();

							ds_lote.ReadXmlSchema(Preferencias.SchemaCTe + "retEnviCte_v1.03.xsd");

							ds_lote.ReadXml(Preferencias.PastaCteRetorno + int.Parse(d[4].ToString()).ToString("000000000000000") + "-rec.xml");

							int indice = int.Parse(d[0].ToString());
							string amb = ds_lote.Tables["retEnviCTe"].Rows[0].ItemArray[1].ToString();
							int stat = int.Parse(ds_lote.Tables["retEnviCTe"].Rows[0].ItemArray[4].ToString());
							string motivo = ds_lote.Tables["retEnviCTe"].Rows[0].ItemArray[5].ToString();
							long rec = long.Parse(ds_lote.Tables["infRec"].Rows[0].ItemArray[0].ToString());

							if (_dsoftBd.OrdemColetaLoteRecebido(indice, amb, stat, motivo, rec))
							{
								for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
								{
									if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == int.Parse(d[0].ToString()))
									{
										dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
										dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
										dgvConhecimentos.Rows[i].Cells["situacao"].Value = "P";

										break;
									}
								}
							}
						}
						else if (File.Exists(arq_err))
						{
							XmlDocument xmlDoc = new XmlDocument();

							xmlDoc.Load(Preferencias.PastaCteRetorno + d[2].ToString() + "-num-lot.xml");

							if (_dsoftBd.OrdemColetaLote(int.Parse(d[0].ToString()), int.Parse(xmlDoc.FirstChild.NextSibling.InnerText)))
							{
								for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
								{
									if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == int.Parse(d[0].ToString()))
									{
										dgvConhecimentos.Rows[i].Cells["lote"].Value = xmlDoc.FirstChild.NextSibling.InnerText;

										break;
									}
								}
							}
						}
					}
				}
				else if (d[1].ToString() == "P") // Caso esteja sendo processado
				{
					// Procuramos pelo retorno para ver se já chegou
					string arq = Preferencias.PastaCteEnviadas + "Autorizados/" + DateTime.Now.ToString("yyyyMM") + "/" + d[2].ToString() + "-procCTe.xml";

					if (File.Exists(arq))
					{
						DataSet ds_proc = new DataSet();

						//ds_proc.ReadXmlSchema(Preferencias.SchemaCTe() + "procCTe_v1.03.xsd");

						ds_proc.ReadXml(arq);

						// Verificamos o status do retorno, caso esteja autorizado, marcamos
						if (int.Parse(ds_proc.Tables["infProt"].Rows[0].ItemArray[6].ToString()) == (int)CTe.Status.AutorizadoUsoCTe)
						{
							if (_dsoftBd.OrdemColetaAutorizado(int.Parse(d[0].ToString()), ds_proc.Tables["infProt"].Rows[0].ItemArray[3].ToString(),
								long.Parse(ds_proc.Tables["infProt"].Rows[0].ItemArray[4].ToString()), ds_proc.Tables["infProt"].Rows[0].ItemArray[5].ToString(),
								arq))
							{
								for (int i = dgvConhecimentos.Rows.Count - 1; i >= 0; i--)
								{
									if (int.Parse(dgvConhecimentos.Rows[i].Cells["indice"].Value.ToString()) == int.Parse(d[0].ToString()))
									{
										dgvConhecimentos.Rows[i].Cells["situacao"].Value = "U";
										dgvConhecimentos.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
										dgvConhecimentos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

										break;
									}
								}
							}
						}
					}
				}
				else if (d[1].ToString() == "R") // No caso de erros
				{

				}
			}
		}

		private void tmStatusServico_Tick(object sender, EventArgs e)
		{
			string msg = string.Empty;

			if (CTeManager.VerificarServico(NomeStatusServico, ref msg))
			{
				lbStatus.Text = msg;
				tmStatusServico.Enabled = false;
			}
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			CadClientes form = new CadClientes(_dsoftBd, _usuario, Licenca.Instance);

			form.ShowDialog();

			CarregarClientes();
		}

		private void TotalFrete()
		{
		}

		private void VerificationStatus()
		{
			if (Terminal.VerificaArquivos)
			{
				btStatus.ForeColor = Color.Green;
				btStatus.Text = "Verificação Ativa";
			}
			else
			{
				btStatus.ForeColor = Color.Red;
				btStatus.Text = "Verificação Desativa";
			}
		}

		private void dgvConhecimentos_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				var hit = dgvConhecimentos.HitTest(e.X, e.Y);

				dgvConhecimentos.Rows[hit.RowIndex].Selected = true;

				if (dgvConhecimentos.Rows[hit.RowIndex].Cells["situacao"].Value.ToString() == "T")
				{
					dgvConhecimentos.ContextMenuStrip.Items[0].Enabled = true;
				}
				else
				{
					dgvConhecimentos.ContextMenuStrip.Items[0].Enabled = false;
				}
			}
		}

		private void mitConsulta_Click(object sender, EventArgs e)
		{
			string chave = dgvConhecimentos.SelectedRows[0].Cells["cte"].Value.ToString();

			ConsultarCTe(chave);
		}

		public void ConsultarCTe(string chave)
		{
			CTeManager manager = new CTeManager();
			manager.ConsultarCTe(chave);
		}

		#endregion Methods
	}
}