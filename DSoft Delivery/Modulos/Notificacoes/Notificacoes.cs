using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSoft_Delivery.Forms;
using DSoftParameters;
using System.Threading;

namespace DSoft_Delivery.Modulos.Notificacoes
{
	public class Notificacoes
	{
		IMain _main;

		public Notificacoes(IMain main)
		{
			_main = main;
		}

		public void Verificar()
		{
			_main.LimparNotificacoes();

			if (!VerificarImpressoraCupom())
			{
				return;
			}
		}

		private bool VerificarImpressoraCupom()
		{
			if (Terminal.Impressora() == string.Empty)
			{
				_main.MostrarNotificacao("Identificamos que a impressora de cupons ainda não foi configurada. Gostaria de selecionar uma impressora agora?", new EventHandler(AbrirTerminal));

				return false;
			}
			else
			{
				return true;
			}
		}

		private void AbrirTerminal(object sender, EventArgs e)
		{
			_main.AbrirTerminal();

			Verificar();
		}
	}
}
