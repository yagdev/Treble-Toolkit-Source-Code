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
using System.Threading;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TWRPBootPickFile.xaml
    /// </summary>
    public partial class TWRPBootPickFile : Page
    {
        public TWRPBootPickFile()
        {
            InitializeComponent();
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPBoot.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ContinueLbl.Content = "Checking...";
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/TWRP/twrp.img"))
            {
                NotFound.Visibility = Visibility.Hidden;
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\TWRP.img");
                if (fInfo.Length > 100000000)
                {
                    Title.Content = "Holy crap, that's a big file!";
                    FileSize.Visibility = Visibility.Visible;
                }
                else
                {
                    String command2 = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe boot ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & taskkill /f /im adb.exe";
                    ProcessStartInfo cmdsi2 = new ProcessStartInfo("cmd.exe");
                    cmdsi2.Arguments = command2;
                    Process cmd2 = Process.Start(cmdsi2);
                    cmd2.WaitForExit();
                    Uri uri = new Uri("TWRPBootFinished.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                NotFound.Visibility = Visibility.Visible;
                String command3 = @"/C cd .. & cd Place_Files_Here & cd TWRP & start .";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren * twrp.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
