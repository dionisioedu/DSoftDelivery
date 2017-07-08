using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ProdutoTipo
	{
		#region Constructors

		public ProdutoTipo()
		{
			LocacaoEspecial = new List<LocacaoEspecial>();
		}

		#endregion Constructors

		#region Properties

		public bool Adicionais
		{
			get;
			set;
		}

		public int Codigo
		{
			get;
			set;
		}

		public string Descricao
		{
			get;
			set;
		}

		public bool Estoque
		{
			get;
			set;
		}

		public bool Fracionado
		{
			get;
			set;
		}

		public int ImpressoraExterna
		{
			get;
			set;
		}

		public bool MeioAMeio
		{
			get;
			set;
		}

		public string Nome
		{
			get;
			set;
		}

		public bool Producao
		{
			get;
			set;
		}

		public char Situacao
		{
			get;
			set;
		}

		public bool Soma
		{
			get;
			set;
		}

		public bool PermiteLocacao
		{
			get;
			set;
		}

		public string IntervaloDeLocacao
		{
			get;
			set;
		}

		public int PeriodoLocacao
		{
			get;
			set;
		}

		public List<LocacaoEspecial> LocacaoEspecial
		{
			get;
			set;
		}

		public bool ImprimeQuantidadeTotal
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods

		public override bool Equals(object obj)
		{
			ProdutoTipo other = obj as ProdutoTipo;

			if (other == null)
			{
				return false;
			}

			return Codigo == other.Codigo;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}

		#endregion Methods
	}
}