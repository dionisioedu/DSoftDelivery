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
	public partial class frmCadTiposDeServicos : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private bool _editando = false;

		private TipoDeServico _tipoDeServico;

		public frmCadTiposDeServicos(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		private void Carregar()
		{
			DataTable dt = _dsoftBd.CarregarTiposDeServico();
			dataGridView1.DataSource = dt;
		}

		private void CarregarProdutos()
		{
			List<Produto> produtos = _dsoftBd.CarregarProdutos();
			cbProdutos.Items.AddRange(produtos.ToArray());
		}

		private void Confirmar()
		{
			TipoDeServico tipoDeServico = PreenchidoCorretamente();

			if (tipoDeServico != null)
			{
				if (_dsoftBd.InsertOrUpdate(tipoDeServico))
				{
					Limpar();
					Carregar();
				}
			}
		}

		private TipoDeServico PreenchidoCorretamente()
		{
			TipoDeServico tipoDeServico = new TipoDeServico();

			if (tbCodigo.Text.Length < 1)
			{
				tbCodigo.Focus();
				return null;
			}

			tipoDeServico.Codigo = tbCodigo.Text;

			if (tbDescricao.Text.Length < 1)
			{
				tbDescricao.Focus();
				return null;
			}

			tipoDeServico.Descricao = tbDescricao.Text;

			decimal valor;
			decimal.TryParse(tbValor.Text, out valor);
			tipoDeServico.Valor = valor;

			decimal.TryParse(tbCusto.Text, out valor);
			tipoDeServico.Custo = valor;

			tipoDeServico.Equipamentos = new List<Equipamentos>();

			foreach (Equipamentos equipamento in lbEquipamentos.Items)
			{
				if (equipamento != null)
				{
					tipoDeServico.Equipamentos.Add(equipamento);
				}
			}

			return tipoDeServico;
		}

		private void Excluir()
		{

		}

		private void Limpar()
		{
			tbCodigo.Text = string.Empty;
			tbDescricao.Text = string.Empty;
			tbValor.Text = string.Empty;
			tbCusto.Text = string.Empty;

			_tipoDeServico = null;

			cbProdutos.SelectedItem = null;
			tbQuantidade.Text = string.Empty;

			lbEquipamentos.Items.Clear();
		}

		private void Sair()
		{
			this.Close();
		}

		private void frmCadTiposDeServicos_Load(object sender, EventArgs e)
		{
			Carregar();
			CarregarProdutos();
		}

		private void novoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btExcluir_Click(object sender, EventArgs e)
		{
			Excluir();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbDescricao.Focus();
			}
		}

		private void tbDescricao_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbValor.Focus();
			}
		}

		private void tbValor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbCusto.Focus();
			}
		}

		private void tbCusto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btConfirmar.Focus();
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			tbCodigo.Text = dataGridView1["codigo", e.RowIndex].Value.ToString();
			tbDescricao.Text = dataGridView1["descricao", e.RowIndex].Value.ToString();
			tbValor.Text = dataGridView1["valor", e.RowIndex].Value.ToString();
			tbCusto.Text = dataGridView1["custo", e.RowIndex].Value.ToString();

			_tipoDeServico = new TipoDeServico();
			_tipoDeServico.Codigo = tbCodigo.Text;
			_tipoDeServico.Descricao = tbDescricao.Text;
			_tipoDeServico.Valor = Convert.ToDecimal(tbValor.Text);
			_tipoDeServico.Custo = Convert.ToDecimal(tbCusto.Text);

			_dsoftBd.CarregarEquipamentos(_tipoDeServico);

			lbEquipamentos.Items.Clear();

			if (_tipoDeServico.Equipamentos != null && _tipoDeServico.Equipamentos.Count > 0)
			{
				lbEquipamentos.Items.AddRange(_tipoDeServico.Equipamentos.ToArray());
			}

			tbDescricao.Focus();
		}

		private void btAdicionar_Click(object sender, EventArgs e)
		{
			if (cbProdutos.SelectedItem != null && tbQuantidade.Text.Length > 0)
			{
				float quantidade;
				float.TryParse(tbQuantidade.Text, out quantidade);

				if (quantidade > 0)
				{
					Equipamentos equipamento = new Equipamentos();
					equipamento.Produto = cbProdutos.SelectedItem as Produto;
					equipamento.Quantidade = quantidade;

					lbEquipamentos.Items.Add(equipamento);

					cbProdutos.SelectedItem = null;
					tbQuantidade.Text = string.Empty;
				}
			}
		}

		private void btExcluirItem_Click(object sender, EventArgs e)
		{
			if (lbEquipamentos.SelectedItem != null)
			{
				lbEquipamentos.Items.Remove(lbEquipamentos.SelectedItem);
			}
		}

		private void btLimparLista_Click(object sender, EventArgs e)
		{
			lbEquipamentos.Items.Clear();
		}
	}
}
