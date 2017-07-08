using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftCore;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Forms
{
	public partial class frmConEntregasPorEntregador : Form
	{
		#region Fields

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConEntregasPorEntregador(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btBuscar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbEntregador_SelectedValueChanged(object sender, EventArgs e)
		{
			LimparConsulta();
		}

		private void Consultar()
		{
			if (cbEntregador.SelectedItem == null)
			{
				MessageBox.Show("Selecione o entregador!");
				return;
			}

			int codigo;
			int.TryParse(cbEntregador.Text.Split(" - ".ToCharArray())[0], out codigo);

			if (codigo == default(int))
			{
				MessageBox.Show("Entregador inválido!");
				return;
			}

			Recurso recurso = new Recurso();
			recurso.Codigo = codigo;

			DataTable resultado = _dsoftBd.EntregasPorEntregador(recurso, dtInicial.Value, dtFinal.Value);

			if (resultado == null)
			{
				return;
			}

			dataGridView1.DataSource = resultado;

			dataGridView1.Columns["saida"].DefaultCellStyle.Format = "HH:mm:ss";
			dataGridView1.Columns["entrega"].DefaultCellStyle.Format = "HH:mm:ss";

			Util.Pintar(ref dataGridView1);

			tbQuantidade.Text = resultado.Rows.Count.ToString();
		}

		private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int pedido;
				int.TryParse(dataGridView1.SelectedRows[0].Cells["pedido"].Value.ToString(), out pedido);

				if (pedido > 0)
				{
					frmDemonstraPedido form = new frmDemonstraPedido(_dsoftBd, _usuario, pedido);
					form.Show();
				}
			}
		}

		private void dtFinal_ValueChanged(object sender, EventArgs e)
		{
			LimparConsulta();
		}

		private void dtInicial_ValueChanged(object sender, EventArgs e)
		{
			LimparConsulta();
		}

		private void frmConEntregasPorEntregador_Load(object sender, EventArgs e)
		{
			PreencherEntregadores();
		}

		private void Imprimir()
		{
			DataTable consulta = dataGridView1.DataSource as DataTable;

			if (consulta == null || consulta.Rows.Count == 0)
			{
				MessageBox.Show("Não existem dados para serem impressos!");
				return;
			}

			if (Terminal.RelatoriosMatricial)
			{
				if (string.IsNullOrEmpty(Terminal.Impressora()))
				{
					MessageBox.Show("Nenhuma impressora foi selecionada no Terminal!");
					return;
				}

				Impressora.ImprimirBuffer("CONSULTA DE ENTREGAS" + Environment.NewLine);
				Impressora.ImprimirBuffer(cbEntregador.Text + Environment.NewLine);
				Impressora.ImprimirBuffer(dtInicial.Value.ToShortDateString() + " ate " + dtFinal.Value.ToShortDateString() + Environment.NewLine);
				Impressora.ImprimirLinha(true);

				Impressora.ImprimirBuffer("PED.   DATA          SAIDA  CHEGADA  " + Environment.NewLine);

				foreach (DataRow dr in consulta.Rows)
				{
					Impressora.ImprimirBuffer(string.Format("{0,4} {1,12} {2,8} {3,8}", dr["pedido"].ToString(), Convert.ToDateTime(dr["data"]).ToShortDateString(),
						Convert.ToDateTime(dr["saida"]).ToShortTimeString(), Convert.ToDateTime(dr["entrega"]).ToShortTimeString() + Environment.NewLine));
				}

				Impressora.ImprimirLinha(true);
				Impressora.ImprimirBuffer("TOTAL DE ENTREGAS: " + tbQuantidade.Text + Environment.NewLine + Environment.NewLine);
				Impressora.ImprimirBuffer();
			}
		}

		private void LimparConsulta()
		{
			dataGridView1.DataSource = null;
			tbQuantidade.Text = string.Empty;
		}

		private void PreencherEntregadores()
		{
			cbEntregador.Items.Clear();

			DataSet ds = new DataSet();

			if (_dsoftBd.CarregarRecursos(ds))
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					if (row != null)
					{
						bool entrega;
						bool.TryParse(row["entrega"].ToString(), out entrega);

						if (entrega)
						{
							cbEntregador.Items.Add(row["codigo"].ToString() + " - " + row["nome"].ToString());
						}
					}
				}
			}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion Methods
	}
}