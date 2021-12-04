using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for DeviceTester.xaml
    /// </summary>
    public partial class DeviceTester : Page
    {
        public DeviceTester()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Check1);
            thread2.Start();
            Thread thread3 = new Thread(Check2);
            thread3.Start();
            Thread thread4 = new Thread(Check3);
            thread4.Start();
            Thread thread5 = new Thread(Check4);
            thread5.Start();
            Thread thread6 = new Thread(Check5);
            thread6.Start();
            Thread thread7 = new Thread(Check6);
            thread7.Start();
            Thread thread8 = new Thread(Check7);
            thread8.Start();
            Thread thread9 = new Thread(Check8);
            thread9.Start();
            Thread thread10 = new Thread(UpdateUI);
            thread10.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            Thread thread2 = new Thread(Check1);
            thread2.Start();
            Thread thread3 = new Thread(Check2);
            thread3.Start();
            Thread thread4 = new Thread(Check3);
            thread4.Start();
            Thread thread5 = new Thread(Check4);
            thread5.Start();
            Thread thread6 = new Thread(Check5);
            thread6.Start();
            Thread thread7 = new Thread(Check6);
            thread7.Start();
            Thread thread8 = new Thread(Check7);
            thread8.Start();
            Thread thread9 = new Thread(Check8);
            thread9.Start();
            Thread thread10 = new Thread(UpdateUI);
            thread10.Start();
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
        private void Check1()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.model";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output2 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    Model.Content = output2;
                    if (output2.Length == 0)
                    {
                        Model.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check2()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.treble.enabled";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SupportsTreble.Content = output3;
                    if (output3.Contains("true") == true)
                    {
                        SupportsTreble.Content = "Yes";
                    }
                    else
                    {
                        SupportsTreble.Content = "No";
                    }
                    if (output3.Length == 0)
                    {
                        SupportsTreble.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });

        }
        private void Check3()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.release";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output4 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    AndroidVersion.Content = output4;
                    if (output4.Length == 0)
                    {
                        AndroidVersion.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check4()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output5 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SDKVersion.Content = output5;
                    if (output5.Length == 0)
                    {
                        SDKVersion.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check5()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.build.version.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output6 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SecurityPatch.Content = output6;
                    if (output6.Length == 0)
                    {
                        SecurityPatch.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check6()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.crypto.state";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output8 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (output8.Contains("encrypted") == true)
                    {
                        IsEncrypted.Content = "Yes";
                    }
                    else
                    {
                        IsEncrypted.Content = "No";
                    }
                    if (output8.Length == 0)
                    {
                        IsEncrypted.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check7()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.serialno";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output9 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SN.Content = output9;
                    if (output9.Length == 0)
                    {
                        SN.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void Check8()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output10 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    VendorSDK.Content = output10;
                    if (output10.Length == 0)
                    {
                        VendorSDK.Content = "Unable to retrieve";
                        NotDetected.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Hidden;
                    }
                });
            });
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                NotDetected.Visibility = Visibility.Hidden;
            });
        }
    }
}
