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
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img";
            Process.Start("CMD.exe", strCmdText);
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C start https://github.com/yagdev/Treble-Toolkit-Source-Code/issues";
            Process.Start("CMD.exe", strCmdText);
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
                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                const string strCmdText = "/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe boot ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & taskkill /f /im adb.exe";
                Process.Start("CMD.exe", strCmdText);
                Uri uri = new Uri("TWRPBootFinished.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Uri uri = new Uri("TWRPBootPickFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
