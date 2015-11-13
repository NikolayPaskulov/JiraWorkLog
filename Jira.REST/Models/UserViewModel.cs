using Jira.REST.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Models
{
	public class UserViewModel
	{
		public string Username { get; set; }

		public string Password { get; set; }

		// TODO 
		// public SecureString Password {get; set;}
	}
}
