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

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TWRPBoot.xaml
    /// </summary>
    public partial class TWRPBoot : Page
    {
        public TWRPBoot()
        {
            InitializeComponent();
            ReportLabel.Visibility = Visibility.Hidden;
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            ReportLabel.Visibility = Visibility.Visible;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C systeminfo & adb shell getprop & wmic process where name='adb.exe' delete & mkdir BugReports & cd BugReports & mkdir SystemInfo";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            using (StreamReader reader = process.StandardOutput)
            {
                string system_info_path = System.IO.Path.Combine(Environment.CurrentDirectory, "BugReports", "SystemInfo", "SystemReport.txt");
                using (StreamWriter sw = File.CreateText(system_info_path))
                {
                    sw.WriteLine("Treble Toolkit System Report");
                    sw.WriteLine("©2021 YAG-dev");
                    sw.WriteLine(output);
                }
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://github.com/yagdev/Treble-Toolkit-Source-Code/issues";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/TWRP/twrp.img"))
            {
                
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    Title.Content = "Holy crap, that's a big file!";
                    FileSize.Visibility = Visibility.Visible;
                }
                else
                {
                    String command = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe boot ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & wmic process where name='adb.exe' delete";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                    Uri uri = new Uri("TWRPBootFinished.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                Uri uri = new Uri("TWRPBootPickFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
