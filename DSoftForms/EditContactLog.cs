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
	public partial class EditContactLog : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private Lead _lead;

		public Temperaturas Temperatura;

		public EditContactLog(Bd bd, Usuario usuario, Lead lead = null)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_lead = lead;
		}

		private void EditContactLog_Load(object sender, EventArgs e)
		{
			PreencherLeads();

			if (_lead != null)
			{
				cbLead.SelectedItem = _lead;
			}
		}

		private void PreencherLeads()
		{
			List<Lead> leadsAtivos = _dsoftBd.LeadsAtivos();

			cbLead.Items.AddRange(leadsAtivos.ToArray());
		}

		private void cbLead_SelectedValueChanged(object sender, EventArgs e)
		{
			Lead lead = cbLead.SelectedItem as Lead;

			if (lead != null)
			{
				lbCidadeEstado.Text = string.Format("{0} / {1}", lead.Cidade, lead.Estado);
				lbErroLead.Visible = false;
			}
			else
			{
				lbCidadeEstado.Text = string.Empty;
			}
		}

		private void Confirmar()
		{
			bool erro = false;

			ContactLog log = new ContactLog();

			log.Lead = cbLead.SelectedItem as Lead;

			if (log.Lead == null)
			{
				lbErroLead.Visible = true;
				erro = true;
			}

			log.Data = DateTime.Today;
			log.Hora = DateTime.Now;

			log.Motivo = tbMotivo.Text;
			log.Descricao = tbDescricao.Text;
			log.Conclusao = tbConclusao.Text;

			if (log.Motivo.Length < 1)
			{
				erro = true;
				lbErroMotivo.Visible = true;
			}

			if (log.Descricao.Length < 1)
			{
				erro = true;
				lbErroDescricao.Visible = true;
			}

			if (erro)
			{
				return;
			}

			if (rbFrio.Checked)
			{
				log.Temperatura = Temperaturas.Frio;
			}
			else if (rbMorno.Checked)
			{
				log.Temperatura = Temperaturas.Morno;
			}
			else if (rbQuente.Checked)
			{
				log.Temperatura = Temperaturas.Quente;
			}
			else if (rbPerdido.Checked)
			{
				log.Temperatura = Temperaturas.Perdido;
			}
			else if (rbCliente.Checked)
			{
				log.Temperatura = Temperaturas.Cliente;
			}
			else
			{
				log.Temperatura = Temperaturas.Aberto;
			}

			if (cbRetorno.Checked)
			{
				log.Retorno = true;
				log.RetornoData = dtRetorno.Value;
				log.RetornoHora = dtRetorno.Value;
				log.CriarAlerta = cbAlerta.Checked;
			}
			else
			{
				log.Retorno = false;
				log.CriarAlerta = false;
			}

			if (_dsoftBd.IncluirContactLog(log, _usuario))
			{
				if (log.CriarAlerta)
				{
					Alerta alerta = new Alerta();

					alerta.Data = dtRetorno.Value;
					alerta.Hora = dtHora.Value;
					alerta.Lead = cbLead.SelectedItem as Lead;
					alerta.UsuarioDestino = _usuario;
					alerta.UsuarioOrigem = _usuario;
					alerta.Titulo = tbConclusao.Text;
					alerta.Observacao = tbDescricao.Text;

					_dsoftBd.CriarAlerta(alerta);
				}

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Temperatura = log.Temperatura;
				this.Close();
			}
		}

		private void Sair()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbLead_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbMotivo.Focus();
			}
		}

		private void tbMotivo_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				
			}
		}

		private void tbConclusao_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				gbTemperatura.Focus();
			}
		}

		private void tbMotivo_TextChanged(object sender, EventArgs e)
		{
			if (tbMotivo.Text.Length > 0)
			{
				lbErroMotivo.Visible = false;
			}
		}

		private void tbDescricao_TextChanged(object sender, EventArgs e)
		{
			if (tbDescricao.Text.Length > 0)
			{
				if (lbErroDescricao.Visible == true)
					lbErroDescricao.Visible = false;
			}
		}
	}
}
