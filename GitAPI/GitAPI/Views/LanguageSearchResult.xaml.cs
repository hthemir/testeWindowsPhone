using Model;
using Service;
using System.Collections.Generic;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace GitAPI.Views
{
    public sealed partial class LanguageSearchResult : Page
    {
        int page { get; set; }
        string linguagem { get; set; }
        bool incall { get; set; }

        public LanguageSearchResult()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            headerBar.BackButton_Tapped += BackButton_Clicked;
            this.Unloaded += Screen_Unloaded;

        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void Screen_Unloaded(object sender, RoutedEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            headerBar.BackButton_Tapped -= BackButton_Clicked;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BusyProgressRing.IsActive = true;
            page = 1;
            linguagem = e.Parameter.ToString();
            headerBar.Title = linguagem;
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
            incall = false;
            BusyProgressRing.IsActive = false;
        }

        private void resultList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mySelectedItem = resultList.SelectedItem as Repository;
            Frame.Navigate(typeof(RepositorySearchResult), mySelectedItem);
        }

        public static ScrollViewer GetScrollViewer(DependencyObject depOjb)
        {
            if (depOjb is ScrollViewer)
                return depOjb as ScrollViewer;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depOjb); i++)
            {
                var child = VisualTreeHelper.GetChild(depOjb, i);
                var result = GetScrollViewer(child);
                if (result != null)
                    return result;
            }
            return null;
        }

        private void resultList_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollViewer viewer = GetScrollViewer(this.resultList);
            viewer.ViewChanged += ListViewChanged;
        }

        private void ListViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer view = (ScrollViewer)sender;
            double progress = view.VerticalOffset / view.ScrollableHeight;
            if (progress > 0.7 && !incall)
            {
                incall = true;
                page += 1;
                string url = "https://api.github.com/search/repositories?q=language:" + linguagem + "&sort=stars&page=" + page;
                fillScreen(url);
            }

        }
    }
}
