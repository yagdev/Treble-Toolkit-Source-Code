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
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for DebugInfo.xaml
    /// </summary>
    public partial class DebugInfo : Page
    {
        public DebugInfo()
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
            string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
            if (File.Exists(VisibleCMD))
            {
                DeviceSpecificFeatures_Copy.Content = "Hide CMD Window While Flashing";
            }
            else
            {
                DeviceSpecificFeatures_Copy.Content = "Show CMD Window While Flashing";
            }
        }

        private void BugReports_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
            if (File.Exists(VisibleCMD))
            {
                File.Delete(VisibleCMD);
                DeviceSpecificFeatures_Copy.Content = "Show CMD Window While Flashing";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(VisibleCMD))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                DeviceSpecificFeatures_Copy.Content = "Hide CMD Window While Flashing";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
