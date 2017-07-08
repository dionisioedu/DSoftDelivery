using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Manifesto
	{
		#region Fields

		public Veiculo Carreta;
		public DateTime Chegada;
		public string CIOT;
		public DataTable Conhecimentos;
		public DateTime Data;
		public Emitente Emitente;
		public int Indice;
		public int Itens;
		public Recurso Motorista;
		public List<OrdemDeColeta> OrdemDeColeta;
		public string RNTRC;
		public DateTime Saida;
		public char Situacao;
		public Veiculo Veiculo;
		public string Chave;
		public string Protocolo;
		public string UFEntrega;
		public string MunEntrega;
		public int CodUFEntrega;
		public int CodMunEntrega;
		public int Numero;
		public string Arquivo;

		#endregion Fields

		#region Constructors

		public Manifesto()
		{
			Emitente = new Emitente();
			Motorista = new Recurso();
			Veiculo = new Veiculo();
			Carreta = new DSoftModels.Veiculo();

			OrdemDeColeta = new List<DSoftModels.OrdemDeColeta>();

			Itens = 0;
		}

		#endregion Constructors
	}
}