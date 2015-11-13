using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Contracts
{
	public class ErrorResponse : IResponse
	{
		public IEnumerable<string> ErrorMessages { get; set; }

		public object Errors { get; set; }
	}
}
