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
	public partial class frmConfirmarUsoEquipamentos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private List<Recurso> _funcionarios = null;

		public frmConfirmarUsoEquipamentos(Bd bd, Usuario usuario)
			: base()
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmConfirmarUsoEquipamentos_Load(object sender, EventArgs e)
		{
			CarregarFuncionarios();
		}

		private void CarregarFuncionarios()
		{
			_funcionarios = _dsoftBd.CarregarRecursos();

			if (_funcionarios != null)
			{
				cbFuncionario.Items.AddRange(_funcionarios.ToArray());
			}
		}

		private void CarregarOS(Recurso funcionario)
		{
			List<long> os = _dsoftBd.CarregarOSNaoEntregues(funcionario);

			lbOrdensDeServico.Items.Clear();

			foreach (long l in os)
			{
				lbOrdensDeServico.Items.Add(l);
			}
		}

		private void CarregarEquipamentos(long numero)
		{
			List<Equipamentos> equipamentos = _dsoftBd.EquipamentosNecessarios(numero);

			clEquipamentosUtilizados.Items.Clear();

			if (equipamentos != null)
			{
				clEquipamentosUtilizados.Items.AddRange(equipamentos.ToArray());
			}

			for (int i = 0; i < clEquipamentosUtilizados.Items.Count; i++)
			{
				clEquipamentosUtilizados.SetItemChecked(i, true);
			}
		}

		private void Confirmar()
		{
			Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

			if (funcionario != null)
			{
				long? ordemDeServico = lbOrdensDeServico.SelectedItem as long?;

				if (ordemDeServico != null && ordemDeServico > 0)
				{
					List<Equipamentos> equipamentos = new List<Equipamentos>();

					for (int i = 0; i < clEquipamentosUtilizados.Items.Count; i++)
					{
						if (clEquipamentosUtilizados.GetItemChecked(i))
						{
							Equipamentos equipamento = clEquipamentosUtilizados.Items[i] as Equipamentos;

							if (equipamento != null)
							{
								equipamentos.Add(equipamento);
							}
						}
					}

					if (_dsoftBd.ConfirmarUsoEquipamentos(funcionario, (long)ordemDeServico, equipamentos, _usuario))
					{
						clEquipamentosUtilizados.Items.Clear();

						CarregarOS(funcionario);
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

		private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
		{
			Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

			if (funcionario != null)
			{
				CarregarOS(funcionario);
			}
		}

		private void lbOrdensDeServico_SelectedIndexChanged(object sender, EventArgs e)
		{
			long? numero = lbOrdensDeServico.SelectedItem as long?;

			if (numero != null && numero > 0)
			{
				CarregarEquipamentos((long)numero);
			}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}
	}
}
