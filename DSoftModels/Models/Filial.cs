using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Filial : IEquatable<Filial>
	{
		public string Bairro;
		public string Banco;
		public string Cep;
		public string Cidade;
		public string Cnpj;
		public int Codigo;
		public string Endereco;
		public string Estado;
		public string IE;
		public string Ip;
		public string Nome;
		public string Pais;
		public string Porta;
		public int Telefone;
		public string Situacao;

		private static Filial _instance;

		public static Filial Instance()
		{
			if (_instance == null)
			{
				_instance = new Filial();
			}

			return _instance;
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", this.Codigo, this.Nome);
		}

		public bool Equals(Filial other)
		{
			return this.Codigo == other.Codigo;
		}
	}
}