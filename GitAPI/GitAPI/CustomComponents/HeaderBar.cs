using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace GitAPI.CustomComponents
{
    public sealed class HeaderBar : Control
    {
        Grid __layoutRoot;
        TextBlock __title;
        Image __imageBackButton;

        public HeaderBar()
        {
            this.DefaultStyleKey = typeof(HeaderBar);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            __layoutRoot = GetChild<Grid>(this, "layoutRoot") as Grid;
            __title = __layoutRoot.FindName("tbHeaderTitle") as TextBlock;
            __imageBackButton = __layoutRoot.FindName("imgBackButton") as Image;

            __imageBackButton.Tapped += __imageBackButtonTapped;

            try { __title.Text = Title; }
            catch { __title.Text = String.Empty; }

            try { __layoutRoot.Background = BarColor; }
            catch { }

        }

        public EventHandler BackButton_Tapped;
        private void __imageBackButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            EventHandler eh = BackButton_Tapped;
            if (eh != null)
                eh(this, new EventArgs());
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public SolidColorBrush BarColor
        {
            get { return (SolidColorBrush)GetValue(BarColorProperty); }
            set { SetValue(BarColorProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(HeaderBar),
            new PropertyMetadata(0));

        public static readonly DependencyProperty BarColorProperty = DependencyProperty.Register(
            "BarColor",
            typeof(SolidColorBrush),
            typeof(HeaderBar),
            new PropertyMetadata(0));

        public static DependencyObject GetChild<T>(DependencyObject depOjb, string ctrlName)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depOjb); i++)
            {
                var child = VisualTreeHelper.GetChild(depOjb, i);
                FrameworkElement fe = child as FrameworkElement;
                if (fe == null)
                    return null;
                if (child is T && fe.Name == ctrlName)
                    return child;
                else
                {
                    DependencyObject next = GetChild<T>(child, ctrlName);
                    if (next != null)
                        return next;
                }
            }
            return null;
        }
    }


}
