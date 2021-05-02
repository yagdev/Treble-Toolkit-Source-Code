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
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for SideloaderPickFile.xaml
    /// </summary>
    public partial class SideloaderPickFile : Page
    {
        public SideloaderPickFile()
        {
            InitializeComponent();
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            String command = @"/C cd .. & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren * sideload.zip";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Sideloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Continuelbl.Content = "Checking...";
            String command5 = @"/C cd .. & cd Place_Files_Here & cd Sideload & ren * sideload.zip";
            ProcessStartInfo cmdsi5 = new ProcessStartInfo("cmd.exe");
            cmdsi5.Arguments = command5;
            Process cmd5 = Process.Start(cmdsi5);
            cmd5.WaitForExit();
            if (File.Exists("../Place_Files_Here/Sideload/sideload.zip"))
            {
                String command = @"/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir Sideload & cd Sideload & ren *.zip sideload.zip & cd .. & cd .. & cd assets & adb.exe sideload ../Place_Files_Here/Sideload/sideload.zip";
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                cmdsi.Arguments = command;
                Process cmd = Process.Start(cmdsi);
                cmd.WaitForExit();
                Uri uri = new Uri("SideloadFinished.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                String command6 = @"/C cd .. & cd Place_Files_Here & cd Sideload & start .";
                ProcessStartInfo cmdsi6 = new ProcessStartInfo("cmd.exe");
                cmdsi6.Arguments = command6;
                Process cmd6 = Process.Start(cmdsi6);
                cmd6.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd Sideload & ren * sideload.zip";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
