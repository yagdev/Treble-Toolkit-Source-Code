using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
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
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ToggleTransparency_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TransparentTheme_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CMDvis(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrivacyClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PrivacyAndDataManagement.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DebugClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("DebugInfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void TransparencyClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TransparencyAndEffects.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
