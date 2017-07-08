using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftModels;
using DSoftBd;
using DSoftParameters;
using DSoftCore;

namespace DSoft_Delivery.Forms
{
	public partial class frmLancamentoOS : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private OrdemDeServico _ordemDeServico;
		private Endereco _endereco;
		private List<Periodo> _periodos = null;

		public frmLancamentoOS(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmLancamentoOS_Load(object sender, EventArgs e)
		{
			CarregarFuncionarios();
			CarregarTiposDeServico();
			CarregarPeriodos();
			CarregarOS();
			Limpar();
		}

		private void CarregarFuncionarios()
		{
			List<Recurso> recursos = _dsoftBd.CarregarRecursos();

			if (recursos != null && recursos.Count > 0)
			{
				cbFuncionario.Items.AddRange(recursos.ToArray());
				cbFuncionario.SelectedIndex = 0;
			}
		}

		private void CarregarPeriodos()
		{
			_periodos = _dsoftBd.Periodos();

			cbPeriodo.Items.AddRange(_periodos.ToArray());
		}

		private void CarregarOS()
		{
			DataTable dt = _dsoftBd.CarregarOS();

			dataGridView1.DataSource = dt;

			dataGridView1.Columns["numero"].HeaderText = "Número";
			dataGridView1.Columns["abertura"].HeaderText = "Lançamento";
			dataGridView1.Columns["tipo"].Visible = false;
			dataGridView1.Columns["tipo_descricao"].HeaderText = "Tipo Serv.";
			dataGridView1.Columns["status"].HeaderText = "Status";
			dataGridView1.Columns["funcionario"].Visible = false;
			dataGridView1.Columns["funcionario_nome"].HeaderText = "Funcionário";
			dataGridView1.Columns["fechamento"].HeaderText = "Encerramento";
			dataGridView1.Columns["periodo"].HeaderText = "Período";
			dataGridView1.Columns["cliente"].HeaderText = "Cliente";
			dataGridView1.Columns["observacao"].HeaderText = "Observação";
			dataGridView1.Columns["usuario"].Visible = false;
			dataGridView1.Columns["usuario_nome"].HeaderText = "Usuário";

			if (dataGridView1.Rows.Count > 2)
			{
				dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
			}

			PintarGrid();
		}

		private void PintarGrid()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1["status", i].Value.ToString())
				{
					case "A": //AGENDADO
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C": //CANCELADO
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "E": //EXECUTADO
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "R": //REAGENDADO
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;
				}
			}
		}

		private void CarregarTiposDeServico()
		{
			List<TipoDeServico> tiposDeServico = _dsoftBd.TiposDeServico();

			if (tiposDeServico != null && tiposDeServico.Count > 0)
			{
				cbServico.Items.Clear();
				cbServico.Items.AddRange(tiposDeServico.ToArray());

				cbServico.SelectedIndex = 0;
			}
		}

		private void Lancar()
		{
			OrdemDeServico ordemDeServico = LerOrdemDeServico();

			if (ordemDeServico != null)
			{
				if (tbNumero.Enabled == true)
				{
					if (_dsoftBd.IncluirOS(ordemDeServico, _usuario))
					{
						SalvarCliente();
						Limpar();
						CarregarOS();
					}
				}
				else
				{
					if (_dsoftBd.AlterarOS(ordemDeServico, _usuario))
					{
						SalvarCliente();
						Limpar();
						CarregarOS();
					}
				}
			}
		}

		private void SalvarCliente()
		{
			if (tbCliente.Text.Length > 0)
			{
				Cliente cliente = new Cliente();
				cliente.Codigo = Convert.ToInt64(tbCliente.Text);
				cliente.Nome = tbNome.Text;
				cliente.Telefone1 = Convert.ToInt64(tbTelefone.Text);

				if (_endereco != null)
				{
					cliente.Cep = _endereco.CEP.ToString("00000-000");
					cliente.Endereco = _endereco.Logradouro;
					cliente.Numero = tbNumeroEnd.Text;
					cliente.Bairro = _endereco.Bairro;
					cliente.Cidade = _endereco.Cidade;
					cliente.Estado = _endereco.Estado;
				}

				_dsoftBd.InsertOrUpdate(cliente);
			}
		}

		private OrdemDeServico LerOrdemDeServico()
		{
			OrdemDeServico ordemDeServico = new OrdemDeServico();

			if (tbNumero.Text.Length < 1)
			{
				tbNumero.Focus();
				return null;
			}

			int numero;
			int.TryParse(tbNumero.Text, out numero);

			if (numero < 1)
			{
				tbNumero.SelectAll();
				tbNumero.Focus();
				return null;
			}

			ordemDeServico.Numero = numero;

			if (tbCliente.Text.Length > 0)
			{
				long cliente;
				long.TryParse(tbCliente.Text, out cliente);

				ordemDeServico.Cliente = cliente;
			}

			if (cbFuncionario.Text.Length > 0)
			{
				Recurso recurso = cbFuncionario.SelectedItem as Recurso;

				if (recurso == null)
				{
					cbFuncionario.SelectAll();
					cbFuncionario.Focus();
					return null;
				}

				ordemDeServico.Funcionario = recurso;
			}

			if (cbStatus.SelectedItem == null)
			{
				cbStatus.Focus();
				return null;
			}

			ordemDeServico.Status = cbStatus.SelectedItem.ToString()[0].ToString();

			if (cbPeriodo.SelectedItem == null)
			{
				cbPeriodo.Focus();
				return null;
			}

			ordemDeServico.Periodo = cbPeriodo.SelectedItem as Periodo;

			TipoDeServico servico;

			if (cbServico.SelectedItem == null || (servico = cbServico.SelectedItem as TipoDeServico) == null)
			{
				cbServico.Focus();
				return null;
			}

			ordemDeServico.Tipo = servico;
			ordemDeServico.Abertura = dtLancamento.Value;
			ordemDeServico.Observacao = tbObservacoes.Text;

			return ordemDeServico;
		}

		private void Baixar()
		{
			if (tbNumero.Enabled == false)
			{
				if (_ordemDeServico.Status == "A" || _ordemDeServico.Status == "R") // Está editando e em aberto
				{
					if (_dsoftBd.BaixarOS(_ordemDeServico, DateTime.Today, _usuario))
					{
						Limpar();
						CarregarOS();
					}
				}
				else if (_ordemDeServico.Status == "E")
				{
					if (_dsoftBd.ReabrirOS(_ordemDeServico, _usuario))
					{
						Limpar();
						CarregarOS();
					}
				}
			}
		}

		private void Reagendar()
		{
			if (tbNumero.Enabled == false)
			{
				if (_ordemDeServico != null && (_ordemDeServico.Status == "A" || _ordemDeServico.Status == "R"))
				{
					frmData form = new frmData();
					form.Titulo = "Reagendar para";

					if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						if (_dsoftBd.ReagendarOS(_ordemDeServico, form.Data, _usuario))
						{
							Limpar();
							CarregarOS();
						}
					}
				}
			}
		}

		private void Cancelar()
		{
			if (tbNumero.Enabled == false)
			{
				if (_ordemDeServico != null)
				{
					if (_ordemDeServico.Status == "A" || _ordemDeServico.Status == "R")
					{
						if (_dsoftBd.CancelarOS(_ordemDeServico, _usuario))
						{
							Limpar();
							CarregarOS();
						}
					}
					else if (_ordemDeServico.Status == "C")
					{
						if (_dsoftBd.ReativarOS(_ordemDeServico, _usuario))
						{
							Limpar();
							CarregarOS();
						}
					}
				}
			}
		}

		private void Limpar()
		{
			tbNumero.Enabled = true;

			tbNumero.Text = string.Empty;
			tbCliente.Text = string.Empty;
			cbFuncionario.SelectedItem = null;
			tbNome.Text = string.Empty;
			tbTelefone.Text = string.Empty;
			mbCep.Text = string.Empty;
			tbEndereco.Text = string.Empty;
			tbNumeroEnd.Text = string.Empty;
			tbObservacoes.Text = string.Empty;

			cbPeriodo.SelectedIndex = 0;
			cbServico.SelectedIndex = 0;
			cbStatus.SelectedIndex = 0;

			_endereco = null;

			btLancar.Text = "&Lançar F2";
			btBaixar.Text = "&Baixar F3";
			btCancelar.Text = "&Cancelar F4";

			btBaixar.Enabled = false;
			btCancelar.Enabled = false;

			tbNumero.Focus();
		}

		private void CarregarRegistro(int rowIndex)
		{
			_ordemDeServico = new OrdemDeServico();

			tbNumero.Enabled = false;
			tbNumero.Text = dataGridView1["numero", rowIndex].Value.ToString();

			_ordemDeServico.Numero = Convert.ToInt32(tbNumero.Text);

			tbCliente.Text = dataGridView1["cliente", rowIndex].Value.ToString();

			if (tbCliente.Text == "0")
				tbCliente.Text = string.Empty;

			int cliente;
			int.TryParse(tbCliente.Text, out cliente);

			_ordemDeServico.Cliente = cliente;

			if (cliente > 0)
			{
				CarregarCliente(cliente);
			}

			int funcionario;
			int.TryParse(dataGridView1["funcionario", rowIndex].Value.ToString(), out funcionario);

			if (funcionario > 0)
			{
				_ordemDeServico.Funcionario = _dsoftBd.CarregarRecurso(funcionario);
				cbFuncionario.Text = _ordemDeServico.Funcionario.ToString();
			}
			else
			{
				_ordemDeServico.Funcionario = null;
				cbFuncionario.SelectedItem = null;
			}

			switch (dataGridView1["status", rowIndex].Value.ToString())
			{
				case "A":
					cbStatus.Text = "AGENDADO";
					_ordemDeServico.Status = "A";

					tbCliente.Enabled = true;
					cbFuncionario.Enabled = true;
					cbPeriodo.Enabled = true;
					cbServico.Enabled = true;
					dtLancamento.Enabled = true;

					btLancar.Text = "Salvar F2";
					btLancar.Enabled = true;
					btBaixar.Text = "&Baixar F3";
					btBaixar.Enabled = true;
					btCancelar.Text = "&Cancelar F4";
					btCancelar.Enabled = true;

					break;

				case "C":
					cbStatus.Text = "CANCELADO";
					_ordemDeServico.Status = "C";

					tbCliente.Enabled = false;
					cbFuncionario.Enabled = false;
					cbPeriodo.Enabled = false;
					cbServico.Enabled = false;
					dtLancamento.Enabled = false;

					btLancar.Text = "&Lancar F2";
					btLancar.Enabled = false;
					btBaixar.Text = "&Baixar F3";
					btBaixar.Enabled = false;
					btCancelar.Text = "&Agendar F4";
					btCancelar.Enabled = true;

					break;

				case "E":
					cbStatus.Text = "EXECUTADO";
					_ordemDeServico.Status = "E";

					tbCliente.Enabled = false;
					cbFuncionario.Enabled = false;
					cbServico.Enabled = false;
					cbPeriodo.Enabled = false;
					dtLancamento.Enabled = false;

					btLancar.Text = "&Lançar F2";
					btLancar.Enabled = false;
					btBaixar.Text = "&Agendar F3";
					btBaixar.Enabled = true;
					btCancelar.Text = "&Cancelar F4";
					btCancelar.Enabled = false;

					break;

				case "R":
					cbStatus.Text = "REAGENDADO";
					_ordemDeServico.Status = "R";

					tbCliente.Enabled = true;
					cbFuncionario.Enabled = true;
					cbPeriodo.Enabled = true;
					cbServico.Enabled = true;
					dtLancamento.Enabled = true;

					btLancar.Text = "Salvar F2";
					btLancar.Enabled = true;
					btBaixar.Text = "&Baixar F3";
					btBaixar.Enabled = true;
					btCancelar.Text = "&Cancelar F4";
					btCancelar.Enabled = true;

					break;
			}

			_ordemDeServico.Periodo = _periodos.FirstOrDefault(p => p.Id == dataGridView1["periodo", rowIndex].Value.ToString());
			cbPeriodo.SelectedItem = _ordemDeServico.Periodo;

			_ordemDeServico.Tipo = _dsoftBd.CarregarTipoDeServico(dataGridView1["tipo", rowIndex].Value.ToString());

			cbServico.Text = dataGridView1["tipo_descricao", rowIndex].Value.ToString();

			dtLancamento.Value = Convert.ToDateTime(dataGridView1["abertura", rowIndex].Value);

			_ordemDeServico.Abertura = dtLancamento.Value;

			_ordemDeServico.Observacao = dataGridView1["observacao", rowIndex].Value.ToString();
			tbObservacoes.Text = _ordemDeServico.Observacao;
		}

		private void Sair()
		{
			this.Close();
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lancar();
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Baixar();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbNumero_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbFuncionario.Focus();
			}
		}

		private void tbCliente_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbNome.Focus();
			}
		}

		private void cbServico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtLancamento.Focus();
			}
		}

		private void btLancar_Click(object sender, EventArgs e)
		{
			Lancar();
		}

		private void btBaixar_Click(object sender, EventArgs e)
		{
			Baixar();
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

		private void cbStatus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbPeriodo.Focus();
			}
		}

		private void cbPeriodo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbServico.Focus();
			}
		}

		private void dtLancamento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCliente.Focus();
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			CarregarRegistro(e.RowIndex);
		}

		private void btReagendar_Click(object sender, EventArgs e)
		{
			Reagendar();
		}

		private void cbFuncionario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbPeriodo.Focus();
			}
		}

		private void tbTelefone_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void tbTelefone_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				mbCep.Focus();
			}
		}

		private void PreencherEndereco()
		{
			if (RegrasDeNegocio.Instance.BuscaEnderecoPorCep)
			{
				int cep;

				if (int.TryParse(Util.LimpaFormatacao(mbCep.Text), out cep) && cep > 0)
				{
					_endereco = _dsoftBd.BuscaEndereco(cep);

					if (_endereco != null)
					{
						tbEndereco.Text = _endereco.Logradouro.ToUpper();
						tbNumeroEnd.Focus();
					}
				}
				else
				{
					tbNumeroEnd.Focus();
				}
			}
			else
			{
				tbNumeroEnd.Focus();
			}
		}

		private void mbCep_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				PreencherEndereco();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbObservacoes.Focus();
			}
		}

		private void tbObservacoes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btLancar.Focus();
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTelefone.Focus();
			}
		}

		private void tbCliente_Leave(object sender, EventArgs e)
		{
			if (tbCliente.Text.Length > 0)
			{
				long codigo = Convert.ToInt64(tbCliente.Text);

				CarregarCliente(codigo);
			}
		}

		private void CarregarCliente(long codigo)
		{
			if (_dsoftBd.ClienteCadastrado(codigo))
			{
				Cliente cliente = _dsoftBd.CarregarCliente(codigo);

				tbNome.Text = cliente.Nome;
				tbTelefone.Text = cliente.Telefone1.ToString();
				mbCep.Text = cliente.Cep;
				tbEndereco.Text = cliente.Endereco;
				tbNumeroEnd.Text = cliente.Numero;

				if (cliente.Cep != string.Empty)
				{
					_endereco = _dsoftBd.BuscaEndereco(Convert.ToInt32(Util.LimpaFormatacao(cliente.Cep)));
				}
			}
		}
	}
}
