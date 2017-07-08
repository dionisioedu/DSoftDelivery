using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftCloud
{
	public class Cloud
	{
		public string TestWebService()
		{
			DSoftWS.dsoft_server server = new DSoftWS.dsoft_server();

			return server.dsoft_test("DSoftWS");
		}
	}
}
