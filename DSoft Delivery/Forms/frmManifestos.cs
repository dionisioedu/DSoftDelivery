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
using System.IO;

namespace DSoft_Delivery
{
	public partial class frmManifestos : Form
	{
		#region Fields

		private bool Editando = false;
		private Manifesto ManifestoAtual;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmManifestos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Adicionar(int row)
		{
			dataGridView2.Rows.Add();

			for (int i = 0; i < dataGridView2.Columns.Count; i++)
			{
				dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[i].Value = dataGridView1.Rows[row].Cells[i].Value;
			}

			dataGridView1.Rows.Remove(dataGridView1.Rows[row]);

			CalcularTotais();

			btNovo.Enabled = true;
		}

		private void AdicionarTodos()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				dataGridView2.Rows.Add();

				for (int j = 0; j < dataGridView2.Columns.Count; j++)
				{
					dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value;
				}
			}

			for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
			{
				dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
			}

			CalcularTotais();

			btNovo.Enabled = true;
		}

		private void Atualizar()
		{
			CarregarConhecimentos();
			CarregarManifestos();
		}

		private void btAddTodos_Click(object sender, EventArgs e)
		{
			AdicionarTodos();
		}

		private void btAddUm_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
				Adicionar(dataGridView1.SelectedRows[0].Index);
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btChegada_Click(object sender, EventArgs e)
		{
			Chegada();
		}

		private void btGerar_Click(object sender, EventArgs e)
		{
			GerarMDFe();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btLimpar_Click_1(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btNovo_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btRemTodos_Click(object sender, EventArgs e)
		{
			RemoverTodos();
		}

		private void btRemUm_Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0)
				Remover(dataGridView2.SelectedRows[0].Index);
		}

		private void btSaida_Click(object sender, EventArgs e)
		{
			Saida();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click_1(object sender, EventArgs e)
		{
			Sair();
		}

		private void CalcularTotais()
		{
			double total_notas = 0;
			double peso = 0;
			double volume = 0;
			double total_frete = 0;

			for (int i = 0; i < dataGridView2.Rows.Count; i++)
			{
				total_notas += double.Parse(dataGridView2.Rows[i].Cells["valor_mercadoria"].Value.ToString());
				peso += double.Parse(dataGridView2.Rows[i].Cells["peso"].Value.ToString());
				volume += double.Parse(dataGridView2.Rows[i].Cells["m3l"].Value.ToString());
				total_frete += double.Parse(dataGridView2.Rows[i].Cells["valor_frete"].Value.ToString());
			}

			tbQuantidade.Text = dataGridView2.Rows.Count.ToString();
			tbTotalNotas.Text = total_notas.ToString("###,###,##0.00");
			tbPeso.Text = peso.ToString();
			tbVolume.Text = volume.ToString();
			tbTotalFrete.Text = total_frete.ToString("###,###,##0.00");
		}

		private void Cancelar()
		{
			if (dgvManifestos.SelectedRows.Count > 0)
			{
				DataGridViewRow selected = dgvManifestos.SelectedRows[0];

				if (selected.Cells["situacao"].Value.ToString() == "A")
				{
					if (_dsoftBd.CancelarManifesto(Convert.ToInt32(selected.Cells["indice"].Value)))
					{
						selected.DefaultCellStyle.BackColor = Color.Red;
						selected.DefaultCellStyle.ForeColor = Color.White;

						btCancelar.Enabled = false;
					}
				}
			}
		}

		private void CarregarConhecimentos()
		{
			DataSet ds = new DataSet();

			if (!_dsoftBd.CarregarConhecimentos(ds, cbEmitente.Text))
				return;

			// Isso só deve ser feito na primeira vez
			if (dataGridView1.Columns.Count == 0)
			{
				for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
				{
					dataGridView1.Columns.Add(ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].Caption);
				}
			}
			else
			{
				dataGridView1.Rows.Clear();
			}

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				dataGridView1.Rows.Add();

				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					dataGridView1.Rows[i].Cells[j].Value = ds.Tables[0].Rows[i].ItemArray[j];
				}
			}

			//dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["indice"].HeaderText = "CTRL";
			dataGridView1.Columns["indice"].Width = 40;
			dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["abertura_data"].HeaderText = "Data";
			dataGridView1.Columns["abertura_data"].Width = 60;
			dataGridView1.Columns["abertura_data"].DefaultCellStyle.Format = "dd/MM/yy";
			dataGridView1.Columns["remetente"].HeaderText = "Remetente";
			dataGridView1.Columns["destinatario"].HeaderText = "Destinatario";
			dataGridView1.Columns["nota_fiscal"].HeaderText = "Nota Fiscal";
			dataGridView1.Columns["nota_fiscal"].Width = 90;
			dataGridView1.Columns["valor_mercadoria"].HeaderText = "Valor Notas";
			dataGridView1.Columns["valor_mercadoria"].Width = 90;
			dataGridView1.Columns["valor_mercadoria"].DefaultCellStyle.Format = "###,###,##0.00";
			dataGridView1.Columns["valor_mercadoria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["peso"].HeaderText = "Peso";
			dataGridView1.Columns["peso"].Width = 60;
			dataGridView1.Columns["peso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["m3l"].HeaderText = "Volume";
			dataGridView1.Columns["m3l"].Width = 60;
			dataGridView1.Columns["m3l"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["valor_frete"].HeaderText = "Valor Frete";
			dataGridView1.Columns["valor_frete"].Width = 90;
			dataGridView1.Columns["valor_frete"].DefaultCellStyle.Format = "###,###,##0.00";
			dataGridView1.Columns["valor_frete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			// Isso só deve ser feito na primeira vez
			if (dataGridView2.Columns.Count == 0)
			{
				for (int i = 0; i < dataGridView1.Columns.Count; i++)
				{
					dataGridView2.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText);

					dataGridView2.Columns[i].Width = dataGridView1.Columns[i].Width;
					dataGridView2.Columns[i].DefaultCellStyle.Alignment = dataGridView1.Columns[i].DefaultCellStyle.Alignment;
					dataGridView2.Columns[i].DefaultCellStyle.Format = dataGridView1.Columns[i].DefaultCellStyle.Format;
				}
			}
			else
			{
				dataGridView2.Rows.Clear();
			}
		}

		private void CarregarConhecimentos(int manifesto)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarConhecimentos(ds, cbEmitente.Text);

			// Isso só deve ser feito na primeira vez
			if (dataGridView1.Columns.Count == 0)
			{
				for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
				{
					dataGridView1.Columns.Add(ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].Caption);
				}
			}
			else
			{
				dataGridView1.Rows.Clear();
			}

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				dataGridView1.Rows.Add();

				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					dataGridView1.Rows[i].Cells[j].Value = ds.Tables[0].Rows[i].ItemArray[j];
				}
			}

			//dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["indice"].HeaderText = "CTRL";
			dataGridView1.Columns["indice"].Width = 40;
			dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["abertura_data"].HeaderText = "Data";
			dataGridView1.Columns["abertura_data"].Width = 60;
			dataGridView1.Columns["abertura_data"].DefaultCellStyle.Format = "dd/MM/yy";
			dataGridView1.Columns["remetente"].HeaderText = "Remetente";
			dataGridView1.Columns["destinatario"].HeaderText = "Destinatario";

			// Isso só deve ser feito na primeira vez
			if (dataGridView2.Columns.Count == 0)
			{
				for (int i = 0; i < dataGridView1.Columns.Count; i++)
				{
					dataGridView2.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText);

					dataGridView2.Columns[i].Width = dataGridView1.Columns[i].Width;
					dataGridView2.Columns[i].DefaultCellStyle.Alignment = dataGridView1.Columns[i].DefaultCellStyle.Alignment;
					dataGridView2.Columns[i].DefaultCellStyle.Format = dataGridView1.Columns[i].DefaultCellStyle.Format;
				}
			}
			else
			{
				dataGridView2.Rows.Clear();
			}

			ds.Clear();

			_dsoftBd.CarregarConhecimentos(ds, manifesto);

			ManifestoAtual.Conhecimentos = ds.Tables[0];

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				dataGridView2.Rows.Add();

				for (int j = 0; j < dataGridView2.Columns.Count; j++)
				{
					dataGridView2.Rows[i].Cells[j].Value = ds.Tables[0].Rows[i].ItemArray[j];
				}
			}
		}

		private void CarregarEmitentes()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEmitentes(ds);

			cbEmitente.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				if (ds.Tables[0].Rows[i].ItemArray[16].ToString() != "C")
					cbEmitente.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
			}

			cbEmitente.Text = cbEmitente.Items[0].ToString();
		}

		private void CarregarManifesto(int indice)
		{
			ManifestoAtual = new Manifesto();

			ManifestoAtual.Indice = indice;

			if (!_dsoftBd.CarregarManifesto(ManifestoAtual))
				return;

			ManifestoAtual.Emitente.RazaoSocial = _dsoftBd.EmitenteRazaoSocial(ManifestoAtual.Emitente.Cnpj);
			_dsoftBd.CarregarEmitente(ManifestoAtual.Emitente);

			_dsoftBd.CarregarRecurso(ManifestoAtual.Motorista);
			_dsoftBd.CarregarVeiculo(ManifestoAtual.Veiculo);

			if (ManifestoAtual.Carreta.Placa != "")
			{
				_dsoftBd.CarregarVeiculo(ManifestoAtual.Carreta);
			}

			cbEmitente.Text = _dsoftBd.EmitenteRazaoSocial(ManifestoAtual.Emitente.Cnpj);
			tbIndice.Text = indice.ToString();
			dtData.Value = ManifestoAtual.Data;
			cbMotorista.Text = _dsoftBd.RecursoNome(ManifestoAtual.Motorista.Codigo);
			cbVeiculo.Text = ManifestoAtual.Veiculo.Placa;
			cbCarreta.Text = ManifestoAtual.Carreta.Placa;

			tbRNTRC.Text = ManifestoAtual.RNTRC;
			tbCIOT.Text = ManifestoAtual.CIOT;

			cbUFEntrega.Text = ManifestoAtual.UFEntrega;
			cbMunEntrega.Text = ManifestoAtual.MunEntrega;

			cbEmitente.Enabled = false;

			switch (ManifestoAtual.Situacao)
			{
			case 'A':
				btNovo.Enabled = true;
				btSaida.Enabled = true;
				btImprimir.Enabled = true;
				btCancelar.Enabled = true;
				btGerar.Enabled = true;
				break;

			case 'C':
				btCancelar.Enabled = false;
				break;

			case 'E':
				btChegada.Text = "Voltar";
				btChegada.Enabled = true;
				btImprimir.Enabled = true;
				break;

			case 'S':
				btSaida.Text = "Voltar";
				btSaida.Enabled = true;
				btChegada.Enabled = true;
				btImprimir.Enabled = true;
				break;
			}

			if (!string.IsNullOrEmpty(ManifestoAtual.Arquivo))
			{
				btImprimirMDFe.Visible = true;
			}
			else
			{
				btImprimirMDFe.Visible = false;
			}

			CarregarConhecimentos(indice);
		}

		private void CarregarManifestos()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarManifestos(ds);

			dgvManifestos.DataSource = ds.Tables[0];

			dgvManifestos.Columns["indice"].HeaderText = "Indice";
			dgvManifestos.Columns["indice"].Width = 60;
			dgvManifestos.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["montagem_data"].HeaderText = "Montagem";
			dgvManifestos.Columns["montagem_data"].Width = 60;
			dgvManifestos.Columns["montagem_data"].DefaultCellStyle.Format = "dd/MM/yy";
			dgvManifestos.Columns["montagem_hora"].HeaderText = "Hora";
			dgvManifestos.Columns["montagem_hora"].Width = 60;
			dgvManifestos.Columns["montagem_hora"].DefaultCellStyle.Format = "hh:mm:ss";
			dgvManifestos.Columns["saida_data"].HeaderText = "Saida";
			dgvManifestos.Columns["saida_data"].Width = 60;
			dgvManifestos.Columns["saida_data"].DefaultCellStyle.Format = "dd/MM/yy";
			dgvManifestos.Columns["saida_hora"].HeaderText = "Hora";
			dgvManifestos.Columns["saida_hora"].Width = 60;
			dgvManifestos.Columns["saida_hora"].DefaultCellStyle.Format = "hh:mm:ss";
			dgvManifestos.Columns["chegada_data"].HeaderText = "Chegada";
			dgvManifestos.Columns["chegada_data"].Width = 60;
			dgvManifestos.Columns["chegada_data"].DefaultCellStyle.Format = "dd/MM/yy";
			dgvManifestos.Columns["chegada_hora"].HeaderText = "Hora";
			dgvManifestos.Columns["chegada_hora"].Width = 60;
			dgvManifestos.Columns["chegada_hora"].DefaultCellStyle.Format = "hh:mm:ss";
			dgvManifestos.Columns["usuario"].HeaderText = "Usuário";
			dgvManifestos.Columns["usuario"].Width = 90;
			dgvManifestos.Columns["emitente"].HeaderText = "Emitente";
			dgvManifestos.Columns["emitente"].Width = 120;
			dgvManifestos.Columns["motorista"].HeaderText = "Motorista";
			dgvManifestos.Columns["motorista"].Width = 120;
			dgvManifestos.Columns["veiculo"].HeaderText = "Veículo";
			dgvManifestos.Columns["veiculo"].Width = 90;
			dgvManifestos.Columns["carreta"].HeaderText = "Carreta";
			dgvManifestos.Columns["carreta"].Width = 90;
			dgvManifestos.Columns["situacao"].HeaderText = "Situação";
			dgvManifestos.Columns["situacao"].Width = 45;
			dgvManifestos.Columns["itens"].HeaderText = "Itens";
			dgvManifestos.Columns["itens"].Width = 60;
			dgvManifestos.Columns["itens"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["valor_total"].HeaderText = "Valor Notas";
			dgvManifestos.Columns["valor_total"].Width = 90;
			dgvManifestos.Columns["valor_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["valor_total"].DefaultCellStyle.Format = "###,###,##0.00";
			dgvManifestos.Columns["peso_total"].HeaderText = "Peso";
			dgvManifestos.Columns["peso_total"].Width = 60;
			dgvManifestos.Columns["peso_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["volume_total"].HeaderText = "Volume";
			dgvManifestos.Columns["volume_total"].Width = 60;
			dgvManifestos.Columns["volume_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["frete_total"].HeaderText = "Frete";
			dgvManifestos.Columns["frete_total"].Width = 90;
			dgvManifestos.Columns["frete_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvManifestos.Columns["frete_total"].DefaultCellStyle.Format = "###,###,##0.00";

			tabPage2.Show();
			dgvManifestos.Refresh();

			Util.Pintar(ref dgvManifestos);

			if (dgvManifestos.Rows.Count > 0)
				dgvManifestos.FirstDisplayedScrollingRowIndex = dgvManifestos.Rows.Count - 1;
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
			cbCarreta.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbVeiculo.Items.Add(ds.Tables[0].Rows[i].ItemArray[0]);
				cbCarreta.Items.Add(ds.Tables[0].Rows[i].ItemArray[0]);
			}
		}

		private void Chegada()
		{
			if (btChegada.Text == "Chegada")
			{
				MDFe.MDFeManager manager = new MDFe.MDFeManager();

				//Manifesto manifesto = new Manifesto();

				//manifesto.Indice = int.Parse(tbIndice.Text);

				//if (_dsoftBd.CarregarManifesto(manifesto))
				//{
				if (ManifestoAtual != null)
				{
					if (manager.EncerrarManifesto(ManifestoAtual, DateTime.Now))
					{
						if (_dsoftBd.EntregarManifesto(ManifestoAtual.Indice))
						{
							Limpar();
						}
					}
				}
				//}
			}
			else
			{
				if (_dsoftBd.RetornarManifesto(int.Parse(tbIndice.Text)))
				{
					Limpar();
				}
			}
		}

		private void Confirmar()
		{
			Manifesto manifesto = ManifestoAtual;

			if (cbEmitente.Text.Length == 0)
			{
				MessageBox.Show("Selecione um emitente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbEmitente.Focus();

				return;
			}

			if (manifesto == null)
			{
				manifesto = new Manifesto();
			}

			manifesto.Emitente.RazaoSocial = cbEmitente.Text;

			if (!_dsoftBd.CarregarEmitente(manifesto.Emitente))
			{
				MessageBox.Show("Emitente inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbEmitente.SelectAll();
				cbEmitente.Focus();

				return;
			}

			manifesto.Data = dtData.Value;

			if (cbMotorista.Text.Length == 0)
			{
				MessageBox.Show("Selecione um motorista.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbMotorista.Focus();

				return;
			}

			manifesto.Motorista.Nome = cbMotorista.Text;

			if ((manifesto.Motorista.Codigo = _dsoftBd.RecursoCodigo(manifesto.Motorista.Nome)) == 0)
			{
				MessageBox.Show("Motorista inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbMotorista.SelectAll();
				cbMotorista.Focus();

				return;
			}

			if (cbVeiculo.Text.Length == 0)
			{
				MessageBox.Show("Selecione um veículo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbVeiculo.Focus();

				return;
			}

			manifesto.Veiculo.Placa = cbVeiculo.Text;

			if (!_dsoftBd.VeiculoAtivo(manifesto.Veiculo.Placa))
			{
				MessageBox.Show("Veículo inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbVeiculo.SelectAll();
				cbVeiculo.Focus();

				return;
			}

			if (cbCarreta.Text.Length > 0)
			{
				if (!_dsoftBd.VeiculoAtivo(cbCarreta.Text))
				{
					MessageBox.Show("Veículo inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbCarreta.SelectAll();
					cbCarreta.Focus();

					return;
				}

				manifesto.Carreta.Placa = cbCarreta.Text;
			}

			manifesto.RNTRC = tbRNTRC.Text;
			manifesto.CIOT = tbCIOT.Text;

			manifesto.UFEntrega = cbUFEntrega.Text.Substring(0, 2);
			manifesto.MunEntrega = cbMunEntrega.Text;

			if (dataGridView2.Rows.Count == 0)
			{
				MessageBox.Show("Selecione pelo menos um conhecimento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				return;
			}

			if (MessageBox.Show("Confirma gravação do manifesto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			if (tbIndice.Text.Length == 0)
			{
				if (_dsoftBd.NovoManifesto(manifesto))
				{
					for (int i = 0; i < dataGridView2.Rows.Count; i++)
					{
						int conhecimento = int.Parse(dataGridView2.Rows[i].Cells["indice"].Value.ToString());

						_dsoftBd.VincularConhecimentoManifesto(conhecimento, manifesto.Indice, dtData.Value);
					}

					Limpar();
				}
			}
			else
			{
				_dsoftBd.AlterarManifesto(manifesto);

				if (_dsoftBd.LimparManifesto(int.Parse(tbIndice.Text)))
				{
					for (int i = 0; i < dataGridView2.Rows.Count; i++)
					{
						int conhecimento = int.Parse(dataGridView2.Rows[i].Cells["indice"].Value.ToString());

						_dsoftBd.VincularConhecimentoManifesto(conhecimento, int.Parse(tbIndice.Text), dtData.Value);
					}

					Limpar();
				}
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
				Adicionar(dataGridView1.SelectedRows[0].Index);
		}

		private void dataGridView3_DoubleClick(object sender, EventArgs e)
		{
			if (dgvManifestos.SelectedRows.Count == 0)
				return;

			CarregarManifesto(int.Parse(dgvManifestos.Rows[dgvManifestos.SelectedRows[0].Index].Cells["indice"].Value.ToString()));
		}

		private void frmManifestos_Load(object sender, EventArgs e)
		{
			CarregarEmitentes();
			CarregarMotoristas();
			CarregarVeiculos();
			CarregarUF();

			Limpar();
		}

		private void CarregarUF()
		{
			cbUFEntrega.Items.Clear();

			DataSet ds = new DataSet();

			_dsoftBd.CarregarEstados(ds);

			string[] ufs = new string[ds.Tables[0].Rows.Count];

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				ufs[i] = ds.Tables[0].Rows[i][0] + " - " + ds.Tables[0].Rows[i][1];
			}

			cbUFEntrega.Items.AddRange(ufs);
		}

		private void CarregarMunicipios(string uf)
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarMunicipios(ds, uf);

			cbMunEntrega.Items.Clear();

			string[] municipios = new string[ds.Tables[0].Rows.Count];

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				municipios[i] = ds.Tables[0].Rows[i]["nome"].ToString();
			}

			cbMunEntrega.Items.AddRange(municipios);
		}

		private void GerarMDFe()
		{
			Confirmar();

			Manifesto manifesto = ManifestoAtual;

			_dsoftBd.CarregarManifesto(manifesto);

			Emitente emitente = _dsoftBd.CarregarEmitente(manifesto.Emitente.Cnpj);
			manifesto.Emitente = emitente;

			Recurso motorista = new Recurso();
			motorista.Codigo = manifesto.Motorista.Codigo;
			_dsoftBd.CarregarRecurso(motorista);
			manifesto.Motorista = motorista;

			Veiculo principal = new Veiculo();
			principal.Placa = manifesto.Veiculo.Placa;
			_dsoftBd.CarregarVeiculo(principal);
			manifesto.Veiculo = principal;

			Veiculo carreta = new Veiculo();
			carreta.Placa = manifesto.Carreta.Placa;
			_dsoftBd.CarregarVeiculo(carreta);
			manifesto.Carreta = carreta;

			DataSet ds = new DataSet();

			_dsoftBd.CarregarConhecimentos(ds, manifesto.Indice);

			DataTable rows = ds.Tables[0];

			for (int i = 0; i < rows.Rows.Count; i++)
			{
				OrdemDeColeta ordem = new OrdemDeColeta();
				ordem.Indice = Convert.ToInt32(rows.Rows[i]["indice"]);
				ordem.MunicipioDestino = rows.Rows[i]["destino"].ToString();
				ordem.EstadoDestino = rows.Rows[i]["destino_uf"].ToString();
				ordem.CTe = rows.Rows[i]["cte"].ToString();
				ordem.ValorMercadoria = Convert.ToDouble(rows.Rows[i]["valor_mercadoria"]);
				ordem.Peso = Convert.ToDouble(rows.Rows[i]["peso"]);

				manifesto.OrdemDeColeta.Add(ordem);
			}

			MDFe.MDFeManager mdfe = new MDFe.MDFeManager();

			if (mdfe.Gerar(_dsoftBd, manifesto))
			{
				_dsoftBd.AlterarManifesto(manifesto);

				Saida();
			}
		}

		private void Imprimir()
		{
			if (tbIndice.Text.Length == 0)
			{
				return;
			}

			if (cbEmitente.Text.Length < 1)
			{
				MessageBox.Show("Emitente inválido!", Text);
				cbEmitente.Focus();
				return;
			}

			Relatorios.ManifestoDeTransporte relatorio = new Relatorios.ManifestoDeTransporte();

			relatorio.Gerar(ManifestoAtual);
		}

		private void Limpar()
		{
			Editando = false;

			cbEmitente.Enabled = true;
			dtData.Enabled = true;
			cbMotorista.Enabled = true;
			cbVeiculo.Enabled = true;
			cbCarreta.Enabled = true;
			tbRNTRC.Enabled = true;
			tbCIOT.Enabled = true;

			tbIndice.Clear();
			tbRNTRC.Clear();
			tbCIOT.Clear();

			cbUFEntrega.SelectedItem = null;
			cbMunEntrega.SelectedItem = null;

			btNovo.Enabled = false;

			btGerar.Enabled = false;

			btSaida.Enabled = false;
			btChegada.Enabled = false;
			btImprimir.Enabled = false;
			btCancelar.Enabled = false;

			btSaida.Text = "Saída";
			btChegada.Text = "Chegada";
			btImprimir.Text = "Imprimir";
			btCancelar.Text = "Cancelar";

			Atualizar();
			CalcularTotais();
		}

		private void Remover(int row)
		{
			dataGridView1.Rows.Add();

			for (int i = 0; i < dataGridView1.Columns.Count; i++)
			{
				dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Value = dataGridView2.Rows[row].Cells[i].Value;
			}

			dataGridView2.Rows.Remove(dataGridView2.Rows[row]);

			CalcularTotais();

			btNovo.Enabled = true;
		}

		private void RemoverTodos()
		{
			for (int i = 0; i < dataGridView2.Rows.Count; i++)
			{
				dataGridView1.Rows.Add();

				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j].Value = dataGridView2.Rows[i].Cells[j].Value;
				}
			}

			for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
			{
				dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
			}

			CalcularTotais();

			btNovo.Enabled = true;
		}

		private void Saida()
		{
			if (btSaida.Text == "Saída")
			{
				if (_dsoftBd.SaidaManifesto(ManifestoAtual.Indice))
				{
					Limpar();
				}
			}
			else
			{
				if (_dsoftBd.RetornarManifesto(ManifestoAtual.Indice))
				{
					Limpar();
				}
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

		private void cbUFEntrega_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbUFEntrega.SelectedItem == null)
			{
				cbMunEntrega.Items.Clear();
				return;
			}

			CarregarMunicipios(cbUFEntrega.SelectedItem.ToString().Substring(0, 2));
		}

		private void btImprimirMDFe_Click(object sender, EventArgs e)
		{
			if (ManifestoAtual != null)
			{
				if (!string.IsNullOrEmpty(ManifestoAtual.Arquivo))
				{
					if (!File.Exists(ManifestoAtual.Arquivo))
					{
						MessageBox.Show(string.Format("O arquivo não se encontra no destino! ({0})", ManifestoAtual.Arquivo));
						return;
					}
					else
					{
						System.Diagnostics.Process.Start(ManifestoAtual.Arquivo);
					}
				}
			}
		}

		#endregion Methods
	}
}