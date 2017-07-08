using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Recurso : ICloneable, IComparable<Recurso>, IEquatable<Recurso>, IComparable
	{
		#region Constructors

		public Recurso()
		{
		}

		#endregion

		#region Properties

		public string Categoria
		{
			get;
			set;
		}

		public long? Celular
		{
			get;
			set;
		}

		public string Cidade
		{
			get;
			set;
		}

		public int Codigo
		{
			get;
			set;
		}

		public string Cpf
		{
			get;
			set;
		}

		public string Endereco
		{
			get;
			set;
		}

		public string Estado
		{
			get;
			set;
		}

		public string Habilitacao
		{
			get;
			set;
		}

		public DateTime Nascimento
		{
			get;
			set;
		}

		public string Nome
		{
			get;
			set;
		}

		public string Rg
		{
			get;
			set;
		}

		public char Situacao
		{
			get;
			set;
		}

		public long? Telefone1
		{
			get;
			set;
		}

		public long? Telefone2
		{
			get;
			set;
		}

		public char Tipo
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}

		public object Clone()
		{
			Recurso recurso = new Recurso();

			recurso.Categoria = this.Categoria;
			recurso.Celular = this.Celular;
			recurso.Cidade = this.Cidade;
			recurso.Codigo = this.Codigo;
			recurso.Cpf = this.Cpf;
			recurso.Email = this.Email;
			recurso.Endereco = this.Endereco;
			recurso.Estado = this.Estado;
			recurso.Habilitacao = this.Habilitacao;
			recurso.Nascimento = this.Nascimento;
			recurso.Nome = this.Nome;
			recurso.Rg = this.Rg;
			recurso.Situacao = this.Situacao;
			recurso.Telefone1 = this.Telefone1;
			recurso.Telefone2 = this.Telefone2;
			recurso.Tipo = this.Tipo;

			return recurso;
		}

		public int CompareTo(Recurso other)
		{
			return Codigo.CompareTo(other.Codigo);
		}

		public bool Equals(Recurso other)
		{
			return Codigo.Equals(other.Codigo);
		}

		public int CompareTo(object obj)
		{
			Recurso other = obj as Recurso;

			if (other == null)
				return -1;

			return Codigo.CompareTo(other.Codigo);
		}

		#endregion Properties
	}
}