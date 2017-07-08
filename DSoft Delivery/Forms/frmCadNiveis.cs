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
	public partial class frmCadNiveis : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadNiveis(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_dsoftBd.UsuariosNiveis(ds);

			dataGridView1.DataSource = ds.Tables[0];
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CarregarNivel(string codigo)
		{
			NivelUsuario nivel = _dsoftBd.CarregarNivelUsuario(codigo);

			if (nivel == null)
			{
				MessageBox.Show("Erro ao carregar dados!");
				return;
			}

			tbCodigo.Text = nivel.Nivel;
			tbDescricao.Text = nivel.Nome;
			cbAdministrador.Checked = nivel.Administrador;
			cbLancarPedidos.Checked = nivel.LancarPedidos;
			cbAlterarPedidos.Checked = nivel.AlterarPedidos;
			cbAlteraClientePedido.Checked = nivel.AlterarClienteDoPedido;
			cbCancelarPedidos.Checked = nivel.CancelarPedidos;
			cbCaixa.Checked = nivel.Caixa;
			cbControleFinanceiro.Checked = nivel.ControleFinanceiro;
			cbEntregas.Checked = nivel.Entregas;
			cbRelatorios.Checked = nivel.Relatorios;
			cbCadastrarProdutos.Checked = nivel.CadastrarProdutos;
			cbAlterarPrecos.Checked = nivel.AlterarPrecos;
			cbCompras.Checked = nivel.Compras;
			cbCadastrarRecursos.Checked = nivel.CadastrarRecursos;
			cbCadastrarUsuarios.Checked = nivel.CadastrarUsuarios;
			cbAlterarEstoque.Checked = nivel.AlterarEstoque;
			cbScriptBd.Checked = nivel.ScriptBd;
			cbPreferencias.Checked = nivel.Preferencias;
			cbTerminal.Checked = nivel.Terminal;
			cbRegrasNegocio.Checked = nivel.RegrasDeNegocio;
			cbCadastrarGruposDeClientes.Checked = nivel.CadastrarGruposDeClientes;
			cbEscritorio.Checked = nivel.Escritorio;
			cbAlmoxarifado.Checked = nivel.Almoxarifado;
		}

		private void cbAdministrador_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;

			if (checkBox != null && checkBox.Checked)
			{
				foreach (Control c in this.Controls)
				{
					if (c is CheckBox)
					{
						if (!((CheckBox)c).Checked)
						{
							((CheckBox)c).Checked = true;
						}
					}
				}
			}
		}

		private void Confirmar()
		{
			NivelUsuario nivel = new NivelUsuario();

			nivel.Nivel = tbCodigo.Text;
			nivel.Nome = tbDescricao.Text;
			nivel.Administrador = cbAdministrador.Checked;
			nivel.LancarPedidos = cbLancarPedidos.Checked;
			nivel.AlterarPedidos = cbAlterarPedidos.Checked;
			nivel.AlterarClienteDoPedido = cbAlteraClientePedido.Checked;
			nivel.CancelarPedidos = cbCancelarPedidos.Checked;
			nivel.Caixa = cbCaixa.Checked;
			nivel.ControleFinanceiro = cbControleFinanceiro.Checked;
			nivel.Entregas = cbEntregas.Checked;
			nivel.Relatorios = cbRelatorios.Checked;
			nivel.CadastrarProdutos = cbCadastrarProdutos.Checked;
			nivel.AlterarPrecos = cbAlterarPrecos.Checked;
			nivel.Compras = cbCompras.Checked;
			nivel.CadastrarRecursos = cbCadastrarRecursos.Checked;
			nivel.CadastrarUsuarios = cbCadastrarUsuarios.Checked;
			nivel.AlterarEstoque = cbAlterarEstoque.Checked;
			nivel.ScriptBd = cbScriptBd.Checked;
			nivel.Preferencias = cbPreferencias.Checked;
			nivel.Terminal = cbTerminal.Checked;
			nivel.RegrasDeNegocio = cbRegrasNegocio.Checked;
			nivel.CadastrarGruposDeClientes = cbCadastrarGruposDeClientes.Checked;
			nivel.Escritorio = cbEscritorio.Checked;
			nivel.Almoxarifado = cbAlmoxarifado.Checked;

			if (_dsoftBd.SalvarNivelUsuario(nivel, _usuario))
			{
				LimparCampos();
				Atualizar();
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string codigo = dataGridView1.Rows[e.RowIndex].Cells["nivel"].Value.ToString();

			CarregarNivel(codigo);
		}

		private void frmCadNiveis_Load(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void LimparCampos()
		{
			foreach (Control c in this.Controls)
			{
				if (c is TextBox)
				{
					((TextBox)c).Text = string.Empty;
				}
				else if (c is CheckBox)
				{
					((CheckBox)c).Checked = false;
				}
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
			Confirmar();
		}

		#endregion Methods
	}
}