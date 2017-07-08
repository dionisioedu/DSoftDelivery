using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DSoft_Delivery.Despesas
{
	interface IDespesasView
	{
		#region Events

		event EventHandler CancelarClicked;

		event EventHandler NovoClicked;

		event EventHandler PagarClicked;

		event EventHandler SairClicked;

		event EventHandler TiposClicked;

		#endregion Events

		#region Methods

		void ClearFields();

		void PrepareNew();

		void SetDataSource(DataSet ds);

		void SetTypes(string[] types);

		string Titulo();

		#endregion Methods
	}
}