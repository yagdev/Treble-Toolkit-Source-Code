﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for UnlockBootloader.xaml
    /// </summary>
    public partial class UnlockBootloader : Page
    {
        public UnlockBootloader()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Next);
            thread.Start();
        }

        private void HW_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("BTULHW.xaml", UriKind.Relative);
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
            this.Dispatcher.Invoke(() =>
            {
                ReportLabel.Visibility = Visibility.Hidden;
            });
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
        private void Next()
        {
            String command = @"/C adb.exe reboot-bootloader & fastboot.exe oem unlock & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("UnlockedBootloader.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
    }
}
