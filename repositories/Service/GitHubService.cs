using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using System.Collections;
using repositories.Model;
using repositories.RestClient;

namespace repositories.Service
{
	public class GitHubService
	{


		public GitHubService()
		{


		}

		public async Task<List<RepositoriesModel.Item>>GetRepositoriesAsync()
		{
			RestClient<RepositoriesModel.Item> restClient = new RestClient<RepositoriesModel.Item>();

			var repositoriesList = await restClient.GetAsync();
			return repositoriesList;
			}

      
	}
}
