using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery
{
	public partial class frmEstoqueMatriz : Form
	{
		#region Constructors

		public frmEstoqueMatriz()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			ds.ReadXml(/*Matriz.Pasta2() + */"\\matriz_estoque.xml");

			dataGridView1.DataSource = ds.Tables[0];

			dataGridView1.Columns["produto"].HeaderText = "Produto";
			dataGridView1.Columns["nome"].HeaderText = "Nome";
			dataGridView1.Columns["atual"].HeaderText = "Atual";
			dataGridView1.Columns["produto"].Width = 80;
			dataGridView1.Columns["nome"].Width = 200;
			dataGridView1.Columns["atual"].Width = 60;
			dataGridView1.Columns["JACUP"].Width = 60;
			dataGridView1.Columns["CANAN"].Width = 60;
			dataGridView1.Columns["CAJAT"].Width = 60;
			dataGridView1.Columns["ELDOR"].Width = 60;
			dataGridView1.Columns["PARIQ"].Width = 60;
			dataGridView1.Columns["PEDRO"].Width = 60;
			dataGridView1.Columns["ITARI"].Width = 60;
			dataGridView1.Columns["IPORA"].Width = 60;
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dataGridView1_Sorted(object sender, EventArgs e)
		{
			Pintar();
		}

		private void Filtrar(string filtro)
		{
			Atualizar();

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (!dataGridView1.Rows[i].Cells["nome"].Value.ToString().Contains(filtro))
				{
					dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
					i--;
				}
			}

			Pintar();
		}

		private void frmEstoqueMatriz_Load(object sender, EventArgs e)
		{
			Atualizar();
			Pintar();
		}

		private void Pintar()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (int.Parse(dataGridView1.Rows[i].Cells["atual"].Value.ToString()) < 1)
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (textBox1.Text.Length > 0)
					Filtrar(textBox1.Text);
				else
				{
					Atualizar();
					Pintar();
				}
			}
		}

		#endregion Methods
	}
}