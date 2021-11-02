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
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "shell dumpsys battery";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();
            string outputbattery = process.StandardOutput.ReadLine();
            Thread.Sleep(1000);
            DebugShit.Text = outputbattery + "%";
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    string IsAnimated = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotAnimated.txt");
                    if (File.Exists(IsAnimated))
                    {

                    }
                    else
                    {
                        GridMain.Opacity = 0;
                        Grid r = (Grid)GridMain;
                        DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                        r.BeginAnimation(Grid.OpacityProperty, animation);
                    }
                });
            });
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir GSI & mkdir TWRP & mkdir boot & cd GSI & ren *.img system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd TWRP & ren *.img twrp.img";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
            string BootIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "boot", "boot.img");
            string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
            if (File.Exists(GSI))
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                        if (fInfo.Length < 500000000)
                        {
                            GSIFileLabel.Content = "Invalid (< 500MB)";
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
                        }
                        else
                        {
                            GSIRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            GSIFileLabel.Content = "Detected";
                        }
                    });
                });
            }
            else
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        GSIFileLabel.Content = "Not Detected";
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
                });
            }
            if (File.Exists(BootIMG))
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\boot\boot.img");
                        if (fInfo.Length > 100000000)
                        {
                            BootFileLabel.Content = "Invalid (> 100MB)";
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
                        }
                        else
                        {
                            BootRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            BootFileLabel.Content = "Detected";
                        }
                    });
                });
            }
            else
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        BootFileLabel.Content = "Not Detected";
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
                });
            }
            if (File.Exists(TWRPIMG))
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                        if (fInfo.Length > 100000000)
                        {
                            TWRPFileLabel.Content = "Invalid (> 100MB)";
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
                        }
                        else
                        {
                            TWRPRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            TWRPFileLabel.Content = "Detected";
                        }
                    });
                });
            }
            else
            {
                Task.Run(() =>
                {
                    dis.Invoke(() =>
                    {
                        TWRPFileLabel.Content = "Not Detected";
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
                });
            }
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
                }
                else
                {
                    DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                    cc.Content = "Yes (ADB)";
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
                }
                else
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
                }
            }
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
            Process.Start("CMD.exe");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UpdateCenter.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://youraveragegamer.wixsite.com/treble-toolkit";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("More.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir GSI & mkdir TWRP & mkdir boot & cd GSI & ren *.img system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd TWRP & ren *.img twrp.img";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                dis.Invoke(() =>
                {
                    string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
                    string BootIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "boot", "boot.img");
                    string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
                    if (File.Exists(GSI))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                                if (fInfo.Length < 500000000)
                                {
                                    GSIFileLabel.Content = "Invalid (< 500MB)";
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
                                }
                                else
                                {
                                    GSIRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                    GSIFileLabel.Content = "Detected";
                                }
                            });
                        });
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                GSIFileLabel.Content = "Not Detected";
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
                        });
                    }
                    if (File.Exists(BootIMG))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\boot\boot.img");
                                if (fInfo.Length > 100000000)
                                {
                                    BootFileLabel.Content = "Invalid (> 100MB)";
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
                                }
                                else
                                {
                                    BootRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                    BootFileLabel.Content = "Detected";
                                }
                            });
                        });
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                BootFileLabel.Content = "Not Detected";
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
                        });
                    }
                    if (File.Exists(TWRPIMG))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                                if (fInfo.Length > 100000000)
                                {
                                    TWRPFileLabel.Content = "Invalid (> 100MB)";
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
                                }
                                else
                                {
                                    TWRPRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                    TWRPFileLabel.Content = "Detected";
                                }
                            });
                        });
                    }
                    else
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                TWRPFileLabel.Content = "Not Detected";
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
                        });
                    }
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
                        }
                        else
                        {
                            DeviceRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                            cc.Content = "Yes (ADB)";
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
                        }
                        else
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
                        }
                    }
                }, DispatcherPriority.Normal);
            });
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
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
            if(GridMain.ActualWidth <= 530)
            {
                ConDev.Content = "Connected";
                if(cc.Content == "Yes (2+ Devices)") 
                {
                    cc.Content = "Yes (2+)";
                } else 
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
        }

        private void Setup(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
