using Jira.REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST
{
	public interface IJira
	{
		Task<bool> Connect(string url, string name, string password);

		Task<IEnumerable<Board>> GetAllBoards();

		Task<Board> GetBoardById(string boardId);

		Task<IEnumerable<Sprint>> GetBoardSprints(string boardId);

		Task<IEnumerable<Issue>> GetIssuesByBoardAndSprint(string boardId, string sprintId);

		Task<IEnumerable<WorkLog>> GetIssueWorkLogs(string issueIdOrKey);

		Task<WorkLog> GetWorkLogById(string issueIdOrKey, string workLogId);

		Task<WorkLog> AddWorkLog(string issueIdOrKey, DateTime created, int timeSpent, string comment);

		Task<WorkLog> UpdateWorkLog(string issueIdOrKey, string workLogId, DateTime created, int timeSpent, string comment);
	}
}
