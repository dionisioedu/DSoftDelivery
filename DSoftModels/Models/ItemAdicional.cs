using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class ItemAdicional
	{
		#region Fields

		private string _descricao;
		private decimal _valor;

		#endregion Fields

		#region Properties

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

		public decimal Valor
		{
			get
			{
				return _valor;
			}

			set
			{
				if (_valor != value)
				{
					_valor = value;
				}
			}
		}

		#endregion Properties

		#region Methods

		public override string ToString()
		{
			if (_valor > 0)
			{
				return string.Format("    {0} (+{1})", _descricao, _valor.ToString("0.00"));
			}
			else if (_valor < 0)
			{
				return string.Format("    {0} ({1})", _descricao, _valor.ToString("0.00"));
			}
			else
			{
				return "    " + _descricao;
			}
		}

		public override bool Equals(object obj)
		{
			ItemAdicional item = obj as ItemAdicional;

			if (item == null)
			{
				return false;
			}

			return item.Descricao == _descricao && item.Valor == _valor;
		}

		#endregion Methods
	}
}