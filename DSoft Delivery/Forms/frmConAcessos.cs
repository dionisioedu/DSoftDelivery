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
	public partial class frmConAcessos : Form
	{
		#region Fields

		private Bd _DSoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmConAcessos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_DSoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Relatorio();
		}

		private void Consultar()
		{
			try
			{
				bool logado;
				bool cancelados;
				int usuario;
				string sql;

				if (textBox1.Text == string.Empty)
				{
					usuario = 0;
				}
				else if (!int.TryParse(textBox1.Text, out usuario))
				{
					MessageBox.Show("Código de usuário deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}
				else if ((label4.Text = _DSoftBd.UsuarioNome(usuario)) == string.Empty)
				{
					MessageBox.Show("Usuário não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				logado = checkBox1.Checked;
				cancelados = checkBox2.Checked;

				sql = "select log_acessos.indice, log_acessos.usuario, cad_usuarios.nome, " +
					"log_acessos.data, log_acessos.entrada, log_acessos.saida, (log_acessos.saida - log_acessos.entrada) as duracao, " +
					" log_acessos.situacao from log_acessos " +
					"left join cad_usuarios on (cad_usuarios.codigo = log_acessos.usuario) where ";

				if (usuario > 0)
				{
					sql += "log_acessos.usuario = " + usuario.ToString() + " and ";
				}

				if (logado)
				{
					sql += "log_acessos.saida is null and ";
				}

				if (!cancelados)
				{
					sql += "log_acessos.situacao = 'A' and ";
				}

				sql += "log_acessos.data between to_date('"+dateTimePicker1.Value.ToString("dd/MM/yy")+"', 'DD/MM/YY') "+
					" and to_date('"+dateTimePicker2.Value.ToString("dd/MM/yy")+"', 'DD/MM/YY')"+
					"order by indice";

				DataSet ds = new DataSet();

				_DSoftBd.ExecQuery(sql, ds, _usuario.Autorizado);

				dataGridView1.DataSource = ds.Tables[0];

				// Formatação das colunas
				dataGridView1.Columns["indice"].Width = 60;
				dataGridView1.Columns["usuario"].Width = 60;
				dataGridView1.Columns["nome"].Width = 120;
				dataGridView1.Columns["data"].Width = 80;
				dataGridView1.Columns["entrada"].Width = 80;
				dataGridView1.Columns["saida"].Width = 80;
				dataGridView1.Columns["duracao"].Width = 80;
				dataGridView1.Columns["situacao"].Width = 60;

				dataGridView1.Columns["entrada"].DefaultCellStyle.Format = "hh:mm:ss";
				dataGridView1.Columns["saida"].DefaultCellStyle.Format = "hh:mm:ss";
				dataGridView1.Columns["duracao"].DefaultCellStyle.Format = "hh:mm:ss";
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void frmConAcessos_Load(object sender, EventArgs e)
		{
		}

		private void Relatorio()
		{
			if (dataGridView1.Rows.Count < 1)
				return;

			try
			{
				bool logado;
				bool cancelados;
				int usuario;
				string sql;

				if (textBox1.Text == string.Empty)
				{
					usuario = 0;
				}
				else if (!int.TryParse(textBox1.Text, out usuario))
				{
					MessageBox.Show("Código de usuário deve ser numérico!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}
				else if ((label4.Text = _DSoftBd.UsuarioNome(usuario)) == string.Empty)
				{
					MessageBox.Show("Usuário não encontrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					textBox1.SelectAll();

					textBox1.Focus();

					return;
				}

				logado = checkBox1.Checked;
				cancelados = checkBox2.Checked;

				sql = "select log_acessos.indice, log_acessos.usuario, cad_usuarios.nome, " +
					"log_acessos.data, log_acessos.entrada, log_acessos.saida, (log_acessos.saida - log_acessos.entrada) as duracao, " +
					" log_acessos.situacao from log_acessos " +
					"left join cad_usuarios on (cad_usuarios.codigo = log_acessos.usuario) where ";

				if (usuario > 0)
				{
					sql += "log_acessos.usuario = " + usuario.ToString() + " and ";
				}

				if (logado)
				{
					sql += "log_acessos.saida is null and ";
				}

				if (!cancelados)
				{
					sql += "log_acessos.situacao = 'A' and ";
				}

				sql += "log_acessos.data between to_date('" + dateTimePicker1.Value.ToString("dd/MM/yy") + "', 'DD/MM/YY') " +
					" and to_date('" + dateTimePicker2.Value.ToString("dd/MM/yy") + "', 'DD/MM/YY')" +
					"order by indice";

				DataSet ds = new DataSet();

				_DSoftBd.ExecQuery(sql, ds, _usuario.Autorizado);

				RelatorioHtml relatorio = new RelatorioHtml();

				relatorio.Arquivo = "Consulta Acessos";
				relatorio.Titulo = "Consulta de Acessos";

				if (usuario == 0)
				{
					relatorio.Descricao = "Consulta dos acessos de todos os usuarios ";
				}
				else
				{
					relatorio.Descricao = "Consulta dos acessos do usuario " + usuario.ToString() + " - " + _DSoftBd.UsuarioNome(usuario) + " ";
				}

				relatorio.Descricao += " no periodo de " + dateTimePicker1.Value.ToShortDateString() + " ate " + dateTimePicker2.Value.ToShortDateString();

				relatorio.Gerar(ds);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		#endregion Methods
	}
}