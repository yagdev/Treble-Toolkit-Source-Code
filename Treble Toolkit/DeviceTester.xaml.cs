using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media.Effects;
using System.Windows.Media;
using Microsoft.Win32;
using System.Linq;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for DeviceTester.xaml
    /// </summary>
    public partial class DeviceTester : Page
    {
        public string GetTheme()
        {
            string RegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes";
            string theme;
            theme = (string)Registry.GetValue(RegistryKey, "CurrentTheme", string.Empty);
            theme = theme.Split('\\').Last().Split('.').First().ToString();
            return theme;
        }
        public DeviceTester()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(Check1);
            thread2.Start();
            Thread thread3 = new Thread(Check2);
            thread3.Start();
            Thread thread4 = new Thread(Check3);
            thread4.Start();
            Thread thread5 = new Thread(Check4);
            thread5.Start();
            Thread thread6 = new Thread(Check5);
            thread6.Start();
            Thread thread7 = new Thread(Check6);
            thread7.Start();
            Thread thread8 = new Thread(Check7);
            thread8.Start();
            Thread thread9 = new Thread(Check8);
            thread9.Start();
            Thread thread10 = new Thread(UpdateUI);
            thread10.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            Thread thread2 = new Thread(Check1);
            thread2.Start();
            Thread thread3 = new Thread(Check2);
            thread3.Start();
            Thread thread4 = new Thread(Check3);
            thread4.Start();
            Thread thread5 = new Thread(Check4);
            thread5.Start();
            Thread thread6 = new Thread(Check5);
            thread6.Start();
            Thread thread7 = new Thread(Check6);
            thread7.Start();
            Thread thread8 = new Thread(Check7);
            thread8.Start();
            Thread thread9 = new Thread(Check8);
            thread9.Start();
            Thread thread10 = new Thread(UpdateUI);
            thread10.Start();
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
        private void Check1()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.product.model";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output2 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    Model.Content = output2;
                    if (output2.Length == 0)
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
                        TrebleSupportRectangle.Effect = myDropShadowEffect;
                        Model.Content = "Unable to retrieve";
                    }
                    else
                    {
                        TrebleSupportRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check2()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.treble.enabled";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SupportsTreble.Content = output3;
                    if (output3.Contains("true") == true)
                    {
                        SupportsTreble.Content = "Project Treble Supported";
                        TrebleSupportRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                    else
                    {
                        SupportsTreble.Content = "Project Treble Not Supported";
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
                        TrebleSupportRectangle.Effect = myDropShadowEffect;
                    }
                    if (output3.Length == 0)
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
                        TrebleSupportRectangle.Effect = myDropShadowEffect;
                        SupportsTreble.Content = "Unable to retrieve";
                    }
                    else
                    {
                        
                    }
                });
            });

        }
        private void Check3()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.release";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output4 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    AndroidVersion.Content = output4;
                    if (output4.Length == 0)
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
                        AndroidRectangle.Effect = myDropShadowEffect;
                        AndroidVersion.Content = "Unable to retrieve";
                    }
                    else
                    {
                        AndroidRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check4()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.system.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output5 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SDKVersion.Content = output5;
                    if (output5.Length == 0)
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
                        SDK1Rectangle.Effect = myDropShadowEffect;
                        SDKVersion.Content = "Unable to retrieve";
                    }
                    else
                    {
                        SDK1Rectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check5()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.build.version.security_patch";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output6 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SecurityPatch.Content = output6;
                    if (output6.Length == 0)
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
                        SecurityPatchRectangle.Effect = myDropShadowEffect;
                        SecurityPatch.Content = "Unable to retrieve";
                    }
                    else
                    {
                        SecurityPatchRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check6()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.crypto.state";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output8 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (output8.Contains("encrypted") == true)
                    {
                        IsEncrypted.Content = "Encrypted";
                    }
                    else
                    {
                        IsEncrypted.Content = "Not Encrypted";
                    }
                    if (output8.Length == 0)
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
                        CryptoRectangle.Effect = myDropShadowEffect;
                        IsEncrypted.Content = "Unable to retrieve";
                    }
                    else
                    {
                        CryptoRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check7()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.serialno";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output9 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    SN.Content = output9;
                    if (output9.Length == 0)
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
                        SNRectangle.Effect = myDropShadowEffect;
                        SN.Content = "Unable to retrieve";
                    }
                    else
                    {
                        SNRectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void Check8()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe shell getprop ro.vendor.build.version.sdk";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output10 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    VendorSDK.Content = output10;
                    if (output10.Length == 0)
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
                        SDK2Rectangle.Effect = myDropShadowEffect;
                        VendorSDK.Content = "Unable to retrieve";
                    }
                    else
                    {
                        SDK2Rectangle.Effect = DeviceSpecificFeatures_Copy4.Effect;
                    }
                });
            });
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-security-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-lock-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sdk-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-android-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sdk-dark.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sn-dark.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-security-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-lock-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sdk-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-android-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sdk-light.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-sn-light.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                }
            });
        }
    }
}
