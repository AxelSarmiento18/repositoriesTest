using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using repositories.Model;
using Xamarin.Forms;
using System.Linq;

namespace repositories.View
{
    public partial class RepositoriesPull : ContentPage
    {
		RepositoriesPullModel model = new RepositoriesPullModel();

        public RepositoriesPull(RepositoriesModel.Item model)
        {
            InitializeComponent();
			repositoryList(model.Pulls_Url);
			Title = model.Full_Name;


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
					int opens = a.Count( x => x.State == "open" );
					int close = a.Count(x => x.State == "close");

					openRepo.Text = $"{opens} opened";
					closeRepo.Text = $"/{close} closed";
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
