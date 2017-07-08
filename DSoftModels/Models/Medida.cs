using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Medida
	{
		#region Constructors

		public Medida()
		{
			Codigo = 0;
			Descricao = "";
			Abreviatura = "";
		}

		public Medida(int codigo)
		{
			Codigo = codigo;
			Descricao = "";
			Abreviatura = "";
		}

		#endregion Constructors

		#region Properties

		public string Abreviatura
		{
			get; set;
		}

		public int Codigo
		{
			get; set;
		}

		public string Descricao
		{
			get; set;
		}

		#endregion Properties
	}
}