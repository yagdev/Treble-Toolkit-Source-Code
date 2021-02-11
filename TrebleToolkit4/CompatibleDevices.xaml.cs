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

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for CompatibleDevices.xaml
    /// </summary>
    public partial class CompatibleDevices : Page
    {
        public CompatibleDevices()
        {
            InitializeComponent();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("OP6.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SXXZ2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SX5.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("A12018.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HuaweiMate10Lite.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
