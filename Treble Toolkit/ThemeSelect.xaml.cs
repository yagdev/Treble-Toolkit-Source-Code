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
        private void Slate(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(SlateEnable);
            thread.Start();
        }

        private void Slipside(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(SlipsideEnable);
            thread.Start();
        }

        private void Intensity(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(IntensityEnable);
            thread.Start();
        }

        private void Joy(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(JoyEnable);
            thread.Start();
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
        private void Anniversary_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AnniversaryThemes.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
        private void SlateEnable()
        {
            string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
            string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
            string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
            string Anniversary1_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.0.txt");
            string Anniversary1_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.2.txt");
            string Anniversary1_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.3.txt");
            string Anniversary1_5_0_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.5.0.3.txt");
            string Anniversary2_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary2.0.txt");
            string Anniversary3_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.1.txt");
            string Anniversary3_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.2.txt");
            string Anniversary5_4File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.4.txt");
            string Anniversary5_6File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.6.txt");
            string Anniversary5_7File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.7.txt");
            string Anniversary5_9File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.9.txt");
            string Anniversary21_2_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.2.1.txt");
            string Anniversary21_7_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.7.1.txt");
            string Anniversary21_8_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.8.1.txt");
            string Anniversary22_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.1.txt");
            string Anniversary22_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.2.txt");
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            if (File.Exists(Anniversary1_0File))
            {
                File.Delete(Anniversary1_0File);
            }
            if (File.Exists(Anniversary1_2File))
            {
                File.Delete(Anniversary1_2File);
            }
            if (File.Exists(Anniversary1_3File))
            {
                File.Delete(Anniversary1_3File);
            }
            if (File.Exists(Anniversary1_5_0_3File))
            {
                File.Delete(Anniversary1_5_0_3File);
            }
            if (File.Exists(Anniversary2_0File))
            {
                File.Delete(Anniversary2_0File);
            }
            if (File.Exists(Anniversary3_1File))
            {
                File.Delete(Anniversary3_1File);
            }
            if (File.Exists(Anniversary3_2File))
            {
                File.Delete(Anniversary3_2File);
            }
            if (File.Exists(Anniversary5_4File))
            {
                File.Delete(Anniversary5_4File);
            }
            if (File.Exists(Anniversary5_6File))
            {
                File.Delete(Anniversary5_6File);
            }
            if (File.Exists(Anniversary5_7File))
            {
                File.Delete(Anniversary5_7File);
            }
            if (File.Exists(Anniversary5_9File))
            {
                File.Delete(Anniversary5_9File);
            }
            if (File.Exists(Anniversary21_2_1File))
            {
                File.Delete(Anniversary21_2_1File);
            }
            if (File.Exists(Anniversary21_7_1File))
            {
                File.Delete(Anniversary21_7_1File);
            }
            if (File.Exists(Anniversary21_8_1File))
            {
                File.Delete(Anniversary21_8_1File);
            }
            if (File.Exists(Anniversary22_1File))
            {
                File.Delete(Anniversary22_1File);
            }
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            if (File.Exists(IntensityFile))
            {
                File.Delete(IntensityFile);
            }
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy8.Content = "Anniversary Themes";
                DeviceSpecificFeatures_Copy4.IsEnabled = false;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4StyleDefault"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleTheme22.5Default"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleTheme22.5Default"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockTheme22.5Default"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void IntensityEnable()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
            string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
            string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
            string Anniversary1_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.0.txt");
            string Anniversary1_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.2.txt");
            string Anniversary1_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.3.txt");
            string Anniversary1_5_0_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.5.0.3.txt");
            string Anniversary2_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary2.0.txt");
            string Anniversary3_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.1.txt");
            string Anniversary3_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.2.txt");
            string Anniversary5_4File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.4.txt");
            string Anniversary5_6File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.6.txt");
            string Anniversary5_7File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.7.txt");
            string Anniversary5_9File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.9.txt");
            string Anniversary21_2_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.2.1.txt");
            string Anniversary21_7_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.7.1.txt");
            string Anniversary21_8_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.8.1.txt");
            string Anniversary22_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.1.txt");
            string Anniversary22_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.2.txt");
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            if (File.Exists(Anniversary1_0File))
            {
                File.Delete(Anniversary1_0File);
            }
            if (File.Exists(Anniversary1_2File))
            {
                File.Delete(Anniversary1_2File);
            }
            if (File.Exists(Anniversary1_3File))
            {
                File.Delete(Anniversary1_3File);
            }
            if (File.Exists(Anniversary1_5_0_3File))
            {
                File.Delete(Anniversary1_5_0_3File);
            }
            if (File.Exists(Anniversary2_0File))
            {
                File.Delete(Anniversary2_0File);
            }
            if (File.Exists(Anniversary3_1File))
            {
                File.Delete(Anniversary3_1File);
            }
            if (File.Exists(Anniversary3_2File))
            {
                File.Delete(Anniversary3_2File);
            }
            if (File.Exists(Anniversary5_4File))
            {
                File.Delete(Anniversary5_4File);
            }
            if (File.Exists(Anniversary5_6File))
            {
                File.Delete(Anniversary5_6File);
            }
            if (File.Exists(Anniversary5_7File))
            {
                File.Delete(Anniversary5_7File);
            }
            if (File.Exists(Anniversary5_9File))
            {
                File.Delete(Anniversary5_9File);
            }
            if (File.Exists(Anniversary21_2_1File))
            {
                File.Delete(Anniversary21_2_1File);
            }
            if (File.Exists(Anniversary21_7_1File))
            {
                File.Delete(Anniversary21_7_1File);
            }
            if (File.Exists(Anniversary21_8_1File))
            {
                File.Delete(Anniversary21_8_1File);
            }
            if (File.Exists(Anniversary22_1File))
            {
                File.Delete(Anniversary22_1File);
            }
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            using (StreamWriter sw = File.CreateText(IntensityFile))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy8.Content = "Anniversary Themes";
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = false;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt1"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt2"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleTheme22.5Default"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleTheme22.5Default"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockTheme22.5Default"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void JoyEnable()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
            string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
            string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
            string Anniversary1_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.0.txt");
            string Anniversary1_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.2.txt");
            string Anniversary1_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.3.txt");
            string Anniversary1_5_0_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.5.0.3.txt");
            string Anniversary2_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary2.0.txt");
            string Anniversary3_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.1.txt");
            string Anniversary3_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.2.txt");
            string Anniversary5_4File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.4.txt");
            string Anniversary5_6File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.6.txt");
            string Anniversary5_7File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.7.txt");
            string Anniversary5_9File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.9.txt");
            string Anniversary21_2_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.2.1.txt");
            string Anniversary21_7_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.7.1.txt");
            string Anniversary21_8_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.8.1.txt");
            string Anniversary22_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.1.txt");
            string Anniversary22_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.2.txt");
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            if (File.Exists(Anniversary1_0File))
            {
                File.Delete(Anniversary1_0File);
            }
            if (File.Exists(Anniversary1_2File))
            {
                File.Delete(Anniversary1_2File);
            }
            if (File.Exists(Anniversary1_3File))
            {
                File.Delete(Anniversary1_3File);
            }
            if (File.Exists(Anniversary1_5_0_3File))
            {
                File.Delete(Anniversary1_5_0_3File);
            }
            if (File.Exists(Anniversary2_0File))
            {
                File.Delete(Anniversary2_0File);
            }
            if (File.Exists(Anniversary3_1File))
            {
                File.Delete(Anniversary3_1File);
            }
            if (File.Exists(Anniversary3_2File))
            {
                File.Delete(Anniversary3_2File);
            }
            if (File.Exists(Anniversary5_4File))
            {
                File.Delete(Anniversary5_4File);
            }
            if (File.Exists(Anniversary5_6File))
            {
                File.Delete(Anniversary5_6File);
            }
            if (File.Exists(Anniversary5_7File))
            {
                File.Delete(Anniversary5_7File);
            }
            if (File.Exists(Anniversary5_9File))
            {
                File.Delete(Anniversary5_9File);
            }
            if (File.Exists(Anniversary21_2_1File))
            {
                File.Delete(Anniversary21_2_1File);
            }
            if (File.Exists(Anniversary21_7_1File))
            {
                File.Delete(Anniversary21_7_1File);
            }
            if (File.Exists(Anniversary21_8_1File))
            {
                File.Delete(Anniversary21_8_1File);
            }
            if (File.Exists(Anniversary22_1File))
            {
                File.Delete(Anniversary22_1File);
            }
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(IntensityFile))
            {
                File.Delete(IntensityFile);
            }
            using (StreamWriter sw = File.CreateText(JoyFile))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy8.Content = "Anniversary Themes";
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = false;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt3"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style3"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt3"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleTheme22.5Default"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleTheme22.5Default"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockTheme22.5Default"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void SlipsideEnable()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
            string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
            string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
            string Anniversary1_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.0.txt");
            string Anniversary1_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.2.txt");
            string Anniversary1_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.3.txt");
            string Anniversary1_5_0_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.5.0.3.txt");
            string Anniversary2_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary2.0.txt");
            string Anniversary3_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.1.txt");
            string Anniversary3_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.2.txt");
            string Anniversary5_4File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.4.txt");
            string Anniversary5_6File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.6.txt");
            string Anniversary5_7File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.7.txt");
            string Anniversary5_9File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.9.txt");
            string Anniversary21_2_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.2.1.txt");
            string Anniversary21_7_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.7.1.txt");
            string Anniversary21_8_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.8.1.txt");
            string Anniversary22_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.1.txt");
            string Anniversary22_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.2.txt");
            if (File.Exists(SlipsideFile))
            {
                File.Delete(SlipsideFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            if (File.Exists(Anniversary1_0File))
            {
                File.Delete(Anniversary1_0File);
            }
            if (File.Exists(Anniversary1_2File))
            {
                File.Delete(Anniversary1_2File);
            }
            if (File.Exists(Anniversary1_3File))
            {
                File.Delete(Anniversary1_3File);
            }
            if (File.Exists(Anniversary1_5_0_3File))
            {
                File.Delete(Anniversary1_5_0_3File);
            }
            if (File.Exists(Anniversary2_0File))
            {
                File.Delete(Anniversary2_0File);
            }
            if (File.Exists(Anniversary3_1File))
            {
                File.Delete(Anniversary3_1File);
            }
            if (File.Exists(Anniversary3_2File))
            {
                File.Delete(Anniversary3_2File);
            }
            if (File.Exists(Anniversary5_4File))
            {
                File.Delete(Anniversary5_4File);
            }
            if (File.Exists(Anniversary5_6File))
            {
                File.Delete(Anniversary5_6File);
            }
            if (File.Exists(Anniversary5_7File))
            {
                File.Delete(Anniversary5_7File);
            }
            if (File.Exists(Anniversary5_9File))
            {
                File.Delete(Anniversary5_9File);
            }
            if (File.Exists(Anniversary21_2_1File))
            {
                File.Delete(Anniversary21_2_1File);
            }
            if (File.Exists(Anniversary21_7_1File))
            {
                File.Delete(Anniversary21_7_1File);
            }
            if (File.Exists(Anniversary21_8_1File))
            {
                File.Delete(Anniversary21_8_1File);
            }
            if (File.Exists(Anniversary22_1File))
            {
                File.Delete(Anniversary22_1File);
            }
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            if (File.Exists(IntensityFile))
            {
                File.Delete(IntensityFile);
            }
            if (File.Exists(JoyFile))
            {
                File.Delete(JoyFile);
            }
            using (StreamWriter sw = File.CreateText(SlipsideFile))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy8.Content = "Anniversary Themes";
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = false;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleTheme22.5Default"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleTheme22.5Default"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockTheme22.5Default"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-dark.png"));
                    DeviceSpecificFeatures_Copy8.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-confetti-dark.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-theme-light.png"));
                    DeviceSpecificFeatures_Copy8.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-confetti-light.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
        }
        private void UpdateUI2()
        {
            this.Dispatcher.Invoke(() =>
            {
                string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
                string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
                string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
                string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
                string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
                if (File.Exists(Dark))
                {
                    DeviceSpecificFeatures_Copy2.IsEnabled = false;
                }
                else
                {
                    if (File.Exists(Light))
                    {
                        DeviceSpecificFeatures_Copy3.IsEnabled = false;
                    }
                    else
                    {
                        DeviceSpecificFeatures_Copy1.IsEnabled = false;
                    }
                }
                if (File.Exists(IntensityFile))
                {
                    DeviceSpecificFeatures_Copy6.IsEnabled = false;
                }
                else
                {
                    if (File.Exists(SlipsideFile))
                    {
                        DeviceSpecificFeatures_Copy5.IsEnabled = false;
                    }
                    else
                    {
                        if (File.Exists(JoyFile))
                        {
                            DeviceSpecificFeatures_Copy7.IsEnabled = false;
                        }
                        else
                        {
                            string Anniversary1_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.0.txt");
                            string Anniversary1_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.2.txt");
                            string Anniversary1_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.3.txt");
                            string Anniversary1_5_0_3File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary1.5.0.3.txt");
                            string Anniversary2_0File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary2.0.txt");
                            string Anniversary3_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.1.txt");
                            string Anniversary3_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary3.2.txt");
                            string Anniversary5_4File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.4.txt");
                            string Anniversary5_6File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.6.txt");
                            string Anniversary5_7File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.7.txt");
                            string Anniversary5_9File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary5.9.txt");
                            string Anniversary21_2_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.2.1.txt");
                            string Anniversary21_7_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.7.1.txt");
                            string Anniversary21_8_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary21.8.1.txt");
                            string Anniversary22_1File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.1.txt");
                            string Anniversary22_2File = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Anniversary22.2.txt");
                            if (File.Exists(Anniversary1_0File) || File.Exists(Anniversary1_2File) || File.Exists(Anniversary1_5_0_3File) || File.Exists(Anniversary2_0File) || File.Exists(Anniversary3_1File) || File.Exists(Anniversary3_2File) || File.Exists(Anniversary5_4File) || File.Exists(Anniversary5_6File) || File.Exists(Anniversary5_7File) || File.Exists(Anniversary5_9File) || File.Exists(Anniversary21_2_1File) || File.Exists(Anniversary21_7_1File) || File.Exists(Anniversary21_8_1File) || File.Exists(Anniversary22_1File) || File.Exists(Anniversary22_2File))
                            {
                                DeviceSpecificFeatures_Copy8.Content = DeviceSpecificFeatures_Copy8.Content + "(Active)";
                            }
                            else
                            {
                                DeviceSpecificFeatures_Copy4.IsEnabled = false;
                            }
                        }
                    }
                }
            });
        }
    }
}
