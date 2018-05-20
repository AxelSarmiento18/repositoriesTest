using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using repositories.Model;

namespace repositories.RestClient
{
	public class RestClient<T>
	{
		RepositoriesModel model = new RepositoriesModel();
		List<RepositoriesPullModel> pullModel = new List<RepositoriesPullModel>();
		private const string sebServiceUrl = "https://api.github.com/search/repositories?q=language:JavaScript&sort=stars&page=1";

		public RestClient()
		{
		}

		public async Task<List<RepositoriesModel.Item>> GetAsync()
		{
			try
			{
				using (var c = new HttpClient())
				{
					HttpClient client = new HttpClient();
					client.Timeout = TimeSpan.FromSeconds(30);
					HttpResponseMessage response = await client.GetAsync(sebServiceUrl);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<RepositoriesModel>(responseBody);
					return model.Items;
				}
			}
			catch (Exception e)
			{
				return null;
			}

		}

		public async Task<List<RepositoriesPullModel>> GetPullAsync(string pullsURL)
		{
			try
			{
				using (var c = new HttpClient())
				{
					HttpClient client = new HttpClient();
					string url = pullsURL.Replace("{/number}", "?state=all");
					client.Timeout = TimeSpan.FromSeconds(30);
					HttpResponseMessage response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();
					pullModel = JsonConvert.DeserializeObject<List<RepositoriesPullModel>>(responseBody);
					return pullModel;
				}
			}
			catch (Exception e)
			{
				return null;
			}

		}





	}
}
