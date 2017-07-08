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
	public partial class frmCadMateriais : Form
	{
		#region Fields

		public bool Consulta = false;

		static bool Editando = false;

		private Bd _DSoftBd;
		private Usuario _usuario;

		public long CodigoProduto;
		private Material _material;

		public Material Material
		{
			get
			{
				return _material;
			}
		}

		#endregion Fields

		#region Constructors

		public frmCadMateriais(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Alterar()
		{
			if (AlterarMaterial())
			{
				LimparDados();
			}
		}

		private bool AlterarMaterial()
		{
			try
			{
				Material material = new Material();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido.");

					return false;
				}

				if (!int.TryParse(tbCodigo.Text, out material.Codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico.");

					return false;
				}

				if ((material.Nome = tbNome.Text) == string.Empty)
				{
					MessageBox.Show("Campo 'nome' não pod ser vazio.");

					return false;
				}

				if (cbTipo.Text.Length > 0 && !int.TryParse(cbTipo.Text.Split(" - ".ToCharArray(), 2)[0], out material.Tipo))
				{
					MessageBox.Show("Campo 'tipo' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbTipo.SelectAll();

					cbTipo.Focus();

					return false;
				}

				if (cbMedida.Text.Length > 0 && !int.TryParse(cbMedida.Text.Split(" - ".ToCharArray(), 2)[0], out material.Medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbMedida.SelectAll();

					cbMedida.Focus();

					return false;
				}

				if (cbFornecedor.Text.Length > 0 && !int.TryParse(cbFornecedor.Text.Split(" - ".ToCharArray(), 2)[0], out material.Fornecedor))
				{
					MessageBox.Show("Campo 'fornecedor' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbFornecedor.SelectAll();

					cbFornecedor.Focus();

					return false;
				}

				return _DSoftBd.AlterarMaterial(material);
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

				_DSoftBd.MateriaisCadastrados(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["codigo"].Width = 60;
				dataGridView1.Columns["codigo"].HeaderText = "Codigo";
				dataGridView1.Columns["nome"].Width = 210;
				dataGridView1.Columns["nome"].HeaderText = "Nome";
				dataGridView1.Columns["fornecedor"].Width = 180;
				dataGridView1.Columns["fornecedor"].HeaderText = "Fornecedor";
				dataGridView1.Columns["tipo"].Width = 90;
				dataGridView1.Columns["tipo"].HeaderText = "Tipo";
				dataGridView1.Columns["medida"].Width = 90;
				dataGridView1.Columns["medida"].HeaderText = "Medida";
				dataGridView1.Columns["situacao"].Width = 60;
				dataGridView1.Columns["situacao"].HeaderText = "Situacao";
				dataGridView1.Columns["cadastro"].Width = 90;
				dataGridView1.Columns["cadastro"].HeaderText = "Cadastro";
				dataGridView1.Columns["usuario"].Width = 90;
				dataGridView1.Columns["usuario"].HeaderText = "Usuario";

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

				CarregarFornecedores();
				CarregarMedidas();
				CarregarTipos();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao atualizar os dados." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Bloquear()
		{
		}

		private bool BloquearMaterial()
		{
			return true;
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
			Fechar();
		}

		private void Cancelar()
		{
			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (CancelarMaterial())
				{
					LimparDados();

					Atualizar();
				}
			}
			else
			{
				if (ReativarMaterial())
				{
					LimparDados();

					Atualizar();
				}
			}
		}

		private bool CancelarMaterial()
		{
			return _DSoftBd.CancelarMaterial(int.Parse(tbCodigo.Text));
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarFornecedores()
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.CarregarFornecedores(ds);

				cbFornecedor.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbFornecedor.Items.Add(ds.Tables[0].Rows[i].ItemArray[0] + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar fornecedores." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarMedidas()
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.Medidas(ds);

				cbMedida.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbMedida.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar medidas." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarRegistro()
		{
			int row;

			if (dataGridView1.SelectedRows.Count < 1)
			{
				return;
			}

			Editando = true;

			btConfirmar.Text = "&Confirmar - F2";

			groupBox1.Enabled = true;

			LimparCampos();

			tbCodigo.ReadOnly = true;

			row = dataGridView1.SelectedRows[0].Index;

			tbCodigo.Text = dataGridView1.Rows[row].Cells["codigo"].Value.ToString();
			tbNome.Text = dataGridView1.Rows[row].Cells["nome"].Value.ToString();
			cbTipo.Text = dataGridView1.Rows[row].Cells["cod_tipo"].Value.ToString() + " - " + dataGridView1.Rows[row].Cells["tipo"].Value.ToString();
			cbMedida.Text = dataGridView1.Rows[row].Cells["cod_medida"].Value.ToString() + " - " + dataGridView1.Rows[row].Cells["medida"].Value.ToString();
			cbFornecedor.Text = dataGridView1.Rows[row].Cells["cod_fornecedor"].Value.ToString() + " - " + dataGridView1.Rows[row].Cells["fornecedor"].Value.ToString();

			btCancelar.Enabled = true;

			if (dataGridView1.Rows[row].Cells["situacao"].Value.ToString() == "A")
			{
				btCancelar.Text = "&Cancelar - F4";
			}
			else
			{
				btCancelar.Text = "&Reativar - F4";
			}
		}

		private void CarregarTipos()
		{
			try
			{
				DataSet ds = new DataSet();

				_DSoftBd.TiposMateriais(ds);

				cbTipo.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbTipo.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar tipos de materiais." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbMedida.Focus();
			}
		}

		private void comboBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbFornecedor.Focus();
			}
		}

		private void comboBox3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarRegistro();
		}

		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
		}

		private bool DessbloquearMaterial()
		{
			return true;
		}

		private void Fechar()
		{
			this.Close();
		}

		private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Fechar();
		}

		private void frmCadMateriais_Load(object sender, EventArgs e)
		{
			Atualizar();

			LimparDados();
		}

		private void Incluir()
		{
			if (btConfirmar.Text == "&Incluir - F2")
			{
				groupBox1.Enabled = true;

				btConfirmar.Text = "Confirmar - F2";

				tbCodigo.ReadOnly = false;
				tbCodigo.Focus();
			}
			else
			{
				if (Editando)
				{
					if (AlterarMaterial())
					{
						Editando = false;

						btConfirmar.Text = "&Incluir - F2";

						LimparDados();

						groupBox1.Enabled = false;

						Atualizar();
					}
				}
				else
				{
					if (IncluirMaterial())
					{
						if (Consulta)
						{
							CodigoProduto = long.Parse(tbCodigo.Text);

							Fechar();
						}

						groupBox1.Enabled = false;

						btConfirmar.Text = "&Incluir - F2";

						LimparDados();
					}
				}
			}
		}

		private bool IncluirMaterial()
		{
			try
			{
				Material material = new Material();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.Focus();

					return false;
				}

				if (!int.TryParse(tbCodigo.Text, out material.Codigo))
				{
					MessageBox.Show("Campo 'código' inválido!. Campo deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.Focus();

					return false;
				}

				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbNome.Focus();

					return false;
				}

				material.Nome = tbNome.Text;

				if (cbTipo.Text.Length > 0 && !int.TryParse(cbTipo.Text.Split(" - ".ToCharArray(), 2)[0], out material.Tipo))
				{
					MessageBox.Show("Campo 'tipo' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbTipo.SelectAll();

					cbTipo.Focus();

					return false;
				}

				if (cbMedida.Text.Length > 0 && !int.TryParse(cbMedida.Text.Split(" - ".ToCharArray(), 2)[0], out material.Medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbMedida.SelectAll();

					cbMedida.Focus();

					return false;
				}

				if (cbFornecedor.Text.Length > 0 && !int.TryParse(cbFornecedor.Text.Split(" - ".ToCharArray(), 2)[0], out material.Fornecedor))
				{
					MessageBox.Show("Campo 'fornecedor' inválido! Selecione uma opção válida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					cbFornecedor.SelectAll();

					cbFornecedor.Focus();

					return false;
				}

				return _DSoftBd.NovoMaterial(material);
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao incluir material." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			cbTipo.Text = string.Empty;
			cbMedida.Text = string.Empty;
			cbFornecedor.Text = string.Empty;
		}

		private void LimparDados()
		{
			LimparCampos();

			btConfirmar.Text = "&Incluir - F2";
			btConfirmar.Enabled = true;

			btCancelar.Text = "&Cancelar - F4";
			btCancelar.Enabled = false;

			btLimparDados.Text = "Limpar Dados";

			btSair.Text = "&Sair - F10";

			lbAviso.Text = string.Empty;
			//lbTipo.Text = string.Empty;
			//lbGrupo.Text = string.Empty;

			groupBox1.Enabled = false;

			Atualizar();

			btConfirmar.Focus();
		}

		private bool ReativarMaterial()
		{
			return _DSoftBd.ReativarMaterial(int.Parse(tbCodigo.Text));
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbNome.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long numero;

			if (tbCodigo.Text.Length > 0)
			{
				if (!long.TryParse(tbCodigo.Text, out numero))
				{
					MessageBox.Show("Campo 'código' deve ser numérico.", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbTipo.Focus();
			}
		}

		#endregion Methods
	}
}