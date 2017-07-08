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
	public partial class frmFiltroPedidosCliente : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmFiltroPedidosCliente(Bd bd, Usuario usuario)
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

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Confirmar()
		{
			//int cliente;
			//double soma;

			//RelatorioHtml relatorio = new RelatorioHtml();

			//DataSet ds = new DataSet();

			//relatorio.Arquivo = "Pedidos_por_Cliente";
			//relatorio.Titulo = "Pedidos por Cliente";

			//if (tbCliente.Text.Length == 0)
			//{
			//    relatorio.Descricao = "Pedidos efetuados por todos os clientes no periodo de " + dtInicial.Value.ToShortDateString() +
			//                            " e " + dtFinal.Value.ToShortDateString();

			//    soma = Consultas.PedidosPorPeriodo(dtInicial.Value, dtFinal.Value, ref ds);

			//    relatorio.Rodape = "TOTAL REAL :   R$" + soma.ToString("###,###,##0.00");
			//}
			//else
			//{
			//    if (!int.TryParse(tbCliente.Text, out cliente) || !Bd.CaixaAtivo(cliente))
			//    {
			//        MessageBox.Show("Caixa inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			//        tbCliente.SelectAll();
			//        tbCliente.Focus();

			//        return;
			//    }

			//    relatorio.Descricao = "Pedidos efetuados pelo cliente " + tbCliente.Text + " - " + Bd.CaixaDescricao(int.Parse(textBox1.Text)) +
			//        " no periodo de " + dateTimePicker1.Value.ToShortDateString() + " e " + dateTimePicker2.Value.ToShortDateString();

			//    soma = Consultas.PedidosPorPeriodo(dateTimePicker1.Value, dateTimePicker2.Value, caixa, ref ds);

			//    relatorio.Rodape = "VALOR TOTAL :   R$ " + soma.ToString("###,###,##0.00");
			//}

			//relatorio.Gerar(ref ds);

			//Sair();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void dtFinal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				tbCliente.Focus();
		}

		private void dtInicial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				dtFinal.Focus();
		}

		private void frmFiltroPedidosCliente_Load(object sender, EventArgs e)
		{
			dtInicial.Focus();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btConfirmar.Focus();
		}

		private void tbCliente_Leave(object sender, EventArgs e)
		{
			int codigo;
			string nome = string.Empty;
			char situacao = '0';

			if (tbCliente.Text.Length == 0)
				return;

			if (!int.TryParse(tbCliente.Text, out codigo))
			{
				MessageBox.Show("Campo 'código' deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbCliente.SelectAll();
				tbCliente.Focus();

				return;
			}

			if (!_DSoftBd.ClienteNome(codigo, out nome, out situacao))
			{
				MessageBox.Show("Cliente não encontrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbCliente.SelectAll();
				tbCliente.Focus();

				return;
			}

			lbCliente.Text = nome;
		}

		#endregion Methods
	}
}