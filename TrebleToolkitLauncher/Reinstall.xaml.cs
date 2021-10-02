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
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;
using ChaseLabs.CLUpdate;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace TrebleToolkitLauncher
{
    /// <summary>
    /// Interaction logic for Reinstall.xaml
    /// </summary>
    public partial class Reinstall : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public Reinstall()
        {
            InitializeComponent();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
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
            string GetCurVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
            if (File.Exists(GetCurVer))
            {
                string text = System.IO.File.ReadAllText(GetCurVer);
                CurrentVersion.Content = text;
            }
            else
            {
                CurrentVersion.Content = "No Data Yet";
            }
            string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
            string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
            string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
            string version_key = "Treble Toolkit ";
            string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
            string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
            string local_version_path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "NewVersionLabel.txt");
            string local_launcher_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
            string launch_exe = "TrebleToolkitLauncher.exe";
            if (File.Exists(beta_path))
            {
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    client.DownloadFileAsync(new Uri("https://www.dropbox.com/s/7onsz56k52liim2/version.txt?dl=1"), local_version_path1);
                }
            }
            else
            {
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    client.DownloadFileAsync(new Uri("https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1"), local_version_path1);
                }
            }
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string local_version_path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "NewVersionLabel.txt");
            string text1 = System.IO.File.ReadAllText(local_version_path1);
            NewVersion.Content = text1;
        }

        private void No_btn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Yes.IsEnabled = false;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion & del /f /q LauncherVersion.txt & del /f /q VersionString.txt";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
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
                        Yes.Content = "Preparating..";
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
                        process.WaitForExit();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C RD /s /q Application";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        dis.Invoke(() =>
                        {
                            Yes.Content = "Downloading...";
                            status_pgr.Value += 5;
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            Yes.Content = "Decompressing...";
                            status_pgr.Value += 60;
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            Yes.Content = "Cleaning Up...";
                            status_pgr.Value += 10;
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            Yes.Content = "Finishing Up...";
                            status_pgr.Value += 10;
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                            client.DownloadFile(remote_version_url, local_launcher_path);
                            client.Dispose();
                        }

                    }

                    dis.Invoke(() =>
                    {
                        Yes.Content = "Executing...";
                        status_pgr.Value += 10;
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
                });
            }
            else
            {
                Yes.IsEnabled = false;
                Yes.Content = "🔒 Reinstall";
            }
        }
    }
}
