using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels.Enums
{
	public enum FluxosDeCaixa : byte
	{
		Entrada = (byte)'E',
		Saida = (byte)'S',
		Despesa = (byte)'D',
		Vale = (byte)'V',
		Pagamento = (byte)'P',
		Transferencia = (byte)'T'
	}
}
