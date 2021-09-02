using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ChaseLabs.CLUpdate;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Media;

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
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "TransparentTheme.txt");
            if (File.Exists(IsTransparent))
            {
                GridMain.Background = new SolidColorBrush(Colors.Transparent);
            }
            else
            {

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
            string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
            if (File.Exists(beta_path))
            {
                JoinBeta.Content = "Leave Beta Program";
                JoinBeta.FontSize = 14;
            }
            else
            {
                JoinBeta.Content = "Join Beta Program";
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
                Reinstall.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                JoinBeta.Visibility = Visibility.Hidden;
                CheckConnection.Visibility = Visibility.Visible;
            }
            GridMain.Opacity = 0;
            Grid r = (Grid)GridMain;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Protection.Visibility = Visibility.Visible;
                if (File.Exists(IsAnimated))
                {
                    Launch2.Visibility = Visibility.Hidden;
                    Reinstall.Visibility = Visibility.Hidden;
                    UpdateLauncher.Visibility = Visibility.Hidden;
                    JoinBeta.Visibility = Visibility.Hidden;
                    CheckConnection.Visibility = Visibility.Hidden;
                }
                else
                {
                    Button r = (Button)Launch2;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r3 = (Button)CheckConnection;
                    r3.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                Launch.Visibility = Visibility.Visible;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion & del /f /q LauncherVersion.txt";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "application: ";
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
                        status_lbl.Content = "Checking for Updates...";
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
                            client.DownloadFile(remote_version_url, local_launcher_path);
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
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });
            }
            else
            {
                if (File.Exists(IsAnimated))
                {

                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                UpdateLauncher.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
                Protection.Visibility = Visibility.Visible;
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
                if (File.Exists(IsAnimated))
                {
                    Launch.Visibility = Visibility.Hidden;
                    Launch2.Visibility = Visibility.Hidden;
                    UpdateLauncher.Visibility = Visibility.Hidden;
                    JoinBeta.Visibility = Visibility.Hidden;
                    CheckConnection.Visibility = Visibility.Hidden;
                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Launch2;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r3 = (Button)CheckConnection;
                    r3.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                Reinstall.Visibility = Visibility.Visible;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion & ren VersionString.txt VersionString2.txt & del VersionString.txt";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "application: ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";
                // Please remove this in 21.8.1
                if (Environment.Is64BitOperatingSystem)
                {
                    if (File.Exists(beta_path))
                    {
                        url = "https://www.dropbox.com/s/2nykzlitzy2u8an/release.zip?dl=1";
                        remote_version_url = "https://www.dropbox.com/s/7onsz56k52liim2/version.txt?dl=1";
                    }
                    else
                    {
                        url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                        remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                    }
                }
                else
                {
                    url = "https://www.dropbox.com/s/dqmk13zq52d3clo/release.zip?dl=1";
                    remote_version_url = "https://www.dropbox.com/s/7faalz9dxjgethh/version.txt?dl=1";
                }
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        status_lbl.Visibility = Visibility.Hidden;
                        status_lbl.Content = "Reinstalling...";
                        status_pgr.Visibility = Visibility.Visible;
                        status_pgr.Value = 0;
                    }, DispatcherPriority.Normal);

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
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
                if (File.Exists(IsAnimated))
                {

                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Protection.Visibility = Visibility.Visible;
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {
                Launch.Visibility = Visibility.Hidden;
                Reinstall.Visibility = Visibility.Hidden;
                UpdateLauncher.Visibility = Visibility.Hidden;
                JoinBeta.Visibility = Visibility.Hidden;
                CheckConnection.Visibility = Visibility.Hidden;
            }
            else
            {
                Button r = (Button)Launch;
                DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                r.BeginAnimation(Button.OpacityProperty, animation);
                Button r2 = (Button)Reinstall;
                r2.BeginAnimation(Button.OpacityProperty, animation);
                Button r3 = (Button)CheckConnection;
                r3.BeginAnimation(Button.OpacityProperty, animation);
                Button r4 = (Button)UpdateLauncher;
                r4.BeginAnimation(Button.OpacityProperty, animation);
                Button r5 = (Button)JoinBeta;
                r5.BeginAnimation(Button.OpacityProperty, animation);
            }
            String command = @"/C wmic process where name='adb.exe' delete & wmic process where name='fastboot.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
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
            InitializeComponent();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Protection.Visibility = Visibility.Visible;
                if (File.Exists(IsAnimated))
                {
                    Launch2.Visibility = Visibility.Hidden;
                    Reinstall.Visibility = Visibility.Hidden;
                    Launch.Visibility = Visibility.Hidden;
                    JoinBeta.Visibility = Visibility.Hidden;
                    CheckConnection.Visibility = Visibility.Hidden;
                }
                else
                {
                    Button r = (Button)Launch2;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r3 = (Button)CheckConnection;
                    r3.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                Launch.Visibility = Visibility.Visible;
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
                string version_key = "application: ";
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
                        status_lbl.Content = "Checking for Launcher Updates...";
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
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd UpdateFiles & move TrebleToolkitLauncher.exe ../ & cd .. & rmdir UpdateFiles /s /q & wmic process where name='TrebleToolkitLauncher.exe' delete & start TrebleToolkitLauncher.exe";
                    process.StartInfo = startInfo;
                    process.Start();
                    status_pgr.Visibility = Visibility.Hidden;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });
            }
            else
            {
                if (File.Exists(IsAnimated))
                {

                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                UpdateLauncher.Visibility = Visibility.Hidden;
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
                CheckConnection.Visibility = Visibility.Visible;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void CheckConnection_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
                if (File.Exists(IsAnimated))
                {
                    Launch.Visibility = Visibility.Visible;
                    Reinstall.Visibility = Visibility.Visible;
                    UpdateLauncher.Visibility = Visibility.Visible;
                    JoinBeta.Visibility = Visibility.Visible;
                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                Title.Content = "Welcome to Treble Toolkit Launcher";
                status_lbl.Content = "©2021 YAG-dev · Version 21.7.1";
            }
            else
            {
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
                if (File.Exists(IsAnimated))
                {
                    Launch.Visibility = Visibility.Hidden;
                    Reinstall.Visibility = Visibility.Hidden;
                    UpdateLauncher.Visibility = Visibility.Hidden;
                    JoinBeta.Visibility = Visibility.Hidden;
                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                status_lbl.Content = "©2021 YAG-dev · Still couldn't connect to the internet :(";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
                if (File.Exists(IsAnimated))
                {

                }
                else
                {
                    Button r = (Button)Launch;
                    DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(150));
                    r.BeginAnimation(Button.OpacityProperty, animation);
                    Button r2 = (Button)Reinstall;
                    r2.BeginAnimation(Button.OpacityProperty, animation);
                    Button r4 = (Button)UpdateLauncher;
                    r4.BeginAnimation(Button.OpacityProperty, animation);
                    Button r5 = (Button)JoinBeta;
                    r5.BeginAnimation(Button.OpacityProperty, animation);
                }
                status_lbl.Content = "©2021 YAG-dev · Looks like you're offline. Reconnect to the Internet to gain access to more features.";
                Title.Content = "Welcome To Treble Toolkit Launcher (Offline Mode)";
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
