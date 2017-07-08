using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public enum Temperaturas : byte
	{
		Aberto = (byte)'A',
		Perdido = (Byte)'0',
		Frio = (Byte)'1',
		Morno = (Byte)'2',
		Quente = (Byte)'3',
		Cliente = (Byte)'P'
	}
}
