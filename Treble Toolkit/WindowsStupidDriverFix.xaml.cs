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
using System.Threading;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(InstallADB);
            thread.Start();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value = e.ProgressPercentage;
            });
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Visibility = Visibility.Hidden;
                DeviceSpecificFeatures_Copy1.Content = "Download Finished";
            });
            String command = @"/C ren ADBDriverInstaller.txt ADBDriverInstaller.exe";
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
        private void InstallADB()
        {
            using (WebClient wc = new WebClient())
            {
                string DownloadCheck = System.IO.Path.Combine(Environment.CurrentDirectory, "ADBDriverInstaller.exe");
                string DownloadPath = System.IO.Path.Combine(Environment.CurrentDirectory, "ADBDriverInstaller.txt");
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
                        this.Dispatcher.Invoke(() =>
                        {
                            DeviceSpecificFeatures_Copy1.Content = "Downloading Wizard...";
                            status_pgr.Visibility = Visibility.Visible;
                        });
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            WebClient webClient = new WebClient();
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                            webClient.DownloadFileAsync(new Uri("https://4e528933-793b-408d-ade0-2543f7e974c3.filesusr.com/ugd/3c5973_bd5f5055983b418b9ec8a45c0930aa9d.txt?dn=ADBDriverInstaller.txt"), DownloadPath);
                        }
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            DeviceSpecificFeatures_Copy1.Content = "You need an internet connection for this...";
                        });
                    }
                }
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Visibility = Visibility.Hidden;
            });
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-usb-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-usb-light.png"));
                }
            });
        }
    }
}
