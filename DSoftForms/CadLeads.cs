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

namespace DSoftForms
{
	public partial class CadLeads : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private List<string> _columnsString;

		public CadLeads(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			_columnsString = new List<string>();
			_columnsString.Add("nome");
			_columnsString.Add("endereco");
			_columnsString.Add("numero");
			_columnsString.Add("bairro");
			_columnsString.Add("cidade");
			_columnsString.Add("estado");
			_columnsString.Add("pais");
			_columnsString.Add("contato");
			_columnsString.Add("ramo");
			_columnsString.Add("origem");
			_columnsString.Add("obs");
			_columnsString.Add("situacao");
		}

		private void CadLeads_Load(object sender, EventArgs e)
		{
			Carregar();

			this.dgvLeads.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
			this.dgvLeads.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
		}

		private void Carregar()
		{
			DataTable dt = _dsoftBd.CarregarLeads();

			dgvLeads.DataSource = dt;

			dgvLeads.Columns["indice"].Visible = false;
			dgvLeads.Columns["nome"].Width = 180;
			dgvLeads.Columns["nome"].HeaderText = "Nome";
			dgvLeads.Columns["endereco"].HeaderText = "Endereço";
			dgvLeads.Columns["numero"].HeaderText = "Número";
			dgvLeads.Columns["bairro"].HeaderText = "Bairro";
			dgvLeads.Columns["cidade"].HeaderText = "Cidade";
			dgvLeads.Columns["estado"].HeaderText = "Estado";
			dgvLeads.Columns["pais"].HeaderText = "Pais";
			dgvLeads.Columns["cep"].HeaderText = "Cep";
			dgvLeads.Columns["tel1"].HeaderText = "Telefone";
			dgvLeads.Columns["tel2"].HeaderText = "Telefone";
			dgvLeads.Columns["celular"].HeaderText = "Celular";
			dgvLeads.Columns["contato"].HeaderText = "Contato";
			dgvLeads.Columns["ramo"].HeaderText = "Ramo";
			dgvLeads.Columns["origem"].HeaderText = "Origem";
			dgvLeads.Columns["obs"].HeaderText = "Observação";
			dgvLeads.Columns["situacao"].HeaderText = "Situação";
		}

		private Lead PreencherLead(int row)
		{
			if (row >= 0)
			{
				Lead lead = new Lead();

				lead.Indice = Util.TryParseInt(dgvLeads["indice", row].Value);
				lead.Nome = Util.TryGetValue(dgvLeads["nome", row].Value).ToUpper();
				lead.Endereco = Util.TryGetValue(dgvLeads["endereco", row].Value).ToUpper();
				lead.Numero = Util.TryGetValue(dgvLeads["numero", row].Value).ToUpper();
				lead.Bairro = Util.TryGetValue(dgvLeads["bairro", row].Value).ToUpper();
				lead.Cidade = Util.TryGetValue(dgvLeads["cidade", row].Value).ToUpper();
				lead.Estado = Util.TryGetValue(dgvLeads["estado", row].Value).ToUpper();
				lead.Pais = Util.TryGetValue(dgvLeads["pais", row].Value).ToUpper();
				lead.Cep = Util.TryGetValue(dgvLeads["cep", row].Value);
				lead.Tel1 = Util.TryParseLong(dgvLeads["tel1", row].Value);
				lead.Tel2 = Util.TryParseLong(dgvLeads["tel2", row].Value);
				lead.Celular = Util.TryParseLong(dgvLeads["celular", row].Value);
				lead.Contato = Util.TryGetValue(dgvLeads["contato", row].Value).ToUpper();
				lead.Ramo = Util.TryGetValue(dgvLeads["ramo", row].Value).ToUpper();
				lead.Origem = Util.TryGetValue(dgvLeads["origem", row].Value).ToUpper();
				lead.Observacao = Util.TryGetValue(dgvLeads["obs", row].Value).ToUpper();
				lead.Situacao = Util.TryGetChar(dgvLeads["situacao", row].Value);

				if (lead.Situacao == '\0')
					lead.Situacao = 'A';
				else
					lead.Situacao = char.ToUpper(lead.Situacao);

				return lead;
			}
			else
			{
				return null;
			}
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			Lead lead = PreencherLead(e.RowIndex);

			if (lead != null)
			{
				if (_dsoftBd.InsertOrUpdate(lead, _usuario))
				{
					if (Util.TryParseInt(dgvLeads["indice", e.RowIndex].Value) < 1)
					{
						dgvLeads["indice", e.RowIndex].Value = lead.Indice;
					}
				}
			}
		}

		private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			char situacao = Util.TryGetChar(dgvLeads["situacao", e.RowIndex].Value);

			switch (situacao)
			{
				case '0':
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
					break;

				case '1':
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aquamarine;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
					break;

				case '2':
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
					break;

				case '3':
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
					break;

				case 'P':
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGreen;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
					break;

				case 'A':
				default:
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
					dgvLeads.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
					break;
			}
		}

		private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			dgvLeads.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvLeads.Font, FontStyle.Bold);
		}

		private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
		{
			dgvLeads.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dgvLeads.Font, FontStyle.Regular);
		}

		private void dgvLeads_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				Lead lead = PreencherLead(e.RowIndex);

				if (lead != null)
				{
					EditContactLog form = new EditContactLog(_dsoftBd, _usuario, lead);

					form.FormClosing += new FormClosingEventHandler((o, ev) =>
					{
						if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
						{
							dgvLeads["situacao", e.RowIndex].Value = (char)form.Temperatura;
						}
					});

					form.Show();
				}
			}
		}

		private void dgvLeads_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (_columnsString.Contains(dgvLeads.Columns[e.ColumnIndex].Name))
			{
				dgvLeads[e.ColumnIndex, e.RowIndex].Value = Util.TryGetValue(dgvLeads[e.ColumnIndex, e.RowIndex].Value).ToUpper();
			}
		}
	}
}
