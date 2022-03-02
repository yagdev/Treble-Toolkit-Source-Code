using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Media;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for PMFlash.xaml
    /// </summary>
    public partial class PMFlash : Page
    {
        public PMFlash()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
            Thread thread3 = new Thread(CheckPhone);
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
            Uri uri = new Uri("PMFinished.xaml", UriKind.Relative);
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
        private void Flash()
        {
            String command = @"/C adb.exe sideload PM.zip & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void CheckPhone()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C fastboot.exe devices";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output4 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (output4.Contains("fastboot") == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneStatus2.Content = "Fastboot";
                });
            }
            else
            {
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = "CMD.exe";
                startInfo.Arguments = "/C adb.exe get-state";
                startInfo.CreateNoWindow = true;
                process.StartInfo = startInfo;
                process.Start();
                string output3 = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (output3.Contains("device") == true)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneStatus2.Content = "ADB";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneStatus2.Content = "Device Not Detected. Please retry.";
                    });
                }
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                }
            });
        }
    }
}
