using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Alerta
	{
		public int Indice;
		public DateTime Criacao;
		public Usuario UsuarioOrigem;
		public Usuario UsuarioDestino;
		public DateTime Data;
		public DateTime Hora;
		public char Situacao;
		public string Titulo;
		public string Observacao;
		public Cliente Cliente;
		public Lead Lead;
	}
}
