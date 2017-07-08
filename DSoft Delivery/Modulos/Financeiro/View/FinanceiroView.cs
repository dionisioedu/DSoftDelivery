using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSoftCore;
using DSoftBd;
using DSoftModels;

namespace DSoft_Delivery.Financeiro
{
	public partial class FinanceiroView : Form, IFinanceiroView
	{
		#region Fields

		public List<string> ListaClientes;
		public List<Recurso> ListaRecursos;

		private string Conteudo;
		private DataSet DataSet = null;
		private FinanceiroModel Model;
		private FinanceiroPresenter Presenter;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public FinanceiroView(Bd bd, Usuario usuario)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			Model = new FinanceiroModel();
			Presenter = new FinanceiroPresenter(bd, usuario, Model, this);

			InitializeComponent();

			this.FormClosing += new FormClosingEventHandler(frmFinanceiro_FormClosing);

			dataGridView1.UseWaitCursor = true;
			dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);

			cbTipo.SelectedValueChanged += new EventHandler(cbTipo_SelectedValueChanged);
			cbCodigo.SelectedValueChanged += new EventHandler(cbCodigo_SelectedValueChanged);
			cbForma.SelectedValueChanged += new EventHandler(cbForma_SelectedValueChanged);

			Initialize.Invoke(this, null);

