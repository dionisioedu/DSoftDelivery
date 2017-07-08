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

namespace DSoft_Delivery.Despesas
{
	public partial class DespesasView : Form, IDespesasView
	{
		#region Fields

		//private Despesa DespesaAtual;
		private DataSet DataSet = null;
		private DespesasModel Model;
		private DespesasPresenter Presenter;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public DespesasView(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Model = new DespesasModel();
			Presenter = new DespesasPresenter(bd, usuario, this, Model);
		}

		#endregion Constructors

		#region Events

		public event EventHandler CancelarClicked;

		public event EventHandler NovoClicked;

		public event EventHandler PagarClicked;

		public event EventHandler SairClicked;

		public event EventHandler TiposClicked;

		#endregion Events

		#region Methods

		public void ClearFields()
		{
			this.Invoke(new Action(() => { LimparCampos(); }));
		}

		public void PrepareNew()
		{
			this.Invoke(new Action(() =>
				{
					btNova.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					cbTipo.Focus();
				}));
		}

		public void SetDataSource(DataSet ds)
		{
			DataSet = ds;

			this.Invoke(new Action(() => { Atualizar(); }));
		}

		public void SetTypes(string[] types)
		{
			this.Invoke(new Action(() =>
				{
					cbTipo.Items.Clear();
					cbTipo.Items.AddRange(types);
				}));
		}

		public string Titulo()
		{
			return this.Text;
		}

		private void Atualizar()
		{
			try
			{
				if (DataSet == null)
					return;

				dataGridView1.DataSource = DataSet.Tables[0];

				dataGridView1.Columns["codigo"].Width = 42;
				dataGridView1.Columns["data"].Width = 68;
				dataGridView1.Columns["vencimento"].Width = 68;
				dataGridView1.Columns["pagamento"].Width = 68;
				dataGridView1.Columns["tipo"].Width = 42;
				dataGridView1.Columns["fornecedor"].Width = 42;

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
					//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
				}

				dataGridView1.UseWaitCursor = false;
				progressBar1.Visible = false;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			LimparCampos();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			CancelarClicked.Invoke(btCancelar, null);
		}

		private void CarregarDados(int row)
		{
			try
			{
				string tmp;
				Despesa despesa = new Despesa();

				despesa.Indice = int.Parse(dataGridView1.Rows[row].Cells["codigo"].Value.ToString());
				despesa.Data = DateTime.Parse(dataGridView1.Rows[row].Cells["data"].Value.ToString());
				despesa.Vencimento = DateTime.Parse(dataGridView1.Rows[row].Cells["vencimento"].Value.ToString());

				if ((tmp = dataGridView1.Rows[row].Cells["pagamento"].Value.ToString()) != string.Empty)
				{
					despesa.Pagamento = DateTime.Parse(tmp);
				}

				if ((tmp = dataGridView1.Rows[row].Cells["valor_pago"].Value.ToString()) != string.Empty)
				{
					despesa.ValorPago = decimal.Parse(tmp);
				}

				despesa.Tipo = int.Parse(dataGridView1.Rows[row].Cells["tipo"].Value.ToString());
				despesa.Situacao = char.Parse(dataGridView1.Rows[row].Cells["situacao"].Value.ToString());
				despesa.Valor = decimal.Parse(dataGridView1.Rows[row].Cells["valor"].Value.ToString());
				despesa.Documento = dataGridView1.Rows[row].Cells["documento"].Value.ToString();
				despesa.Observacao = dataGridView1.Rows[row].Cells["observacao"].Value.ToString();

				cbTipo.Text = cbTipo.Items[cbTipo.FindString(despesa.Tipo.ToString())].ToString();
				dtVencimento.Value = despesa.Vencimento;
				tbValor.Text = despesa.Valor.ToString("0.00");
				tbDocumento.Text = despesa.Documento;
				tbObservacao.Text = despesa.Observacao;

				if (long.TryParse(dataGridView1.Rows[row].Cells["fornecedor"].Value.ToString(), out despesa.Fornecedor))
				{
					lbFornecedor.Text = _dsoftBd.FornecedorNome(despesa.Fornecedor);

					tbCodigo.Text = despesa.Fornecedor.ToString();
				}

				switch (despesa.Situacao)
				{
				case 'A':
					groupBox1.Enabled = true;

					btNova.Text = "&Confirmar - F2";
					btPagar.Enabled = true;
					btCancelar.Enabled = true;

					break;

				case 'V':
					groupBox1.Enabled = true;

					btNova.Text = "&Confirmar - F2";
					btPagar.Enabled = true;
					btCancelar.Enabled = true;

					break;

				case 'C':
					btNova.Enabled = false;
					btPagar.Enabled = true;
					btCancelar.Text = "&Reativar - F4";

					break;

				case 'F':
					btNova.Enabled = false;

					break;

				case 'P':
					btNova.Enabled  = false;
					btPagar.Enabled = true;
					btPagar.Text = "&Desfazer - F3";

					break;
				}

				Presenter.SetDespesa(despesa);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbTipo.Text.Length > 0)
			{
				if (!cbTipo.Items.Contains(cbTipo.Text))
				{
					MessageBox.Show("Selecione um item!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbTipo.SelectAll();

					cbTipo.Focus();
				}
				else
				{
					int tipo = Util.Codigo(cbTipo.Text);
					Presenter.SetTipo(tipo);
				}
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbTipo.Text.Length > 0)
			{
				tbCodigo.Focus();
			}
		}

		private void Confirmar()
		{
			NovoClicked.Invoke(btNova, null);
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(dataGridView1.CurrentRow.Index);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			DataGridViewRow r = grid.Rows[e.RowIndex];

			DataGridViewCellStyle style = new DataGridViewCellStyle(r.DefaultCellStyle);

			switch (r.Cells["situacao"].Value.ToString())
			{
				case "A":
					if (DateTime.Compare(DateTime.Parse(r.Cells["vencimento"].Value.ToString()), DateTime.Now) < 0)
					{
						style.BackColor = Color.Yellow;
					}

					break;

				case "V":
					style.BackColor = Color.Yellow;
					style.ForeColor = Color.Black;
					break;

				case "C":
					style.BackColor = Color.Red;
					style.ForeColor = Color.White;
					break;

				case "F":
					style.BackColor = Color.Blue;
					style.ForeColor = Color.White;
					break;

				case "P":
					style.BackColor = Color.Green;
					style.ForeColor = Color.White;
					break;
			}

			r.DefaultCellStyle = style;
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor.Focus();
			}
		}

