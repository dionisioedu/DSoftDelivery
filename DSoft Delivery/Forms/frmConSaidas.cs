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
using DSoftCore;

namespace DSoft_Delivery.Forms
{
	public partial class frmConSaidas : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConSaidas(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			refreshButton1.Click += consultarToolStripMenuItem_Click;
			quitButton1.Click += sairToolStripMenuItem_Click;
		}

		private void fmConsultaSaidas_Load(object sender, EventArgs e)
		{
			CarregarCaixas();
			CarregarUsuarios();

			Consultar();
		}

		private void CarregarCaixas()
		{
			List<Caixa> caixas = _dsoftBd.CarregarCaixas();

			cbCaixa.Items.Add("");
			cbCaixa.Items.AddRange(caixas.ToArray());
		}

		private void CarregarUsuarios()
		{
			List<Usuario> usuarios = _dsoftBd.CarregarUsuarios();

			cbUsuario.Items.Add("");
			cbUsuario.Items.AddRange(usuarios.ToArray());
		}

		private void Consultar()
		{
			Usuario usuario = cbUsuario.SelectedItem as Usuario;
			Caixa caixa = cbCaixa.SelectedItem as Caixa;

			if (caixa == null && usuario == null)
			{
				dataGridView1.DataSource = _dsoftBd.ConsultarSaidas(dtInicio.Value, dtFinal.Value);
			}
			else if (caixa == null)
			{
				if (usuario != null)
				{
					dataGridView1.DataSource = _dsoftBd.ConsultarSaidas(dtInicio.Value, dtFinal.Value, usuario);
				}
			}
			else if (usuario == null)
			{
				if (caixa != null)
				{
					dataGridView1.DataSource = _dsoftBd.ConsultarSaidas(dtInicio.Value, dtFinal.Value, caixa);
				}
			}
			else
			{
				if (usuario != null && caixa != null)
				{
					dataGridView1.DataSource = _dsoftBd.ConsultarSaidas(dtInicio.Value, dtFinal.Value, caixa, usuario);
				}
			}

			dataGridView1.Columns["indice"].HeaderText = "Índice";
			dataGridView1.Columns["indice"].Width = 60;
			dataGridView1.Columns["indice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["data"].HeaderText = "Data";
			dataGridView1.Columns["data"].Width = 80;
			dataGridView1.Columns["data"].DefaultCellStyle.Format = "dd/MM/yyyy";
			dataGridView1.Columns["hora"].HeaderText = "Hora";
			dataGridView1.Columns["hora"].Width = 80;
			dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dataGridView1.Columns["descricao"].HeaderText = "Caixa";
			dataGridView1.Columns["valor"].HeaderText = "Valor R$";
			dataGridView1.Columns["valor"].Width = 80;
			dataGridView1.Columns["valor"].DefaultCellStyle.Format = Constants.FORMATO_MOEDA;
			dataGridView1.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns["observacao"].HeaderText = "Observação";
			dataGridView1.Columns["observacao"].Width = 300;
			dataGridView1.Columns["nome"].HeaderText = "Usuário";

			if (dataGridView1.Rows.Count > 2)
			{
				dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
			}

			SomaTotais();
		}

		private void SomaTotais()
		{
			lbQuantidade.Text = string.Format("Quantidade: {0}", dataGridView1.Rows.Count);

			decimal valor = 0;

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				valor += Util.TryParseDecimal(dataGridView1["valor", i].Value);
			}

			tbTotal.Text = valor.ToString(Constants.FORMATO_MOEDA);
		}

		private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
