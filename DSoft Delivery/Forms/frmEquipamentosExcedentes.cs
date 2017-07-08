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
	public partial class frmEquipamentosExcedentes : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private Recurso _funcionario;
		private List<Equipamentos> _excedentes;

		public frmEquipamentosExcedentes(Bd bd, Usuario usuario, Recurso funcionario, List<Equipamentos> excedente)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			_funcionario = funcionario;
			_excedentes = excedente;
		}

		private void frmEquipamentosExcedentes_Load(object sender, EventArgs e)
		{
			tbFuncionario.Text = _funcionario.ToString();

			lbExcedentes.Items.AddRange(_excedentes.ToArray());
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void btAdicionar_Click(object sender, EventArgs e)
		{
			Equipamentos equipamento = lbExcedentes.SelectedItem as Equipamentos;

			if (equipamento != null)
			{
				lbAbatimentos.Items.Add(equipamento);

				lbExcedentes.Items.Remove(equipamento);
			}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			if (lbAbatimentos.Items.Count > 0)
			{
				List<Equipamentos> abatimentos = new List<Equipamentos>();

				foreach (object obj in lbAbatimentos.Items)
				{
					Equipamentos equip = obj as Equipamentos;

					if (equip != null)
					{
						abatimentos.Add(equip);
					}
				}

				if (_dsoftBd.AbaterNecessidadeEquipamentos(_funcionario, abatimentos, _usuario))
				{
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
			}
		}
	}
}
