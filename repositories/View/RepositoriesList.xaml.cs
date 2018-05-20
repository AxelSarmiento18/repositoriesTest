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
using repositories.ViewModel;

namespace repositories.View
{
	public partial class RepositoriesList : ContentPage
	{
		GitHubService git = new GitHubService();
		RepositoriesModel model = new RepositoriesModel();
		RepositoriesViewModel r = new RepositoriesViewModel();
        
		public RepositoriesList()
		{
			InitializeComponent();
   
		}
  
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
			RepoList.BeginRefresh();
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
				RepoList.ItemsSource = r.RepositoriesListM;
            }

            else
            {
				RepoList.ItemsSource = r.RepositoriesListM.Where(x => x.Owner.Login.StartsWith(e.NewTextValue) || x.Name.StartsWith(e.NewTextValue));
            }

			RepoList.EndRefresh();
        }

		public async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			try{
				var contact = e.SelectedItem as RepositoriesModel.Item;
				await Navigation.PushAsync(new RepositoriesPull(contact));
			}catch(Exception ex){
				
			}


        

		}

	}
}
