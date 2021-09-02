using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;

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
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {

            }
            else
            {
                GridMain.Opacity = 0;
                Grid r = (Grid)GridMain;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                r.BeginAnimation(Grid.OpacityProperty, animation);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
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

        private void DSF_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
