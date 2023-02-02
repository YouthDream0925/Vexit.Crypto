using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api
{
	public class Settings
	{
		public string RpcUserName { get; set; }
		public string RpcPassword { get; set; }
		public string RpcIpAddress { get; set; }
		public int Port { get; set; }
	}
}
