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
    public partial class GSIFlashAB : Page
    {
        public GSIFlashAB()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckPhone);
            thread2.Start();
            Thread thread3 = new Thread(Flash);
            thread3.Start();
            Thread thread4 = new Thread(UpdateUI);
            thread4.Start();
        }

        private void DSF_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Cancel);
            thread.Start();
        }
        //Threading starts here -- 5/11/2021@22:07, YAG-dev, 21.12+
        private void Animate()
        {
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    GridMain.Opacity = 0;
                    Grid r = (Grid)GridMain;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    r.BeginAnimation(Grid.OpacityProperty, animation);
                });
            }
        }
        private void CheckPhone()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C fastboot.exe devices";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (output3.Contains("fastboot"))
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneStatus2.Content = output3;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneStatus2.Content = "Not Detected. Uh oh...";
                });
            }
        }
        private void Flash()
        {
            string VbmetaFlashYes = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "FlashVbmetaYes.txt");
            string BootFlashYes = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "FlashBootYes.txt");
            string FormatYes = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "FormatYes.txt");
            string Fastbootd = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Fastbootd.txt");
            string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value = 0;
                status_lbl.Content = "Doing some preparations...";
            });
            if (File.Exists(Fastbootd))
            {
                String command0 = @"/C adb.exe reboot-bootloader & fastboot.exe reboot fastboot";
                ProcessStartInfo cmdsi0 = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi0.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi0.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi0.Arguments = command0;
                Process cmd0 = Process.Start(cmdsi0);
                cmd0.WaitForExit();
            }
            String command = @"/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
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
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value += 5;
                status_lbl.Content = "Looks like we froze... Please try installing the ADB/Fastboot drivers.";
            });
            if (File.Exists(FormatYes))
            {
                String command2 = @"/C fastboot.exe format system_a & fastboot.exe format system_b & fastboot.exe format userdata";
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
            }
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value += 5;
                status_lbl.Content = "Flashing vbmeta and boot images...";
            });
            if (File.Exists(BootFlashYes))
            {
                String command3 = @"/C fastboot.exe flash boot_a ../Place_Files_Here/boot/boot.img & fastboot.exe flash boot_b ../Place_Files_Here/boot/boot.img";
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
            }
            if (File.Exists(VbmetaFlashYes))
            {
                String command3 = @"/C fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img";
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
            }
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value += 10;
                status_lbl.Content = "Flashing GSI...";
            });
            String command4 = @"/C fastboot.exe flash system_a ../Place_Files_Here/GSI/system.img & fastboot.exe flash system_b ../Place_Files_Here/GSI/system.img";
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
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value += 70;
                status_lbl.Content = "Finishing up...";
            });
            if (File.Exists(Fastbootd))
            {
                String commandf = @"/C fastboot.exe reboot bootloader";
                ProcessStartInfo cmdsif = new ProcessStartInfo("cmd.exe");
                if (File.Exists(VisibleCMD))
                {
                    cmdsif.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsif.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsif.Arguments = commandf;
                Process cmdf = Process.Start(cmdsif);
                cmdf.WaitForExit();
            }
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
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value = 100;
                status_lbl.Content = "Finished";
            });
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("GSIFlashTerminatedAB.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void Cancel()
        {
            this.Dispatcher.Invoke(() =>
            {
                status_lbl.Content = "Cancelling...";
            });
            String command = @"/C taskkill /F /IM adb.exe /T & taskkill /F /IM fastboot.exe /T & taskkill /F /IM cmd.exe /T";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            Process cmd2 = Process.Start(cmdsi);
            cmd2.WaitForExit();
            Process cmd3 = Process.Start(cmdsi);
            cmd3.WaitForExit();
            Process cmd4 = Process.Start(cmdsi);
            cmd4.WaitForExit();
            Process cmd5 = Process.Start(cmdsi);
            cmd5.WaitForExit();
            Process cmd6 = Process.Start(cmdsi);
            cmd6.WaitForExit();
            Process cmd7 = Process.Start(cmdsi);
            cmd7.WaitForExit();
            Process cmd8 = Process.Start(cmdsi);
            cmd8.WaitForExit();
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flashing-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flashing-light.png"));
                }
            });
        }
    }
}
