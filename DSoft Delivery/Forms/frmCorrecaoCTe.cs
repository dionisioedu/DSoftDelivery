using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery.Forms
{
	public partial class frmCorrecaoCTe : Form
	{
		#region Constructors

		public frmCorrecaoCTe()
		{
			InitializeComponent();
		}

		public frmCorrecaoCTe(string emitente, string cte)
		{
			InitializeComponent();

			tbEmitente.Text = emitente;
			tbCTe.Text = cte;

			tbEmitente.ReadOnly = true;
			tbCTe.ReadOnly = true;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			CTeManager manager = new CTeManager();

			List<string[]> correcoes = new List<string[]>();
			string[] c = new string[3];
			c[0] = tbGrupo.Text;
			c[1] = tbCampo.Text;
			c[2] = tbValor.Text;

			correcoes.Add(c);

			int seqEvento = 0;

			if (!int.TryParse(tbSeqEvento.Text, out seqEvento))
			{
				lbErroSeqEvento.Visible = true;

				tbSeqEvento.SelectAll();
				tbSeqEvento.Focus();

				return;
			}

			manager.CorrecaoCTe(tbEmitente.Text, tbCTe.Text, tbProtocolo.Text, correcoes, seqEvento);

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbSeqEvento_TextChanged(object sender, EventArgs e)
		{
			int seq = 0;

			if (int.TryParse(tbSeqEvento.Text, out seq) && seq > 0)
			{
				lbErroSeqEvento.Visible = false;
			}
			else
			{
				lbErroSeqEvento.Visible = true;
			}
		}

		#endregion Methods
	}
}