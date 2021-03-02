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
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIABPickAFile.xaml
    /// </summary>
    public partial class GSIABPickAFile : Page
    {
        public GSIABPickAFile()
        {
            InitializeComponent();
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & start .";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ContinueLbl.Content = "Checking...";
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
            Process.Start("CMD.exe", strCmdText);
            Thread.Sleep(5000);
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                const string str2CmdText = "/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets & fastboot.exe format system_a & fastboot.exe format system_b & fastboot.exe format userdata & fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot_a ../Place_Files_Here/boot/boot.img & fastboot.exe flash boot_b ../Place_Files_Here/boot/boot.img & fastboot.exe flash system_a ../Place_Files_Here/GSI/system.img & fastboot.exe flash system_b ../Place_Files_Here/GSI/system.img & fastboot.exe reboot & cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
                Process.Start("CMD.exe", str2CmdText);
                Uri uri = new Uri("GSIFlashTerminatedAB.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                NotFound.Visibility = Visibility.Visible;
                const string strCmdText2 = "/C cd .. & cd Place_Files_Here & cd GSI & start .";
                Process.Start("CMD.exe", strCmdText2);
            }
        }
    }
}
