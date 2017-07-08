using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSoftLogger
{
	public class Logger
	{
		#region Fields

		private static Logger _instance;

		#endregion Fields

		#region Properties

		public static Logger Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Logger();
				}

				return _instance;
			}
		}

		#endregion Properties

		#region Methods

		public void Error(string msg, int usuario)
		{
			StreamWriter writer = new StreamWriter(DSoftParameters.Preferencias.PastaLog + "error" + DateTime.Now.ToShortDateString() + ".log", true);
			writer.WriteLine(DateTime.Now.ToShortTimeString() + " - " + usuario.ToString() + " : " + msg);
			writer.Flush();
			writer.Close();
		}

		public void Error(string msg)
		{
			Error(msg, 1);
		}

		public void Error(Exception e, int usuario)
		{
			StreamWriter writer = new StreamWriter(DSoftParameters.Preferencias.PastaLog + "error" + DateTime.Now.ToString("yyMMdd") + ".log", true);
			writer.WriteLine(DateTime.Now.ToShortTimeString() + " - " + usuario.ToString() + Environment.NewLine + "Data : " + e.Data + Environment.NewLine
				+ "Message : " + e.Message + Environment.NewLine + "Source : " + e.Source + Environment.NewLine + "StackTrace : " + e.StackTrace);
			writer.Flush();
			writer.Close();
		}

		public void Error(Exception e)
		{
			Error(e, 1);
		}

		public void Log(string msg, int usuario)
		{
			StreamWriter writer = new StreamWriter(Path.Combine(DSoftParameters.Preferencias.PastaLog, string.Format("log_{0}{1}{2}.log", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)), true);
			writer.WriteLine(string.Format("{0} - {1} : {2}", DateTime.Now.ToShortTimeString(), usuario.ToString(), msg));
			writer.Flush();
			writer.Close();
		}

		#endregion Methods
	}
}