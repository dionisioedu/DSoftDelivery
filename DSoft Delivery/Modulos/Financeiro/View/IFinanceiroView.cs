using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DSoftModels;

namespace DSoft_Delivery
{
	interface IFinanceiroView
	{
		#region Events

		event EventHandler Cancelar;
		event EventHandler Initialize;
		event EventHandler Novo;

		#endregion Events

		#region Methods

		DateTime LerData();
		string LerObservacoes();
		string LerValor();
		void LimparDados();
		void NovoLancamento();
		void PreencherClientes(DataSet ds);
		void PreencherFormasDePagamento(List<FormaDePagamento> formas);
		void PreencherLancarEntrada(long cliente, decimal valor);
		void PreencherRecursos(List<Recurso> recursos);
		void SetDataSource(DataSet ds);

		#endregion Methods
	}
}