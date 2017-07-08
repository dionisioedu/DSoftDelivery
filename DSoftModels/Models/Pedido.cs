using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Pedido : ICloneable, IEquatable<Pedido>
	{
		#region Fields

		public long Cliente;
		public DateTime Data;
		public bool Debito;
		public decimal Desconto;
		public int Divisor;
		public DateTime Hora;
		public string IndicadorPagamento;
		public int? Indice;
		public List<ItemAdicional> ItensAdicionais;
		public List<ItemPedido> ItensPedido;
		public string NFe;
		public string NFeSerializado;
		public int Numero;
		public string Observacao;
		public long Produto;
		public string ProdutoNome;
		public float Quantidade;
		public char Situacao;
		public TabelaDePrecos Tabela;
		public decimal TaxaDeEntrega;
		public decimal PorcentagemServico;
		public decimal Troco;
		public int Usuario;
		public decimal Valor;
		public Recurso Vendedor;
		public int Comanda;
		public string MotivoDoCancelamento;
		public bool Retirar;
		public decimal TaxaEntregador;

		private decimal _totalManual;
		private bool _isTotalManual;
		private decimal _taxaDeServicoManual;
		private bool _isTaxaDeServicoManual;

		#endregion Fields

		#region Constructors

		public Pedido()
		{
			Valor = 0;
			Situacao = 'A';
			Debito = false;
			ItensPedido = new List<ItemPedido>();
			Observacao = string.Empty;
			Vendedor = new Recurso();
			ItensAdicionais = new List<ItemAdicional>();

			IndicadorPagamento = "0";
			_isTaxaDeServicoManual = false;
		}

		#endregion Constructors

		#region Properties

		public bool isItemValid
		{
			get
			{
				if (Produto < 1 || Quantidade == 0)
					return false;

				return true;
			}
		}

		/// <summary>
		/// Retorna a quantidade de itens contidos no pedido.
		/// </summary>
		/// <returns></returns>
		public int ItensQtd
		{
			get
			{
				return ItensPedido.Count;
			}
		}

		/// <summary>
		/// Retorna a soma total do pedido, ou o valor definido manualmente pelo usuário.
		/// </summary>
		public decimal TotalPedido
		{
			get
			{
				if (_isTotalManual == false)
				{
					decimal total = 0;

					foreach (ItemPedido item in ItensPedido)
					{
						total += item.Preco;
					}

					total += TaxaDeServico;
					total += TaxaDeEntrega;

					return total;
				}
				else
				{
					return _totalManual;
				}
			}
			set
			{
				_totalManual = value;
				_isTotalManual = true;
			}
		}

		public void ResetarTotalManual()
		{
			this._totalManual = 0;
			this._isTotalManual = false;
		}

		public decimal TaxaDeServico
		{
			get
			{
				if (_isTaxaDeServicoManual == true)
				{
					return _taxaDeServicoManual;
				}

				decimal total = 0;

				foreach (ItemPedido item in ItensPedido)
				{
					total += item.Preco;
				}

				return ((total * PorcentagemServico) / 100);
			}
			set
			{
				_isTaxaDeServicoManual = true;
				_taxaDeServicoManual = value;

				_totalManual = 0;
				_isTotalManual = false;
			}
		}

		public decimal DescontoPedido
		{
			get
			{
				if (_totalManual == 0)
				{
					return 0;
				}
				else
				{
					decimal total = 0;

					foreach (ItemPedido item in ItensPedido)
					{
						total += item.Preco;
					}

					total += TaxaDeServico;
					total += TaxaDeEntrega;

					return total - _totalManual;
				}
			}
		}

		#endregion Properties

		#region Methods

		[Obsolete("Use o novo método int AdicionarItem(long produto, decimal valor, float quantidade, decimal total, string observacao);")]
		public int AdicionarItem()
		{
			int item = NovoItem(this.Produto, this.ProdutoNome, this.Valor, this.Quantidade, this.TotalProduto(), this.Observacao);

			this.Produto = 0;
			this.Valor = 0;
			this.Quantidade = 1;
			this.Observacao = "";

			return item;
		}

		public int AdicionarItem(long produto, string nome, decimal valor, float quantidade, decimal total, string observacao)
		{
			return NovoItem(produto, nome, valor, quantidade, total, observacao);
		}

		[Obsolete("Use o novo método int AdicionarItemSecundario(int numero, long produto, decimal valor, float quantidade, decimal total, string observacao);")]
		public int AdicionarItemSecundario(int numero)
		{
			int item = NovoItemSecundario(numero, this.Produto, this.ProdutoNome, this.Valor, this.Quantidade, this.TotalProduto());

			this.Produto = 0;
			this.ProdutoNome = string.Empty;
			this.Valor = 0;
			this.Quantidade = 1;
			this.Observacao = "";

			return item;
		}

		public int AdicionarItemSecundario(int numero, long produto, string nome, decimal valor, float quantidade, decimal total, string observacao)
		{
			return NovoItemSecundario(numero, produto, nome, valor, quantidade, total, observacao);
		}

		public bool Ativo()
		{
			if (Situacao == 'A')
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Cancela um item do pedido. Caso o item tenha itens secundários, eles também serão cancelados. Caso o item seja um item secundário ou
		/// fracionado, todo o item será cancelado.
		/// </summary>
		/// <param name="item">Número do item a ser cancelado</param>
		/// <returns>true para sucesso ou false caso o item já estivesse cancelado</returns>
		public int[] CancelarItem(int item)
		{
			int principal = item;

			if (ItensPedido[item].Secundario)
			{
				for (int i = item; i >= 0; i--)
				{
					if (!ItensPedido[i].Secundario)
					{
						principal = i;
						break;
					}
				}
			}

			if (ItensPedido[principal].Situacao != 'A')
				return null;

			List<int> cancelados = new List<int>();

			for (int i = principal; i < ItensPedido.Count; i++)
			{
				if (i > principal && !ItensPedido[i].Secundario)
				{
					break;
				}

				ItensPedido[i].Situacao = 'C';

				cancelados.Add(i);
			}

			return cancelados.ToArray();
		}

		public void ClientePedido(long cliente)
		{
			Cliente = cliente;
		}

		public long ClientePedido()
		{
			return Cliente;
		}

		public void ExcluirItem(int item)
		{
			int principal = item;

			if (ItensPedido[item].Secundario)
			{
				for (int i = item; i >= 0; i--)
				{
					if (!ItensPedido[i].Secundario)
					{
						principal = i;
						break;
					}
				}
			}

			List<int> cancelados = new List<int>();

			for (int i = principal; i < ItensPedido.Count; i++)
			{
				if (i > principal && !ItensPedido[i].Secundario)
				{
					break;
				}

				ItensPedido[i].Situacao = 'C';

				cancelados.Add(i);
			}

			ItensPedido.RemoveRange(cancelados[0], cancelados.Count);

			ResetaNumerosItens();

			_totalManual = 0;
			_isTotalManual = false;
		}

		public void Limpa()
		{
			ItensPedido.Clear();

			Cliente = 0;
			Usuario = 0;
			Data = DateTime.MinValue;

			Produto = 0;
			Quantidade = 0;
			Divisor = 0;
			Valor = 0;
			TaxaDeEntrega = 0;
			PorcentagemServico = 0;
			Troco = 0;
			Observacao = string.Empty;
			Retirar = false;
			_totalManual = 0;
			_isTotalManual = false;
			_isTaxaDeServicoManual = false;
			_taxaDeServicoManual = 0;
		}

		public void LimpaAtual()
		{
			this.Produto = 0;
			this.Valor = 0;
			this.Quantidade = 1;
			this.Observacao = "";

			ItensAdicionais.Clear();
		}

		public int NovoItem(long produto, string nome, decimal unitario, float quantidade, decimal preco, string observacao)
		{
			ItemPedido item = new ItemPedido();

			_totalManual = 0;
			_isTotalManual = false;

			item.Numero = ProximoItem();

			item.Produto = produto;
			item.ProdutoNome = nome;
			item.Quantidade = quantidade;
			item.Preco = preco;
			item.Unitario = unitario;
			item.Situacao = 'A';
			item.Observacao = observacao;

			ItensPedido.Add(item);

			return ItensPedido.Count;
		}

		/// <summary>
		/// Adiciona um novo item principal ao pedido, e retorna o número deste item
		/// </summary>
		/// <param name="item">Item que vai ser adicionado ao pedido</param>
		/// <returns>Número do item adicionado</returns>
		public int NovoItem(ItemPedido item)
		{
			_totalManual = 0;
			_isTotalManual = false;

			if (item.Numero == 0)
			{
				item.Numero = ProximoItem();
			}

			item.Situacao = 'A';

			ItensPedido.Add(item);

			return item.Numero;
		}

		public int NovoItem(ItemPedido item, ItemPedido secundario)
		{
			_totalManual = 0;
			_isTotalManual = false;

			item.Numero = ProximoItem();
			item.Situacao = 'A';
			secundario.Numero = item.Numero;
			secundario.Situacao = 'A';

			ItensPedido.Add(item);
			ItensPedido.Add(secundario);

			return ItensPedido.Count;
		}

		public int NovoItem(ItemPedido item, ItemPedido secundario, ItemPedido terceiro)
		{
			_totalManual = 0;
			_isTotalManual = false;

			item.Numero = ProximoItem();
			item.Situacao = 'A';
			secundario.Numero = item.Numero;
			secundario.Situacao = 'A';
			terceiro.Numero = item.Numero;
			terceiro.Situacao = 'A';

			ItensPedido.Add(item);
			ItensPedido.Add(secundario);
			ItensPedido.Add(terceiro);

			return ItensPedido.Count;
		}

		public int NovoItem(ItemPedido item, ItemPedido secundario, ItemPedido terceiro, ItemPedido quarto)
		{
			_totalManual = 0;
			_isTotalManual = false;

			item.Numero = ProximoItem();
			item.Situacao = 'A';
			item.Secundario = false;
			secundario.Numero = item.Numero;
			secundario.Situacao = 'A';
			secundario.Secundario = true;
			terceiro.Numero = item.Numero;
			terceiro.Situacao = 'A';
			terceiro.Secundario = true;
			quarto.Numero = item.Numero;
			quarto.Situacao = 'A';
			quarto.Secundario = true;

			ItensPedido.Add(item);
			ItensPedido.Add(secundario);
			ItensPedido.Add(terceiro);
			ItensPedido.Add(quarto);

			return ItensPedido.Count;
		}

		/// <summary>
		/// Adiciona um novo item secundário ao pedido
		/// </summary>
		/// <param name="item">Item à ser adicionado ao pedido</param>
		/// <param name="numero">Número do item principal que vai estar vinculado a este item secundário</param>
		public void NovoItemSecundario(ItemPedido item, int numero)
		{
			item.Numero = numero;
			item.Secundario = true;

			NovoItem(item);
		}

		public int NovoItemSecundario(int numero, long produto, string nome, decimal unitario, float quantidade, decimal preco, string observacao = "")
		{
			ItemPedido item = new ItemPedido();
			item.Numero = numero;
			item.Produto = produto;
			item.ProdutoNome = nome;
			item.Quantidade = quantidade;
			item.Preco = preco;
			item.Unitario = unitario;
			item.Situacao = 'A';
			item.Observacao = observacao;

			item.Secundario = true;

			ItensPedido.Add(item);

			return ItensPedido.Count;
		}

		public void NumeroPedido(int numero)
		{
			Numero = numero;
		}

		public int NumeroPedido()
		{
			return Numero;
		}

		/// <summary>
		/// Calcula o valor dos itens fracionados, como 2/2 e 3/3
		/// </summary>
		public void RecalcularProdutosMultiplos()
		{
			for (int i = 0; i < ItensPedido.Count; i++)
			{
				int numero = ItensPedido[i].Numero;

				if (ItensPedido.Count(c => c.Numero == numero) > 1)
				{
					int pular = 0;

					if (((i + 1) < ItensPedido.Count) && ItensPedido[(i + 1)].Secundario)
					{
						decimal preco = ItensPedido[i].Unitario > ItensPedido[(i + 1)].Unitario ? ItensPedido[i].Unitario : ItensPedido[(i + 1)].Unitario;
						float quantidade = ItensPedido[i].Quantidade + ItensPedido[(i + 1)].Quantidade;

						ItensPedido[i].Preco = preco * (decimal)quantidade;
						ItensPedido[(i + 1)].Preco = 0;

						pular++;
					}

					if (((i + 2) < ItensPedido.Count) && ItensPedido[(i + 2)].Secundario)
					{
						if (ItensPedido[i].Unitario > ItensPedido[i + 1].Unitario && ItensPedido[i].Unitario > ItensPedido[i + 2].Unitario)
						{
							ItensPedido[i].Preco = ItensPedido[i].Unitario;
							ItensPedido[i + 1].Preco = 0;
							ItensPedido[i + 2].Preco = 0;
						}
						else if (ItensPedido[i + 1].Unitario > ItensPedido[i + 2].Unitario)
						{
							ItensPedido[i].Preco = ItensPedido[i + 1].Unitario;
							ItensPedido[i + 1].Preco = 0;
							ItensPedido[i + 2].Preco = 0;
						}
						else
						{
							ItensPedido[i].Preco = ItensPedido[i + 2].Unitario;
							ItensPedido[i + 1].Preco = 0;
							ItensPedido[i + 2].Preco = 0;
						}

						if (ItensPedido[i].Quantidade == 0.5)
						{
							float a = 1, b = 3;
							ItensPedido[i].Quantidade = ItensPedido[i + 1].Quantidade = ItensPedido[i + 2].Quantidade = a / b;
						}

						pular++;
					}

					i += pular;
				}
			}
		}

		public void ResetarNumeros()
		{
			int i = 0;

			foreach (ItemPedido item in ItensPedido)
			{
				if (!item.Secundario)
				{
					item.Numero = ++i;
				}
				else
				{
					item.Numero = i;
				}
			}
		}

		public decimal TotalProduto()
		{
			decimal total = Valor;

			if (Quantidade > 1)
			{
				total = total * (decimal)Quantidade;
			}
			else if (Divisor > 0)
			{
				total = total / Divisor;
			}

			if (Desconto > 0)
			{
				total -= ((total * Desconto) / 100);
			}

			return total + SomaAdicionais();
		}

		public void UsuarioPedido(int usuario)
		{
			Usuario = usuario;
		}

		public int UsuarioPedido()
		{
			return Usuario;
		}

		private int ProximoItem()
		{
			if (ItensPedido.Count == 0)
				return 1;
			else
				return ItensPedido[ItensPedido.Count - 1].Numero + 1;
		}

		private void ResetaNumerosItens()
		{
			int num = 0;

			foreach (ItemPedido item in ItensPedido)
			{
				if (!item.Secundario)
				{
					item.Numero = ++num;
				}
				else
				{
					item.Numero = num;
				}
			}
		}

		private decimal SomaAdicionais()
		{
			decimal valor = 0;

			foreach (ItemAdicional item in ItensAdicionais)
			{
				valor += item.Valor;
			}

			return valor * (decimal)Quantidade;
		}

		public bool AlterouCliente(Pedido other)
		{
			if (this.Cliente == other.Cliente)
				return false;
			else
				return true;
		}

		public bool ApenasAdicionou(Pedido other)
		{
			if (this.Numero != other.Numero)
				return false;

			if (this.ItensPedido != null)
			{
				if (other.ItensPedido == null)
					return false;

				if (this.ItensPedido.Count > other.ItensPedido.Count)
					return false;

				for (int i = 0; i < this.ItensPedido.Count; i++)
				{
					if (this.ItensPedido[i].Equals(other.ItensPedido[i]) == false || this.ItensPedido[i].Quantidade > other.ItensPedido[i].Quantidade)
					{
						return false;
					}
				}
			}

			if (this.Observacao != other.Observacao)
				return false;

			if (this.Situacao != other.Situacao)
				return false;

			if (this.TotalPedido > other.TotalPedido)
				return false;

			return true;
		}

		public override string ToString()
		{
			return string.Format("NÚMERO: {0} DATA: {1} {2}\n", Numero, Data.ToShortDateString(), Data.ToShortTimeString());
		}

		public object Clone()
		{
			Pedido pedido = new Pedido();

			pedido.Cliente = this.Cliente;
			pedido.Data = this.Data;
			pedido.Debito = this.Debito;
			pedido.Desconto = this.Desconto;
			pedido.Divisor = this.Divisor;
			pedido.Hora = this.Hora;
			pedido.IndicadorPagamento = this.IndicadorPagamento;
			pedido.Indice = this.Indice;

			foreach(ItemPedido item in this.ItensPedido)
			{
				pedido.ItensPedido.Add((ItemPedido)item.Clone());
			}

			pedido.Numero = this.Numero;
			pedido.Observacao = this.Observacao;
			pedido.Situacao = this.Situacao;
			pedido.Tabela = (TabelaDePrecos)this.Tabela.Clone();

			pedido.TaxaDeEntrega = this.TaxaDeEntrega;
			pedido.PorcentagemServico = this.PorcentagemServico;
			pedido._isTaxaDeServicoManual = this._isTaxaDeServicoManual;
			pedido._taxaDeServicoManual = this._taxaDeServicoManual;
			pedido.Troco = this.Troco;
			pedido.Usuario = this.Usuario;
			pedido.Valor = this.Valor;
			pedido.Vendedor = (Recurso)this.Vendedor;
			pedido.Comanda = this.Comanda;
			pedido.Retirar = this.Retirar;

			pedido._totalManual = this._totalManual;
			pedido._isTotalManual = this._isTotalManual;

			return pedido;
		}

		public bool Equals(Pedido other)
		{
			if (this.Numero != other.Numero)
				return false;

			if (this.Cliente != other.Cliente)
				return false;

			if (this.ItensPedido != null)
			{
				if (other.ItensPedido == null)
					return false;

				if (this.ItensPedido.Count != other.ItensPedido.Count)
					return false;

				for (int i = 0; i < this.ItensPedido.Count; i++)
				{
					if (this.ItensPedido[i].Equals(other.ItensPedido[i]) == false || this.ItensPedido[i].Quantidade != other.ItensPedido[i].Quantidade)
					{
						return false;
					}
				}
			}

			if (this.Observacao != other.Observacao)
				return false;

			if (this.Situacao != other.Situacao)
				return false;

			if (this.TotalPedido != other.TotalPedido)
				return false;

			return true;
		}

		#endregion Methods
	}
}