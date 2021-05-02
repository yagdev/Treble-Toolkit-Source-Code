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
using ChaseLabs.CLUpdate;
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for FlashingGSIA.xaml
    /// </summary>
    public partial class FlashingGSIA : Page
    {
        Dispatcher dis = Dispatcher.CurrentDispatcher;
        public FlashingGSIA()
        {
            InitializeComponent();
            Pgr_Label.Content = "Press Start to start flashing.";
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                Pgrbar.Value = 0;
                Pgr_Label.Content = "Getting things ready...";
                Pgrbar.Value += 20;
                String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                Pgr_Label.Content = "Formatting partitions...";
                Pgrbar.Value += 20;
                String command2 = @"/C adb.exe reboot-bootloader & fastboot.exe format system & fastboot.exe format userdata";
                ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                cmdsi2.Arguments = command2;
                Process cmd2 = Process.Start(cmdsi2);
                cmd2.WaitForExit();
                Pgr_Label.Content = "Starting flash...";
                Pgrbar.Value += 20;
                String command3 = @"/C fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img & fastboot.exe flash system ../Place_Files_Here/GSI/system.img & fastboot.exe reboot";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                Pgr_Label.Content = "Finishing up...";
                Pgrbar.Value += 20;
                String command4 = @"/C cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        Uri uri = new Uri("GSIFlashTerminated.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    }, DispatcherPriority.Normal);
                });
            }
            else
            {
                Uri uri = new Uri("GSIAPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                Pgrbar.Value = 0;
                Pgr_Label.Content = "Getting things ready...";
                Pgrbar.Value += 20;
                String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                Pgr_Label.Content = "Formatting partitions...";
                Pgrbar.Value += 20;
                String command2 = @"/C adb.exe reboot-bootloader & fastboot.exe format system & fastboot.exe format userdata";
                ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                cmdsi2.Arguments = command2;
                Process cmd2 = Process.Start(cmdsi2);
                cmd2.WaitForExit();
                Pgr_Label.Content = "Starting flash...";
                Pgrbar.Value += 20;
                String command3 = @"/C fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img & fastboot.exe flash system ../Place_Files_Here/GSI/system.img & fastboot.exe reboot";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                Pgr_Label.Content = "Finishing up...";
                Pgrbar.Value += 20;
                String command4 = @"/C cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        Uri uri = new Uri("GSIFlashTerminated.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    }, DispatcherPriority.Normal);
                });
            }
            else
            {
                Uri uri = new Uri("GSIAPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
