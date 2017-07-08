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
using DSoftParameters;

namespace DSoft_Delivery.Forms
{
	public partial class frmRota : Form
	{
		private Bd _dsoftBd;
		private Usuario _usuario;
		private Cliente _cliente;

		public frmRota(Bd bd, Usuario usuario, Cliente cliente)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
			_cliente = cliente;
		}

		private void frmRota_Load(object sender, EventArgs e)
		{
			if (_cliente != null)
			{
				List<Emitente> emitentes = _dsoftBd.CarregarEmitentes();

				if (emitentes != null && emitentes.Count > 0)
				{
					CarregarMapa(emitentes[0]);
				}
			}
		}

		private void CarregarMapa(Emitente emitente)
		{
			if (Terminal.MapasOnline && emitente != null)
			{
				string origem = "";
				string destino;
				string estado;

				origem = string.Format("{0}, {1} - {2} - {3} - {4}", emitente.Logradouro, emitente.Numero, emitente.Bairro, emitente.Municipio, emitente.Uf.Substring(0, 2));

				if (_cliente.Estado.Length > 2)
				{
					estado = _cliente.Estado.Substring(0, 2);
				}
				else
				{
					estado = _cliente.Estado;
				}

				destino = string.Format("{0}, {1} - {2} - {3} - {4}", _cliente.Endereco, _cliente.Numero, _cliente.Bairro, _cliente.Cidade, estado);

				string mapa = "<!DOCTYPE html>" +
										"<html> " +
										"<head> " +
										"   <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\"/> " +
										"   <title>Google Maps API v3 Directions Example</title> " +
										"   <script type=\"text/javascript\" " +
										"           src=\"http://maps.google.com/maps/api/js?sensor=false\"></script>" +
										"</head> " +
										"<body style=\"font-family: Arial; font-size: 12px;\"> " +
										"   <div style=\"width: 850px;\">" +
										"     <div id=\"map\" style=\"width: 380px; height: 420px; float: left;\"></div> " +
										"     <div id=\"panel\" style=\"width: 380px; float: right;\"></div> " +
										"   </div>" +
										"   <script type=\"text/javascript\"> " +
										"     var directionsService = new google.maps.DirectionsService();" +
										"     var directionsDisplay = new google.maps.DirectionsRenderer();" +
										"     var map = new google.maps.Map(document.getElementById('map'), {" +
										"       zoom:7," +
										"       mapTypeId: google.maps.MapTypeId.ROADMAP" +
										"     });" +
										"     directionsDisplay.setMap(map);" +
										"     directionsDisplay.setPanel(document.getElementById('panel'));" +
										"     var request = {" +
										"       origin: '" + origem + "', " +
										"       destination: '" + destino + "'," +
										"       travelMode: google.maps.DirectionsTravelMode.DRIVING" +
										"     };" +
										"     directionsService.route(request, function(response, status) {" +
										"       if (status == google.maps.DirectionsStatus.OK) {" +
										"         directionsDisplay.setDirections(response);" +
										"       }" +
										"     });" +
										"   </script> " +
										"</body> " +
										"</html>";

				try
				{
					webBrowser1.Navigate("about:blank");

					if (webBrowser1.Document != null)
					{
						webBrowser1.Document.Write(string.Empty);
					}

					webBrowser1.DocumentText = mapa;
				}
				catch (Exception e)
				{
					DSoftLogger.Logger.Instance.Error(e);
				}
			}
		}

		private void frmRota_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F10)
			{
				this.Close();
			}
		}
	}
}
