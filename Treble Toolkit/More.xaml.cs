using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Media;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
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
            Uri uri = new Uri("DeviceTester.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FVButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibleDevices.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void StupidWindows(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("WindowsStupidDriverFix.xaml", UriKind.Relative);
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
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flashing-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-down-dark.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flashing-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-down-light.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
    }
}
