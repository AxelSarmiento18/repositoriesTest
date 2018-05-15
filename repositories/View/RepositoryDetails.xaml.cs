using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace repositories.View
{
    public partial class RepositoryDetails : ContentPage
    {
        public RepositoryDetails(string htmlUrl)
        {
            InitializeComponent();
			RWebView(htmlUrl);
        }

		public void RWebView(string URL){
			var browser = new WebView();
            browser.Source = URL;
			Content = browser;
		}
       

    }
}
