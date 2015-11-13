using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jira.REST.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Jira.REST.Managers
{
	public class ConnectionManager : BaseManager, IConnectionManager
	{
		public LoginResponse Login(string url, string username, string password)
		{
			using (var client = new HttpClient())
			{

				var request = CreateRequestParams(new
				{
					username = username,
					password = password
				});

				var http = client.PostAsync(url, request).Result;

				var httpResponse = http.Content.ReadAsStringAsync().Result;

				var response = new LoginResponse();

				if (http.IsSuccessStatusCode)
				{
					var successResponse = JsonConvert.DeserializeObject<LoginResponseSuccess>(httpResponse);

					response.IsRequestSuccessful = true;

					response.Response = successResponse;

					return response;
				}

				response.IsRequestSuccessful = false;

				return response;

			}
		}
	}
}
