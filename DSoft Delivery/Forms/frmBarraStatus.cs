using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery
{
	public partial class frmBarraStatus : Form
	{
		#region Constructors

		public frmBarraStatus()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void btCancelar_Click(object sender, EventArgs e)
		{
			//Globais.Resultado = DialogResult.Cancel;
			Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//if (pbBarra.Maximum != Globais.Maximo)
			//    pbBarra.Maximum = Globais.Maximo;

			//pbBarra.Value = Globais.Valor;
			//lbDetalhes.Text = Globais.Mensagem;
		}

		#endregion Methods
	}
}