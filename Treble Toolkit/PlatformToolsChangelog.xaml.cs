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
using System.Threading;

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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI2);
            thread3.Start();
            Thread thread4 = new Thread(UpdateUI3);
            thread4.Start();
            Thread thread5 = new Thread(CheckForUpdates);
            thread5.Start();
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
            Thread thread = new Thread(Website);
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
            string ptpath = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
            string ptlog = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformToolsLog.txt");
            if (File.Exists(ptpath))
            {
                this.Dispatcher.Invoke(() =>
                {
                    string ptversion = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt"));
                    copyright.Content = ptversion;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    copyright.Content = "Unable to check current Platform Tools version.";
                });
            }
        }
        private void UpdateUI2()
        {
            string ptlog = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformToolsLog.txt");
            if (File.Exists(ptlog))
            {
                string ptlog2 = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformToolsLog.txt"));
                this.Dispatcher.Invoke(() =>
                {
                    Changelog.Text = ptlog2;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Changelog.Text = "Changelog not available for this release.";
                });
            }
        }
        private void UpdateUI3()
        {
            this.Dispatcher.Invoke(() =>
            {
                Update.Visibility = Visibility.Hidden;
            });
        }
        private void CheckForUpdates()
        {
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
                    var update = Updater.Init(url, update_path, application_path, launch_exe);
                    if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Title_Copy.Content = "Platform Tools · Please Update";
                            Update.Visibility = Visibility.Visible;
                            DropShadowEffect myDropShadowEffect = new DropShadowEffect();
                            // Set the color of the shadow to Black.
                            Color myShadowColor = new Color();
                            myShadowColor.A = 255; // Note that the alpha value is ignored by Color property. 
                                                   // The Opacity property is used to control the alpha.
                            myShadowColor.B = 0;
                            myShadowColor.G = 255;
                            myShadowColor.R = 255;
                            myDropShadowEffect.Direction = 0;
                            myDropShadowEffect.ShadowDepth = 0;
                            myDropShadowEffect.Color = myShadowColor;
                            Reptangle.Effect = myDropShadowEffect;
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Title_Copy.Content = "Platform Tools";
                            Update.Visibility = Visibility.Hidden;
                        });
                    }
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Title_Copy.Content = "Platform Tools · Unable To Check For Updates";
                    Update.Visibility = Visibility.Visible;
                });
                this.Dispatcher.Invoke(() =>
                {
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
                    Reptangle.Effect = myDropShadowEffect;
                });
            }
        }
        private void Website()
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
