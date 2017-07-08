using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Emitente
	{
		#region Fields

		public string Bairro;
		public string Cep;
		public string CNAEFiscal;
		public long Cnpj;
		public string Complemento;
		public string Email;
		public string InscricaoEstadual;
		public string InscricaoMunicipal;
		public string Logradouro;
		public string Municipio;
		public string NomeFantasia;
		public string Numero;
		public string Pais;
		public string RazaoSocial;
		public string RNTRC;
		public char Situacao;
		public string Telefone;
		public string Uf;

		#endregion Fields

		#region Other

		//public bool Preencher()
		//{
		//	try
		//	{
		//		if (RazaoSocial != null && RazaoSocial != string.Empty)
		//		{
		//			Cnpj = Bd.EmitenteCnpj(RazaoSocial);
		//			return true;
		//		}
		//		if (Cnpj != null && Cnpj != 0)
		//		{
		//			RazaoSocial = Bd.EmitenteRazaoSocial(Cnpj);
		//			return true;
		//		}
		//		return false;
		//	}
		//	catch (Exception e)
		//	{
		//		return false;
		//	}
		//}

		#endregion Other
	}
}