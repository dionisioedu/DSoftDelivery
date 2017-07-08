using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DSoft_Server
{
	static class Program
	{
		#region Methods

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}

		#endregion Methods
	}
}