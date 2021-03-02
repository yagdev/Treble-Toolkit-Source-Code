using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIABFlash.xaml
    /// </summary>
    public partial class GSIABFlash : Page
    {
        public GSIABFlash()
        {
            InitializeComponent();
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd vbmeta & ren * vbmeta.img";
            Process.Start("CMD.exe", strCmdText);
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                VbmetaLbl.Visibility = Visibility.Hidden;
                VbmetaRectangle.Visibility = Visibility.Hidden;
                AddVbmeta.Visibility = Visibility.Hidden;
                VbmetaText.Visibility = Visibility.Hidden;
            }
            else
            {

            }
            if (File.Exists("../Place_Files_Here/boot/boot.img"))
            {
                AddBootBtn.Visibility = Visibility.Hidden;
                AddBootLabel.Visibility = Visibility.Hidden;
                BootRectangle.Visibility = Visibility.Hidden;
                Bootlbl.Visibility = Visibility.Hidden;
            }
            else
            {
                
            }
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
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                const string strCmdText = "/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets & fastboot.exe format system_a & fastboot.exe format system_b & fastboot.exe format userdata & fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot_a ../Place_Files_Here/boot/boot.img & fastboot.exe flash boot_b ../Place_Files_Here/boot/boot.img & fastboot.exe flash system_a ../Place_Files_Here/GSI/system.img & fastboot.exe flash system_b ../Place_Files_Here/GSI/system.img & fastboot.exe reboot & cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
                Process.Start("CMD.exe", strCmdText);
                Uri uri = new Uri("GSIFlashTerminatedAB.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Uri uri = new Uri("GSIABPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void AddVbmeta_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                VbmetaLbl.Visibility = Visibility.Hidden;
                VbmetaRectangle.Visibility = Visibility.Hidden;
                AddVbmeta.Visibility = Visibility.Hidden;
                VbmetaText.Visibility = Visibility.Hidden;
                ThisIsAwkward.Content = "This is awkward. We thought you needed a vbmeta file, but turns out you don't. Sorry!";
                ThisIsAwkward.Visibility = Visibility.Visible;
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd .. & cd Place_Files_Here & cd vbmeta & start .";
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void AddBoot_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/boot/boot.img"))
            {
                AddBootBtn.Visibility = Visibility.Hidden;
                AddBootLabel.Visibility = Visibility.Hidden;
                BootRectangle.Visibility = Visibility.Hidden;
                Bootlbl.Visibility = Visibility.Hidden;
                ThisIsAwkward.Content = "This is awkward. We thought you needed a boot file, but turns out you don't. Sorry!";
                ThisIsAwkward.Visibility = Visibility.Visible;
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                const string strCmdText = "/C cd .. & cd Place_Files_Here & cd boot & start .";
                Process.Start("CMD.exe", strCmdText);
            }
        }
    }
}
