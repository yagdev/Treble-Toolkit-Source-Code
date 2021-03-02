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

namespace Treble_Toolkit
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

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("OnePlus6.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void OP8_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("OnePlus8.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void OP8_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XP5_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SonyXperia5.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void XP1_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SonyXperia1.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void XZ2_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SonyXperiaXZ2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void A1_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Alcatel1.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void HM10L_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HuaweiMate10Lite.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
