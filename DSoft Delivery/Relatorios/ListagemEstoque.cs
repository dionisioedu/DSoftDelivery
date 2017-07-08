using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using DSoftParameters;

namespace DSoft_Delivery.Relatorios
{
	class ListagemEstoque
	{
		#region Fields

		public static string Arquivo = "ListagemEstoque.htm";

		#endregion Fields

		#region Methods

		public static void Gerar(DataTable dt)
		{
			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Arquivo);
			StreamWriter streamWriter = fileInfo.CreateText();

			string html = "<html encoding=\"utf8\"><head><title>";
			html += "DSoft Delivery v1.2";
			html += "</title><head>";
			html += "<table style=\"font-family: arial; width:100%; border:1px;\"><tr><td rowspan=\"2\"><img alt=\"Logo\" src=\"logo.png\" /></td>";
			html += "<td colspan=\"4\"><p style=\"font-family:Arial, Helvetica, sans-serif; font-size:x-Large\">Listagem do Estoque</p></td></tr>";
			html += "<tr><td colspan=\"4\"><p style=\"font-family: Arial; font-size: Normal;\">Emitido em: " + DateTime.Today.ToShortDateString() + "</p></td></tr>";
			html += "<tr style=\"font-family: Arial; font-size: Normal;\"><th>Produto</th><th>Descrição</th><th>Mínimo</th><th>Máximo</th><th><b>Atual</b></th></tr>";
			html += "<tr><td colspan=\"5\"><hr/></td></tr>";

			bool zebra = true;

			foreach (DataRow r in dt.Rows)
			{
				if (zebra)
					html += "<tr>";
				else
					html += "<tr style=\"background-color:silver\">";

				zebra = !zebra;

				html += "<td align=\"right\" style=\"padding-right: 20px; \">" + r["produto"].ToString() + "</td>";
				html += "<td>" + r["nome"].ToString() + "</td>";
				html += "<td align=\"right\">" + r["minimo"].ToString() + "</td>";
				html += "<td align=\"right\">" + r["maximo"].ToString() + "</td>";
				html += "<td align=\"right\">" + r["atual"].ToString() + "</td>";

				html += "</tr>";
			}

			html += "<tr><td colspan=\"5\"><hr/></td></tr>";
			html += "<tr><td colspan=\"5\">Total de produtos listados: <b>" + dt.Rows.Count.ToString() + "</b></td></tr>";
			html += "</table></body></html>";

			streamWriter.Write(html);
			streamWriter.Close();

			System.Diagnostics.Process.Start(Terminal.Browser, directory.FullName + "\\" + Arquivo);
		}

		#endregion Methods
	}
}