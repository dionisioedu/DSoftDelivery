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
	public partial class frmCalendarioDeTabelas : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private List<TabelaDePrecos> _tabelas;

		public frmCalendarioDeTabelas(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmCalendarioDeTabelas_Load(object sender, EventArgs e)
		{
			CarregarTabelas();

			CalendarioDeTabelas calendario = _dsoftBd.CarregarCalendarioDeTabelas();

			cbGerenciarCalendario.Checked = calendario.Gerencia;

			cbDomingo.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Domingo);
			cbSegunda.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Segunda);
			cbTerca.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Terca);
			cbQuarta.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Quarta);
			cbQuinta.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Quinta);
			cbSexta.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Sexta);
			cbSabado.SelectedItem = _tabelas.FirstOrDefault(t => t.Codigo == calendario.Sabado);

			if (_usuario.NivelUsuario.Administrador == false)
			{
				btConfirmar.Enabled = false;
			}
		}

		private void CarregarTabelas()
		{
			_tabelas =  _dsoftBd.CarregarTabelas();

			cbDomingo.Items.AddRange(_tabelas.ToArray());
			cbSegunda.Items.AddRange(_tabelas.ToArray());
			cbTerca.Items.AddRange(_tabelas.ToArray());
			cbQuarta.Items.AddRange(_tabelas.ToArray());
			cbQuinta.Items.AddRange(_tabelas.ToArray());
			cbSexta.Items.AddRange(_tabelas.ToArray());
			cbSabado.Items.AddRange(_tabelas.ToArray());

			cbDomingo.SelectedIndex = 0;
			cbSegunda.SelectedIndex = 0;
			cbTerca.SelectedIndex = 0;
			cbQuarta.SelectedIndex = 0;
			cbQuinta.SelectedIndex = 0;
			cbSexta.SelectedIndex = 0;
			cbSabado.SelectedIndex = 0;
		}

		private void Confirmar()
		{
			if (_usuario.NivelUsuario.Administrador)
			{
				CalendarioDeTabelas calendario = new CalendarioDeTabelas();

				calendario.Gerencia = cbGerenciarCalendario.Checked;

				calendario.Domingo = ((TabelaDePrecos)cbDomingo.SelectedItem).Codigo;
				calendario.Segunda = ((TabelaDePrecos)cbSegunda.SelectedItem).Codigo;
				calendario.Terca = ((TabelaDePrecos)cbTerca.SelectedItem).Codigo;
				calendario.Quarta = ((TabelaDePrecos)cbQuarta.SelectedItem).Codigo;
				calendario.Quinta = ((TabelaDePrecos)cbQuinta.SelectedItem).Codigo;
				calendario.Sexta = ((TabelaDePrecos)cbSexta.SelectedItem).Codigo;
				calendario.Sabado = ((TabelaDePrecos)cbSabado.SelectedItem).Codigo;

				_dsoftBd.AtualizarCalendarioDeTabelas(calendario);

				this.Close();
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbGerenciarCalendario_CheckedChanged(object sender, EventArgs e)
		{
			bool gerencia = cbGerenciarCalendario.Checked;

			cbDomingo.Enabled = gerencia;
			cbSegunda.Enabled = gerencia;
			cbTerca.Enabled = gerencia;
			cbQuarta.Enabled = gerencia;
			cbQuinta.Enabled = gerencia;
			cbSexta.Enabled = gerencia;
			cbSabado.Enabled = gerencia;
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}
	}
}
