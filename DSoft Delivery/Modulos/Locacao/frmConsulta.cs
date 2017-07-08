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

namespace DSoft_Delivery.Modulos.Locacao
{
	public partial class frmConsulta : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmConsulta(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmConsulta_Load(object sender, EventArgs e)
		{
			CarregarUsuarios();
		}

		private void CarregarUsuarios()
		{
			DataSet ds = new DataSet();

			_dsoftBd.UsuariosCadastrados(ds);

			List<Usuario> usuarios = new List<Usuario>();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				usuarios.Add(_dsoftBd.CarregarUsuario(Convert.ToInt32(r[0])));
			}

			cbUsuario.Items.Add("");
			cbUsuario.Items.AddRange(usuarios.ToArray());
		}

		private void Confirmar()
		{
			if (rbLocacao.Checked)
			{
				ConsultarLancamentos();
			}
			else if (rbRecebimento.Checked)
			{
				ConsultarRecebimentos();
			}
			else if (rbCaixa.Checked)
			{
				ConsultarCaixa();
			}
			else if (rbCancelamentos.Checked)
			{
				ConsultarCancelamentos();
			}
		}

		private void ConsultarLancamentos()
		{
			tbConsulta.Clear();

			if (cbUsuario.SelectedItem != null && cbUsuario.SelectedItem.ToString().Length > 0)
			{
				Usuario usuario = cbUsuario.SelectedItem as Usuario;

				if (usuario != null)
				{
					DataTable dt = _dsoftBd.ConsultaLancamentosLocacao(usuario, dtInicio.Value, dtFinal.Value);

					if (dt != null)
					{
						tbConsulta.AppendText(string.Format("CONSULTA DE LANÇAMENTOS DO USUÁRIO {0} DO DIA {1} AO DIA {2}"
							, usuario.Nome, dtInicio.Value.ToShortDateString(), dtFinal.Value.ToShortDateString()));

						tbConsulta.AppendText(Environment.NewLine + Environment.NewLine);

						foreach (DataRow r in dt.Rows)
						{
							tbConsulta.AppendText(string.Format("{0} {1} {2} {3}", r[3], r[4], r[5], r[6]));
							tbConsulta.AppendText(Environment.NewLine);
						}
					}
				}
			}
		}

		private void ConsultarRecebimentos()
		{

		}

		private void ConsultarCaixa()
		{

		}

		private void ConsultarCancelamentos()
		{

		}

		private void Imprimir()
		{
			Impressora.Imprimir(tbConsulta.Text);
		}

		private void Sair()
		{
			this.Close();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			Imprimir();
		}
	}
}
