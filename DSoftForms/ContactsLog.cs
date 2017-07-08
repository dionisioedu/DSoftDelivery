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

namespace DSoftForms
{
	public partial class ContactsLog : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public ContactsLog(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void ContactLogs_Load(object sender, EventArgs e)
		{
			CarregarLogs();
		}

		private void CarregarLogs()
		{
			DataTable dt = _dsoftBd.CarregarContactsLog();

			dgvContactsLog.DataSource = dt;

			dgvContactsLog.Columns["indice"].HeaderText = "Índice";
			dgvContactsLog.Columns["indice"].Width = 60;
			dgvContactsLog.Columns["data"].HeaderText = "Data";
			dgvContactsLog.Columns["data"].Width = 80;
			dgvContactsLog.Columns["hora"].HeaderText = "Hora";
			dgvContactsLog.Columns["hora"].Width = 80;
			dgvContactsLog.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
			dgvContactsLog.Columns["lead"].HeaderText = "Lead";
			dgvContactsLog.Columns["nome"].HeaderText = "Nome";
			dgvContactsLog.Columns["motivo"].HeaderText = "Motivo";
			dgvContactsLog.Columns["descricao"].HeaderText = "Descrição";
			dgvContactsLog.Columns["conclusao"].HeaderText = "Conclusão";
			dgvContactsLog.Columns["retorno"].HeaderText = "Retorno";
			dgvContactsLog.Columns["retorno_hora"].HeaderText = "Retorno hr";
			dgvContactsLog.Columns["temperatura"].HeaderText = "Temperatura";
			dgvContactsLog.Columns["situacao"].HeaderText = "Situação";
			dgvContactsLog.Columns["usuario"].HeaderText = "Usuário";
		}

		private void tsbNovoContato_Click(object sender, EventArgs e)
		{
			EditContactLog form = new EditContactLog(_dsoftBd, _usuario);

			form.FormClosed += new FormClosedEventHandler((o, ev) =>
			{
				CarregarLogs();
			});

			form.Show();
		}
	}
}
