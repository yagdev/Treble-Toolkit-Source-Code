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
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for More.xaml
    /// </summary>
    public partial class More : Page
    {
        public More()
        {
            InitializeComponent();
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PMFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Sideloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void APButton_Click(object sender, RoutedEventArgs e)
        {
            AD.Content = "Testing...";
            Uri uri = new Uri("DeviceTester.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FVButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibleDevices.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
