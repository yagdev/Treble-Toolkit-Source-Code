using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TWRPBoot.xaml
    /// </summary>
    public partial class TWRPBoot : Page
    {
        public TWRPBoot()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
            Thread thread3 = new Thread(Prepare);
            thread3.Start();
            Thread thread5 = new Thread(CheckPhone);
            thread5.Start();
            Thread thread6 = new Thread(UpdateUI);
            thread6.Start();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ReportBug.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Next);
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
        private void SupportLock()
        {
            if (Environment.OSVersion.Version.Build <= 9)
            {
                this.Dispatcher.Invoke(() =>
                {
                    DeviceSpecificFeatures_Copy.IsEnabled = false;
                    DeviceSpecificFeatures_Copy.Content = "🔒 Report Bug";
                });
            }
        }
        private void Prepare()
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            cmdsi.Arguments = command;
            Process cmd = Process.Start(cmdsi);
        }
        private void Next()
        {
            if (File.Exists("../Place_Files_Here/TWRP/twrp.img"))
            {

                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Uri uri = new Uri("TWRPBootPickFile.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    });
                }
                else
                {
                    String command = @"/C adb.exe reboot-bootloader & cd .. & cd Place_Files_Here & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe boot ../Place_Files_Here/TWRP/twrp.img & cd .. & cd Place_Files_Here & mkdir TWRP & wmic process where name='adb.exe' delete";
                    ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
                    cmdsi.Arguments = command;
                    Process cmd = Process.Start(cmdsi);
                    cmd.WaitForExit();
                    this.Dispatcher.Invoke(() =>
                    {
                        Uri uri = new Uri("TWRPBootFinished.xaml", UriKind.Relative);
                        this.NavigationService.Navigate(uri);
                    });
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Uri uri = new Uri("TWRPBootPickFile.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
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
                    PhoneStatus2.Content = "Fastboot";
                });
            }
            else
            {
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
                        PhoneStatus2.Content = "ADB";
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        PhoneStatus2.Content = "Device Not Detected";
                    });
                }
            }
            this.Dispatcher.Invoke(() =>
            {
                if (PhoneStatus2.Content == "Device Not Detected")
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
                }
                else
                {
                    GSIRectangle.Effect = DeviceSpecificFeatures_Copy1.Effect;
                }
            });
            string TWRPIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "TWRP", "twrp.img");
            if (File.Exists(TWRPIMG))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\TWRP\twrp.img");
                if (fInfo.Length > 100000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        FileInfo fs = new FileInfo(TWRPIMG);
                        long filesize = fs.Length / 1000000;
                        PhoneStatus2.Content = PhoneStatus2.Content + " · Invalid Image (+100 MB)";
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
                    });
                    FileInfo fs = new FileInfo(TWRPIMG);
                    if (fs.Length >= 1000000000)
                    {
                        long filesize = fs.Length / 1000000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            PhoneStatus2.Content = PhoneStatus2.Content + " · Valid Image (" + System.Convert.ToString(filesize) + "GB)";
                        });
                    }
                    else
                    {
                        long filesize = fs.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            PhoneStatus2.Content = PhoneStatus2.Content + " · Valid Image (" + System.Convert.ToString(filesize) + "MB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneStatus2.Content = PhoneStatus2.Content + " · No Image";
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
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrp-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrp-light.png"));
                }
            });
        }
    }
}
