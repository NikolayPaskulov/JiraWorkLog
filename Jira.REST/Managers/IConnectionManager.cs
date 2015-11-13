using Jira.REST.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Managers
{
	public interface IConnectionManager
	{
		LoginResponse Login(string url, string username, string password);
	}
}
