using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using repositories.Model;
using Xamarin.Forms;

namespace repositories.View
{
    public partial class RepositoriesPull : ContentPage
    {
		RepositoriesPullModel model = new RepositoriesPullModel();

        public RepositoriesPull(RepositoriesModel.Item model)
        {
            InitializeComponent();

			repositoryList(model.Pulls_Url);
            


        }

		public async void repositoryList(string pullsURL)
        {
            try
            {
				
                using (var c = new HttpClient())
                {
                    HttpClient client = new HttpClient();
					string url = pullsURL.Replace("{/number}","");
                    client.Timeout = TimeSpan.FromSeconds(30);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
					List<RepositoriesPullModel> a  = JsonConvert.DeserializeObject<List<RepositoriesPullModel>>(responseBody);
                    //RepositoriesListViews.ItemsSource = model;
					//List<RepositoriesPullModel> a= JsonConvert.DeserializeObject<List<RepositoriesPullModel>>(responseBody);
					//model = JsonConvert.DeserializeObject<RepositoriesPullModel>(responseBody);
					RepositoriesPullListViews.ItemsSource = a;
                    
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }


		public async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			var contact = e.SelectedItem as RepositoriesPullModel;
			await Navigation.PushModalAsync(new RepositoryDetails(contact.Html_url));

		}
	}
}
