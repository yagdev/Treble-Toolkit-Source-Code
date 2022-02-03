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
    /// Interaction logic for UpdateAvailable.xaml
    /// </summary>
    public partial class UpdateAvailable : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public UpdateAvailable()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(GetCurrentVersion);
            thread2.Start();
            Thread thread3 = new Thread(GetNewRelease);
            thread3.Start();
            Thread thread4 = new Thread(UpdateUI);
            thread4.Start();
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string local_version_path1 = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "NewVersionLabel.txt");
            string text1 = System.IO.File.ReadAllText(local_version_path1);
            this.Dispatcher.Invoke(() =>
            {
                NewVersion.Content = text1;
            });
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Changelogs(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ViewChangekig);
            thread.Start();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Launch);
            thread.Start();
        }

        private void No_btn(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(LaunchWithoutUpdating);
            thread.Start();
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
        private void GetNewRelease()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir Update & cd Update & mkdir Download & cd .. & mkdir UpdateFiles & mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
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
        private void GetCurrentVersion()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir Update & cd Update & mkdir Download & cd .. & mkdir UpdateFiles & mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string GetCurVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
            if (File.Exists(GetCurVer))
            {
                string text = System.IO.File.ReadAllText(GetCurVer);
                this.Dispatcher.Invoke(() =>
                {
                    CurrentVersion.Content = text;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    CurrentVersion.Content = "No Data Yet";
                });
            }
        }
        private void ViewChangekig()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit/changelog";
                process.StartInfo = startInfo;
                process.Start();
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Yes.IsEnabled = false;
                    Changelog.IsEnabled = false;
                    Yes.Content = "🔒 Yes";
                    Changelog.Content = "🔒 Visit the changelog page";
                });
            }
        }
        private void Launch()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir Update & cd Update & mkdir Download & cd .. & mkdir UpdateFiles & mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            this.Dispatcher.Invoke(() =>
            {
                Yes.IsEnabled = false;
            });
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion & del /f /q LauncherVersion.txt";
                process.StartInfo = startInfo;
                process.Start();
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
                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Preparating..";
                    status_pgr.Value += 5;
                });
                var update = Updater.Init(url, update_path, application_path, launch_exe);
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
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
                    this.Dispatcher.Invoke(() =>
                    {
                        Yes.Content = "Downloading...";
                        status_pgr.Value += 5;
                    });

                    update.Download();

                    this.Dispatcher.Invoke(() =>
                    {
                        Yes.Content = "Decompressing...";
                        status_pgr.Value += 60;
                    });

                    update.Unzip();

                    this.Dispatcher.Invoke(() =>
                    {
                        Yes.Content = "Cleaning Up...";
                        status_pgr.Value += 10;
                    });

                    update.CleanUp();


                    this.Dispatcher.Invoke(() =>
                    {
                        Yes.Content = "Finishing Up...";
                        status_pgr.Value += 10;
                    });

                    using (var client = new System.Net.WebClient())
                    {
                        client.DownloadFile(remote_version_url, local_version_path);
                        client.Dispose();
                        client.DownloadFile(remote_version_url, local_launcher_path);
                        client.Dispose();
                    }

                }

                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Executing...";
                    status_pgr.Value += 10;
                });
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
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Yes.IsEnabled = false;
                    Changelog.IsEnabled = false;
                    Yes.Content = "🔒 Yes";
                    Changelog.Content = "🔒 Visit the changelog page";
                });
            }
        }
        private void LaunchWithoutUpdating()
        {
            String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                }
            });
        }
    }
}
