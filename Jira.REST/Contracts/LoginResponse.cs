using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Contracts
{
	public class LoginResponse
	{
		public bool IsRequestSuccessful { get; set; }

		public IResponse Response { get; set; }
	}
}
