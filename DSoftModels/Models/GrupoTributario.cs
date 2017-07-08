using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class GrupoTributario
	{
		#region Fields

		public int Codigo;
		public float COFINS;
		public float CSLL;
		public float ICMS;
		public float IPI;
		public float IRRF;
		public string Nome;
		public float PIS;
		public Situacoes Situacao;

		#endregion Fields
	}
}