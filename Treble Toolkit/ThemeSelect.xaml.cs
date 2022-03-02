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
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para ThemeSelect.xam
    /// </summary>
    public partial class ThemeSelect : Page
    {
        public ThemeSelect()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI2);
            thread3.Start();
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TransparencyAndEffects.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ToggleDark);
            thread.Start();
        }
        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ToggleLight);
            thread.Start();
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ToggleDefault);
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
        private void ToggleDark()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
            string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
            if (File.Exists(Light))
            {
                File.Delete(Light);
            }
            using (StreamWriter sw = File.CreateText(Dark))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = false;
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Dark;
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void ToggleLight()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
            string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
            if (File.Exists(Dark))
            {
                File.Delete(Dark);
            }
            using (StreamWriter sw = File.CreateText(Light))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = false;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Light;
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void ToggleDefault()
        {
            string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
            string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
            if (File.Exists(Dark))
            {
                File.Delete(Dark);
            }
            if (File.Exists(Light))
            {
                File.Delete(Light);
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = false;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Default;
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Dark;
                }
                else
                {
                    SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Light;
                }
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
        private void UpdateUI2()
        {
            this.Dispatcher.Invoke(() =>
            {
                string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
                string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
                if (File.Exists(Dark))
                {
                    DeviceSpecificFeatures_Copy2.IsEnabled = false;
                    DeviceSpecificFeatures_Copy1.IsEnabled = true;
                    DeviceSpecificFeatures_Copy3.IsEnabled = true;
                }
                else
                {
                    if (File.Exists(Light))
                    {
                        DeviceSpecificFeatures_Copy2.IsEnabled = true;
                        DeviceSpecificFeatures_Copy1.IsEnabled = true;
                        DeviceSpecificFeatures_Copy3.IsEnabled = false;
                    }
                    else
                    {
                        DeviceSpecificFeatures_Copy2.IsEnabled = true;
                        DeviceSpecificFeatures_Copy1.IsEnabled = false;
                        DeviceSpecificFeatures_Copy3.IsEnabled = true;
                    }
                }
            });
        }
    }
}
