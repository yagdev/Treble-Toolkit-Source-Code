using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;
using NHotkey;
using NHotkey.Wpf;
using System.Windows.Input;

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
            HotkeyManager.Current.AddOrReplace("Increment", Key.D, ModifierKeys.Control, OnIncrement);
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Preparation);
            thread2.Start();
        }
        private void OnIncrement(object sender, HotkeyEventArgs e)
        {
            Debug1.Visibility = Visibility.Visible;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Flash);
            thread.Start();
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            String command2 = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe flash recovery ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
            cmdsi2.Arguments = command2;
            Process cmd2 = Process.Start(cmdsi2);
            cmd2.WaitForExit();
            Uri uri = new Uri("TWRPFlashFinished.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
        private void Preparation()
        {
            this.Dispatcher.Invoke(() =>
            {
                Debug1.Visibility = Visibility.Hidden;
            });
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void Flash()
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/TWRP/twrp.img"))
            {
                this.Dispatcher.Invoke(() =>
                {
                    NotFound.Visibility = Visibility.Hidden;
                });
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Title.Content = "Holy crap, that's a big file!";
                        FileSize.Visibility = Visibility.Visible;
                    });
                }
                else
                {
                    String command2 = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe flash recovery ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & wmic process where name='adb.exe' delete";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    Process cmd2 = Process.Start(cmdsi);
                    cmd2.WaitForExit();
                    this.Dispatcher.Invoke(() =>
                    {
                        Uri uri = new Uri("TWRPFlashFinished.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    NotFound.Visibility = Visibility.Visible;
                });
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
