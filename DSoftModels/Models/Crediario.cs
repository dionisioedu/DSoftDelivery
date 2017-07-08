using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Crediario
	{
		#region Fields

		public Cliente Cliente;
		public int Numero;
		public System.Data.DataSet Parcelas;
		public double ValorTotal;

		#endregion Fields
	}
}