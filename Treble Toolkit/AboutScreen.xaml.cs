using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Media;
using ChaseLabs.CLUpdate;
using ChaseLabs.CLConfiguration;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Effects;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for AboutScreen.xaml
    /// </summary>
    public partial class AboutScreen : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public AboutScreen()
        {
            InitializeComponent();
            string ptpath = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
            if (File.Exists(ptpath))
            {
                string ptversion = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt"));
                Changelog_Copy.Text = "©2021 YAG-dev · " + ptversion;
            }
            else
            {
                Changelog_Copy.Text = "©2021 YAG-dev · Unable to check current Platform Tools version";
            }
            TTOutOfDate.Visibility = Visibility.Hidden;
            TTOutOfDateTxt1.Visibility = Visibility.Hidden;
            TTOutOfDateTxt2.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true && File.Exists(local_version_path))
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_launcher_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "LauncherVersion.txt");
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
                            TTOutOfDate.Visibility = Visibility.Visible;
                            TTOutOfDateTxt1.Visibility = Visibility.Visible;
                            TTOutOfDateTxt2.Visibility = Visibility.Visible;
                            Update.Visibility = Visibility.Visible;
                        }, DispatcherPriority.Normal);
                    }
                    else
                    {
                        dis.Invoke(() =>
                        {
                            TTOutOfDate.Visibility = Visibility.Hidden;
                            TTOutOfDateTxt1.Visibility = Visibility.Hidden;
                            TTOutOfDateTxt2.Visibility = Visibility.Hidden;
                            Update.Visibility = Visibility.Hidden;
                        });
                    }
                });
            }
            else
            {
                TTOutOfDate.Visibility = Visibility.Visible;
                TTOutOfDateTxt1.Visibility = Visibility.Visible;
                TTOutOfDateTxt2.Visibility = Visibility.Visible;
                DropShadowEffect myDropShadowEffect = new DropShadowEffect();

                // Set the color of the shadow to Black.
                Color myShadowColor = new Color();
                myShadowColor.A = 255; // Note that the alpha value is ignored by Color property. 
                                       // The Opacity property is used to control the alpha.
                myShadowColor.B = 0;
                myShadowColor.G = 0;
                myShadowColor.R = 255;
                myDropShadowEffect.Direction = 0;
                myDropShadowEffect.ShadowDepth = 0;

                myDropShadowEffect.Color = myShadowColor;
                TTOutOfDate.Effect = myDropShadowEffect;
                TTOutOfDate.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                TTOutOfDateTxt1.Content = "⚠ Could not check for updates";
                TTOutOfDateTxt2.Content = "Updates might be available";
            }
            if (Environment.OSVersion.Version.Build <= 9)
            {

            }
            else
            {
                W7WarningRectangle.Visibility = Visibility.Hidden;
                W7WarningTxt1.Visibility = Visibility.Hidden;
                W7WarningTxt2.Visibility = Visibility.Hidden;
                LearnMore.Visibility = Visibility.Hidden;
            }
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
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & start TrebleToolkitLauncher.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
        }

        private void DiscoverAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit/21-11";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void UpdateAbout_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void thirtytwobitclick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("32bitlifecycleinfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void AnniversaryEvent(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start TimeMachine.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
        }

        private void DeviceSpecificFeatures_Copy4_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("QSG.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }

        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & start TrebleToolkitLauncher.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
        }

        private void LearnMore_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("WindowsOutdatedMoreInfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void LogViewADB(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PlatformToolsChangelog.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
