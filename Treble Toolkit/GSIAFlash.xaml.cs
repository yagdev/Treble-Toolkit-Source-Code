using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIAFlash.xaml
    /// </summary>
    public partial class GSIAFlash : Page
    {
        public GSIAFlash()
        {
            InitializeComponent();
            FileSize_Copy.Visibility = Visibility.Hidden;
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
            String command = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd vbmeta & ren * vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                AddVbmeta.Visibility = Visibility.Hidden;
            }
            else
            {

            }
            if (File.Exists("../Place_Files_Here/boot/boot.img"))
            {
                AddBootBtn.Visibility = Visibility.Hidden;
            }
            else
            {

            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
                {
                    Title.Content = "This is not the correct file...";
                    FileSize_Copy.Visibility = Visibility.Visible;
                }
                else
                {
                    Uri uri = new Uri("GSIFlashA.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                Uri uri = new Uri("GSIAPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void AddVbmeta_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                AddVbmeta.Visibility = Visibility.Hidden;
                ThisIsAwkward.Content = "This is awkward. We thought you needed a vbmeta file, but turns out you don't. Sorry!";
                ThisIsAwkward.Visibility = Visibility.Visible;
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C cd .. & cd Place_Files_Here & cd vbmeta & start .";
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void AddBoot_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/boot/boot.img"))
            {
                AddBootBtn.Visibility = Visibility.Hidden;
                ThisIsAwkward.Content = "This is awkward. We thought you needed a boot file, but turns out you don't. Sorry!";
                ThisIsAwkward.Visibility = Visibility.Visible;
            }
            else
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                const string strCmdText = "/C cd .. & cd Place_Files_Here & cd boot & start .";
                Process.Start("CMD.exe", strCmdText);
            }
        }
    }
}
