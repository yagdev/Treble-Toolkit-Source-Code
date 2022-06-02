using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para TransparencySlider.xam
    /// </summary>
    public partial class TransparencySlider : Page
    {
        public TransparencySlider()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI2);
            thread3.Start();
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Off);
            thread.Start();
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Default);
            thread.Start();
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(On);
            thread.Start();
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TransparencyAndEffects.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void Delete1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Restart);
            thread.Start();
        }
        //Threading starts here (YAG-dev - 5/1/22@17:55
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
        private void Off()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string Transparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            string NotTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(Transparent))
            {
                File.Delete(Transparent);
            }
            using (StreamWriter sw = File.CreateText(NotTransparent))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy1.IsEnabled = false;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                BugReport_Copy.Visibility = Visibility.Visible;
                cc_Copy.Visibility = Visibility.Visible;
                FileSizeCheck_Copy.Visibility = Visibility.Visible;
                DeviceSpecificFeatures_Copy4.Visibility = Visibility.Visible;
                DeviceInfoImg_Copy.Visibility = Visibility.Visible;
            });
        }
        private void Default()
        {
            string Transparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            string NotTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(Transparent))
            {
                File.Delete(Transparent);
            }
            if (File.Exists(NotTransparent))
            {
                File.Delete(NotTransparent);
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = false;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                BugReport_Copy.Visibility = Visibility.Visible;
                cc_Copy.Visibility = Visibility.Visible;
                FileSizeCheck_Copy.Visibility = Visibility.Visible;
                DeviceSpecificFeatures_Copy4.Visibility = Visibility.Visible;
                DeviceInfoImg_Copy.Visibility = Visibility.Visible;
            });
        }
        private void On()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string Transparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            string NotTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(NotTransparent))
            {
                File.Delete(NotTransparent);
            }
            using (StreamWriter sw = File.CreateText(Transparent))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = false;
                BugReport_Copy.Visibility = Visibility.Visible;
                cc_Copy.Visibility = Visibility.Visible;
                FileSizeCheck_Copy.Visibility = Visibility.Visible;
                DeviceSpecificFeatures_Copy4.Visibility = Visibility.Visible;
                DeviceInfoImg_Copy.Visibility = Visibility.Visible;
            });
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                BugReport_Copy.Visibility = Visibility.Hidden;
                cc_Copy.Visibility = Visibility.Hidden;
                FileSizeCheck_Copy.Visibility = Visibility.Hidden;
                DeviceSpecificFeatures_Copy4.Visibility = Visibility.Hidden;
                DeviceInfoImg_Copy.Visibility = Visibility.Hidden;
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-transparency-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-transparency-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
        private void UpdateUI2()
        {
            this.Dispatcher.Invoke(() =>
            {
                string Transparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
                string NotTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
                if (File.Exists(Transparent))
                {
                    DeviceSpecificFeatures_Copy2.IsEnabled = true;
                    DeviceSpecificFeatures_Copy1.IsEnabled = true;
                    DeviceSpecificFeatures_Copy3.IsEnabled = false;
                }
                else
                {
                    if (File.Exists(NotTransparent))
                    {
                        DeviceSpecificFeatures_Copy2.IsEnabled = true;
                        DeviceSpecificFeatures_Copy1.IsEnabled = false;
                        DeviceSpecificFeatures_Copy3.IsEnabled = true;
                    }
                    else
                    {
                        DeviceSpecificFeatures_Copy2.IsEnabled = false;
                        DeviceSpecificFeatures_Copy1.IsEnabled = true;
                        DeviceSpecificFeatures_Copy3.IsEnabled = true;
                    }
                }
            });
        }
        private void Restart()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
