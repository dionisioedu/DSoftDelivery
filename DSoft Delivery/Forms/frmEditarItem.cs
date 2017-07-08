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
using DSoftParameters;

namespace DSoft_Delivery.Forms
{
	public partial class frmEditarItem : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private ItemPedido _item;
		private ItemPedido _copia;

		public frmEditarItem(Bd bd, Usuario usuario, ItemPedido item)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_item = item;
			_copia = (ItemPedido)item.Clone();
		}

		private void frmEditarItem_Load(object sender, EventArgs e)
		{
			tbProduto.Text = string.Format("{0} - {1}", _item.Produto, _item.ProdutoNome);
			tbQuantidade.Text = _item.Quantidade.ToString();
			tbPreco.Text = _item.Preco.ToString("##,###,##0.00");
			tbObs.Text = _item.Observacao;

			CarregarAdicionais();
			MarcarItensSelecionados();
		}

		private void CarregarAdicionais()
		{
			List<ItemAdicional> adicionais;

			if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
			{
				adicionais = _dsoftBd.CarregarItensAdicionais(_item.Produto);
			}
			else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
			{
				adicionais = _dsoftBd.CarregarItensAdicionais(_dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(_item.Produto)));
			}
			else
			{
				adicionais = _dsoftBd.CarregarItensAdicionais();
			}

			clAdicionais.Items.AddRange(adicionais.ToArray());
		}

		private void MarcarItensSelecionados()
		{
			foreach (ItemAdicional itemAdicional in _item.ItensAdicionais)
			{
				for (int i = 0; i < clAdicionais.Items.Count; i++)
				{
					ItemAdicional adc = clAdicionais.Items[i] as ItemAdicional;

					if (adc.Equals(itemAdicional))
					{
						clAdicionais.SetItemChecked(i, true);

						break;
					}
				}
			}
		}

		private void Confirmar()
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void Cancelar()
		{
			_item = _copia;

			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void CalcularPreco()
		{
			decimal preco = _item.Unitario * (decimal)_item.Quantidade;

			foreach (ItemAdicional i in _item.ItensAdicionais)
			{
				preco += i.Valor;
			}

			_item.Preco = preco;

			tbPreco.Text = preco.ToString("##,###,##0.00");
		}

		private void frmEditarItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Cancelar();
			}
		}

		private void tbProduto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Cancelar();
			}
			else if (e.KeyCode == Keys.Down)
			{
				clAdicionais.Focus();

				if (clAdicionais.Items.Count > 0)
				{
					clAdicionais.SetSelected(0, true);
				}
			}
			else if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void tbObs_TextChanged(object sender, EventArgs e)
		{
			_item.Observacao = tbObs.Text;
		}

		private void clAdicionais_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Cancelar();
			}
			else if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void clAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ItemAdicional itemAdicional = ((CheckedListBox)sender).SelectedItem as ItemAdicional;

			if (itemAdicional != null)
			{
				if (e.NewValue == CheckState.Checked)
				{
					_item.ItensAdicionais.Add(itemAdicional);
				}
				else if (e.NewValue == CheckState.Unchecked)
				{
					_item.ItensAdicionais.Remove(itemAdicional);
				}
			}

			CalcularPreco();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmCadAdicionaisRapido form = new frmCadAdicionaisRapido(_dsoftBd, _usuario);

			form.ShowDialog();

			if (form.ItemAdicional != null)
			{
				ItemAdicional item = form.ItemAdicional;

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					_dsoftBd.AdicionarItemAdicional(item, _item.Produto);
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					ProdutoTipo tipo = _dsoftBd.CarregarProdutoTipo(_dsoftBd.ProdutoTipo(_item.Produto));

					if (tipo != null)
					{
						_dsoftBd.AdicionarItemAdicional(item, tipo);
					}
				}
				else
				{
					_dsoftBd.AdicionarItemAdicional(item);
				}

				clAdicionais.Items.Add(item);
				clAdicionais.SetItemChecked(clAdicionais.Items.Count - 1, true);

				clAdicionais.ClearSelected();
				clAdicionais.SetSelected(clAdicionais.Items.Count - 1, true);

				ItemCheckEventArgs itemCheckEvent = new ItemCheckEventArgs(clAdicionais.Items.Count - 1, CheckState.Checked, CheckState.Indeterminate);

				clAdicionais_ItemCheck(clAdicionais, itemCheckEvent);
			}
		}
	}
}
