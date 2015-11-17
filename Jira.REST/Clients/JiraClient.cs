using Jira.REST.Managers;
using Jira.REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Security;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using Jira.REST.Contracts;

namespace Jira.REST.Clients
{
	public class JiraClient : IJiraClient
	{

		private UserViewModel _model;
		private string _baseUrl;


		private HttpClient Client { get; set; }
		private ConnectionManager ConnectionManager { get; set; }
		private BoardsManager BoardsManager { get; set; }
		private WorkLogManager WorkLogManager { get; set; }


		private const string _jiraApiUrl = "rest/api/latest";
		private const string _jiraAuthUrl = "rest/auth/1/session";
		private const string _jiraAgileUrl = "rest/agile/latest";

		public JiraClient(string baseUrl)
		{
			_baseUrl = baseUrl;
            ConnectionManager = new ConnectionManager();
        }

		public bool Connect(string username, string password)
		{
			var url = string.Format("{0}/{1}", _baseUrl, _jiraAuthUrl);

			var connectionResponse = ConnectionManager.Login(url, username, password);

			if(connectionResponse.IsRequestSuccessful)
			{
				_model = new UserViewModel()
				{
					Username = username,
					Password = password
				};

				InitHttpClient(username, password);
				InitManagers();
				return true;
			}

			return false;
        }

		private void InitHttpClient(string username, string password)
		{
			this.Client = new HttpClient();

			Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
			Client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");

			var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password));
			Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
		}

		private void InitManagers()
		{
			BoardsManager = new BoardsManager(this.Client);

			WorkLogManager = new WorkLogManager(this.Client);
        }

		public IEnumerable<Board> GetAllBoards()
		{
			var url = string.Format("{0}/{1}/{2}", _baseUrl, _jiraAgileUrl, "board");

			return BoardsManager.GetAllBoards(url);
		}

		public Board GetBoardById(string boardId)
		{
			var url = string.Format("{0}/{1}/{2}/{3}", _baseUrl, _jiraAgileUrl, "board", boardId);

			return BoardsManager.GetBoardById(url);
		}

		public IEnumerable<Sprint> GetBoardSprints(string boardId)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}", _baseUrl, _jiraAgileUrl, "board", boardId, "sprint");

			return BoardsManager.GetBoardSprints(url);
		}

		public IEnumerable<Issue> GetIssuesByBoardAndSprint(string boardId, string sprintId)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", _baseUrl, _jiraAgileUrl, "board", boardId, "sprint", sprintId, "issue");

			return BoardsManager.GetIssuesByBoardAndSprint(url);
		}

		public IEnumerable<WorkLog> GetIssueWorkLogs(string issueIdOrKey)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}", _baseUrl, _jiraApiUrl, "issue", issueIdOrKey, "worklog");

			return WorkLogManager.GetIssueWorkLogs(url);
		}

		public WorkLog GetWorkLogById(string issueIdOrKey, string workLogId)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}/{5}", _baseUrl, _jiraApiUrl, "issue", issueIdOrKey, "worklog", workLogId);

			return WorkLogManager.GetWorkLogById(url);
		}

		public WorkLog AddWorkLog(string issueIdOrKey, DateTime created, int timeSpent, string comment)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}", _baseUrl, _jiraApiUrl, "issue", issueIdOrKey, "worklog");

			return WorkLogManager.AddWorkLog(url, created, timeSpent, comment);
		}

		public WorkLog UpdateWorkLog(string issueIdOrKey, string workLogId, DateTime created, int timeSpent, string comment)
		{
			var url = string.Format("{0}/{1}/{2}/{3}/{4}/{5}", _baseUrl, _jiraApiUrl, "issue", issueIdOrKey, "worklog", workLogId);

			return WorkLogManager.UpdateWorkLog(url, created, timeSpent, comment);
		}
	}
}
