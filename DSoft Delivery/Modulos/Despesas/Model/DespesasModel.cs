using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSoftModels;

namespace DSoft_Delivery.Despesas
{
	class DespesasModel : Despesa
	{
		#region Constructors

		public DespesasModel()
		{
			Vencimento = DateTime.Now.Date;
		}

		#endregion Constructors

		#region Properties

		public Despesa Despesa
		{
			get
			{
				return new Despesa()
				{
					Data = this.Data,
					Documento = this.Documento,
					Fornecedor = this.Fornecedor,
					Indice = this.Indice,
					Observacao = this.Observacao,
					Pagamento = this.Pagamento,
					Situacao = this.Situacao,
					Tipo = this.Tipo,
					Valor = this.Valor,
					ValorPago = this.ValorPago,
					Vencimento = this.Vencimento
				};
			}
		}

		public bool isCanceled
		{
			get
			{
				if (this.Situacao == 'C')
					return true;

				return false;
			}
		}

		public bool isNew
		{
			get
			{
				if (Indice != 0)
					return false;

				return true;
			}
		}

		public bool isPaid
		{
			get
			{
				if (this.Situacao == 'P')
					return true;

				return false;
			}
		}

		public bool isValid
		{
			get
			{
				if (Tipo == 0 || Fornecedor == 0)
					return false;

				return true;
			}
		}

		#endregion Properties
	}
}