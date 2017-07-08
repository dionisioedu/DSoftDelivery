using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	#region Enumerations

	public enum Situacoes : byte
	{
		Ativo = (byte)'A',
		Bloqueado = (byte)'B',
		Cancelado = (byte)'C',
		Entregue = (byte)'E',
		Pago = (byte)'P'
	}

	#endregion Enumerations
}