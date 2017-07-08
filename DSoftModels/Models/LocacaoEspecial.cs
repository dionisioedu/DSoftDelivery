using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class LocacaoEspecial
	{
		public LocacaoEspecial()
		{
		}

		public string Descricao
		{
			get;
			set;
		}

		public int Periodo
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("{0} ({1})", Descricao, Periodo);
		}
	}
}
