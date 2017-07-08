using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;
using DSoftCore;

namespace DSoft_Delivery
{
	public partial class frmCadFornecedores : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadFornecedores(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private bool Alterar()
		{
			try
			{
				Fornecedor fornecedor = new Fornecedor();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Código deve ser preenchido!", this.Text);

					tbCodigo.Focus();

					return false;
				}

				if (!long.TryParse(tbCodigo.Text, out fornecedor.Codigo))
				{
					MessageBox.Show("Código deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return false;
				}

				if ((fornecedor.Nome = tbNome.Text) == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!", this.Text);

					tbNome.Focus();

					return false;
				}

				fornecedor.Cnpj = tbCNPJ.Text;

				if (tbTel1.Text != string.Empty && !long.TryParse(tbTel1.Text, out fornecedor.Telefone1))
				{
					MessageBox.Show("Campo 'telefone 1' deve ser numérico!", this.Text);

					tbTel1.SelectAll();

					tbTel1.Focus();

					return false;
				}

				if (tbTel2.Text != string.Empty && !long.TryParse(tbTel2.Text, out fornecedor.Telefone2))
				{
					MessageBox.Show("Campo 'telefone 2' deve ser numérico!", this.Text);

					tbTel2.SelectAll();

					tbTel2.Focus();

					return false;
				}

				fornecedor.Endereco = tbEndereco.Text;
				fornecedor.Bairro = tbBairro.Text;
				fornecedor.Cidade = tbCidade.Text;
				fornecedor.Estado = cbEstado.Text;
				fornecedor.Pais = tbPais.Text;

				if (tbCep.Text != string.Empty && !int.TryParse(tbCep.Text.Remove(5, 1), out fornecedor.Cep))
				{
					MessageBox.Show("Campo 'cep' deve ser numérico!");

					tbCep.SelectAll();

					tbCep.Focus();

					return false;
				}

				fornecedor.Tipo = (FornecedorTipo)cbTipo.SelectedItem;
				fornecedor.Contato = tbContato.Text;
				fornecedor.Observacao = tbObs.Text;
				fornecedor.Email = tbEmail.Text;

				return _dsoftBd.AlterarFornecedor(fornecedor);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);

				return false;
			}
		}

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarFornecedores(ds);

				dataGridView1.DataSource = ds.Tables[0];

