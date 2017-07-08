using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	#region Enumerations

	[Flags]
	public enum Permissoes
	{
		Administrador,
		Pedidos,
		Caixa,
		Entregas,
		CancelarPedidos,
		Relatorios
	}

	#endregion Enumerations
}