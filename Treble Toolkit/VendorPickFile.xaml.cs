using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para VendorPickFile.xam
    /// </summary>
    public partial class VendorPickFile : Page
    {
        public VendorPickFile()
        {
            InitializeComponent();
            NotFound.Visibility = Visibility.Hidden;
            FileSize.Visibility = Visibility.Hidden;
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
            String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & ren * vendor.img & start .";
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
            Uri uri = new Uri("VendorFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & ren * vendor.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/Vendor/vendor.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\Vendor\vendor.img");
                if (fInfo.Length < 300000000)
                {
                    Title.Content = "This is not the correct file...";
                    FileSize.Visibility = Visibility.Visible;
                    String command2 = @"/C cd .. & cd Place_Files_Here & cd Vendor & cd .";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    Process cmd2 = Process.Start(cmdsi2);
                    cmd2.WaitForExit();
                }
                else
                {
                    if (fInfo.Length > 1500000000)
                    {
                        Title.Content = "Holy crap, that's a big file!";
                        FileSize.Visibility = Visibility.Visible;
                        FileSize.Content = "Your Vendor file is above 1.5GB and is likely not the correct file. Try again";
                        String command3 = @"/C cd .. & cd Place_Files_Here & cd Vendor & cd .";
                        ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                        cmdsi3.Arguments = command3;
                        Process cmd3 = Process.Start(cmdsi3);
                        cmd3.WaitForExit();
                    }
                    else
                    {
                        String command4 = @"/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir vendor & cd vendor & ren *.img vendor.img & cd .. & cd .. & cd assets & fastboot.exe format vendor & fastboot.exe flash vendor ../Place_Files_Here/Vendor/vendor.img & fastboot.exe reboot & wmic process where name='adb.exe' delete";
                        ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                        cmdsi4.Arguments = command4;
                        Process cmd4 = Process.Start(cmdsi4);
                        cmd4.WaitForExit();
                        Uri uri = new Uri("VendorFinished.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    }
                }
            }
            else
            {
                NotFound.Visibility = Visibility.Visible;
                String command3 = @"/C cd .. & cd Place_Files_Here & cd Vendor & start .";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd Vendor & ren * vendor.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
