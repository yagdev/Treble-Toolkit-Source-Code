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
using System.Diagnostics;

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
            Thread thread = new Thread(PlatformToolsUI);
            thread.Start();
            Thread thread2 = new Thread(CheckForUpdates);
            thread2.Start();
            Thread thread3 = new Thread(CheckForWindowsVersion);
            thread3.Start();
            Thread thread4 = new Thread(Animate);
            thread4.Start();
            Thread thread5 = new Thread(UpdateUI);
            thread5.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void AboutMe_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("DiscoverMore.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UpdateCenter.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DiscoverAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit/22-4";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy4_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("QSG.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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

        //Threading starts here -- 5/11/2021@22:07, YAG-dev, 21.12+
        private void PlatformToolsUI()
        {
            string ptpath = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
            if (File.Exists(ptpath))
            {
                string ptversion = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt"));
                this.Dispatcher.Invoke(() =>
                {
                    PT_Version.Content = ptversion;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PT_Version.Content = "Unable to check";
                });
            }
        }
        private void CheckForUpdates()
        {
            string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "CurrentVersion", "VersionString.txt");
            int Out;
            if (File.Exists(local_version_path))
            {

            }
            else
            {
                String command = @"/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
            }
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                string url = "https://www.dropbox.com/s/f76ks90k8gvi0p5/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/elbmcwbx389z71o/version.txt?dl=1";
                string remote_version_url2 = "https://www.dropbox.com/s/iseh3e7tzpujznt/version.txt?dl=1";
                string version_key = "Treble Toolkit ";
                string version_key2 = "Platform Tools ";
                string update_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "TempDownload");
                string local_version_path2 = System.IO.Path.Combine(Environment.CurrentDirectory, "PlatformTools.txt");
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
                        this.Dispatcher.Invoke(() =>
                        {
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
                            TTUpdateRectangle.Effect = myDropShadowEffect;
                            DeviceSpecificFeatures_Copy3.Effect = myDropShadowEffect;
                            UpdateCheckTxt.Content = "Updates Available";
                            DeviceSpecificFeatures_Copy3.Content = "Update (Recommended)";
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            UpdateCheckTxt.Content = "Up to date";
                        });
                    }
                    if (UpdateManager.CheckForUpdate(version_key2, local_version_path2, remote_version_url2))
                    {
                        this.Dispatcher.Invoke(() =>
                        {
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
                            PTRectangle.Effect = myDropShadowEffect;
                            DeviceSpecificFeatures_Copy3.Effect = myDropShadowEffect;
                            PTCheck.Content = "Updates Available";
                            DeviceSpecificFeatures_Copy3.Content = "Update (Recommended)";
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            PTCheck.Content = "Up to date";
                        });
                    }
                });
            }
            else
            {
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
                    TTUpdateRectangle.Effect = myDropShadowEffect;
                    DeviceSpecificFeatures_Copy3.Effect = myDropShadowEffect;
                    UpdateCheckTxt.Content = "Unable to check...";
                    DeviceSpecificFeatures_Copy3.Content = "Update (Recommended)";
                });
            }
        }
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
        private void CheckForWindowsVersion()
        {
            if (Environment.OSVersion.Version.Build >= 9)
            {

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    VersionCheck.Content = VersionCheck.Content + " · Support features have been disabled.";
                });
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy8.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-freecmd-dark.png"));
                    DeviceInfoImg_Copy9.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy8.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-freecmd-light.png"));
                    DeviceInfoImg_Copy9.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                }
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                if (File.Exists(beta_path))
                {
                    VersionCheck.Content = VersionCheck.Content + " (Beta)";
                }
            });
        }
    }
}
