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
using ChaseLabs.CLUpdate;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
using Microsoft.CSharp;
using System.Windows.Media.Animation;

namespace Treble_Toolkit_Installer
{
    /// <summary>
    /// Interaction logic for ProgramFiles.xaml
    /// </summary>
    public partial class ProgramFiles : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public ProgramFiles()
        {
            InitializeComponent();
            GridMain.Opacity = 0;
            Grid r = (Grid)GridMain;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
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
                        status_pgr.Visibility = Visibility.Visible;
                        status_pgr.Value = 0;
                        status_pgr.Value += 0;
                    }, DispatcherPriority.Normal);

                    string url = "https://www.dropbox.com/s/pqnwsjlw8e6tdcv/update.zip?dl=1";
                    string remote_version_url = "https://www.dropbox.com/s/2iio6h7fe1xlje8/version.txt?dl=1";
                    string version_key = "application: ";
                    string update_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Treble_Toolkit", "Update", "Download");
                    string application_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Treble_Toolkit", "UpdateFiles");
                    string local_version_path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Treble_Toolkit", "UpdateInfo", "CurrentVersion", "VersionString.txt");
                    string launch_exe = "TrebleToolkitLauncher.exe";

                    var update = Updater.Init(url, update_path, application_path, launch_exe);

                    if (UpdateManager.CheckForUpdate(version_key, local_version_path, remote_version_url))
                    {
                        process.Start();
                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Initializing Download...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Download();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Downloading...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.Unzip();

                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Unzipping...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        update.CleanUp();


                        dis.Invoke(() =>
                        {
                            status_lbl.Content = "Finishing Up...";
                            status_pgr.Value += 20;
                        }, DispatcherPriority.Normal);

                        using (var client = new System.Net.WebClient())
                        {

                        }

                    }

                    dis.Invoke(() =>
                    {
                        Uri uri = new Uri("DonePF.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                        status_lbl.Content = "Done.";
                        status_pgr.Value += 20;
                    }, DispatcherPriority.Normal);
                    object shDesktop = (object)"Desktop";
                    object shStartMenu = (object)"StartMenu";
                    WshShell shell = new WshShell();
                    string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Treble Toolkit.lnk";
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                    shortcut.Description = "Executable for Treble Toolkit";
                    shortcut.Hotkey = "Ctrl+Shift+N";
                    shortcut.TargetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe";
                    shortcut.WorkingDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Treble_Toolkit");
                    shortcut.Save();
                    using (var fs = new FileStream(shortcutAddress, FileMode.Open, FileAccess.ReadWrite))
                    {
                        fs.Seek(21, SeekOrigin.Begin);
                        fs.WriteByte(0x22);
                    }
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C cd %ProgramFiles% & cd Treble_Toolkit & cd UpdateFiles & move Application ../ & move TrebleToolkitLauncher.exe ../ & cd .. & RD /s /q UpdateFiles & cd .. & RD /s /q UpdateInfo & cd %UserProfile% & cd Desktop & copy \u0022Treble Toolkit.lnk\u0022 \u0022%AppData%/Microsoft/Windows/Start Menu/\u0022";
                    process.StartInfo = startInfo;
                    process.Start();
                });
            }
            else
            {
                Uri uri = new Uri("Start.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object shDesktop = (object)"Desktop";
            object shStartMenu = (object)"StartMenu";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Treble Toolkit.lnk";
            string shortcutAddress2 = (string)shell.SpecialFolders.Item(ref shStartMenu) + @"\Treble Toolkit.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            IWshShortcut shortcut2 = (IWshShortcut)shell.CreateShortcut(shortcutAddress2);
            shortcut.Description = "Executable for Treble Toolkit";
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe";
            shortcut.Save();
            shortcut2.Description = "Executable for Treble Toolkit";
            shortcut2.Hotkey = "Ctrl+Shift+N";
            shortcut2.TargetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe";
            shortcut2.Save();
            Uri uri = new Uri("Done.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
