using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class TabelaDePrecos : ICloneable
	{
		#region Fields

		private int _codigo;
		private string _descricao;
		private string _nome;
		private char _situacao;

		#endregion Fields

		#region Constructors

		public TabelaDePrecos()
		{
		}

		public TabelaDePrecos(int codigo)
		{
			_codigo = codigo;
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
				if (_codigo != value)
				{
					_codigo = value;
				}
			}
		}

		public string Descricao
		{
			get
			{
				return _descricao;
			}
			set
			{
				if (_descricao != value)
				{
					_descricao = value;
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

		public override string ToString()
		{
			return Codigo + " - " + Nome;
		}

		public object Clone()
		{
			TabelaDePrecos tabela = new TabelaDePrecos();

			tabela._codigo = this._codigo;
			tabela._descricao = this._descricao;
			tabela._nome = this._nome;
			tabela._situacao = this._situacao;

			return tabela;
		}

		#endregion Properties
	}
}