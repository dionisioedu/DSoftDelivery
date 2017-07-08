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
	public partial class frmRecebimentoDeProdutos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		public frmRecebimentoDeProdutos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void frmRecebimentoDeProdutos_Load(object sender, EventArgs e)
		{
			CarregarProdutos();
			Limpar();
		}

		private void CarregarProdutos()
		{
			List<Produto> produtos = _dsoftBd.CarregarProdutos();

			cbProdutos.Items.AddRange(produtos.ToArray());
		}

		private void Confirmar()
		{
			if (cbProdutos.SelectedItem != null && tbQuantidade.Text.Length > 0)
			{
				Produto produto = cbProdutos.SelectedItem as Produto;
				float quantidade = (float)Convert.ToDouble(tbQuantidade.Text);

				if (produto != null && quantidade > 0)
				{
					Equipamentos equipamento = new Equipamentos();
					equipamento.Produto = produto;
					equipamento.Quantidade = quantidade;
					equipamento.Id = tbCodigo.Text;

					//if (MessageBox.Show(string.Format("Confirma o recebimento de '{0}' {1}?", equipamento.Quantidade, equipamento.Produto.Nome), this.Text, MessageBoxButtons.YesNo)
					//    == System.Windows.Forms.DialogResult.Yes)
					//{
						if (_dsoftBd.ReceberEquipamentos(equipamento, _usuario))
						{
							CarregarEquipamentosSimilares(produto);

							if (tbCodigo.Text.Length > 0)
							{
								tbCodigo.Text = string.Empty;
								tbCodigo.Focus();
							}
							else
							{
								Limpar();
							}
						}
					//}
				}
			}
		}

		private void Limpar()
		{
			cbProdutos.SelectedItem = null;
			tbQuantidade.Text = "1";
			tbCodigo.Text = string.Empty;

			cbProdutos.Focus();
		}

		private void Excluir(Equipamentos equipamento)
		{
			if (_dsoftBd.Delete(equipamento, _usuario))
			{
				CarregarEquipamentosSimilares(equipamento.Produto);
			}
			else
			{
				MessageBox.Show("Não foi possível excluir registro! Entre em contato com o suporte para mais informações.");
			}
		}

		private void Sair()
		{
			this.Close();
		}

		private void CarregarEquipamentosSimilares(Produto produto)
		{
			lbEquipamentos.Items.Clear();

			List<Equipamentos> equipamentos = _dsoftBd.CarregarEquipamentos(produto);

			if (equipamentos != null)
			{
				lbEquipamentos.Items.AddRange(equipamentos.ToArray());
			}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void cbProdutos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbQuantidade.Focus();
			}
		}

		private void tbQuantidade_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCodigo.Focus();
			}
		}

		private void tbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
		{
			//if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
			//{
			//    e.Handled = true;
			//}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Confirmar();
			}
		}

		private void cbProdutos_SelectedIndexChanged(object sender, EventArgs e)
		{
			Produto produto = cbProdutos.SelectedItem as Produto;

			if (produto != null)
			{
				CarregarEquipamentosSimilares(produto);
				tbCodigo.Focus();
			}
		}

		private void btExcluir_Click(object sender, EventArgs e)
		{
			if (lbEquipamentos.SelectedItem != null)
			{
				Equipamentos equipamento = lbEquipamentos.SelectedItem as Equipamentos;

				if (equipamento != null)
				{
					Excluir(equipamento);
				}
			}
		}
	}
}
