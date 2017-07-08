using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftModels;
using DSoftBd;

namespace DSoft_Delivery.Forms
{
	public partial class frmEntregaDeEquipamentos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private List<Equipamentos> _equipamentos = null;
		private List<Equipamentos> _necessidade_real = null;
		private List<Equipamentos> _excedentes = null;

		private Dictionary<Recurso, List<Equipamentos>> _entreguesAgora = null;

		public frmEntregaDeEquipamentos(Bd bd, Usuario usuario)
			: base()
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmEntregaDeEquipamentoscs_Load(object sender, EventArgs e)
		{
			CarregarFuncionarios();

			_entreguesAgora = new Dictionary<Recurso, List<Equipamentos>>();
		}

		private void CarregarFuncionarios()
		{
			List<Recurso> funcionarios = _dsoftBd.CarregarRecursos();

			if (funcionarios != null && funcionarios.Count > 0)
			{
				cbFuncionario.Items.AddRange(funcionarios.ToArray());
			}
		}

		private void CarregarEquipamentos(Recurso funcionario)
		{
			_equipamentos = _dsoftBd.EquipamentosNecessarios(funcionario);

			lbEquipamentos.Items.Clear();

			if (_equipamentos != null)
			{
				lbEquipamentos.Items.AddRange(_equipamentos.ToArray());
			}

			List<Equipamentos> estoque = _dsoftBd.EstoqueFuncionario(funcionario);

			lbEstoque.Items.Clear();

			if (estoque != null && estoque.Count > 0)
			{
				lbEstoque.Items.AddRange(estoque.ToArray());
			}

			VerificarEquipamentosExtra(funcionario, estoque);

			if (_entreguesAgora.ContainsKey(funcionario) == false)
			{
				_entreguesAgora.Add(funcionario, new List<Equipamentos>());
			}
		}

