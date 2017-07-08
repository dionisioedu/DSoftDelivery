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
	class FechamentoDiario
	{
		#region Fields

		public static string Arquivo = "FechamentoDiario.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(Fechamento fechamento, int pedidos_volume, int pedidos_itens, decimal pedidos_total, DataTable caixas, DataTable entradas)
		{
			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			string html = "<html><head><title>";
			html += Preferencias.Titulo;
			html += "</title></head><body>";

			html += "<table style=\"font-family: arial; width: 100%; \">";
			html += "<tr><td rowspan=\"2\" width=\"30 px\"><img alt=\"Logo\" src=\"logo.png\" /></td>";
			html += "<td style=\"font-size: x-large;\">Fechamento diário</td></tr>";
			html += "<tr><td>Número: <b>" + fechamento.Indice + "</b>     Data: <b>" +
				fechamento.Data.ToShortDateString() + "</b>     Emissão: <b>" + DateTime.Now.ToShortDateString() + "</b></td></tr>";
			html += "<tr><td colspan=\"2\"><hr/></td></tr>";
			html += "<tr><td colspan=\"2\">";

			html += "<table style=\"font-family: arial; width: 100%; \">";
			html += "<tr><td colspan=\"3\" style=\"font-size: large; \">Pedidos</td></tr>";
			html += "<tr align=\"center\"><td><i>Volume</i></td><td><i>Itens</i></td><td><i>Total</i></td></tr>";
			html += "<tr align=\"center\"><td>" + pedidos_volume.ToString() + "</td><td>" + pedidos_itens + "</td><td bgcolor=\"silver\"><b>" + pedidos_total.ToString("##,###,##0.00") + "</b></td></tr>";
			html += "</table>";

			html += "</td></tr>";
			html += "<tr><td colspan=\"2\"><hr/></td></tr>";
			html += "<tr><td colspan=\"2\">";

			html += "<table style=\"font-family: arial; width: 100%; \">";
			html += "<tr><td colspan=\"6\" style=\"font-size: large; \">Caixas</td></tr>";
			html += "<tr align=\"right\"><td><i>Caixa</i></td><td bgcolor=\"silver\"><i>Entrada</i></td><td><i>Saída</i></td><td><i>Pagamento</i></td><td><i>Transferência</i></td><td><i>Vale</i></td></tr>";

			decimal entrada, saida, pagamento, transferencia, vale;
			decimal total_entrada = 0;
			decimal total_saida = 0;
			decimal total_pagamento = 0;
			decimal total_transferencia = 0;
			decimal total_vale = 0;

			foreach (DataRow r in caixas.Rows)
			{
				entrada = (r["entrada"].ToString() == "") ? 0 : Convert.ToDecimal(r["entrada"]);
				saida = (r["saida"].ToString() == "") ? 0 : Convert.ToDecimal(r["saida"]);
				pagamento = (r["pagamento"].ToString() == "") ? 0 : Convert.ToDecimal(r["pagamento"]);
				transferencia = (r["transferencia"].ToString() == "") ? 0 : Convert.ToDecimal(r["transferencia"]);
				vale = (r["vale"].ToString() == "") ? 0 : Convert.ToDecimal(r["vale"]);

				html += "<tr align=\"right\"><td>" + r["descricao"].ToString() + "</td>";
				html += "<td bgcolor=\"silver\" style=\"width: 15%;\">" + entrada.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 15%;\">" + saida.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 15%;\">" + pagamento.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 15%;\">" + transferencia.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 15%;\">" + vale.ToString("##,###,##0.00") + "</td></tr>";

				total_entrada += entrada;
				total_saida += saida;
				total_pagamento += pagamento;
				total_transferencia += transferencia;
				total_vale += vale;
			}

			html += "<tr align=\"right\"><td><b>Total</b></td>";
			html += "<td bgcolor=\"silver\"><b>" + total_entrada.ToString("##,###,##0.00") + "</b></td>";
			html += "<td><b>" + total_saida.ToString("##,###,##0.00") + "</b></td>";
			html += "<td><b>" + total_pagamento.ToString("##,###,##0.00") + "</b></td>";
			html += "<td><b>" + total_transferencia.ToString("##,###,##0.00") + "</b></td>";
			html += "<td><b>" + total_vale.ToString("##,###,##0.00") + "</b></td></tr>";
			html += "</table>";

			html += "</td></tr>";
			html += "<tr><td colspan=\"2\"><hr/></td></tr>";
			html += "<tr><td colspan=\"2\">";

			html += "<table style=\"font-family: arial; width: 100%; \">";
			html += "<tr><td colspan=\"7\" style=\"font-size: large; \">Entradas</td></tr>";
			html += "<tr align=\"right\"><td><i>Caixa</i></td><td bgcolor=\"silver\" style=\"width: 15%;\"><i>Dinheiro</i></td><td style=\"width: 15%;\"><i>Cartão</i></td><td style=\"width: 15%;\"><i>Visa</i></td><td style=\"width: 15%;\"><i>Master</i></td><td style=\"width: 15%;\"><i>Cheque</i></td><td><i>Débito</i></td></tr>";

			decimal dinheiro, cartao, visa, master, cheque, debito;

			foreach (DataRow r in entradas.Rows)
			{
				dinheiro = (r["dinheiro"].ToString() == "") ? 0 : Convert.ToDecimal(r["dinheiro"]);
				cartao = (r["cartao"].ToString() == "") ? 0 : Convert.ToDecimal(r["cartao"]);
				visa = (r["visa"].ToString() == "") ? 0 : Convert.ToDecimal(r["visa"]);
				master = (r["master"].ToString() == "") ? 0 : Convert.ToDecimal(r["master"]);
				cheque = (r["cheque"].ToString() == "") ? 0 : Convert.ToDecimal(r["cheque"]);
				debito = (r["debito"].ToString() == "") ? 0 : Convert.ToDecimal(r["debito"]);

				html += "<tr align=\"right\"><td>" + r["descricao"].ToString() + "</td>";
				html += "<td bgcolor=\"silver\" style=\"width: 10%;\">" + dinheiro.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 10%;\">" + cartao.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 10%;\">" + visa.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 10%;\">" + master.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 10%;\">" + cheque.ToString("##,###,##0.00") + "</td>";
				html += "<td style=\"width: 10%;\">" + debito.ToString("##,###,##0.00") + "</td></tr>";
			}

			html += "</table>";

			html += "</td></tr>";
			html += "<tr><td colspan=\"2\"><hr/></td></tr>";
			html += "<tr><td colspan=\"2\" align=\"right\" bgcolor=\"silver\">";
			html += "Diferença\tR$ <b>" + (-(pedidos_total - total_entrada)).ToString("##,###,##0.00") + "</b>";
			html += "</td></tr>";
			html += "</table>";

			html += "</body></html>";

			streamWriter.Write(html);
			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
		}

		#endregion Methods
	}
}