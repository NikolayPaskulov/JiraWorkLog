using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jira.REST.Managers
{
	public class BaseManager
	{
		public HttpClient GetHttpClient()
		{
			var client = new HttpClient();

			client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");

			return client;
		}

		public StringContent CreateRequestParams(object requestParams)
		{
			var requestContent = JsonConvert.SerializeObject(requestParams);

			var request = new StringContent(requestContent)
			{
				Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
			};

			return request;
        }
	}
}
