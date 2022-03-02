using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Sideloader.xaml
    /// </summary>
    public partial class Sideloader : Page
    {
        public Sideloader()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
            Thread thread3 = new Thread(Prepare);
            thread3.Start();
            Thread thread4 = new Thread(UpdateUI);
            thread4.Start();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Flash);
            thread.Start();
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
        private void SupportLock()
        {
            if (Environment.OSVersion.Version.Build <= 9)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Report Bug";
                });
            }
        }
        private void Prepare()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren * sideload.zip";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void Flash()
        {
            if (File.Exists("../Place_Files_Here/Sideload/sideload.zip"))
            {
                String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren *.zip sideload.zip & cd .. & cd .. & cd assets & adb.exe sideload ../Place_Files_Here/Sideload/sideload.zip & wmic process where name='adb.exe' delete";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                this.Dispatcher.Invoke(() =>
                {
                    Uri uri = new Uri("SideloadFinished.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Uri uri = new Uri("SideloaderPickFile.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
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
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
    }
}
