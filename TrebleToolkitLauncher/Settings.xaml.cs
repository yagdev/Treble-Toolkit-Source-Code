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
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "Settings", "NotAnimated.txt");
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
            string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
            string blocker_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "UpdateBlocker", "BlockUpdates.txt");
            if (File.Exists(beta_path))
            {
                BetaUpdatesToggle.Content = "Stop Receiving Beta Updates";
                BranchCheck.Content = "Beta";
            }
            else
            {
                BetaUpdatesToggle.Content = "Receive Beta Updates";
                BranchCheck.Content = "Stable";
            }
            if (File.Exists(blocker_path))
            {
                UpdateToggle.Content = "Enable Updates";
                UpdateIsEnabledChecker.Content = "Disabled";
            }
            else
            {
                UpdateToggle.Content = "Disable Updates";
                UpdateIsEnabledChecker.Content = "Enabled";
            }
        }

        private void UpdateLauncher(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Reinstall(object sender, RoutedEventArgs e)
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
                UpdateToggle.Content = "Disable Updates";
                UpdateIsEnabledChecker.Content = "Enabled";
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
                UpdateToggle.Content = "Enable Updates";
                UpdateIsEnabledChecker.Content = "Disabled";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
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
                    BetaUpdatesToggle.Content = "Receive Beta Updates";
                    BranchCheck.Content = "Stable";
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
                    BetaUpdatesToggle.Content = "Stop Receiving Beta Updates";
                    BranchCheck.Content = "Beta";
                }
            }
            else
            {
                string beta_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "BetaProgram", "BetaProgram.txt");
                File.Delete(beta_path);
            }
        }
    }
}
