using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using repositories.Model;
using repositories.ViewModel;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace repositories.View
{
	public partial class RepositoriesPull : ContentPage
	{

		public RepositoriesPull(RepositoriesModel.Item model)
		{
			InitializeComponent();
			Title = model.Full_Name;
			this.BindingContext = new PullRepositoriesViewModel(model.Pulls_Url);
            
		}


		public async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			var contact = e.SelectedItem as RepositoriesPullModel;
			await Navigation.PushModalAsync(new RepositoryDetails(contact.Html_url));
		}
	}
}
