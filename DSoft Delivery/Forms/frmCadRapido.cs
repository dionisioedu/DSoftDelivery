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
using DSoftParameters;
using DSoftCore;

namespace DSoft_Delivery.Forms
{
	public partial class frmCadRapido : Form
	{
		#region Fields

		public long Codigo;
		public string Nome;
		public string Auxiliar;

		private Cliente _cliente;
		private Bd _dsoftBd;
		private Usuario _usuario;

		public Cliente Cliente
		{
			get
			{
				return _cliente;
			}
		}

		#endregion Fields

		#region Constructors

		public frmCadRapido(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		public frmCadRapido(Bd bd, Usuario usuario, long codigo)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Codigo = codigo;
		}

		public frmCadRapido(Bd bd, Usuario usuario, string nome)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			Nome = nome;
			tbNome.Text = nome;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			if (_cliente == null)
				_cliente = new Cliente();

			if (!long.TryParse(tbCodigo.Text, out _cliente.Codigo))
			{
				if (tbCodigo.Text.Contains('*'))
				{
					_cliente.Codigo = _dsoftBd.ProximoCodigoCliente();
					_cliente.Auxiliar = tbCodigo.Text;
				}
				else
				{
					MessageBox.Show("Código inválido!", Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbCodigo.Focus();
					return;
				}
			}

			if (tbNome.Text.Length < 1)
			{
				MessageBox.Show("Nome não pode ser vazio!", Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				tbNome.Focus();
				return;
			}

			_cliente.Nome = tbNome.Text;

			_cliente.Telefone1 = (tbTel1.TextLength > 0) ? Convert.ToInt64(tbTel1.Text) : 0;
			_cliente.Telefone2 = (tbTel2.TextLength > 0) ? Convert.ToInt64(tbTel2.Text) : 0;
			_cliente.Celular = (tbCel.TextLength > 0) ? Convert.ToInt64(tbCel.Text) : 0;

			_cliente.Cep = mbCep.Text;

			_cliente.Endereco = tbEndereco.Text;
			_cliente.Bairro = tbBairro.Text;
			_cliente.Cidade = tbCidade.Text;
			_cliente.Estado = cbEstado.Text;

			_cliente.Referencia = tbReferencia.Text;

			if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
			{
				ClienteGrupo grupo = cbBairro.SelectedItem as ClienteGrupo;

				if (grupo != null)
				{
					_cliente.Grupo = grupo.Codigo;
					_cliente.Bairro = grupo.Nome;
				}
				else
				{
					_cliente.Grupo = 1;
				}
			}
			else
			{
				if (_cliente.Grupo == 0)
					_cliente.Grupo = 1;
			}

			_cliente.Tipo = 'F';

			_cliente.ClienteTipo = _dsoftBd.CarregarClienteTipo(1);

			_cliente.Nascimento = DateTime.Now;

			if (RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente)
			{
				decimal taxa;
				decimal.TryParse(tbTaxaDeEntrega.Text, out taxa);
				_cliente.TaxaDeEntrega = taxa;
			}

			if (_dsoftBd.ClienteCadastrado(_cliente.Codigo))
			{
				_dsoftBd.AlterarCliente(_cliente);
			}
			else
			{
				_dsoftBd.NovoCliente(_cliente, Licenca.Instance);
			}

			Codigo = _cliente.Codigo;
			this.DialogResult = System.Windows.Forms.DialogResult.OK;

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void frmCadRapido_Load(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
			{
				tbBairro.Visible = false;
				cbBairro.Location = tbBairro.Location;
				llCadastroGrupos.Visible = true;

				CarregarGrupos();
			}
			else
			{
				llCadastroGrupos.Visible = false;
				cbBairro.Visible = false;
			}

			pnTaxaDeEntrega.Visible = RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente;

			CarregarEstados();

			if (Codigo > 0)
			{
				tbCodigo.Text = Codigo.ToString();

				if (_dsoftBd.ClienteCadastrado(Codigo))
				{
					tbCodigo.ReadOnly = true;

					_cliente = new Cliente(Codigo);

					_dsoftBd.CarregarDadosCliente(_cliente);

					tbNome.Text = _cliente.Nome;
					tbTel1.Text = _cliente.Telefone1.ToString();
					tbTel2.Text = _cliente.Telefone2.ToString();
					tbCel.Text = _cliente.Celular.ToString();
					mbCep.Text = _cliente.Cep;
					tbEndereco.Text = _cliente.Endereco;
					tbReferencia.Text = _cliente.Referencia;

					if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
					{
						ClienteGrupo grupo = _dsoftBd.CarregarClientesGrupo(_cliente.Grupo);
						cbBairro.SelectedItem = grupo;
					}
					else
					{
						tbBairro.Text = _cliente.Bairro;
					}
				}
			}
			else if (!string.IsNullOrEmpty(Auxiliar))
			{
				tbCodigo.Text = Auxiliar;
			}

			tbCodigo.Focus();
		}

		private void CarregarGrupos()
		{
			List<ClienteGrupo> grupos = _dsoftBd.CarregarClientesGrupos();

			cbBairro.Items.Clear();

			if (grupos != null && grupos.Count > 0)
			{
				cbBairro.Items.AddRange(grupos.ToArray());
				cbBairro.SelectedIndex = 0;
			}
		}

		private void CarregarEstados()
		{
			List<string> estados = _dsoftBd.CarregarEstados();

			cbEstado.Items.Clear();

			if (estados != null && estados.Count > 0)
			{
				cbEstado.Items.AddRange(estados.ToArray());
			}
		}

		private void llCompleta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CadClientes form = new CadClientes(_dsoftBd, _usuario, Licenca.Instance);
			form.Codigo = Codigo;
			form.Consulta = true;
			form.ShowDialog();
			_cliente = form.Cliente;
			this.DialogResult = form.DialogResult;
			Close();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbBairro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbReferencia.Focus();
			}
		}

