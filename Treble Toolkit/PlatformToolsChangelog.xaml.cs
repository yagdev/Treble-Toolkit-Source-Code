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
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using ChaseLabs.CLUpdate;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Net;
using System.Windows.Media.Effects;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for PlatformToolsChangelog.xaml
    /// </summary>
    public partial class PlatformToolsChangelog : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public PlatformToolsChangelog()
        {
            InitializeComponent();
            string ptpath = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
            string ptlog = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformToolsLog.txt");
            if (File.Exists(ptpath))
            {
                string ptversion = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt"));
                copyright.Content = "©2021 YAG-dev · " + ptversion;
            }
            else
            {
                copyright.Content = "©2021 YAG-dev · Unable to check current Platform Tools version";
            }
            if (File.Exists(ptlog))
            {
                string ptlog2 = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformToolsLog.txt"));
                Changelog.Text = ptlog2;
            }
            else
            {
                Changelog.Text = "Changelog not available for this release.";
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
            TTOutOfDate.Visibility = Visibility.Hidden;
            TTOutOfDateTxt1.Visibility = Visibility.Hidden;
            TTOutOfDateTxt2.Visibility = Visibility.Hidden;
            Update.Visibility = Visibility.Hidden;
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string remote_version_url2 = "https://www.dropbox.com/s/iseh3e7tzpujznt/version.txt?dl=1";
                string url = "https://www.dropbox.com/s/8nz4xbwb1dlb9hl/PlatformToolsPackage.zip?dl=1";
                string version_key2 = "Platform Tools ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "Update", "Download");
                string update_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "TempDownload");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateFiles");
                string local_version_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {

                    }, DispatcherPriority.Normal);
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
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
                        }, DispatcherPriority.Normal);
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
        }

        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UpdateCenter.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DiscoverAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://developer.android.com/studio/releases/platform-tools#revisions";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
