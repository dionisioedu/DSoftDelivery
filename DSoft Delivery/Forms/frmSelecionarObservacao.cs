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
	public partial class frmSelecionarObservacao : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public string Observacoes = string.Empty;

		public frmSelecionarObservacao(Bd bd, Usuario usuario, string observacoes)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			CarregarObservacoes();
			MarcarSelecoes(observacoes);
		}

		private void frmSelecionarObservacao_Load(object sender, EventArgs e)
		{
		}

		private void Confirmar()
		{
			for (int i = 0; i < clObservacoes.Items.Count; i++)
			{
				if (clObservacoes.GetItemChecked(i))
				{
					Observacoes = string.Format("{0}{1}\r\n", Observacoes, clObservacoes.Items[i].ToString());
				}
			}

			if (Observacoes.Length > 0)
			{
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
		}

		private void Cancelar()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void CarregarObservacoes()
		{
			List<string> observacoes = _dsoftBd.CarregarObservacoes();

			clObservacoes.Items.Clear();

			if (observacoes != null && observacoes.Count > 0)
			{
				clObservacoes.Items.AddRange(observacoes.ToArray());
			}

			clObservacoes.Focus();
		}

		private void MarcarSelecoes(string observacoes)
		{
			if (observacoes != null && observacoes.Length > 0)
			{
				string[] obs = observacoes.Split("\r\n".ToCharArray());

				foreach (string s in obs)
				{
					if (s.Length > 0)
					{
						bool encontrado = false;

						for (int i = 0; i < clObservacoes.Items.Count; i++)
						{
							if (s == clObservacoes.Items[i].ToString())
							{
								clObservacoes.SetItemChecked(i, true);
								encontrado = true;
								break;
							}
						}

						if (!encontrado)
							Observacoes = string.Format("{0}{1}\r\n", Observacoes, s);
					}
				}
			}
		}

		private void clObservacoes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
			else if (e.KeyCode == Keys.F2)
			{
				Confirmar();
			}
			else if (e.KeyCode == Keys.F10 || e.KeyCode == Keys.Escape)
			{
				Cancelar();
			}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}
	}
}
