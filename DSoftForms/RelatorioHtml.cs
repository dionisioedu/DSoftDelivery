using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	class RelatorioHtml
	{
		#region Fields

		/// <summary>
		/// Nome do arquivo que será gerado
		/// </summary>
		public string Arquivo;

		/// <summary>
		/// Uma breve descrição do relatório, será impressa logo após o título
		/// </summary>
		public string Descricao;

		/// <summary>
		/// Rodapé da tabela
		/// </summary>
		public string Rodape;

		/// <summary>
		/// Titulo do relatório
		/// </summary>
		public string Titulo;

		#endregion Fields

		#region Methods

		public static bool GerarExtratoFinanceiroPeriodo(Cliente cliente, DateTime inicio, DateTime fim, ref DataSet dados)
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

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "ExtratoFinanceiro.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Extrato Financeiro</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b>" + cliente.Nome + "</b></td></tr>");
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

				System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + "ExtratoFinanceiro.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool GerarExtratoFinanceiroPeriodo(DateTime inicio, DateTime fim, DataTable dados)
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
				htm += "</title></head><body>" ;

				foreach (DataRow r in dados.Rows)
				{
					htm += "<div style=\"page-break-after:always\">";
					htm += "<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>";
					htm += "<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Extrato Financeiro</p></td></tr>";
					htm += "<tr><td colspan=\"2\" align=\"left\"><b>" + r["nome"].ToString() + "</b></td></tr>";
					htm += "<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " até " + fim.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr>";

					htm += "<tr><td colspan=\"5\"><hr/></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Entradas</td><td align=\"right\">" + Convert.ToDouble(r["entrada"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Débitos</td><td align=\"right\">" + Convert.ToDouble(r["debito"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\">Saldo no período</td><td align=\"right\">" + Convert.ToDouble(r["periodo"]).ToString("##,###,##0.00") + "</td><td></td></tr>";
					htm += "<tr><td colspan=\"3\" align=\"right\"><b>Saldo Atual</b></td><td align=\"right\"><b>" + Convert.ToDouble(r["saldo"]).ToString("##,###,##0.00") + "</b></td><td></td></tr></table>";

					htm += "</div>";
				}

				htm += "</body></html>";

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "ExtratosFinanceiros.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write(htm);
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "ExtratosFinanceiros.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool GerarExtratoPedidosItensPeriodo(Cliente cliente, DateTime inicio, DateTime fim, ref DataSet dados, double pago, double entrada)
		{
			try
			{
				string data = string.Empty;
				double soma = 0;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "Extrato.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Extrato de Pedidos</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b>" + cliente.Nome + "</b></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " até " + fim.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table>");
				streamWriter.Write("<tr><td>Data</td><td>Produto</td><td>Unitário (R$)</td><td>Quantidade</td><td>Preço (R$)</td></tr><tr><td colspan=\"5\"><hr/></td></tr>");

				// Os itens dos pedidos
				foreach (DataRow d in dados.Tables[0].Rows)
				{
					streamWriter.Write("<tr>");

					if (data != d.ItemArray[1].ToString())
					{
						streamWriter.Write("<td>" + d.ItemArray[1].ToString() + "</td>");
						data = d.ItemArray[1].ToString();
					}
					else
					{
						streamWriter.Write("<td> </td>");
					}

					streamWriter.Write("<td>" + d.ItemArray[6].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + d.ItemArray[9].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + d.ItemArray[7].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + d.ItemArray[8].ToString() + "</td>");
					streamWriter.Write("</tr>");

					soma += Convert.ToDouble(d.ItemArray[8]);
				}

				streamWriter.Write("<tr><td colspan=\"5\"><hr/></td></tr>");
				streamWriter.Write("<tr><td colspan=\"4\" align=\"right\">Total</td><td align=\"right\">" + soma.ToString("##,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"4\" align=\"right\">Pago</td><td align=\"right\">" + pago.ToString("##,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"4\" align=\"right\">Entrada</td><td align=\"right\">" + entrada.ToString("##,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"4\" align=\"right\"><b>Saldo</b></td><td align=\"right\"><b>" + cliente.Saldo.ToString("##,###,##0.00") + "</b></td></tr>");

				streamWriter.Write("</table>");
				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "Extrato.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool GerarMargemLucros(DateTime inicio, DateTime fim, int tabela_base, DataTable dados)
		{
			try
			{
				double quantidade = 0;
				double valor = 0;
				double valor2 = 0;
				double margem = 0;
				double lucro = 0;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "MargemLucros.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Margem de Lucros</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b></b></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " até " + fim.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table>");
				streamWriter.Write("<tr><td>Código</td><td>Produto</td><td>Quant.</td><td>Preço (R$)</td><td>Base (R$)</td><td>Margem (%)</td><td>Lucro (R$)</td></tr><tr><td colspan=\"7\"><hr/></td></tr>");

				// Os produtos
				foreach (DataRow d in dados.Rows)
				{
					double q, v, b, m, l;

					q = Convert.ToDouble(d.ItemArray[2].ToString());
					v = Convert.ToDouble(d.ItemArray[3].ToString());
					b = Convert.ToDouble(d.ItemArray[4].ToString());
					m = Convert.ToDouble(d.ItemArray[5].ToString());
					l = Convert.ToDouble(d.ItemArray[6].ToString());

					streamWriter.Write("<tr>");
					streamWriter.Write("<td>" + d.ItemArray[0].ToString() + "</td>");
					streamWriter.Write("<td>" + d.ItemArray[1].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + q.ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + v.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("<td align=\"right\">" + b.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("<td align=\"right\">" + m.ToString("##0.00") + "</td>");
					streamWriter.Write("<td align=\"right\">" + l.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("</tr>");

					quantidade += q;
					valor += v;
					valor2 += b;
					margem += m;
					lucro += l;
				}

				streamWriter.Write("<tr><td colspan=\"7\"><hr/></td></tr>");
				streamWriter.Write("<tr>");
				streamWriter.Write("<td></td><td></td>");
				streamWriter.Write("<td align=\"right\">" + quantidade.ToString() + "</td>");
				streamWriter.Write("<td align=\"right\">" + valor.ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<td align=\"right\">" + valor2.ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<td align=\"right\">" + (margem / dados.Rows.Count).ToString("##0.00") + "</td>");
				streamWriter.Write("<td align=\"right\"><b>" + lucro.ToString("##,###,##0.00") + "</b></td>");
				streamWriter.Write("<tr>");

				streamWriter.Write("</table>");
				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "MargemLucros.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool GerarProdutosPorPeriodo(DateTime inicio, DateTime hrinicio, DateTime fim, DateTime hrfim, ref DataSet dados)
		{
			try
			{
				double quantidade = 0;
				double valor = 0;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "ProdutosPeriodo.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write(Preferencias.Titulo);
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Produtos por Período</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b></b></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Período de " + inicio.ToString("dd/MM/yy") + " às " + hrinicio.ToString("HH:mm:ss") +
					" até " + fim.ToString("dd/MM/yy") + " às " + hrfim.ToString("HH:mm:ss") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table>");
				streamWriter.Write("<tr><td>Código</td><td>Produto</td><td>Quantidade</td><td>Valor (R$)</td></tr><tr><td colspan=\"4\"><hr/></td></tr>");

				// Os produtos
				foreach (DataRow d in dados.Tables[0].Rows)
				{
					double q, v;

					q = Convert.ToDouble(d.ItemArray[2].ToString());
					v = Convert.ToDouble(d.ItemArray[3].ToString());

					streamWriter.Write("<tr>");
					streamWriter.Write("<td>" + d.ItemArray[0].ToString() + "</td>");
					streamWriter.Write("<td>" + d.ItemArray[1].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + q.ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + v.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("</tr>");

					quantidade += q;
					valor += v;
				}

				streamWriter.Write("<tr><td colspan=\"4\"><hr/></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Produtos</td><td align=\"right\">" + dados.Tables[0].Rows.Count.ToString() + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Quantidade</td><td align=\"right\">" + quantidade.ToString() + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\" align=\"right\">Valor Total</td><td align=\"right\">" + valor.ToString("##,###,##0.00") + "</td></tr>");

				streamWriter.Write("</table>");
				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "ProdutosPeriodo.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool ListarClientesDevedores(DataTable dados, DateTime inicial, DateTime final)
		{
			try
			{
				double total = 0;
				double total_periodo = 0;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "ClientesDevedores.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td rowspan=\"3\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td colspan=\"2\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Clientes Devedores</p></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" align=\"left\"><b></b></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">De " + inicial.ToString("dd/MM/yy") + " até " + final.ToString("dd/MM/yy") + "</td><td>Emitido em&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table style=\"width: 100%\">");
				streamWriter.Write("<tr><td>Código</td><td>Nome</td><td>Grupo</td><td>Limite (R$)</td><td>Saldo (R$)</td><td>Período (R$)</td></tr><tr><td colspan=\"6\"><hr/></td></tr>");

				foreach (DataRow d in dados.Rows)
				{
					double limite = Convert.ToDouble(d.ItemArray[3].ToString());
					double saldo = Convert.ToDouble(d.ItemArray[4].ToString());
					double periodo = Convert.ToDouble(d.ItemArray[7].ToString());

					streamWriter.Write("<tr>");
					streamWriter.Write("<td>" + d.ItemArray[0].ToString() + "</td>");
					streamWriter.Write("<td>" + d.ItemArray[1].ToString() + "</td>");
					streamWriter.Write("<td>" + d.ItemArray[2].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\">" + limite.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("<td align=\"right\">" + saldo.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("<td align=\"right\">" + periodo.ToString("##,###,##0.00") + "</td>");
					streamWriter.Write("</tr>");

					total += saldo;
					total_periodo += periodo;
				}

				streamWriter.Write("<tr><td colspan=\"6\"><hr/></td></tr>");
				streamWriter.Write("<tr>");
				streamWriter.Write("<td colspan=\"2\" align=\"right\">Clientes: " + dados.Rows.Count.ToString() + "</td>");
				streamWriter.Write("<td colspan=\"2\" align=\"right\">Total R$ " + total.ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<td colspan=\"2\" align=\"right\">Período R$ " + total_periodo.ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<tr>");

				streamWriter.Write("</table>");
				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "ClientesDevedores.htm");

				return true;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return false;
			}
		}

		public void Gerar(DataSet ds)
		{
			try
			{
				if (ds == null && ds.Tables.Count == 0)
				{
					return;
				}

				DataTable dados = ds.Tables[0];

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + Arquivo + ".htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				StringBuilder html = new StringBuilder();
				html.Append("<html encoding=\"utf8\"><head><title>");
				html.Append(Preferencias.Titulo);
				html.Append("</title>");
				html.Append("<style>table.normal{font-size: normal; font-family:Arial; width: 100%;}</style>");
				html.Append("</head>");

				html.Append("<body>");

				html.Append("<table style=\"font-family: arial; width: 100%;\"><tr>");
				html.Append("<td rowspan=\"2\" width=\"30 px\"><img alt=\"Logo\" src=\"logo.png\" /></td>");
				html.Append(string.Format("<td style=\"font-size: x-large;\">{0}</td></tr>", Titulo));
				html.Append(string.Format("<tr><td><i>{0}</i></td></tr>", Descricao));
				html.Append("</table>");

				html.Append("<table class=\"normal\"");

				html.Append("<tr>");

				int i = 0;

				for (i = 0; i < dados.Columns.Count; i++)
				{
					html.Append(string.Format("<th>{0}</th>", dados.Columns[i].Caption.ToUpper()));
				}

				html.Append(string.Format("</tr><tr><td colspan=\"{0}\"><hr/></td></tr>", i));

				for (i = 0; i < dados.Rows.Count; i++)
				{
					if (dados.Rows[i].ItemArray[dados.Columns.Count - 1].ToString() == "C")
					{
						html.Append("<tr bgcolor=\"red\">");
					}
					else
					{
						if (i % 2 == 0)
						{
							html.Append("<tr bgcolor=\"white\">");
						}
						else
						{
							html.Append("<tr bgcolor=\"silver\">");
						}
					}

					for (int j = 0; j < dados.Columns.Count; j++)
					{
						html.Append(string.Format("<td>{0}</td>", dados.Rows[i].ItemArray[j].ToString()));
					}

					html.Append("</tr>");
				}

				html.Append(string.Format("</tr><tr><td colspan=\"{0}\"><hr/></td></tr>", i));

				if (Rodape != null && Rodape.Length > 0)
				{
					html.Append("<tfoot><tr style=\"background-color: black; color: white;\">");
					html.Append(string.Format("<td colspan=\"{0}\" align=\"right\"><b>{1}</b></td></tr></tfoot>", dados.Columns.Count, Rodape));
				}

				html.Append("</table></br>");

				html.Append(string.Format("<i>Registros: {0}</i></br></br>", dados.Rows.Count));

				html.Append("</body></html>");

				streamWriter.Write(html.ToString());
				streamWriter.Close();

				System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + Arquivo + ".htm");

				return;
			}
			catch (Exception e)
			{
				return;
			}
		}

		public void GerarFechamentoDia(int indice, string data, double dinheiro, double cheque, double cartao, double debito, double crediario,
			double recebimentos, double total_entrada, double total_vendas, double vendas_dia, int volume_dia, double dinheiro_dia,
			double cheque_dia, double cartao_dia, double debito_dia, double crediario_dia, double dinheiro_rec, double cheque_rec, double cartao_rec,
			double despesa, double despesa_dia, ref ProdutoGrupo[] grupos)
		{
			try
			{
				double total = dinheiro + cheque + cartao + crediario;
				double pdinheiro = 0;
				double pcheque = 0;
				double pcartao = 0;
				double pdebito = 0;
				double pcrediario = 0;
				double pdinheirodia = 0;
				double pchequedia = 0;
				double pcartaodia = 0;
				double pdebitodia = 0;
				double pcrediariodia = 0;
				double pdinheirorec = 0;
				double pchequerec = 0;
				double pcartaorec = 0;
				double totalrec = dinheiro_rec + cheque_rec + cartao_rec;
				double totaldia = dinheiro_dia + cheque_dia + cartao_dia + debito_dia;

				if (total > 0)
				{
					pdinheiro = (dinheiro * 100) / (total + recebimentos);
					pcheque = (cheque * 100) / (total + recebimentos);
					pcartao = (cartao * 100) / (total + recebimentos);
					pdebito = (debito * 100) / (total + recebimentos);
					pcrediario = (crediario * 100) / (total + recebimentos);
				}

				if (vendas_dia > 0)
				{
					pdinheirodia = (dinheiro_dia * 100) / vendas_dia;
					pchequedia = (cheque_dia * 100) / vendas_dia;
					pcartaodia = (cartao_dia * 100) / vendas_dia;
					pdebitodia = (debito_dia * 100) / vendas_dia;
					pcrediariodia = (crediario_dia * 100) / vendas_dia;
				}

				if (totalrec > 0)
				{
					pdinheirorec = (dinheiro_rec * 100) / totalrec;
					pchequerec = (cheque_rec * 100) / totalrec;
					pcartaorec = (cartao_rec * 100) / totalrec;
				}

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo + ".htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Fechamento Diário</p></td>");
				streamWriter.Write("<td align=\"right\"><p style=\"font-family:Arial; color:silver; font-size:small\"><i>" + Descricao + "</i></p></td></tr>");
				streamWriter.Write("<tr><td></td><td>Número:&nbsp;&nbsp;" + indice.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data:&nbsp;&nbsp;" + data + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Emissão:&nbsp;&nbsp;" + DateTime.Now.ToString("dd/MM/yy") + "</td><td></td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table cellspacing=\"1\" cellpadding=\"4\" style=\"width:100%; font-family:monospace; font-size:x-small;\"><tr><td>");
				streamWriter.Write("<table style=\"border: dotted 1px;\"><tr><td colspan=\"3\" align=\"center\">Caixa</td></tr>");
				streamWriter.Write("<tr><td>Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + dinheiro.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pdinheiro.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td>Cheque..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cheque.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pcheque.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td>Cartao..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cartao.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pcartao.ToString("0.00") + " %</td></tr>");

				if (RegrasDeNegocio.Instance.Ramo == "ESCOLA")
				{
					streamWriter.Write("<tr><td>Débito..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + debito.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pdebito.ToString("0.00") + " %</td></tr>");
				}
				else
				{
					streamWriter.Write("<tr><td><i>Crediário.......</i></td><td align=\"right\"><i>&nbsp;&nbsp;&nbsp;R$ " + crediario.ToString("#,###,##0.00") + "</i></td><td align=\"right\"><i>&nbsp;&nbsp;&nbsp;" + pcrediario.ToString("0.00") + " %</i></td></tr>");
				}

				streamWriter.Write("</table></td>");
				streamWriter.Write("<td><table style=\"border: dotted 1px;\"><tr><td colspan=\"2\" align=\"center\">Resumo</td></tr>");
				streamWriter.Write("<tr><td>Recebimentos......</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + recebimentos.ToString("#,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td><b>Total de Entradas.</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + total_entrada.ToString("#,###,##0.00") + "</b></td></tr>");
				streamWriter.Write("<tr><td>Total de Vendas...</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + total_vendas.ToString("#,###,##0.00") + "</td></tr>");
				//("resumos"."entrada" + "resumos"."crediario") - ("resumos"."vendas" + "resumos"."recebimentos")
				streamWriter.Write("<tr><td style=\"font-color:Red\">Diferença.........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + ((total_entrada + crediario) - (total_vendas + recebimentos)).ToString("#,###,##0.00") + "</td></tr></table>");
				streamWriter.Write("</td></tr><tr><td>");

				//Produtos
				streamWriter.Write("<table style=\"font-family:monospace; border: dotted 1px\"><tr><td colspan=\"5\" align=\"center\">Produtos</td></tr>");
				streamWriter.Write("<tr style=\"border: solid 1px;\"><td>Código</td><td>Descrição</td><td>Quant.</td><td>Valor (R$)</td><td></td></tr>");

				foreach (ProdutoGrupo g in grupos)
				{
					streamWriter.Write("<tr><td>" + g.Codigo.ToString() + "</td><td>" + g.Descricao + "</td><td align=\"center\">" + g.Quantidade.ToString() +
						"</td><td align=\"right\">R$ " + g.Valor.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + ((g.Valor * 100) / total_vendas).ToString("0.00") + " %</td></tr>");
				}

				streamWriter.Write("</table></td><td>");

				//Financeiro
				streamWriter.Write("<table style=\"font-family:monospace;\"><tr><td colspan=\"3\" align=\"center\">Financeiro</td></tr>");
				streamWriter.Write("<tr><td>Entrada.........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + total_entrada.ToString("#,###,##0.00") + "</td><td></td></tr>");
				streamWriter.Write("<tr><td>Despesas........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + despesa.ToString("#,###,##0.00") + "</td><td></td></tr>");
				streamWriter.Write("<tr><td colspan=\"3\"><hr/></td></tr>");
				streamWriter.Write("<tr><td>Saldo...........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + (total_entrada - despesa).ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + (((total_entrada - despesa) * 100) / total_entrada).ToString("0.00") + " %</td></tr></table>");

				streamWriter.Write("</td></tr><tr><td>");

				//Vendas do dia
				streamWriter.Write("<table style=\"font-family:monospace; border: solid 1px;\"><tr><td colspan=\"4\" align=\"center\">Vendas do dia</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + dinheiro_dia.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pdinheirodia.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cheque..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cheque_dia.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pchequedia.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cartão..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cartao_dia.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pcartaodia.ToString("0.00") + " %</td></tr>");

				if (RegrasDeNegocio.Instance.Ramo == "ESCOLA")
				{
					streamWriter.Write("<tr><td colspan=\"2\">Débito..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + debito_dia.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pdebitodia.ToString("0.00") + " %</td></tr>");
				}
				else
				{
					streamWriter.Write("<tr><td colspan=\"2\">Crediário.......</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + crediario_dia.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pcrediariodia.ToString("0.00") + " %</td></tr>");
				}

				streamWriter.Write("<tr><td colspan=\"2\"><b>Total de vendas.</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + vendas_dia.ToString("#,###,##0.00") + "</b></td><td align=\"right\"></td></tr>");

				streamWriter.Write("</table></td><td>");

				//Recebimentos Dia
				streamWriter.Write("<table style=\"font-family:monospace; border: solid 1px;\"><tr><td colspan=\"4\" align=\"center\">Recebimentos do dia</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + dinheiro_rec.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pdinheirorec.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cheque..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cheque_rec.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pchequerec.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cartão..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cartao_rec.ToString("#,###,##0.00") + "</td><td align=\"right\">&nbsp;&nbsp;&nbsp;" + pcartaorec.ToString("0.00") + " %</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\"><b>Total...........</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + totalrec.ToString("#,###,##0.00") + "</b></td><td align=\"right\"></td></tr></table>");

				streamWriter.Write("</td></tr><tr><td>");

				//Financeiro Dia
				streamWriter.Write("<table style=\"font-family:monospace; border: solid 1px;\"><tr><td colspan=\"4\" align=\"center\">Caixa do dia</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + (dinheiro_rec + dinheiro_dia).ToString("#,###,##0.00") + "</td><td align=\"right\"></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cheque..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + (cheque_rec + cheque_dia).ToString("#,###,##0.00") + "</td><td align=\"right\"></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cartão..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + (cartao_rec + cartao_dia).ToString("#,###,##0.00") + "</td><td align=\"right\"></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\"><b>Total...........</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + (totalrec + totaldia).ToString("#,###,##0.00") + "</b></td><td align=\"right\"></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Despesas........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + despesa_dia.ToString("#,###,##0.00") + "</td><td align=\"right\"></td></tr>");
				streamWriter.Write("<tr><td colspan=\"4\"><hr/></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\"><b>Saldo...........</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + ((totalrec + totaldia) - despesa_dia).ToString("#,###,##0.00") + "</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;" + ((((totalrec + totaldia) - despesa_dia) * 100) / (totalrec + totaldia)).ToString("0.00") + " %</b></td></tr>");

				streamWriter.Write("</td><td></td></tr></table>");

				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + Arquivo + ".htm");

				return;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return;
			}
		}

		public void GerarMovimentosPeriodo(string inicial, string final, double dinheiro, double cartao, double cheque, double debito, double crediario,
			double cdinheiro, double ccartao, double ccheque)
		{
			try
			{
				double vendas = dinheiro + cheque + cartao + crediario + debito;
				double caixa = cdinheiro + ccartao + ccheque;

				DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

				if (!directory.Exists)
				{
					directory.Create();
				}

				FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + "Movimento.htm");
				StreamWriter streamWriter = fileInfo.CreateText();

				streamWriter.Write("<html encoding=\"utf8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head>");
				streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td><img alt=\"Logo\" src=\"logo.png\" /></td>");
				streamWriter.Write("<td><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Movimento por Período</p></td>");
				streamWriter.Write("<td align=\"right\"><p style=\"font-family:Arial; color:silver; font-size:small\"><i>" + Descricao + "</i></p></td></tr>");
				streamWriter.Write("<tr><td>Período de " + inicial + " até " + final + "</td><td></td><td></td></tr></table>");
				streamWriter.Write("<hr/>");
				streamWriter.Write("</head>");
				streamWriter.Write("<body>");
				streamWriter.Write("<table cellspacing=\"1\" cellpadding=\"4\" style=\"width:100%; font-family:monospace; font-size:x-small;\"><tr><td>");
				streamWriter.Write("<table style=\"border: dotted 1px;\"><tr><td colspan=\"3\" align=\"center\">Vendas</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + dinheiro.ToString("#,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cartao..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cartao.ToString("#,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cheques.........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cheque.ToString("#,###,##0.00") + "</td></tr>");

				if (RegrasDeNegocio.Instance.Ramo == "ESCOLA")
				{
					streamWriter.Write("<tr><td colspan=\"2\">Débito..........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + debito.ToString("#,###,##0.00") + "</td></tr>");
				}
				else
				{
					streamWriter.Write("<tr><td colspan=\"2\"><i>Crediário.......</i></td><td align=\"right\"><i>&nbsp;&nbsp;&nbsp;R$ " + crediario.ToString("#,###,##0.00") + "</i></td></tr>");
				}

				streamWriter.Write("<tr><td colspan=\"2\"><b>Total...........</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + vendas.ToString("#,###,##0.00") + "</b></td></tr>");

				streamWriter.Write("</table></td>");
				streamWriter.Write("<td><table style=\"border: dotted 1px;\"><tr><td colspan=\"3\" align=\"center\">Caixa</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Dinheiro........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + cdinheiro.ToString("#,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cartão..........</td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + ccartao.ToString("#,###,##0.00") + "</b></td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\">Cheques.........</td><td align=\"right\">&nbsp;&nbsp;&nbsp;R$ " + ccheque.ToString("#,###,##0.00") + "</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\"><b>Total.............</b></td><td align=\"right\"><b>&nbsp;&nbsp;&nbsp;R$ " + caixa.ToString("#,###,##0.00") + "</b></td></tr></table>");

				streamWriter.Write("</td></tr></table>");

				streamWriter.Write("</body></html>");
				streamWriter.Close();

				System.Diagnostics.Process.Start("chrome.exe", directory.FullName + "\\" + "Movimento.htm");

				return;
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message, "Relatório Html", System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore, System.Windows.Forms.MessageBoxIcon.Error);

				return;
			}
		}

		#endregion Methods
	}
}