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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Prepare);
            thread2.Start();
            Thread thread3 = new Thread(CurrentVersionGet);
            thread3.Start();
            Thread thread4 = new Thread(NewReleaseGet);
            thread4.Start();
            Thread thread5 = new Thread(UpdateUI);
            thread5.Start();
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

        private void No_btn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(NextReinstall);
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
        private void Prepare()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir Update & cd Update & mkdir Download & cd .. & mkdir UpdateFiles & mkdir UpdateInfo & cd UpdateInfo & mkdir BetaProgram & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        private void CurrentVersionGet()
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
        private void NewReleaseGet()
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-fnf-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-retry-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-fnf-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-retry-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-restart-light.png"));
                }
            });
        }
        private void NextReinstall()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Yes.IsEnabled = false;
                });
                String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
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
                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Preparing Reinstall..";
                    status_pgr.Value += 5;
                });
                var update = Updater.Init(url, update_path, application_path, launch_exe);
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Downloading Package...";
                        status_pgr.Value += 5;
                    });

                    update.Download();

                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Extracting Package...";
                        status_pgr.Value += 60;
                        Yes.Foreground = No.Background;
                    });

                    update.Unzip();

                this.Dispatcher.Invoke(() =>
                {
                    Yes.Content = "Optimizing...";
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
                    Yes.Content = "Launching...";
                    status_pgr.Value += 10;
                });
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
                String command2 = @"/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & wmic process where name='fastboot.exe' delete";
                ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                cmdsi2.Arguments = command2;
                cmdsi2.WindowStyle = ProcessWindowStyle.Hidden;
                Process cmd2 = Process.Start(cmdsi2);
                cmd2.WaitForExit();
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
                    Yes.Content = "🔒 Reinstall";
                });
            }
        }
    }
}
