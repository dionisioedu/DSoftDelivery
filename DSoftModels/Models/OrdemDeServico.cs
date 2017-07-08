using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class OrdemDeServico
	{
		public int Numero;
		public DateTime Abertura;
		public TipoDeServico Tipo;
		public string Status;
		public Recurso Funcionario;
		public DateTime Fechamento;
		public Periodo Periodo;
		public long Cliente;
		public string Observacao;
		public Usuario Usuario;
	}
}
