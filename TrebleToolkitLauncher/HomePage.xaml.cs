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
using System.Diagnostics;
using System.Windows.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using ChaseLabs.CLUpdate;
using ChaseLabs.CLConfiguration;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;

namespace TrebleToolkitLauncher
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public HomePage()
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
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                BootFileLabel_Copy1.Content = "Connected";
                DeviceSpecificFeatures_Copy.IsEnabled = true;
                UpdateLauncher_Btn.IsEnabled = true;
                JoinBeta.IsEnabled = true;
                DeviceSpecificFeatures_Copy.Content = "Reinstall";
                UpdateLauncher_Btn.Content = "Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "Join Beta Program";
                }
            }
            else
            {
                BootFileLabel_Copy1.Content = "Not Connected";
                DeviceSpecificFeatures_Copy.IsEnabled = false;
                UpdateLauncher_Btn.IsEnabled = false;
                JoinBeta.IsEnabled = false;
                DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "🔒 Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "🔒 Join Beta Program";
                }
            }
            string GetCurVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
            string GetLauncherVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
            if (File.Exists(GetCurVer))
            {
                string text = System.IO.File.ReadAllText(GetCurVer);
                CurrentVersion.Content = text;
            }
            else
            {
                CurrentVersion.Content = "No Data Yet";
            }
            if (File.Exists(GetLauncherVer))
            {
                string text = System.IO.File.ReadAllText(GetLauncherVer);
                LauncherVer.Content = text;
            }
            else
            {
                if (File.Exists(GetCurVer))
                {
                    string text = System.IO.File.ReadAllText(GetCurVer);
                    LauncherVer.Content = text;
                }
                else
                {
                    LauncherVer.Content = "No Data Yet";
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                string local_launcher_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
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
                            Uri uri = new Uri("UpdateAvailable.xaml", UriKind.Relative);
                            this.NavigationService.Navigate(uri);
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
                            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                            cmdsi.Arguments = command;
                            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                            Process cmd = Process.Start(cmdsi);
                            cmd.WaitForExit();
                            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo2.FileName = "cmd.exe";
                            startInfo2.Arguments = "/C cd Application & cd assets & gui.exe";
                            process2.StartInfo = startInfo2;
                            process2.Start();
                            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo2.FileName = "cmd.exe";
                            startInfo2.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe";
                            process2.StartInfo = startInfo2;
                            process2.Start();
                        });
                    }
                });
            }
            else
            {
                String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo2.FileName = "cmd.exe";
                startInfo2.Arguments = "/C cd Application & cd assets & gui.exe";
                process2.StartInfo = startInfo2;
                process2.Start();
                startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo2.FileName = "cmd.exe";
                startInfo2.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe";
                process2.StartInfo = startInfo2;
                process2.Start();
            }
        }

        private void Reinstall(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Reinstall.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateLauncher(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
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
                        UpdateLauncher_Btn.Content = "Checking for Launcher Updates...";
                        status_pgr.Value += 5;
                    }, DispatcherPriority.Normal);
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q old & mkdir old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old";
                        process.StartInfo = startInfo;
                        process.Start();
                        dis.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Downloading...";
                            status_pgr.Value += 5;
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Unzipping...";
                            status_pgr.Value += 60;
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Cleaning Up...";
                            status_pgr.Value += 10;
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Finishing Up...";
                            status_pgr.Value += 10;
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }

                    }

                    dis.Invoke(() =>
                    {
                        UpdateLauncher_Btn.Content = "Launching...";
                        status_pgr.Value += 10;
                    }, DispatcherPriority.Normal);
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move TrebleToolkitLauncher.exe ../ & cd .. & rmdir UpdateFiles /s /q & wmic process where name='TrebleToolkitLauncher.exe' delete & start TrebleToolkitLauncher.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });
            }
            else
            {
                DeviceSpecificFeatures_Copy.IsEnabled = false;
                UpdateLauncher_Btn.IsEnabled = false;
                JoinBeta.IsEnabled = false;
                DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "🔒 Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "🔒 Join Beta Program";
                }
            }
        }

        private void CheckConnection(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                DeviceSpecificFeatures_Copy.IsEnabled = true;
                UpdateLauncher_Btn.IsEnabled = true;
                JoinBeta.IsEnabled = true;
                DeviceSpecificFeatures_Copy.Content = "Reinstall";
                UpdateLauncher_Btn.Content = "Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "Join Beta Program";
                }
            }
            else
            {
                DeviceSpecificFeatures_Copy.IsEnabled = false;
                UpdateLauncher_Btn.IsEnabled = false;
                JoinBeta.IsEnabled = false;
                DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "🔒 Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "🔒 Join Beta Program";
                }
            }
        }

        private void JoinBeta_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & cd CurrentVersion & del /f /q ";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                    string version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                    if (File.Exists(version_path))
                    {
                        File.Delete(version_path);
                    }
                    if (File.Exists(beta_path))
                    {
                        File.Delete(beta_path);
                        JoinBeta.Content = "Join Beta Program";
                        JoinBeta.FontSize = 16;
                    }
                    else
                    {
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram";
                        process.StartInfo = startInfo;
                        process.Start();
                        using (StreamWriter sw = File.CreateText(beta_path))
                        {
                            sw.WriteLine("Treble Toolkit Beta Program Validation");
                            sw.WriteLine("©2021 YAG-dev");
                        }
                        JoinBeta.Content = "Leave Beta Program";
                        JoinBeta.FontSize = 16;
                    }
                }
                else
                {
                    string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                    File.Delete(beta_path);
                }
            }
            else
            {
                DeviceSpecificFeatures_Copy.IsEnabled = false;
                UpdateLauncher_Btn.IsEnabled = false;
                JoinBeta.IsEnabled = false;
                DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    JoinBeta.Content = "🔒 Leave Beta Program";
                }
                else
                {
                    JoinBeta.Content = "🔒 Join Beta Program";
                }
            }
        }
    }
}
