using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Animation;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            string IsTransparent2 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
            if (File.Exists(IsAnimated))
            {
                AnimationsToggle.Content = "Enable Animations";
            }
            else
            {
                AnimationsToggle.Content = "Disable Animations";
                GridMain.Opacity = 0;
                Grid r = (Grid)GridMain;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                r.BeginAnimation(Grid.OpacityProperty, animation);
            }
            if (File.Exists(IsTransparent2))
            {
                TranparentTheme.Content = "Disable Transparent Theme";
            }
            else
            {
                TranparentTheme.Content = "Enable Transparent Theme";
            }
            if (File.Exists(IsTransparent))
            {
                TranparencyToggle.Content = "Enable Transparency";
            }
            else
            {
                TranparencyToggle.Content = "Disable Transparency";
            }
            if (File.Exists(VisibleCMD))
            {
                CMDVis.Content = "Disable CMD Prompt Visibility";
            }
            else
            {
                CMDVis.Content = "Enable CMD Prompt Visibility";
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            if (File.Exists(IsAnimated))
            {
                File.Delete(IsAnimated);
                AnimationsToggle.Content = "Disable Animations";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(IsAnimated))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                AnimationsToggle.Content = "Enable Animations";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ToggleTransparency_Click(object sender, RoutedEventArgs e)
        {
            string IsTransparent2 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            if (File.Exists(IsTransparent2))
            {
                File.Delete(IsTransparent2);
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(IsTransparent))
            {
                File.Delete(IsTransparent);
                TranparencyToggle.Content = "Disable Transparency";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(IsTransparent))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                TranparencyToggle.Content = "Enable Transparency";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void TransparentTheme_Click(object sender, RoutedEventArgs e)
        {
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(IsTransparent))
            {
                File.Delete(IsTransparent);
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IsTransparent2 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            if (File.Exists(IsTransparent2))
            {
                File.Delete(IsTransparent2);
                TranparentTheme.Content = "Enable Transparent Theme";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(IsTransparent2))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                TranparentTheme.Content = "Disable Transparent Theme";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void CMDvis(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
            if (File.Exists(VisibleCMD))
            {
                File.Delete(VisibleCMD);
                CMDVis.Content = "Enable CMD Prompt Visibility";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(VisibleCMD))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                CMDVis.Content = "Disable CMD Prompt Visibility";
            }
        }
    }
}
