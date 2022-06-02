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
using System.Threading;

namespace TrebleToolkitLauncher
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckBetaEnrollment);
            thread2.Start();
            Thread thread3 = new Thread(CheckUpdateEnrollment);
            thread3.Start();
            Thread thread4 = new Thread(x8632Specific);
            thread4.Start();
            Thread thread5 = new Thread(UpdateUI);
            thread5.Start();
        }

        private void UpdateLauncher(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Reinstall(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ToggleUpdates);
            thread.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ToggleBetaEnrollment);
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
        private void CheckBetaEnrollment()
        {
            string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
            string blocker_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "UpdateBlocker", "BlockUpdates.txt");
            if (File.Exists(beta_path))
            {
                this.Dispatcher.Invoke(() =>
                {
                    BetaUpdatesToggle.Content = "Stop Receiving Beta Updates";
                    BranchCheck.Content = "Beta";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    BetaUpdatesToggle.Content = "Receive Beta Updates";
                    BranchCheck.Content = "Stable";
                });
            }
        }
        private void CheckUpdateEnrollment()
        {
            string blocker_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "UpdateBlocker", "BlockUpdates.txt");
            if (File.Exists(blocker_path))
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateToggle.Content = "Enable Updates";
                    UpdateIsEnabledChecker.Content = "Disabled";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    UpdateToggle.Content = "Disable Updates";
                    UpdateIsEnabledChecker.Content = "Enabled";
                });
            }
        }
        private void ToggleUpdates()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir UpdateBlock & cd CurrentVersion & del /f /q ";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string blocker_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "UpdateBlocker", "BlockUpdates.txt");
            if (File.Exists(blocker_path))
            {
                File.Delete(blocker_path);
                this.Dispatcher.Invoke(() =>
                {
                    UpdateToggle.Content = "Disable Updates";
                    UpdateIsEnabledChecker.Content = "Enabled";
                });
            }
            else
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir UpdateBlocker";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                using (StreamWriter sw = File.CreateText(blocker_path))
                {
                    sw.WriteLine("Treble Toolkit Settings - Disable Updates");
                    sw.WriteLine("©2021 YAG-dev");
                }
                this.Dispatcher.Invoke(() =>
                {
                    UpdateToggle.Content = "Enable Updates";
                    UpdateIsEnabledChecker.Content = "Disabled";
                });
            }
        }
        private void ToggleBetaEnrollment()
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
                if (File.Exists(beta_path))
                {
                    if (File.Exists(version_path))
                    {
                        File.Delete(version_path);
                    }
                    File.Delete(beta_path);
                    this.Dispatcher.Invoke(() =>
                    {
                        BetaUpdatesToggle.Content = "Receive Beta Updates";
                        BranchCheck.Content = "Stable";
                    });
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
                    this.Dispatcher.Invoke(() =>
                    {
                        BetaUpdatesToggle.Content = "Stop Receiving Beta Updates";
                        BranchCheck.Content = "Beta";
                    });
                }
            }
            else
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                File.Delete(beta_path);
            }
        }
        private void x8632Specific()
        {
            if(Environment.Is64BitOperatingSystem == false)
            {
                this.Dispatcher.Invoke(() =>
                {
                    string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                    if (File.Exists(beta_path))
                    {
                        File.Delete(beta_path);
                    }
                    BetaUpdatesToggle.IsEnabled = false;
                    BetaUpdatesToggle.Content = "This feature is not available in this PC.";
                });
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-settings-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    BetaUpdatesToggle.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    UpdateLauncher_Btn.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-restart-dark.png"));
                    UpdateToggle.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-dark.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-widgets-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-settings-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-checkmark-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    BetaUpdatesToggle.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    UpdateLauncher_Btn.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-restart-light.png"));
                    UpdateToggle.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-up-light.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TrebleToolkitLauncher;Component/tt-widgets-light.png"));
                }
            });
        }
    }
}
