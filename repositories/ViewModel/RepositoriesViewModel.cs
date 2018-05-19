using System;
using System.ComponentModel;
using repositories.Model;
using System.Runtime.CompilerServices;
using repositories.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace repositories.ViewModel
{
	public class RepositoriesViewModel : INotifyPropertyChanged
	{
		private List<RepositoriesModel.Item> _repositoriesListM { get; set; }
		public List<RepositoriesModel.Item> Items { get; set; }

		public RepositoriesViewModel()
		{
			
			//var git = new GitHubService();
			//RepositoriesListM = git.GetRepositories();
			InitializationDataAsync();
			Items = _repositoriesListM;
		}

		public List<RepositoriesModel.Item> RepositoriesListM
		{
			get { return _repositoriesListM; }
			set
			{
				_repositoriesListM = value;
				OnPropertyChanged();
			}

		}

		public List<RepositoriesModel.Item> SearchRepository(){

			List<RepositoriesModel.Item> Items = new List<RepositoriesModel.Item>();
			Items = RepositoriesListM;
			return Items;
		}
  

		private async Task InitializationDataAsync()
		{
			var gitHubService = new GitHubService();
			RepositoriesListM = await gitHubService.GetRepositoriesAsync();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
