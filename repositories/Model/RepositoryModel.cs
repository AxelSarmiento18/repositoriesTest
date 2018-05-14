using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace repositories.Model
{
	public class RepositoryModel:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string propertyName = ""){
			PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
		}

		private string id;

		public string Id
		{

			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged();
			}

		}

		private string repositoryName;

		public string RepositoryName
        {

			get { return repositoryName; }
			set { repositoryName = value; OnPropertyChanged(); }

        }

		private string repositoryDescription;

		public string RepositoryDescription
        {

			get { return repositoryDescription; }
			set { repositoryDescription = value; OnPropertyChanged();}

        }

		private string authorAvatar;

		public string AuthorAvatar{
			get { return authorAvatar; }
			set { authorAvatar = value; OnPropertyChanged();}
		}

		private string authorFullName;

		public string AuthorFullName
        {
			get { return authorFullName; }
			set { authorFullName = value; OnPropertyChanged();}
        }

		private string forksQuantity;

		public string ForksQuantity
        {
			get { return forksQuantity; }
			set { forksQuantity = value; OnPropertyChanged();}
        }

		private string starsQuantity;



		public string StarsQuantity
        {
			get { return starsQuantity; }
			set { starsQuantity = value; OnPropertyChanged();}
        }

		private bool isBusy;

		public bool IsBusy
        {
			get { return isBusy = false; }
			set { isBusy = value; OnPropertyChanged(); }
        }

	
	}
}
