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

namespace DSoft_Delivery
{
	public partial class frmDespesas : Form
	{
		#region Fields

		private Despesa DespesaAtual;
		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmDespesas(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.CarregarDespesas(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["codigo"].Width = 42;
				dataGridView1.Columns["data"].Width = 68;
				dataGridView1.Columns["vencimento"].Width = 68;
				dataGridView1.Columns["pagamento"].Width = 68;
				dataGridView1.Columns["tipo"].Width = 42;
				dataGridView1.Columns["fornecedor"].Width = 42;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						if (DateTime.Compare(DateTime.Parse(dataGridView1.Rows[i].Cells["vencimento"].Value.ToString()), DateTime.Now) < 0)
						{
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						}

						break;

					case "V":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "F":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "P":
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}

				if (dataGridView1.Rows.Count > 1)
				{
					dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
					//dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
				}
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
			try
			{
				if (!button3.Enabled)
				{
					return;
				}

				if (button3.Text == "&Cancelar - F4")
				{
					if (_DSoftBd.CancelarDespesa(DespesaAtual.Indice, _usuario.Autorizado))
					{
						LimparCampos();

						Atualizar();
					}
				}
				else
				{
					if (_DSoftBd.ReativarDespesa(DespesaAtual.Indice, _usuario.Autorizado))
					{
						LimparCampos();

						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
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
					lbFornecedor.Text = _DSoftBd.FornecedorNome(despesa.Fornecedor);

					tbCodigo.Text = despesa.Fornecedor.ToString();
				}

				switch (despesa.Situacao)
				{
				case 'A':
					groupBox1.Enabled = true;

					button1.Text = "&Confirmar - F2";
					button2.Enabled = true;
					button3.Enabled = true;

					break;

				case 'V':
					groupBox1.Enabled = true;

					button1.Text = "&Confirmar - F2";
					button2.Enabled = true;
					button3.Enabled = true;

					break;

				case 'C':
					button1.Enabled = false;
					button3.Enabled = true;
					button3.Text = "&Reativar - F4";

					break;

				case 'F':
					button1.Enabled = false;

					break;

				case 'P':
					button1.Enabled  = false;
					button2.Enabled = true;
					button2.Text = "&Desfazer - F3";

					break;
				}

				DespesaAtual = despesa;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void CarregarTipos()
		{
			try
			{
				string[] tipos;

				cbTipo.Items.Clear();

				_DSoftBd.CarregarDespesasTipo(out tipos);

				for (int i = 0; i < tipos.Length; i++)
				{
					cbTipo.Items.Add(tipos[i]);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar tipos de despesas." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cbTipo.Text.Length > 0)
			{
				tbCodigo.Focus();
			}
		}

		private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && cbTipo.Text.Length > 0)
			{
				tbCodigo.Focus();
			}
		}

		private void comboBox1_Leave(object sender, EventArgs e)
		{
			if (cbTipo.Text.Length > 0)
			{
				if (!cbTipo.Items.Contains(cbTipo.Text))
				{
					MessageBox.Show("Por favor, selecione um item!", this.Text);

					cbTipo.SelectAll();

					cbTipo.Focus();
				}
			}
		}

		private void Confirmar()
		{
			try
			{
				if (button1.Enabled && button1.Text == "&Nova - F2")
				{
					button1.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					cbTipo.Focus();

					return;
				}

				Despesa despesa = new Despesa();

				if (cbTipo.Text.Length < 1)
				{
					MessageBox.Show("Tipo de despesa deve ser preenchido!", this.Text);

					cbTipo.Focus();

					return;
				}

				if (!cbTipo.Items.Contains(cbTipo.Text))
				{
					MessageBox.Show("Selecione um item!", this.Text);

					cbTipo.SelectAll();

					cbTipo.Focus();

					return;
				}

				despesa.Tipo = Util.Codigo(cbTipo.Text);

				if (tbCodigo.Text.Length < 1)
				{
					despesa.Fornecedor = 0;
				}
				else
				{
					if (!long.TryParse(tbCodigo.Text, out despesa.Fornecedor))
					{
						MessageBox.Show("Campo 'fornecedor' deve ser numérico!", this.Text);

						tbCodigo.SelectAll();

						tbCodigo.Focus();

						return;
					}

					if (_DSoftBd.FornecedorNome(despesa.Fornecedor) == string.Empty)
					{
						MessageBox.Show("Código não encontrado!", this.Text);

						tbCodigo.SelectAll();

						tbCodigo.Focus();

						return;
					}
				}

				despesa.Vencimento = dtVencimento.Value.Date;

				despesa.Data = DateTime.Now;

				if (!decimal.TryParse(tbValor.Text, out despesa.Valor))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbValor.SelectAll();

					tbValor.Focus();

					return;
				}

				despesa.Documento = tbDocumento.Text;

				despesa.Observacao = tbObservacao.Text;

				if (DespesaAtual == null)
				{
					if (_DSoftBd.NovaDespesa(despesa, _usuario.Autorizado) > 0)
					{
						LimparCampos();

						Atualizar();
					}
				}
				else
				{
					despesa.Indice = DespesaAtual.Indice;

					if (_DSoftBd.AlterarDespesa(despesa, _usuario.Autorizado))
					{
						LimparCampos();

						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(dataGridView1.CurrentRow.Index);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text);
			}
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValor.Focus();
			}
		}

		private void frmDespesas_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparCampos();

			CarregarTipos();
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

			button1.Text = "&Nova - F2";
			button2.Text = "&Pagar - F3";
			button3.Text = "&Cancelar - F4";

			button1.Enabled = true;
			button2.Enabled = false;
			button3.Enabled = false;

			DespesaAtual = null;
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Pagar()
		{
			try
			{
				if (!button2.Enabled)
				{
					return;
				}

				if (button2.Text == "&Pagar - F3")
				{
					if (_DSoftBd.PagarDespesa(DespesaAtual.Indice, _usuario.Autorizado, Caixa.Numero))
					{
						LimparCampos();

						Atualizar();
					}
				}
				else
				{
					if (_DSoftBd.DesfazerDespesa(DespesaAtual.Indice, _usuario.Autorizado))
					{
						LimparCampos();

						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
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

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dtVencimento.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int codigo;

			if (tbCodigo.Text.Length > 0)
			{
				if (!int.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'fornecedor' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if ((lbFornecedor.Text = _DSoftBd.FornecedorNome(codigo)) == string.Empty)
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
			double valor;

			if (tbValor.Text.Length > 0)
			{
				if (!double.TryParse(tbValor.Text, out valor))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbValor.SelectAll();

					tbValor.Focus();

					return;
				}

				tbValor.Text = valor.ToString("0.00");
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			frmCadDespesasTipos form = new frmCadDespesasTipos(_DSoftBd, _usuario);

			form.ShowDialog();

			CarregarTipos();
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