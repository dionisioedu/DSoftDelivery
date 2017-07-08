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
	public partial class frmTransferenciaEstoque : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmTransferenciaEstoque(Bd bd, Usuario usuario)
			: base()
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmTransferenciaEstoque_Load(object sender, EventArgs e)
		{
			CarregarFiliais();
		}

		private void CarregarFiliais()
		{
			List<Filial> filiais = _dsoftBd.CarregarFiliais();

			if (filiais != null)
			{
				cbFilial.Items.AddRange(filiais.ToArray());
			}
		}

		private void AdicionarEquipamento(string id)
		{
			Equipamentos equipamento = _dsoftBd.CarregarEquipamento(id);

			if (equipamento != null)
			{
				lbEquipamentos.Items.Add(equipamento);

				tbEquipamento.Text = string.Empty;
				tbEquipamento.Focus();
			}
			else
			{
				tbEquipamento.SelectAll();
				tbEquipamento.Focus();
			}
		}

		private void Excluir()
		{
			if (lbEquipamentos.SelectedItem != null)
			{
				lbEquipamentos.Items.Remove(lbEquipamentos.SelectedItem);
			}
		}

		private void Confirmar()
		{
			if (cbFilial.SelectedItem != null)
			{
				Filial filial = cbFilial.SelectedItem as Filial;

				if (filial != null)
				{
					if (lbEquipamentos.Items.Count > 0)
					{
						List<Equipamentos> equipamentos = new List<Equipamentos>();

						for (int i = 0; i < lbEquipamentos.Items.Count; i++)
						{
							Equipamentos equipamento = lbEquipamentos.Items[i] as Equipamentos;

							if (equipamento != null)
							{
								equipamentos.Add(equipamento);
							}
						}

						if (_dsoftBd.EnviarEquipamentos(filial, equipamentos, _usuario))
						{
							lbEquipamentos.Items.Clear();
							cbFilial.Focus();
						}
					}
				}
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void tbEquipamento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (tbEquipamento.Text.Length > 0)
				{
					AdicionarEquipamento(tbEquipamento.Text);
				}
			}
		}

		private void btExcluir_Click(object sender, EventArgs e)
		{
			Excluir();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void cbFilial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbEquipamento.Focus();
			}
		}
	}
}
