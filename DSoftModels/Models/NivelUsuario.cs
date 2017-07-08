using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class NivelUsuario
	{
		#region Properties

		public bool Administrador
		{
			get;
			set;
		}

		public bool AlterarEstoque
		{
			get;
			set;
		}

		public bool AlterarPedidos
		{
			get;
			set;
		}

		public bool AlterarClienteDoPedido
		{
			get;
			set;
		}

		public bool AlterarPrecos
		{
			get;
			set;
		}

		public bool CadastrarGruposDeClientes
		{
			get;
			set;
		}

		public bool CadastrarProdutos
		{
			get;
			set;
		}

		public bool CadastrarRecursos
		{
			get;
			set;
		}

		public bool CadastrarUsuarios
		{
			get;
			set;
		}

		public bool Caixa
		{
			get;
			set;
		}

		public bool CancelarPedidos
		{
			get;
			set;
		}

		public bool Compras
		{
			get;
			set;
		}

		public bool ControleFinanceiro
		{
			get;
			set;
		}

		public bool Entregas
		{
			get;
			set;
		}

		public bool LancarPedidos
		{
			get;
			set;
		}

		public string Nivel
		{
			get;
			set;
		}

		public string Nome
		{
			get;
			set;
		}

		public bool Preferencias
		{
			get;
			set;
		}

		public bool RegrasDeNegocio
		{
			get;
			set;
		}

		public bool Relatorios
		{
			get;
			set;
		}

		public bool ScriptBd
		{
			get;
			set;
		}

		public bool Terminal
		{
			get;
			set;
		}

		public bool Escritorio
		{
			get;
			set;
		}

		public bool Almoxarifado
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods

		public override string ToString()
		{
			return string.Format("{0} - {1}", this.Nivel, this.Nome);
		}

		#endregion Methods
	}
}