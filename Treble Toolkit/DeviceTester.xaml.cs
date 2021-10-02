using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;

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
            NotDetected.Visibility = Visibility.Hidden;
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
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
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
                        dis.Invoke(() =>
                        {
                            Model.Content = output2;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SupportsTreble.Content = output3;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            AndroidVersion.Content = output4;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SDKVersion.Content = output5;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SecurityPatch.Content = output6;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            IsEncrypted.Content = output8;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SN.Content = output9;
                        });
                    });                    
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
                        dis.Invoke(() =>
                        {
                            VendorSDK.Content = output10;
                        });
                    });
                    Task.Run(() =>
                    {
                        dis.Invoke(() =>
                        {
                            if (output3.Contains("true") == true)
                            {
                                SupportsTreble.Content = "Yes";
                            }
                            else
                            {
                                SupportsTreble.Content = "No";
                            }
                            if (output8.Contains("encrypted") == true)
                            {
                                IsEncrypted.Content = "Yes";
                            }
                            else
                            {
                                IsEncrypted.Content = "No";
                            }
                            if (output2.Length == 0)
                            {
                                Model.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
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
                            if (output4.Length == 0)
                            {
                                AndroidVersion.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
                            if (output5.Length == 0)
                            {
                                SDKVersion.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
                            if (output6.Length == 0)
                            {
                                SecurityPatch.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
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
                            if (output9.Length == 0)
                            {
                                SN.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
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
                }, DispatcherPriority.Normal);
            });
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            NotDetected.Visibility = Visibility.Hidden;
            Warning.Visibility = Visibility.Visible;
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
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
                        dis.Invoke(() =>
                        {
                            Model.Content = output2;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SupportsTreble.Content = output3;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            AndroidVersion.Content = output4;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SDKVersion.Content = output5;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SecurityPatch.Content = output6;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            IsEncrypted.Content = output8;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            SN.Content = output9;
                        });
                    });
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
                        dis.Invoke(() =>
                        {
                            VendorSDK.Content = output10;
                        });
                    });
                    Task.Run(() =>
                    {
                        dis.Invoke(() =>
                        {
                            if (output3.Contains("true") == true)
                            {
                                SupportsTreble.Content = "Yes";
                            }
                            else
                            {
                                SupportsTreble.Content = "No";
                            }
                            if (output8.Contains("encrypted") == true)
                            {
                                IsEncrypted.Content = "Yes";
                            }
                            else
                            {
                                IsEncrypted.Content = "No";
                            }
                            if (output2.Length == 0)
                            {
                                Model.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
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
                            if (output4.Length == 0)
                            {
                                AndroidVersion.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
                            if (output5.Length == 0)
                            {
                                SDKVersion.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
                            if (output6.Length == 0)
                            {
                                SecurityPatch.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
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
                            if (output9.Length == 0)
                            {
                                SN.Content = "Unable to retrieve";
                                NotDetected.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                Warning.Visibility = Visibility.Hidden;
                            }
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
                }, DispatcherPriority.Normal);
            });
        }

        private void grid_Initialized(object sender, EventArgs e)
        {
            
        }

        private void SupportsTreble_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
