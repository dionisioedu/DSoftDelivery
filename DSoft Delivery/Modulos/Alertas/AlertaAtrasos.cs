using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSoft_Delivery.Forms;
using System.Timers;
using DSoftBd;
using DSoftParameters;
using DSoftModels;

namespace DSoft_Delivery.Modulos.Alertas
{
	public class AlertaAtrasos
	{
		private IMain _form;
		private Bd _bd;
		private Timer _timer;

		public AlertaAtrasos(IMain main, Bd bd)
		{
			_form = main;
			_bd = bd;

			_timer = new Timer(60 * 1000);
			_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
			_timer.Start();
		}

		private void _timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			List<Pedido> entregas_atrasadas = _bd.EntregasAtrasadas(RegrasDeNegocio.Instance.AvisoAtraso);

			if (entregas_atrasadas != null && entregas_atrasadas.Count > 0)
			{
				_form.ShowAlert(string.Format("Existem {0} entregas atrasadas!", entregas_atrasadas.Count));
			}
		}
	}
}
