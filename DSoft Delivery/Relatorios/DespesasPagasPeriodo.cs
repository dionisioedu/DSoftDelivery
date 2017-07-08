using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	class DespesasPagasPeriodo
	{
		#region Fields

		private static string Arquivo = "DespesasPagasPeriodo.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(DateTime inicial, DateTime final, DataTable dt)
		{
			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			string html = "<html encoding=\"utf8\"><head><title>";
			html += Preferencias.Titulo;
			html += "</title></head>";
			html += "<body>";

			html += "<table style=\"font-family: arial; width: 100%;\"><tr>";
			html += "<td rowspan=\"2\" width=\"30 px\"><img alt=\"Logo\" src=\"logo.png\" /></td>";
			html += "<td style=\"font-size: x-large;\">Despesas pagas por período</td></tr>";
			html += "<tr><td><b>Período de " + inicial.ToShortDateString() + " até " + final.ToShortDateString() + "</b></td></tr>";
			html += "</table>";

			html += "<table style=\"width: 100 px; font-family: arial; font-size: normal;\">";
			html += "<tr><th>Índice</th><th>Data</th><th>Vencimento</th><th><b>Pagamento</b></th><th>Tipo</th><th>Valor (R$)</th><th>Pago (R$)</th><th>Documento</th><th>Observação</th></tr>";
			html += "<tr><td colspan=\"9\"><hr/></td></tr>";

			decimal total = 0;
			decimal pago = 0;
			bool zebra = true;

			foreach (DataRow r in dt.Rows)
			{
				if (zebra)
					html += "<tr>";
				else
					html += "<tr style=\"background-color:silver\">";

				zebra = !zebra;

				html += "<td align=\"right\">" + r["indice"].ToString() + "</td>";
				html += "<td>" + Convert.ToDateTime(r["data"]).ToShortDateString() + "</td>";
				html += "<td>" + Convert.ToDateTime(r["vencimento"]).ToShortDateString() + "</td>";
				html += "<td>" + Convert.ToDateTime(r["pagamento"]).ToShortDateString() + "</td>";
				html += "<td>" + r["nome"].ToString() + "</td>";
				html += "<td align=\"right\">" + Convert.ToDecimal(r["valor"]).ToString("##,###,##0.00") + "</td>";
				html += "<td align=\"right\"><b>" + Convert.ToDecimal(r["valor_pago"]).ToString("##,###,##0.00") + "</b></td>";
				html += "<td>" + r["documento"].ToString() + "</td>";
				html += "<td>" + r["observacao"].ToString() + "</td>";
				html += "</tr>";

				total += Convert.ToDecimal(r["valor"]);
				pago += Convert.ToDecimal(r["valor_pago"]);
			}

			html += "<tr><td colspan=\"9\"><hr/></td></tr>";
			html += "<tr><td colspan=\"5\">Quantidade de registros: " + dt.Rows.Count.ToString() + "</td>";
			html += "<td align=\"right\" style=\"background-color:silver\"><b>" + total.ToString("##,###,##0.00") + "</b></td>";
			html += "<td align=\"right\" style=\"background-color:silver\"><b>" + pago.ToString("##,###,##0.00") + "</b></td>";
			html += "<td colspan=\"2\"></td></tr>";
			html += "</table>";

			html += "</body></html>";
			streamWriter.Write(html);
			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
		}

		#endregion Methods
	}
}