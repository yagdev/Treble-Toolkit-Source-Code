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

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for ChangeTheme.xaml
    /// </summary>
    public partial class ChangeTheme : Page
    {
        public ChangeTheme()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ren gui.exe dark.exe & ren light.exe gui.exe";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ren gui.exe dark.exe & ren pitchblack.exe gui.exe";
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
    }
}
