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
		bool Connect(string url, string name, string password);

		IEnumerable<Board> GetAllBoards();

		Board GetBoardById(string boardId);

		IEnumerable<Sprint> GetBoardSprints(string boardId);

		IEnumerable<Issue> GetIssuesByBoardAndSprint(string boardId, string sprintId);

		IEnumerable<WorkLog> GetIssueWorkLogs(string issueIdOrKey);

		WorkLog GetWorkLogById(string issueIdOrKey, string workLogId);

		WorkLog AddWorkLog(string issueIdOrKey, DateTime created, int timeSpent, string comment);

		WorkLog UpdateWorkLog(string issueIdOrKey, string workLogId, DateTime created, int timeSpent, string comment);
	}
}
