using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftCore;
using DSoftModels;

namespace DSoftForms
{
	public partial class LancarSaida : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private Usuario _usuarioOperacao;
		private Caixa _caixa;

		public LancarSaida(Bd bd, Usuario usuario, Caixa caixa)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_caixa = caixa;

			confirmButton1.Click += confirmarToolStripMenuItem_Click;
			cancelButton1.Click += sairToolStripMenuItem_Click;
		}

		private void LancarSaida_Load(object sender, EventArgs e)
		{
			CarregarCaixas();

			tbUsuario.Text = _usuario.Codigo.ToString();
			lbUsuario.Text = _usuario.Nome;

			tbValor.Focus();
		}

		private void CarregarCaixas()
		{
			List<Caixa> caixas = _dsoftBd.CarregarCaixas();

			cbCaixa.Items.AddRange(caixas.ToArray());

			cbCaixa.SelectedIndex = cbCaixa.FindString(_caixa.ToString());
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			decimal valor;
			decimal.TryParse(tbValor.Text, out valor);

			if (valor > 0)
			{
				if (tbObs.Text.Length < 3)
				{
					lbMensagemObs.Text = "Observação precisa ser preenchida!";
					tbObs.Focus();
					return;
				}

				if (ValidarUsuario())
				{
					Caixa caixa = cbCaixa.SelectedItem as Caixa;

					if (caixa != null)
					{
						FluxoDeCaixa saida = new FluxoDeCaixa();
						saida.Caixa = caixa.Codigo;
						saida.Data = DateTime.Now;
						saida.Forma = 'D';
						saida.Observacao = tbObs.Text;
						saida.Tipo = 'S';
						saida.Valor = valor;

						if (_dsoftBd.LancarSaida(saida, caixa.Codigo, _usuarioOperacao.Codigo))
						{
							this.Close();
						}
						else
						{
							MessageBox.Show("Não foi possível efetuar a operação!");
						}
					}
				}
			}
		}

		private bool ValidarUsuario()
		{
			int codigo;
			int.TryParse(tbUsuario.Text, out codigo);

			if (codigo < 1)
			{
				lbUsuario.Text = "Usuário inválido!";
				tbUsuario.SelectAll();
				tbUsuario.Focus();
				return false;
			}

			if (_dsoftBd.UsuarioCadastrado(codigo, tbSenha.Text) == '0')
			{
				lbMensagem.Text = "Senha inválida!";
				tbSenha.SelectAll();
				tbSenha.Focus();
				return false;
			}

			_usuarioOperacao = _dsoftBd.CarregarUsuario(codigo);

			return true;
		}

		private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbObs.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void tbUsuario_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbSenha.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbObs_TextChanged(object sender, EventArgs e)
		{
			if (tbObs.Text.Length > 0)
			{
				if (lbMensagemObs.Text != string.Empty)
				{
					lbMensagemObs.Text = string.Empty;
				}
			}
			else
			{
				lbMensagemObs.Text = "Observação precisa ser preenchida!";
			}
		}

		private void tbSenha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				confirmButton1.Focus();
			}
		}

		private void tbObs_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbObs.Lines.Count() > 1)
			{
				tbSenha.Focus();
			}
		}

		private void tbUsuario_Leave(object sender, EventArgs e)
		{
			int codigo;
			int.TryParse(tbUsuario.Text, out codigo);

			if (codigo > 0)
			{
				lbUsuario.Text = _dsoftBd.UsuarioNome(codigo);
			}
		}
	}
}
