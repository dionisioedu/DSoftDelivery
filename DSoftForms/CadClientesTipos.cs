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
	public partial class CadClientesTipos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public CadClientesTipos(Bd bd, Usuario usuario)
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

				_dsoftBd.TiposClientes(ds);

				dgTipos.DataSource = ds.Tables[0];

				dgTipos.Columns["codigo"].HeaderText = "Código";
				dgTipos.Columns["nome"].HeaderText = "Nome";
				dgTipos.Columns["situacao"].HeaderText = "Situação";
				dgTipos.Columns["cliente_interno"].HeaderText = "Cliente interno";
				dgTipos.Columns["mensalidade"].HeaderText = "Mensalidade";
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

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			try
			{
				int codigo;

				if (tbCodigo.Text != string.Empty && int.TryParse(tbCodigo.Text, out codigo) && codigo > 0)
				{
					if (tbNome.Text == string.Empty)
					{
						MessageBox.Show("Campo 'nome' deve ser preenchido!");
						tbNome.Focus();
						return;
					}

					ClienteTipo tipo = new ClienteTipo();
					tipo.Codigo = codigo;
					tipo.Nome = tbNome.Text;
					tipo.Interno = cbInterno.Checked;
					tipo.Mensalidade = cbMensalidade.Checked;

					if (_dsoftBd.TipoClienteExiste(codigo))
					{
						if (_dsoftBd.AlterarTipoClientes(tipo))
						{
							Atualizar();
							LimparDados();
						}
					}
					else
					{
						if (_dsoftBd.NovoTipoClientes(tipo))
						{
							Atualizar();
							LimparDados();
						}
					}
				}
				else
				{
					MessageBox.Show("Campo 'código' inválido!");
					tbCodigo.SelectAll();
					tbCodigo.Focus();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				tbCodigo.Text = dgTipos["codigo", e.RowIndex].Value.ToString();
				tbNome.Text = dgTipos["nome", e.RowIndex].Value.ToString();
				cbInterno.Checked = Convert.ToBoolean(dgTipos["cliente_interno", e.RowIndex].Value);
				cbMensalidade.Checked = Convert.ToBoolean(dgTipos["mensalidade", e.RowIndex].Value);
			}
		}

		private void frmCadClientesTipos_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void LimparDados()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			cbInterno.Checked = false;
			cbMensalidade.Checked = false;

			tbCodigo.Focus();
		}

		private void listagemDeTiposDeClietnesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//DataSet ds = new DataSet();

			//if (!_dsoftBd.ListaClientesTipos(ds))
			//    return;

			//RelatorioHtml relatorio = new RelatorioHtml();

			//relatorio.Arquivo = relatorio.Titulo = "Listagem de tipos de clientes";

			//relatorio.Descricao = "Listagem de todos os tipos de clientes cadastrados no sistema. Emitido em " + DateTime.Now.ToShortDateString();

			//relatorio.Gerar(ds);
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (tbCodigo.Text.Length > 0 && e.KeyChar == (char)Keys.Enter)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbInterno.Focus();
			}
		}

		private void cbInterno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbMensalidade.Focus();
			}
		}

		private void cbMensalidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		#endregion Methods
	}
}