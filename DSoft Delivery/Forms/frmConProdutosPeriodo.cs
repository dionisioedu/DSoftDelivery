using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;
using System.Threading.Tasks;
using DSoftCore;
using System.Windows.Forms.DataVisualization.Charting;
using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmConProdutosPeriodo : Form
	{
		#region Fields

		private DateTime dataInicial, horaInicial, dataFinal, horaFinal;
		private DataSet dataSet;
		private Bd _dsoftBd;
		private Usuario _usuario;

		private bool _avoidRefresh = false;

		#endregion Fields

		#region Constructors

		public frmConProdutosPeriodo(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			refreshButton1.Click += button1_Click;
			quitButton.Click += btSair_Click;
			printLittleButton1.Click += btImprimir_Click;
		}

		#endregion Constructors

		#region Methods

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Confirmar()
		{
			DataSet ds = new DataSet();

			ProdutoTipo tipo = cbTipo.SelectedItem as ProdutoTipo;

			if (_dsoftBd.ProdutosPeriodo(ds, dtInicial.Value, hrInicial.Value, dtFinal.Value, hrFinal.Value, tipo))
			{
				dataSet = new DataSet();
				dataSet = ds.Copy();

				dataInicial = dtInicial.Value;
				horaInicial = hrInicial.Value;
				dataFinal = dtFinal.Value;
				horaFinal = hrFinal.Value;
			}

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["produto"].HeaderText = "Produto";
			dataGridView1.Columns["produto"].Width = 60;
			dataGridView1.Columns["produto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["nome"].HeaderText = "Nome";
			dataGridView1.Columns["nome"].Width = 210;
			dataGridView1.Columns["quantidade"].HeaderText = "Qtd.";
			dataGridView1.Columns["quantidade"].Width = 60;
			dataGridView1.Columns["quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["preco"].HeaderText = "Valor (R$)";
			dataGridView1.Columns["preco"].Width = 90;
			dataGridView1.Columns["preco"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dataGridView1.Columns["preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			decimal qtd = 0;
			decimal val = 0;

			//Somamos os totais
			foreach (DataRow r in ds.Tables[0].Rows)
			{
				qtd += Util.TryParseDecimal(r.ItemArray[2]);
				val += Util.TryParseDecimal(r.ItemArray[3]);
			}

			tbProdutos.Text = dataGridView1.Rows.Count.ToString();
			tbQuantidade.Text = qtd.ToString();
			tbValor.Text = val.ToString(Constants.FORMATO_MOEDA);

			_avoidRefresh = true;

			nmQuantidade.Value = (decimal)dataGridView1.Rows.Count;

			_avoidRefresh = false;

			Task.Factory.StartNew(() =>
			{
				CarregarGrafico();
			});
		}

		private void CarregarGrafico(int produtos = 0)
		{
			this.Invoke(new Action(() =>
			{
				chart1.Series.Clear();

				Series serie = chart1.Series.Add("produtos");
				serie.ChartType = SeriesChartType.Pie;

				if (produtos == 0)
					produtos = dataGridView1.Rows.Count;

				for (int i = 0; i < produtos; i++)
				{
					serie.Points.AddXY(dataGridView1["nome", i].Value, dataGridView1["quantidade", i].Value);
				}

				chart1.Invalidate();
			}));
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dtFinal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				refreshButton1.Focus();
			}
		}

		private void dtInicial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtFinal.Focus();
			}
		}

		private void frmConProdutosPeriodo_Load(object sender, EventArgs e)
		{
			hrInicial.Value = Convert.ToDateTime("00:00:00");
			hrFinal.Value = Convert.ToDateTime("23:59:59");

			dtInicial.Value = dtFinal.Value.AddMonths(-1);

			CarregarTiposDeProdutos();
		}

		private void CarregarTiposDeProdutos()
		{
			Task.Factory.StartNew(() =>
			{
				List<ProdutoTipo> tipos = _dsoftBd.ProdutosTipos();

				this.Invoke(new Action(() =>
				{
					cbTipo.Items.Add("");
					cbTipo.Items.AddRange(tipos.ToArray());
				}));
			});
		}

		private void Imprimir()
		{
			if (dataSet == null)
				return;

			if (Terminal.RelatoriosMatricial)
			{
				
			}
			else
			{
				RelatorioHtml.GerarProdutosPorPeriodo(dataInicial, horaInicial, dataFinal, horaFinal, ref dataSet);
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

		private void nmQuantidade_ValueChanged(object sender, EventArgs e)
		{
			if (_avoidRefresh == false)
			{
				CarregarGrafico((int)nmQuantidade.Value);
			}
		}

		#endregion Methods
	}
}