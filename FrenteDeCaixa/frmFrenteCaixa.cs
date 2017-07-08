using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DSoftModels;
using DSoftCore;
using DSoftBd;
using DSoftForms;
using DSPrintingHelper;

namespace FrenteDeCaixa
{
	public partial class frmFrenteCaixa : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private int _caixa;

		public static Pedido _pedido;
		private TabelaDePrecos _tabela;

		private System.Windows.Forms.Timer _productCleanerTimer;

		public frmFrenteCaixa()
		{
			InitializeComponent();

			_dsoftBd = new Bd(0);
			_usuario = new Usuario();

			_productCleanerTimer = new Timer();
			_productCleanerTimer.Interval = 5000;
			_productCleanerTimer.Tick += new EventHandler(_productCleanerTimer_Tick);
		}

		private void _productCleanerTimer_Tick(object sender, EventArgs e)
		{
			tbDescricao.Text = string.Empty;
			pbImagem.Image = null;
			pbImagem.Invalidate();

			_productCleanerTimer.Enabled = false;
		}

		private void frmFrenteCaixa_Load(object sender, EventArgs e)
		{
			if (!IniciaConexao())
			{
				Application.Exit();
			}

			frmLogin f = new frmLogin(_dsoftBd, _usuario);

			f.StartPosition = FormStartPosition.CenterParent;

			if (f.ShowDialog() != DialogResult.OK || _usuario == null)
			{
				Application.Exit();
				return;
			}

			Caixa.Numero = _caixa;
			_tabela = _dsoftBd.CarregarTabela(1);

			NovoPedido();

			lbCaixa.Text = _dsoftBd.CaixaDescricao(_caixa);
			lbUsuario.Text = _usuario.Nome;

			tbProduto.Focus();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			lbData.Text = DateTime.Now.ToShortDateString();
			lbHora.Text = DateTime.Now.ToLongTimeString();
		}

