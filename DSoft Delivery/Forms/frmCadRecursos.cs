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
	public partial class frmCadRecursos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadRecursos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Alterar()
		{
			try
			{
				if (!btAlterar.Enabled)
				{
					return;
				}

				if (AlterarRecurso())
				{
					LimparDados();

					Atualizar();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private bool AlterarRecurso()
		{
			try
			{
				long telefone = 0;
				Recurso recurso = new Recurso();

				recurso.Codigo = int.Parse(tbCodigo.Text);

				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!");

					tbNome.Focus();

					return false;
				}

				recurso.Nome = tbNome.Text;
				recurso.Nascimento = dtNascimento.Value;

				if (tbTelefone1.Text != string.Empty && !long.TryParse(tbTelefone1.Text, out telefone))
				{
					MessageBox.Show("Campo 'telefone 1' deve ser numérico!");

					tbTelefone1.SelectAll();
					tbTelefone1.Focus();

					return false;
				}

				if (telefone > 0)
				{
					recurso.Telefone1 = telefone;
					telefone = 0;
				}

				if (tbTelefone2.Text != string.Empty && !long.TryParse(tbTelefone2.Text, out telefone))
				{
					MessageBox.Show("Campo 'telefone 2' deve ser numérico!");

					tbTelefone2.SelectAll();
					tbTelefone2.Focus();

					return false;
				}

				if (telefone > 0)
				{
					recurso.Telefone2 = telefone;
					telefone = 0;
				}

				if (tbCelular.Text != string.Empty && !long.TryParse(tbCelular.Text, out telefone))
				{
					MessageBox.Show("Campo 'celular' deve ser numérico!");

					tbCelular.SelectAll();
					tbCelular.Focus();

					return false;
				}

				if (telefone > 0)
				{
					recurso.Celular = telefone;
				}

				recurso.Endereco = tbEndereco.Text;
				recurso.Cidade = tbCidade.Text;
				recurso.Estado = cbEstado.Text;

				if (cbTipo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'tipo' deve ser preenchido com uma das opções!");

					cbTipo.Focus();

					return false;
				}

				recurso.Tipo = cbTipo.Text[0];
				recurso.Rg = tbRG.Text;
				recurso.Cpf = tbCPF.Text;
				recurso.Habilitacao = tbHabilitacao.Text;
				recurso.Categoria = tbCategoria.Text;
				recurso.Email = tbEmail.Text;

				if (_dsoftBd.AlterarRecurso(recurso))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Alterar();
		}

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				if (_dsoftBd.CarregarRecursos(ds))
				{
					dataGridView1.DataSource = ds.Tables[0];

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

						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void Bloquear()
		{
			if (!btBloquear.Enabled)
			{
				return;
			}

			if (btBloquear.Text == "&Bloquear")
			{
				if (_dsoftBd.BloquearRecurso(int.Parse(tbCodigo.Text)))
				{
					LimparDados();

					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.DesbloquearRecurso(int.Parse(tbCodigo.Text), _usuario.Autorizado))
				{
					LimparDados();

					Atualizar();
				}
			}
		}

		private void bloquearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Alterar();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (!btCancelar.Enabled)
			{
				return;
			}

			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (_dsoftBd.CancelarRecurso(int.Parse(tbCodigo.Text)))
				{
					LimparDados();

					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.ReativarRecurso(int.Parse(tbCodigo.Text), _usuario.Autorizado))
				{
					LimparDados();

					Atualizar();
				}
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarDados(int codigo)
		{
			try
			{
				Recurso recurso = new Recurso();

				recurso.Codigo = codigo;

				if (!_dsoftBd.CarregarDadosRecurso(recurso))
				{
					return;
				}

				tbCodigo.ReadOnly = true;
				tbCodigo.Text = recurso.Codigo.ToString();
				tbNome.Text = recurso.Nome;
				dtNascimento.Value = recurso.Nascimento;
				tbTelefone1.Text = recurso.Telefone1.ToString();
				tbTelefone2.Text = recurso.Telefone2.ToString();
				tbCelular.Text = recurso.Celular.ToString();
				tbEndereco.Text = recurso.Endereco;
				tbCidade.Text = recurso.Cidade;
				cbEstado.Text = recurso.Estado;
				tbRG.Text = recurso.Rg;
				tbCPF.Text = recurso.Cpf;
				tbHabilitacao.Text = recurso.Habilitacao;
				tbCategoria.Text = recurso.Categoria;
				tbEmail.Text = recurso.Email;

				for (int i = 0; i < cbTipo.Items.Count; i++)
				{
					if (recurso.Tipo == cbTipo.Items[i].ToString()[0])
					{
						cbTipo.Text = cbTipo.Items[i].ToString();

						break;
					}
				}

				groupBox1.Enabled = true;

				btIncluir.Enabled = false;
				btLimpar.Enabled = true;

				switch (recurso.Situacao)
				{
				case 'A':
					btAlterar.Enabled = true;
					btBloquear.Enabled = true;
					btCancelar.Enabled = true;

					break;

				case 'B':
					btAlterar.Enabled = false;
					btBloquear.Enabled = true;
					btCancelar.Enabled = true;

					btBloquear.Text = "Desbloquear";

					break;

				case 'C':
					btAlterar.Enabled = false;
					btBloquear.Enabled = false;
					btCancelar.Enabled = true;

					btCancelar.Text = "Reativar - F4";

					break;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void CarregarTiposRecursos()
		{
			string[] tipos;

			cbTipo.Items.Clear();

			if (_dsoftBd.RecursosTipos(out tipos))
			{
				for (int i = 0; i < tipos.Length; i++)
				{
					cbTipo.Items.Add(tipos[i]);
				}
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(int.Parse(dataGridView1.CurrentRow.Cells["codigo"].Value.ToString()));
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void frmCadRecursos_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparDados();
		}

		private void Incluir()
		{
			if (btIncluir.Text == "&Incluir - F2")
			{
				groupBox1.Enabled = true;

				tbCodigo.ReadOnly = false;
				tbCodigo.Focus();

				btIncluir.Text = "Confirmar - F2";
			}
			else
			{
				if (IncluirRecurso())
				{
					LimparDados();

					Atualizar();
				}
			}
		}

		private bool IncluirRecurso()
		{
			try
			{
				int codigo;
				long telefone;

				Recurso recurso = new Recurso();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!");

					tbCodigo.Focus();

					return false;
				}

				if (!int.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!");

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return false;
				}

				recurso.Codigo = codigo;
				recurso.Nome = tbNome.Text;

				recurso.Nascimento = dtNascimento.Value;

				if (long.TryParse(tbTelefone1.Text, out telefone))
				{
					recurso.Telefone1 = telefone;
				}

				if (long.TryParse(tbTelefone2.Text, out telefone))
				{
					recurso.Telefone2 = telefone;
				}

				if (long.TryParse(tbCelular.Text, out telefone))
				{
					recurso.Celular = telefone;
				}

				recurso.Endereco = tbEndereco.Text;
				recurso.Cidade = tbCidade.Text;
				recurso.Estado = cbEstado.Text;

				if (cbTipo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'tipo' deve ser preenchido!");

					cbTipo.Focus();

					return false;
				}

				recurso.Tipo = cbTipo.Text[0];
				recurso.Rg = tbRG.Text;
				recurso.Cpf = tbCPF.Text;
				recurso.Habilitacao = tbHabilitacao.Text;
				recurso.Categoria = tbCategoria.Text;
				recurso.Email = tbEmail.Text;

				if (_dsoftBd.NovoRecurso(recurso))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return false;
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void LimparDados()
		{
			foreach (Control tb in groupBox1.Controls)
			{
				if (tb is TextBox || tb is ComboBox)
				{
					tb.Text = string.Empty;
				}
				else if (tb is DateTimePicker)
				{
					tb.Text = string.Empty;
				}
			}

			CarregarTiposRecursos();

			btIncluir.Text = "&Incluir - F2";
			btAlterar.Text = "&Alterar - F3";
			btBloquear.Text = "&Bloquear";
			btCancelar.Text = "&Cancelar - F4";
			btLimpar.Text = "&Limpar Dados";

			btIncluir.Enabled = true;
			btAlterar.Enabled = false;
			btBloquear.Enabled = false;
			btCancelar.Enabled = false;
			btLimpar.Enabled = false;

			groupBox1.Enabled = false;
		}

		private void listagemDeRecursosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();

			if (!_dsoftBd.ListaRecursos(ds))
				return;

			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.Arquivo = "ListagemRecursos";
			relatorio.Titulo = "Listagem de recursos";

			relatorio.Descricao = "Listagem de todos os recursos cadastrados no sistema. Emitido em " + DateTime.Now.ToShortDateString();

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

		private void tbTelefone2_TextChanged(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			frmCadRecursosTipos form = new frmCadRecursosTipos(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarTiposRecursos();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			frmCadRecursosGrupos form = new frmCadRecursosGrupos(_dsoftBd, _usuario);

			form.ShowDialog();
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbTelefone1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTelefone2.Focus();
			}
		}

		private void tbTelefone1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbNome.Focus();
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbNome.Text.Length > 0)
			{
				cbTipo.Focus();
			}
		}

		private void cbTipo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtNascimento.Focus();
			}
		}

		private void dtNascimento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTelefone1.Focus();
			}
		}

		private void tbTelefone2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCelular.Focus();
			}
		}

		private void tbTelefone2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbCelular_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEndereco.Focus();
			}
		}

		private void tbCelular_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbEndereco_KeyDown(object sender, KeyEventArgs e)
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
				cbEstado.Focus();
			}
		}

		private void cbEstado_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbRG.Focus();
			}
		}

		private void tbRG_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCPF.Focus();
			}
		}

		private void tbCPF_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbHabilitacao.Focus();
			}
		}

		private void tbHabilitacao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCategoria.Focus();
			}
		}

		private void tbCategoria_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEmail.Focus();
			}
		}

		private void tbEmail_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btIncluir.Focus();
			}
		}

		#endregion Methods
	}
}