using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Periodo
	{
		public string Id;
		public string Descricao;
		public DateTime Inicio;
		public DateTime Final;

		public bool isValid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Id) && !string.IsNullOrEmpty(Descricao);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", Inicio.ToString("HH:mm:ss"), Final.ToString("HH:mm:ss"));
		}
	}
}