		private void VerificarEquipamentosExtra(Recurso funcionario, List<Equipamentos> estoque)
		{
			_necessidade_real = _dsoftBd.EquipamentosNecessariosReal(funcionario);
			_excedentes = new List<Equipamentos>();

			pnEquipamentosExtra.Visible = false;

			foreach (Equipamentos equipamento in estoque)
			{
				Equipamentos adicionando = _equipamentos.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo);
				Equipamentos necessidade = _necessidade_real.FirstOrDefault(e => e.Produto.Codigo == equipamento.Produto.Codigo);

				if (adicionando != null && necessidade != null)
				{
					if (equipamento.Quantidade + adicionando.Quantidade > necessidade.Quantidade)
					{
						_excedentes.Add((Equipamentos)equipamento.Clone());

						if (equipamento.Quantidade >= adicionando.Quantidade)
						{
							_excedentes.Last().Quantidade = adicionando.Quantidade;
						}
						else
						{
							_excedentes.Last().Quantidade = equipamento.Quantidade;
						}

						pnEquipamentosExtra.Visible = true;
					}
				}
			}
		}

		private void Confirmar()
		{
			if (cbFuncionario.SelectedItem != null && lbEquipamentos.Items.Count > 0)
			{
				if (MessageBox.Show("Confirma a entrega dos equipamentos listados?", this.Text, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

					if (funcionario != null)
					{
						List<Equipamentos> equipamentos = new List<Equipamentos>();

						foreach (Equipamentos equipamento in lbEquipamentos.Items)
						{
							if (equipamento != null)
							{
								equipamentos.Add(equipamento);
							}
						}

						if (_dsoftBd.EntregarEquipamentos(funcionario, equipamentos, _usuario))
						{
							cbFuncionario.SelectedItem = null;
							lbEquipamentos.Items.Clear();
							lbEstoque.Items.Clear();
						}
					}
				}
			}
		}

		private void TentarEntregarEquipamento(string id)
		{
			Equipamentos equipamento = _dsoftBd.CarregarEquipamento(id);

			if (equipamento != null)
			{
				if (_equipamentos.Contains(equipamento))
				{
					Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

					if (funcionario != null)
					{
						if (_dsoftBd.EntregarEquipamento(funcionario, equipamento, _usuario))
						{
							tbEquipamento.Text = string.Empty;

							CarregarEquipamentos(funcionario);

							_entreguesAgora[funcionario].Add(equipamento);
						}
						else
						{
							tbEquipamento.SelectAll();
						}
					}
				}
				else
				{
					tbEquipamento.SelectAll();
				}
			}
			else
			{
				long codigo;
				long.TryParse(id, out codigo);

				if (codigo > 0)
				{
					Produto produto = _dsoftBd.CarregarProduto(codigo);

					if (produto != null)
					{
						Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

						if (funcionario != null)
						{
							equipamento = new Equipamentos();
							equipamento.Produto = produto;
							equipamento.Quantidade = 1;

							if (_dsoftBd.EntregarEquipamento(funcionario, equipamento, _usuario))
							{
								tbEquipamento.Text = string.Empty;

								CarregarEquipamentos(funcionario);

								_entreguesAgora[funcionario].Add(equipamento);

								return;
							}
						}
					}
				}

				MessageBox.Show("Equipamento não localizado!");
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

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFuncionario.SelectedItem != null)
			{
				Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

				if (funcionario != null)
				{
					CarregarEquipamentos(funcionario);
				}

				btImprimir.Enabled = true;
			}
			else
			{
				btImprimir.Enabled = false;
			}
		}

		private void tbEquipamento_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbEquipamento.Text.Length > 0)
				{
					TentarEntregarEquipamento(tbEquipamento.Text);
				}
			}
		}

		private void btEquipamentosExtra_Click(object sender, EventArgs e)
		{
			Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

			if (funcionario != null)
			{
				frmEquipamentosExcedentes form = new frmEquipamentosExcedentes(_dsoftBd, _usuario, funcionario, _excedentes);

				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					CarregarEquipamentos(funcionario);
				}
			}
		}

		private void btImprimir_Click(object sender, EventArgs e)
		{
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.Show();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Recurso funcionario = cbFuncionario.SelectedItem as Recurso;

			if (funcionario != null)
			{
				float yPos = 0;
				float leftMargin = e.MarginBounds.Left;
				float topMargin = e.MarginBounds.Top;
				Font titleFont = new Font("Arial", 14, FontStyle.Bold);
				Font printFont = new Font("Arial", 10);
				Font italicFont = new Font("Arial", 10, FontStyle.Italic);

				yPos = topMargin;
				e.Graphics.DrawString("Comprovante de recebimento de equipamentos", titleFont, Brushes.Black, leftMargin, yPos, new StringFormat());
				yPos += titleFont.GetHeight(e.Graphics);
				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawString(string.Format("Eu, {0} RG: {1}", funcionario.Nome, funcionario.Rg), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawString("Confirmo o recebimento dos equipamentos listados abaixo:", printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
				yPos += printFont.GetHeight(e.Graphics);
				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawLine(Pens.Black, new Point((int)leftMargin, (int)yPos), new Point(800, (int)yPos));
				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawString("Produto", italicFont, Brushes.Gray, leftMargin, yPos, new StringFormat());
				e.Graphics.DrawString("Identificador", italicFont, Brushes.Gray, 400, yPos, new StringFormat());
				e.Graphics.DrawString("Quantidade", italicFont, Brushes.Gray, 600, yPos, new StringFormat());
				yPos += printFont.GetHeight(e.Graphics);

				foreach (Equipamentos equipamento in _entreguesAgora[funcionario])
				{
					e.Graphics.DrawString(equipamento.Produto.ToString(), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
					e.Graphics.DrawString(equipamento.Id, printFont, Brushes.Black, 400, yPos, new StringFormat());
					e.Graphics.DrawString(equipamento.Quantidade.ToString(), printFont, Brushes.Black, 600, yPos, new StringFormat());
					yPos += printFont.GetHeight(e.Graphics);
				}

				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawLine(Pens.Black, new Point((int)leftMargin, (int)yPos), new Point(800, (int)yPos));
				yPos += printFont.GetHeight(e.Graphics);
				yPos += printFont.GetHeight(e.Graphics);
				e.Graphics.DrawString(string.Format("{0}   Ass:____________________________________", DateTime.Today.ToShortDateString()), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

				e.HasMorePages = false;
			}
		}
	}
}
