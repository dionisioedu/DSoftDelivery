using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Compra
	{
		#region Fields

		public int Codigo;
		public DateTime Data;
		public int Fornecedor;
		public CompraItem[] Item;
		public int Itens;
		public string Observacao;
		public int Situacao;
		public int Usuario;
		public decimal Valor;

		#endregion Fields

		#region Constructors

		public Compra()
		{
			Item = new CompraItem[256];
		}

		#endregion Constructors

		#region Methods

		public bool ExcluirItem(int item)
		{
			int numero;

			Valor -= Item[item].Total;

			numero = Item[item].Numero;

			for (int i = item; i < Itens; i++)
			{
				if (Item[i] == null)
				{
					break;
				}

				if ((i + 1) < Itens)
				{
					Item[i] = Item[i + 1];
				}
				else
				{
					Item[i] = null;

					break;
				}

				Item[i].Numero = numero++;
			}

			Itens--;

			return true;
		}

		public void Limpar()
		{
			LimparItens();

			Fornecedor = 0;
			Data = DateTime.Now;
			Codigo = 0;
			Situacao = 'A';
			Usuario = 0;
		}

		public void LimparItens()
		{
			for (int i = 0; i < Item.Length; i++)
			{
				if (Item[i] != null)
				{
					Item[i] = null;
				}
				else
				{
					break;
				}
			}

			Valor = 0;
			Itens = 0;
		}

		public int NovoItem(CompraItem item)
		{
			Item[Itens] = new CompraItem();
			Item[Itens] = item;

			Item[Itens].Numero = ++Itens;

			Valor += item.Total;

			return Itens;
		}

		#endregion Methods
	}
}