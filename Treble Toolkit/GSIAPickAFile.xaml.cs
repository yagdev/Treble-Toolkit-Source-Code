using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIAPickAFile.xaml
    /// </summary>
    public partial class GSIAPickAFile : Page
    {
        public GSIAPickAFile()
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
            String command = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & start .";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Continuelbl.Content = "Checking...";
            String command5 = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
            ProcessStartInfo cmdsi5 = new ProcessStartInfo("cmd.exe");
            cmdsi5.Arguments = command5;
            Process cmd5 = Process.Start(cmdsi5);
            cmd5.WaitForExit();
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
                {
                    Title.Content = "This is not the correct file...";
                    FileSize.Visibility = Visibility.Visible;
                }
                else
                {
                    String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                    String command2 = @"/C adb.exe reboot-bootloader & fastboot.exe format system & fastboot.exe format userdata";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    Process cmd2 = Process.Start(cmdsi2);
                    cmd2.WaitForExit();
                    String command3 = @"/C fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img & fastboot.exe flash system ../Place_Files_Here/GSI/system.img & fastboot.exe reboot";
                    ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                    cmdsi3.Arguments = command3;
                    Process cmd3 = Process.Start(cmdsi3);
                    cmd3.WaitForExit();
                    String command4 = @"/C cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & wmic process where name='adb.exe' delete";
                    ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                    cmdsi4.Arguments = command4;
                    Process cmd4 = Process.Start(cmdsi4);
                    cmd4.WaitForExit();
                    Uri uri = new Uri("GSIFlashTerminated.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                String command6 = @"/C cd .. & cd Place_Files_Here & cd GSI & start .";
                ProcessStartInfo cmdsi6 = new ProcessStartInfo("cmd.exe");
                cmdsi6.Arguments = command6;
                Process cmd6 = Process.Start(cmdsi6);
                cmd6.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
