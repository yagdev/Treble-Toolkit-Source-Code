﻿using System;
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
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(CheckGSI);
            thread2.Start();
            Thread thread3 = new Thread(CheckPhone);
            thread3.Start();
            Thread thread4 = new Thread(CheckTWRP);
            thread4.Start();
            Thread thread5 = new Thread(CheckBoot);
            thread5.Start();
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
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FlashButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPFlash.xaml", UriKind.Relative);
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
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Thread thread = new Thread(Size);
            thread.Start();
        }

        private void Setup(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup.xaml", UriKind.Relative);
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
            startInfo.Arguments = "/C adb.exe get-state";
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
                            cc.Content = "Yes (2+)";
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
                            cc.Content = "Yes (2+ Devices)";
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
                            cc.Content = "Yes (Fastboot)";
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
                        cc.Content = "No";
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
        private void Size()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.Dispatcher.Invoke(() =>
            {
                if (GridMain.ActualWidth <= 410)
                {
                    BootmgTitle.Content = "Boot Img";
                    TWRPImgTitle.Content = "TWRP Img";
                }
                else
                {
                    BootmgTitle.Content = "Boot Image";
                    TWRPImgTitle.Content = "TWRP Image";
                }
            });
            this.Dispatcher.Invoke(() =>
            {
                if (GridMain.ActualWidth <= 530)
                {
                    ConDev.Content = "Connected";
                    if (cc.Content == "Yes (2+ Devices)")
                    {
                        cc.Content = "Yes (2+)";
                    }
                    else
                    {
                        if (cc.Content == "Yes (Fastboot)")
                        {
                            cc.Content = "Yes (F)";
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    ConDev.Content = "Connected Device";
                    if (cc.Content == "Yes (2+)")
                    {
                        cc.Content = "Yes (2+ Devices)";
                    }
                    else
                    {
                        if (cc.Content == "Yes (F)")
                        {
                            cc.Content = "Yes (Fastboot)";
                        }
                    }
                }
            });
        }
        private void FreeCMD()
        {
            Process.Start("CMD.exe");
        }
    }
}
