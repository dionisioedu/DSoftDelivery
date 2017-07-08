using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Lead
	{
		public int Indice;
		public string Nome;
		public string Endereco;
		public string Numero;
		public string Bairro;
		public string Cidade;
		public string Estado;
		public string Pais;
		public string Cep;
		public long Tel1;
		public long Tel2;
		public long Celular;
		public string Contato;
		public string Ramo;
		public DateTime Cadastro;
		public string Origem;
		public char Situacao;
		public Usuario Usuario;
		public Cliente Cliente;
		public string Observacao;

		public override string ToString()
		{
			return string.Format("{0} ({1})", Nome, Indice);
		}

		public override bool Equals(object obj)
		{
			Lead other = obj as Lead;

			if (other == null)
				return false;

			return this.Indice == other.Indice;
		}
	}
}
