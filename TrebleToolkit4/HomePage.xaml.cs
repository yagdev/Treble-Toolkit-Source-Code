using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FlashGSI.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRP.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBL.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PMFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibleDevices.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            const string strCmdText = "/C cd .. & cd assets & start FreeCMD.exe";
            Process.Start("CMD.exe", strCmdText);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://github.com/yag-dev-xda/Treble-Toolkit-4.0-Source-Code/releases";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ren gui.exe gui3.exe & ren gui2.exe gui.exe & ren gui3.exe gui2.exe";
            process.StartInfo = startInfo;
            process.Start();
            Application.Current.Shutdown();
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://forum.xda-developers.com/project-treble/trebleenabled-device-development/treble-gsi-flashing-tool-b-t4040435";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var win2 = new About();
            win2.Show();
        }
    }
}
