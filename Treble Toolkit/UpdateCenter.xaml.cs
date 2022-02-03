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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
            Thread thread3 = new Thread(CheckUpdates);
            thread3.Start();
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdatePT);
            thread.Start();
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateTT);
            thread.Start();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckUpdates);
            thread.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void DeviceSpecificFeatures_Copy3_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PlatformToolsChangelog.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next(object sender, RoutedEventArgs e)
        {

        }

        private void ViewBug(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(OpenBulletin);
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                ADBStatus.Content = "Up To Date";
                PhoneStatus.Content = "Update Center · No Updates Available";
                Change1b_Copy.IsEnabled = false;
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-light.png"));
                }
            });
        }
        private void CheckUpdates()
        {
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
                var update = Updater.Init(url, update_path, application_path, launch_exe);
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        ADBStatus.Content = "Update Available";
                        PhoneStatus.Content = "Update Center · Update Available";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        ADBStatus.Content = "No Updates Available";
                        if (ADBStatus_Copy.Content == "No Updates Available")
                        {
                            PhoneStatus.Content = "Update Center · No Updates Available";
                        }
                    });
                }
                if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.IsEnabled = true;
                        ADBStatus_Copy.Content = "Update Available";
                        PhoneStatus.Content = "Update Center · Update Available";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.IsEnabled = false;
                        ADBStatus_Copy.Content = "No Updates Available";
                        if (ADBStatus.Content == "No Updates Available")
                        {
                            PhoneStatus.Content = "Update Center · No Updates Available";
                        }
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "An internet connection is required for this.";
                    ADBStatus_Copy.Content = "An internet connection is required for this.";
                    ADBStatus.IsEnabled = false;
                    ADBStatus_Copy.IsEnabled = false;
                });
            }
        }
        private void UpdatePT()
        {
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
                this.Dispatcher.Invoke(() =>
                {
                    Change1b_Copy.Content = "Preparating..";
                });
                var update = Updater.Init(url, update_path, application_path, launch_exe);
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Downloading...";
                    });

                    update.Download();

                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Decompressing...";
                    });

                    update.Unzip();

                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Cleaning Up...";
                    });

                    update.CleanUp();


                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Finishing Up...";
                    });
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
                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.Content = "Update Finished";
                        ADBStatus_Copy.Content = "Update Finished";
                        Change1b_Copy.IsEnabled = false;
                        if (ADBStatus.Content == "No Updates Available")
                        {
                            PhoneStatus.Content = "Update Center · No Updates Available";
                        }
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Change1b_Copy.IsEnabled = false;
                        ADBStatus.Content = "No Updates Available";
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Change1b.IsEnabled = false;
                    Change1b_Copy.IsEnabled = false;
                });
            }
        }
        private void UpdateTT()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & start TrebleToolkitLauncher.exe";
            process.StartInfo = startInfo;
            process.Start();
            this.Dispatcher.Invoke(() =>
            {
                Application.Current.Shutdown();
            });
        }
        private void OpenBulletin()
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
