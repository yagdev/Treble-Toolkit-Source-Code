﻿using System;
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
using ChaseLabs.CLUpdate;
using System.Windows.Threading;

namespace TrebleToolkitUpdaterLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dispatcher dis = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        void Update()
        {
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Preparing to Install...";
                }, DispatcherPriority.Normal);

                string url = "https://www.dropbox.com/s/b064v1bhhomzxx0/release.zip?dl=1";
                string remote_version_url = "https://www.dropbox.com/s/xowfvfnd8it4suw/version?dl=1";
                string version_key = "application: ";
                string update_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Update");
                string application_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Application");
                string local_version_path = System.IO.Path.Combine(Environment.CurrentDirectory, "Application", "UpdateService", "CurrentVersion");
                string launch_exe = "TrebleToolkitLauncher.exe";

                var update = Updater.Init(url, update_path, application_path, launch_exe);

                if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                {
                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Initializing Download...";
                    }, DispatcherPriority.Normal);

                    update.Download();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Downloading...";
                    }, DispatcherPriority.Normal);

                    update.Unzip();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Unzipping...";
                    }, DispatcherPriority.Normal);

                    update.CleanUp();

                    dis.Invoke(() =>
                    {
                        status_lbl.Content = "Cleaning Up...";
                    }, DispatcherPriority.Normal);

                    using (var client = new System.Net.WebClient())
                    {
                        client.DownloadFile(remote_version_url, local_version_path);
                        client.Dispose();
                    }

                }

                dis.Invoke(() =>
                {
                    status_lbl.Content = "Treble Toolkit is Up To Date. Launching...";
                }, DispatcherPriority.Normal);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd Application & cd assets & gui.exe";
                process.StartInfo = startInfo;
                process.Start();
            });
        }
    }
}
