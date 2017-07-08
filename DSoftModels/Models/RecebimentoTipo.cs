using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class RecebimentoTipo
	{
		public int Codigo;
		public string Nome;

		public override string ToString()
		{
			return string.Format("{0} - {1}", Codigo, Nome);
		}

		public override bool Equals(object obj)
		{
			RecebimentoTipo other = obj as RecebimentoTipo;

			if (other == null)
			{
				return false;
			}
			else
			{
				return Codigo.Equals(other.Codigo);
			}
		}
	}
}
