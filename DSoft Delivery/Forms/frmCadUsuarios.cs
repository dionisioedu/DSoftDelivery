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
	public partial class frmCadUsuarios : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadUsuarios(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private bool AlterarUsuario()
		{
			Usuario usuario = LeUsuario();

			if (usuario == null)
			{
				return false;
			}

			if (!_dsoftBd.AlterarUsuario(usuario))
			{
				MessageBox.Show("Erro ao salvar dados!");

				return false;
			}

			Atualizar();

			LimparCampos();

			return true;
		}

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.UsuariosCadastrados(ds);

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

				CarregarNiveis();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			LimparDados();
		}

		private void Cancelar()
		{
			if (btCancelar.Text == "&Cancelar - F4")
			{
				CancelarUsuario();
			}
			else
			{
				ReativarUsuario();
			}

			LimparDados();
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CancelarUsuario()
		{
			try
			{
				int codigo;

				if (int.TryParse(tbCodigo.Text, out codigo))
				{
					if (_dsoftBd.CancelarUsuario(codigo, _usuario.Autorizado))
					{
						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void CarregarNiveis()
		{
			cbNivel.Items.Clear();

			DataSet ds = new DataSet();

			_dsoftBd.UsuariosNiveis(ds);

			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				NivelUsuario nivel = new NivelUsuario();
				nivel.Nivel = dr["nivel"].ToString();
				nivel.Nome = dr["nome"].ToString();

				cbNivel.Items.Add(nivel);
			}
		}

		private void CarregarRegistro()
		{
			try
			{
				int codigo;

				if (int.TryParse(dataGridView1.CurrentRow.Cells["codigo"].Value.ToString(), out codigo) == false)
				{
					MessageBox.Show("Usuário inválido", "Cadastro de Usuários");

					return;
				}

				Usuario usuario = _dsoftBd.CarregarUsuario(codigo);

				tbCodigo.Text = codigo.ToString();
				tbCodigo.ReadOnly = true;

				tbNome.Text = usuario.Nome;

				mbSenha.Text = usuario.Senha;
				mbConfirma.Text = usuario.Senha;

				if (usuario.Recurso != null)
				{
					cbRecurso.SelectedIndex = cbRecurso.FindString(usuario.Recurso.ToString());
				}

				if (usuario.NivelUsuario != null)
				{
					cbNivel.SelectedIndex = cbNivel.FindString(usuario.NivelUsuario.ToString());
				}
				else
				{
					cbNivel.SelectedIndex = cbNivel.FindString(usuario.Nivel.ToString());
				}

				switch (usuario.Situacao.ToString())
				{
				case "A":
					lbAviso.Text = "Usuário Ativo!";

					btConfirmar.Enabled = true;
					btConfirmar.Text = "Confirmar - F2";
					btCancelar.Enabled = true;

					break;

				case "B":
					lbAviso.Text = "Usuário Bloqueado!";

					btConfirmar.Enabled = false;
					btCancelar.Enabled = true;

					break;

				case "C":
					lbAviso.Text = "Usuário Cancelado!";

					btConfirmar.Enabled = false;
					btCancelar.Enabled = true;

					btCancelar.Text = "Reativar - F4";

					break;

				default:

					break;
				}

				groupBox1.Enabled = true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return;
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarRegistro();
		}

		private void DesbloquearUsuario()
		{
			try
			{
				int codigo;

				if (int.TryParse(tbCodigo.Text, out codigo))
				{
					if (_dsoftBd.DesbloquearUsuario(codigo))
					{
						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void frmCadUsuarios_Load(object sender, EventArgs e)
		{
			Atualizar();

			CarregarRecursos();
		}

		private void CarregarRecursos()
		{
			cbRecurso.Items.Clear();

			cbRecurso.Items.Add("");

			cbRecurso.Items.AddRange(_dsoftBd.CarregarRecursos().ToArray());
		}

		private void Incluir()
		{
			if (groupBox1.Enabled)
			{
				if (tbCodigo.Text.Length > 0)
				{
					int codigo;
					int.TryParse(tbCodigo.Text, out codigo);

					if (codigo > 0 && _dsoftBd.UsuarioCadastrado(codigo))
					{
						if (AlterarUsuario())
						{
							LimparDados();
						}
					}
					else
					{
						if (IncluirUsuario())
						{
							LimparDados();
						}
					}
				}
			}
			else
			{
				groupBox1.Enabled = true;

				tbCodigo.Focus();

				btConfirmar.Text = "Confirmar - F2";
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private bool IncluirUsuario()
		{
			Usuario usuario = LeUsuario();

			if (usuario == null)
			{
				return false;
			}

			if (!_dsoftBd.IncluirUsuario(usuario))
			{
				MessageBox.Show("Operação não concluída!");

				return false;
			}

			Atualizar();

			LimparCampos();

			return true;
		}

		private Usuario LeUsuario()
		{
			int codigo;

			if (!int.TryParse(tbCodigo.Text, out codigo) || codigo < 1)
			{
				MessageBox.Show("Código inválido!");

				tbCodigo.Focus();

				return null;
			}

			if (tbNome.Text.Trim().Length < 1)
			{
				MessageBox.Show("Nome inválido!");

				tbNome.Focus();

				return null;
			}

			if (mbSenha.Text.Length < 4)
			{
				MessageBox.Show("Senha inválida! Deve ter no mínimo 4 dígitos");

				mbSenha.Focus();

				return null;
			}

			if (mbSenha.Text != mbConfirma.Text)
			{
				MessageBox.Show("Senha não confere!");

				mbSenha.Focus();

				return null;
			}

			if (!cbNivel.Items.Contains(cbNivel.SelectedItem))
			{
				MessageBox.Show("Nível de usuário inválido!");

				cbNivel.Focus();

				return null;
			}

			Usuario usuario = new Usuario();
			usuario.Codigo = codigo;
			usuario.Nome = tbNome.Text;
			usuario.Senha = mbSenha.Text;
			usuario.NivelUsuario = (NivelUsuario)cbNivel.SelectedItem;
			usuario.Recurso = (Recurso)cbRecurso.SelectedItem;

			return usuario;
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			cbNivel.SelectedItem = null;
			mbSenha.Clear();
			mbConfirma.Clear();
			cbRecurso.SelectedItem = null;
		}

		private void LimparDados()
		{
			LimparCampos();

			lbAviso.Text = string.Empty;

			btConfirmar.Enabled = true;
			btCancelar.Enabled = false;

			btConfirmar.Text = "&Incluir - F2";
			btCancelar.Text = "&Cancelar - F4";

			tbCodigo.ReadOnly = false;

			groupBox1.Enabled = false;
		}

		private void listaDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();

			if (!_dsoftBd.ListaUsuarios(ds))
				return;

			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.Arquivo = relatorio.Titulo = "Listagem Usuarios";

			relatorio.Descricao = "Listagem de todos os usuarios cadastrados no sistema. Emitido em " + DateTime.Now.ToShortDateString();

			relatorio.Gerar(ds);
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void ReativarUsuario()
		{
			try
			{
				int codigo;

				if (int.TryParse(tbCodigo.Text, out codigo))
				{
					if (_dsoftBd.ReativarUsuario(codigo))
					{
						Atualizar();
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
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

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			frmCadNiveis form = new frmCadNiveis(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarNiveis();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbNome.Focus();
			}
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		#endregion Methods

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbRecurso.Focus();
			}
		}

		private void cbRecurso_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbNivel.Focus();
			}
		}

		private void cbNivel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbSenha.Focus();
			}
		}

		private void mbSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbConfirma.Focus();
			}
		}

		private void mbConfirma_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}
	}
}