		private void label5_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Tem certeza de que deseja abandonar o sistema?", "DSoft Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private bool IniciaConexao()
		{
			byte[] conteudo;
			string dados;
			string host;
			string porta;
			string banco;
			string caixa;
			string[] parametros;

			try
			{
				FileStream file = new FileStream("dsoft.ini", FileMode.Open);

				conteudo = new byte[file.Length];

				file.Read(conteudo, 0, conteudo.Length);

				dados = System.Text.Encoding.ASCII.GetString(conteudo);

				parametros = dados.Split(":".ToCharArray());

				host = parametros[0];
				porta = parametros[1];
				banco = parametros[2];
				caixa = parametros[3];

				_caixa = int.Parse(caixa);

				return _dsoftBd.Conecta(host, porta, banco);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		private void NovoPedido()
		{
			LimparCampos();

			lbPedido.Items.Clear();
			tbTotalCompra.Text = "0,00";

			_pedido = new Pedido();
			_pedido.Tabela = _tabela;

			GC.Collect();
		}

		private void AdicionaProduto(Produto produto, decimal unitario, float quantidade, decimal total)
		{
			int numero;
			string valor;
			string linha = string.Empty;
			const int NOME_LEN = 16;

			ItemPedido item = new ItemPedido();
			item.Produto = produto.Codigo;
			item.ProdutoNome = produto.Nome;
			item.Quantidade = quantidade;
			item.Unitario = unitario;
			item.Preco = total;

			numero = _pedido.NovoItem(item);

			string nome = Util.Formata(produto.Nome, NOME_LEN);

			linha = string.Format("{0:000} {1:00000000} {2}", numero, produto, Util.Formata(nome, 14, ' '));

			valor = unitario.ToString(Constants.FORMATO_MOEDA);
			valor = valor.PadLeft(12, ' ');

			linha += valor;

			valor = string.Format("   {0:00.0##} ", quantidade);
			valor = valor.PadRight(6, ' ');

			linha += valor;

			valor = total.ToString(Constants.FORMATO_MOEDA);
			valor = valor.PadLeft(12, ' ');

			linha += valor;

			lbPedido.Items.Add(linha);
			lbPedido.SetSelected(lbPedido.Items.Count - 1, true);

			tbTotalCompra.Text = _pedido.TotalPedido.ToString(Constants.FORMATO_MOEDA);

			MostrarDescricaoEImagem(produto.Nome, produto.Foto);

			LimparCampos();
		}

		private void MostrarDescricaoEImagem(string descricao, string imagem)
		{
			tbDescricao.Text = descricao;

			if (imagem.Length > 0 && File.Exists(imagem))
			{
				pbImagem.Image = Image.FromFile(imagem);
			}
			else
			{
				pbImagem.Image = null;
				pbImagem.Invalidate();
			}

			if (_productCleanerTimer.Enabled == false)
			{
				_productCleanerTimer.Enabled = true;
				_productCleanerTimer.Start();
			}
			else
			{
				_productCleanerTimer.Stop();
				_productCleanerTimer.Start();
			}
		}

		private void LimparCampos()
		{
			tbProduto.Clear();

			tbValorUnitario.Text = "0,00";
			tbQuantidade.Text = "1";
			tbValorTotal.Text = "0,00";

			tbProduto.Focus();
		}

		private void AtualizaDetalhes()
		{
			lbPedido.Items.Clear();
		}

		private void tbProduto_KeyPress(object sender, KeyPressEventArgs e)
		{
			long codigo;
			float quantidade;

			if (e.KeyChar == (char)Keys.Enter)
			{
				if (tbProduto.Text.Length > 0 && long.TryParse(tbProduto.Text, out codigo))
				{
					Produto produto = _dsoftBd.CarregarProduto(codigo);

					if (produto == null)
					{
						tbProduto.SelectAll();
						tbProduto.Focus();

						return;
					}

					if (!float.TryParse(tbQuantidade.Text, out quantidade))
					{
						tbQuantidade.SelectAll();
						tbQuantidade.Focus();

						return;
					}

					decimal unitario = (decimal)_dsoftBd.ProdutoPreco(produto.Codigo, 1);

					decimal total = (decimal)((float)unitario * quantidade);

					tbDescricao.Text = produto.Nome;
					tbValorUnitario.Text = unitario.ToString(Constants.FORMATO_MOEDA);
					tbValorTotal.Text = total.ToString(Constants.FORMATO_MOEDA);

					AdicionaProduto(produto, unitario, quantidade, total);
				}
				else if (tbProduto.Text.Length == 0)
				{
					if (_pedido.ItensQtd < 1)
						return;

					if ((_pedido.Numero = _dsoftBd.NovoPedido(_pedido, _usuario.Autorizado, _caixa)) < 1)
					{
						MessageBox.Show("Erro ao gravar pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

						return;
					}

					//frmPagamento f = new frmPagamento(_dsoftBd, _usuario, _pedido);
					CaixaSimples caixa = new CaixaSimples(_dsoftBd, _usuario, _pedido);
					
					if (caixa.ShowDialog() == DialogResult.OK)
					{
						PrinterHelper.PrintOrder(_pedido, _dsoftBd.CarregarCaixa(_caixa), _usuario.Codigo, _dsoftBd, Licenca.Instance);

						_dsoftBd.EntregaPedido(_pedido.Numero, _usuario.Codigo);

						NovoPedido();
					}
					else
					{
						tbProduto.Focus();
					}
				}
			}
		}

		private void tbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
		{
			tbProduto_KeyPress(sender, e);
		}

		private void lbPedido_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void lbPedido_KeyDown(object sender, KeyEventArgs e)
		{
			if (lbPedido.SelectedItem != null && e.KeyCode == Keys.Delete)
			{
				_pedido.ExcluirItem(lbPedido.SelectedIndex);
				lbPedido.Items.RemoveAt(lbPedido.SelectedIndex);

				tbTotalCompra.Text = _pedido.TotalPedido.ToString(Constants.FORMATO_MOEDA);
			}
			else if (lbPedido.SelectedIndex == 0 && e.KeyCode == Keys.Up)
			{
				tbProduto.Focus();
			}
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Tem certeza que deseja limpar o pedido atual?", "DSoft Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				_pedido.Limpa();
				lbPedido.Items.Clear();

				tbTotalCompra.Text = "0,00";
			}
		}

		private void btExcluir_Click(object sender, EventArgs e)
		{
			if (lbPedido.SelectedItem != null)
			{
				_pedido.ExcluirItem(lbPedido.SelectedIndex);
				lbPedido.Items.RemoveAt(lbPedido.SelectedIndex);

				tbTotalCompra.Text = _pedido.TotalPedido.ToString(Constants.FORMATO_MOEDA);
			}
		}

		private void tbProduto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (lbPedido.Items.Count > 0)
				{
					lbPedido.SelectedIndex = 0;
					lbPedido.Focus();
				}
			}
		}
	}
}
