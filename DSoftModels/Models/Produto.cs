using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Produto
	{
		#region Constructors

		public Produto()
		{
			Medida = new Medida();
			MedidaTributavel = new Medida();
		}

		#endregion Constructors

		#region Properties

		public string CFOP
		{
			get; set;
		}

		public long Codigo
		{
			get; set;
		}

		public string Descricao
		{
			get; set;
		}

		public string EAN
		{
			get; set;
		}

		public string EANTrib
		{
			get; set;
		}

		public Fornecedor Fornecedor
		{
			get; set;
		}

		public string Foto
		{
			get; set;
		}

		public int Grupo
		{
			get; set;
		}

		public int GrupoTributario
		{
			get; set;
		}

		public Medida Medida
		{
			get; set;
		}

		public Medida MedidaTributavel
		{
			get; set;
		}

		public string NCM
		{
			get; set;
		}

		public string Nome
		{
			get; set;
		}

		public bool Producao
		{
			get; set;
		}

		public int QuantidadeTributavel
		{
			get; set;
		}

		public char Situacao
		{
			get; set;
		}

		public int Tipo
		{
			get; set;
		}

		public ProdutoTipo ProdutoTipo
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods

		public override bool Equals(object obj)
		{
			Produto other = obj as Produto;

			if (other == null)
				return false;

			return Codigo == other.Codigo;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}

		#endregion Methods
	}
}