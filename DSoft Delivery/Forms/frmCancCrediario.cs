using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public partial class frmCancCrediario : Form
	{
		#region Fields

		private int Indice;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCancCrediario(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
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

		private void Carregar(int numero)
		{
			bool em_aberto = true;

			Crediario crediario = new Crediario();

			crediario.Numero = numero;
			Indice = numero;

			if (!_dsoftBd.CarregarCrediario(crediario))
			{
				return;
			}

			tbCliente.Text = crediario.Cliente.Codigo.ToString() + crediario.Cliente.Nome;
			tbParcelas.Text = crediario.Parcelas.Tables[0].Rows.Count.ToString();
			tbValor.Text = crediario.ValorTotal.ToString("###,###,##0.00");

			dataGridView1.DataSource = crediario.Parcelas.Tables[0];

			dataGridView1.Columns["numero"].Width = 90;
			dataGridView1.Columns["data"].Width = 90;
			dataGridView1.Columns["situacao"].Width = 40;
			dataGridView1.Columns["valor"].Width = 90;
			dataGridView1.Columns["parcela"].Width = 40;
			dataGridView1.Columns["vencimento"].Width = 90;
			dataGridView1.Columns["total_pago"].Width = 90;

			dataGridView1.Columns["numero"].HeaderText = "Número";
			dataGridView1.Columns["data"].HeaderText = "Data";
			dataGridView1.Columns["situacao"].HeaderText = "Sit.";
			dataGridView1.Columns["valor"].HeaderText = "Valor R$";
			dataGridView1.Columns["parcela"].HeaderText = "Parc";
			dataGridView1.Columns["vencimento"].HeaderText = "Vencimento";
			dataGridView1.Columns["total_pago"].HeaderText = "Pago R$";

			dataGridView1.Columns["numero"].DisplayIndex = 0;
			dataGridView1.Columns["data"].DisplayIndex = 1;
			dataGridView1.Columns["parcela"].DisplayIndex = 2;
			dataGridView1.Columns["valor"].DisplayIndex = 3;
			dataGridView1.Columns["total_pago"].DisplayIndex = 4;
			dataGridView1.Columns["vencimento"].DisplayIndex = 5;
			dataGridView1.Columns["situacao"].DisplayIndex = 6;

			dataGridView1.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["valor"].DefaultCellStyle.Format = "###,###,##0.00";
			dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["parcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["total_pago"].DefaultCellStyle.Format = "###,###,##0.00";
			dataGridView1.Columns["total_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				switch (dataGridView1.Rows[i].Cells["situacao"].Value.ToString())
				{
				case "P":
					em_aberto = false;
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
					break;

				case "R":
					em_aberto = false;
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

			if (!em_aberto)
			{
				btConfirmar.Enabled = false;
				confirmarToolStripMenuItem.Enabled = false;

				MessageBox.Show("Crediário não pode ser cancelado! Todas as parcelas precisam estar em aberto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				btConfirmar.Enabled = true;
				confirmarToolStripMenuItem.Enabled = true;
			}
		}

		private void Confirmar()
		{
			//if (_usuario.Nivel != 'A')
			//{
			//    frmCapturaUsuario form = new frmCapturaUsuario(_dsoftBd, _usuario);

			//    if (form.ShowDialog() != DialogResult.OK)
			//        return;
			//}
			//else
			//{
			//    Globais.UsuarioTemporario = _usuario.Autorizado;
			//}

			//if (MessageBox.Show("Confirma o cancelamento do crediário?" + Environment.NewLine + "(O pedido referente ficará em aberto.)", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
			//    != DialogResult.Yes)
			//    return;

			//if (_dsoftBd.CancelarCrediario(Indice, Globais.UsuarioTemporario))
			//{
			//    //Sync
			//    if (RegrasDeNegocio.Instance.Ramo == "LOJA"/* && Matriz.Sincroniza()*/)
			//    {
			//        Crediario crediario = new Crediario();

			//        crediario.Numero = Indice;

			//        _dsoftBd.CarregarCrediario(crediario);

			//        for (int i = 0; i < crediario.Parcelas.Tables[0].Rows.Count; i++)
			//        {
			//            Sync.CancelaParcela(long.Parse(crediario.Parcelas.Tables[0].Rows[i].ItemArray[0].ToString()));
			//        }
			//    }

			//    MessageBox.Show("Cancelamento efetuado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			//    Close();
			//}
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCrediario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbCrediario.Text.Length > 0)
			{
				int crediario;

				if (!int.TryParse(tbCrediario.Text, out crediario))
				{
					MessageBox.Show("Campo 'crediario' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					tbCrediario.SelectAll();

					return;
				}

				Carregar(crediario);
			}
		}

		private void tbCrediario_Leave(object sender, EventArgs e)
		{
			if (tbCrediario.Text.Length > 0)
			{
				int crediario;

				if (!int.TryParse(tbCrediario.Text, out crediario))
				{
					MessageBox.Show("Campo 'crediario' deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					tbCrediario.SelectAll();

					return;
				}

				Carregar(crediario);
			}
		}

		#endregion Methods
	}
}