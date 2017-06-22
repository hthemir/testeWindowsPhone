using Model;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GitAPI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LanguageSearchResult : Page
    {
        public LanguageSearchResult()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = "https://api.github.com/search/repositories?q=language:" + e.Parameter.ToString() +"&sort=stars&page=1";
            fillScreen(url);
        }

        public async void fillScreen(string url)
        {
            var result = await Client.GetRepositores(url);
            List<Repository> items =  result;

            for (int i = 0; i < items.Count; i++)
            {
                resultList.Items.Add(items[i]);
            }

            /*Repository batata1 = new Repository();
            batata1.full_name = "batata1";
            batata1.description = "a primeira batata";
            resultList.Items.Add(batata1);
            Repository batata2 = new Repository();
            batata2.full_name = "batata2";
            batata2.description = "a segunda batata";
            resultList.Items.Add(batata2);*/
        }
        

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame.Navigate(typeof(RepositorySearchResult));
        }

        private void resultList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mySelectedItem = resultList.SelectedItem as Repository;
            Frame.Navigate(typeof(RepositorySearchResult), mySelectedItem);
        }
    }
}
