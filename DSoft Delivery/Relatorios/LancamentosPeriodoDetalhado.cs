using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	class LancamentosPeriodoDetalhado
	{
		#region Fields

		public static string Arquivo = "LancamentosPeriodoDetalhado.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(DateTime inicial, DateTime final, string[] lancamentos, string[] formas, DataTable dt)
		{
			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			streamWriter.Write("<html encoding=\"utf8\"><head><title>");
			streamWriter.Write("DSoft Delivery v1.2");
			streamWriter.Write("</title><head>");
			streamWriter.Write("<table style=\"font-family: arial; width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
			streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Lançamentos por Período Detalhado</p></td></tr>");

			string auxiliar = "Tipos de lançamentos <b>";

			for (int i = 0; i < lancamentos.Length; i++)
			{
				if (i > 0)
					auxiliar += ", ";

				auxiliar += lancamentos[i];
			}

			auxiliar += "</b>   e Formas de pagamento <b>";

			for (int i = 0; i < formas.Length; i++)
			{
				if (i > 0)
					auxiliar += ", ";

				auxiliar += formas[i];
			}

			auxiliar += "</b>";

			streamWriter.Write("<tr><td colspan=\"2\" align=\"left\">" + auxiliar + "</td></tr>");
			streamWriter.Write("<tr><td colspan=\"2\">Período de <b>" + inicial.ToString("dd/MM/yy") + "</b> até <b>" + final.ToString("dd/MM/yy") + "</b></td><td>Emitido em&nbsp;&nbsp;<b>" + DateTime.Now.ToString("dd/MM/yy") + "</b></td></tr></table>");
			streamWriter.Write("<hr/>");
			streamWriter.Write("</head>");
			streamWriter.Write("<body>");
			streamWriter.Write("<table style=\"font-family: arial; \"><tr><th>Índice</th><th>Data</th><th>Hora</th><th>Tipo</th><th>Cliente</th><th>Nome</th><th>Forma</th><th>Valor (R$)</th><th>Sit.</th><th>Pedido</th></tr>");
			streamWriter.Write("<tr><td colspan=\"10\"><hr/></td></tr>");

			bool zebra = true;
			decimal entradas = 0;
			decimal pagamentos = 0;
			decimal saidas = 0;
			decimal tranferencias = 0;
			decimal vales = 0;

			foreach (DataRow r in dt.Rows)
			{
				bool cancelado = false;

				if (r["situacao"].ToString() == "C")
				{
					cancelado = true;
					streamWriter.Write("<tr style=\"background-color:red; color:white; \">");
				}
				else if (zebra)
					streamWriter.Write("<tr>");
				else
					streamWriter.Write("<tr style=\"background-color:silver\">");

				zebra = !zebra;

				streamWriter.Write("<td align=\"right\">" + r["indice"] + "</td>");
				streamWriter.Write("<td>" + Convert.ToDateTime(r["data"]).ToShortDateString() + "</td>");
				streamWriter.Write("<td>" + Convert.ToDateTime(r["hora"]).ToShortTimeString() + "</td>");
				streamWriter.Write("<td>" + r["tipo"] + "</td>");
				streamWriter.Write("<td align=\"right\">" + r["cliente"] + "</td>");
				streamWriter.Write("<td>" + r["nome"] + "</td>");
				streamWriter.Write("<td>" + r["forma"] + "</td>");
				streamWriter.Write("<td align=\"right\">" + Convert.ToDecimal(r["valor"]).ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<td>" + r["situacao"] + "</td>");
				streamWriter.Write("<td align=\"right\">" + r["pedido"] + "</td>");
				streamWriter.Write("</tr>");

				if (!cancelado)
				{
					if (r["tipo"].ToString() == "E")
					{
						entradas += Convert.ToDecimal(r["valor"]);
					}
					else if (r["tipo"].ToString() == "P")
					{
						pagamentos += Convert.ToDecimal(r["valor"]);
					}
					else if (r["tipo"].ToString() == "S")
					{
						saidas += Convert.ToDecimal(r["valor"]);
					}
					else if (r["tipo"].ToString() == "T")
					{
						tranferencias += Convert.ToDecimal(r["valor"]);
					}
					else if (r["tipo"].ToString() == "V")
					{
						vales += Convert.ToDecimal(r["valor"]);
					}
				}
			}

			streamWriter.Write("<tr><td colspan=\"10\"><hr/></td></tr>");

			streamWriter.Write("<tr><td align=\"right\" colspan=\"5\"></td>");
			streamWriter.Write("<td colspan=\"3\" align=\"right\">");

			streamWriter.Write("Total de Entradas <b>R$ " + entradas.ToString("##,###,##0.00") + "</b><br/>");
			streamWriter.Write("Total de Pagamentos <b>R$ " + pagamentos.ToString("##,###,##0.00") + "</b><br/>");
			streamWriter.Write("Total de Saídas <b>R$ " + saidas.ToString("##,###,##0.00") + "</b><br/>");
			streamWriter.Write("Total de Transferências <b>R$ " + tranferencias.ToString("##,###,##0.00") + "</b><br/>");
			streamWriter.Write("Total de Vales <b>R$ " + vales.ToString("##,###,##0.00") + "</b><br/>");

			streamWriter.Write("</td><td colspan=\"2\"></td></tr>");

			streamWriter.Write("</table>");
			streamWriter.Write("</body></html>");
			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
		}

		#endregion Methods
	}
}