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
using ChaseLabs.CLUpdate;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Setup3.xaml
    /// </summary>
    public partial class Setup3 : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public Setup3()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckForUpdates);
            thread2.Start();
            Thread thread3 = new Thread(CurrentVersionCheck);
            thread3.Start();
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CurrentVersionCheck);
            thread.Start();
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckForUpdates);
            thread.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckForUpdates);
            thread.Start();
            Thread thread2 = new Thread(CurrentVersionCheck);
            thread2.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Update);
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
                PhoneWarning.Visibility = Visibility.Hidden;
                PhoneWarningBtn.Visibility = Visibility.Hidden;
                PhoneWarningTxt1.Visibility = Visibility.Hidden;
                PhoneWarningTxt2.Visibility = Visibility.Hidden;
            });
        }
        private void CheckForUpdates()
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
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
                        UpdateCheckTxt2.Content = "Update Available";
                        PhoneWarning.Visibility = Visibility.Visible;
                        PhoneWarningBtn.Visibility = Visibility.Visible;
                        PhoneWarningTxt1.Visibility = Visibility.Visible;
                        PhoneWarningTxt2.Visibility = Visibility.Visible;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        UpdateCheckTxt2.Content = "No Updates Available";
                        PhoneWarning.Visibility = Visibility.Hidden;
                        PhoneWarningBtn.Visibility = Visibility.Hidden;
                        PhoneWarningTxt1.Visibility = Visibility.Hidden;
                        PhoneWarningTxt2.Visibility = Visibility.Hidden;
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateCheckTxt2.Content = "An internet connection is required for this.";
                });
            }
        }
        private void CurrentVersionCheck()
        {
            string GetCurVer = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
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
                    CurrentVersion.Content = "Unknown";
                });
            }
        }
        private void Update()
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
    }
}
