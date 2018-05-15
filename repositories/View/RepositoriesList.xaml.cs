using System;
using System.Collections.Generic;

using Xamarin.Forms;
using repositories.Service;
using Plugin.Connectivity;
using System.Threading.Tasks;
using Refit;
using System.Collections.ObjectModel;
using repositories.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace repositories.View
{
	public partial class RepositoriesList : ContentPage
	{
		GitHubService git = new GitHubService();
		RepositoriesModel model = new RepositoriesModel();

		public RepositoriesList()
		{
			InitializeComponent();

			repositoryList();
			BindingContext = model;



			var isConnected = CrossConnectivity.Current.IsConnected;

			if (isConnected)
				git.repositoryList();
			else
				DisplayAlert("Error", "Err", "ok");
		}

		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			         
			if (string.IsNullOrEmpty(e.NewTextValue))
			{
				RepositoriesListView.ItemsSource = model.Items;
			}

			else
			{
				RepositoriesListView.ItemsSource = model.Items.Where(x => x.Owner.Login.StartsWith(e.NewTextValue) || x.Name.StartsWith(e.NewTextValue));
			}
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
					model = JsonConvert.DeserializeObject<RepositoriesModel>(responseBody);
					RepositoriesListView.ItemsSource = model.Items;

				}
			}
			catch (Exception e)
			{
				Console.Write(e);
			}
		}



	}
}
