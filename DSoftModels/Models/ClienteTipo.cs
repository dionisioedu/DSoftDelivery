using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ClienteTipo
	{
		#region Fields

		private int _codigo;
		private bool _interno;
		private string _nome;
		private bool _mensalidade;

		#endregion Fields

		#region Constructors

		public ClienteTipo()
		{
		}

		#endregion Constructors

		#region Properties

		public int Codigo
		{
			get
			{
				return _codigo;
			}
			set
			{
				if (value != _codigo)
				{
					_codigo = value;
				}
			}
		}

		public bool Interno
		{
			get
			{
				return _interno;
			}
			set
			{
				if (value != _interno)
				{
					_interno = value;
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
				if (value != _nome)
				{
					_nome = value;
				}
			}
		}

		public bool Mensalidade
		{
			get
			{
				return _mensalidade;
			}
			set
			{
				if (value != _mensalidade)
				{
					_mensalidade = value;
				}
			}
		}

		#endregion Properties

		#region Methods

		public override bool Equals(object obj)
		{
			ClienteTipo other = obj as ClienteTipo;

			if (other == null)
				return false;

			return this._codigo == other.Codigo;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0} - {1}", this._codigo, this._nome);
		}

		#endregion Methods
	}
}