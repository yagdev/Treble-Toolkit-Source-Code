using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para VendorFlash.xam
    /// </summary>
    public partial class VendorFlash : Page
    {
        public VendorFlash()
        {
            InitializeComponent();
            ReportLabel.Visibility = Visibility.Hidden;
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
            String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & ren * vendor.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/Vendor/vendor.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\Vendor\vendor.img");
                if (fInfo.Length < 300000000)
                {
                    Title.Content = "This is not the correct file...";
                    FileSize.Visibility = Visibility.Visible;
                    String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & cd .";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                }
                else
                {
                    if (fInfo.Length > 1500000000)
                    {
                        Title.Content = "Holy crap, that's a big file!";
                        FileSize.Visibility = Visibility.Visible;
                        FileSize.Content = "Your Vendor file is above 1.5GB and is likely not the correct file. Try again";
                        String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & cd .";
                        ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                        cmdsi.Arguments = command;
                        Process cmd = Process.Start(cmdsi);
                        cmd.WaitForExit();
                    }
                    else
                    {
                        String command = @"/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir vendor & cd vendor & ren *.img vendor.img & cd .. & cd .. & cd assets & fastboot.exe format vendor & fastboot.exe flash vendor ../Place_Files_Here/Vendor/vendor.img & fastboot.exe reboot & wmic process where name='adb.exe' delete";
                        ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                        cmdsi.Arguments = command;
                        Process cmd = Process.Start(cmdsi);
                        cmd.WaitForExit();
                        Uri uri = new Uri("VendorFinished.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    }
                }
            }
            else
            {
                Uri uri = new Uri("VendorPickFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
