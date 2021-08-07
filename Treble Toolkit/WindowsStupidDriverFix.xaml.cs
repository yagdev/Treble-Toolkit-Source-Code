using System;
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
using System.Net;
using System.ComponentModel;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for WindowsStupidDriverFix.xaml
    /// </summary>
    public partial class WindowsStupidDriverFix : Page
    {
        public WindowsStupidDriverFix()
        {
            InitializeComponent();
            status_pgr.Visibility = Visibility.Hidden;
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
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                string DownloadCheck = System.IO.Path.Combine(Environment.CurrentDirectory, "ADBDriverInstaller.exe");
                if (File.Exists(DownloadCheck))
                {
                    String command = @"/C ADBDriverInstaller.exe";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }
                else
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {
                        DeviceSpecificFeatures_Copy1.Content = "Downloading Wizard...";
                        status_pgr.Visibility = Visibility.Visible;
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            WebClient webClient = new WebClient();
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                            webClient.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1M3phIYwitJ0QrKo44adlHA6Las92OoSN"), DownloadCheck);
                        }
                    }
                    else
                    {
                        DeviceSpecificFeatures_Copy1.Content = "You need an internet connection for this...";
                    }
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            status_pgr.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            status_pgr.Visibility = Visibility.Hidden;
            DeviceSpecificFeatures_Copy1.Content = "Download Finished";
            String command = @"/C ADBDriverInstaller.exe";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
