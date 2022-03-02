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
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Diagnostics;
using System.Windows.Diagnostics;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Setup2.xaml
    /// </summary>
    public partial class Setup2 : Page
    {
        public Setup2()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Check);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Check);
            thread.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup3.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Troubleshoot(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FixConnectionPhoneStep1.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(RefreshADB);
            thread.Start();
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(RefreshFastboot);
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
        private void Check()
        {
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
            if (output3.Contains("device") == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Not Detected";
                });
            }
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
                    FastbootStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    FastbootStatus.Content = "Not Detected";
                });
            }
            if (output4.Contains("fastboot") == false && output3.Contains("device") == false)
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneWarningBtn.Visibility = Visibility.Visible;
                    cc.Content = "Setup · Phone Not Detected";
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
                    BugReport.Effect = myDropShadowEffect;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneWarningBtn.Visibility = Visibility.Hidden;
                    cc.Content = "Setup";
                    BugReport.Effect = DeviceSpecificFeatures_Copy.Effect;
                });
            }
        }
        private void RefreshADB()
        {
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
            if (output3.Contains("device") == true)
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    ADBStatus.Content = "Not Detected";
                });
            }
            this.Dispatcher.Invoke(() =>
            {
                if (ADBStatus.Content == "Not Detected" && FastbootStatus.Content == "Not Detected")
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneWarningBtn.Visibility = Visibility.Visible;
                        cc.Content = "Setup · Phone Not Detected";
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
                        BugReport.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneWarningBtn.Visibility = Visibility.Hidden;
                        cc.Content = "Setup";
                        BugReport.Effect = DeviceSpecificFeatures_Copy.Effect;
                    });
                }
            });
        }
        private void RefreshFastboot()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
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
                    FastbootStatus.Content = "Detected";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    FastbootStatus.Content = "Not Detected";
                });
            }
            this.Dispatcher.Invoke(() =>
            {
                if (ADBStatus.Content == "Not Detected" && FastbootStatus.Content == "Not Detected")
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneWarningBtn.Visibility = Visibility.Visible;
                        cc.Content = "Setup · Phone Not Detected";
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
                        BugReport.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneWarningBtn.Visibility = Visibility.Hidden;
                        cc.Content = "Setup";
                        BugReport.Effect = DeviceSpecificFeatures_Copy.Effect;
                    });
                }
            });
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                }
            });
        }
    }
}
