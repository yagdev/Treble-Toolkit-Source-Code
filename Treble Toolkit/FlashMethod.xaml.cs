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
    /// Interação lógica para FlashMethod.xam
    /// </summary>
    public partial class FlashMethod : Page
    {
        public FlashMethod()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI2);
            thread3.Start();
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Fastboot);
            thread.Start();
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Fastbootd);
            thread.Start();
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibilitySettings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        //Threading starts here (YAG-dev - 10/1/2022@00:09
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
        private void UpdateUI2()
        {
            this.Dispatcher.Invoke(() =>
            {
                string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Fastbootd.txt");
                if (File.Exists(IsAnimated))
                {
                    DeviceSpecificFeatures_Copy3.IsEnabled = false;
                    DeviceSpecificFeatures_Copy2.IsEnabled = true;
                }
                else
                {
                    DeviceSpecificFeatures_Copy3.IsEnabled = true;
                    DeviceSpecificFeatures_Copy2.IsEnabled = false;
                }
            });
        }
        private void Fastboot()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Fastbootd.txt");
            if (File.Exists(IsAnimated))
            {
                File.Delete(IsAnimated);
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = false;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
            });
        }
        private void Fastbootd()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Fastbootd.txt");
            using (StreamWriter sw = File.CreateText(IsAnimated))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2021-2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = false;
            });
        }
    }
}
