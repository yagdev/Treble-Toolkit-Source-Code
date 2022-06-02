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
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para AnniversaryThemes.xam
    /// </summary>
    public partial class AnniversaryThemes : Page
    {
        public AnniversaryThemes()
        {
            InitializeComponent();
            Thread thread = new Thread(UpdateUI);
            thread.Start();
            Thread thread2 = new Thread(Animate);
            thread2.Start();
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ThemeSelect.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Anniversary1_0(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary1_0Toggle);
            thread.Start();
        }

        private void Anniversary1_2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary1_2Toggle);
            thread.Start();
        }

        private void Anniversary1_3(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary1_3Toggle);
            thread.Start();
        }

        private void Anniversary1_5_0_3(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary1_5_0_3Toggle);
            thread.Start();
        }

        private void Anniversary2_0(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary2_0Toggle);
            thread.Start();
        }

        private void Anniversary3_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary3_1Toggle);
            thread.Start();
        }

        private void Anniversary3_2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary3_2Toggle);
            thread.Start();
        }

        private void Anniversary5_4(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary5_4Toggle);
            thread.Start();
        }

        private void Anniversary5_6(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary5_6Toggle);
            thread.Start();
        }

        private void Anniversary5_7(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary5_7Toggle);
            thread.Start();
        }

        private void Anniversary5_9(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary5_9Toggle);
            thread.Start();
        }

        private void Anniversary21_2_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary21_2_1Toggle);
            thread.Start();
        }

        private void Anniversary21_7_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary21_7_1Toggle);
            thread.Start();
        }

        private void Anniversary21_8_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary21_8_1Toggle);
            thread.Start();
        }

        private void Anniversary22_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary22_1Toggle);
            thread.Start();
        }

        private void Anniversary22_2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Anniversary22_2Toggle);
            thread.Start();
        }
        // Threading starts here (YAG-dev, 6/4/2022@21:34)
        private void Anniversary1_0Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary1_0File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = false;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton1.0"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle1.0"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton1.0"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary1.0"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary1.0"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary1.0"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary1_2Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary1_2File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = false;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton1.2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle1.2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton1.2"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary1.0"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary1.0"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary1.0"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary1_3Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary1_3File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = false;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton1.3"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle1.3"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton1.3"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary1.0"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary1.0"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary1.0"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary1_5_0_3Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary1_5_0_3File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = false;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton1.5.0.3"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle1.5.0.3"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton1.5.0.3"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary1.5.0.3"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary1.5.0.3"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary1.5.0.3"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary2_0Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary2_0File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = false;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton2.0"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle2.0"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton2.0"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary1.5.0.3"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary1.5.0.3"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary1.5.0.3"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary3_1Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary3_1File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = false;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton3.1"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle3.1"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton3.1"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary3.1"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary3.1"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary3.1"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary3_2Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary3_2File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = false;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton3.2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle3.2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton3.2"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary3.2"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary3.2"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary3.2"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary5_4Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary5_4File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = false;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton5.4"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle5.4"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton5.4"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary3.3"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary3.3"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary3.3"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary5_6Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary5_6File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = false;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton5.6"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle5.6"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton5.6"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary5_7Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary5_7File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = false;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton5.7"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle5.7"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton5.7"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary5_9Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary5_9File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = false;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton5.9"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle5.9"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton5.9"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary21_2_1Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary21_2_1File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = false;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton21.2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle21.2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton21.2"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary21_7_1Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary21_7_1File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = false;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton21.7"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle21.7"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton21.7"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary21_8_1Toggle()
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
            if (File.Exists(Anniversary22_1File))
            {
                File.Delete(Anniversary22_1File);
            }
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            using (StreamWriter sw = File.CreateText(Anniversary21_8_1File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = false;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton21.8"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["AnniversaryRectangle21.8"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["AnniversaryImageButton21.8"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary22_1Toggle()
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
            if (File.Exists(Anniversary22_2File))
            {
                File.Delete(Anniversary22_2File);
            }
            using (StreamWriter sw = File.CreateText(Anniversary22_1File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = false;
                DeviceSpecificFeatures_Copy6.IsEnabled = true;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton22.1"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleThemeAnniversary5.6"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleThemeAnniversary5.6"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockThemeAnniversary5.6"];
            });
            Thread thread = new Thread(UpdateUI);
            thread.Start();
        }
        private void Anniversary22_2Toggle()
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
            using (StreamWriter sw = File.CreateText(Anniversary22_2File))
            {
                sw.WriteLine("Treble Toolkit Settings Item");
                sw.WriteLine("©2022 YAG-dev");
            }
            this.Dispatcher.Invoke(() =>
            {
                DeviceSpecificFeatures_Copy1.IsEnabled = true;
                DeviceSpecificFeatures_Copy2.IsEnabled = true;
                DeviceSpecificFeatures_Copy3.IsEnabled = true;
                DeviceSpecificFeatures_Copy4.IsEnabled = true;
                DeviceSpecificFeatures_Copy5.IsEnabled = true;
                DeviceSpecificFeatures_Copy6.IsEnabled = false;
                DeviceSpecificFeatures_Copy7.IsEnabled = true;
                DeviceSpecificFeatures_Copy8.IsEnabled = true;
                DeviceSpecificFeatures_Copy9.IsEnabled = true;
                DeviceSpecificFeatures_Copy10.IsEnabled = true;
                DeviceSpecificFeatures_Copy11.IsEnabled = true;
                DeviceSpecificFeatures_Copy12.IsEnabled = true;
                DeviceSpecificFeatures_Copy13.IsEnabled = true;
                DeviceSpecificFeatures_Copy14.IsEnabled = true;
                DeviceSpecificFeatures_Copy15.IsEnabled = true;
                DeviceSpecificFeatures_Copy16.IsEnabled = true;
                Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["AnniversaryButton22.2"];
                Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                Application.Current.Resources["TitleTheme22.5"] = Application.Current.Resources["TitleTheme22.5Default"];
                Application.Current.Resources["SubtitleTheme22.5"] = Application.Current.Resources["SubtitleTheme22.5Default"];
                Application.Current.Resources["TextBlockTheme22.5"] = Application.Current.Resources["TextBlockTheme22.5Default"];
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
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-confetti-dark.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-confetti-light.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                }
            });
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
            this.Dispatcher.Invoke(() =>
            {
                if (File.Exists(Anniversary1_0File))
                {
                    DeviceSpecificFeatures_Copy16.IsEnabled = false;
                }
                else
                {
                    if (File.Exists(Anniversary1_2File))
                    {
                        DeviceSpecificFeatures_Copy13.IsEnabled = false;
                    }
                    else
                    {
                        if (File.Exists(Anniversary1_3File))
                        {
                            DeviceSpecificFeatures_Copy14.IsEnabled = false;
                        }
                        else
                        {
                            if (File.Exists(Anniversary1_5_0_3File))
                            {
                                DeviceSpecificFeatures_Copy15.IsEnabled = false;
                            }
                            else
                            {
                                if (File.Exists(Anniversary2_0File))
                                {
                                    DeviceSpecificFeatures_Copy10.IsEnabled = false;
                                }
                                else
                                {
                                    if (File.Exists(Anniversary3_1File))
                                    {
                                        DeviceSpecificFeatures_Copy11.IsEnabled = false;
                                    }
                                    else
                                    {
                                        if (File.Exists(Anniversary3_2File))
                                        {
                                            DeviceSpecificFeatures_Copy12.IsEnabled = false;
                                        }
                                        else
                                        {
                                            if (File.Exists(Anniversary5_4File))
                                            {
                                                DeviceSpecificFeatures_Copy7.IsEnabled = false;
                                            }
                                            else
                                            {
                                                if (File.Exists(Anniversary5_6File))
                                                {
                                                    DeviceSpecificFeatures_Copy8.IsEnabled = false;
                                                }
                                                else
                                                {
                                                    if (File.Exists(Anniversary5_7File))
                                                    {
                                                        DeviceSpecificFeatures_Copy9.IsEnabled = false;
                                                    }
                                                    else
                                                    {
                                                        if (File.Exists(Anniversary5_9File))
                                                        {
                                                            DeviceSpecificFeatures_Copy1.IsEnabled = false;
                                                        }
                                                        else
                                                        {
                                                            if (File.Exists(Anniversary21_2_1File))
                                                            {
                                                                DeviceSpecificFeatures_Copy2.IsEnabled = false;
                                                            }
                                                            else
                                                            {
                                                                if (File.Exists(Anniversary21_7_1File))
                                                                {
                                                                    DeviceSpecificFeatures_Copy3.IsEnabled = false;
                                                                }
                                                                else
                                                                {
                                                                    if (File.Exists(Anniversary21_8_1File))
                                                                    {
                                                                        DeviceSpecificFeatures_Copy4.IsEnabled = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (File.Exists(Anniversary22_1File))
                                                                        {
                                                                            DeviceSpecificFeatures_Copy5.IsEnabled = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (File.Exists(Anniversary22_2File))
                                                                            {
                                                                                DeviceSpecificFeatures_Copy6.IsEnabled = false;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
        private void Animate()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
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
    }
}