			Conteudo = string.Empty;
		}

		public FinanceiroView(Bd bd, Usuario usuario, long cliente, decimal valor)
		{
			_dsoftBd = bd;
			_usuario = usuario;

			Model = new FinanceiroModel();
			Presenter = new FinanceiroPresenter(bd, usuario, Model, this);

			InitializeComponent();

			this.FormClosing += new FormClosingEventHandler(frmFinanceiro_FormClosing);

			dataGridView1.UseWaitCursor = true;
			dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);

			cbTipo.SelectedValueChanged += new EventHandler(cbTipo_SelectedValueChanged);
			cbCodigo.SelectedValueChanged += new EventHandler(cbCodigo_SelectedValueChanged);
			cbForma.SelectedValueChanged += new EventHandler(cbForma_SelectedValueChanged);

			Initialize.Invoke(this, null);

			Conteudo = string.Empty;

			Presenter.LancarEntrada(cliente, valor);
		}

		#endregion Constructors

		#region Delegates

		delegate void UpdaterDelegate();

		#endregion Delegates

		#region Events

		public event EventHandler Cancelar;

		public event EventHandler Initialize;

		public event EventHandler Novo;

		#endregion Events

		#region Methods

		public DateTime LerData()
		{
			return dtData.Value;
		}

		public string LerObservacoes()
		{
			return tbObservacao.Text;
		}

		public string LerValor()
		{
			return tbValor.Text;
		}

		public void LimparDados()
		{
			btNovo.Text = "&Novo - F2";
			btCancelar.Text = "&Cancelar - F4";

			cbTipo.Enabled = true;
			cbTipo.SelectedItem = null;
			cbCodigo.SelectedItem = null;
			cbForma.SelectedItem = null;

			lbNome.Text = string.Empty;
			lbCodigo.Text = string.Empty;
			tbValor.Clear();
			tbObservacao.Clear();
			dtData.Value = DateTime.Now;

			groupBox1.Enabled = false;

			btCancelar.Enabled = false;

			GC.Collect();
		}

		public void NovoLancamento()
		{
			btNovo.Text = "&Confirmar - F2";

			groupBox1.Enabled = true;
			cbTipo.Focus();
		}

		public void PreencherClientes(DataSet ds)
		{
			this.Invoke(new UpdaterDelegate(() =>
				{
					ListaClientes = new List<string>();

					foreach (DataRow r in ds.Tables[0].Rows)
					{
						ListaClientes.Add(r.ItemArray[1].ToString() + " - " + r.ItemArray[0].ToString());
					}

					foreach (DataRow r in ds.Tables[0].Rows)
					{
						ListaClientes.Add(r.ItemArray[0].ToString());
					}
				}));
		}

		public void PreencherFormasDePagamento(List<FormaDePagamento> formas)
		{
			this.Invoke(new UpdaterDelegate(() =>
			{
				cbForma.Items.Clear();

				foreach (FormaDePagamento forma in formas)
				{
					if (forma.Ativo)
					{
						cbForma.Items.Add(forma);
					}
				}
			}));
		}

		public void PreencherLancarEntrada(long cliente, decimal valor)
		{
			this.Invoke(new Action(() =>
				{
					btNovo.Text = "Confirmar - F2";
					groupBox1.Enabled = true;
					cbTipo.SelectedIndex = 0;
					cbCodigo.SelectedIndex = cbCodigo.FindString(cliente.ToString() + " - ", 0);
					tbValor.Text = valor.ToString("##,###,##0.00");
					cbForma.Focus();
				}));
		}

		public void PreencherRecursos(List<Recurso> recursos)
		{
			this.Invoke(new UpdaterDelegate(() =>
				{
					ListaRecursos = recursos;
				}));
		}

		public void SetDataSource(DataSet ds)
		{
			DataSet = ds;

			this.Invoke(new UpdaterDelegate(() => { Atualizar(); }));
		}

		private void Atualizar()
		{
			try
			{
				if (DataSet == null)
					return;

				dataGridView1.DataSource = DataSet.Tables[0];

				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";

				dataGridView1.Columns["indice"].Width = 50;
				dataGridView1.Columns["indice"].HeaderText = "Índice";
				dataGridView1.Columns["data"].Width = 70;
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["hora"].Width = 70;
				dataGridView1.Columns["hora"].HeaderText = "Hora";
				dataGridView1.Columns["tipo"].Width = 42;
				dataGridView1.Columns["tipo"].HeaderText = "Tipo";
				dataGridView1.Columns["caixa"].Visible = false;
				dataGridView1.Columns["descricao"].Width = 180;
				dataGridView1.Columns["descricao"].HeaderText = "Caixa";
				dataGridView1.Columns["situacao"].Width = 42;
				dataGridView1.Columns["situacao"].HeaderText = "Sit.";

				//Task.Factory.StartNew(new Action(Pintar));

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
				}

				dataGridView1.UseWaitCursor = false;
				progressBar1.Visible = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button1_Click_2(object sender, EventArgs e)
		{
			Presenter.EmitirComprovante();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			Cancela();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancela()
		{
			if (!btCancelar.Enabled)
				return;

			Cancelar.Invoke(btCancelar, null);
		}

		private void CancelamentoCrediario()
		{
			frmCancCrediario form = new frmCancCrediario(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void CarregarRegistro(int r)
		{
			FinanceiroModel model = new FinanceiroModel();

			model.Indice = Convert.ToInt32(dataGridView1.Rows[r].Cells["indice"].Value);
			model.Tipo = dataGridView1.Rows[r].Cells["tipo"].Value.ToString()[0];

			if (dataGridView1.Rows[r].Cells["cliente"].Value.ToString().Length > 0)
			{
				model.Codigo = Convert.ToInt64(dataGridView1.Rows[r].Cells["cliente"].Value);
			}
			else if (dataGridView1.Rows[r].Cells["recurso"].Value.ToString().Length > 0)
			{
				model.Codigo = Convert.ToInt64(dataGridView1.Rows[r].Cells["recurso"].Value);
			}

			if (dataGridView1.Rows[r].Cells["nome_cliente"].Value.ToString().Length > 0)
			{
				model.Nome = dataGridView1.Rows[r].Cells["nome_cliente"].Value.ToString();
			}
			else if (dataGridView1.Rows[r].Cells["nome_recurso"].Value.ToString().Length > 0)
			{
				model.Nome = dataGridView1.Rows[r].Cells["nome_recurso"].Value.ToString();
			}

			if (dataGridView1.Rows[r].Cells["forma"].Value.ToString().Length > 0)
			{
				model.Forma = dataGridView1.Rows[r].Cells["forma"].Value.ToString()[0];
			}

			model.Situacao = dataGridView1.Rows[r].Cells["situacao"].Value.ToString()[0];
			model.Valor = Convert.ToDecimal(dataGridView1.Rows[r].Cells["valor"].Value);
			model.Data = DateTime.Parse(dataGridView1.Rows[r].Cells["data"].Value.ToString());
			model.Observacao = dataGridView1.Rows[r].Cells["observacao"].Value.ToString();

			Presenter.CarregarLancamento(model);

			LimparDados();

			foreach (object o in cbTipo.Items)
			{
				if (o.ToString()[0] == model.Tipo)
					cbTipo.SelectedItem = o;
			}

			if (model.LancamentoTipo == LancamentoTipo.Entrada || model.LancamentoTipo == LancamentoTipo.Pagamento || model.LancamentoTipo == LancamentoTipo.Vale)
			{
				cbCodigo.Text = model.Codigo.ToString() + " - " + model.Nome;
			}
			else
			{
				cbCodigo.Text = "";
			}

			if ((model.LancamentoTipo == LancamentoTipo.Entrada || model.LancamentoTipo == LancamentoTipo.Pagamento) && model.Situacao != 'C')
			{
				btRecibo.Enabled = true;
			}
			else
			{
				btRecibo.Enabled = false;
			}

			if (model.Forma != null)
			{
				foreach (object o in cbForma.Items)
				{
					if (o.ToString()[0] == model.Forma)
						cbForma.SelectedItem = o;
				}
			}

			tbValor.Text = model.Valor.ToString();
			dtData.Value = model.Data;
			tbObservacao.Text = model.Observacao;

			if (model.Situacao == 'A')
			{
				btNovo.Text = "Confirmar - F2";

				btCancelar.Enabled = true;
				btCancelar.Text = "&Cancelar - F4";

				groupBox1.Enabled = true;
				cbTipo.Enabled = false;
			}
			else if (model.Situacao == 'C')
			{
				btNovo.Enabled = false;

				btCancelar.Enabled = true;
				btCancelar.Text = "Reativar - F4";
			}
			else
			{
				btNovo.Enabled = false;
				btCancelar.Enabled = false;
			}
		}

		private void cbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cbForma.Focus();
		}

		private void cbCodigo_SelectedValueChanged(object sender, EventArgs e)
		{
			if (((ComboBox)sender).SelectedItem != null)
				Presenter.DefinirCodigo(((ComboBox)sender).SelectedItem.ToString());
		}

		private void cbForma_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				tbValor.Focus();
		}

		private void cbForma_SelectedValueChanged(object sender, EventArgs e)
		{
			if (((ComboBox)sender).SelectedItem != null)
				Presenter.DefinirFormaDePagamento(((ComboBox)sender).SelectedItem.ToString());
		}

		private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbTipo.Text.Length > 0)
			{
				if (!cbTipo.Items.Contains(cbTipo.Text))
				{
					MessageBox.Show("Por favor, selecione um item da lista!", this.Text);

					cbTipo.SelectAll();

					cbTipo.Focus();

					return;
				}

				Presenter.DefinirLancamentoTipo(cbTipo.Text[0]);

				switch (cbTipo.Text[0])
				{
					case 'E':
						{
							cbCodigo.Items.Clear();

							if (ListaClientes != null)
								cbCodigo.Items.AddRange(ListaClientes.ToArray());

							lbCodigo.Text = "Cliente";
							cbCodigo.Enabled = true;
							cbCodigo.Focus();

							cbForma.Enabled = true;

							break;
						}

					case 'P':
						{
							cbCodigo.Items.Clear();

							if (ListaRecursos != null)
								cbCodigo.Items.AddRange(ListaRecursos.ToArray());

							lbCodigo.Text = "Funcionário";
							cbCodigo.Enabled = true;
							cbCodigo.Focus();

							cbForma.Enabled = false;

							break;
						}

					case 'S':
						{
							lbCodigo.Text = "";
							cbCodigo.Enabled = false;
							cbCodigo.Items.Clear();

							cbForma.Enabled = false;

							break;
						}

					case 'T':
						{
							cbCodigo.Items.Clear();
							lbCodigo.Text = "Caixa";
							cbCodigo.Enabled = true;
							cbCodigo.Focus();

							cbForma.Enabled = false;

							break;
						}

					case 'V':
						{
							cbCodigo.Items.Clear();
							cbCodigo.Items.AddRange(ListaRecursos.ToArray());
							lbCodigo.Text = "Funcionário";
							cbCodigo.Enabled = true;
							cbCodigo.Focus();

							cbForma.Enabled = false;

							break;
						}
				}
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbTipo.Text != string.Empty)
			{
				tbValor.Focus();
			}
		}

		private void Confirmar()
		{
			try
			{
				if (!btNovo.Enabled)
				{
					return;
				}

				Novo.Invoke(btNovo, null);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
				CarregarRegistro(dataGridView1.SelectedRows[0].Index);
		}

		void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			DataGridViewRow r = grid.Rows[e.RowIndex];

			DataGridViewCellStyle style = new DataGridViewCellStyle(r.DefaultCellStyle);

			if (r.Cells["situacao"].Value.ToString() == "C")
			{
				style.BackColor = Color.Red;
				style.ForeColor = Color.White;
			}
			else
			{
				switch (r.Cells["tipo"].Value.ToString())
				{
					case "D":
						style.BackColor = Color.Orange;
						style.ForeColor = Color.Black;
						break;

					case "E":
						style.BackColor = Color.LightGreen;
						style.ForeColor = Color.Black;
						break;

					case "P":
						style.BackColor = Color.Blue;
						style.ForeColor = Color.White;
						break;

					case "S":
						style.BackColor = Color.Magenta;
						style.ForeColor = Color.White;
						break;

					case "T":
						style.BackColor = Color.Pink;
						style.ForeColor = Color.Black;
						break;

					case "V":
						style.BackColor = Color.LightBlue;
						style.ForeColor = Color.Black;
						break;
				}
			}

			r.DefaultCellStyle = style;
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbObservacao.Focus();
			}
		}

		private void fechamentoDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDeCaixa);

			form.ShowDialog();

			Atualizar();
		}

		private void fechamentoDiárioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Presenter.RelatorioFechamentoDiario();
		}

		void frmFinanceiro_FormClosing(object sender, FormClosingEventArgs e)
		{
			Presenter.Finish();

			GC.Collect();
		}

		private void frmFinanceiro_Load(object sender, EventArgs e)
		{
		}

		private void label7_DoubleClick(object sender, EventArgs e)
		{
			CancelamentoCrediario();
		}

		private void lançamentosPorPeríodoDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Presenter.LancamentosPeriodoDetalhado(this);
		}

		private void movimentosPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConMovimentos form = new frmConMovimentos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor.Focus();
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbValor.Text.Length > 0)
			{
				dtData.Focus();
			}
		}

		private void textBox2_Leave(object sender, EventArgs e)
		{
			double numero;

			if (tbValor.Text.Length > 0)
			{
				if (!double.TryParse(tbValor.Text, out numero))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbValor.SelectAll();

					tbValor.Focus();

					return;
				}

				tbValor.Text = numero.ToString("0.00");
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btNovo.Focus();
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Cancela();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			frmFechamento form = new frmFechamento(_dsoftBd, _usuario, DSoftModels.Enums.Fechamentos.FechamentoDiario);

			form.Text = "Fechamento Diário";

			form.ShowDialog();
		}

		private void toolStripMenuItem7_Click(object sender, EventArgs e)
		{
			CancelamentoCrediario();
		}

		private void toolStripMenuItem8_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma emissão da Redução Z?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
				BemaFI64.Analisa_iRetorno(BemaFI64.Bematech_FI_ReducaoZ(DateTime.Today.ToString("ddMMyy"), DateTime.Now.ToString("hhmmss")));
		}

		private void toolStripMenuItem9_Click(object sender, EventArgs e)
		{
			Presenter.RecalcularSaldosClientes();
		}

		#endregion Methods
	}
}