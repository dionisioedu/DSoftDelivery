using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class frmConEntregasEmAberto : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConEntregasEmAberto(Bd bd, Usuario usuario)
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
				int entregador;

				LimparCampos();

				if (textBox1.Text == string.Empty)
				{
					entregador = 0;
				}
				else
				{
					if (!int.TryParse(textBox1.Text, out entregador))
					{
						MessageBox.Show("Campo 'entregador' deve ser numérico!", this.Text);

						textBox1.SelectAll();

						textBox1.Focus();

						return;
					}
				}

				DataSet ds = new DataSet();

				if (!_DSoftBd.CarregarEntregas(ds, entregador, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, radioButton1.Checked))
				{
					MessageBox.Show("Houve eu erro ao consultar os dados! Entre em contato com o suporte.", this.Text);

					return;
				}

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["hora"].DefaultCellStyle.Format = "hh:mm:ss";
				dataGridView1.Columns["saida"].DefaultCellStyle.Format = "hh:mm:ss";
				dataGridView1.Columns["entrega1"].DefaultCellStyle.Format = "hh:mm:ss";

				dataGridView1.Columns["codigo"].Width = 40;
				dataGridView1.Columns["data"].Width = 68;
				dataGridView1.Columns["hora"].Width = 68;
				dataGridView1.Columns["cliente"].Width = 68;
				dataGridView1.Columns["nome"].Width = 172;
				dataGridView1.Columns["itens"].Width = 40;
				dataGridView1.Columns["valor"].Width = 60;
				dataGridView1.Columns["situacao"].Width = 40;
				dataGridView1.Columns["caixa"].Width = 60;
				dataGridView1.Columns["entrega"].Width = 40;
				dataGridView1.Columns["data1"].Width = 68;
				dataGridView1.Columns["saida"].Width = 68;
				dataGridView1.Columns["entrega1"].Width = 68;
				dataGridView1.Columns["recurso"].Width = 68;

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
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int row)
		{
			string tmp;
			string endereco;
			string bairro;

			try
			{
				LimparCampos();

				textBox3.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
				textBox5.Text = dataGridView1.Rows[row].Cells["itens"].Value.ToString();
				textBox4.Text = dataGridView1.Rows[row].Cells["valor"].Value.ToString();
				dateTimePicker3.Value = DateTime.Parse(dataGridView1.Rows[row].Cells["data"].Value.ToString());
				dateTimePicker6.Value = DateTime.Parse(dataGridView1.Rows[row].Cells["hora"].Value.ToString());
				textBox2.Text = dataGridView1.Rows[row].Cells["cliente"].Value.ToString();
				lbCliente.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();
				textBox6.Text = dataGridView1.Rows[row].Cells["recurso"].Value.ToString();
				lbRecurso.Text = dataGridView1.Rows[row].Cells["nome1"].Value.ToString();

				if (_DSoftBd.ClienteEndereco(int.Parse(textBox2.Text), out endereco, out bairro))
				{
					lbEndereco.Text = endereco + Environment.NewLine;
					lbEndereco.Text += bairro;
				}

				if ((tmp = dataGridView1.Rows[row].Cells["saida"].Value.ToString()) != string.Empty)
				{
					dateTimePicker5.Visible = true;
					dateTimePicker5.Value = DateTime.Parse(tmp);
				}

				if ((tmp = dataGridView1.Rows[row].Cells["entrega1"].Value.ToString()) != string.Empty)
				{
					dateTimePicker4.Visible = true;
					dateTimePicker4.Value = DateTime.Parse(tmp);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarDados(dataGridView1.CurrentRow.Index);
		}

		private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				dateTimePicker2.Focus();
			}
		}

		private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void frmConEntregasEmAberto_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void LimparCampos()
		{
			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			textBox6.Clear();

			lbCliente.Text = string.Empty;
			lbEndereco.Text = string.Empty;
			lbRecurso.Text = string.Empty;

			//dateTimePicker6.Visible = false;
			dateTimePicker5.Visible = false;
			dateTimePicker4.Visible = false;
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
				dateTimePicker1.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int entregador;

			if (textBox1.Text == string.Empty)
			{
				lbEntregador.Text = string.Empty;
			}
			else
			{
				if (!int.TryParse(textBox1.Text, out entregador))
				{
					MessageBox.Show("Campo 'entregador' deve ser numérico!", this.Text);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				Recurso recurso = new Recurso();

				recurso.Codigo = entregador;

				if (_DSoftBd.CarregarDadosRecurso(recurso))
				{
					RecursoTipo recurso_tipo = new RecursoTipo();

					recurso_tipo.Codigo = recurso.Tipo;

					if (!_DSoftBd.CarregarRecursoTipo(recurso_tipo))
					{
						MessageBox.Show("Erro ao carregar tipo de recurso!", this.Text);

						textBox1.SelectAll();

						textBox1.Focus();

						return;
					}

					if (!recurso_tipo.Entrega)
					{
						MessageBox.Show("Recurso não está habilitado para fazer entregas!", this.Text);

						textBox1.SelectAll();

						textBox1.Focus();

						return;
					}

					lbEntregador.Text = recurso.Nome;

					return;
				}
				else
				{
					MessageBox.Show("Entregador não encontrado!");

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}
			}
		}

		#endregion Methods
	}
}