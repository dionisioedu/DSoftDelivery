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
	public partial class frmControlePontos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmControlePontos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			if (!_DSoftBd.CarregarPontos(ds))
				return;

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["indice"].Width = 60;
			dataGridView1.Columns["indice"].HeaderText = "Índice";
			dataGridView1.Columns["data"].Width = 60;
			dataGridView1.Columns["data"].HeaderText = "Data";
			dataGridView1.Columns["hora"].Width = 60;
			dataGridView1.Columns["hora"].HeaderText = "Hora";
			dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dataGridView1.Columns["situacao"].Width = 40;
			dataGridView1.Columns["situacao"].HeaderText = "Sit.";
			dataGridView1.Columns["tipo"].Width = 40;
			dataGridView1.Columns["tipo"].HeaderText = "Tipo";
			dataGridView1.Columns["funcionario"].Width = 60;
			dataGridView1.Columns["funcionario"].HeaderText = "Código";
			dataGridView1.Columns["nome"].Width = 180;
			dataGridView1.Columns["nome"].HeaderText = "Nome";

			if (dataGridView1.Rows.Count > 1)
				dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
		}

		private void btNovo_Click(object sender, EventArgs e)
		{
			NovaEntrada();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void CarregarFuncionarios()
		{
			DataSet ds = new DataSet();

			_DSoftBd.ListaRecursos(ds);

			cbFuncionario.Items.Clear();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				cbFuncionario.Items.Add(r[0].ToString() + " - " + r[1].ToString());
			}
		}

		private void frmControlePontos_Load(object sender, EventArgs e)
		{
			CarregarFuncionarios();

			Atualizar();
		}

		private void NovaEntrada()
		{
			int funcionario;

			if (cbFuncionario.Text.Length == 0)
			{
				MessageBox.Show("Código de funcionário não informado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return;
			}

			if (!int.TryParse(cbFuncionario.Text.Split(" - ".ToCharArray(), 2)[0], out funcionario))
			{
				MessageBox.Show("Código de funcionário inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbFuncionario.SelectAll();

				return;
			}

			if (_DSoftBd.NovoPonto(funcionario, dtData.Value, dtHora.Value, true, _usuario.Autorizado))
			{
				dtData.Focus();

				Atualizar();
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

		private void timer1_Tick(object sender, EventArgs e)
		{
			dtData.Value = DateTime.Now;
			dtHora.Value = DateTime.Now;
		}

		#endregion Methods
	}
}