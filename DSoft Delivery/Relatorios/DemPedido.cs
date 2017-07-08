using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DSoftBd;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	public class DemPedido
	{
		#region Fields

		private string FILE_EXT = ".htm";
		private string FILE_NAME = "Pedido_";

		#endregion Fields

		#region Methods

		public void Gerar(Bd bd, Pedido pedido, int vias = 1)
		{
			if (pedido == null)
			{
				return;
			}

			string arquivo = FILE_NAME + pedido.Numero.ToString() + FILE_EXT;

			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			string endereco = "";
			string bairro = "";

			bd.ClienteEndereco(pedido.Cliente, out endereco, out bairro);

			for (int i = 0; i < vias; i++)
			{
				streamWriter.Write("<html encoding=\"utf-8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");

				streamWriter.Write("<table style=\"width:100%; border:1px solid black; font-size:xx-small; border-collapse:collapse;\">");

				// Cabeçalho
				streamWriter.Write("<tr><td colspan=\"2\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td align=\"center\" style=\"font-size: normal; border: 1px solid black;\">PEDIDO</td>");
				streamWriter.Write("<td align=\"right\" style=\"font-size: normal;\">" + pedido.Data.ToString("dd/MM/yyyy") + "<br/>");
				streamWriter.Write("Número: " + pedido.Numero.ToString() + "</td>");
				streamWriter.Write("</tr>");

				// Cliente
				streamWriter.Write("<tr style=\"border: 1px solid black;\">");
				streamWriter.Write("<td colspan=\"4\">");
				streamWriter.Write("<table width=\"100%\" style=\"font-size: xx-small;\"><tr><td colspan=\"2\" width=\"70%\">CLIENTE: " + bd.ClienteNome(pedido.Cliente) + "</td><td width=\"30%\">CPF/CNPJ: " + bd.ClienteDocumento(pedido.Cliente) + "</td></tr>");
				streamWriter.Write("<tr><td width=\"50%\">ENDEREÇO: " + endereco + " - " + bairro + "</td>");
				streamWriter.Write("<td width=\"25%\">CIDADE: " + bd.ClienteCidade(pedido.Cliente) + "</td><td width=\"25%\">INSC: " + bd.ClienteIE(pedido.Cliente) + "</td></tr></table></td>");
				streamWriter.Write("</tr>");

				// Pedido
				streamWriter.Write("<tr><td colspan=\"4\"><h3>Itens</b></h3></tr>");

				streamWriter.Write("</table>");
			}

			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + arquivo);
		}

		#endregion Methods
	}
}