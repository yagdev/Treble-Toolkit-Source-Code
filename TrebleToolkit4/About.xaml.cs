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
using System.Windows.Shapes;
using ChaseLabs.CLUpdate;
using System.Windows.Threading;

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public About()
        {
            InitializeComponent();
            /// This is abandoned code for a cut feature on 21.1.1 (Outdated program alert). Maybe it will return in later versions. - YAG-dev on 25/1/2021
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C mkdir UpdateInfo & cd UpdateInfo & mkdir CurrentVersion & cd CurrentVersion";
            process.StartInfo = startInfo;
            process.Start();
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Checking for Updates...";
                }, DispatcherPriority.Normal);

                string url = "https://www.dropbox.com/s/pqnwsjlw8e6tdcv/update.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/2iio6h7fe1xlje8/version.txt?dl=1";
                string version_key = "application: ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update", "Download");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateFiles");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "UpdateInfo", "CurrentVersion", "VersionString.txt");
                string launch_exe = "TrebleToolkitLauncher.exe";

                var update = Updater.Init(url, update_path, application_path, launch_exe);

                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    status_lbl.Content = "There is an update available to Treble Toolkit.";
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/C cd .. & cd .. & TrebleToolkitLauncher.exe";
            process2.StartInfo = startInfo2;
            process2.Start();
            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/C taskkill /im gui.exe & taskkill /im gui.exe";
            process2.StartInfo = startInfo2;
            process2.Start();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
