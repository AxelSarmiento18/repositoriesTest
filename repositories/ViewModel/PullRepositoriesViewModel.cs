using System;
using repositories.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using repositories.Service;
using System.Threading.Tasks;
using System.Linq;
using Plugin.Connectivity;

namespace repositories.ViewModel
{
	public class PullRepositoriesViewModel : INotifyPropertyChanged
	{
		public PullRepositoriesViewModel(string pullUrl)
		{
			
			if (DoIHaveInternet() == true)
				InitializationDataAsync(pullUrl);
			else
				Console.Write("No internet connection");
		}



		private List<RepositoriesPullModel> _repositoriesPullList { get; set; }
		private string _pullURL { get; set; }
		private int _repoOpen { get; set; }
		private int _repoClose { get; set; }
		private bool _isBusy { get; set; }

		public int repoOpen { get { return _repoOpen; } set { _repoOpen = value; OnPropertyChanged(); } }
		public int repoClose { get { return _repoClose; } set { _repoClose = value; OnPropertyChanged(); } }
		public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged(); } }
		public string pullURL { get { return _pullURL; } set { _pullURL = value; OnPropertyChanged(); } }

		public List<RepositoriesPullModel> RepositoriesPullList
		{
			get { return _repositoriesPullList; }
			set
			{
				_repositoriesPullList = value;

				OnPropertyChanged();
			}

		}

		private async Task InitializationDataAsync(string pullUrl)
		{
			IsBusy = true;
			var gitHubService = new GitHubService();
			RepositoriesPullList = await gitHubService.GetPullRepositoriesAsync(pullUrl);
			repoOpen = RepositoriesPullList.Count(x => x.State == "open");
			repoClose = RepositoriesPullList.Count(x => x.State == "closed");
			IsBusy = false;

		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public bool DoIHaveInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }
	}
}




