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
using System.Windows.Media.Effects;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckPhone);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
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
                Thread thread = new Thread(ADB);
                thread.Start();
            }
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
                Install.Content = "Download Finished";
            });
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
            Thread thread2 = new Thread(CheckPhone);
            thread2.Start();
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
                        PhoneStatus.Content = "Device Detected";
                        PhoneStatus2.Content = "You're all set!";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneStatus.Content = "Device Not Detected";
                        PhoneStatus2.Content = "Uh oh, something might be wrong here...";
                    });
                }
            }
            this.Dispatcher.Invoke(() =>
            {
                if (PhoneStatus.Content == "Device Not Detected")
                {
                    DropShadowEffect myDropShadowEffect = new DropShadowEffect();

                    // Set the color of the shadow to Black.
                    Color myShadowColor = new Color();
                    myShadowColor.A = 255; // Note that the alpha value is ignored by Color property. 
                                           // The Opacity property is used to control the alpha.
                    myShadowColor.B = 0;
                    myShadowColor.G = 0;
                    myShadowColor.R = 255;
                    myDropShadowEffect.Direction = 0;
                    myDropShadowEffect.ShadowDepth = 0;

                    myDropShadowEffect.Color = myShadowColor;
                    GSIRectangle.Effect = myDropShadowEffect;
                }
                else
                {
                    GSIRectangle.Effect = DeviceSpecificFeatures_Copy1.Effect;
                }
            });
        }
        private void ADB()
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
                    this.Dispatcher.Invoke(() =>
                    {
                        Install.Content = "Downloading Wizard...";
                        status_pgr.Visibility = Visibility.Visible;
                    });
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
                    this.Dispatcher.Invoke(() =>
                    {
                        Install.Content = "You need an internet connection for this...";
                    });
                }
            }
        }
        private void UpdateUI()
        {
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
