using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace PullRequestChecker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListaRepositorios : Page
    {
        public ListaRepositorios()
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
            /*Class1 batata1 = new Class1();
            batata1.Repositorio = "batata";
            batata1.Idade = 10;
            resultList.Items.Add(batata1);*/
            resultList.Items.Add("batata");
            resultList.Items.Add("batata");
            resultList.Items.Add("batata");
            resultList.Items.Add("batata");
            resultList.Items.Add("batata");
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RepositorioPullRequests));
        }
    }
}

/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestChecker
{
    class Class1
    {
        public String Repositorio { get; set; }
        public int Idade { get; set; }
    }
}

     */
