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
using IWshRuntimeLibrary;
using System.IO;
using System.Runtime.InteropServices;


namespace Treble_Toolkit_Installer
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        public Start()
        {
            InitializeComponent();
            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Treble_Toolkit", "TrebleToolkitLauncher.exe")))
            {
                TT.Content = "We detected that Treble Toolkit is already installed.";
                C.Visibility = Visibility.Hidden;
                CL.Visibility = Visibility.Hidden;
                CR.Visibility = Visibility.Hidden;
                RU.Visibility = Visibility.Visible;
                RUL.Visibility = Visibility.Visible;
                RUR.Visibility = Visibility.Visible;
            }
            else
            {
                
            }
            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe"))
            {
                TT.Content = "We detected that Treble Toolkit is already installed.";
                C.Visibility = Visibility.Hidden;
                CL.Visibility = Visibility.Hidden;
                CR.Visibility = Visibility.Hidden;
                RU.Visibility = Visibility.Visible;
                RUL.Visibility = Visibility.Visible;
                RUR.Visibility = Visibility.Visible;
            }
            else
            {

            }
            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe"))
            {
                TT.Content = "We detected that Treble Toolkit is already installed.";
                C.Visibility = Visibility.Hidden;
                CL.Visibility = Visibility.Hidden;
                CR.Visibility = Visibility.Hidden;
                RU.Visibility = Visibility.Visible;
                RUL.Visibility = Visibility.Visible;
                RUR.Visibility = Visibility.Visible;
            }
            else
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                Uri uri = new Uri("StorageDirectory.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Lbl.Content = "An internet connection is needed for this. Please connect to the internet and try again.";
                Lbl.FontSize = 10;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Treble Toolkit.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Executable for Treble Toolkit";
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Treble_Toolkit") + @"\TrebleToolkitLauncher.exe";
            shortcut.Save();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd %AppData% & cd Microsoft & cd Windows & cd Start Menu & del /f /q \u0022Treble Toolkit.lnk\u0022";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Reinstall(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Uninstall,Repair.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
