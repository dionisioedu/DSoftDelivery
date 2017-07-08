using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Fornecedor
	{
		#region Fields

		public string Bairro;
		public int Cep;
		public string Cidade;
		public string Cnpj;
		public long Codigo;
		public string Contato;
		public string Endereco;
		public string Estado;
		public string Nome;
		public string Observacao;
		public string Pais;
		public char Situacao;
		public long Telefone1;
		public long Telefone2;
		public FornecedorTipo Tipo;
		public string Email;

		#endregion Fields

		#region Constructors

		public Fornecedor()
		{
		}

		public Fornecedor(long codigo)
		{
			Codigo = codigo;
		}

		#endregion Constructors
	}
}