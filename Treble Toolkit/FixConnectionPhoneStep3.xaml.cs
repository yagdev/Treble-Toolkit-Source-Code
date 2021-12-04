﻿using System;
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
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for FixConnectionPhoneStep3.xaml
    /// </summary>
    public partial class FixConnectionPhoneStep3 : Page
    {
        public FixConnectionPhoneStep3()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckPhone);
            thread2.Start();
            Thread thread3 = new Thread(SupportLock);
            thread3.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void PreviousSolution(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FixConnectionPhoneStep2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void InstallDrivers(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckPhone);
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
                    PhoneStatus.Content = "Detected";
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
                        PhoneStatus.Content = "Detected";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneStatus.Content = "Not Detected";
                    });
                }
            }
            this.Dispatcher.Invoke(() =>
            {
                if (PhoneStatus.Content == "Not Detected")
                {
                    PhoneWarning.Visibility = Visibility.Visible;
                    PhoneWarningTxt1.Visibility = Visibility.Visible;
                    PhoneWarningTxt2.Visibility = Visibility.Visible;
                }
                else
                {
                    PhoneWarning.Visibility = Visibility.Hidden;
                    PhoneWarningTxt1.Visibility = Visibility.Hidden;
                    PhoneWarningTxt2.Visibility = Visibility.Hidden;
                }
            });
        }
        private void SupportLock()
        {
            if (Environment.OSVersion.Version.Build <= 9)
            {
                this.Dispatcher.Invoke(() =>
                {
                    ReportBug.IsEnabled = false;
                    ReportBug.Content = "🔒 Report Bug";
                });
            }
        }
    }
}
