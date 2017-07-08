using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	class ExtratoFinanceiroPeriodo
	{
		#region Fields

		public static string Arquivo = "ExtratoFinanceiro.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(Cliente cliente, DateTime inicio, DateTime fim, ref DataSet dados)
		{
			try
			{
				string data = string.Empty;
				double entrada = 0;
				double debitos = 0;
				double gastos = 0;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Extrato Financeiro</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b>" + cliente.Nome + "</b></td><td>" + cliente.GrupoDescricao + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " até " + fim.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table>");
				streamWriter.Write("<tr><td>Data</td><td>Observação</td><td>Forma</td><td>Valor (R$)</td><td>Tipo</td></tr><tr><td colspan=\"5\"><hr/></td></tr>");

				// Fluxo de Caixa
				foreach (DataRow d in dados.Tables[0].Rows)
				{
					bool debito;

					if (d.ItemArray[6].ToString() == "A")
						debito = true;
					else
						debito = false;

					streamWriter.Write("<tr>");
					streamWriter.Write("<td>" + d.ItemArray[0].ToString() + "</td>");
					streamWriter.Write("<td>" + d.ItemArray[5].ToString() + "</td>");

					switch (d.ItemArray[6].ToString())
					{
						case "A":
							streamWriter.Write("<td><i>Débito</i></td>");
							break;

						case "C":
							streamWriter.Write("<td><i>Cartão</i></td>");
							break;

						case "D":
							streamWriter.Write("<td><i>Dinheiro</i></td>");
							break;

						case "X":
							streamWriter.Write("<td><i>Cheque</i></td>");
							break;

						default:
							streamWriter.Write("<td><i>" + d.ItemArray[6].ToString() + "</i></td>");
							break;
					}

					streamWriter.Write("<td align=\"right\">" + d.ItemArray[2].ToString() + "</td>");

					// Caso não tenha sido o pagamento de um pedido, então é uma entrada
					if (debito)
					{
						debitos += Convert.ToDouble(d.ItemArray[2].ToString());
						streamWriter.Write("<td>-</td>");
					}
					else if (d.ItemArray[4].ToString() == "")
					{
						entrada += Convert.ToDouble(d.ItemArray[2].ToString());
						streamWriter.Write("<td>+</td>");
					}
					else if (d.ItemArray[1].ToString() == "E")
					{
						gastos += Convert.ToDouble(d.ItemArray[2].ToString());
						streamWriter.Write("<td></td>");
					}
					else
						streamWriter.Write("<td>" + d.ItemArray[1].ToString() + "</td>");

					streamWriter.Write("</tr>");
				}

				streamWriter.Write("<tr><td colspan=\"5\"><hr/></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Entradas</td><td align=\"right\">" + entrada.ToString("##,###,##0.00") + "</td><td></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Débitos</td><td align=\"right\">" + debitos.ToString("##,###,##0.00") + "</td><td></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Saldo no período</td><td align=\"right\">" + (entrada - debitos).ToString("##,###,##0.00") + "</td><td></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\"><b>Saldo Atual</b></td><td align=\"right\"><b>" + cliente.Saldo.ToString("##,###,##0.00") + "</b></td><td></td></tr>");

				streamWriter.Write("</table>");
				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		public static void Gerar(DateTime inicio, DateTime fim, DataTable dados)
		{
			try
			{
				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				string htm = "";

				htm += "<html encoding=\"utf8\"><head><title>";
				htm += Preferencias.Titulo;
				htm += "</title></head><body>";

				foreach (DataRow r in dados.Rows)
				{
					htm += "<div style=\"page-break-after:always\">";
					htm += "<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>";
					htm += "<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Extrato Financeiro</p></td></tr>";
					htm += "<tr><td colspan=\"2\" align=\"left\"><b>" + r["nome"].ToString() + "</b></td>";
					htm += "<td colspan=\"1\" align=\"right\"><b>" + r["grupo"].ToString() + "</b></td></tr>";
					htm += "<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " até " + fim.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr>";

					htm += "<tr><td colspan=\"5\"><hr/></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Entradas</td><td align=\"right\">" + Convert.ToDouble(r["entrada"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Débitos</td><td align=\"right\">" + Convert.ToDouble(r["debito"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Saldo no período</td><td align=\"right\">" + Convert.ToDouble(r["periodo"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\"><b>Saldo Atual</b></td><td align=\"right\"><b>" + Convert.ToDouble(r["saldo"]).ToString("##,###,##0.00") + "</b></td><td></td></tr></table>";

					htm += "</div>";
				}

				htm += "</body></html>";

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write(htm);
				streamWriter.Close();

				System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		#endregion Methods
	}
}