using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using DSoftModels;

namespace DSoft_Delivery.Financeiro
{
	class FinanceiroModel : FluxoDeCaixa, IFinanceiroModel
	{
		#region Fields

		public LancamentoTipo LancamentoTipo = LancamentoTipo.NotSet;

		private long _codigo;
		private string _nome;
		private char _tipo;

		#endregion Fields

		#region Constructors

		public FinanceiroModel()
		{
		}

		#endregion Constructors

		#region Properties

		public new long Codigo
		{
			get
			{
				return _codigo;
			}
			set
			{
				_codigo = value;

				if (this.LancamentoTipo == LancamentoTipo.Entrada)
				{
					this.Cliente = value;
				}
				else if (this.LancamentoTipo == LancamentoTipo.Pagamento || this.LancamentoTipo == LancamentoTipo.Vale)
				{
					this.Recurso = value;
				}
			}
		}

		public FluxoDeCaixa FluxoDeCaixa
		{
			get
			{
				FluxoDeCaixa caixa = new FluxoDeCaixa();

				caixa.Caixa = this.Caixa;
				caixa.Cliente = this.Cliente;
				caixa.Codigo = this.Codigo;
				caixa.Data = this.Data;
				caixa.Despesa = this.Despesa;
				caixa.Forma = this.Forma;
				caixa.Indice = this.Indice;
				caixa.Observacao = this.Observacao;
				caixa.Pedido = this.Pedido;
				caixa.Recurso = this.Recurso;
				caixa.Situacao = this.Situacao;
				caixa.Tipo = this.Tipo;
				caixa.Valor = this.Valor;

				return caixa;
			}
		}

		public bool isValid
		{
			get
			{
				if (this.Data == null)
					return false;

				if (this.LancamentoTipo == LancamentoTipo.Saida)
				{

				}

				return true;
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
				_nome = value;
			}
		}

		public new char Tipo
		{
			get
			{
				return _tipo;
			}
			set
			{
				this._tipo = value;

				switch (value)
				{
					case 'E':
						{
							this.LancamentoTipo = LancamentoTipo.Entrada;

							break;
						}

					case 'P':
						{
							this.LancamentoTipo = LancamentoTipo.Pagamento;

							break;
						}

					case 'S':
						{
							this.LancamentoTipo = LancamentoTipo.Saida;

							break;
						}

					case 'T':
						{
							this.LancamentoTipo = LancamentoTipo.Transferencia;

							break;
						}

					case 'V':
						{
							this.LancamentoTipo = LancamentoTipo.Vale;

							break;
						}
				}
			}
		}

		#endregion Properties
	}
}