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
using System.IO;
using ChaseLabs.CLUpdate;
using System.Runtime.InteropServices;
using System.Net;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for UpdateCenter.xaml
    /// </summary>
    public partial class UpdateCenter : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public UpdateCenter()
        {
            InitializeComponent();
            ADBStatus.Content = "No Updates Available";
            PhoneWarning.Visibility = Visibility.Hidden;
            PhoneWarningTxt1.Visibility = Visibility.Hidden;
            PhoneWarningTxt2.Visibility = Visibility.Hidden;
            Change1b_Copy.IsEnabled = false;
            PhoneWarning.Visibility = Visibility.Hidden;
            PhoneWarningTxt1.Visibility = Visibility.Hidden;
            PhoneWarningTxt2.Visibility = Visibility.Hidden;
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
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string remote_version_url2 = "https://www.dropbox.com/s/iseh3e7tzpujznt/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string version_key2 = "Platform Tools ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string update_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "TempDownload");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
                string local_version_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
                string local_launcher_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";
                if (File.Exists(beta_path))
                {
                    url = "https://www.dropbox.com/s/2nykzlitzy2u8an/release.zip?dl=1";
                    remote_version_url = "https://www.dropbox.com/s/7onsz56k52liim2/version.txt?dl=1";
                }
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {

                    }, DispatcherPriority.Normal);
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        dis.Invoke(() =>
                        {
                            ADBStatus.Content = "Update Available";
                            PhoneWarning.Visibility = Visibility.Visible;
                            PhoneWarningTxt1.Visibility = Visibility.Visible;
                            PhoneWarningTxt2.Visibility = Visibility.Visible;
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            ADBStatus.Content = "No Updates Available";
                            PhoneWarning.Visibility = Visibility.Hidden;
                            PhoneWarningTxt1.Visibility = Visibility.Hidden;
                            PhoneWarningTxt2.Visibility = Visibility.Hidden;
                        }, DispatcherPriority.Normal);
                    }
                    if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
                    {
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.IsEnabled = true;
                            ADBStatus_Copy.Content = "Update Available";
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.IsEnabled = false;
                            ADBStatus_Copy.Content = "No Updates Available";
                            Change1b_Copy.Content = "No Updates Available";
                        }, DispatcherPriority.Normal);
                    }
                });
            }
            else
            {
                ADBStatus.Content = "An internet connection is required for this.";
                ADBStatus_Copy.Content = "An internet connection is required for this.";
                ADBStatus.IsEnabled = false;
                ADBStatus_Copy.IsEnabled = false;
            }
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C taskkill /f /im adb.exe & taskkill /f /im fastboot.exe";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                string url = "https://www.dropbox.com/s/8nz4xbwb1dlb9hl/PlatformToolsPackage.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/iseh3e7tzpujznt/version.txt?dl=1";
                string version_key = "Platform Tools ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "TempDownload");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Download");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Preparating..";
                    }, DispatcherPriority.Normal);
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.Content = "Downloading...";
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            Change1b_Copy.Content = "Decompressing...";
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            Change1b_Copy.Content = "Cleaning Up...";
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            Change1b_Copy.Content = "Finishing Up...";
                        }, DispatcherPriority.Normal);
                        String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
                        ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                        cmdsi.Arguments = command;
                        cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                        Process cmd = Process.Start(cmdsi);
                        cmd.WaitForExit();
                        System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C del /f /q adb.exe & del /f /q fastboot.exe & del /f /q AdbWinApi.dll & del /f /q AdbWinUsbApi.dll";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C cd Download & cd PlatformToolsPackage & move * ../../";
                        process.StartInfo = startInfo;
                        process.Start();
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.Content = "Update Finished";
                            ADBStatus_Copy.Content = "Update Finished";
                            Change1b_Copy.IsEnabled = false;
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        Change1b_Copy.IsEnabled = false;
                        ADBStatus.Content = "No Updates Available";
                    }

                    
                });
            }
            else
            {
                Change1b.Content = "🔒 Update";
                Change1b_Copy.Content = "🔒 Update";
                Change1b.IsEnabled = false;
                Change1b_Copy.IsEnabled = false;
            }
        }

        private void Change2(object sender, RoutedEventArgs e)
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

        private void Refresh(object sender, RoutedEventArgs e)
        {
            PhoneWarning.Visibility = Visibility.Hidden;
            PhoneWarningTxt1.Visibility = Visibility.Hidden;
            PhoneWarningTxt2.Visibility = Visibility.Hidden;
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
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string remote_version_url2 = "https://www.dropbox.com/s/iseh3e7tzpujznt/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string version_key2 = "Platform Tools ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string update_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "TempDownload");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
                string local_version_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
                string local_launcher_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";
                if (File.Exists(beta_path))
                {
                    url = "https://www.dropbox.com/s/2nykzlitzy2u8an/release.zip?dl=1";
                    remote_version_url = "https://www.dropbox.com/s/7onsz56k52liim2/version.txt?dl=1";
                }
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {

                    }, DispatcherPriority.Normal);
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        dis.Invoke(() =>
                        {
                            ADBStatus.Content = "Update Available";
                            PhoneWarning.Visibility = Visibility.Visible;
                            PhoneWarningTxt1.Visibility = Visibility.Visible;
                            PhoneWarningTxt2.Visibility = Visibility.Visible;
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            ADBStatus.Content = "No Updates Available";
                            PhoneWarning.Visibility = Visibility.Hidden;
                            PhoneWarningTxt1.Visibility = Visibility.Hidden;
                            PhoneWarningTxt2.Visibility = Visibility.Hidden;
                        }, DispatcherPriority.Normal);
                    }
                    if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
                    {
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.IsEnabled = true;
                            ADBStatus_Copy.Content = "Update Available";
                            Change1b_Copy.Content = "Update";
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            Change1b_Copy.IsEnabled = false;
                            ADBStatus_Copy.Content = "No Updates Available";
                            Change1b_Copy.Content = "No Updates Available";
                        }, DispatcherPriority.Normal);
                    }
                });
            }
            else
            {
                ADBStatus.Content = "An internet connection is required for this.";
                ADBStatus_Copy.Content = "An internet connection is required for this.";
                ADBStatus.IsEnabled = false;
                ADBStatus_Copy.IsEnabled = false;
            }
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next(object sender, RoutedEventArgs e)
        {

        }

        private void ViewBug(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit/bugs";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
