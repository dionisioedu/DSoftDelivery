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
	public partial class frmCrediario : Form
	{
		#region Fields

		public long Cliente;
		public Parcela[] Parcelas;
		public double Valor;

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCrediario(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btGerar_Click(object sender, EventArgs e)
		{
			Gerar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			double valor_teste = 0;

			if (tbValorTotal.Text == string.Empty)
				return;

			Valor = double.Parse(tbValor.Text);

			Parcela[] parcela = new Parcela[dataGridView1.Rows.Count];

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				parcela[i] = new Parcela();

				parcela[i].Numero = int.Parse(dataGridView1.Rows[i].Cells["Numero"].Value.ToString());
				parcela[i].Vencimento = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Vencimento"].Value.ToString());
				parcela[i].Valor = double.Parse(dataGridView1.Rows[i].Cells["Valor"].Value.ToString());
				parcela[i].Juros = double.Parse(dataGridView1.Rows[i].Cells["Juros"].Value.ToString());
				parcela[i].Total = double.Parse(dataGridView1.Rows[i].Cells["Total"].Value.ToString());

				valor_teste += parcela[i].Total;
			}

			if (valor_teste != Valor)
			{
				MessageBox.Show("Valor incorreto!", Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			Parcelas = parcela;

			this.DialogResult = System.Windows.Forms.DialogResult.OK;

			Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dtVencimento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbParcelas.Focus();
			}
		}

		private void frmCrediario_Load(object sender, EventArgs e)
		{
			double saldo;
			double limite;
			double disponivel;
			double pendente;

			tbCliente.Text = _DSoftBd.ClienteNome(Cliente);

			saldo = _DSoftBd.ClienteSaldo(Cliente);
			limite = _DSoftBd.ClienteLimite(Cliente);
			pendente = _DSoftBd.PagamentosPendentes(Cliente);
			disponivel = saldo + limite - pendente;

			tbSaldo.Text = saldo.ToString("###,###,##0.00");
			tbLimite.Text = limite.ToString("###,###,##0.00");
			tbPendente.Text = pendente.ToString("###,###,##0.00");
			tbDisponivel.Text = disponivel.ToString("###,###,##0.00");

			tbValor.Text = Valor.ToString("###,###,##0.00");

			dtVencimento.Focus();
		}

		private void Gerar()
		{
			int parcelas;
			double juros;
			double valor;
			double total_juros = 0;
			double total_valor = 0;

			if (!int.TryParse(tbParcelas.Text, out parcelas))
			{
				return;
			}

			if (!double.TryParse(tbJuros.Text, out juros))
			{
				juros = 0;
			}

			if (!double.TryParse(tbValor.Text, out valor))
			{
				return;
			}

			Parcela[] parcela = new Parcela[parcelas];

			for (int i = 0; i < parcelas; i++)
			{
				parcela[i] = new Parcela();

				parcela[i].Numero = i + 1;
				parcela[i].Vencimento = dtVencimento.Value.AddMonths(i);
				parcela[i].Valor = valor / parcelas;
				total_juros += parcela[i].Juros = (parcela[i].Valor * juros) / 100;
				total_valor += parcela[i].Total = parcela[i].Valor + parcela[i].Juros;
			}

			DataSet ds = new DataSet();

			ds.Tables.Add();

			ds.Tables[0].Columns.Add("Numero");
			ds.Tables[0].Columns.Add("Vencimento");
			ds.Tables[0].Columns.Add("Valor");
			ds.Tables[0].Columns.Add("Juros");
			ds.Tables[0].Columns.Add("Total");

			for (int i = 0; i < parcelas; i++)
			{
				DataRow dr = ds.Tables[0].NewRow();

				dr[0] = parcela[i].Numero;
				dr[1] = parcela[i].Vencimento.ToString("dd/MM/yy");
				dr[2] = parcela[i].Valor.ToString("###,###,##0.00");
				dr[3] = parcela[i].Juros.ToString("###,###,##0.00");
				dr[4] = parcela[i].Total.ToString("###,###,##0.00");

				ds.Tables[0].Rows.Add(dr);
			}

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["Numero"].Width = 60;
			dataGridView1.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["Vencimento"].Width = 90;
			dataGridView1.Columns["Valor"].Width = 90;
			dataGridView1.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["Juros"].Width = 90;
			dataGridView1.Columns["Juros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["Total"].Width = 90;
			dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			tbTotalJuros.Text = total_juros.ToString("###,###,##0.00");
			tbValorTotal.Text = total_valor.ToString("###,###,##0.00");

			Parcelas = parcela;
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbJuros_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btGerar.Focus();
			}
		}

		private void tbParcelas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbJuros.Focus();
			}
		}

		private void tbValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtVencimento.Focus();
			}
		}

		#endregion Methods
	}
}