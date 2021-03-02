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
    /// Interaction logic for UnlockBootloader.xaml
    /// </summary>
    public partial class UnlockBootloader : Page
    {
        public UnlockBootloader()
        {
            InitializeComponent();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C start https://github.com/yagdev/Treble-Toolkit-Source-Code/issues";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & fastboot.exe oem unlock & taskkill /f /im adb.exe";
            Process.Start("CMD.exe", strCmdText);
            Uri uri = new Uri("UnlockedBootloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
