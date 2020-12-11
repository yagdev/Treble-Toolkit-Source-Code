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
using System.Windows.Shapes;

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/C cd .. & cd .. & TrebleToolkitUpdaterLauncher.exe";
            process2.StartInfo = startInfo2;
            process2.Start();
            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/C taskkill /im gui.exe & taskkill /im gui.exe";
            process2.StartInfo = startInfo2;
            process2.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start updater.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
