using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DSoftBd;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	class ReciboEscolar
	{
		#region Fields

		public static string Arquivo = "Recibo.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(Bd bd, long codigo, string nome, decimal valor, DateTime data)
		{
			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			string html = "<html><head><title>";
			html += "DSoft Delivery v1.2";
			html += "</title><head>";
			html += "</head>";
			html += "<body>";
			html += "<table style=\"font-family: arial; width:100%; border:1px;\"><tr><td rowspan=\"3\" style=\"vertical-align: top; \"><img alt=\"Logo\" src=\"logo.png\" /></td>";
			html += "<td><p style=\"font-size:x-Large\">Recibo de Pagamento</p><br/></td></tr>";
			html += "<tr><td align=\"left\">Declaramos ter recebido do responsável pelo aluno <b><u>" + nome + "</u></b>";
			html += ", <b>" + bd.GrupoClienteNome(bd.ClienteGrupo(codigo)) + "</b>, ";
			html += " matriculado com número <b> " + codigo.ToString() + "</b>";
			html += " o valor de <b>R$ " + valor.ToString("##,###,##0.00") + "</b> referente aos produtos consumidos na cantina da escola.<br/><br/><br/><br/>";
			html += "Data do pagamento <b>" + data.ToShortDateString() + "</b><br/><br/><br/> </td></tr>";
			html += "<tr><td align=\"center\">Visto:<br/></td></tr>";
			html += "<tr><td colspan=\"2\"><br/><hr/><br/></td></tr></table>";
			html += "<br/><br/><br/>";
			html += "<table style=\"font-family: arial; width:100%; border:1px;\"><tr><td rowspan=\"3\" style=\"vertical-align: top; \"><img alt=\"Logo\" src=\"logo.png\" /></td>";
			html += "<td><p style=\"font-size:x-Large\">Recibo de Pagamento</p><br/></td></tr>";
			html += "<tr><td align=\"left\">Declaramos ter recebido do responsável pelo aluno <b><u>" + nome + "</u></b>";
			html += ", <b>" + bd.GrupoClienteNome(bd.ClienteGrupo(codigo)) + "</b>, ";
			html += " matriculado com número <b> " + codigo.ToString() + "</b>";
			html += " o valor de <b>R$ " + valor.ToString("##,###,##0.00") + "</b> referente aos produtos consumidos na cantina da escola.<br/><br/><br/><br/>";
			html += "Data do pagamento <b>" + data.ToShortDateString() + "</b><br/><br/><br/> </td></tr>";
			html += "<tr><td align=\"center\">Visto:<br/></td></tr>";
			html += "<tr><td colspan=\"2\"><br/><hr/><br/></td></tr></table>";
			html += "</body></html>";

			streamWriter.Write(html);
			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
		}

		#endregion Methods
	}
}