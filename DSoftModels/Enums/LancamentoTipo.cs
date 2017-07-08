using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	#region Enumerations

	public enum LancamentoTipo : byte
	{
		Despesa,
		Entrada,
		Pagamento,
		Saida,
		Transferencia,
		Vale,
		NotSet
	}

	#endregion Enumerations
}