		private void despesasPagasPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmFiltroData form = new frmFiltroData(_dsoftBd, _usuario);
			form.Text = "Despesas pagas por período";

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_dsoftBd.DespesasPagasPeriodoAsync(form.Inicial, form.Final).ContinueWith((task) =>
					{
						if (task.IsFaulted)
							return;

						Relatorios.DespesasPagasPeriodo.Gerar(form.Inicial, form.Final, task.Result);
					});
			}
		}

		private void DespesasView_FormClosing(object sender, FormClosingEventArgs e)
		{
			SairClicked.Invoke(this, e);
		}

		private void dtVencimento_ValueChanged(object sender, EventArgs e)
		{
			Presenter.SetVencimento(dtVencimento.Value);
		}

		private void frmDespesas_Load(object sender, EventArgs e)
		{
			LimparCampos();
		}

		private void LimparCampos()
		{
			cbTipo.Text = string.Empty;
			tbCodigo.Clear();
			tbDocumento.Clear();
			tbValor.Clear();
			tbObservacao.Clear();
			lbFornecedor.Text = string.Empty;
			dtVencimento.Value = DateTime.Now;

			groupBox1.Enabled = false;

			btNova.Text = "&Nova - F2";
			btPagar.Text = "&Pagar - F3";
			btCancelar.Text = "&Cancelar - F4";

			btNova.Enabled = true;
			btPagar.Enabled = false;
			btCancelar.Enabled = false;
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Pagar()
		{
			PagarClicked.Invoke(btPagar, null);
		}

		private void Sair()
		{
			SairClicked.Invoke(btSair, null);

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbDocumento_TextChanged(object sender, EventArgs e)
		{
			Presenter.SetDocumento(tbDocumento.Text);
		}

		private void tbObservacao_TextChanged(object sender, EventArgs e)
		{
			Presenter.SetObservacao(tbObservacao.Text);
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dtVencimento.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long codigo;

			if (tbCodigo.Text.Length > 0)
			{
				if (!long.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'fornecedor' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if ((lbFornecedor.Text = Presenter.SetFornecedor(codigo)) == string.Empty)
				{
					MessageBox.Show("Código de fornecedor não encontrado!", this.Text);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbObservacao.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbValor.Text.Length > 0)
			{
				tbDocumento.Focus();
			}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			decimal valor;

			if (tbValor.Text.Length > 0)
			{
				if (!decimal.TryParse(tbValor.Text, out valor))
				{
					MessageBox.Show("Valor inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbValor.SelectAll();

					tbValor.Focus();

					return;
				}

				Presenter.SetValor(valor);

				tbValor.Text = valor.ToString("0.00");
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btNova.Focus();
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			TiposClicked.Invoke(null, null);
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Pagar();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		#endregion Methods
	}
}