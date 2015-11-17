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

		public Task<bool> Connect(string url, string name, string password)
		{
			Client = new JiraClient(url);

			return Task.Factory.StartNew(() =>
			{
				return Client.Connect(name, password);
			});
		}

		public Task<IEnumerable<Board>> GetAllBoards()
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetAllBoards();
			}); 
		}

		public Task<Board> GetBoardById(string boardId)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetBoardById(boardId);
			});
		}

		public Task<IEnumerable<Sprint>> GetBoardSprints(string boardId)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetBoardSprints(boardId);
			});
		}

		public Task<IEnumerable<Issue>> GetIssuesByBoardAndSprint(string boardId, string sprintId)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetIssuesByBoardAndSprint(boardId, sprintId);
			});
		}

		public Task<IEnumerable<WorkLog>> GetIssueWorkLogs(string issueIdOrKey)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetIssueWorkLogs(issueIdOrKey);
			});
		}

		public Task<WorkLog> GetWorkLogById(string issueIdOrKey, string workLogId)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.GetWorkLogById(issueIdOrKey, workLogId);
			});
		}

		public Task<WorkLog> AddWorkLog(string issueIdOrKey, DateTime created, int timeSpent, string comment)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.AddWorkLog(issueIdOrKey, created, timeSpent, comment);
			});
		}

		public Task<WorkLog> UpdateWorkLog(string issueIdOrKey, string workLogId, DateTime created, int timeSpent, string comment)
		{
			return Task.Factory.StartNew(() =>
			{
				return Client.UpdateWorkLog(issueIdOrKey, workLogId, created, timeSpent, comment);
			});
		}
	}
}
