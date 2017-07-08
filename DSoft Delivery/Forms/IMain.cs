using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoft_Delivery.Forms
{
	public interface IMain
	{
		void ShowAlert(string message);
		void MostrarNotificacao(string mensagem, EventHandler funcao);
		void LimparNotificacoes();
		void AbrirTerminal();
	}
}
