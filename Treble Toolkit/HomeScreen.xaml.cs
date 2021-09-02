using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        public HomeScreen()
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
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = "CMD.exe";
                    startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir GSI & mkdir TWRP & mkdir boot & cd GSI & ren *.img system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd TWRP & ren *.img twrp.img";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
                    string BootIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "boot", "boot.img");
                    string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
                    if (File.Exists(GSI))
                    {
                        GSIFileLabel.Content = "Detected";
                    }
                    else
                    {
                        GSIFileLabel.Content = "Not Detected";
                    }
                    if (File.Exists(BootIMG))
                    {
                        BootFileLabel.Content = "Detected";
                    }
                    else
                    {
                        BootFileLabel.Content = "Not Detected";
                    }
                    if (File.Exists(TWRPIMG))
                    {
                        TWRPFileLabel.Content = "Detected";
                    }
                    else
                    {
                        TWRPFileLabel.Content = "Not Detected";
                    }
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
                            cc.Content = "Yes (ADB/Fastboot)";
                        }
                        else
                        {
                            cc.Content = "Yes (ADB)";
                        }
                    }
                    else
                    {
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
                            cc.Content = "Yes (Fastboot)";
                        }
                        else
                        {
                            cc.Content = "No";
                        }
                    }
                }, DispatcherPriority.Normal);
            });

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIAFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void CompatibleDevices_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("VendorFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Format_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FormatPartitions.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ABButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FlashButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BootButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPBoot.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBootloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FreeCMD_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("CMD.exe");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.UseShellExecute = false;
                    startInfo.FileName = "CMD.exe";
                    startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir GSI & mkdir TWRP & mkdir boot & cd GSI & ren *.img system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd TWRP & ren *.img twrp.img";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
                    string BootIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "boot", "boot.img");
                    string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
                    if (File.Exists(GSI))
                    {
                        GSIFileLabel.Content = "Detected";
                    }
                    else
                    {
                        GSIFileLabel.Content = "Not Detected";
                    }
                    if (File.Exists(BootIMG))
                    {
                        BootFileLabel.Content = "Detected";
                    }
                    else
                    {
                        BootFileLabel.Content = "Not Detected";
                    }
                    if (File.Exists(TWRPIMG))
                    {
                        TWRPFileLabel.Content = "Detected";
                    }
                    else
                    {
                        TWRPFileLabel.Content = "Not Detected";
                    }
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
                            if (GridMain.ActualWidth <= 530)
                            {
                                cc.Content = "Yes (A/F)";
                            }
                            else
                            {
                                cc.Content = "Yes (ADB/Fastboot)";
                            }
                        }
                        else
                        {
                            cc.Content = "Yes (ADB)";
                        }
                    }
                    else
                    {
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
                            if (GridMain.ActualWidth <= 530)
                            {
                                cc.Content = "Yes (F)";
                            }
                            else
                            {
                                cc.Content = "Yes (Fastboot)";
                            }
                        }
                        else
                        {
                            cc.Content = "No";
                        }
                    }
                }, DispatcherPriority.Normal);
            });
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (GridMain.ActualWidth <= 400)
            {
                BootmgTitle.Content = "Boot Img";
                TWRPImgTitle.Content = "TWRP Img";
            }
            else
            {
                BootmgTitle.Content = "Boot Image";
                TWRPImgTitle.Content = "TWRP Image";
            }
            if(GridMain.ActualWidth <= 530)
            {
                ConDev.Content = "Connected";
                if(cc.Content == "Yes (ADB/Fastboot)") 
                {
                    cc.Content = "Yes (A/F)";
                } else 
                {
                    if (cc.Content == "Yes (Fastboot)")
                    {
                        cc.Content = "Yes (F)";
                    }
                    else
                    {
                       
                    }
                }
            }
            else
            {
                ConDev.Content = "Connected Device";
                if (cc.Content == "Yes (A/F)")
                {
                    cc.Content = "Yes (ADB/Fastboot)";
                }
                else 
                {
                    if (cc.Content == "Yes (F)")
                    {
                        cc.Content = "Yes (Fastboot)";
                    }
                }
            }
        }
    }
}
