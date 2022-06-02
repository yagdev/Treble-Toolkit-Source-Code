using ChaseLabs.CLUpdate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for RestoreInstall.xaml
    /// </summary>
    public partial class RestoreInstall : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public RestoreInstall()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Restore);
            thread.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        //Threading starts here -- 15/4/2022@17:37, YAG-dev, 22.5+
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
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                }
            });
        }
        private void Restore()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    status_pgr.Value = 0;
                    DeviceSpecificFeatures_Copy4.IsEnabled = false;
                });
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
                process.StartInfo = startInfo;
                process.Start();
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
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
                        DeviceSpecificFeatures_Copy4.Content = "Preparing Restore...";
                        status_pgr.Value += 5;
                    });
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd .. & cd .. & RD /s /q old & mkdir old";
                    process.StartInfo = startInfo;
                    process.Start();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd .. & cd .. & ren TrebleToolkitLauncher.exe TrebleToolkitLauncherOld.exe & move TrebleToolkitLauncherOld.exe old & move CLConfiguration.dll old & move CLConfiguration.xml old & move CLUpdate.dll old & move CLUpdate.xml old";
                    process.StartInfo = startInfo;
                    process.Start();
                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Downloading Package...";
                        status_pgr.Value += 5;
                    });

                    update.Download();

                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Unpacking Package...";
                        status_pgr.Value += 60;
                    });

                    update.Unzip();

                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Cleaning Up...";
                        status_pgr.Value += 10;
                    });

                    update.CleanUp();


                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Finishing Up...";
                        status_pgr.Value += 10;
                    });

                    using (var client = new System.Net.WebClient())
                    {
                        client.DownloadFile(remote_version_url, local_version_path);
                        client.Dispose();
                    }

                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Restore Successful";
                        status_pgr.Value += 10;
                    });
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd .. & cd .. & cd UpdateFiles & move TrebleToolkitLauncher.exe ../ & cd .. & rmdir UpdateFiles /s /q";
                    process.StartInfo = startInfo;
                    process.Start();
                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.IsEnabled = true;
                    });
                });
            }
            else
            {
                string failedupdatepath = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "old", "TrebleToolkitLauncherOld.exe");
                if (File.Exists(failedupdatepath))
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd .. & cd .. & cd old & ren TrebleToolkitLauncherOld.exe TrebleToolkitLauncher.exe & move TrebleToolkitLauncher.exe ../ & cd ..";
                    process.StartInfo = startInfo;
                    process.Start();
                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceSpecificFeatures_Copy4.Content = "Restore Successful";
                        status_pgr.Value += 100;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        status_pgr.Value = 0;
                        DeviceSpecificFeatures_Copy4.Content = "You need an internet connection for this";
                    });
                }
            }
        }
    }
}
