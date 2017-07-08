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
	public partial class frmCadVeiculos : Form
	{
		#region Fields

		private char Situacao;
		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadVeiculos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.CarregarVeiculos(ds);

			if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
			{
				dataGridView1.DataSource = ds.Tables[0];

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					if (dataGridView1.Rows[i].Cells["situacao"].Value.ToString() == "C")
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					}
				}
			}
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btIncluir_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (_DSoftBd.CancelarVeiculo(mbPlaca.Text))
				{
					Limpar();
					Atualizar();
				}
			}
			else
			{
				if (_DSoftBd.ReativarVeiculo(mbPlaca.Text))
				{
					Limpar();
					Atualizar();
				}
			}
		}

		private void Confirmar()
		{
			if (mbPlaca.Text == "___-____")
				return;

			Veiculo veiculo = new Veiculo();

			veiculo.Placa = mbPlaca.Text;
			veiculo.Modelo = tbModelo.Text;
			int.TryParse(tbAno.Text, out veiculo.Ano);
			veiculo.Cor = tbCor.Text;
			veiculo.Marca = tbMarca.Text;
			veiculo.Proprietario = tbProprietario.Text;
			veiculo.Endereco = tbEndereco.Text;
			veiculo.Cidade = tbCidade.Text;
			veiculo.Estado = cbEstado.Text;
			veiculo.Telefone = tbTelefone.Text;
			veiculo.Cpf = mbCpf.Text;
			veiculo.RENAVAM = tbRenavam.Text;
			veiculo.Tara = tbTara.Text;
			veiculo.CapKg = tbCapKg.Text;
			veiculo.CapM3 = tbCapM3.Text;
			veiculo.RNTRC = tbRNTRC.Text;
			veiculo.IE = tbIE.Text;

			if (btIncluir.Text == "&Incluir - F2")
			{
				if (_DSoftBd.NovoVeiculo(veiculo))
				{
					Limpar();
					Atualizar();
				}
			}
			else
			{
				if (_DSoftBd.AlterarVeiculo(veiculo))
				{
					Limpar();
					Atualizar();
				}
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			int r;

			if (dataGridView1.SelectedRows.Count == 0)
				return;

			Limpar();

			r = dataGridView1.SelectedRows[0].Index;

			mbPlaca.Text = dataGridView1.Rows[r].Cells["placa"].Value.ToString();
			tbModelo.Text = dataGridView1.Rows[r].Cells["modelo"].Value.ToString();
			tbAno.Text = dataGridView1.Rows[r].Cells["ano"].Value.ToString();
			tbCor.Text = dataGridView1.Rows[r].Cells["cor"].Value.ToString();
			tbMarca.Text = dataGridView1.Rows[r].Cells["marca"].Value.ToString();
			tbProprietario.Text = dataGridView1.Rows[r].Cells["proprietario"].Value.ToString();
			tbEndereco.Text = dataGridView1.Rows[r].Cells["endereco"].Value.ToString();
			tbCidade.Text = dataGridView1.Rows[r].Cells["cidade"].Value.ToString();
			cbEstado.Text = dataGridView1.Rows[r].Cells["estado"].Value.ToString();
			tbTelefone.Text = dataGridView1.Rows[r].Cells["telefone"].Value.ToString();
			mbCpf.Text = dataGridView1.Rows[r].Cells["cpf"].Value.ToString();
			tbRenavam.Text = dataGridView1.Rows[r].Cells["renavam"].Value.ToString();
			tbTara.Text = dataGridView1.Rows[r].Cells["tara"].Value.ToString();
			tbCapKg.Text = dataGridView1.Rows[r].Cells["capkg"].Value.ToString();
			tbCapM3.Text = dataGridView1.Rows[r].Cells["capm3"].Value.ToString();
			tbRNTRC.Text = dataGridView1.Rows[r].Cells["rntrc"].Value.ToString();
			tbIE.Text = dataGridView1.Rows[r].Cells["ie"].Value.ToString();

			mbPlaca.ReadOnly = true;

			if ((Situacao = dataGridView1.Rows[r].Cells["situacao"].Value.ToString()[0]) == 'A')
			{
				btCancelar.Enabled = true;
			}
			else
			{
				btCancelar.Enabled = true;
				btCancelar.Text = "&Reativar - F4";
			}

			btIncluir.Text = "Confirmar - F2";
		}

		private void frmCadVeiculos_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void Limpar()
		{
			foreach (Control c in Controls)
			{
				if (c is TextBox || c is MaskedTextBox || c is ComboBox)
				{
					c.Text = string.Empty;
				}
			}

			mbPlaca.ReadOnly = false;

			btIncluir.Text = "&Incluir - F2";

			btCancelar.Text = "&Cancelar - F4";
			btCancelar.Enabled = false;

			mbPlaca.Focus();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
		}

		#endregion Methods
	}
}