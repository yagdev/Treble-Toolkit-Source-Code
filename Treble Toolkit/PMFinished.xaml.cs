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
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for PMFinished.xaml
    /// </summary>
    public partial class PMFinished : Page
    {
        public PMFinished()
        {
            InitializeComponent();
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PMFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            String command = @"/C wmic process where name='adb.exe' delete";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            Application.Current.Shutdown();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
