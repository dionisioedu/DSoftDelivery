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

namespace DSoft_Delivery.Forms
{
	public partial class frmEntregadoresDisponiveis : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmEntregadoresDisponiveis(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void dgEntregadores_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void CarregarEntregadores()
		{
			DataTable entregadores = _dsoftBd.CarregarEntregadores();

			dgEntregadores.DataSource = entregadores;

			for (int i = 0; i < dgEntregadores.Rows.Count; i++)
			{
				if (Convert.ToBoolean(dgEntregadores.Rows[i].Cells["disponivel"].Value))
				{
					dgEntregadores.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
				}
				else
				{
					dgEntregadores.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
				}

				dgEntregadores.Rows[i].Cells["codigo"].ReadOnly = true;
				dgEntregadores.Rows[i].Cells["nome"].ReadOnly = true;
			}
		}

		private void dgEntregadores_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
				int recurso = Convert.ToInt32(dgEntregadores[0, e.RowIndex].Value);
				bool disponivel = Convert.ToBoolean(dgEntregadores[2, e.RowIndex].Value);

				disponivel = !disponivel;

				_dsoftBd.AlterarDisponibilidadeEntregador(recurso, disponivel);

				dgEntregadores[2, e.RowIndex].Value = disponivel;

				if (disponivel)
				{
					dgEntregadores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
				}
				else
				{
					dgEntregadores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
				}
			}
		}

		private void frmEntregadoresDisponiveis_Load(object sender, EventArgs e)
		{
			CarregarEntregadores();
		}
	}
}
