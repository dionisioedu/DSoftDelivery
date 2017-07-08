using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	public class DemOrdemDeColeta
	{
		#region Fields

		private string FILE_EXT = ".htm";
		private string FILE_NAME = "OrdemDeColeta_";

		#endregion Fields

		#region Methods

		public void Gerar(OrdemDeColeta ordemDeColeta, int vias = 1)
		{
			if (ordemDeColeta == null)
			{
				return;
			}

			string arquivo = FILE_NAME + ordemDeColeta.Indice.ToString() + FILE_EXT;

			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			for (int i = 0; i < vias; i++)
			{
				streamWriter.Write("<html encoding=\"utf-8\"><head><title>");
				streamWriter.Write("DSoft Delivery v1.4");
				streamWriter.Write("</title><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");

				streamWriter.Write("<table style=\"width:100%; border:1px solid black; font-size:xx-small; border-collapse:collapse;\">");

				// Cabeçalho
				streamWriter.Write("<tr><td colspan=\"2\"><img alt=\"Logo\" src=\"logo_ordem_de_coleta.png\" /></td>");
				streamWriter.Write("<td align=\"center\" style=\"font-size: normal; border: 1px solid black;\">ORDEM<br/>DE<br/>COLETA<br/></td>");
				streamWriter.Write("<td align=\"center\" style=\"font-size: normal;\">" + ordemDeColeta.Data.ToString("dd/MM/yyyy") + "</td>");
				streamWriter.Write("</tr>");

				// Remetente
				streamWriter.Write("<tr style=\"border: 1px solid black;\">");
				streamWriter.Write("<td colspan=\"4\">");
				streamWriter.Write("<table width=\"100%\" style=\"font-size: xx-small;\"><tr><td colspan=\"2\" width=\"70%\">REMETENTE: " + ordemDeColeta.Remetente.Nome + "</td><td width=\"30%\">CNPJ: " + ordemDeColeta.Remetente.Documento + "</td></tr>");
				streamWriter.Write("<tr><td width=\"50%\">ENDEREÇO: " + ordemDeColeta.Remetente.Endereco + ", " + ordemDeColeta.Remetente.Numero + "</td>");
				streamWriter.Write("<td width=\"25%\">CIDADE: " + ordemDeColeta.Remetente.Cidade + "</td><td width=\"25%\">INSC: " + ordemDeColeta.Remetente.InscricaoEstadual + "</td></tr></table></td>");
				streamWriter.Write("</tr>");

				// Destinatário
				streamWriter.Write("<tr style=\"border: 1px solid black;\">");
				streamWriter.Write("<td colspan=\"4\">");
				streamWriter.Write("<table width=\"100%\" style=\"font-size: xx-small;\"><tr><td colspan=\"2\" width=\"70%\">DESTINATÁRIO: " + ordemDeColeta.Destinatario.Nome + "</td><td width=\"30%\">CNPJ: " + ordemDeColeta.Destinatario.Documento + "</td></tr>");
				streamWriter.Write("<tr><td width=\"50%\">ENDEREÇO: " + ordemDeColeta.Destinatario.Endereco + ", " + ordemDeColeta.Destinatario.Numero + "</td>");
				streamWriter.Write("<td width=\"25%\">CIDADE: " + ordemDeColeta.Destinatario.Cidade + "</td><td width=\"25%\">INSC: " + ordemDeColeta.Destinatario.InscricaoEstadual + "</td></tr></table></td>");
				streamWriter.Write("</tr>");

				// Consignatário
				streamWriter.Write("<tr>");
				streamWriter.Write("<td colspan=\"3\" style=\"border-bottom:none; border-right:1px solid black;\">CONSIGNATÁRIO: </td>");

				if (ordemDeColeta.Pago)
				{
					streamWriter.Write("<td rowspan=\"2\">PAGO | X |  À PAGAR |  |</td></tr>");
				}
				else
				{
					streamWriter.Write("<td rowspan=\"2\">PAGO |  |  À PAGAR | X |</td></tr>");
				}

				streamWriter.Write("<tr><td colspan=\"3\" style=\"border-top:none; border-right:1px solid black;\">ENDEREÇO: </td></tr>");

				// Nota Fiscal
				streamWriter.Write("<tr style=\"border: 1px solid black;\">");
				streamWriter.Write("<td colspan=\"2\" width=\"33%\" align=\"center\" style=\"border: 1px solid black;\">CONTEÚDO</td>");
				streamWriter.Write("<td align=\"center\" width=\"33%\" style=\"border: 1px solid black;\">NOTA FISCAL</td>");
				streamWriter.Write("<td align=\"center\" width=\"33%\" style=\"border: 1px solid black;\">VALOR DA NOTA FISCAL</td></tr>");
				streamWriter.Write("<tr><td colspan=\"2\" width=\"33%\" style=\"border: 1px solid black;\">" + ordemDeColeta.ProdudoPredominante + "</td>");
				streamWriter.Write("<td style=\"border: 1px solid black;\">" + ordemDeColeta.DocNota[0] + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border: 1px solid black;\">" + ordemDeColeta.ValorMercadoria.ToString("##,###,##0.00") + "</td><tr>");

				// Produto
				streamWriter.Write("<tr><td colspan=\"4\"><table width=\"100%\" style=\"font-size: xx-small; border-collapse:collapse;\">");
				streamWriter.Write("<tr><td align=\"center\" style=\"border-right: 1px solid black;\">PESO</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">QUANTIDADE</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">ESPÉCIE</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">MARCA</td>");
				streamWriter.Write("<td align=\"center\">NÚMERO</td></tr>");

				streamWriter.Write("<tr style=\"border-top: 1px solid black;\">");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + ordemDeColeta.Quantidade[0].ToString() + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + ordemDeColeta.TipoMedida[0] + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\">" + "</td>");
				streamWriter.Write("</tr>");
				streamWriter.Write("</table></td></tr>");

				// Frete
				streamWriter.Write("<tr><td colspan=\"4\"><table width=\"100%\" style=\"font-size: xx-small; border-collapse:collapse;\">");
				streamWriter.Write("<tr style=\"border-top: 1px solid black;\"><td align=\"center\" style=\"border-right: 1px solid black;\">FRETE PESO</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">FRETEVALOR</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">CAT</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">DESPACHO</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">ITR</td>");
				streamWriter.Write("<td align=\"center\" style=\"border-right: 1px solid black;\">ADEME</td>");
				streamWriter.Write("<td align=\"center\">TOTAL DA PREST.</td></tr>");

				streamWriter.Write("<tr style=\"border-top: 1px solid black;\">");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + ordemDeColeta.ValorFrete.ToString("##,###,##0.00") + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("<td align=\"right\" style=\"border-right: 1px solid black;\">" + "</td>");
				streamWriter.Write("</tr>");
				streamWriter.Write("</table></td></tr>");

				streamWriter.Write("<tr style=\"border-top: 1px solid black;\"><td colspan=\"2\" valign=\"top\" style=\"border-right: 1px solid black;\">OBSERVAÇÕES<br/><br/></td>");
				streamWriter.Write("<td valign=\"top\" style=\"border-right: 1px solid black;\">RECEBEMOS OS VOLUMES DESTA</td>");
				streamWriter.Write("<td>LOCAL DATA<br/><br/><br/><br/>____________________________________________________<br/>ASSINATURA</td></tr>");

				streamWriter.Write("</table><br/><br/>");
			}

			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + arquivo);
		}

		#endregion Methods
	}
}