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

namespace DSoft_Delivery.Forms
{
	public partial class frmCadFiliais : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Filial _filial = null;

		public frmCadFiliais(Bd bd, Usuario usuario)
			:base()
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCadFiliais_Load(object sender, EventArgs e)
		{
			CarregarFiliais();
		}

		private void CarregarFiliais()
		{
			DataTable dt = _dsoftBd.CarregarCadastroFiliais();

			dataGridView1.DataSource = dt;
		}

		private void Confirmar()
		{
			if (CadastroPreenchido())
			{
				if (_dsoftBd.InsertOrUpdate(_filial))
				{
					Limpar();
					CarregarFiliais();
				}
			}
		}

		private bool CadastroPreenchido()
		{
			int codigo;
			int.TryParse(tbCodigo.Text, out codigo);

			if (codigo < 1)
			{
				return false;
			}

			if (tbNome.Text.Length < 1)
			{
				return false;
			}

			_filial = new Filial();
			_filial.Codigo = codigo;
			_filial.Nome = tbNome.Text;
			_filial.Cnpj = tbCnpj.Text;

			int telefone;
			int.TryParse(tbTelefone.Text, out telefone);

			_filial.Telefone = telefone;
			_filial.Endereco = tbEndereco.Text;
			_filial.Bairro = tbBairro.Text;
			_filial.Cidade = tbCidade.Text;
			_filial.Estado = tbEstado.Text;
			_filial.Pais = tbPais.Text;

			return true;
		}

		private void Limpar()
		{
			tbCodigo.Enabled = true;

			foreach (Control c in this.Controls)
			{
				if (c is TextBox)
				{
					c.Text = string.Empty;
				}
			}

			btCancelar.Text = "&Cancelar F4";

			_filial = null;
		}

		private void Cancelar()
		{

		}

		private void Sair()
		{
			this.Close();
		}

		private void CarregarFilial(Filial filial)
		{
			tbCodigo.Enabled = false;

			tbCodigo.Text = filial.Codigo.ToString();
			tbNome.Text = filial.Nome;
			tbCnpj.Text = filial.Cnpj;
			tbTelefone.Text = filial.Telefone.ToString();
			tbEndereco.Text = filial.Endereco;
			tbBairro.Text = filial.Bairro;
			tbCidade.Text = filial.Cidade;
			tbEstado.Text = filial.Estado;
			tbPais.Text = filial.Pais;

			if (filial.Situacao == "A")
			{
				btCancelar.Text = "&Cancelar F4";
			}
			else
			{
				btCancelar.Text = "&Reativar F4";
			}

			_filial = filial;
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text != string.Empty)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCnpj.Focus();
			}
		}

		private void tbCnpj_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTelefone.Focus();
			}
		}

		private void tbTelefone_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEndereco.Focus();
			}
		}

		private void tbEndereco_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbBairro.Focus();
			}
		}

		private void tbBairro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCidade.Focus();
			}
		}

		private void tbCidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEstado.Focus();
			}
		}

		private void tbEstado_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbPais.Focus();
			}
		}

		private void tbPais_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int codigo = Convert.ToInt32(dataGridView1["codigo", e.RowIndex].Value);

			Filial filial = _dsoftBd.CarregarFilial(codigo);

			if (filial != null)
			{
				CarregarFilial(filial);
			}
		}
	}
}
