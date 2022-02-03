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
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for BTULHW.xaml
    /// </summary>
    public partial class BTULHW : Page
    {
        public BTULHW()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBootloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(StartOps);
            thread.Start();
            Uri uri = new Uri("UnlockedBootloader.xaml", UriKind.Relative);
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-usb-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-usb-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bug-light.png"));
                }
            });

            if (Environment.OSVersion.Version.Build <= 9)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Report Bug";
                });
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe get-state";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            this.Dispatcher.Invoke(() =>
                {
                    if (output3.Contains("device") == true)
                {
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.FileName = "CMD.exe";
                    startInfo.Arguments = "/C fastboot.exe devices";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    string output4 = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    if (output4.Contains("fastboot") == true)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            if (GridMain.ActualWidth <= 530)
                            {
                                DropShadowEffect myDropShadowEffect = new DropShadowEffect();
                                // Set the color of the shadow to Black.
                                Color myShadowColor = new Color();
                                myShadowColor.A = 255; // Note that the alpha value is ignored by Color property. 
                                // The Opacity property is used to control the alpha.
                                myShadowColor.B = 0;
                                myShadowColor.G = 255;
                                myShadowColor.R = 255;
                                myDropShadowEffect.Direction = 0;
                                myDropShadowEffect.ShadowDepth = 0;
                                myDropShadowEffect.Color = myShadowColor;
                                DeviceRectangle.Effect = myDropShadowEffect;
                                cc.Content = "Device Connected (ADB/Fastboot)";
                            }
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            cc.Content = "Device Connected (ADB)";
                        });
                    }
                }
                else
                {
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.FileName = "CMD.exe";
                    startInfo.Arguments = "/C fastboot.exe devices";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    string output4 = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    if (output4.Contains("fastboot") == true)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            if (GridMain.ActualWidth <= 530)
                            {
                                DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                cc.Content = "Device Connected (Fastboot)";
                            }
                        });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            DropShadowEffect myDropShadowEffect = new DropShadowEffect();
                            // Set the color of the shadow to Black.
                            Color myShadowColor = new Color();
                            myShadowColor.A = 255; // Note that the alpha value is ignored by Color property. 
                            // The Opacity property is used to control the alpha.
                            myShadowColor.B = 0;
                            myShadowColor.G = 0;
                            myShadowColor.R = 255;
                            myDropShadowEffect.Direction = 0;
                            myDropShadowEffect.ShadowDepth = 0;
                            myDropShadowEffect.Color = myShadowColor;
                            DeviceRectangle.Effect = myDropShadowEffect;
                            cc.Content = "No Device Connected";
                        });
                    }
                }
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = "CMD.exe";
                startInfo.Arguments = "/C fastboot devices";
                startInfo.CreateNoWindow = true;
                process.StartInfo = startInfo;
                process.Start();
                string output5 = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (output5.Contains("fastboot") == true)
                {
                    ConnectdDevice.Content = output5;
                }
                else
                {
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.FileName = "CMD.exe";
                        startInfo.Arguments = "/C adb devices";
                        startInfo.CreateNoWindow = true;
                        process.StartInfo = startInfo;
                        process.Start();
                        process.StandardOutput.ReadLine();
                        string output6 = process.StandardOutput.ReadLine();
                        process.WaitForExit();
                        if (output6.Contains("device") == true)
                        {
                            ConnectdDevice.Content = output6;
                        }
                        else
                        {
                            ConnectdDevice.Content = "Unable to Verify";
                        }
                }
            });
        }
        private void StartOps()
        {
            this.Dispatcher.Invoke(() =>
            {
                string input1 = BLCode.Text;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                string VisibleCMD = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "VisibleCMD.txt");
                if (File.Exists(VisibleCMD))
                {
                    cmdsi.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
                }
                cmdsi.Arguments = String.Format(@"/c fastboot.exe oem unlock", input1);
                Process cmd = Process.Start(cmdsi);
            });
        }
    }
}
