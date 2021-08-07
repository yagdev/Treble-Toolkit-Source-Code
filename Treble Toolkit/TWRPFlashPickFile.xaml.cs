using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;

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
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
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
            Uri uri = new Uri("TWRPFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/TWRP/twrp.img"))
            {
                NotFound.Visibility = Visibility.Hidden;
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    Title.Content = "Holy crap, that's a big file!";
                    FileSize.Visibility = Visibility.Visible;
                }
                else
                {
                    String command2 = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe flash recovery ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & wmic process where name='adb.exe' delete";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    Process cmd2 = Process.Start(cmdsi);
                    cmd2.WaitForExit();
                    Uri uri = new Uri("TWRPFlashFinished.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                NotFound.Visibility = Visibility.Visible;
                String command3 = @"/C cd .. & cd Place_Files_Here & cd TWRP & start .";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
