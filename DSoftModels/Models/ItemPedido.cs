using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ItemPedido : IEquatable<ItemPedido>, ICloneable
	{
		#region Fields

		public decimal Desconto;
		public bool Dupla;
		public List<ItemAdicional> ItensAdicionais;
		public int Numero;
		public string Observacao;
		public decimal Preco;
		public long Produto;
		public string ProdutoNome;
		public float Quantidade;
		public bool Secundario;
		public char Situacao;
		public decimal Unitario;
		public int Recurso;

		#endregion Fields

		#region Constructors

		public ItemPedido()
		{
			Situacao = 'B';
			ItensAdicionais = new List<ItemAdicional>();
		}

		#endregion Constructors

		#region Methods

		public bool Equals(ItemPedido item)
		{
			if (item == null)
			{
				return false;
			}

			if (this.Produto != item.Produto || this.Unitario != item.Unitario || this.Observacao != item.Observacao)
			{
				return false;
			}
			else
			{
				if (item.ItensAdicionais.Count != this.ItensAdicionais.Count)
				{
					return false;
				}
				else if (this.ItensAdicionais.Count > 0)
				{
					foreach (ItemAdicional i in this.ItensAdicionais)
					{
						if (item.ItensAdicionais.Contains(i) == false)
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		public void Limpa()
		{
			Numero = 0;
			Preco = 0;
			Unitario = 0;
			Produto = 0;
			Quantidade = 0;
			Situacao = 'B';
			Secundario = false;
			Dupla = false;
		}

		public int NumeroItem()
		{
			return Numero;
		}

		public override string ToString()
		{
			if (ProdutoNome.Length > 22)
			{
				return string.Format("{0:000} {1:000000} - {2} {3,8} x {4,4} {5,8}", Numero, Produto, ProdutoNome.Substring(0, 22), Unitario.ToString("#,##0.00"), Quantidade.ToString("00.0"), Preco.ToString("#,##0.00"));
			}
			else
			{
				return string.Format("{0:000} {1:000000} - {2,-22} {3,8} x {4,4} {5,8}", Numero, Produto, ProdutoNome, Unitario.ToString("#,##0.00"), Quantidade.ToString("00.0"), Preco.ToString("#,##0.00"));
			}
		}

		public object Clone()
		{
			ItemPedido clone = new ItemPedido();
			clone.Desconto = this.Desconto;
			clone.Dupla = this.Dupla;
			clone.Numero = this.Numero;
			clone.Observacao = this.Observacao;
			clone.Preco = this.Preco;
			clone.Produto = this.Produto;
			clone.ProdutoNome = this.ProdutoNome;
			clone.Quantidade = this.Quantidade;
			clone.Recurso = this.Recurso;
			clone.Secundario = this.Secundario;
			clone.Situacao = this.Situacao;
			clone.Unitario = this.Unitario;

			foreach (ItemAdicional i in this.ItensAdicionais)
			{
				clone.ItensAdicionais.Add(i);
			}

			return clone;
		}

		#endregion Methods
	}
}