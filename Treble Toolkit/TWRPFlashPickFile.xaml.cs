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
using System.Threading;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TWRPFlashPickFile.xaml
    /// </summary>
    public partial class TWRPFlashPickFile : Page
    {
        public TWRPFlashPickFile()
        {
            InitializeComponent();
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ContinueLbl.Content = "Checking...";
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd GSI & ren * twrp.img";
            Process.Start("CMD.exe", strCmdText);
            Thread.Sleep(5000);
            if (File.Exists("../Place_Files_Here/GSI/twrp.img"))
            {
                const string str2CmdText = "/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe flash recovery ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & taskkill /f /im adb.exe";
                Process.Start("CMD.exe", str2CmdText);
                Uri uri = new Uri("TWRPFlashFinished.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                NotFound.Visibility = Visibility.Visible;
                const string strCmdText2 = "/C cd .. & cd Place_Files_Here & cd TWRP & start .";
                Process.Start("CMD.exe", strCmdText2);
            }
        }
    }
}
