using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ContactLog
	{
		public int Indice;
		public DateTime Data;
		public DateTime Hora;
		public Usuario Usuario;
		public Lead Lead;
		public string Motivo;
		public string Descricao;
		public string Conclusao;
		public Temperaturas Temperatura;
		public bool Retorno;
		public DateTime RetornoData;
		public DateTime RetornoHora;
		public bool CriarAlerta;
	}
}
