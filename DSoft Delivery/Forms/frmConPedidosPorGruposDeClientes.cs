using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftModels;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;

namespace DSoft_Delivery.Forms
{
	public partial class frmConPedidosPorGruposDeClientes : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;

		private List<ClienteGrupo> _grupos;
		private List<DateTime> _dias;

		private Dictionary<ClienteGrupo, Dictionary<DateTime, int>> _gruposSeries;
		private Dictionary<ClienteGrupo, int> _gruposPedidos;

		private bool _avoidRefresh = false;

		public frmConPedidosPorGruposDeClientes(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;

			quitButton1.Click += btSair_Click;
			refreshButton1.Click += btConfirmar_Click;
		}

		private void frmConPedidosPorGruposDeClientes_Load(object sender, EventArgs e)
		{
			dtInicial.Value = dtFinal.Value.AddMonths(-1);
		}

		private void Confirmar()
		{
			pnLoading.Visible = true;

			Task.Factory.StartNew(() =>
			{
				// Primeiro carregamos todos os grupos que vamos pesquisar
				_grupos = _dsoftBd.CarregarClientesGrupos();

				this.Invoke(new Action(() =>
				{
					pbLoading.Maximum = _grupos.Count + 5;
					pbLoading.Value = 5;
				}));

				// Descobrimos quantos dias vamos pesquisar
				_dias = new List<DateTime>();

				DateTime cursor = dtInicial.Value;

				while (cursor <= dtFinal.Value)
				{
					_dias.Add(cursor);
					cursor = cursor.AddDays(1);
				}

				_gruposPedidos = new Dictionary<ClienteGrupo, int>();
				_gruposSeries = new Dictionary<ClienteGrupo, Dictionary<DateTime, int>>();

				foreach (ClienteGrupo grupo in _grupos)
				{
					if (_gruposSeries.ContainsKey(grupo) == false)
					{
						_gruposSeries.Add(grupo, new Dictionary<DateTime, int>());
						_gruposPedidos.Add(grupo, 0);
					}

					foreach (DateTime dia in _dias)
					{
						int pedidos = _dsoftBd.PedidosPorGruposDeClientes(grupo, dia);

						_gruposSeries[grupo].Add(dia, pedidos);
						_gruposPedidos[grupo] += pedidos;
					}

					this.Invoke(new Action(() =>
					{
						pbLoading.Value++;
					}));
				}

				this.Invoke(new Action(() =>
				{
					_avoidRefresh = true;
					nmQuantidade.Value = _gruposSeries.Count;
					_avoidRefresh = false;

					CarregarGrafico();
				}));
			});
		}

		private void CarregarGrafico(int quantidade = 0)
		{
			int i = 0;

			if (quantidade == 0)
				quantidade = _gruposSeries.Count;

			chPedidos.Series.Clear();

			// Cada grupo vai formar uma série no gráfico
			foreach (var grupo in _gruposPedidos.OrderByDescending(o => o.Value))
			{
				if (chPedidos.Series.FindByName(grupo.Key.Nome) == null)
				{
					Series serie = chPedidos.Series.Add(grupo.Key.Nome);
					serie.ChartType = SeriesChartType.Line;
					serie.BorderWidth = 4;

					foreach (DateTime dia in _dias)
					{
						serie.Points.AddXY(dia.ToShortDateString(), _gruposSeries[grupo.Key][dia]);
					}
				}

				if (++i >= quantidade)
					break;
			}

			chPedidos.Invalidate();

			pnLoading.Visible = false;
		}

		private void Sair()
		{
			this.Close();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void btConfirmar_Click(object sender, EventArgs e)
		{
			Confirmar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void nmQuantidade_ValueChanged(object sender, EventArgs e)
		{
			if (!_avoidRefresh)
			{
				CarregarGrafico((int)nmQuantidade.Value);
			}
		}
	}
}
