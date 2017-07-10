using Model;
using Service;
using System.Collections.Generic;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Xaml;

namespace GitAPI.Views
{
    public sealed partial class RepositorySearchResult : Page
    {
        public RepositorySearchResult()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            this.Unloaded += Screen_Unloaded;
        }

        private void Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Repository rep = e.Parameter as Repository;
            string url = "https://api.github.com/repos/" + rep.owner.login + "/" + rep.name + "/pulls";
            fillScreen(url);
        }

        public async void fillScreen(string url)
        {
            var result = await Client.GetPullRequests(url);
            List<PullRequest> items = result;

            for (int i = 0; i < items.Count; i++)
            {
                resultList.Items.Add(items[i]);
            }
        }
    }
}
