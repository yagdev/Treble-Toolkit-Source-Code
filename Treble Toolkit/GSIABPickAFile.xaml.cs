using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;
using NHotkey;
using NHotkey.Wpf;
using System.Windows.Input;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIABPickAFile.xaml
    /// </summary>
    public partial class GSIABPickAFile : Page
    {
        public GSIABPickAFile()
        {
            InitializeComponent();
            HotkeyManager.Current.AddOrReplace("Increment", Key.D, ModifierKeys.Control, OnIncrement);
            Debug1.Visibility = Visibility.Hidden;
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(PrepareFiles);
            thread2.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Next);
            thread.Start();
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIFlashAB.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void OnIncrement(object sender, HotkeyEventArgs e)
        {
            Debug1.Visibility = Visibility.Visible;
        }
        //Threading starts here -- 5/11/2021@22:07, YAG-dev, 21.12+
        private void Animate()
        {
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    GridMain.Opacity = 0;
                    Grid r = (Grid)GridMain;
                    DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    r.BeginAnimation(Grid.OpacityProperty, animation);
                });
            }
        }
        private void PrepareFiles()
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & start .";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
        private void Next()
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Title.Content = "This is not the correct file...";
                        FileSize.Visibility = Visibility.Visible;
                    });
                }
                else
                {
                    Uri uri = new Uri("GSIFlashAB.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    NotFound.Visibility = Visibility.Visible;
                });
                String command3 = @"/C cd .. & cd Place_Files_Here & cd GSI & start .";
                ProcessStartInfo cmdsi3 = new ProcessStartInfo("cmd.exe");
                cmdsi3.Arguments = command3;
                Process cmd3 = Process.Start(cmdsi3);
                cmd3.WaitForExit();
                String command4 = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
                ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
                cmdsi4.Arguments = command4;
                Process cmd4 = Process.Start(cmdsi4);
                cmd4.WaitForExit();
            }
        }
    }
}
