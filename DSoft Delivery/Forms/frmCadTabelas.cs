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
	public partial class frmCadTabelas : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadTabelas(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void AdicionarBase()
		{
			int tabela;

			if (cbBase.Text.Length == 0)
				return;

			if (dgPrecos.Rows.Count < 1)
				return;

			tabela = int.Parse(cbBase.Text.Split(" - ".ToCharArray(), 2)[0]);

			DataSet ds = new DataSet();

			_dsoftBd.ProdutosPrecos(tabela, ds);

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				dgPrecos.Rows[i].Cells["base"].Value = double.Parse(ds.Tables[0].Rows[i].ItemArray[3].ToString()).ToString("###,###,##0.00");
			}

			CalcularMargem();
		}

		private void Alterar()
		{
			if (AlterarTabela())
			{
				LimparDados();

				CarregarTabelasBase();
			}
		}

		private bool AlterarTabela()
		{
			try
			{
				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!");

					tbNome.Focus();

					return false;
				}

				if (_dsoftBd.AlterarTabela(int.Parse(tbTabela.Text), tbNome.Text, tbDescricao.Text))
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
				int row = 0;

				DataSet ds = new DataSet();

				_dsoftBd.TabelasPrecos(ds);

				if (dgTabelas.SelectedRows.Count > 0)
				{
					row = dgTabelas.SelectedRows[0].Index;
				}

				dgTabelas.DataSource = ds.Tables[0];

				dgTabelas.Columns["codigo"].Width = 42;
				dgTabelas.Columns["codigo"].HeaderText = "Código";
				dgTabelas.Columns["nome"].Width = 120;
				dgTabelas.Columns["nome"].HeaderText = "Nome";
				dgTabelas.Columns["descricao"].Width = 180;
				dgTabelas.Columns["descricao"].HeaderText = "Descrição";
				dgTabelas.Columns["situacao"].Width = 60;
				dgTabelas.Columns["situacao"].HeaderText = "Situação";

				for (int i = 0; i < dgTabelas.Rows.Count; i++)
				{
					switch (dgTabelas.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dgTabelas.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgTabelas.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dgTabelas.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dgTabelas.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dgTabelas.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgTabelas.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}

				dgTabelas.FirstDisplayedScrollingRowIndex = row;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void Bloquear()
		{
			if (button3.Text == "&Bloquear")
			{
				if (BloquearTabela())
				{
					LimparDados();
				}
			}
			else
			{
				if (DesbloquearTabela())
				{
					LimparDados();
				}
			}
		}

		private bool BloquearTabela()
		{
			if (_dsoftBd.BloquearTabela(int.Parse(tbTabela.Text)))
			{
				return true;
			}
			else
			{
				return false;
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

		private void button7_Click(object sender, EventArgs e)
		{
			LimparProduto();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void CalcularMargem()
		{
			try
			{
				foreach (DataGridViewRow r in dgPrecos.Rows)
				{
					double b, d, p, m;

					b = double.Parse(r.Cells["base"].Value.ToString());
					p = double.Parse(r.Cells["preco"].Value.ToString());

					d = p - b;

					if (b == 0 && p > 0)
						m = 100;
					else if (b == 0 && p == 0)
						m = 0;
					else
						//m = ((p - b) / p) * 100;
						m = ((p - b) * 100) / b;

					r.Cells["porcentagem"].Value = m.ToString("###,###,##0.00");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao calcular margem." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Cancelar()
		{
			if (button4.Text == "&Cancelar - F4")
			{
				if (CancelarTabela())
				{
					LimparDados();

					CarregarTabelasBase();
				}
			}
			else
			{
				if (ReativarTabela())
				{
					LimparDados();

					CarregarTabelasBase();
				}
			}
		}

		private bool CancelarTabela()
		{
			if (_dsoftBd.CancelarTabela(int.Parse(tbTabela.Text), _usuario.Autorizado))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void CarregarProduto()
		{
			try
			{
				tbProduto.Text = dgPrecos.CurrentRow.Cells["codigo"].Value.ToString();

				tbProdutoNome.Text = dgPrecos.CurrentRow.Cells["nome"].Value.ToString();

				tbProdutoDescricao.Text = dgPrecos.CurrentRow.Cells["descricao"].Value.ToString();

				tbPreco.Text = dgPrecos.CurrentRow.Cells["preco"].Value.ToString();

				decimal trib;
				decimal.TryParse(dgPrecos.CurrentRow.Cells["tributavel"].Value.ToString(), out trib);

				tbTributavel.Text = trib.ToString("##,###,##0.00");

				if (RegrasDeNegocio.Instance.Ramo == "LOCADORA")
				{
					long produto = long.Parse(tbProduto.Text);
					int produto_tipo = _dsoftBd.ProdutoTipo(produto);

					if (_dsoftBd.ProdutoTipoLocacao(produto_tipo))
					{
						tbLocacao.Enabled = true;
						tbLocacao.Text = dgPrecos.CurrentRow.Cells["locacao"].Value.ToString();

						btGerarLocacao.Enabled = true;

						CarregarLocacoesEspeciais(produto);
					}
					else
					{
						tbLocacao.Text = "0,00";
						tbLocacao.Enabled = false;

						btGerarLocacao.Enabled = false;

						dgLocacao.Rows.Clear();
					}
				}
				else
				{
					tbLocacao.Enabled = false;
					tbLocacao.Text = "0,00";
				}

				tcPrecos.Enabled = true;

				btDescarta.Enabled = true;
				btConfirma.Enabled = true;
				btConfirma.Select();

				tbPreco.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return;
			}
		}

		private void CarregarLocacoesEspeciais(long produto)
		{
			int tabela = Convert.ToInt32(tbTabela.Text);

			dgLocacao.Rows.Clear();

			List<LocacaoEspecialPreco> precos = _dsoftBd.CarregarLocacoesEspeciaisPrecos(tabela, produto);

			if (precos != null)
			{
				foreach (LocacaoEspecialPreco p in precos)
				{
					dgLocacao.Rows.Add(p.Indice, p.Tabela, p.Produto, p.Descricao, p.Preco);
				}
			}
		}

		private void CarregarProdutos()
		{
			try
			{
				int row = 0;

				DataSet ds = new DataSet();

				_dsoftBd.ProdutosPrecos(int.Parse(tbTabela.Text), ds);

				if (dgPrecos.SelectedRows.Count > 0)
				{
					row = dgPrecos.SelectedRows[0].Index;
				}

				// Adicionamos uma coluna para o preco base e uma para a porcentagem
				ds.Tables[0].Columns.Add("base");
				ds.Tables[0].Columns.Add("porcentagem");

				dgPrecos.DataSource = ds.Tables[0];

				dgPrecos.Columns["codigo"].Width = 80;
				dgPrecos.Columns["codigo"].HeaderText = "Código";
				dgPrecos.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgPrecos.Columns["codigo"].DisplayIndex = 0;
				dgPrecos.Columns["nome"].Width = 180;
				dgPrecos.Columns["nome"].HeaderText = "Nome";
				dgPrecos.Columns["nome"].DisplayIndex = 1;
				dgPrecos.Columns["descricao"].Width = 180;
				dgPrecos.Columns["descricao"].Visible = false;
				dgPrecos.Columns["base"].HeaderText = "Base(R$)";
				dgPrecos.Columns["base"].Width = 80;
				dgPrecos.Columns["base"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgPrecos.Columns["base"].DefaultCellStyle.Format = "###,###,##0.00";
				dgPrecos.Columns["base"].DisplayIndex = 2;
				dgPrecos.Columns["preco"].Width = 80;
				dgPrecos.Columns["preco"].HeaderText = "Preço(R$)";
				dgPrecos.Columns["preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgPrecos.Columns["preco"].DefaultCellStyle.Format = "###,###,##0.00";
				dgPrecos.Columns["preco"].DisplayIndex = 3;
				dgPrecos.Columns["porcentagem"].HeaderText = "Dif.(%)";
				dgPrecos.Columns["porcentagem"].Width = 55;
				dgPrecos.Columns["porcentagem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgPrecos.Columns["porcentagem"].DefaultCellStyle.Format = "###,###,##0";
				dgPrecos.Columns["porcentagem"].DisplayIndex = 4;
				dgPrecos.Columns["tributavel"].Width = 80;
				dgPrecos.Columns["tributavel"].HeaderText = "Trib.(R$)";
				dgPrecos.Columns["tributavel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgPrecos.Columns["tributavel"].DefaultCellStyle.Format = "###,###,##0.00";
				dgPrecos.Columns["tributavel"].DisplayIndex = 5;

				dgPrecos.Columns["situacao"].Width = 60;
				dgPrecos.Columns["situacao"].Visible = false;

				if (RegrasDeNegocio.Instance.Ramo != "LOCADORA")
				{
					dgPrecos.Columns["locacao"].Visible = false;
				}
				else
				{
					dgPrecos.Columns["locacao"].HeaderText = "Locação";
					dgPrecos.Columns["locacao"].Width = 80;
					dgPrecos.Columns["locacao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgPrecos.Columns["locacao"].DefaultCellStyle.Format = "###,###,##0.00";
					dgPrecos.Columns["locacao"].DisplayIndex = 5;
				}

				for (int i = 0; i < dgPrecos.Rows.Count; i++)
				{
					switch (dgPrecos.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dgPrecos.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgPrecos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dgPrecos.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dgPrecos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dgPrecos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgPrecos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;
					}
				}

				if (dgPrecos.Rows.Count > 1)
				{
					dgPrecos.FirstDisplayedScrollingRowIndex = row;
					dgPrecos.Rows[row].Selected = true;
					dgPrecos.Rows[0].Selected = false;
					dgPrecos.Focus();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void CarregarRegistro()
		{
			try
			{
				int codigo;

				if (int.TryParse(dgTabelas.CurrentRow.Cells["codigo"].Value.ToString(), out codigo) == false)
				{
					MessageBox.Show("Código inválido", "Cadastro de Tabelas");

					return;
				}

				TabelaDePrecos tabela = _dsoftBd.CarregarTabela(codigo);

				tbTabela.Text = codigo.ToString();
				tbTabela.ReadOnly = true;

				tbNome.Text = tabela.Nome;

				tbDescricao.Text = tabela.Descricao;

				switch (tabela.Situacao.ToString())
				{
				case "A":
					lbAviso.Text = "Tabela Ativa!";

					button2.Enabled = true;
					button3.Enabled = true;
					button4.Enabled = true;

					break;

				case "B":
					lbAviso.Text = "Tabela Bloqueada!";

					button2.Enabled = true;
					button3.Enabled = true;
					button4.Enabled = true;

					button3.Text = "Des&bloquear";

					break;

				case "C":
					lbAviso.Text = "Tabela Cancelada!";

					button4.Enabled = true;

					button4.Text = "Reativar - F4";

					break;

				default:

					break;
				}

				button1.Enabled = false;

				groupBox1.Enabled = true;

				CarregarProdutos();

				AdicionarBase();

				dgPrecos.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);

				return;
			}
		}

		private void CarregarTabelasBase()
		{
			string []tabelas;

			_dsoftBd.CarregarTabelas(out tabelas);

			cbBase.Items.Clear();

			if (tabelas == null)
				return;

			foreach (string s in tabelas)
			{
				cbBase.Items.Add(s);
			}
		}

		private void cbBase_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (cbBase.Text.Length > 0)
					AdicionarBase();
			}
		}

		private void cbBase_SelectedIndexChanged(object sender, EventArgs e)
		{
			AdicionarBase();
		}

		private void Confirmar()
		{
			int produto = 0;
			int tabela = 0;
			decimal preco = 0;
			decimal locacao = 0;
			decimal tributavel = 0;

			if (!int.TryParse(tbProduto.Text, out produto))
			{
				tbProduto.SelectAll();
				tbProduto.Focus();

				return;
			}

			if (!int.TryParse(tbTabela.Text, out tabela))
			{
				tbTabela.SelectAll();
				tbTabela.Focus();

				return;
			}

			if (!decimal.TryParse(tbPreco.Text, out preco))
			{
				tbPreco.SelectAll();
				tbPreco.Focus();

				return;
			}

			decimal.TryParse(tbLocacao.Text, out locacao);

			if (!decimal.TryParse(tbTributavel.Text, out tributavel))
			{
				tbTributavel.SelectAll();
				tbTributavel.Focus();

				return;
			}

			if (_dsoftBd.AlterarPreco(produto, tabela, preco, tributavel, locacao, _usuario.Autorizado))
			{
				foreach (DataGridViewRow r in dgPrecos.Rows)
				{
					if (r.Cells["codigo"].Value.ToString() == tbProduto.Text)
					{
						double b, d, p, m;

						r.Cells["preco"].Value = tbPreco.Text;
						r.Cells["tributavel"].Value = tbTributavel.Text;
						r.Cells["locacao"].Value = tbLocacao.Text;

						if (r.Cells["base"].Value.ToString() != string.Empty)
						{
							b = double.Parse(r.Cells["base"].Value.ToString());
							p = double.Parse(r.Cells["preco"].Value.ToString());

							d = p - b;

							if (b == 0 && p > 0)
								m = 100;
							else if (b == 0 && p == 0)
								m = 0;
							else
								//m = ((p - b) / p) * 100;
								m = ((p - b) * 100) / b;

							r.Cells["porcentagem"].Value = m.ToString("###,###,##0.00");
						}

						break;
					}
				}

				LimparProduto();

				dgPrecos.Focus();
			}
			else
			{
				MessageBox.Show("Erro ao gravar dados." + Environment.NewLine + "Se o problema persistir, entre em contato com o suporte.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				tbPreco.Focus();
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			CarregarRegistro();
		}

		private void dataGridView2_DoubleClick(object sender, EventArgs e)
		{
			CarregarProduto();

			AdicionarBase();
		}

		private bool DesbloquearTabela()
		{
			if (_dsoftBd.DesbloquearTabela(int.Parse(tbTabela.Text), _usuario.Autorizado))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void frmCadTabelas_Load(object sender, EventArgs e)
		{
			Atualizar();

			CarregarTabelasBase();
		}

		private void Incluir()
		{
			if (button1.Text == "&Incluir - F2")
			{
				groupBox1.Enabled = true;

				button1.Text = "Confirmar - F2";

				tbTabela.Focus();

				CarregarTabelasBase();
			}
			else
			{
				if (IncluirTabela())
				{
					groupBox1.Enabled = false;

					button1.Text = "&Incluir - F2";

					LimparDados();

					CarregarTabelasBase();
				}
			}
		}

		private bool IncluirTabela()
		{
			try
			{
				int codigo;

				if (tbTabela.Text == string.Empty)
				{
					MessageBox.Show("Campo 'código' deve ser preenchido!");

					tbTabela.Focus();

					return false;
				}

				if (!int.TryParse(tbTabela.Text, out codigo))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!");

					tbTabela.Focus();

					return false;
				}

				if (tbNome.Text == string.Empty)
				{
					MessageBox.Show("Campo 'nome' deve ser preenchido!");

					tbNome.Focus();

					return false;
				}

				if (_dsoftBd.IncluirTabela(codigo, tbNome.Text, tbDescricao.Text, 0))
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

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void label9_Click(object sender, EventArgs e)
		{
		}

		private void LimparCampos()
		{
			tbTabela.Clear();
			tbNome.Clear();
			tbDescricao.Clear();
		}

		private void LimparDados()
		{
			LimparCampos();

			button1.Text = "&Incluir - F2";
			button1.Enabled = true;

			button2.Text = "&Alterar - F3";
			button2.Enabled = false;

			button3.Text = "&Bloquear";
			button3.Enabled = false;

			button4.Text = "&Cancelar - F4";
			button4.Enabled = false;

			button5.Text = "Limpar Dados";

			button6.Text = "&Sair - F10";

			lbAviso.Text = string.Empty;

			groupBox1.Enabled = false;

			LimparProduto();

			Atualizar();
		}

		private void LimparProduto()
		{
			tcPrecos.Enabled = false;

			tbProduto.Clear();
			tbProdutoNome.Clear();
			tbProdutoDescricao.Clear();
			tbPreco.Clear();
			tbLocacao.Clear();
			tbTributavel.Clear();

			btDescarta.Enabled = false;
			btConfirma.Enabled = false;
		}

		private bool ReativarTabela()
		{
			if (_dsoftBd.ReativarTabela(int.Parse(tbTabela.Text)))
			{
				return true;
			}
			else
			{
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

		private void tbTributavel_KeyPress(object sender, KeyPressEventArgs e)
		{
			double valor;

			if (e.KeyChar == (char)Keys.Enter && tbTributavel.Text != string.Empty)
			{
				if (!double.TryParse(tbTributavel.Text, out valor))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbTributavel.SelectAll();

					tbTributavel.Focus();

					return;
				}

				tbTributavel.Text = valor.ToString("0.00");

				btConfirma.Focus();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbTabela.Text.Length > 0)
			{
				tbNome.Focus();
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			int numero;

			if (tbTabela.Text.Length > 0)
			{
				if (!int.TryParse(tbTabela.Text, out numero))
				{
					MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

					tbTabela.SelectAll();

					tbTabela.Focus();
				}
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbNome.Text.Length > 0)
			{
				tbDescricao.Focus();
			}
		}

		private void textBox3_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (button1.Enabled)
				{
					button1.Focus();
				}
				else
				{
					button2.Focus();
				}
			}
		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
		}

		private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
		{
			double valor;

			if (e.KeyChar == (char)Keys.Enter && tbPreco.Text != string.Empty)
			{
				if (!double.TryParse(tbPreco.Text, out valor))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbPreco.SelectAll();

					tbPreco.Focus();

					return;
				}

				tbPreco.Text = valor.ToString("0.00");

				if (tbLocacao.Enabled)
				{
					tbLocacao.Focus();
				}
				else
				{
					tbTributavel.Focus();
				}
			}
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
		}

		private void tbLocacao_KeyPress(object sender, KeyPressEventArgs e)
		{
			double valor;

			if (e.KeyChar == (char)Keys.Enter && tbLocacao.Text != string.Empty)
			{
				if (!double.TryParse(tbLocacao.Text, out valor))
				{
					MessageBox.Show("Valor inválido!", this.Text);

					tbLocacao.SelectAll();

					tbLocacao.Focus();

					return;
				}

				tbLocacao.Text = valor.ToString("0.00");

				tbTributavel.Focus();
			}
		}

		private void btGerarLocacao_Click(object sender, EventArgs e)
		{
			GerarLocacao();
		}

		private void GerarLocacao()
		{
			_dsoftBd.GerarLocacoesEspeciais(Convert.ToInt32(tbTabela.Text), Convert.ToInt64(tbProduto.Text));

			CarregarLocacoesEspeciais(Convert.ToInt64(tbProduto.Text));
		}

		private void dgLocacao_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.FormattedValue.ToString().Length > 0 && e.ColumnIndex == 4)
			{
				decimal valor;
				decimal.TryParse(e.FormattedValue.ToString(), out valor);

				_dsoftBd.AtualizarPrecoLocacaoEspecial(Convert.ToInt32(dgLocacao[0, e.RowIndex].Value), valor);
			}
		}

		private void dgPrecos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && dgPrecos.SelectedRows.Count > 0)
			{
				CarregarProduto();
				AdicionarBase();
			}
		}

		#endregion Methods
	}
}