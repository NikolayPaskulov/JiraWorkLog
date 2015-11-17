using Jira.REST.Contracts;
using Jira.REST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Managers
{
	public class WorkLogManager : BaseManager
	{

		private HttpClient _client { get; set; }

		public WorkLogManager(HttpClient client)
		{
			_client = client;
		}

		public IEnumerable<WorkLog> GetIssueWorkLogs(string url)
		{
			var worklogs = new List<WorkLog>();

			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<GetIssueWorkLogsResponse>(resultAsString);

				return result.WorkLogs;
			}

			return worklogs;
		}

		public WorkLog GetWorkLogById(string url)
		{
			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<WorkLog>(resultAsString);

				return result;
			}

			return null;
		}

		public WorkLog AddWorkLog(string url, DateTime created, long timeSpent, string comment)
		{
			var request = CreateRequestParams(new
			{
				created = created,
				timeSpentSeconds = timeSpent,
				comment = comment
			});

			var http = _client.PostAsync(url, request).Result;

			if(http.IsSuccessStatusCode)
			{
				var httpResponse = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<WorkLog>(httpResponse);

				return result;
			}

			return null;
		}

		public WorkLog UpdateWorkLog(string url, DateTime created, long timeSpent, string comment)
		{
			var request = CreateRequestParams(new
			{
				created = created,
				timeSpent = timeSpent,
				comment = comment
			});

			var http = _client.PutAsync(url, request).Result;

			if(http.IsSuccessStatusCode)
			{
				var httpResponse = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<WorkLog>(httpResponse);

				return result;
			}

			return null;
		}
	}
}
