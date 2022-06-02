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
using System.Windows.Media;

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
            DbgRct1.Visibility = Visibility.Hidden;
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(PrepareFiles);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
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
            DbgRct1.Visibility = Visibility.Visible;
        }
        private void AddVbmeta_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIFlashAB.xaml", UriKind.Relative);
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
                        FileSizeCheck_Copy.Visibility = Visibility.Visible;
                        cc_Copy.Visibility = Visibility.Visible;
                        AddVbmeta.Visibility = Visibility.Visible;
                        BugReport_Copy.Visibility = Visibility.Visible;
                        DeviceInfoImg_Copy.Visibility = Visibility.Visible;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Uri uri = new Uri("GSIFlashAB.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    });
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-dark.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    Debug1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-fnf-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-light.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    Debug1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                    DeviceSpecificFeatures_Copy4.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                }
                if (File.Exists("../Place_Files_Here/GSI/system.img"))
                {
                    FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                    if (fInfo.Length < 500000000)
                    {
                        FileSizeCheck_Copy.Visibility = Visibility.Visible;
                        cc_Copy.Visibility = Visibility.Visible;
                        AddVbmeta.Visibility = Visibility.Visible;
                        BugReport_Copy.Visibility = Visibility.Visible;
                        DeviceInfoImg_Copy.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        FileSizeCheck_Copy.Visibility = Visibility.Hidden;
                        cc_Copy.Visibility = Visibility.Hidden;
                        AddVbmeta.Visibility = Visibility.Hidden;
                        BugReport_Copy.Visibility = Visibility.Hidden;
                        DeviceInfoImg_Copy.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    FileSizeCheck_Copy.Visibility = Visibility.Hidden;
                    cc_Copy.Visibility = Visibility.Hidden;
                    AddVbmeta.Visibility = Visibility.Hidden;
                    BugReport_Copy.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy.Visibility = Visibility.Hidden;
                }
            });
        }
    }
}