				Util.Pintar(ref dataGridView1);
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
			Cancelar();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (tbCodigo.ReadOnly == true)
			{
				long codigo;

				if (long.TryParse(tbCodigo.Text, out codigo) && codigo > 0)
				{
					if (btCancelar.Text == "&Cancelar - F4")
					{
						if (_dsoftBd.CancelarFornecedor(codigo))
						{
							Atualizar();
						}
					}
					else
					{
						if (_dsoftBd.ReativarFornecedor(codigo))
						{
							Atualizar();
						}
					}
				}
			}
		}

		private void CarregarDados(int row)
		{
			try
			{
				groupBox1.Enabled = true;

				btNovo.Text = "&Confirmar - F2";

				tbCodigo.ReadOnly = true;

				tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
				tbNome.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();
				tbCNPJ.Text = dataGridView1.Rows[row].Cells["cnpj"].Value.ToString();
				tbTel1.Text = dataGridView1.Rows[row].Cells["tel1"].Value.ToString();
				tbTel2.Text = dataGridView1.Rows[row].Cells["tel2"].Value.ToString();
				tbEndereco.Text = dataGridView1.Rows[row].Cells["endereco"].Value.ToString();
				tbBairro.Text = dataGridView1.Rows[row].Cells["bairro"].Value.ToString();
				tbCidade.Text = dataGridView1.Rows[row].Cells["cidade"].Value.ToString();
				cbEstado.Text = dataGridView1.Rows[row].Cells["estado"].Value.ToString();
				tbPais.Text = dataGridView1.Rows[row].Cells["pais"].Value.ToString();
				tbCep.Text = dataGridView1.Rows[row].Cells["cep"].Value.ToString();
				cbTipo.SelectedIndex = 0;
				tbContato.Text = dataGridView1.Rows[row].Cells["contato"].Value.ToString();
				tbObs.Text = dataGridView1.Rows[row].Cells["obs"].Value.ToString();
				tbEmail.Text = dataGridView1.Rows[row].Cells["email"].Value.ToString();

				if (dataGridView1.Rows[row].Cells["situacao"].Value.ToString() == "A")
				{
					btCancelar.Text = "&Cancelar - F4";
				}
				else
				{
					btCancelar.Text = "&Reativar - F4";
				}

				btNovo.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbPais.Focus();
			}
		}

		private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbContato.Focus();
			}
		}

		private void Confirmar()
		{
			try
			{
				if (btNovo.Text == "&Novo - F2")
				{
					btNovo.Text = "&Confirmar - F2";

					groupBox1.Enabled = true;

					tbCodigo.Focus();
				}
				else
				{
					if (tbCodigo.ReadOnly)
					{
						if (Alterar())
						{
							LimparDados();

							Atualizar();
						}
					}
					else
					{
						if (Incluir())
						{
							LimparDados();

							Atualizar();
						}
					}
				}
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
			CarregarDados(dataGridView1.CurrentRow.Index);
		}

		private void frmCadFornecedores_Load(object sender, EventArgs e)
		{
			CarregarTipos();

			Atualizar();
		}

		private void CarregarTipos()
		{
			List<FornecedorTipo> tipos = new List<FornecedorTipo>();

			tipos.Add(new FornecedorTipo() { Codigo = 1, Nome = "COMUM" });

			cbTipo.Items.Clear();

			cbTipo.Items.AddRange(tipos.ToArray());
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private bool Incluir()
		{
			try
			{
				Fornecedor fornecedor = new Fornecedor();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Código deve ser preenchido!", this.Text);

					tbCodigo.Focus();

					return false;
				}

				if (!long.TryParse(tbCodigo.Text, out fornecedor.Codigo))
				{
					MessageBox.Show("Código deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return false;
				}

				if ((fornecedor.Nome = tbNome.Text) == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!", this.Text);

					tbNome.Focus();

					return false;
				}

				fornecedor.Cnpj = tbCNPJ.Text;

				if (tbTel1.Text != string.Empty && !long.TryParse(tbTel1.Text, out fornecedor.Telefone1))
				{
					MessageBox.Show("Campo 'telefone 1' deve ser numérico!", this.Text);

					tbTel1.SelectAll();

					tbTel1.Focus();

					return false;
				}

				if (tbTel2.Text != string.Empty && !long.TryParse(tbTel2.Text, out fornecedor.Telefone2))
				{
					MessageBox.Show("Campo 'telefone 2' deve ser numérico!", this.Text);

					tbTel2.SelectAll();

					tbTel2.Focus();

					return false;
				}

				fornecedor.Endereco = tbEndereco.Text;
				fornecedor.Bairro = tbBairro.Text;
				fornecedor.Cidade = tbCidade.Text;
				fornecedor.Estado = cbEstado.Text;
				fornecedor.Pais = tbPais.Text;

				if (tbCep.Text != "     -" && !int.TryParse(tbCep.Text.Remove(5, 1), out fornecedor.Cep))
				{
					MessageBox.Show("Campo 'cep' deve ser numérico!");

					tbCep.SelectAll();

					tbCep.Focus();

					return false;
				}

				fornecedor.Tipo = (FornecedorTipo)cbTipo.SelectedItem;
				fornecedor.Contato = tbContato.Text;
				fornecedor.Observacao = tbObs.Text;
				fornecedor.Email = tbEmail.Text;

				return _dsoftBd.IncluirFornecedor(fornecedor);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);

				return false;
			}
		}

		private void LimparDados()
		{
			foreach (Control c in groupBox1.Controls)
			{
				if (c is TextBox || c is ComboBox || c is MaskedTextBox)
				{
					c.Text = string.Empty;
				}
			}

			groupBox1.Enabled = false;

			tbCodigo.ReadOnly = false;

			btNovo.Text = "&Novo - F2";
			btCancelar.Text = "&Cancelar - F4";
		}

		private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbTel1.Focus();
			}
		}

		private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbTipo.Focus();
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

		private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btNovo.Focus();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbCodigo.Text != string.Empty && e.KeyChar == (char)Keys.Enter)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long numero;

			if (tbCodigo.Text.Length > 0 && !long.TryParse(tbCodigo.Text, out numero))
			{
				MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

				tbCodigo.SelectAll();

				tbCodigo.Focus();

				return;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbNome.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
			{
				tbCNPJ.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbTel2.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbEndereco.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbBairro.Focus();
			}
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbCidade.Focus();
			}
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbEstado.Focus();
			}
		}

		private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbCep.Focus();
			}
		}

		private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar==(char)Keys.Enter)
			{
				tbObs.Focus();
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		#endregion Methods
	}
}