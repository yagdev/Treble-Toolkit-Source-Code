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

namespace TrebleToolkitUpdaterLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dispatcher dis = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                    status_lbl.Content = "Checking for Updates...";
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
                        status_lbl.Content = "Initializing Download...";
                    }, DispatcherPriority.Normal);

                    update.Download();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Downloading...";
                    }, DispatcherPriority.Normal);

                    update.Unzip();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Unzipping...";
                    }, DispatcherPriority.Normal);

                    update.CleanUp();


                    dis.Invoke(() =>
                    {
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
                    status_lbl.Content = "Launching...";
                }, DispatcherPriority.Normal);
                System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move CLUpdate.dll ../ & move FluentWPF.dll ../ & move CLUpdate.xml ../ & move TrebleToolkitLauncher.exe ../";
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
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
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
                    status_lbl.Content = "Reinstalling...";
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
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C RD /s /q old & mkdir old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old & move FluentWPF.dll old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C RD /s /q Application";
                    process.StartInfo = startInfo;
                    process.Start();
                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Initializing Download...";
                    }, DispatcherPriority.Normal);

                    update.Download();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Downloading...";
                    }, DispatcherPriority.Normal);

                    update.Unzip();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Unzipping...";
                    }, DispatcherPriority.Normal);

                    update.CleanUp();


                    dis.Invoke(() =>
                    {
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
                    status_lbl.Content = "Treble Toolkit was reinstalled successfully. Launching...";
                }, DispatcherPriority.Normal);
                System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move CLUpdate.dll ../ & move CLUpdate.xml ../ & move TrebleToolkitLauncher.exe ../ & move FluentWPF.dll ../";
                process.StartInfo = startInfo;
                process.Start();
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C RD /s /q old & mkdir old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old & move FluentWPF.dll old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C RD /s /q Application";
                    process.StartInfo = startInfo;
                    process.Start();
                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Initializing Download...";
                    }, DispatcherPriority.Normal);

                    update.Download();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Downloading...";
                    }, DispatcherPriority.Normal);

                    update.Unzip();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Unzipping...";
                    }, DispatcherPriority.Normal);

                    update.CleanUp();


                    dis.Invoke(() =>
                    {
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
                    status_lbl.Content = "Treble Toolkit was reinstalled successfully. Launching...";
                }, DispatcherPriority.Normal);
                System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd UpdateFiles & move Application ../ & move CLUpdate.dll ../ & move CLUpdate.xml ../ & move TrebleToolkitUpdaterLauncher.exe ../ & move FluentWPF.dll ../";
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
            });
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
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
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C RD /s /q old & mkdir old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old & move FluentWPF.dll old";
                    process.StartInfo = startInfo;
                    process.Start();
                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Initializing Download...";
                    }, DispatcherPriority.Normal);

                    update.Download();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Downloading...";
                    }, DispatcherPriority.Normal);

                    update.Unzip();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Unzipping...";
                    }, DispatcherPriority.Normal);

                    update.CleanUp();


                    dis.Invoke(() =>
                    {
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
                    status_lbl.Content = "Updated Launcher. Restarting...";
                }, DispatcherPriority.Normal);
                System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd UpdateFiles & move CLUpdate.dll ../ & move CLUpdate.xml ../ & move TrebleToolkitLauncher.exe ../ & move FluentWPF.dll ../";
                process.StartInfo = startInfo;
                process.Start();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C taskkill /im TrebleToolkitLauncher.exe & start TrebleToolkitLauncher.exe";
                process.StartInfo = startInfo;
                process.Start();
            });
        }
    }
}
