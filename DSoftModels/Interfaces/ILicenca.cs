using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public interface ILicenca
	{
		#region Properties

		string CNPJ
		{
			get;
		}

		bool Demo
		{
			get;
		}

		string Endereco
		{
			get;
		}

		string Nome
		{
			get;
		}

		int Numero
		{
			get;
		}

		string Telefone
		{
			get;
		}

		bool Expirou
		{
			get;
		}

		#endregion Properties
	}
}