using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DSoftCore
{
	public class Tanca
	{
		[DllImport("SAT.dll")]
		public static extern IntPtr ConsultarSAT(int numeroSessao);

		public static string ConsultarSAT()
		{
			string retorno = string.Empty;

			retorno = ConsultarSAT(0).ToString();

			return retorno;
		}
	}
}
