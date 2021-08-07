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
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIFlashAB.xaml
    /// </summary>
    public partial class GSIFlashA : Page
    {
        public GSIFlashA()
        {
            InitializeComponent();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {

            }
            else
            {
                GridMain.Opacity = 0;
                Grid r = (Grid)GridMain;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                r.BeginAnimation(Grid.OpacityProperty, animation);
            }
            status_lbl_Copy.Visibility = Visibility.Hidden;
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    status_pgr.Value = 0;
                    status_lbl.Content = "Doing some preparations...";
                }, DispatcherPriority.Normal);
                String command = @"/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                dis.Invoke(() =>
                {
                    status_pgr.Value += 5;
                    status_lbl.Content = "Formatting partitions...";
                    status_lbl_Copy.Visibility = Visibility.Visible;
                }, DispatcherPriority.Normal);
                String command2 = @"/C fastboot.exe format system & fastboot.exe format userdata";
                ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi2.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi2.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi2.Arguments = command2;
                Process cmd2 = Process.Start(cmdsi2);
                cmd2.WaitForExit();
                dis.Invoke(() =>
                {
                    status_pgr.Value += 5;
                    status_lbl.Content = "Flashing vbmeta and boot images...";
                    status_lbl_Copy.Visibility = Visibility.Hidden;
                }, DispatcherPriority.Normal);
                String command3 = @"/C fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi3.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi3.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                dis.Invoke(() =>
                {
                    status_pgr.Value += 10;
                    status_lbl.Content = "Flashing GSI...";
                }, DispatcherPriority.Normal);
                String command4 = @"/C fastboot.exe flash system ../Place_Files_Here/GSI/system.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi4.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi4.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
                dis.Invoke(() =>
                {
                    status_pgr.Value += 70;
                    status_lbl.Content = "Finishing up...";
                }, DispatcherPriority.Normal);
                String command5 = @"/C fastboot.exe reboot & cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & wmic process where name='adb.exe' delete";
                ProcessStartInfo cmdsi5 = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi5.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi5.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi5.Arguments = command5;
                Process cmd5 = Process.Start(cmdsi5);
                cmd5.WaitForExit();
                dis.Invoke(() =>
                {
                    status_pgr.Value = 100;
                    status_lbl.Content = "Finished";
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    Uri uri = new Uri("GSIFlashTerminatedAB.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }, DispatcherPriority.Normal);
            });
        }

        private void DSF_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                dis.Invoke(() =>
                {
                    status_lbl.Content = "Cancelling...";
                    String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }, DispatcherPriority.Normal);
                Uri uri = new Uri("GSIAFlash.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }

        private void GridMain_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void GridMain_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Page_Initialized(object sender, EventArgs e)
        {

        }
    }
}