		private void tbCel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (RegrasDeNegocio.Instance.BuscaEnderecoPorCep)
				{
					mbCep.Focus();
				}
				else
				{
					tbEndereco.Focus();
				}
			}
		}

		private void tbCodigo_Leave(object sender, EventArgs e)
		{
			if (tbCodigo.Text.Length > 0)
			{
				if (RegrasDeNegocio.Instance.Ramo == "PIZZARIA")
				{
					long tel;
					long.TryParse(tbCodigo.Text, out tel);

					if (tel > 0)
					{
						tbTel1.Text = tbCodigo.Text;
					}
				}
				else if (RegrasDeNegocio.Instance.Ramo == "LOCADORA")
				{
					tbCpf.Text = tbCodigo.Text;
				}
			}
		}

		private void tbEndereco_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
				{
					cbBairro.Focus();
				}
				else
				{
					tbBairro.Focus();
				}
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTel1.Focus();
			}
		}

		private void tbReferencia_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void tbTel1_Enter(object sender, EventArgs e)
		{
			if (tbTel1.Text.Length > 0)
			{
				tbTel1.SelectAll();
			}
		}

		private void tbTel1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTel2.Focus();
			}
		}

		private void tbTel2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCel.Focus();
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbNome.Focus();
			}
		}

		private void cbBairro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
				{
					ClienteGrupo grupo = cbBairro.SelectedItem as ClienteGrupo;

					if (grupo != null)
					{
						tbCidade.Text = grupo.Cidade;
						cbEstado.Text = grupo.Estado;

						tbReferencia.Focus();
					}
					else
					{
						tbCidade.Focus();
					}
				}
				else
				{
					tbReferencia.Focus();
				}
			}
		}

		private void tbTel1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != '*')
			{
				e.Handled = true;
			}
		}

		private void tbTel2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbCel_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void PreencherEndereco()
		{
			if (RegrasDeNegocio.Instance.BuscaEnderecoPorCep)
			{
				int cep;

				if (int.TryParse(Util.LimpaFormatacao(mbCep.Text), out cep) && cep > 0)
				{
					Endereco endereco = _dsoftBd.BuscaEndereco(cep);

					if (endereco != null)
					{
						if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
						{
							ClienteGrupo grupo = _dsoftBd.ClienteGrupo(endereco.Bairro.ToUpper(), endereco.Cidade.ToUpper());

							if (grupo != null)
							{
								cbBairro.SelectedItem = grupo;

								if (RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente)
								{
									tbTaxaDeEntrega.Text = grupo.Taxa.ToString("##,###,##0.00");
								}
							}
							else
							{
								if (MessageBox.Show(string.Format("Bairro ({0}) de {1} não está cadastrado no sistema. Gostaria incluir novo bairro?",
									endereco.Bairro.ToUpper(), endereco.Cidade.ToUpper()), this.Text,
									MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
								{
									Usuario usuario = _usuario;

									if (!_usuario.NivelUsuario.Administrador && !_usuario.NivelUsuario.CadastrarGruposDeClientes)
									{
										frmUsuarioAutorizacao form = new frmUsuarioAutorizacao(_dsoftBd, _usuario);

										if (form.ShowDialog() == DialogResult.Cancel || form.UsuarioAutorizado == null)
										{
											usuario = null;
										}

										if (!form.UsuarioAutorizado.NivelUsuario.Administrador && !form.UsuarioAutorizado.NivelUsuario.CadastrarGruposDeClientes)
										{
											MessageBox.Show("Usuário não tem permissão para cadastrar grupos de clientes!");
											usuario = null;
										}
									}

									if (usuario != null)
									{
										CadClientesGrupos form = new CadClientesGrupos(_dsoftBd, usuario, endereco.Bairro.ToUpper(), endereco.Cidade.ToUpper(), endereco.UFCompleto.ToUpper());

										if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
										{
											CarregarGrupos();

											PreencherEndereco(); //RECURSIVIDADE

											return;
										}
									}
								}
							}
						}
						else
						{
							tbBairro.Text = endereco.Bairro.ToUpper();
						}

						tbCidade.Text = endereco.Cidade;
						cbEstado.Text = endereco.UFCompleto;

						tbEndereco.Text = endereco.Logradouro.ToUpper() + ", ";
						tbEndereco.SelectionLength = 0;
						tbEndereco.SelectionStart = tbEndereco.Text.Length;
						tbEndereco.Focus();
					}
				}
				else
				{
					tbEndereco.Focus();
				}
			}
			else
			{
				tbEndereco.Focus();
			}
		}

		private void mbCep_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				PreencherEndereco();
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

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
				if (RegrasDeNegocio.Instance.TaxaDeEntregaPorCliente)
				{
					tbTaxaDeEntrega.Focus();
				}
				else
				{
					tbReferencia.Focus();
				}
			}
		}

		private void tbTaxaDeEntrega_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbReferencia.Focus();
			}
		}

		private void tbTaxaDeEntrega_Enter(object sender, EventArgs e)
		{
			tbTaxaDeEntrega.SelectAll();
		}

		private void tbTaxaDeEntrega_Leave(object sender, EventArgs e)
		{
			decimal taxa;
			decimal.TryParse(tbTaxaDeEntrega.Text, out taxa);
			tbTaxaDeEntrega.Text = taxa.ToString("##,###,##0.00");
		}

		private void llCadastroGrupos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CadClientesGrupos form = new CadClientesGrupos(_dsoftBd, _usuario, true);

			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (form.ClienteGrupo != null)
				{
					cbBairro.Items.Add(form.ClienteGrupo);
					cbBairro.SelectedItem = form.ClienteGrupo;

					tbCidade.Text = form.ClienteGrupo.Cidade;
					cbEstado.Text = form.ClienteGrupo.Estado;

					tbReferencia.Focus();
				}
			}
		}

		#endregion Methods
	}
}