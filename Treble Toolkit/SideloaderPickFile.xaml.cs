using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NHotkey;
using System.Windows.Input;
using NHotkey.Wpf;
using System.Windows.Media;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for SideloaderPickFile.xaml
    /// </summary>
    public partial class SideloaderPickFile : Page
    {
        public SideloaderPickFile()
        {
            InitializeComponent();
            HotkeyManager.Current.AddOrReplace("Increment", Key.D, ModifierKeys.Control, OnIncrement);
            Debug1.Visibility = Visibility.Hidden;
            DbgRct1.Visibility = Visibility.Hidden;
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Prepare);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Sideloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Flash);
            thread.Start();
        }

        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren *.zip sideload.zip & cd .. & cd .. & cd assets & adb.exe sideload ../Place_Files_Here/Sideload/sideload.zip & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            Uri uri = new Uri("SideloadFinished.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void OnIncrement(object sender, HotkeyEventArgs e)
        {
            Debug1.Visibility = Visibility.Visible;
            DbgRct1.Visibility = Visibility.Visible;
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
        private void Prepare()
        {
            this.Dispatcher.Invoke(() =>
            {
                Debug1.Visibility = Visibility.Hidden;
            });
            String command = @"/C cd .. & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren * sideload.zip";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void Flash()
        {
            String command5 = @"/C cd .. & cd Place_Files_Here & cd Sideload & ren * sideload.zip";
            ProcessStartInfo cmdsi5 = new ProcessStartInfo("cmd.exe");
            cmdsi5.Arguments = command5;
            Process cmd5 = Process.Start(cmdsi5);
            cmd5.WaitForExit();
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
                String command6 = @"/C cd .. & cd Place_Files_Here & cd Sideload & start .";
                ProcessStartInfo cmdsi6 = new ProcessStartInfo("cmd.exe");
                cmdsi6.Arguments = command6;
                Process cmd6 = Process.Start(cmdsi6);
                cmd6.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd Sideload & ren * sideload.zip";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-light.png"));
                }
            });
        }
    }
}
