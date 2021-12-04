using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for FormatPartitions.xaml
    /// </summary>
    public partial class FormatPartitions : Page
    {
        public FormatPartitions()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click1);
            thread.Start();
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click2);
            thread.Start();
        }

        private void A2Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click3);
            thread.Start();
        }

        private void B2Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click4);
            thread.Start();
        }

        private void UButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click5);
            thread.Start();
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click6);
            thread.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void VendorButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click7);
            thread.Start();
        }

        private void VendorButtonB_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Click8);
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
        private void Click1()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format system_a";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click2()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format system_b";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click3()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format boot_a";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click4()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format boot_b";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click5()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe erase userdata";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click6()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format cache";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click7()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format vendor_a";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Click8()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format vendor_b";
            Process.Start("CMD.exe", strCmdText);
        }
    }
}
