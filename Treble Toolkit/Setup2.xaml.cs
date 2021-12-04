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
using System.Windows.Media.Animation;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Diagnostics;
using System.Windows.Diagnostics;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Setup2.xaml
    /// </summary>
    public partial class Setup2 : Page
    {
        public Setup2()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Check);
            thread2.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Check);
            thread.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup3.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FixConnectionPhoneStep1.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(RefreshADB);
            thread.Start();
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(RefreshFastboot);
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
        private void Check()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
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
                    ADBStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Not Detected";
                });
            }
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
                    FastbootStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    FastbootStatus.Content = "Not Detected";
                });
            }
            if (output4.Contains("fastboot") == false && output3.Contains("device") == false)
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneWarning.Visibility = Visibility.Visible;
                    PhoneWarningTxt1.Visibility = Visibility.Visible;
                    PhoneWarningTxt2.Visibility = Visibility.Visible;
                    PhoneWarningBtn.Visibility = Visibility.Visible;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneWarning.Visibility = Visibility.Hidden;
                    PhoneWarningTxt1.Visibility = Visibility.Hidden;
                    PhoneWarningTxt2.Visibility = Visibility.Hidden;
                    PhoneWarningBtn.Visibility = Visibility.Hidden;
                });
            }
        }
        private void RefreshADB()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
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
                    ADBStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Not Detected";
                });
            }
            this.Dispatcher.Invoke(() =>
            {
                if (ADBStatus.Content == "Not Detected" && FastbootStatus.Content == "Not Detected")
                {
                    PhoneWarning.Visibility = Visibility.Visible;
                    PhoneWarningTxt1.Visibility = Visibility.Visible;
                    PhoneWarningTxt2.Visibility = Visibility.Visible;
                    PhoneWarningBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    PhoneWarning.Visibility = Visibility.Hidden;
                    PhoneWarningTxt1.Visibility = Visibility.Hidden;
                    PhoneWarningTxt2.Visibility = Visibility.Hidden;
                    PhoneWarningBtn.Visibility = Visibility.Hidden;
                }
            });
        }
        private void RefreshFastboot()
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
                    FastbootStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    FastbootStatus.Content = "Not Detected";
                });
            }
            this.Dispatcher.Invoke(() =>
            {
                if (ADBStatus.Content == "Not Detected" && FastbootStatus.Content == "Not Detected")
                {
                    PhoneWarning.Visibility = Visibility.Visible;
                    PhoneWarningTxt1.Visibility = Visibility.Visible;
                    PhoneWarningTxt2.Visibility = Visibility.Visible;
                    PhoneWarningBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    PhoneWarning.Visibility = Visibility.Hidden;
                    PhoneWarningTxt1.Visibility = Visibility.Hidden;
                    PhoneWarningTxt2.Visibility = Visibility.Hidden;
                    PhoneWarningBtn.Visibility = Visibility.Hidden;
                }
            });
        }
    }
}
