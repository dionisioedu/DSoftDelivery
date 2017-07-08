using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Locacao
	{
		public Locacao()
		{
			Produtos = new List<Produto>();
		}

		public int Indice
		{
			get;
			set;
		}

		public TabelaDePrecos Tabela
		{
			get;
			set;
		}

		public Cliente Cliente
		{
			get;
			set;
		}

		public DateTime InicioData
		{
			get;
			set;
		}

		public DateTime InicioHora
		{
			get;
			set;
		}

		public DateTime PrevisaoData
		{
			get;
			set;
		}

		public DateTime PrevisaoHora
		{
			get;
			set;
		}

		public DateTime DevolucaoData
		{
			get;
			set;
		}

		public DateTime DevolucaoHora
		{
			get;
			set;
		}

		public decimal ValorPrevisto
		{
			get;
			set;
		}

		public decimal Valor
		{
			get;
			set;
		}

		public string Observacao
		{
			get;
			set;
		}

		public string ObservacaoRecepcao
		{
			get;
			set;
		}

		public string Situacao
		{
			get;
			set;
		}

		public Usuario UsuarioInicio
		{
			get;
			set;
		}

		public Usuario UsuarioRecepcao
		{
			get;
			set;
		}

		public List<Produto> Produtos
		{
			get;
			set;
		}
	}
}
