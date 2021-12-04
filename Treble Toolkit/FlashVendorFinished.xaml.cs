﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para FlashVendorFinished.xam
    /// </summary>
    public partial class FlashVendorFinished : Page
    {
        public FlashVendorFinished()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("VendorFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(KillADB);
            thread.Start();
            Application.Current.Shutdown();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
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
        private void KillADB()
        {
            String command = @"/C wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
    }
}
