using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
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
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void HP20L_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HuaweiP20Lite.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        //Threading starts here -- 5/11/2021@22:07, YAG-dev, 21.12+
        private void Animate()
        {
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    GridMain.Opacity = 0;
                    Grid r = (Grid)GridMain;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    r.BeginAnimation(Grid.OpacityProperty, animation);
                });
            }
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                }
            });
        }
    }
}
