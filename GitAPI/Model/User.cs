using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Model
{
   public class User
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public ImageSource image
        {
            get
            {
                return new BitmapImage(new Uri(avatar_url, UriKind.Absolute));
            }
        }
    }
}
