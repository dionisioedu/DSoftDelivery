using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery.Despesas
{
	class DespesasPresenter
	{
		#region Fields

		private bool Finished = false;
		private DespesasModel Model;
		private IDespesasView View;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public DespesasPresenter(Bd bd, Usuario usuario, IDespesasView view, DespesasModel model)
		{
			View = view;
			Model = model;

			_dsoftBd = bd;
			_usuario = usuario;

			View.SairClicked += new EventHandler(View_SairClicked);
			View.NovoClicked += new EventHandler(View_NovoClicked);
			View.TiposClicked += new EventHandler(View_TiposClicked);
			View.PagarClicked += new EventHandler(View_PagarClicked);
			View.CancelarClicked += new EventHandler(View_CancelarClicked);

			Initialize();
		}

		#endregion Constructors

		#region Methods

		public void SetDespesa(Despesa despesa)
		{
			Model.Indice = despesa.Indice;
			Model.Tipo = despesa.Tipo;
			Model.Fornecedor = despesa.Fornecedor;
			Model.Vencimento = despesa.Vencimento;
			Model.Valor = despesa.Valor;
			Model.ValorPago = despesa.ValorPago;
			Model.Documento = despesa.Documento;
			Model.Observacao = despesa.Observacao;
			Model.Situacao = despesa.Situacao;
			Model.Pagamento = despesa.Pagamento;
			Model.Data = despesa.Data;
		}

		public void SetDocumento(string documento)
		{
			Model.Documento = documento;
		}

		public string SetFornecedor(long fornecedor)
		{
			string nome = "";

			if ((nome = _dsoftBd.FornecedorNome(fornecedor)) != "")
			{
				Model.Fornecedor = fornecedor;
			}

			return nome;
		}

		public void SetObservacao(string observacao)
		{
			Model.Observacao = observacao;
		}

		public void SetTipo(int tipo)
		{
			Model.Tipo = tipo;
		}

		public void SetValor(decimal valor)
		{
			Model.Valor = valor;
		}

		public void SetVencimento(DateTime vencimento)
		{
			Model.Vencimento = vencimento;
		}

		private void Initialize()
		{
			LoadTipos();
			RefreshView();
		}

		private void LoadTipos()
		{
			_dsoftBd.CarregarDespesasTiposAsync().ContinueWith((task) =>
				{
					if (task.IsFaulted || task.Result == null || Finished)
						return;

					List<string> tipos = new List<string>();

					foreach (DataRow r in task.Result.Tables[0].Rows)
					{
						tipos.Add(r["codigo"].ToString() + " - " + r["nome"].ToString());
					}

					View.SetTypes(tipos.ToArray());
				});
		}

		private void RefreshView()
		{
			_dsoftBd.CarregarDespesasAsync().ContinueWith((task) =>
				{
					if (task.IsFaulted || task.Result == null || Finished)
						return;

					View.SetDataSource(task.Result);
				});
		}

		void View_CancelarClicked(object sender, EventArgs e)
		{
			Button button = sender as Button;

			if (!button.Enabled)
				return;

			if (Model.isCanceled)
			{
				if (_dsoftBd.ReativarDespesa(Model.Indice, _usuario.Autorizado))
				{
					View.ClearFields();
					RefreshView();
				}
			}
			else
			{
				if (_dsoftBd.CancelarDespesa(Model.Indice, _usuario.Autorizado))
				{
					View.ClearFields();
					RefreshView();
				}
			}
		}

		void View_NovoClicked(object sender, EventArgs e)
		{
			Button button = sender as Button;

			if (button.Enabled && button.Text == "&Nova - F2")
			{
				View.PrepareNew();

				return;
			}

			if (Model.isValid)
			{
				if (Model.isNew)
				{
					if (_dsoftBd.NovaDespesa(Model.Despesa, _usuario.Autorizado) > 0)
					{
						View.ClearFields();
						RefreshView();
					}
				}
				else
				{
					if (_dsoftBd.AlterarDespesa(Model.Despesa, _usuario.Autorizado))
					{
						View.ClearFields();
						RefreshView();
					}
				}
			}
			else
			{
				MessageBox.Show("Dados incompletos!", View.Titulo(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		void View_PagarClicked(object sender, EventArgs e)
		{
			Button button = sender as Button;

			if (!button.Enabled)
				return;

			if (Model.isPaid)
			{
				if (_dsoftBd.DesfazerDespesa(Model.Indice, _usuario.Autorizado))
				{
					View.ClearFields();
					RefreshView();
				}
			}
			else
			{
				if (_dsoftBd.PagarDespesa(Model.Indice, _usuario.Autorizado, Caixa.Numero))
				{
					View.ClearFields();
					RefreshView();
				}
			}
		}

		void View_SairClicked(object sender, EventArgs e)
		{
			Finished = true; ;
		}

		void View_TiposClicked(object sender, EventArgs e)
		{
			frmCadDespesasTipos form = new frmCadDespesasTipos(_dsoftBd, _usuario);

			form.ShowDialog();

			LoadTipos();
		}

		#endregion Methods
	}
}