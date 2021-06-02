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
using ChaseLabs.CLUpdate;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace TrebleToolkitUpdaterLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir SystemInfo & cd SystemInfo";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C systeminfo";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            using (StreamReader reader = process.StandardOutput)
            {
                string system_info_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "SystemInfo", "SystemReport.txt");
                using (StreamWriter sw = File.CreateText(system_info_path))
                {
                    sw.WriteLine("Treble Toolkit System Report");
                    sw.WriteLine("©2021 YAG-dev");
                    sw.WriteLine(output);
                }
            }
            if (Environment.Is64BitOperatingSystem)
            {

            }
            else
            {
                status_lbl.Content = "©2021 YAG-dev · Version 21.6.1 · Version 21.8.1 will not support 32 Bit computers.";
            }
            string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
            if (File.Exists(beta_path))
            {
                JoinBetaLbl.Content = "Leave Beta Program";
                JoinBetaLbl.FontSize = 14;
            }
            else
            {
                JoinBetaLbl.Content = "Join Beta Program";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C RD /s /q old & mkdir old & del /f CLUpdate.dll & del /f CLConfiguration.dll & move FluentWPF.dll old & RD /s /q old & mkdir old";
            process.StartInfo = startInfo;
            process.Start();
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {

            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                Launcher.Visibility = Visibility.Hidden;
                CheckLabel.Visibility = Visibility.Visible;
                GridMain.Opacity = 0;
                Grid r = (Grid)GridMain;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                r.BeginAnimation(Grid.OpacityProperty, animation);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Launch.Visibility = Visibility.Visible;
                LaunchLabel.Visibility = Visibility.Visible;
                LaunchRectangle.Visibility = Visibility.Visible;
                Reinstall.Visibility = Visibility.Visible;
                ReinstallLabel.Visibility = Visibility.Visible;
                ReinstallRectangle.Visibility = Visibility.Visible;
                UpdateLauncher.Visibility = Visibility.Visible;
                UpdateLabel.Visibility = Visibility.Visible;
                UpdateRectangle.Visibility = Visibility.Visible;
                CheckConnection.Visibility = Visibility.Hidden;
                CheckConnectionRectangle.Visibility = Visibility.Hidden;
                CheckLabel.Visibility = Visibility.Hidden;
                Launch.Visibility = Visibility.Hidden;
                Launch2.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                Launch2Rectangle.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                Launch2Label.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                CheckConnection.Visibility = Visibility.Hidden;
                CheckConnectionRectangle.Visibility = Visibility.Hidden;
                CheckLabel.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
               Task.Run(() =>
                {
                    if (File.Exists(beta_path))
                    {
                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Checking for Updates...";
                        }, DispatcherPriority.Normal);
                        string url = "https://www.dropbox.com/s/2nykzlitzy2u8an/release.zip?dl=1";
                        string remote_version_url = "https://www.dropbox.com/s/7onsz56k52liim2/version.txt?dl=1";
                        string version_key = "application: ";
                        string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                        string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                        string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                        string launch_exe = "TrebleToolkitLauncher.exe";
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
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/C RD /s /q Application";
                            process.StartInfo = startInfo;
                            process.Start();
                            dis.Invoke(() =>
                            {
                                status_pgr.Visibility = Visibility.Visible;
                                status_pgr.Value = 0;
                                status_pgr.Value += 0;
                                status_lbl.Visibility = Visibility.Hidden;
                                status_lbl.Content = "Initializing Download...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.Download();

                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Downloading...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.Unzip();

                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Unzipping...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.CleanUp();


                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Finishing Up...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            using (var client = new System.Net.WebClient())
                            {
                                client.DownloadFile(remote_version_url, local_version_path);
                                client.Dispose();
                            }

                        }

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Launching...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);
                        String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                        ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                        cmdsi.Arguments = command;
                        cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                        Process cmd = Process.Start(cmdsi);
                        cmd.WaitForExit();
                        System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move TrebleToolkitLauncher.exe ../";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C cd Application & cd assets & gui.exe";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe";
                        process.StartInfo = startInfo;
                        process.Start();
                        status_pgr.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Checking for Updates...";
                        }, DispatcherPriority.Normal);
                        string version_key = "application: ";
                        string url = "https://www.dropbox.com/s/pqnwsjlw8e6tdcv/update.zip?dl=1";
                        string remote_version_url = "https://www.dropbox.com/s/2iio6h7fe1xlje8/version.txt?dl=1";
                        string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                        string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                        string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                        string launch_exe = "TrebleToolkitLauncher.exe";
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
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/C RD /s /q Application";
                            process.StartInfo = startInfo;
                            process.Start();
                            dis.Invoke(() =>
                            {
                                status_pgr.Visibility = Visibility.Visible;
                                status_pgr.Value = 0;
                                status_pgr.Value += 0;
                                status_lbl.Visibility = Visibility.Hidden;
                                status_lbl.Content = "Initializing Download...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.Download();

                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Downloading...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.Unzip();

                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Unzipping...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            update.CleanUp();


                            dis.Invoke(() =>
                            {
                                status_lbl.Content = "Finishing Up...";
                                status_pgr.Value += 20;
                            }, DispatcherPriority.Normal);

                            using (var client = new System.Net.WebClient())
                            {
                                client.DownloadFile(remote_version_url, local_version_path);
                                client.Dispose();
                            }

                        }

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Launching...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);
                        String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                        ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                        cmdsi.Arguments = command;
                        cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                        Process cmd = Process.Start(cmdsi);
                        cmd.WaitForExit();
                        System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move TrebleToolkitLauncher.exe ../";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C cd Application & cd assets & gui.exe";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe";
                        process.StartInfo = startInfo;
                        process.Start();
                        status_pgr.Visibility = Visibility.Hidden;
                    }
                });
            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                CheckLabel.Visibility = Visibility.Visible;
                Launcher.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Launch.Visibility = Visibility.Visible;
                LaunchLabel.Visibility = Visibility.Visible;
                LaunchRectangle.Visibility = Visibility.Visible;
                Reinstall.Visibility = Visibility.Visible;
                ReinstallLabel.Visibility = Visibility.Visible;
                ReinstallRectangle.Visibility = Visibility.Visible;
                UpdateLauncher.Visibility = Visibility.Visible;
                UpdateLabel.Visibility = Visibility.Visible;
                UpdateRectangle.Visibility = Visibility.Visible;
                CheckConnection.Visibility = Visibility.Hidden;
                CheckConnectionRectangle.Visibility = Visibility.Hidden;
                CheckLabel.Visibility = Visibility.Hidden;
                Launch.Visibility = Visibility.Hidden;
                Launch2.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Launch2Rectangle.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                Launch2Label.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion & ren VersionString.txt VersionString2.txt & del VersionString.txt";
                process.StartInfo = startInfo;
                process.Start();
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        status_lbl.Visibility = Visibility.Hidden;
                        status_lbl.Content = "Reinstalling...";
                        status_pgr.Visibility = Visibility.Visible;
                        status_pgr.Value = 0;
                    }, DispatcherPriority.Normal);

                    string url = "https://www.dropbox.com/s/pqnwsjlw8e6tdcv/update.zip?dl=1";
                    string remote_version_url = "https://www.dropbox.com/s/2iio6h7fe1xlje8/version.txt?dl=1";
                    string version_key = "application: ";
                    string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                    string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                    string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                    string launch_exe = "TrebleToolkitLauncher.exe";
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    {
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q old & mkdir old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q Application";
                        process.StartInfo = startInfo;
                        process.Start();
                        dis.Invoke(() =>
                        {
                            status_pgr.Value = 0;
                            status_lbl.Content = "Initializing Download...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Downloading...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Unzipping...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Finishing Up...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }

                    }

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Treble Toolkit was reinstalled successfully. Launching...";
                        status_pgr.Value += 20;
                    }, DispatcherPriority.Normal);
                    String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move TrebleToolkitLauncher.exe ../ & cd .. & cd Application & cd assets & start gui.exe & wmic process where name='TrebleToolkitLauncher.exe' delete";
                    process.StartInfo = startInfo;
                    process.Start();
                    status_pgr.Visibility = Visibility.Hidden;
                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        status_pgr.Visibility = Visibility.Visible;
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q old & mkdir old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q Application";
                        process.StartInfo = startInfo;
                        process.Start();
                        dis.Invoke(() =>
                        {
                            status_pgr.Value = 0;
                            status_lbl.Content = "Initializing Download...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Downloading...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Unzipping...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Finishing Up...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }

                    }

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Treble Toolkit was reinstalled successfully. Launching...";
                        status_pgr.Value += 20;
                    }, DispatcherPriority.Normal);
                    String command2 = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    cmdsi2.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd2 = Process.Start(cmdsi2);
                    cmd.WaitForExit();
                    System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move TrebleToolkitLauncher.exe ../";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd Application & cd assets & gui.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    status_pgr.Visibility = Visibility.Visible;
                });
            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                CheckLabel.Visibility = Visibility.Visible;
                Launcher.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            Launch.Visibility = Visibility.Hidden;
            Launch2.Visibility = Visibility.Hidden;
            Reinstall.Visibility = Visibility.Hidden;
            UpdateLauncher.Visibility = Visibility.Hidden;
            LaunchRectangle.Visibility = Visibility.Hidden;
            ReinstallRectangle.Visibility = Visibility.Hidden;
            UpdateRectangle.Visibility = Visibility.Hidden;
            LaunchLabel.Visibility = Visibility.Hidden;
            ReinstallLabel.Visibility = Visibility.Hidden;
            UpdateLabel.Visibility = Visibility.Hidden;
            CheckConnection.Visibility = Visibility.Hidden;
            CheckConnectionRectangle.Visibility = Visibility.Hidden;
            CheckLabel.Visibility = Visibility.Hidden;
            JoinBeta.Visibility = Visibility.Hidden;
            JoinBetaLbl.Visibility = Visibility.Hidden;
            JoinBetaRectangle.Visibility = Visibility.Hidden;
            status_lbl.Content = "Launching Treble Toolkit without updating...";
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

        private void Button_ClickL(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Launch.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                Launch2.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                Launch2Rectangle.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                Launch2Label.Visibility = Visibility.Hidden;
                status_pgr.Visibility = Visibility.Visible;
                CheckConnection.Visibility = Visibility.Hidden;
                CheckConnectionRectangle.Visibility = Visibility.Hidden;
                CheckLabel.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
                process.StartInfo = startInfo;
                process.Start();
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Checking for Launcher updates...";
                    }, DispatcherPriority.Normal);

                    string url = "https://www.dropbox.com/s/pqnwsjlw8e6tdcv/update.zip?dl=1";
                    string remote_version_url = "https://www.dropbox.com/s/2iio6h7fe1xlje8/version.txt?dl=1";
                    string version_key = "application: ";
                    string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                    string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                    string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                    string launch_exe = "TrebleToolkitLauncher.exe";

                    var update = Updater.Init(url, update_path, application_path, launch_exe);

                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        status_pgr.Visibility = Visibility.Visible;
                        status_pgr.Value = 0;
                        status_lbl.Visibility = Visibility.Hidden;
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q old & mkdir old";
                        process.StartInfo = startInfo;
                        process.Start();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old";
                        process.StartInfo = startInfo;
                        process.Start();
                        dis.Invoke(() =>
                        {
                            status_pgr.Value += 20;
                            status_lbl.Content = "Initializing Download...";
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            status_pgr.Value += 20;
                            status_lbl.Content = "Downloading...";
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            status_pgr.Value += 20;
                            status_lbl.Content = "Unzipping...";
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            status_pgr.Value += 20;
                            status_lbl.Content = "Finishing Up...";
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }

                    }

                    dis.Invoke(() =>
                    {
                        status_pgr.Value += 20;
                        status_lbl.Content = "Updated Launcher. Restarting...";
                    }, DispatcherPriority.Normal);
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move TrebleToolkitLauncher.exe ../";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe & start TrebleToolkitLauncher.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    status_pgr.Visibility = Visibility.Hidden;
                });
            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                CheckLabel.Visibility = Visibility.Visible;
                Launcher.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
            }
        }

        private void CheckConnection_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Launch.Visibility = Visibility.Visible;
                LaunchLabel.Visibility = Visibility.Visible;
                LaunchRectangle.Visibility = Visibility.Visible;
                Reinstall.Visibility = Visibility.Visible;
                ReinstallLabel.Visibility = Visibility.Visible;
                ReinstallRectangle.Visibility = Visibility.Visible;
                UpdateLauncher.Visibility = Visibility.Visible;
                UpdateLabel.Visibility = Visibility.Visible;
                UpdateRectangle.Visibility = Visibility.Visible;
                JoinBeta.Visibility = Visibility.Visible;
                JoinBetaLbl.Visibility = Visibility.Visible;
                JoinBetaRectangle.Visibility = Visibility.Visible;
                Title.Content = "Welcome to Treble Toolkit Launcher";
                Launcher.Visibility = Visibility.Visible;
                status_lbl.Content = "©2021 YAG-dev · Version 21.6.1";
            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                Launcher.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Still couldn't connect to the internet :(";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                CheckLabel.Visibility = Visibility.Visible;
            }
        }

        private void JoinBeta_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & cd CurrentVersion & del /f /q ";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                if (File.Exists(version_path))
                {
                    File.Delete(version_path);
                }
                if (File.Exists(beta_path))
                {
                    File.Delete(beta_path);
                    JoinBetaLbl.Content = "Join Beta Program";
                    JoinBetaLbl.FontSize = 16;
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
                    JoinBetaLbl.Content = "Leave Beta Program";
                    JoinBetaLbl.FontSize = 14;
                }
            }
            else
            {
                Launch.Visibility = Visibility.Hidden;
                LaunchLabel.Visibility = Visibility.Hidden;
                LaunchRectangle.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                ReinstallLabel.Visibility = Visibility.Hidden;
                ReinstallRectangle.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                UpdateLabel.Visibility = Visibility.Hidden;
                UpdateRectangle.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                JoinBetaLbl.Visibility = Visibility.Hidden;
                JoinBetaRectangle.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                CheckConnectionRectangle.Visibility = Visibility.Visible;
                CheckLabel.Visibility = Visibility.Visible;
                Launcher.Visibility = Visibility.Hidden;
            }
        }
    }
}
