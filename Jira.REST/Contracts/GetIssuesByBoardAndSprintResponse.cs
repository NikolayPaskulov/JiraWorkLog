using Jira.REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Contracts
{
	public class GetIssuesByBoardAndSprintResponse
	{
		public int StartAt { get; set; }

		public int MaxResults { get; set; }

		public int Total { get; set; }

		public IEnumerable<Issue> Issues { get; set; }
	}
}
