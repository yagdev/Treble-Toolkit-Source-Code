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

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TransparencyAndEffects.xaml
    /// </summary>
    public partial class TransparencyAndEffects : Page
    {
        public TransparencyAndEffects()
        {
            InitializeComponent();
            string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            string IsTransparent2 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            if (File.Exists(IsTransparent2))
            {
                DeviceSpecificFeatures_Copy.Content = "Disable Transparent Theme";
            }
            else
            {
                DeviceSpecificFeatures_Copy.Content = "Enable Transparent Theme";
            }
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
            if (File.Exists(IsTransparent))
            {
                TransparencyToggle.Content = "Enable Transparency";
            }
            else
            {
                TransparencyToggle.Content = "Disable Transparency";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ToggleTransparency(object sender, RoutedEventArgs e)
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
                TransparencyToggle.Content = "Disable Transparency";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(IsTransparent))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                TransparencyToggle.Content = "Enable Transparency";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void BugReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnableTransparentTheme(object sender, RoutedEventArgs e)
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
                DeviceSpecificFeatures_Copy.Content = "Enable Transparent Theme";
            }
            else
            {
                using (StreamWriter sw = File.CreateText(IsTransparent2))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2021 YAG-dev");
                }
                DeviceSpecificFeatures_Copy.Content = "Disable Transparent Theme";
            }
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C wmic process where name='adb.exe' delete & wmic process where name='gui.exe' delete & start gui.exe";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void AnimationToggle(object sender, RoutedEventArgs e)
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
    }
}
