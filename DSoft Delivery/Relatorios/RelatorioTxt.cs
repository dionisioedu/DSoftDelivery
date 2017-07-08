using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using DSoftParameters;

namespace DSoft_Delivery
{
	class RelatorioTxt
	{
		#region Fields

		/// <summary>
		/// Cabecalho das colunas
		/// </summary>
		public string Cabecalho;

		/// <summary>
		/// Dados do relatório
		/// </summary>
		public string[] Dados;

		/// <summary>
		/// Uma breve descrição do relatório, será impressa logo após o título
		/// </summary>
		public string Descricao;

		/// <summary>
		/// Titulo do relatório
		/// </summary>
		public string Titulo;

		#endregion Fields

		#region Methods

		public void Gerar()
		{
			string linha = new string('=', Titulo.Length);

			DirectoryInfo directory = new DirectoryInfo(Preferencias.RelatoriosPath);

			if (!directory.Exists)
			{
				directory.Create();
			}

			FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + Titulo + ".txt");
			StreamWriter streamWriter = fileInfo.CreateText();

			streamWriter.WriteLine(Titulo);
			streamWriter.WriteLine(linha);
			streamWriter.Write(streamWriter.NewLine);
			streamWriter.WriteLine(Descricao);
			streamWriter.Write(streamWriter.NewLine);
			streamWriter.WriteLine(Cabecalho);
			streamWriter.Close();

			System.Diagnostics.Process.Start("firefox.exe", directory.FullName + "\\" + Titulo + ".txt");

			return;
		}

		#endregion Methods
	}
}