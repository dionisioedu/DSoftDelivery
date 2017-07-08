using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using DSoftBd;

using DSoftCore;

using DSoftModels;
using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmCadProdutos : Form
	{
		#region Fields

		public bool Consulta = false;
		public bool Editando = false;

		private long UltimoCodigo = 0;
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Produto _produto;

		public Produto Produto
		{
			get
			{
				return _produto;
			}
		}

		#endregion Fields

		#region Constructors

		public frmCadProdutos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void AdicionarMaterial()
		{
			try
			{
				int produto;
				int material;
				float quantidade;

				if (tbCodigo.Text.Length < 1)
				{
					return;
				}

				if (!int.TryParse(tbCodigo.Text, out produto))
				{
					return;
				}

				if (!int.TryParse(cbMaterial.Text.Split(" - ".ToCharArray())[0], out material))
				{
					return;
				}

				if (!float.TryParse(tbQuantidade.Text, out quantidade))
				{
					return;
				}

				if (_dsoftBd.VincularMaterial(produto, material, quantidade))
				{
					cbMaterial.Text = string.Empty;
					tbQuantidade.Clear();
					lbMedida.Text = "Medida";

					cbMaterial.Focus();

					AtualizarMateriais(produto);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao adicionar material." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Alterar()
		{
			if (AlterarProduto())
			{
				LimparDados();
			}
		}

		private bool AlterarProduto()
		{
			try
			{
				_produto = new Produto();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!");

					tbCodigo.Focus();

					return false;
				}

				long codigo = 0;

				if (!long.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' inválido!. Campo deve ser numérico!");

					tbCodigo.Focus();

					return false;
				}

				_produto.Codigo = codigo;

				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!");

					tbNome.Focus();

					return false;
				}

				int grupoTributario = 0;

				if (cbGrupoTributario.Text.Length > 0 && !int.TryParse(cbGrupoTributario.Text.Split(" - ".ToCharArray(), 2)[0], out grupoTributario))
				{
					MessageBox.Show("Campo 'grupo tributário' inválido! Campo deve ser numérico.", this.Text);

					cbGrupoTributario.SelectAll();
					cbGrupoTributario.Focus();

					return false;
				}

				_produto.GrupoTributario = grupoTributario;

				int medida = 0;

				if (cbMedida.Text.Length > 0 && !int.TryParse(cbMedida.Text.Split(" - ".ToCharArray(), 2)[0], out medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Campo deve ser numérico.", this.Text);

					cbMedida.SelectAll();
					cbMedida.Focus();

					return false;
				}

				_produto.Medida.Codigo = medida;

				medida = 0;

				if (cbMedidaTributaria.Text.Length > 0 && !int.TryParse(cbMedidaTributaria.Text.Split(" - ".ToCharArray(), 2)[0], out medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Campo deve ser numérico.", this.Text);

					cbMedidaTributaria.SelectAll();
					cbMedidaTributaria.Focus();

					return false;
				}

				_produto.MedidaTributavel.Codigo = medida;

				_produto.Nome = tbNome.Text;

				if (cbTipo.SelectedItem == null)
				{
					MessageBox.Show("O campo 'tipo' deve ser preenchido obrigatoriamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					cbTipo.Focus();
					return false;
				}

				ProdutoTipo tipo = cbTipo.SelectedItem as ProdutoTipo;

				if (tipo != null)
				{
					_produto.Tipo = tipo.Codigo;
				}

				if (cbGrupo.SelectedItem == null)
				{
					MessageBox.Show("Campo 'grupo' deve ser preenchido obrigatoriamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					cbGrupo.Focus();
					return false;
				}

				ProdutoGrupo grupo = cbGrupo.SelectedItem as ProdutoGrupo;

				if (grupo != null)
				{
					_produto.Grupo = (int)grupo.Codigo;
				}

				_produto.Descricao = tbDescricao.Text;

				_produto.Producao = cbProducao.Checked;

				if (cbFornecedor.Text.Length > 0)
				{
					_produto.Fornecedor = new Fornecedor();

					_produto.Fornecedor.Codigo = long.Parse(cbFornecedor.Text.Split(" - ".ToCharArray(), 2)[0]);
				}

				_produto.Foto = pbFoto.ImageLocation;
				_produto.NCM = tbNCM.Text;
				_produto.CFOP = tbCFOP.Text;
				_produto.EAN = tbEAN.Text;
				_produto.EANTrib = tbEANTrib.Text;

				int qtd_trib = 0;

				if (tbQtdTrib.Text.Length > 0 && !int.TryParse(tbQtdTrib.Text, out qtd_trib))
				{
					MessageBox.Show("Campo 'Quantidade Tributável' inválido!", Text);
					tbQtdTrib.SelectAll();
					tbQtdTrib.Focus();
					return false;
				}

				_produto.QuantidadeTributavel = qtd_trib;

				if (_dsoftBd.AlterarProduto(_produto))
				{
					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						if (Convert.ToInt64(dataGridView1["codigo", i].Value) == _produto.Codigo)
						{
							dataGridView1["nome", i].Value = _produto.Nome;

							if (tipo != null)
							{
								dataGridView1["nome1", i].Value = tipo.Nome;
							}

							if (grupo != null)
							{
								dataGridView1["descricao", i].Value = grupo.Descricao;
							}

							dataGridView1["descricao1", i].Value = _produto.Descricao;

							break;
						}
					}

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

				_dsoftBd.ProdutosCadastrados(ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["codigo"].Width = 60;
				dataGridView1.Columns["codigo"].HeaderText = "Codigo";
				dataGridView1.Columns["nome"].Width = 210;
				dataGridView1.Columns["nome"].HeaderText = "Nome";
				dataGridView1.Columns["tipo"].Visible = false;
				dataGridView1.Columns["nome1"].HeaderText = "Tipo";
				dataGridView1.Columns["grupo"].Visible = false;
				dataGridView1.Columns["descricao"].HeaderText = "Grupo";
				dataGridView1.Columns["descricao1"].Width = 180;
				dataGridView1.Columns["descricao1"].HeaderText = "Descricao";
				dataGridView1.Columns["situacao"].Width = 60;
				dataGridView1.Columns["situacao"].HeaderText = "Situacao";

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

				if (UltimoCodigo > 0)
				{
					int match = 0;

					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						if (UltimoCodigo >= long.Parse(dataGridView1.Rows[i].Cells["codigo"].Value.ToString()))
						{
							match = i;
						}
						else
						{
							break;
						}
					}

					dataGridView1.FirstDisplayedScrollingRowIndex = match;
					dataGridView1.Rows[match].Selected = true;

					UltimoCodigo = 0;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao atualizar os dados." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AtualizarAbas()
		{
			try
			{
				int tipo;

				tcProdutos.Enabled = false;

				if (cbTipo.Text == string.Empty)
					return;

				if (!int.TryParse(cbTipo.Text.Split(" - ".ToCharArray(), 2)[0], out tipo))
				{
					return;
				}

				if (_dsoftBd.ProdutoTipoProducao(tipo))
				{
					tcProdutos.Enabled = true;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao atualizar abas." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AtualizarMateriais(long produto)
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.MateriaisVinculados(produto, ds);

				dataGridView2.DataSource = ds.Tables[0];

				dataGridView2.Columns["material"].Width = 60;
				dataGridView2.Columns["material"].HeaderText = "Material";
				dataGridView2.Columns["nome"].Width = 90;
				dataGridView2.Columns["nome"].HeaderText = "Nome";
				dataGridView2.Columns["quantidade"].Width = 30;
				dataGridView2.Columns["quantidade"].HeaderText = "Qtd";
				dataGridView2.Columns["medida"].Width = 30;
				dataGridView2.Columns["medida"].HeaderText = "Medida";
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao atualizar materiais." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Bloquear()
		{
			if (button3.Text == "&Bloquear")
			{
				if (BloquearProduto())
				{
					LimparDados();
				}
			}
			else
			{
				if (DesbloquearProduto())
				{
					LimparDados();
				}
			}
		}

		private bool BloquearProduto()
		{
			try
			{
				if (_dsoftBd.BloquearProduto(int.Parse(tbCodigo.Text)))
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

		private void btMaterial_Click(object sender, EventArgs e)
		{
			AdicionarMaterial();
		}

		private void btRemover_Click(object sender, EventArgs e)
		{
			if (dataGridView2.SelectedRows.Count > 0)
			{
				int produto;
				int material;

				if (tbCodigo.Text.Length < 1 || !int.TryParse(tbCodigo.Text, out produto))
				{
					return;
				}

				if (!int.TryParse(dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells["material"].Value.ToString(), out material))
				{
					return;
				}

				if (_dsoftBd.DesvincularMaterial(produto, material))
				{
					AtualizarMateriais(produto);
				}
			}
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

		private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void Cancelar()
		{
			if (button4.Text == "&Cancelar - F4")
			{
				if (CancelarProduto())
				{
					LimparDados();
				}
			}
			else
			{
				if (ReativarProduto())
				{
					LimparDados();
				}
			}
		}

		private bool CancelarProduto()
		{
			try
			{
				long codigo = long.Parse(tbCodigo.Text);

				if (_dsoftBd.CancelarProduto(codigo))
				{
					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						if (Convert.ToInt64(dataGridView1["codigo", i].Value) == codigo)
						{
							dataGridView1["situacao", i].Value = "C";
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;

							break;
						}
					}

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

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarFornecedores()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.CarregarFornecedores(ds);

				cbFornecedor.Items.Clear();

				foreach (DataRow r in ds.Tables[0].Rows)
				{
					cbFornecedor.Items.Add(r.ItemArray[0].ToString() + " - " + r.ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar fornecedores." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarGrupos()
		{
			try
			{
				List<ProdutoGrupo> _grupos = _dsoftBd.ProdutosGrupos();

				cbGrupo.Items.Clear();

				if (_grupos != null && _grupos.Count > 0)
				{
					cbGrupo.Items.AddRange(_grupos.ToArray());

					cbGrupo.SelectedIndex = 0;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar grupos de produtos." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarGruposTributarios()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.GruposTributarios(ds);

				cbGrupoTributario.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbGrupoTributario.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar grupos tributários." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarMateriais()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.Materiais(ds);

				cbMaterial.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbMaterial.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar materiais." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarMedidas()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.Medidas(ds);

				cbMedida.Items.Clear();
				cbMedidaTributaria.Items.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					cbMedida.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());
					cbMedidaTributaria.Items.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString());

					cbMedida.SelectedIndex = 0;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar grupos tributários." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CarregarRegistro()
		{
			try
			{
				long codigo;

				LimparCampos();

				if (long.TryParse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["codigo"].Value.ToString(), out codigo) == false)
				{
					MessageBox.Show("Código inválido", "Cadastro de Produtos");

					return;
				}

				Produto produto = _dsoftBd.CarregarProduto(codigo);

				tbCodigo.Text = codigo.ToString();
				tbCodigo.ReadOnly = true;

				tbNome.Text = produto.Nome;

				if (produto.Tipo > 0)
				{
					cbTipo.Text = Util.Formata(produto.Tipo, _dsoftBd.ProdutoTipoNome(produto.Tipo));
				}

				if (produto.Grupo > 0)
				{
					cbGrupo.Text = Util.Formata(produto.Grupo, _dsoftBd.ProdutoGrupoDescricao(produto.Grupo));
				}

				if (produto.GrupoTributario > 0)
				{
					cbGrupoTributario.Text = Util.Formata(produto.GrupoTributario, _dsoftBd.GrupoTributarioDescricao(produto.GrupoTributario));
				}

				if (produto.Medida.Codigo > 0)
				{
					cbMedida.Text = Util.Formata(produto.Medida.Codigo, _dsoftBd.MedidaDescricao(produto.Medida.Codigo));
				}

				if (produto.MedidaTributavel.Codigo > 0)
				{
					cbMedidaTributaria.Text = Util.Formata(produto.MedidaTributavel.Codigo, _dsoftBd.MedidaDescricao(produto.MedidaTributavel.Codigo));
				}

				tbDescricao.Text = produto.Descricao;

				if (cbProducao.Checked = produto.Producao)
				{
					AtualizarMateriais(produto.Codigo);
				}

				if (produto.Fornecedor.Codigo > 0)
				{
					cbFornecedor.Text = Util.Formata(produto.Fornecedor.Codigo, _dsoftBd.FornecedorNome(produto.Fornecedor.Codigo));
				}

				if (produto.Foto != string.Empty)
				{
					if (File.Exists(produto.Foto))
					{
						pbFoto.Load(produto.Foto);
					}
				}

				tbNCM.Text = produto.NCM;
				tbCFOP.Text = produto.CFOP;
				tbEAN.Text = produto.EAN;
				tbEANTrib.Text = produto.EANTrib;

				tbQtdTrib.Text = produto.QuantidadeTributavel.ToString();

				switch (produto.Situacao)
				{
				case 'A':
					lbAviso.Text = "Produto Ativo!";

					btMaterial.Enabled = true;
					button3.Enabled = true;
					button4.Enabled = true;

					if (Consulta)
					{
						_produto = produto;
					}

					break;

				case 'B':
					lbAviso.Text = "Produto Bloqueado!";

					btMaterial.Enabled = true;
					button3.Enabled = true;
					button4.Enabled = true;

					button3.Text = "Des&bloquear";

					break;

				case 'C':
					lbAviso.Text = "Produto Cancelado!";

					button4.Enabled = true;

					button4.Text = "Reativar - F4";

					break;

				default:

					break;
				}

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					AtualizarAdicionais();
				}

				Editando = true;

				btIncluir.Text = "&Confirmar - F2";

				tcProdutos.Enabled = true;

				tbNome.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar registro." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
			}
		}

		private void CarregarTipos()
		{
			try
			{
				List<ProdutoTipo> _tipos = _dsoftBd.ProdutosTipos();

				cbTipo.Items.Clear();

				if (_tipos != null && _tipos.Count > 0)
				{
					cbTipo.Items.AddRange(_tipos.ToArray());

					cbTipo.SelectedIndex = 0;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao carregar tipos de produtos." + Environment.NewLine + e.Message, this.Text,
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbFornecedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
				cbFornecedor.SelectedItem = null;
		}

		private void cbGrupoTributario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbMedida.Focus();
			}
		}

		private void cbMaterial_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				tbQuantidade.Focus();
			}
		}

		private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMaterial.SelectedIndex < 0)
			{
				int material = int.Parse(cbMaterial.Text.Split(" - ".ToCharArray())[0]);

				lbMedida.Text = _dsoftBd.MedidaMaterial(material);
			}
		}

		private void cbMaterial_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbMaterial.Text.Length > 0)
				{
					int material = int.Parse(cbMaterial.Text.Split(" - ".ToCharArray())[0]);

					lbMedida.Text = _dsoftBd.MedidaMaterial(material);
				}
			}
			catch (Exception er)
			{
				MessageBox.Show(er.Message);
			}
		}

		private void cbMedida_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbDescricao.Focus();
			}
		}

		private void cbProducao_CheckedChanged(object sender, EventArgs e)
		{
			if (cbProducao.Checked == true)
			{
				cbMaterial.Enabled = true;
				tbQuantidade.Enabled = true;
				lbMedida.Enabled = true;
				btMaterial.Enabled = true;
				dataGridView2.Enabled = true;
			}
			else
			{
				cbMaterial.Enabled = false;
				tbQuantidade.Enabled = false;
				lbMedida.Enabled = false;
				btMaterial.Enabled = false;
				dataGridView2.Enabled = false;
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbGrupo.Focus();
			}
		}

		private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			//AtualizarAbas();
		}

		private void comboBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbMedida.Focus();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarRegistro();
		}

		private bool DesbloquearProduto()
		{
			try
			{
				if (_dsoftBd.DesbloquearProduto(int.Parse(tbCodigo.Text)))
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

		private void frmCadProdutos_Load(object sender, EventArgs e)
		{
			if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
			{
				pnAdicional.Enabled = true;
			}
			else
			{
				pnAdicional.Enabled = false;
			}

			CarregarTipos();
			CarregarGrupos();
			CarregarGruposTributarios();
			CarregarMedidas();
			CarregarFornecedores();

			CarregarMateriais();

			LimparDados();

			Atualizar();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void ImportarCadastro()
		{
			//try
			//{
			//    string arquivo = /*Matriz.Pasta2() +*/ "\\Cadastros\\cadastroProdutos.xml";

			//    if (!File.Exists(arquivo))
			//    {
			//        MessageBox.Show("Arquivo não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			//        return;
			//    }

			//    DataSet ds = new DataSet();

			//    ds.ReadXml(arquivo);

			//    Globais.Maximo = ds.Tables[0].Rows.Count;
			//    Globais.Valor = 0;

			//    foreach (DataRow dr in ds.Tables[0].Rows)
			//    {
			//        Produto produto = new Produto();

			//        if (Globais.Resultado == DialogResult.Cancel)
			//            return;

			//        Globais.Valor++;

			//        produto.Codigo = int.Parse(dr.ItemArray[ds.Tables[0].Columns.IndexOf("codigo")].ToString());
			//        produto.Nome = dr.ItemArray[ds.Tables[0].Columns.IndexOf("nome")].ToString();
			//        produto.Tipo = int.Parse(dr.ItemArray[ds.Tables[0].Columns.IndexOf("produto_tipo")].ToString());
			//        produto.Grupo = int.Parse(dr.ItemArray[ds.Tables[0].Columns.IndexOf("produto_grupo")].ToString());
			//        produto.Descricao = dr.ItemArray[ds.Tables[0].Columns.IndexOf("descricao")].ToString();
			//        produto.Situacao = dr.ItemArray[ds.Tables[0].Columns.IndexOf("situacao")].ToString()[0];
			//        produto.GrupoTributario = int.Parse(dr.ItemArray[ds.Tables[0].Columns.IndexOf("grupo_tributario")].ToString());
			//        produto.Medida.Codigo = int.Parse(dr.ItemArray[ds.Tables[0].Columns.IndexOf("medida")].ToString());

			//        Globais.Mensagem = "Sincronizando produto " + produto.Codigo.ToString() + " - " + produto.Nome;

			//        if (!_dsoftBd.SincronizarProduto(produto))
			//        {
			//            MessageBox.Show("Importação interrompida!" + Environment.NewLine + "Entre em contato com o suporte.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//            return;
			//        }
			//    }

			//    MessageBox.Show("Importação concluída!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void Incluir()
		{
			if (btIncluir.Text == "&Incluir - F2")
			{
				tcProdutos.Enabled = true;

				btIncluir.Text = "Confirmar - F2";
				btIncluir.Enabled = true;

				tbCodigo.Focus();
			}
			else
			{
				if (Editando)
				{
					if (AlterarProduto())
					{
						tcProdutos.Enabled = false;

						btIncluir.Text = "&Incluir - F2";

						LimparDados();

						Editando = false;
					}
				}
				else
				{
					if (IncluirProduto())
					{
						if (Consulta)
						{
							Sair();
						}

						UltimoCodigo = long.Parse(tbCodigo.Text);

						tcProdutos.Enabled = false;

						btIncluir.Text = "&Incluir - F2";

						LimparDados();

						Atualizar();
					}
				}
			}
		}

		private bool IncluirProduto()
		{
			try
			{
				_produto = new Produto();

				if (tbCodigo.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!");

					tbCodigo.Focus();

					return false;
				}

				long codigo;

				if (!long.TryParse(tbCodigo.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' inválido!. Campo deve ser numérico!");

					tbCodigo.Focus();

					return false;
				}

				_produto.Codigo = codigo;

				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!");

					tbNome.Focus();

					return false;
				}

				_produto.Nome = tbNome.Text;

				if (cbTipo.SelectedItem == null)
				{
					MessageBox.Show("O campo 'tipo' deve ser preenchido obrigatoriamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					cbTipo.Focus();
					return false;
				}

				ProdutoTipo tipo = cbTipo.SelectedItem as ProdutoTipo;

				if (tipo != null)
				{
					_produto.Tipo = tipo.Codigo;
				}

				if (cbGrupo.SelectedItem == null)
				{
					MessageBox.Show("Campo 'grupo' deve ser preenchido obrigatoriamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					cbGrupo.Focus();
					return false;
				}

				ProdutoGrupo grupo = cbGrupo.SelectedItem as ProdutoGrupo;

				if (grupo != null)
				{
					_produto.Grupo = (int)grupo.Codigo;
				}

				int grupoTributario = 0;

				if (cbGrupoTributario.Text.Length > 0 && !int.TryParse(cbGrupoTributario.Text.Split(" - ".ToCharArray(), 2)[0], out grupoTributario))
				{
					MessageBox.Show("Campo 'grupo tributário' inválido! Campo deve ser numérico.", this.Text);

					cbGrupoTributario.SelectAll();
					cbGrupoTributario.Focus();

					return false;
				}

				_produto.GrupoTributario = grupoTributario;

				int medida = 0;

				if (cbMedida.Text.Length > 0 && !int.TryParse(cbMedida.Text.Split(" - ".ToCharArray(), 2)[0], out medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Campo deve ser numérico.", this.Text);

					cbMedida.SelectAll();
					cbMedida.Focus();

					return false;
				}

				_produto.Medida.Codigo = medida;

				medida = 0;

				if (cbMedidaTributaria.Text.Length > 0 && !int.TryParse(cbMedidaTributaria.Text.Split(" - ".ToCharArray(), 2)[0], out medida))
				{
					MessageBox.Show("Campo 'medida' inválido! Campo deve ser numérico.", this.Text);

					cbMedidaTributaria.SelectAll();
					cbMedidaTributaria.Focus();

					return false;
				}

				_produto.MedidaTributavel.Codigo = medida;

				_produto.Descricao = tbDescricao.Text;

				_produto.Producao = cbProducao.Checked;

				if (cbFornecedor.Text.Length > 0)
				{
					_produto.Fornecedor = new Fornecedor();

					_produto.Fornecedor.Codigo = long.Parse(cbFornecedor.Text.Split(" - ".ToCharArray(), 2)[0]);
				}

				_produto.Foto = pbFoto.ImageLocation;
				_produto.NCM = tbNCM.Text;
				_produto.CFOP = tbCFOP.Text;
				_produto.EAN = tbEAN.Text;
				_produto.EANTrib = tbEANTrib.Text;

				int qtd_trib = 0;

				if (tbQtdTrib.Text.Length > 0 && !int.TryParse(tbQtdTrib.Text, out qtd_trib))
				{
					MessageBox.Show("Campo 'Quantidade Tributável' inválido!", Text);
					tbQtdTrib.SelectAll();
					tbQtdTrib.Focus();
					return false;
				}

				_produto.QuantidadeTributavel = qtd_trib;

				return _dsoftBd.IncluirProduto(_produto);
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

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			tbDescricao.Clear();
			pbFoto.Image = null;
			tbNCM.Clear();
			tbCFOP.Clear();
			tbEAN.Clear();
			tbEANTrib.Clear();
			tbQtdTrib.Clear();

			cbProducao.Checked = false;
			cbFornecedor.SelectedItem = null;
			dataGridView2.DataSource = null;
		}

		private void LimparDados()
		{
			LimparCampos();

			btIncluir.Text = "&Incluir - F2";
			btIncluir.Enabled = true;

			button3.Text = "&Bloquear";
			button3.Enabled = false;

			button4.Text = "&Cancelar - F4";
			button4.Enabled = false;

			button5.Text = "Limpar Dados";

			button6.Text = "&Sair - F10";

			lbAviso.Text = string.Empty;

			tcProdutos.Enabled = false;

			tbCodigo.ReadOnly = false;
		}

		private void listaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataSet ds = new DataSet();

			if (!_dsoftBd.ListaProdutos(ds))
				return;

			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.Arquivo = relatorio.Titulo = "Listagem de Produtos";
			relatorio.Descricao = "Listagem de todos os produtos cadastrados no sistema. Emitido em " + DateTime.Now.ToShortDateString();

			relatorio.Gerar(ds);
		}

		private void pbFoto_DoubleClick(object sender, EventArgs e)
		{
			SelecionarFoto();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				dataGridView1.Sort(dataGridView1.Columns["codigo"], ListSortDirection.Ascending);

				tbPesquisa.Focus();
			}
			else
			{
				dataGridView1.Sort(dataGridView1.Columns["nome"], ListSortDirection.Ascending);

				tbPesquisa.Focus();
			}
		}

		private void reativarCanceladoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmCadProdutosTipos form = new frmCadProdutosTipos(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarTipos();
		}

		private bool ReativarProduto()
		{
			try
			{
				long codigo = long.Parse(tbCodigo.Text);

				if (_dsoftBd.ReativarProduto(codigo))
				{
					for (int i = 0; i < dataGridView1.Rows.Count; i++)
					{
						if (Convert.ToInt64(dataGridView1["codigo", i].Value) == codigo)
						{
							dataGridView1["situacao", i].Value = "A";
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

							break;
						}
					}

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

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void SelecionarFoto()
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				pbFoto.Load(openFileDialog1.FileName);
			}
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (btIncluir.Enabled)
				{
					btIncluir.Focus();
				}
				else
				{
					btMaterial.Focus();
				}
			}
		}

		private void tbPesquisa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbPesquisa.Text.Length > 0)
			{
				if (dataGridView1.SelectedRows.Count > 0)
				{
					CarregarRegistro();
				}
			}
			else if (e.KeyCode == Keys.Down)
			{
				dataGridView1.Focus();
			}
		}

		private void tbPesquisa_TextChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				int match = 0;
				long codigo;

				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					if (long.TryParse(tbPesquisa.Text, out codigo))
					{
						if (codigo >= long.Parse(dataGridView1.Rows[i].Cells["codigo"].Value.ToString()))
						{
							match = i;
						}
						else
						{
							break;
						}
					}
				}

				dataGridView1.FirstDisplayedScrollingRowIndex = match;
				dataGridView1.Rows[match].Selected = true;
			}
			else
			{
				int match = 0;
				int r = 0;

				for (int i = 0; i < tbPesquisa.Text.Length; i++)
				{
					while (r < dataGridView1.Rows.Count)
					{
						if (dataGridView1.Rows[r].Cells["nome"].Value.ToString().Length > i && tbPesquisa.Text[i] == dataGridView1.Rows[r].Cells["nome"].Value.ToString()[i])
						{
							match = r;

							break;
						}

						r++;
					}
				}

				dataGridView1.FirstDisplayedScrollingRowIndex = match;
				dataGridView1.Rows[match].Selected = true;
			}
		}

		private void tbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btMaterial.Focus();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbCodigo.Text.Length > 0)
			{
				tbNome.Focus();
			}
			else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			long numero;

			if (tbCodigo.Text.Length > 0)
			{
				if (!long.TryParse(tbCodigo.Text, out numero))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbCodigo.SelectAll();

					tbCodigo.Focus();

					return;
				}
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbNome.Text.Length > 0)
			{
				//textBox3.Focus();
				cbTipo.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)Keys.Enter)
			//{
			//    textBox4.Focus();
			//}
		}

		private void textBox3_Leave(object sender, EventArgs e)
		{
			//try
			//{
			//    if (textBox3.Text.Length > 0)
			//    {
			//        if ((lbTipo.Text = Bd.ProdutoTipoNome(int.Parse(textBox3.Text))) == string.Empty)
			//        {
			//            MessageBox.Show("Tipo de produto não encontrado!", this.Text);

			//            textBox3.SelectAll();

			//            textBox3.Focus();

			//            return;
			//        }
			//    }
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(ex.Message, this.Text);

			//    textBox3.SelectAll();

			//    textBox3.Focus();
			//}
		}

		private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (e.KeyChar == (char)Keys.Enter)
			//{
			//    textBox5.Focus();
			//}
		}

		private void textBox4_Leave(object sender, EventArgs e)
		{
			//try
			//{
			//    if (textBox4.Text.Length > 0)
			//    {
			//        if ((lbGrupo.Text = Bd.ProdutoGrupoDescricao(int.Parse(textBox4.Text))) == string.Empty)
			//        {
			//            MessageBox.Show("Grupo de produto não encontrado!", this.Text);

			//            textBox4.SelectAll();

			//            textBox4.Focus();

			//            return;
			//        }
			//    }
			//}
			//catch (Exception ex)
			//{
			//    MessageBox.Show(ex.Message, this.Text);

			//    textBox4.SelectAll();

			//    textBox4.Focus();
			//}
		}

		private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			frmCadProdutosGrupos form = new frmCadProdutosGrupos(_dsoftBd, _usuario);

			form.ShowDialog();

			CarregarGrupos();
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			Bloquear();
		}

		private void toolStripMenuItem5_Click(object sender, EventArgs e)
		{
			//Globais.Resultado = MessageBox.Show("Confirma a importação do cadastro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			//if (Globais.Resultado != DialogResult.Yes)
			//{
			//    return;
			//}

			//Globais.Mensagem = string.Empty;

			//Thread t = new Thread(new ThreadStart(ImportarCadastro));

			//t.Start();

			//frmBarraStatus barra = new frmBarraStatus();
			//barra.ShowDialog();

			//Atualizar();
		}

		private void btAdicionalConfirmar_Click(object sender, EventArgs e)
		{
			decimal valor;

			if (tbAdicionalDescricao.Text.Length < 1)
			{
				MessageBox.Show("Descrição inválida!");
				tbAdicionalDescricao.Focus();
				return;
			}

			if (!decimal.TryParse(tbAdicionalValor.Text, out valor))
			{
				MessageBox.Show("Valor inválido!");
				tbAdicionalValor.SelectAll();
				tbAdicionalValor.Focus();
				return;
			}

			ItemAdicional itemAdicional = new ItemAdicional();

			itemAdicional.Descricao = tbAdicionalDescricao.Text;
			itemAdicional.Valor = valor;

			if (_dsoftBd.AdicionarItemAdicional(itemAdicional, Convert.ToInt64(tbCodigo.Text)))
			{
				LimparAdicional();
				AtualizarAdicionais();
				tbAdicionalDescricao.Focus();
			}
			else
			{
				MessageBox.Show("Erro ao gravar dados!");
			}
		}

		private void LimparAdicional()
		{
			tbAdicionalDescricao.Text = string.Empty;
			tbAdicionalValor.Text = string.Empty;
		}

		private void AtualizarAdicionais()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarItensAdicionais(ds, Convert.ToInt64(tbCodigo.Text));

			dgAdicionais.DataSource = ds.Tables[0];

			dgAdicionais.Columns["descricao"].HeaderText = "Descrição";
			dgAdicionais.Columns["descricao"].Width = 240;
			dgAdicionais.Columns["adicional"].HeaderText = "Valor Adicional";
			dgAdicionais.Columns["adicional"].Width = 120;
			dgAdicionais.Columns["adicional"].DefaultCellStyle.Format = "###,###,##0.00";
			dgAdicionais.Columns["adicional"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}

		private void btAdicionalExcluir_Click(object sender, EventArgs e)
		{
			decimal valor;

			if (tbAdicionalDescricao.Text.Length < 1 || !decimal.TryParse(tbAdicionalValor.Text, out valor))
			{
				return;
			}

			ItemAdicional itemAdicional = new ItemAdicional();

			itemAdicional.Descricao = tbAdicionalDescricao.Text;
			itemAdicional.Valor = valor;

			if (_dsoftBd.ExcluirItemAdicional(itemAdicional, Convert.ToInt64(tbCodigo.Text)))
			{
				AtualizarAdicionais();
				LimparAdicional();
			}
		}

		private void dgAdicionais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			tbAdicionalDescricao.Text = dgAdicionais["descricao", e.RowIndex].Value.ToString();
			tbAdicionalValor.Text = dgAdicionais["adicional", e.RowIndex].Value.ToString();
		}

		#endregion Methods
	}
}