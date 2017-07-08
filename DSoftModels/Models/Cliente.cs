using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Cliente
	{
		#region Fields

		public string Bairro;
		public long Celular;
		public string Cep;
		public string Cidade;
		public ClienteTipo ClienteTipo;
		public long Codigo;
		public string Complemento;
		public string Conjuge;
		public string Documento;
		public string Endereco;
		public string Estado;
		public int Grupo;
		public string GrupoDescricao;
		public string InscricaoEstadual;
		public string InscricaoSuframa;
		public bool IsentoICMS;
		public double Limite;
		public string Mae;
		public DateTime Nascimento;
		public string Nome;
		public string Numero;
		public string Observacao;
		public string Pai;
		public string Pais;
		public string Profissao;
		public string Referencia;
		public string Rg;
		public decimal Saldo;
		public char Situacao;
		public int? Tabela;
		public long Telefone1;
		public long Telefone2;
		public string Auxiliar;
		public char Tipo;
		public string Email;
		public int VencimentoMensalidade;
		public decimal ValorMensalidade;
		public string Contato;
		public string Site;
		public decimal TaxaDeEntrega;
		public Recurso Funcionario;

		#endregion Fields

		#region Constructors

		public Cliente()
		{
			ClienteTipo = new ClienteTipo();
		}

		public Cliente(long codigo)
			: base()
		{
			Codigo = codigo;
		}

		#endregion Constructors

		#region Methods

		public bool Preencher()
		{
			//if (Codigo != 0)
			//{
			//    if (Bd.ClienteNome(Codigo, ref Nome, ref Situacao))
			//    {
			//        Endereco = string.Empty;
			//        Cidade = string.Empty;
			//        Documento = string.Empty;
			//        InscricaoEstadual = string.Empty;

			//        return true;
			//    }
			//}

			//if (Nome != string.Empty)
			//{
			//    if ((Codigo = Bd.ClienteCodigo(Nome)) > 0)
			//    {
			//        if (Bd.ClienteCadastrado(Codigo))
			//        {
			//            Endereco = string.Empty;
			//            Cidade = string.Empty;
			//            Documento = string.Empty;
			//            InscricaoEstadual = string.Empty;

			//            return true;
			//        }
			//    }
			//}

			return false;
		}

		private bool CadastroCompleto()
		{
			return Telefone1 > 0 || Telefone2 > 0 || Celular > 0 || Endereco != null;
		}

		public override string ToString()
		{
			if (Codigo == 0)
			{
				return "";
			}

			if (CadastroCompleto())
			{
				return string.Format("{0} - {1}\nTel: {2} Tel: {3} Celular: {4}\n{5} - {6} - {7}\\{8}", Codigo, Nome, Telefone1, Telefone2, Celular, Endereco, Bairro, Cidade, Estado);
			}
			else
			{
				return string.Format("{0} - {1}", Codigo, Nome);
			}
		}

		public override bool Equals(object obj)
		{
			Cliente other = obj as Cliente;

			if (other == null)
			{
				return false;
			}
			else
			{
				return Codigo == other.Codigo;
			}
		}

		#endregion Methods
	}
}