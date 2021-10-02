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
using System.Management;
using System.Windows.Media.Animation;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for WindowsOutdatedMoreInfo.xaml
    /// </summary>
    public partial class WindowsOutdatedMoreInfo : Page
    {
        public WindowsOutdatedMoreInfo()
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
            string r2 = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection information = searcher.Get();
                if (information != null)
                {
                    foreach (ManagementObject obj in information)
                    {
                        r2 = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                    }
                }
                r2 = r2.Replace("NT 5.1.2600", "XP");
                r2 = r2.Replace("NT 5.2.3790", "Server 2003");
                PhoneStatus.Content = r2;
            }
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://www.microsoft.com/software-download/windows10";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
