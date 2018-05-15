using System;
using System.Collections.Generic;

using Xamarin.Forms;
using repositories.Service;
using Plugin.Connectivity;
using System.Threading.Tasks;
using Refit;

namespace repositories.View
{
    public partial class RepositoriesList : ContentPage
    {
        public RepositoriesList()
        {
            InitializeComponent();

			GitHubService git = new GitHubService();
			var isConnected = CrossConnectivity.Current.IsConnected;

			if (isConnected)   
				git.repositoryList();
			else
			    DisplayAlert("Error", "Err", "ok");
        }

	
    }
}
