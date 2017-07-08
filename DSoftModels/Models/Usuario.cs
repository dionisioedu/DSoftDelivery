using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class Usuario : IComparable<Usuario>
	{
		#region Fields

		private int _codigo;
		private char _nivel;
		private NivelUsuario _nivelUsuario;
		private string _nome;
		private string _display;
		private string _senha;
		private char _situacao;
		private Recurso _recurso;

		#endregion Fields

		#region Constructors

		public Usuario()
		{
			NivelUsuario = new NivelUsuario();
			_recurso = new Recurso();
		}

		public Usuario(int codigo)
			: base()
		{
			_codigo = codigo;
		}

		#endregion Constructors

		#region Properties

		public int Autorizado
		{
			get { return Codigo; }
			set { Codigo = value; }
		}

		public int Codigo
		{
			get
			{
				return _codigo;
			}
			set
			{
				if (_codigo != value)
				{
					_codigo = value;
				}
			}
		}

		public char Nivel
		{
			get
			{
				return _nivel;
			}
			set
			{
				if (_nivel != value)
				{
					_nivel = value;
				}
			}
		}

		public NivelUsuario NivelUsuario
		{
			get
			{
				return _nivelUsuario;
			}
			set
			{
				if (_nivelUsuario != value)
				{
					_nivelUsuario = value;
				}
			}
		}

		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				if (_nome != value)
				{
					_nome = value;
				}
			}
		}

		public string Display
		{
			get
			{
				return _display;
			}
			set
			{
				if (_display != value)
				{
					_display = value;
				}
			}
		}

		public string Senha
		{
			get
			{
				return _senha;
			}
			set
			{
				if (_senha != value)
				{
					_senha = value;
				}
			}
		}

		public char Situacao
		{
			get
			{
				return _situacao;
			}
			set
			{
				if (_situacao != value)
				{
					_situacao = value;
				}
			}
		}

		public Recurso Recurso
		{
			get
			{
				return _recurso;
			}
			set
			{
				if (_recurso != value)
				{
					_recurso = value;
				}
			}
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", _codigo, _nome);
		}

		public int CompareTo(Usuario other)
		{
			return this.Codigo.CompareTo(other.Codigo);
		}

		#endregion Properties
	}
}
