using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace repositories.Service
{
	public class GitHubService
	{

		public GitHubService()
		{


		}

		public async void repositoryList()
		{
			try
			{
				using (var c = new HttpClient())
				{
					HttpClient client = new HttpClient();
					string url = "https://api.github.com/search/repositories?q=language:JavaScript&sort=stars&page=1";
					client.Timeout = TimeSpan.FromSeconds(30);
					HttpResponseMessage response = await client.GetAsync(url);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<OpeningsRecomendationApp>(responseBody);
				}
			}
			catch (Exception e)
			{
				Console.Write(e);
			}
		}

		//async Task CallApi()
		//     {
		//var rAPI = RestService.For<IGitHubAPI>("https://api.github.com");
		//var repositories = await rAPI.GetRepositories();
		//Console.Write(repositories.Length);
		//}


	}
}
