using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftModels;
using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class CadClientesGrupos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;
		private bool _apenasCadastrar = false;
		private string _estado = string.Empty;
		public ClienteGrupo ClienteGrupo = null;

		#endregion Fields

		#region Constructors

		public CadClientesGrupos(Bd bd, Usuario usuario, bool apenasCadastrar = false)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			_apenasCadastrar = apenasCadastrar;
		}

		public CadClientesGrupos(Bd bd, Usuario usuario, string novoGrupo, string cidade, string estado)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			_apenasCadastrar = true;

			tbCodigo.Text = _dsoftBd.ProximoCodigoClienteGrupo().ToString();
			tbNome.Text = novoGrupo;
			tbCidade.Text = cidade;
			_estado = estado;
			tbTaxa.Focus();
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.GruposClientes(ds);

				dgGrupos.DataSource = ds.Tables[0];

				for (int i = 0; i < dgGrupos.Rows.Count; i++)
				{
					switch (dgGrupos.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dgGrupos.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgGrupos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dgGrupos.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dgGrupos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dgGrupos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgGrupos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}
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

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
		}

		private void Confirmar()
		{
			try
			{
				int codigo;
				string nome;
				decimal taxa;
				decimal servico;

				if (tbCodigo.Text != string.Empty && int.TryParse(tbCodigo.Text, out codigo))
				{
					if (tbNome.Text == string.Empty)
					{
						MessageBox.Show("Campo 'nome' deve ser preenchido!");

						return;
					}

					nome = string.Copy(tbNome.Text);

					decimal.TryParse(tbTaxa.Text, out taxa);
					decimal.TryParse(tbServico.Text, out servico);

					ClienteGrupo grupo = new ClienteGrupo();
					grupo.Codigo = codigo;
					grupo.Nome = nome;
					grupo.Taxa = taxa;
					grupo.TaxaDeServico = servico;
					grupo.Cidade = tbCidade.Text;
					grupo.Estado = cbEstado.Text;

					if (_dsoftBd.GrupoClienteExiste(codigo))
					{
						if (_dsoftBd.AlterarGrupoClientes(grupo))
						{
							if (_apenasCadastrar)
							{
								this.DialogResult = System.Windows.Forms.DialogResult.OK;

								ClienteGrupo = grupo;

								this.Close();
							}
							else
							{
								LimparDados();

								for (int i = 0; i < dgGrupos.Rows.Count; i++)
								{
									if (Convert.ToInt32(dgGrupos["codigo", i].Value) == grupo.Codigo)
									{
										dgGrupos["nome", i].Value = grupo.Nome;
										dgGrupos["taxa_entrega", i].Value = grupo.Taxa;
										dgGrupos["taxa_servico", i].Value = grupo.TaxaDeServico;
										dgGrupos["cidade", i].Value = grupo.Cidade;
										dgGrupos["estado", i].Value = grupo.Estado;

										break;
									}
								}
							}
						}
					}
					else
					{
						if (_dsoftBd.NovoGrupoClientes(grupo))
						{
							if (_apenasCadastrar)
							{
								this.DialogResult = System.Windows.Forms.DialogResult.OK;

								ClienteGrupo = grupo;

								this.Close();
							}
							else
							{
								Atualizar();

								LimparDados();
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Campo 'código' inválido!");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void frmCadClientesGrupos_Load(object sender, EventArgs e)
		{
			CarregarEstados();
			Atualizar();
		}

		private void CarregarEstados()
		{
			cbEstado.Items.Clear();

			List<string> estados = _dsoftBd.CarregarEstados();

			if (estados != null && estados.Count > 0)
			{
				cbEstado.Items.AddRange(estados.ToArray());
			}

			cbEstado.Text = _estado;
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void LimparDados()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			tbTaxa.Clear();
			tbServico.Clear();
			tbCidade.Clear();

			tbCodigo.Focus();
		}

		private void listagemDosGruposDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//try
			//{
			//    DataSet ds = new DataSet();

			//    _dsoftBd.ClientesGrupos(ds);

			//    RelatorioHtml relatorio = new RelatorioHtml();

			//    relatorio.Titulo = relatorio.Arquivo = "Listagem Grupos Clientes";

			//    relatorio.Descricao = "Listagem de todos os grupos de clientes cadastrados no sistema. Relatorio emitido em " + DateTime.Now.ToShortDateString() + " as " + DateTime.Now.ToShortTimeString();

			//    relatorio.Gerar(ds);
			//}
			//catch (Exception erro)
			//{
			//    MessageBox.Show(erro.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void dgGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				tbCodigo.Text = dgGrupos["codigo", e.RowIndex].Value.ToString();
				tbNome.Text = dgGrupos["nome", e.RowIndex].Value.ToString();
				tbTaxa.Text = dgGrupos["taxa_entrega", e.RowIndex].Value.ToString();
				tbServico.Text = dgGrupos["taxa_servico", e.RowIndex].Value.ToString();
				tbCidade.Text = dgGrupos["cidade", e.RowIndex].Value.ToString();
				cbEstado.Text = dgGrupos["estado", e.RowIndex].Value.ToString();
			}
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbCodigo.Text.Length > 0)
			{
				int codigo;

				if (int.TryParse(tbCodigo.Text, out codigo) && codigo > 0)
				{
					tbNome.Focus();
				}
			}
		}

		private void tbNome_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbNome.Text.Length > 0)
			{
				tbTaxa.Focus();
			}
		}

		private void tbTaxa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbServico.Focus();
			}
		}

		private void tbTaxa_Leave(object sender, EventArgs e)
		{
			if (tbTaxa.Text.Length > 0)
			{
				decimal valor;
				decimal.TryParse(tbTaxa.Text, out valor);

				tbTaxa.Text = valor.ToString("##,###,##0.00");
			}
		}

		private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
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
				btConfirmar.Focus();
			}
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{

		}

		private void tbServico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (RegrasDeNegocio.Instance.TaxaEntregaPorGrupo)
				{
					tbCidade.Focus();
				}
				else
				{
					btConfirmar.Focus();
				}
			}
		}

		#endregion Methods
	}
}