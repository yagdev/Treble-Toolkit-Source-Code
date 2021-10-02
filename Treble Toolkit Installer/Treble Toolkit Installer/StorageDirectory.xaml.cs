using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;

namespace Treble_Toolkit_Installer
{
    /// <summary>
    /// Interaction logic for StorageDirectory.xaml
    /// </summary>
    public partial class StorageDirectory : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        public StorageDirectory()
        {
            InitializeComponent();
            GridMain.Opacity = 0;
            Grid r = (Grid)GridMain;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Start.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Uri uri = new Uri("CurrentDirectory.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Lbl.Content = "An internet connection is needed for this. Please connect to the internet and try again.";
                Lbl.FontSize = 10;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Uri uri = new Uri("AppData.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Lbl.Content = "An internet connection is needed for this. Please connect to the internet and try again.";
                Lbl.FontSize = 10;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Uri uri = new Uri("ProgramFiles.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Lbl.Content = "An internet connection is needed for this. Please connect to the internet and try again.";
                Lbl.FontSize = 10;
            }
        }
    }
}
