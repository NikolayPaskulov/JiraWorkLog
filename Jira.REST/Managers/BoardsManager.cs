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
	public class BoardsManager
	{

		private HttpClient _client;

		public BoardsManager(HttpClient client)
		{
			_client = client;
        }
		public IEnumerable<Board> GetAllBoards(string url)
		{
			var boards = new List<Board>();

			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<GetAllBoardsResponse>(resultAsString);

				return result.Values;
			}

			return boards;
		}

		public Board GetBoardById(string url)
		{
			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<Board>(resultAsString);

				return result;
			}

			return null;
		}

		public IEnumerable<Sprint> GetBoardSprints(string url)
		{
			var sprints = new List<Sprint>();

			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<GetBoardSprintsResponse>(resultAsString);

				return result.Values;
			}

			return sprints;
		}

		public IEnumerable<Issue> GetIssuesByBoardAndSprint(string url)
		{
			var issues = new List<Issue>();

			var http = _client.GetAsync(url).Result;

			if (http.IsSuccessStatusCode)
			{
				var resultAsString = http.Content.ReadAsStringAsync().Result;
				var result = JsonConvert.DeserializeObject<GetIssuesByBoardAndSprintResponse>(resultAsString);

				return result.Issues;
			}

			return issues;
		}
	}
}
