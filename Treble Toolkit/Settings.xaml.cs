using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
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
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-security-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-security-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                }
            });
        }

        private void Compatibility(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibilitySettings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
