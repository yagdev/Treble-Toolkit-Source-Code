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
using System.Windows.Media;

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
            HotkeyManager.Current.AddOrReplace("Increment", Key.D, ModifierKeys.Control, OnIncrement);
            Debug1.Visibility = Visibility.Hidden;
            DbgRct1.Visibility = Visibility.Hidden;
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Preparation);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
        }
        private void OnIncrement(object sender, HotkeyEventArgs e)
        {
            Debug1.Visibility = Visibility.Visible;
            DbgRct1.Visibility = Visibility.Visible;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("VendorFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Flash);
            thread.Start();
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            String command4 = @"/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir vendor & cd vendor & ren *.img vendor.img & cd .. & cd .. & cd assets & fastboot.exe format vendor & fastboot.exe flash vendor ../Place_Files_Here/Vendor/vendor.img & fastboot.exe reboot & wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
            cmdsi4.Arguments = command4;
            Process cmd4 = Process.Start(cmdsi4);
            cmd4.WaitForExit();
            Uri uri = new Uri("FlashVendorFinished.xaml", UriKind.Relative);
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
            String command = @"/C cd .. & cd Place_Files_Here & cd Vendor & ren * vendor.img & start .";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void Flash()
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
                        this.Dispatcher.Invoke(() =>
                        {
                            Uri uri = new Uri("FlashVendorFinished.xaml", UriKind.Relative);
                            this.NavigationService.Navigate(uri);
                        });
                    }
                }
            }
            else
            {
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-dark.png"));
                    Debug1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-light.png"));
                    Debug1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                }
            });
        }
    }
}
