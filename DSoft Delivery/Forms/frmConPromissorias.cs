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
	public partial class frmConPromissorias : Form
	{
		#region Fields

		private DataSet dataSet = new DataSet();
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConPromissorias(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			if (cbCliente.Text == string.Empty)
			{
				DataSet ds = new DataSet();

				if (cbAberto.Checked || cbPagas.Checked)
					_dsoftBd.CarregarPromissorias(dtInicial.Value, dtFinal.Value, radioButton1.Checked, cbPagas.Checked, cbAberto.Checked, ds);

				dataSet = ds;

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["indice"].Width = 70;
				dataGridView1.Columns["data"].Width = 70;
				dataGridView1.Columns["pedido"].Width = 70;
				dataGridView1.Columns["valor"].Width = 90;
				dataGridView1.Columns["parcela"].Width = 70;
				dataGridView1.Columns["vencimento"].Width = 70;
				dataGridView1.Columns["pago_data"].Width = 70;
				dataGridView1.Columns["multa"].Width = 90;
				dataGridView1.Columns["juros"].Width = 90;
				dataGridView1.Columns["total_pago"].Width = 90;
				dataGridView1.Columns["cliente"].Width = 90;
				dataGridView1.Columns["cliente_nome"].Width = 300;
				dataGridView1.Columns["numero"].Width = 110;
				dataGridView1.Columns["situacao"].Width = 40;

				dataGridView1.Columns["indice"].HeaderText = "Índice";
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["pedido"].HeaderText = "Pedido";
				dataGridView1.Columns["valor"].HeaderText = "Valor (R$)";
				dataGridView1.Columns["parcela"].HeaderText = "Parcela";
				dataGridView1.Columns["vencimento"].HeaderText = "Vencimento";
				dataGridView1.Columns["pago_data"].HeaderText = "Pagamento";
				dataGridView1.Columns["multa"].HeaderText = "Multa (R$)";
				dataGridView1.Columns["juros"].HeaderText = "Juros (R$)";
				dataGridView1.Columns["total_pago"].HeaderText = "Pago (R$)";
				dataGridView1.Columns["cliente"].HeaderText = "Cliente";
				dataGridView1.Columns["cliente_nome"].HeaderText = "Nome";
				dataGridView1.Columns["numero"].HeaderText = "Promissória";
				dataGridView1.Columns["situacao"].HeaderText = "Sit.";

				dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["valor"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["parcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["multa"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["multa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["juros"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["juros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["total_pago"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["total_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
			else
			{
				long cliente;

				if (long.TryParse(cbCliente.Text.Split(" - ".ToCharArray(), 2)[0], out cliente))
				{
					if (!_dsoftBd.ClienteCadastrado(cliente))
					{
						MessageBox.Show("Cliente inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						return;
					}
				}
				else
				{
					if ((cliente = _dsoftBd.ClienteCodigo(cbCliente.Text)) == 0)
					{
						MessageBox.Show("Cliente inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

						return;
					}
				}

				DataSet ds = new DataSet();

				_dsoftBd.CarregarPromissorias(cliente, dtInicial.Value, dtFinal.Value, cbPagas.Checked, ds);

				dataGridView1.DataSource = ds.Tables[0];

				dataGridView1.Columns["indice"].Width = 70;
				dataGridView1.Columns["data"].Width = 70;
				dataGridView1.Columns["pedido"].Width = 70;
				dataGridView1.Columns["valor"].Width = 90;
				dataGridView1.Columns["parcela"].Width = 70;
				dataGridView1.Columns["vencimento"].Width = 70;
				dataGridView1.Columns["pago_data"].Width = 70;
				dataGridView1.Columns["multa"].Width = 90;
				dataGridView1.Columns["juros"].Width = 90;
				dataGridView1.Columns["total_pago"].Width = 90;
				dataGridView1.Columns["numero"].Width = 110;
				dataGridView1.Columns["situacao"].Width = 40;

				dataGridView1.Columns["indice"].HeaderText = "Índice";
				dataGridView1.Columns["data"].HeaderText = "Data";
				dataGridView1.Columns["pedido"].HeaderText = "Pedido";
				dataGridView1.Columns["valor"].HeaderText = "Valor (R$)";
				dataGridView1.Columns["parcela"].HeaderText = "Parcela";
				dataGridView1.Columns["vencimento"].HeaderText = "Vencimento";
				dataGridView1.Columns["pago_data"].HeaderText = "Pagamento";
				dataGridView1.Columns["multa"].HeaderText = "Multa (R$)";
				dataGridView1.Columns["juros"].HeaderText = "Juros (R$)";
				dataGridView1.Columns["total_pago"].HeaderText = "Pago (R$)";
				dataGridView1.Columns["numero"].HeaderText = "Promissória";
				dataGridView1.Columns["situacao"].HeaderText = "Sit.";

				dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["valor"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["parcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["multa"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["multa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["juros"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["juros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["total_pago"].DefaultCellStyle.Format = "###,###,##0.00";
				dataGridView1.Columns["total_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dataGridView1.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}

			Pintar();
		}

		private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void btAtualizar_Click(object sender, EventArgs e)
		{
			Atualizar();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}

		private void CarregarClientes()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarClientesNomeCodigo(ds);

			cbCliente.Items.Clear();

			cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				cbCliente.Items.Add(dr.ItemArray[0].ToString());
			}

			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				cbCliente.Items.Add(dr.ItemArray[1].ToString() + " - " + dr.ItemArray[0].ToString());
			}

			cbCliente.DropDownStyle = ComboBoxStyle.DropDown;
		}

		private void dataGridView1_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
		{
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				frmRecebimentos form = new frmRecebimentos(_dsoftBd, _usuario);

				form.NumeroPagamento = long.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["numero"].Value.ToString());

				if (form.ShowDialog() == DialogResult.OK)
					Atualizar();
			}
		}

		private void dataGridView1_Sorted(object sender, EventArgs e)
		{
			Pintar();
		}

		private void Exportar()
		{
			if (MessageBox.Show("Confirma a criação do arquivo de exportação?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				string arquivo = /*Matriz.Pasta2() + */"\\promissorias_" + Filial.Instance().Codigo.ToString() + ".xml";

				DataSet ds = new DataSet();

				_dsoftBd.CarregarPromissorias(ds);

				ds.DataSetName = "promissorias_" + Filial.Instance().Codigo.ToString();
				ds.Tables[0].TableName = "promissorias";

				ds.Tables[0].WriteXml(arquivo);

				MessageBox.Show("Arquivo gerado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmConPromissorias_Load(object sender, EventArgs e)
		{
			CarregarClientes();

			Atualizar();
		}

		private void Imprimir()
		{
			//frmRelatorio form = new frmRelatorio();

			//relPromissorias report = new relPromissorias();

			//report.ParameterFields["inicial"].CurrentValues.AddValue(dtInicial.Value.Date);
			//report.ParameterFields["final"].CurrentValues.AddValue(dtFinal.Value.Date);
			//report.ParameterFields["Cabecalho"].CurrentValues.AddValue(Preferencias.Titulo);
			//report.ParameterFields["porEmissao"].CurrentValues.AddValue(radioButton1.Checked);
			//report.ParameterFields["aberto"].CurrentValues.AddValue(cbAberto.Checked);
			//report.ParameterFields["pagas"].CurrentValues.AddValue(cbPagas.Checked);

			//if (radioButton1.Checked)
			//{
			//    report.ParameterFields["OrdenadoPor"].CurrentValues.AddValue("Lançamento");
			//}
			//else
			//{
			//    report.ParameterFields["OrdenadoPor"].CurrentValues.AddValue("Pagamento");
			//}

			//if (cbPagas.Checked && cbAberto.Checked)
			//{
			//    report.ParameterFields["Filtro"].CurrentValues.AddValue("Todas");
			//}
			//else if (cbAberto.Checked)
			//{
			//    report.ParameterFields["Filtro"].CurrentValues.AddValue("Em Aberto");
			//}
			//else if (cbPagas.Checked)
			//{
			//    report.ParameterFields["Filtro"].CurrentValues.AddValue("Pagas");
			//}
			//else
			//    return;

			//form.Text = "Relatório de Promissórias";
			////form.crystalReportViewer1.ReportSource = report;

			//form.Show();
		}

		private void Listar()
		{
			RelatorioHtml relatorio = new RelatorioHtml();

			relatorio.Arquivo = "lista_promissoria";
			relatorio.Descricao = "Listagem de Promissorias";
			relatorio.Titulo = "Listagem de Promissorias";

			relatorio.Gerar(dataSet);
		}

		private void listarPromissóriasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Listar();
		}

		private void Pintar()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "P":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
					break;

				case "R":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
					break;

				case "A":
					if (DateTime.Compare(DateTime.Parse(dataGridView1.Rows[i].Cells["vencimento"].Value.ToString()), DateTime.Now) < 0)
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
					}

					break;

				case "C":
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
					break;
				}
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				dataGridView1.Sort(dataGridView1.Columns["data"], ListSortDirection.Ascending);
			}
			else
			{
				dataGridView1.Sort(dataGridView1.Columns["pago_data"], ListSortDirection.Ascending);
			}

			Pintar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			Exportar();
		}

		#endregion Methods
	}
}