using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftParameters
{
	public class Matriz
	{
		#region Fields

		public int _Intervalo;
		public bool _Matriz;
		public string _Pasta;
		public long _Porta;
		public string _Servidor;

		#endregion Fields

		#region Constructors

		public Matriz()
		{
			Parametros p = new Parametros();
			_Matriz = p.matriz;
			_Servidor = p.matriz_servidor;
			_Porta = p.matriz_porta;
			_Intervalo = p.matriz_intervalo;
			_Pasta = p.matriz_pasta;
		}

		#endregion Constructors

		#region Methods

		public static string Pasta2()
		{
			Parametros p = new Parametros();
			return p.matriz_pasta;
		}

		public static bool Sincroniza()
		{
			Parametros p = new Parametros();
			return p.matriz;
		}

		public int Intervalo()
		{
			Parametros p = new Parametros();
			return p.matriz_intervalo;
		}

		public void Intervalo(int i)
		{
			Parametros p = new Parametros();
			p.matriz_intervalo = i;
			p.Save();
		}

		public string Pasta()
		{
			Parametros p = new Parametros();
			return p.matriz_pasta;
		}

		public void Pasta(string pasta)
		{
			Parametros p = new Parametros();
			p.matriz_pasta = pasta;
			p.Save();
		}

		public long Porta()
		{
			Parametros p = new Parametros();
			return p.matriz_porta;
		}

		public void Porta(long porta)
		{
			Parametros p = new Parametros();
			p.matriz_porta = porta;
			p.Save();
		}

		public void Salvar(bool matriz, string servidor, long porta, int intervalo, string pasta)
		{
			Parametros p = new Parametros();
			p.matriz = matriz;
			p.matriz_servidor = servidor;
			p.matriz_porta = porta;
			p.matriz_intervalo = intervalo;
			p.matriz_pasta = pasta;
			p.Save();
		}

		public void Salvar()
		{
			Parametros p = new Parametros();
			p.matriz = _Matriz;
			p.matriz_servidor = _Servidor;
			p.matriz_porta = _Porta;
			p.matriz_intervalo = _Intervalo;
			p.matriz_pasta = _Pasta;
			p.Save();
		}

		public string Servidor()
		{
			Parametros p = new Parametros();
			return p.matriz_servidor;
		}

		public void Servidor(string s)
		{
			Parametros p = new Parametros();
			p.matriz_servidor = s;
			p.Save();
		}

		public bool TemMatriz()
		{
			Parametros p = new Parametros();
			return p.matriz;
		}

		public void TemMatriz(bool m)
		{
			Parametros p = new Parametros();
			p.matriz = m;
			p.Save();
		}

		#endregion Methods
	}
}