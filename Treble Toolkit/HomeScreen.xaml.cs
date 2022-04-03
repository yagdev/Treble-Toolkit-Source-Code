using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.IO;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        public HomeScreen()
        {
            InitializeComponent();
            Thread thread7 = new Thread(UpdateUIWidgets);
            thread7.Start();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread6 = new Thread(UpdateUI);
            thread6.Start();
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIAFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void CompatibleDevices_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("VendorFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Format_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FormatPartitions.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ABButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FlashGSI.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FlashButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPShits.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BootButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPBoot.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBootloader.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FreeCMD_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FreeCMD.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
            Thread thread = new Thread(FreeCMD);
            thread.Start();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UpdateCenter.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Website);
            thread.Start();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckGSI);
            thread.Start();
            Thread thread2 = new Thread(CheckPhone);
            thread2.Start();
            Thread thread3 = new Thread(CheckTWRP);
            thread3.Start();
            Thread thread4 = new Thread(CheckBoot);
            thread4.Start();
            Thread thread5 = new Thread(UpdateUI);
            thread5.Start();
        }

        private void Setup(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void ChangeWidgets(object sender, RoutedEventArgs e)
        {
            Thread thread1 = new Thread(UpdateUIWidgetsClick);
            thread1.Start();
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
        private void CheckGSI()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir GSI & cd GSI & ren *.img system.img";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
            if (File.Exists(GSI))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length< 500000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        GSIFileLabel.Content = "Invalid (< 500MB)";
                    });
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
                        GSIRectangle.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        GSIRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                        GSIFileLabel.Content = "Detected";
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    GSIFileLabel.Content = "Not Detected";
                });
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
                    GSIRectangle.Effect = myDropShadowEffect;
                });
            }
        }
        private void CheckBoot()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string BootIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "boot", "boot.img");
            if (File.Exists(BootIMG))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\boot\boot.img");
                if (fInfo.Length > 100000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        BootFileLabel.Content = "Invalid (> 100MB)";
                    });
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
                        BootRectangle.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        BootRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                        BootFileLabel.Content = "Detected";
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    BootFileLabel.Content = "Not Detected";
                });
                this.Dispatcher.Invoke(() =>
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
                    BootRectangle.Effect = myDropShadowEffect;
                });
            }
        }
        private void CheckTWRP()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir TWRP & cd TWRP & ren *.img twrp.img";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
            if (File.Exists(TWRPIMG))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        TWRPFileLabel.Content = "Invalid (> 100MB)";
                    });
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
                        TWRPRectangle.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        TWRPRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                        TWRPFileLabel.Content = "Detected";
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    TWRPFileLabel.Content = "Not Detected";
                });
                this.Dispatcher.Invoke(() =>
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
                    TWRPRectangle.Effect = myDropShadowEffect;
                });
            }
        }
        private void CheckPhone()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C adb.exe get-state & wmic process where name='adb.exe' delete";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            string output3 = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
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
                            cc.Content = "Connected (2+)";
                        }
                        else
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
                            cc.Content = "Connected (2+ Devices)";
                        }
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                        cc.Content = "Yes (ADB)";
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
                            cc.Content = "Yes (F)";
                        }
                        else
                        {
                            DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            cc.Content = "Connected (Fastboot)";
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
                        cc.Content = "Not Connected";
                    });
                }
            }
        }
        private void Website()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit";
            process.StartInfo = startInfo;
            process.Start();
        }
        private void FreeCMD()
        {
            Process.Start("CMD.exe");
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                string IntensityFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Intensity.txt");
                string SlipsideFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Slipside.txt");
                string JoyFile = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "Joy.txt");
                if (File.Exists(SlipsideFile))
                {
                    Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt2"];
                    Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                    Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                }
                else
                {
                    if (File.Exists(IntensityFile))
                    {
                        Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt1"];
                        Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style2"];
                        Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt2"];
                    }
                    else
                    {
                        if (File.Exists(JoyFile))
                        {
                            Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt3"];
                            Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4Style3"];
                            Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt3"];
                        }
                        else
                        {
                            Application.Current.Resources["Button21.8.1Rev4"] = Application.Current.Resources["22.4Alt2"];
                            Application.Current.Resources["Rectangle22.4Style1"] = Application.Current.Resources["Rectangle22.4StyleDefault"];
                            Application.Current.Resources["ImageButton22.4Default"] = Application.Current.Resources["ImageButton22.4Alt1"];
                        }
                    }
                }
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    if (Widgets.Width == new System.Windows.GridLength(70))
                    {
                        DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-expand-dark.png"));
                    }
                    else
                    {
                        DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-shrink-dark.png"));
                    }
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bootimg-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrpimg-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    BtnImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-erase-dark.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrp-dark.png"));
                    BtnImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-dark.png"));
                    BtnImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-web-dark.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-lock-dark.png"));
                    BtnImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-dark.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-freecmd-dark.png"));
                    BtnImg_Copy8.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-dark.png"));
                }
                else
                {
                    if (Widgets.Width == new System.Windows.GridLength(70))
                    {
                        DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-expand-light.png"));
                    }
                    else
                    {
                        DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-shrink-light.png"));
                    }
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bootimg-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrpimg-light.png"));
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    BtnImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-erase-light.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrp-light.png"));
                    BtnImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-light.png"));
                    BtnImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-web-light.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-lock-light.png"));
                    BtnImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-up-light.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-freecmd-light.png"));
                    BtnImg_Copy8.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-info-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                }
            });
        }
        private void UpdateUIWidgets()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string DisableWidgets = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DisableWidgets.txt");
            if (File.Exists(DisableWidgets))
            {
                this.Dispatcher.Invoke(() =>
                {
                    Widgets.Width = new System.Windows.GridLength(70, GridUnitType.Pixel);
                    DeviceRectangle.Visibility = Visibility.Hidden;
                    BootRectangle.Visibility = Visibility.Hidden;
                    GSIRectangle.Visibility = Visibility.Hidden;
                    TWRPRectangle.Visibility = Visibility.Hidden;
                    PhoneStatus.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy1.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy2.Visibility = Visibility.Hidden;
                    cc.Visibility = Visibility.Hidden;
                    GSIFileLabel.Visibility = Visibility.Hidden;
                    BootFileLabel.Visibility = Visibility.Hidden;
                    TWRPFileLabel.Visibility = Visibility.Hidden;
                    DeviceInfoImg.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy1.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy2.Visibility = Visibility.Hidden;
                    DeviceSpecificFeatures_Copy.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy3.Visibility = Visibility.Hidden;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Thread thread2 = new Thread(CheckGSI);
                    thread2.Start();
                    Thread thread3 = new Thread(CheckPhone);
                    thread3.Start();
                    Thread thread4 = new Thread(CheckTWRP);
                    thread4.Start();
                    Thread thread5 = new Thread(CheckBoot);
                    thread5.Start();
                    Widgets.Width = new System.Windows.GridLength(1, GridUnitType.Star);
                    DeviceRectangle.Visibility = Visibility.Visible;
                    BootRectangle.Visibility = Visibility.Visible;
                    GSIRectangle.Visibility = Visibility.Visible;
                    TWRPRectangle.Visibility = Visibility.Visible;
                    PhoneStatus.Visibility = Visibility.Visible;
                    PhoneStatus_Copy.Visibility = Visibility.Visible;
                    PhoneStatus_Copy1.Visibility = Visibility.Visible;
                    PhoneStatus_Copy2.Visibility = Visibility.Visible;
                    cc.Visibility = Visibility.Visible;
                    GSIFileLabel.Visibility = Visibility.Visible;
                    BootFileLabel.Visibility = Visibility.Visible;
                    TWRPFileLabel.Visibility = Visibility.Visible;
                    DeviceInfoImg.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy1.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy2.Visibility = Visibility.Visible;
                    DeviceSpecificFeatures_Copy.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy3.Visibility = Visibility.Visible;
                });
            }
            Thread thread1 = new Thread(UpdateUI);
            thread1.Start();
        }
        private void UpdateUIWidgetsClick()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string DisableWidgets = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DisableWidgets.txt");
            if (File.Exists(DisableWidgets))
            {
                File.Delete(DisableWidgets);
                this.Dispatcher.Invoke(() =>
                {
                    Thread thread2 = new Thread(CheckGSI);
                    thread2.Start();
                    Thread thread3 = new Thread(CheckPhone);
                    thread3.Start();
                    Thread thread4 = new Thread(CheckTWRP);
                    thread4.Start();
                    Thread thread5 = new Thread(CheckBoot);
                    thread5.Start();
                    Widgets.Width = new System.Windows.GridLength(1, GridUnitType.Star);
                    DeviceRectangle.Visibility = Visibility.Visible;
                    BootRectangle.Visibility = Visibility.Visible;
                    GSIRectangle.Visibility = Visibility.Visible;
                    TWRPRectangle.Visibility = Visibility.Visible;
                    PhoneStatus.Visibility = Visibility.Visible;
                    PhoneStatus_Copy.Visibility = Visibility.Visible;
                    PhoneStatus_Copy1.Visibility = Visibility.Visible;
                    PhoneStatus_Copy2.Visibility = Visibility.Visible;
                    cc.Visibility = Visibility.Visible;
                    GSIFileLabel.Visibility = Visibility.Visible;
                    BootFileLabel.Visibility = Visibility.Visible;
                    TWRPFileLabel.Visibility = Visibility.Visible;
                    DeviceInfoImg.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy1.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy2.Visibility = Visibility.Visible;
                    DeviceSpecificFeatures_Copy.Visibility = Visibility.Visible;
                    DeviceInfoImg_Copy3.Visibility = Visibility.Visible;
                });
            }
            else
            {
                using (StreamWriter sw = File.CreateText(DisableWidgets))
                {
                    sw.WriteLine("Treble Toolkit Settings Item");
                    sw.WriteLine("©2022 YAG-dev");
                }
                this.Dispatcher.Invoke(() =>
                {
                    Widgets.Width = new System.Windows.GridLength(70, GridUnitType.Pixel);
                    DeviceRectangle.Visibility = Visibility.Hidden;
                    BootRectangle.Visibility = Visibility.Hidden;
                    GSIRectangle.Visibility = Visibility.Hidden;
                    TWRPRectangle.Visibility = Visibility.Hidden;
                    PhoneStatus.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy1.Visibility = Visibility.Hidden;
                    PhoneStatus_Copy2.Visibility = Visibility.Hidden;
                    cc.Visibility = Visibility.Hidden;
                    GSIFileLabel.Visibility = Visibility.Hidden;
                    BootFileLabel.Visibility = Visibility.Hidden;
                    TWRPFileLabel.Visibility = Visibility.Hidden;
                    DeviceInfoImg.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy1.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy2.Visibility = Visibility.Hidden;
                    DeviceSpecificFeatures_Copy.Visibility = Visibility.Hidden;
                    DeviceInfoImg_Copy3.Visibility = Visibility.Hidden;
                });
            }
            Thread thread1 = new Thread(UpdateUI);
            thread1.Start();
        }
    }
}
