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
	public partial class frmCadProdutosTipos : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		private ProdutoTipo _produtoTipo;

		#endregion Fields

		#region Constructors

		public frmCadProdutosTipos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			try
			{
				DataSet ds = new DataSet();

				_dsoftBd.TiposProdutos(ds);

				dgProdutosTipos.DataSource = ds.Tables[0];

				for (int i = 0; i < (dgProdutosTipos.Rows.Count - 1); i++)
				{
					switch (dgProdutosTipos.Rows[i].Cells["situacao"].Value.ToString())
					{
					case "A":
						dgProdutosTipos.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dgProdutosTipos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B":
						dgProdutosTipos.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dgProdutosTipos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C":
						dgProdutosTipos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dgProdutosTipos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
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

		private void button2_Click(object sender, EventArgs e)
		{
			LimparCampos();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarDados(int row)
		{
			try
			{
				int impressora;

				tbCodigo.Text = dgProdutosTipos.Rows[row].Cells["codigo"].Value.ToString();
				tbNome.Text = dgProdutosTipos.Rows[row].Cells["nome"].Value.ToString();
				tbDescricao.Text = dgProdutosTipos.Rows[row].Cells["descricao"].Value.ToString();
				cbProducao.Checked = bool.Parse(dgProdutosTipos.Rows[row].Cells["producao"].Value.ToString());
				cbEstoque.Checked = bool.Parse(dgProdutosTipos.Rows[row].Cells["estoque"].Value.ToString());
				cbSoma.Checked = bool.Parse(dgProdutosTipos.Rows[row].Cells["soma"].Value.ToString());
				cbImprimeTotal.Checked = Convert.ToBoolean(dgProdutosTipos.Rows[row].Cells["imprime_total"].Value);

				int.TryParse(dgProdutosTipos.Rows[row].Cells["impressora_externa"].Value.ToString(), out impressora);

				cbImpressora.SelectedIndex = impressora;

				cbAdicionais.Checked = bool.Parse(dgProdutosTipos.Rows[row].Cells["adicionais"].Value.ToString());
				cbMeioAMeio.Checked = Convert.ToBoolean(dgProdutosTipos.Rows[row].Cells["meio"].Value);
				cbFracionado.Checked = Convert.ToBoolean(dgProdutosTipos.Rows[row].Cells["fracao"].Value);
				cbPermiteLocacao.Checked = Convert.ToBoolean(dgProdutosTipos.Rows[row].Cells["permite_locacao"].Value);
				cbLocacaoPeriodo.Text = dgProdutosTipos.Rows[row].Cells["intervalo_locacao"].Value.ToString();
				tbPeriodo.Text = dgProdutosTipos.Rows[row].Cells["periodo_locacao"].Value.ToString();

				tbLocacaoEspecial.Text = string.Empty;
				tbPeriodoEspecial.Text = string.Empty;

				CarregarPeriodosEspeciais(Convert.ToInt32(tbCodigo.Text));

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					AtualizarAdicionais();
				}

				tbCodigo.ReadOnly = true;

				button1.Text = "&Confirmar - F2";
				tabControl1.Enabled = true;

				tbNome.Focus();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void CarregarPeriodosEspeciais(int tipo)
		{
			List<LocacaoEspecial> especiais = _dsoftBd.LocacaoEspecial(tipo);

			lbLocacaoEspecial.Items.Clear();

			lbLocacaoEspecial.Items.AddRange(especiais.ToArray());
		}

		private void cbSoma_Enter(object sender, EventArgs e)
		{
			cbSoma.ForeColor = Color.DarkBlue;
		}

		private void cbSoma_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				button1.Focus();
			}
		}

		private void cbSoma_Leave(object sender, EventArgs e)
		{
			cbSoma.ForeColor = Color.Black;
		}

		private void checkBox1_Enter(object sender, EventArgs e)
		{
			cbProducao.ForeColor = Color.DarkBlue;
		}

		private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbEstoque.Focus();
			}
		}

		private void checkBox1_Leave(object sender, EventArgs e)
		{
			cbProducao.ForeColor = Color.Black;
		}

		private void checkBox2_Enter(object sender, EventArgs e)
		{
			cbEstoque.ForeColor = Color.DarkBlue;
		}

		private void checkBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbSoma.Focus();
			}
		}

		private void checkBox2_Leave(object sender, EventArgs e)
		{
			cbEstoque.ForeColor = Color.Black;
		}

		private void Confirmar()
		{
			try
			{
				if (button1.Text == "&Novo - F2")
				{
					button1.Text = "&Confirmar - F2";

					tabControl1.Enabled = true;

					tbCodigo.Focus();
				}
				else
				{
					ProdutoTipo tipo = new ProdutoTipo();
					int codigo;

					if (tbCodigo.Text == string.Empty)
					{
						MessageBox.Show("Campo código deve ser preenchido!", this.Text);

						tbCodigo.Focus();

						return;
					}

					if (!int.TryParse(tbCodigo.Text, out codigo))
					{
						MessageBox.Show("Campo 'código' deve ser numérico!", this.Text);

						tbCodigo.SelectAll();

						tbCodigo.Focus();

						return;
					}

					tipo.Codigo = codigo;

					if (tbNome.Text == string.Empty)
					{
						MessageBox.Show("Campo 'nome' deve ser preenchido!", this.Text);

						tbNome.Focus();

						return;
					}

					tipo.Nome = tbNome.Text;
					tipo.Descricao = tbDescricao.Text;
					tipo.Producao = cbProducao.Checked;
					tipo.Estoque = cbEstoque.Checked;
					tipo.Producao = cbProducao.Checked;
					tipo.Soma = cbSoma.Checked;
					tipo.ImprimeQuantidadeTotal = cbImprimeTotal.Checked;
					tipo.ImpressoraExterna = cbImpressora.SelectedIndex;
					tipo.Adicionais = cbAdicionais.Checked;
					tipo.MeioAMeio = cbMeioAMeio.Checked;
					tipo.Fracionado = cbFracionado.Checked;
					tipo.PermiteLocacao = cbPermiteLocacao.Checked;
					tipo.IntervaloDeLocacao = cbLocacaoPeriodo.Text;

					int periodo;
					int.TryParse(tbPeriodo.Text, out periodo);
					tipo.PeriodoLocacao = periodo;

					foreach (LocacaoEspecial l in lbLocacaoEspecial.Items)
					{
						tipo.LocacaoEspecial.Add(l);
					}

					if (tbCodigo.ReadOnly)
					{
						if (_dsoftBd.AlterarProdutoTipo(tipo))
						{
							LimparCampos();

							Atualizar();
						}
					}
					else
					{
						if (_dsoftBd.NovoProdutoTipo(tipo))
						{
							LimparCampos();

							Atualizar();
						}
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text);
			}
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				CarregarDados(dgProdutosTipos.CurrentRow.Index);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text);
			}
		}

		private void frmCadTiposProdutos_Load(object sender, EventArgs e)
		{
			Atualizar();

			PreencherIntervalosLocacao();

			LimparCampos();
		}

		private void LimparCampos()
		{
			tbCodigo.Clear();
			tbNome.Clear();
			tbDescricao.Clear();
			cbProducao.Checked = false;
			cbEstoque.Checked = false;
			cbImpressora.SelectedIndex = 0;
			cbImprimeTotal.Checked = false;
			cbAdicionais.Checked = false;
			cbMeioAMeio.Checked = false;
			cbFracionado.Checked = false;
			cbPermiteLocacao.Checked = false;
			cbLocacaoPeriodo.SelectedItem = null;
			tbPeriodo.Text = string.Empty;
			tbLocacaoEspecial.Text = string.Empty;
			tbPeriodoEspecial.Text = string.Empty;
			lbLocacaoEspecial.Items.Clear();

			tabControl1.Enabled = false;

			tbCodigo.ReadOnly = false;

			button1.Text = "&Novo - F2";
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
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

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && tbNome.Text.Length > 0)
			{
				tbDescricao.Focus();
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cbProducao.Focus();
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void cbPermiteLocacao_CheckedChanged(object sender, EventArgs e)
		{
			cbLocacaoPeriodo.Enabled = cbPermiteLocacao.Checked;
			tbPeriodo.Enabled = cbPermiteLocacao.Checked;

			if (cbPermiteLocacao.Checked == false)
			{
				cbLocacaoPeriodo.Text = "";
				tbPeriodo.Text = "";
			}
		}

		private void PreencherIntervalosLocacao()
		{
			cbLocacaoPeriodo.Items.Clear();

			cbLocacaoPeriodo.Items.Add("");
			cbLocacaoPeriodo.Items.Add("MINUTOS");
		}

		private void btAdicionar_Click(object sender, EventArgs e)
		{
			AdicionarEspeciais();
		}

		private void AdicionarEspeciais()
		{
			if (tbLocacaoEspecial.Text.Length < 1)
			{
				tbLocacaoEspecial.Focus();
				return;
			}

			if (tbPeriodoEspecial.Text.Length < 1)
			{
				tbPeriodoEspecial.Focus();
				return;
			}

			int periodo;
			int.TryParse(tbPeriodoEspecial.Text, out periodo);

			if (periodo == 0)
			{
				tbPeriodoEspecial.SelectAll();
				tbPeriodoEspecial.Focus();
				return;
			}

			LocacaoEspecial locacao = new LocacaoEspecial();
			locacao.Descricao = tbLocacaoEspecial.Text;
			locacao.Periodo = periodo;

			lbLocacaoEspecial.Items.Add(locacao);
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

			if (_dsoftBd.AdicionarItemAdicional(itemAdicional, _produtoTipo))
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

			_produtoTipo = _dsoftBd.CarregarProdutoTipo(Convert.ToInt32(tbCodigo.Text));

			_dsoftBd.CarregarItensAdicionais(ds, _produtoTipo);

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

			if (_dsoftBd.ExcluirItemAdicional(itemAdicional, _produtoTipo))
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