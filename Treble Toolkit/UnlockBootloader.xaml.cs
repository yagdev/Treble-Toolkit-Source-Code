using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;

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
            ReportLabel.Visibility = Visibility.Hidden;
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
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
            String command = @"/C adb.exe reboot-bootloader & fastboot.exe oem unlock & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            Uri uri = new Uri("UnlockedBootloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void HW_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("BTULHW.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
