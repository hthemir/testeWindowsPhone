using Model;
using Service;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace GitAPI.Views
{
    public sealed partial class LanguageSearchResult : Page
    {
        int page { get; set; }
        string linguagem { get; set; }

        public LanguageSearchResult()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            page = 1;
            linguagem = e.Parameter.ToString();
            string url = "https://api.github.com/search/repositories?q=language:" + linguagem +"&sort=stars&page=1";
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
        }

        private void resultList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mySelectedItem = resultList.SelectedItem as Repository;
            Frame.Navigate(typeof(RepositorySearchResult), mySelectedItem);
        }

        private void loadMoreResults_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            page += 1;
            string url = "https://api.github.com/search/repositories?q=language:" + linguagem + "&sort=stars&page=" + page;
            fillScreen(url);
        }
    }
}
