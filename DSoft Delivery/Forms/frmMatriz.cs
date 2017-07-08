using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmMatriz : Form
	{
		#region Constructors

		public frmMatriz()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbMatriz_CheckedChanged(object sender, EventArgs e)
		{
			if (cbMatriz.Checked)
				gbParametros.Enabled = true;
			else
				gbParametros.Enabled = false;
		}

		void Confirmar()
		{
			DialogResult d = MessageBox.Show("Confirma gravação dos dados?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			if (d == DialogResult.Yes)
			{
				Matriz matriz = new Matriz();

				matriz._Matriz = cbMatriz.Checked;
				matriz._Servidor = tbServidor.Text;

				if (tbPorta.Text.Length > 0)
				{
					if (!long.TryParse(tbPorta.Text, out matriz._Porta))
					{
						MessageBox.Show("Campo 'porta' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						tbPorta.SelectAll();
						tbPorta.Focus();
						return;
					}
				}
				else
					matriz._Porta = 0;

				if (tbIntervalo.Text.Length == 0)
				{
					MessageBox.Show("Campo 'intervalo' deve ser definido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbIntervalo.Focus();
					return;
				}

				if (!int.TryParse(tbIntervalo.Text, out matriz._Intervalo))
				{
					MessageBox.Show("Campo 'intervalo' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tbIntervalo.SelectAll();
					tbIntervalo.Focus();
					return;
				}

				matriz._Pasta = tbPasta.Text;

				//matriz.Salvar();

				Sair();
			}
			else if (d == DialogResult.No)
			{
				Sair();
			}
			else
			{
				return;
			}
		}

		private void frmMatriz_Load(object sender, EventArgs e)
		{
			Matriz matriz = new Matriz();

			gbParametros.Enabled = cbMatriz.Checked = matriz._Matriz;
			tbServidor.Text = matriz._Servidor;
			tbPorta.Text = matriz._Porta.ToString();
			tbIntervalo.Text = matriz._Intervalo.ToString();
			tbPasta.Text = matriz._Pasta;
		}

		void Sair()
		{
			Close();
		}

		#endregion Methods
	}
}