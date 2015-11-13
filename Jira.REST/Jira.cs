using Jira.REST.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jira.REST.Models;

namespace Jira.REST
{
	public class Jira : IJira
	{
		private IJiraClient Client { get; set; }

		public bool Connect(string url, string name, string password)
		{
			Client = new JiraClient(url);

			return Client.Connect(name, password);
		}

		public IEnumerable<Board> GetAllBoards()
		{
			return Client.GetAllBoards();
		}

		public Board GetBoardById(string boardId)
		{
			return Client.GetBoardById(boardId);
		}

		public IEnumerable<Sprint> GetBoardSprints(string boardId)
		{
			return Client.GetBoardSprints(boardId);
		}

		public IEnumerable<Issue> GetIssuesByBoardAndSprint(string boardId, string sprintId)
		{
			return Client.GetIssuesByBoardAndSprint(boardId, sprintId);
		}

		public IEnumerable<WorkLog> GetIssueWorkLogs(string issueIdOrKey)
		{
			return Client.GetIssueWorkLogs(issueIdOrKey);
		}

		public WorkLog GetWorkLogById(string issueIdOrKey, string workLogId)
		{
			return Client.GetWorkLogById(issueIdOrKey, workLogId);
		}

		public WorkLog AddWorkLog(string issueIdOrKey, DateTime created, int timeSpent, string comment)
		{
			return Client.AddWorkLog(issueIdOrKey, created, timeSpent, comment);
		}

		public WorkLog UpdateWorkLog(string issueIdOrKey, string workLogId, DateTime created, int timeSpent, string comment)
		{
			return Client.UpdateWorkLog(issueIdOrKey, workLogId, created, timeSpent, comment);
		}
	}
}
