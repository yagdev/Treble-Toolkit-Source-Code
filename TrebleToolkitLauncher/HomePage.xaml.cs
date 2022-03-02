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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(NetworkCheck);
            thread2.Start();
            Thread thread3 = new Thread(GetCurrentVersion);
            thread3.Start();
            Thread thread4 = new Thread(GetLauncherVersion);
            thread4.Start();
            Thread thread5 = new Thread(UpdateUI);
            thread5.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Launch);
            thread.Start();
        }

        private void Reinstall(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Reinstall.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateLauncher(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(UpdateLauncher);
            thread.Start();
        }

        private void CheckConnection(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckNetworking);
            thread.Start();
        }

        private void JoinBeta_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
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
        private void NetworkCheck()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    BootFileLabel_Copy1.Content = "Connected";
                    DeviceSpecificFeatures_Copy.IsEnabled = true;
                    UpdateLauncher_Btn.IsEnabled = true;
                    DeviceSpecificFeatures_Copy.Content = "Reinstall";
                    UpdateLauncher_Btn.Content = "Update Launcher";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    BootFileLabel_Copy1.Content = "Not Connected";
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    UpdateLauncher_Btn.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                    UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                });
            }
        }
        private void GetCurrentVersion()
        {
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
        private void GetLauncherVersion()
        {
            string GetCurVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
            string GetLauncherVer = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
            if (File.Exists(GetLauncherVer))
            {
                string text = System.IO.File.ReadAllText(GetLauncherVer);
                this.Dispatcher.Invoke(() =>
                {
                    LauncherVer.Content = text;
                });
            }
            else
            {
                if (File.Exists(GetCurVer))
                {
                    string text = System.IO.File.ReadAllText(GetCurVer);
                    this.Dispatcher.Invoke(() =>
                    {
                        LauncherVer.Content = text;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        LauncherVer.Content = "No Data Yet";
                    });
                }
            }
        }
        private void Launch()
        {
            int Out;
            string blocker_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "UpdateBlocker", "BlockUpdates.txt");
            if (InternetGetConnectedState(out Out, 0) == true && File.Exists(blocker_path) == false)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy3.Content = "Checking for Updates...";
                });
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
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Uri uri = new Uri("UpdateAvailable.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
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
        private void UpdateLauncher()
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
                    this.Dispatcher.Invoke(() =>
                    {
                        UpdateLauncher_Btn.Content = "Checking for Launcher Updates...";
                        status_pgr.Value += 5;
                    });
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
                        this.Dispatcher.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Downloading...";
                            status_pgr.Value += 5;
                        });

                        update.Download();

                        this.Dispatcher.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Unzipping...";
                            status_pgr.Value += 60;
                        });

                        update.Unzip();

                        this.Dispatcher.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Cleaning Up...";
                            status_pgr.Value += 10;
                        });

                        update.CleanUp();


                        this.Dispatcher.Invoke(() =>
                        {
                            UpdateLauncher_Btn.Content = "Finishing Up...";
                            status_pgr.Value += 10;
                        });

                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(remote_version_url, local_version_path);
                            client.Dispose();
                        }

                    }

                    this.Dispatcher.Invoke(() =>
                    {
                        UpdateLauncher_Btn.Content = "Launching...";
                        status_pgr.Value += 10;
                    });
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move TrebleToolkitLauncher.exe ../ & cd .. & rmdir UpdateFiles /s /q & start TrebleToolkitLauncher.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    Application.Current.Shutdown();
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    UpdateLauncher_Btn.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                    UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                });
            }
        }
        private void CheckNetworking()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = true;
                    UpdateLauncher_Btn.IsEnabled = true;
                    DeviceSpecificFeatures_Copy.Content = "Reinstall";
                    UpdateLauncher_Btn.Content = "Update Launcher";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    UpdateLauncher_Btn.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Reinstall";
                    UpdateLauncher_Btn.Content = "🔒 Update Launcher";
                });
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-launch-dark.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-fnf-dark.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-internet-dark.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-settings-dark.png"));
                    ntwimg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-internet-dark.png"));
                    launcherimg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-about-dark.png"));
                    CurrentVerImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-about-dark.png"));
                }
                else
                {
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-launch-light.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-fnf-light.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-internet-light.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-settings-light.png"));
                    ntwimg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-internet-light.png"));
                    launcherimg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-about-light.png"));
                    CurrentVerImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-about-light.png"));
                }
            });
        }
    }
}
