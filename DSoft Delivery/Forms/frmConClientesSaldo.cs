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

using DSoft_Delivery.Relatorios;

namespace DSoft_Delivery
{
	public partial class frmConClientesSaldo : Form
	{
		#region Fields

		private DateTime dataInicial, dataFinal;
		private DataSet dataSet = null;
		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConClientesSaldo(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Delegates

		private delegate void Updater();

		#endregion Delegates

		#region Methods

		private void Atualizar()
		{
			dataInicial = dtInicial.Value;
			dataFinal = dtFinal.Value;

			dataSet.Tables[0].Columns.Add("periodo");

			dataGridView1.DataSource = dataSet.Tables[0];

			// Preenchemos os nulos com zeros
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (dataGridView1.Rows[i].Cells["debito"].Value.ToString() == "")
					dataGridView1.Rows[i].Cells["debito"].Value = "0";

				if (dataGridView1.Rows[i].Cells["entrada"].Value.ToString() == "")
					dataGridView1.Rows[i].Cells["entrada"].Value = "0";

				dataGridView1.Rows[i].Cells["periodo"].Value = (-Convert.ToDouble(dataGridView1.Rows[i].Cells["debito"].Value) +
					Convert.ToDouble(dataGridView1.Rows[i].Cells["entrada"].Value)).ToString("##,###,##0.00");
			}

			dataGridView1.Columns["codigo"].Width = 60;
			dataGridView1.Columns["codigo"].HeaderText = "Código";
			dataGridView1.Columns["nome"].Width = 180;
			dataGridView1.Columns["nome"].HeaderText = "Nome";
			dataGridView1.Columns["grupo"].Width = 80;
			dataGridView1.Columns["grupo"].HeaderText = "Grupo";
			dataGridView1.Columns["saldo"].Width = 80;
			dataGridView1.Columns["saldo"].HeaderText = "Saldo (R$)";
			dataGridView1.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["saldo"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["credito_limite"].Width = 80;
			dataGridView1.Columns["credito_limite"].HeaderText = "Limite (R$)";
			dataGridView1.Columns["credito_limite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["credito_limite"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["debito"].Width = 80;
			dataGridView1.Columns["debito"].HeaderText = "Débito (R$)";
			dataGridView1.Columns["debito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["debito"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["entrada"].Width = 80;
			dataGridView1.Columns["entrada"].HeaderText = "Entrada (R$)";
			dataGridView1.Columns["entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["entrada"].DefaultCellStyle.Format = "##,###,##0.00";
			dataGridView1.Columns["periodo"].Width = 80;
			dataGridView1.Columns["periodo"].HeaderText = "Período (R$)";
			dataGridView1.Columns["periodo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["periodo"].DefaultCellStyle.Format = "##,###,##0.00";
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btExtratos_Click(object sender, EventArgs e)
		{
			Extratos();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Carregar()
		{
			DataSet ds = new DataSet();

			_DSoftBd.GruposClientes(ds);

			cbGrupos.Items.Clear();

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				cbGrupos.Items.Add(ds.Tables[0].Rows[i].ItemArray[0] + " - " + ds.Tables[0].Rows[i].ItemArray[1]);
			}

			cbGrupos.Text = cbGrupos.Items[0].ToString();
		}

		private void Confirmar()
		{
			dataSet = new DataSet();

			if (cbGrupos.Text.Length < 1)
			{
				progressBar1.Visible = true;
				dataGridView1.UseWaitCursor = true;

				_DSoftBd.CarregarClientesAsync((double)0, dtInicial.Value, dtFinal.Value).ContinueWith((task) =>
				{
					if (task.Result != null)
					{
						dataSet = task.Result;

						this.Invoke(new Updater(() =>
						{
							Atualizar();

							progressBar1.Visible = false;
							dataGridView1.UseWaitCursor = false;
						}));
					}
				});
			}
			else
			{
				int grupo;

				if (!int.TryParse(cbGrupos.Text.Split(" - ".ToCharArray(), 2)[0], out grupo))
					return;

				progressBar1.Visible = true;
				dataGridView1.UseWaitCursor = true;

				_DSoftBd.CarregarClientesAsync(grupo, (double)0, dtInicial.Value, dtFinal.Value).ContinueWith((task) =>
				{
					if (task.Result != null)
					{
						dataSet = task.Result;

						this.Invoke(new Updater(() =>
						{
							Atualizar();

							progressBar1.Visible = false;
							dataGridView1.UseWaitCursor = false;
						}));
					}
				});
			}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Extratos()
		{
			if (dataSet != null)
				ExtratoFinanceiroPeriodo.Gerar(dataInicial, dataFinal, dataSet.Tables[0]);
		}

		private void frmConClientesSaldo_Load(object sender, EventArgs e)
		{
			Carregar();
		}

		private void Imprimir()
		{
			if (dataSet == null)
				return;

			RelatorioHtml.ListarClientesDevedores(dataSet.Tables[0], dataInicial, dataFinal);
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods
	}
}