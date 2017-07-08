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
	public partial class frmCadRecursosTipos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadRecursosTipos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.RecursosTipos(ds);

				dataGridView1.DataSource = ds.Tables[0];
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int row)
		{
			try
			{
				tbCodigo.Text = dataGridView1["codigo", row].Value.ToString();
				tbDescricao.Text = dataGridView1["descricao", row].Value.ToString();
				cbEntrega.Checked = bool.Parse(dataGridView1["entrega", row].Value.ToString());
				cbProducao.Checked = bool.Parse(dataGridView1["producao", row].Value.ToString());
				tbComDia.Text = dataGridView1["comissao_diaria", row].Value.ToString();
				tbComNom.Text = dataGridView1["comissao_nominal", row].Value.ToString();
				tbFixoSemanal.Text = dataGridView1["fixo_semanal", row].Value.ToString();
				tbFixoMensal.Text = dataGridView1["fixo_mensal", row].Value.ToString();
				tbValorEntrega.Text = dataGridView1["valor_entrega", row].Value.ToString();
				tbDiaria.Text = dataGridView1["diaria", row].Value.ToString();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void checkBox1_Enter(object sender, EventArgs e)
		{
			cbEntrega.ForeColor = Color.DarkBlue;
		}

		private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbProducao.Focus();
			}
		}

		private void checkBox1_Leave(object sender, EventArgs e)
		{
			cbEntrega.ForeColor = Color.Black;
		}

		private void checkBox2_Enter(object sender, EventArgs e)
		{
			cbProducao.ForeColor = Color.DarkBlue;
		}

		private void checkBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbComDia.Focus();
			}
		}

		private void checkBox2_Leave(object sender, EventArgs e)
		{
			cbProducao.ForeColor = Color.Black;
		}

		private void Confirmar()
		{
			try
			{
				RecursoTipo recurso = new RecursoTipo();

				if (!char.TryParse(tbCodigo.Text, out recurso.Codigo))
				{
					MessageBox.Show("Código deve apenas um caracter!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}

				if ((recurso.Descricao = tbDescricao.Text) == string.Empty)
				{
					MessageBox.Show("Campo 'nome' não pode ser vazio!", this.Text);

					tbDescricao.Focus();

					return;
				}

				recurso.Entrega = cbEntrega.Checked;

				recurso.Producao = cbProducao.Checked;

				if (!float.TryParse(tbComDia.Text, out recurso.ComissaoDiaria))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbComDia.SelectAll();

					tbComDia.Focus();

					return;
				}

				if (!float.TryParse(tbComNom.Text, out recurso.ComissaoNominal))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbComNom.SelectAll();

					tbComNom.Focus();

					return;
				}

				if (!decimal.TryParse(tbFixoSemanal.Text, out recurso.FixoSemanal))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbFixoSemanal.SelectAll();

					tbFixoSemanal.Focus();

					return;
				}

				if (!decimal.TryParse(tbFixoMensal.Text, out recurso.FixoMensal))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbFixoMensal.SelectAll();

					tbFixoMensal.Focus();

					return;
				}

				if (!decimal.TryParse(tbValorEntrega.Text, out recurso.ValorEntrega))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbValorEntrega.SelectAll();

					tbValorEntrega.Focus();

					return;
				}

				if (!decimal.TryParse(tbDiaria.Text, out recurso.Diaria))
				{
					MessageBox.Show("Valor inválido!", this.Text);
					tbDiaria.SelectAll();
					tbDiaria.Focus();
					return;
				}

				if (_dsoftBd.RecursoTipoDescricao(recurso.Codigo) == string.Empty)
				{
					if (_dsoftBd.NovoRecursoTipo(recurso))
					{
						Atualizar();

						LimparDados();
					}
				}
				else
				{
					if (_dsoftBd.AlterarRecursoTipo(recurso))
					{
						Atualizar();

						LimparDados();
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
			CarregarDados(dataGridView1.CurrentRow.Index);
		}

		private void frmCadRecursosTipos_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparDados();
		}

		private void LimparDados()
		{
			decimal zero = 0;

			tbCodigo.Clear();
			tbDescricao.Clear();
			tbComDia.Text = zero.ToString("0.00");
			tbComNom.Text = zero.ToString("0.00");
			tbFixoSemanal.Text = zero.ToString("0.00");
			tbFixoMensal.Text = zero.ToString("0.00");
			tbValorEntrega.Text = zero.ToString("0.00");
			tbDiaria.Text = zero.ToString("0.00");

			cbEntrega.Checked = false;
			cbProducao.Checked = false;

			groupBox1.Focus();
			tbCodigo.Focus();
		}

		private void listagemDeTiposDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();

			if (!_dsoftBd.ListaRecursosTipos(ds))
				return;

			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.Arquivo = relatorio.Titulo = "Listagem de tipos de recursos";

			relatorio.Descricao = "Listagem de todos os tipos de recursos cadastrados no sistema. Emitido em " + DateTime.Now.ToShortDateString();

			relatorio.Gerar(ds);
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
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text != string.Empty)
			{
				tbDescricao.Focus();
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbDescricao.Text != string.Empty)
			{
				cbEntrega.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbComNom.Focus();
			}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			float numero = 0;

			if (tbComDia.Text != string.Empty && !float.TryParse(tbComDia.Text, out numero))
			{
				MessageBox.Show("Valor inválido!", this.Text);

				tbComDia.SelectAll();

				tbComDia.Focus();

				return;
			}

			tbComDia.Text = numero.ToString("0.00");
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbDiaria.Focus();
			}
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			float numero = 0;

			if (tbComNom.Text != string.Empty && !float.TryParse(tbComNom.Text, out numero))
			{
				MessageBox.Show("Valor inválido!", this.Text);

				tbComNom.SelectAll();

				tbComNom.Focus();

				return;
			}

			tbComNom.Text = numero.ToString("0.00");
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbFixoMensal.Focus();
			}
		}

		private void textBox5_Leave(object sender, EventArgs e)
		{
			float numero = 0;

			if (tbFixoSemanal.Text != string.Empty && !float.TryParse(tbFixoSemanal.Text, out numero))
			{
				MessageBox.Show("Valor inválido!", this.Text);

				tbFixoSemanal.SelectAll();

				tbFixoSemanal.Focus();

				return;
			}

			tbFixoSemanal.Text = numero.ToString("0.00");
		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbValorEntrega.Focus();
			}
		}

		private void textBox6_Leave(object sender, EventArgs e)
		{
			float numero = 0;

			if (tbFixoMensal.Text != string.Empty && !float.TryParse(tbFixoMensal.Text, out numero))
			{
				MessageBox.Show("Valor inválido!", this.Text);

				tbFixoMensal.SelectAll();

				tbFixoMensal.Focus();

				return;
			}

			tbFixoMensal.Text = numero.ToString("0.00");
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void textBox7_Leave(object sender, EventArgs e)
		{
			float numero = 0;

			if (tbValorEntrega.Text != string.Empty && !float.TryParse(tbValorEntrega.Text, out numero))
			{
				MessageBox.Show("Valor inválido!", this.Text);

				tbValorEntrega.SelectAll();

				tbValorEntrega.Focus();

				return;
			}

			tbValorEntrega.Text = numero.ToString("0.00");
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void tbDiaria_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbFixoSemanal.Focus();
			}
		}

		#endregion Methods
	}
}