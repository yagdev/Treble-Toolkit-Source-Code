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
    /// Interaction logic for FixConnectionPhoneStep2.xaml
    /// </summary>
    public partial class FixConnectionPhoneStep2 : Page
    {
        public FixConnectionPhoneStep2()
        {
            InitializeComponent();
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
                PhoneStatus.Content = "Detected";
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
                    PhoneStatus.Content = "Detected";
                }
                else
                {
                    PhoneStatus.Content = "Not Detected";
                }
            }
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
        }

        private void PreviousSolution(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FixConnectionPhoneStep1.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void InstallDrivers(object sender, RoutedEventArgs e)
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
                        Install.Content = "Downloading Wizard...";
                        status_pgr.Visibility = Visibility.Visible;
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            WebClient webClient = new WebClient();
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                            webClient.DownloadFileAsync(new Uri("https://4e528933-793b-408d-ade0-2543f7e974c3.filesusr.com/ugd/3c5973_bd5f5055983b418b9ec8a45c0930aa9d.txt?dn=ADBDriverInstaller.txt"), DownloadCheck);
                        }
                    }
                    else
                    {
                        Install.Content = "You need an internet connection for this...";
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
            Install.Content = "Download Finished";
            String command = @"/C ADBDriverInstaller.exe";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FixConnectionPhoneStep3.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
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
                PhoneStatus.Content = "Detected";
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
                    PhoneStatus.Content = "Detected";
                }
                else
                {
                    PhoneStatus.Content = "Not Detected";
                }
            }
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
        }
    }
}
