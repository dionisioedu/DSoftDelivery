using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using DSoftCore;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	public class ManifestoDeTransporte
	{
		#region Fields

		private string FILE_EXT = ".htm";
		private string FILE_NAME = "ManifestoDeTransporte_";

		#endregion Fields

		#region Methods

		public void Gerar(Manifesto manifesto)
		{
			if (manifesto == null)
			{
				return;
			}

			string arquivo = FILE_NAME + manifesto.Indice.ToString() + FILE_EXT;

			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			// Header
			streamWriter.Write("<html encoding=\"utf-8\"><head><title>");
			streamWriter.Write("DSoft Delivery v1.4");
			streamWriter.Write("</title><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
			streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td><img alt=\"Logo\" src=\"logo.png\" /></td>");
			streamWriter.Write("<td><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Manifesto de Carga</p></td></tr></table>");

			// Estilo
			streamWriter.Write("<style type=\"text/css\">table { border: 1px solid #000000; border-collapse: collapse; font-size: x-small; } </style>");
			streamWriter.Write("</head>");

			streamWriter.Write("<body>");

			// Informações do Manifesto
			streamWriter.Write("<table style=\"width:100%; \">");
			streamWriter.Write("<tr>");

			// Emitente
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px;\">");
			streamWriter.Write("<p align=\"center\">EMITENTE</p><br/>");
			streamWriter.Write(manifesto.Emitente.RazaoSocial + "<br/>");
			streamWriter.Write(manifesto.Emitente.Logradouro + ", " + manifesto.Emitente.Numero + "<br/>");
			streamWriter.Write("CNPJ: " + manifesto.Emitente.Cnpj.ToString() + " I.E. " + manifesto.Emitente.InscricaoEstadual + "<br/>");
			streamWriter.Write("</td>");

			// Veículo
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px; \">");
			streamWriter.Write("<p align=\"center\">DADOS DO VEÍCULO</p><br/>");
			streamWriter.Write(manifesto.Veiculo.Marca + " " + manifesto.Veiculo.Placa + " - " + manifesto.Veiculo.Cidade + "/" + manifesto.Veiculo.Estado.Substring(0, 2) + "<br/>");

			if (manifesto.Carreta.Placa != "")
			{
				streamWriter.Write(manifesto.Carreta.Marca + " " + manifesto.Carreta.Placa + " - " + manifesto.Carreta.Cidade + "/" + manifesto.Carreta.Estado.Substring(0, 2) + "<br/>");
			}

			streamWriter.Write(manifesto.Motorista.Nome + "<br/>");
			streamWriter.Write("RG: " + manifesto.Motorista.Rg + " UF: " + manifesto.Motorista.Estado.Substring(0, 2) + " CNH: " + manifesto.Motorista.Habilitacao + "<br/>");
			streamWriter.Write("</td>");

			// Manifesto
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px; \">");
			streamWriter.Write("<p align=\"center\">MANIFESTO DE CARGA</p><br/>");
			streamWriter.Write("N. <b>" + manifesto.Indice.ToString() + "</b> Série: " + "<br/>");
			streamWriter.Write("Local: " + "<br/>");
			streamWriter.Write("Data: " + manifesto.Data.ToString("dd/MM/yyyy") + "<br/>");
			streamWriter.Write("</td>");

			streamWriter.Write("</tr>");
			streamWriter.Write("</table>");

			// Conhecimentos
			streamWriter.Write("<table style=\"width: 100%; \">");

			// Cabeçalho
			streamWriter.Write("<thead><tr>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">CTRC</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">REMETENTE</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">DESTINATÁRIO</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">LOCAL</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">N. FISCAL</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">VALOR MERC.</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">PESO</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">VOLUME</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">FRETE</td>");
			streamWriter.Write("</tr></thead>");

			if (manifesto.Conhecimentos.Rows.Count > 0)
			{
				double total_valor = 0;
				double total_peso = 0;
				double total_volume = 0;
				double total_frete = 0;

				streamWriter.Write("<tbody>");

				foreach (DataRow dr in manifesto.Conhecimentos.Rows)
				{
					double valor_mercadoria;
					double peso;
					double volume;
					double frete;
					string notas = "";

					if (!double.TryParse(dr["valor_mercadoria"].ToString(), out valor_mercadoria))
					{
						valor_mercadoria = 0;
					}

					if (!double.TryParse(dr["peso"].ToString(), out peso))
					{
						peso = 0;
					}

					if (!double.TryParse(dr["m3l"].ToString(), out volume))
					{
						volume = 0;
					}

					if (!double.TryParse(dr["valor_frete"].ToString(), out frete))
					{
						frete = 0;
					}

					if (dr["doc_nota1"].ToString() != "")
					{
						notas += Util.LimpaFormatacao(dr["doc_nota1"].ToString());
					}

					if (dr["doc_nota2"].ToString() != "''")
					{
						notas += ", " + Util.LimpaFormatacao(dr["doc_nota2"].ToString());
					}

					if (dr["doc_nota3"].ToString() != "''")
					{
						notas += ", " + Util.LimpaFormatacao(dr["doc_nota3"].ToString());
					}

					if (dr["doc_nota4"].ToString() != "''")
					{
						notas += ", " + Util.LimpaFormatacao(dr["doc_nota4"].ToString());
					}

					if (dr["doc_nota5"].ToString() != "''")
					{
						notas += ", " + Util.LimpaFormatacao(dr["doc_nota5"].ToString());
					}

					if (dr["doc_nota6"].ToString() != "''")
					{
						notas += ", " + Util.LimpaFormatacao(dr["doc_nota6"].ToString());
					}

					total_valor += valor_mercadoria;
					total_peso += peso;
					total_volume += volume;
					total_frete += frete;

					streamWriter.Write("<tr>");
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + dr["indice"].ToString() + "</td>"); // Conhecimento
					streamWriter.Write("<td align=\"left\" style=\"border: 1px solid #000000; \">" + dr["remetente"].ToString() + "</td>"); // Remetente
					streamWriter.Write("<td align=\"left\" style=\"border: 1px solid #000000; \">" + dr["destinatario"].ToString() + "</td>"); // Destinatário
					streamWriter.Write("<td align=\"left\" style=\"border: 1px solid #000000; \">" + dr["destino"].ToString() + "</td>");
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + notas + "</td>"); // Nota Fiscal
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + valor_mercadoria.ToString("##,###,##0.00") + "</td>"); // Valor da Mercadoria
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + peso.ToString() + "</td>"); // Peso
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + volume.ToString() + "</td>"); // Volume
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + frete.ToString("##,###,##0.00") + "</td>"); // Frete

					streamWriter.Write("</tr>");
				}

				streamWriter.Write("</tbody>");

				streamWriter.Write("<tfoot><tr>");

				streamWriter.Write("<td colspan=\"5\" align=\"left\"><b>Total</b></td>");
				streamWriter.Write("<td align=\"right\"><b>" + total_valor.ToString("##,###,##0.00") + "</b></td>");
				streamWriter.Write("<td align=\"right\"><b>" + total_peso.ToString() + "</b></td>");
				streamWriter.Write("<td align=\"right\"><b>" + total_volume.ToString() + "</b></td>");
				streamWriter.Write("<td align=\"right\"><b>" + total_frete.ToString("##,###,##0.00") + "</b></td>");

				streamWriter.Write("</tr></tfoot>");
			}

			streamWriter.Write("</table>");

			// Rodapé
			streamWriter.Write("<table style=\"width: 100%; \">");

			streamWriter.Write("<tr>");
			streamWriter.Write("<td style=\"width:60%; border-collapse: collapse; border: 1px solid #000000; padding: 15px;\">");
			streamWriter.Write("<p>OBSERVAÇÕES</p><br/><br/><br/><br/></td>");
			streamWriter.Write("<td>");
			streamWriter.Write("Recebi os volumes constantes deste manifesto<br/><br/>");
			streamWriter.Write("_______________________,__________  de  ___________  de  ___________<br/><br/>");
			streamWriter.Write("___________________________________________________<br/>Assinatura");
			streamWriter.Write("</td>");
			streamWriter.Write("</tr>");

			streamWriter.Write("</table>");

			streamWriter.Write("</body></html>");

			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + arquivo);
		}

		public void GerarPadrao(Manifesto manifesto)
		{
			if (manifesto == null)
			{
				return;
			}

			string arquivo = FILE_NAME + manifesto.Indice.ToString() + FILE_EXT;

			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			// Header
			streamWriter.Write("<html encoding=\"utf-8\"><head><title>");
			streamWriter.Write("DSoft Delivery v1.4");
			streamWriter.Write("</title><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
			streamWriter.Write("<table style=\"width:100%; border:1px;\"><tr><td><img alt=\"Logo\" src=\"logo.png\" /></td>");
			streamWriter.Write("<td><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Manifesto de Carga</p></td></tr></table>");

			// Estilo
			streamWriter.Write("<style type=\"text/css\">table { border: 1px solid #000000; border-collapse: collapse; font-size: x-small; } </style>");
			streamWriter.Write("</head>");

			streamWriter.Write("<body>");

			// Informações do Manifesto
			streamWriter.Write("<table style=\"width:100%; \">");
			streamWriter.Write("<tr>");

			// Emitente
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px;\">");
			streamWriter.Write("<p align=\"center\">EMITENTE</p><br/>");
			streamWriter.Write(manifesto.Emitente.RazaoSocial + "<br/>");
			streamWriter.Write(manifesto.Emitente.Logradouro + ", " + manifesto.Emitente.Numero + "<br/>");
			streamWriter.Write("CNPJ: " + manifesto.Emitente.Cnpj.ToString() + " I.E. " + manifesto.Emitente.InscricaoEstadual + "<br/>");
			streamWriter.Write("</td>");

			// Veículo
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px; \">");
			streamWriter.Write("<p align=\"center\">DADOS DO VEÍCULO</p><br/>");
			streamWriter.Write(manifesto.Veiculo.Marca + " " + manifesto.Veiculo.Placa + " - " + manifesto.Veiculo.Cidade + "/" + manifesto.Veiculo.Estado.Substring(0, 2) + "<br/>");
			streamWriter.Write(manifesto.Motorista.Nome + "<br/>");
			streamWriter.Write("RG: " + manifesto.Motorista.Rg + " UF: " + manifesto.Motorista.Estado.Substring(0, 2) + " CNH: " + manifesto.Motorista.Habilitacao + "<br/>");
			streamWriter.Write("</td>");

			// Manifesto
			streamWriter.Write("<td style=\"width:33%; border-collapse: collapse; border: 1px solid #000000; padding: 15px; \">");
			streamWriter.Write("<p align=\"center\">MANIFESTO DE CARGA</p><br/>");
			streamWriter.Write("N. <b>" + manifesto.Indice.ToString() + "</b> Série: " + "<br/>");
			streamWriter.Write("Local: " + "<br/>");
			streamWriter.Write("Data: " + manifesto.Data.ToString("dd/MM/yyyy") + "<br/>");
			streamWriter.Write("</td>");

			streamWriter.Write("</tr>");
			streamWriter.Write("</table>");

			// Conhecimentos
			streamWriter.Write("<table style=\"width: 100%; \">");

			// Cabeçalho
			streamWriter.Write("<tr>");
			streamWriter.Write("<td colspan=\"2\" align=\"center\" style=\"border: 1px solid #000000; \">CONHECIMENTO</td>");
			streamWriter.Write("<td colspan=\"2\" align=\"center\" style=\"border: 1px solid #000000; \">NOTA FISCAL</td>");
			streamWriter.Write("<td rowspan=\"2\" align=\"center\" style=\"border: 1px solid #000000; \">VALOR MERCADORIA</td>");
			streamWriter.Write("<td rowspan=\"2\" align=\"center\" style=\"border: 1px solid #000000; \">REMETENTE</td>");
			streamWriter.Write("<td rowspan=\"2\" align=\"center\" style=\"border: 1px solid #000000; \">DESTINATÁRIO</td>");
			streamWriter.Write("</tr>");
			streamWriter.Write("<tr>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">Número</td><td align=\"center\" style=\"border: 1px solid #000000; \">Série</td>");
			streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">Número</td><td align=\"center\" style=\"border: 1px solid #000000; \">Série</td>");
			streamWriter.Write("</tr>");

			if (manifesto.Conhecimentos.Rows.Count > 0)
			{
				foreach (DataRow dr in manifesto.Conhecimentos.Rows)
				{
					double valor_mercadoria;

					if (!double.TryParse(dr["valor_mercadoria"].ToString(), out valor_mercadoria))
					{
						valor_mercadoria = 0;
					}

					streamWriter.Write("<tr>");
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + dr["indice"].ToString() + "</td>"); // Conhecimento
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + "</td>"); // Série
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + dr["doc_nota"].ToString() + "</td>"); // Nota Fiscal
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + dr["doc_serie"].ToString() + "</td>"); // Série
					streamWriter.Write("<td align=\"right\" style=\"border: 1px solid #000000; \">" + valor_mercadoria.ToString("##,###,##0.00") + "</td>"); // Valor da Mercadoria
					streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">" + dr["remetente"].ToString() + "</td>"); // Remetente
					streamWriter.Write("<td align=\"center\" style=\"border: 1px solid #000000; \">" + dr["destinatario"].ToString() + "</td>"); // Destinatário
					streamWriter.Write("</tr>");
				}
			}

			streamWriter.Write("</table>");

			// Rodapé
			streamWriter.Write("<table style=\"width: 100%; \">");

			streamWriter.Write("<tr>");
			streamWriter.Write("<td style=\"width:60%; border-collapse: collapse; border: 1px solid #000000; padding: 15px;\">");
			streamWriter.Write("<p>OBSERVAÇÕES</p><br/><br/><br/><br/></td>");
			streamWriter.Write("<td>");
			streamWriter.Write("Recebi os volumes constantes deste manifesto<br/><br/>");
			streamWriter.Write("_______________________,__________  de  ___________  de  ___________<br/><br/>");
			streamWriter.Write("___________________________________________________<br/>Assinatura");
			streamWriter.Write("</td>");
			streamWriter.Write("</tr>");

			streamWriter.Write("</table>");

			streamWriter.Write("</body></html>");

			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + arquivo);
		}

		#endregion Methods
	}
}