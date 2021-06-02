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
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for DeviceTester.xaml
    /// </summary>
    public partial class DeviceTester : Page
    {
        public DeviceTester()
        {
            InitializeComponent();
            NotDetected.Visibility = Visibility.Hidden;
            grid.Opacity = 0;
            Grid r = (Grid)grid;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            r.BeginAnimation(Grid.OpacityProperty, animation);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.system.brand";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Brand.Content = output;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.model";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output2 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Model.Content = output2;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.treble.enabled";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SupportsTreble.Content = output3;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.release";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output4 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            AndroidVersion.Content = output4;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output5 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SDKVersion.Content = output5;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.build.version.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output6 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SecurityPatch.Content = output6;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.build.date";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output7 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            BuildDate.Content = output7;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.crypto.state";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output8 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            IsEncrypted.Content = output8;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.serialno";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output9 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SN.Content = output9;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output10 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            VendorSDK.Content = output10;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output11 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            VendorPatch.Content = output11;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.board";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output12 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            BoardName.Content = output12;
            if (output3.Contains("true") == true)
            {
                SupportsTreble.Content = "Yes";
            }
            else
            {
                SupportsTreble.Content = "No";
            }
            if (output8.Contains("encrypted") == true)
            {
                IsEncrypted.Content = "Yes";
            }
            else
            {
                IsEncrypted.Content = "No";
            }
            if (output.Length == 0)
            {
                Brand.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output2.Length == 0)
            {
                Model.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output3.Length == 0)
            {
                SupportsTreble.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output4.Length == 0)
            {
                AndroidVersion.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output5.Length == 0)
            {
                SDKVersion.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output6.Length == 0)
            {
                SecurityPatch.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output7.Length == 0)
            {
                BuildDate.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output8.Length == 0)
            {
                IsEncrypted.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output9.Length == 0)
            {
                SN.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output10.Length == 0)
            {
                VendorSDK.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output11.Length == 0)
            {
                VendorPatch.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output12.Length == 0)
            {
                BoardName.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            NotDetected.Visibility = Visibility.Hidden;
            Warning.Visibility = Visibility.Visible;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.system.brand";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Brand.Content = output;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.model";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output2 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Model.Content = output2;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.treble.enabled";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.release";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output4 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            AndroidVersion.Content = output4;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output5 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SDKVersion.Content = output5;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.build.version.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output6 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SecurityPatch.Content = output6;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.build.date";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output7 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            BuildDate.Content = output7;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.crypto.state";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output8 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            IsEncrypted.Content = output8;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.serialno";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output9 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            SN.Content = output9;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output10 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            VendorSDK.Content = output10;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output11 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            VendorPatch.Content = output11;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.board";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output12 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            BoardName.Content = output12;
            if (output3.Contains("true") == true)
            {
                SupportsTreble.Content = "Yes";
            }
            else
            {
                SupportsTreble.Content = "No";
            }
            if (output8.Contains("encrypted") == true)
            {
                IsEncrypted.Content = "Yes";
            }
            else
            {
                IsEncrypted.Content = "No";
            }
            if (output.Length == 0)
            {
                Brand.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output2.Length == 0)
            {
                Model.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output3.Length == 0)
            {
                SupportsTreble.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output4.Length == 0)
            {
                AndroidVersion.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output5.Length == 0)
            {
                SDKVersion.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output6.Length == 0)
            {
                SecurityPatch.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output7.Length == 0)
            {
                BuildDate.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output8.Length == 0)
            {
                IsEncrypted.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output9.Length == 0)
            {
                SN.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output10.Length == 0)
            {
                VendorSDK.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output11.Length == 0)
            {
                VendorPatch.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
            if (output12.Length == 0)
            {
                BoardName.Content = "Unable to retrieve";
                NotDetected.Visibility = Visibility.Visible;
            }
            else
            {
                Warning.Visibility = Visibility.Hidden;
            }
        }

        private void grid_Initialized(object sender, EventArgs e)
        {
            
        }

        private void SupportsTreble_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
