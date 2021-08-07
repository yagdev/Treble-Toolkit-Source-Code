using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for AboutScreen.xaml
    /// </summary>
    public partial class AboutScreen : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        public AboutScreen()
        {
            InitializeComponent();
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {

            }
            else
            {
                
            }
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

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & start TrebleToolkitLauncher.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
        }

        private void DiscoverAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit/21-8-1";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void UpdateAbout_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void thirtytwobitclick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("32bitlifecycleinfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void AnniversaryEvent(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start TimeMachine.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
        }

        private void DeviceSpecificFeatures_Copy4_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("QSG.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
