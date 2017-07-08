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

namespace DSoft_Delivery
{
	public partial class frmConMargemLucro : Form
	{
		#region Fields

		private DateTime dataInicial, dataFinal;
		private DataSet dataSet = null;
		private int TabelaBase;
		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConMargemLucro(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void AdicionarBase()
		{
			int tabela;

			if (cbTabela.Text.Length == 0)
				return;

			if (dataGridView1.Rows.Count < 1)
				return;

			tabela = int.Parse(cbTabela.Text.Split(" - ".ToCharArray(), 2)[0]);
			TabelaBase = tabela;

			DataSet ds = new DataSet();

			_DSoftBd.ProdutosPrecos(tabela, ds);

			for (int i = 0; i <dataGridView1.Rows.Count; i++)
			{
				dataGridView1.Rows[i].Cells["base"].Value = _DSoftBd.ProdutoPreco(Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value), tabela).ToString("##,###,##0.00");
			}

			CalcularMargem();
			CalcularLucro();
			SomarTotais();

			//dataSet.Tables.Clear();
			//dataSet.Tables.Add((DataTable)dataGridView1.DataSource);
		}

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.ProdutosPeriodo(ds, dtInicial.Value, dtFinal.Value);

			ds.Tables[0].Columns.Add("base");
			ds.Tables[0].Columns.Add("margem");
			ds.Tables[0].Columns.Add("lucro");

			dataSet = ds.Copy();
			dataInicial = dtInicial.Value;
			dataFinal = dtFinal.Value;

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["produto"].HeaderText = "Código";
			dataGridView1.Columns["produto"].Width = 60;
			dataGridView1.Columns["nome"].HeaderText = "Produto";
			dataGridView1.Columns["nome"].Width = 240;
			dataGridView1.Columns["quantidade"].HeaderText = "Quant.";
			dataGridView1.Columns["quantidade"].Width = 60;
			dataGridView1.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["preco"].HeaderText = "Preço (R$)";
			dataGridView1.Columns["preco"].Width = 90;
			dataGridView1.Columns["preco"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["base"].HeaderText = "Base (R$)";
			dataGridView1.Columns["base"].Width = 90;
			dataGridView1.Columns["base"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["base"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["margem"].HeaderText = "Margem (%)";
			dataGridView1.Columns["margem"].Width = 80;
			dataGridView1.Columns["margem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["lucro"].HeaderText = "Lucro (R$)";
			dataGridView1.Columns["lucro"].Width = 90;
			dataGridView1.Columns["lucro"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["lucro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			AdicionarBase();
		}

		private void btAtualizar_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void CalcularLucro()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				double preco, preco2, quantidade;

				preco = Convert.ToDouble(dataGridView1.Rows[i].Cells["preco"].Value);
				preco2 = Convert.ToDouble(dataGridView1.Rows[i].Cells["base"].Value);
				quantidade = Convert.ToDouble(dataGridView1.Rows[i].Cells["quantidade"].Value);

				dataGridView1.Rows[i].Cells["lucro"].Value = (preco - (preco2 * quantidade)).ToString("##,###,##0.00");
			}
		}

		private void CalcularMargem()
		{
			try
			{
				foreach (DataGridViewRow r in dataGridView1.Rows)
				{
					double b, d, p, m;

					b = double.Parse(r.Cells["base"].Value.ToString());
					p = double.Parse(r.Cells["preco"].Value.ToString()) / double.Parse(r.Cells["quantidade"].Value.ToString());

					d = p - b;

					if (b == 0 && p > 0)
						m = 100;
					else if (b == 0 && p == 0)
						m = 0;
					else
						//m = ((p - b) / p) * 100;
						m = ((p - b) * 100) / b;

					r.Cells["margem"].Value = m.ToString("##,###,##0.00");
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao calcular margem." + Environment.NewLine + e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbTabela_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btAtualizar.Focus();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void dtFinal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				cbTabela.Focus();
		}

		private void dtInicial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				dtFinal.Focus();
		}

		private void frmConMargemLucro_Load(object sender, EventArgs e)
		{
			string[] tabelas;

			if (_DSoftBd.CarregarTabelas(out tabelas))
			{
				for (int i = 0; i < tabelas.Length; i++)
				{
					cbTabela.Items.Add(tabelas[i]);
				}

				cbTabela.Text = cbTabela.Items[1].ToString();
			}
		}

		private void Imprimir()
		{
			RelatorioHtml.GerarMargemLucros(dataInicial, dataFinal, TabelaBase, (DataTable)dataGridView1.DataSource);
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void SomarTotais()
		{
			double quantidade = 0;
			double total = 0;
			double margem = 0;
			double lucro = 0;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				quantidade += Convert.ToDouble(dataGridView1.Rows[i].Cells["quantidade"].Value);
				total += Convert.ToDouble(dataGridView1.Rows[i].Cells["preco"].Value);
				margem += Convert.ToDouble(dataGridView1.Rows[i].Cells["margem"].Value);
				lucro += Convert.ToDouble(dataGridView1.Rows[i].Cells["lucro"].Value);
			}

			tbProdutos.Text = quantidade.ToString();
			tbValorTotal.Text = total.ToString("##,###,##0.00");
			tbMargem.Text = (margem / dataGridView1.Rows.Count).ToString("#,##0.00");
			tbLucro.Text = lucro.ToString("##,###,##0.00");
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		#endregion Methods
	}
}