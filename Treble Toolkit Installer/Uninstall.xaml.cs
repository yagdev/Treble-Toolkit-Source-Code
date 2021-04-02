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

namespace Treble_Toolkit_Installer
{
    /// <summary>
    /// Interaction logic for Uninstall.xaml
    /// </summary>
    public partial class Uninstall : Page
    {
        public Uninstall()
        {
            InitializeComponent();
            status_lbl.Content = "Removing directories...";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C RD /s /q Treble_Toolkit & cd %AppData% & RD /s /q Treble_Toolkit & cd %ProgramFiles% & RD /s /q Treble_Toolkit";
            process.StartInfo = startInfo;
            process.Start();
            status_lbl.Content = "Removing shortcuts...";
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd %AppData% & cd Microsoft & cd Windows & cd Start Menu & del /f /q \u0022Treble Toolkit.lnk\u0022 & cd %UserProfile% & cd Desktop & del /f /q \u0022Treble Toolkit.lnk\u0022";
            process.StartInfo = startInfo;
            process.Start();
            status_lbl.Content = "Uninstall successful.";
            status_pgr.Value = +100;
            status_pgr.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Start.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
