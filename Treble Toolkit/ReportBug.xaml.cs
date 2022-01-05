using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para ReportBug.xam
    /// </summary>
    public partial class ReportBug : Page
    {
        public ReportBug()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBugStep2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
            Thread thread = new Thread(CreateBugReport);
            thread.Start();
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
        private void SupportLock()
        {
            if (Environment.OSVersion.Version.Build <= 9)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy4.IsEnabled = false;
                    DeviceSpecificFeatures_Copy4.Content = "🔒 Report Bug";
                });
            }
        }
        private void CreateBugReport()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir BugReports";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string Report = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "BugReports", "Report.txt");
            File.Delete(Report);
            using (StreamWriter sw = File.CreateText(Report))
            {
                sw.WriteLine("©2021 YAG-dev");
                sw.WriteLine("Bug Report Description");
                sw.WriteLine(BugReport);
                this.Dispatcher.Invoke(() =>
                {
                    if (PhoneInfo.IsChecked == true)
                    {
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.FileName = "CMD.exe";
                        startInfo.Arguments = "/C adb shell getprop & wmic process where name='adb.exe' delete & mkdir BugReports & cd BugReports & mkdir SystemInfo";
                        startInfo.CreateNoWindow = true;
                        process.StartInfo = startInfo;
                        process.Start();
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        sw.WriteLine("Phone Info");
                        sw.WriteLine("©2021 YAG-dev");
                        sw.WriteLine(output);
                    }
                    if (PCInfo.IsChecked == true)
                    {
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.FileName = "CMD.exe";
                        startInfo.Arguments = "/C systeminfo";
                        startInfo.CreateNoWindow = true;
                        process.StartInfo = startInfo;
                        process.Start();
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();
                        sw.WriteLine("PC Info");
                        sw.WriteLine("©2021 YAG-dev");
                        sw.WriteLine(output);
                    }
                });
            }
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-light.png"));
                }
            });
        }
    }
}
