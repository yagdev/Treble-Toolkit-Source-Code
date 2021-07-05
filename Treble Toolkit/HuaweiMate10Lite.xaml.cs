using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for HuaweiMate10Lite.xaml
    /// </summary>
    public partial class HuaweiMate10Lite : Page
    {
        public HuaweiMate10Lite()
        {
            InitializeComponent();
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibleDevices.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://www.gsmarena.com/huawei_mate_10_lite-8857.php";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void DSF_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HM10LDSF.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
