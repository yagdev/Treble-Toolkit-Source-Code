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
using System.Diagnostics;

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
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format system_a";
            Process.Start("CMD.exe", strCmdText);
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format system_b";
            Process.Start("CMD.exe", strCmdText);
        }

        private void A2Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format boot_a";
            Process.Start("CMD.exe", strCmdText);
        }

        private void B2Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format boot_b";
            Process.Start("CMD.exe", strCmdText);
        }

        private void UButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe erase userdata";
            Process.Start("CMD.exe", strCmdText);
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe format cache";
            Process.Start("CMD.exe", strCmdText);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
