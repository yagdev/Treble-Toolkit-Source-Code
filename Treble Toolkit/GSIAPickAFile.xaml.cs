using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Input;
using NHotkey.Wpf;
using NHotkey;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIAPickAFile.xaml
    /// </summary>
    public partial class GSIAPickAFile : Page
    {
        public GSIAPickAFile()
        {
            InitializeComponent();
            HotkeyManager.Current.AddOrReplace("Increment", Key.D, ModifierKeys.Control, OnIncrement);
            Debug1.Visibility = Visibility.Hidden;
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(PrepareFiles);
            thread2.Start();
        }

        private void OnIncrement(object sender, HotkeyEventArgs e)
        {
            Debug1.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIAFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                Thread thread = new Thread(Next1);
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(Next2);
                thread.Start();
            }
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIFlashA.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
        private void Next1()
        {
            String command5 = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
            ProcessStartInfo cmdsi5 = new ProcessStartInfo("cmd.exe");
            cmdsi5.Arguments = command5;
            Process cmd5 = Process.Start(cmdsi5);
            cmd5.WaitForExit();
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
                this.Dispatcher.Invoke(() =>
                {
                    Uri uri = new Uri("GSIFlashA.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                });
            }
        }
        private void Next2()
        {
            String command6 = @"/C cd .. & cd Place_Files_Here & cd GSI & start .";
            ProcessStartInfo cmdsi6 = new ProcessStartInfo("cmd.exe");
            cmdsi6.Arguments = command6;
            Process cmd6 = Process.Start(cmdsi6);
            cmd6.WaitForExit();
            String command4 = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img";
            ProcessStartInfo cmdsi4 = new ProcessStartInfo("cmd.exe");
            cmdsi4.Arguments = command4;
            Process cmd4 = Process.Start(cmdsi4);
            cmd4.WaitForExit();
        }
    }
}
