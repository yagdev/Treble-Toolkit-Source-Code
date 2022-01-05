using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for GSIABFlash.xaml
    /// </summary>
    public partial class GSIABFlash : Page
    {
        public GSIABFlash()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(SupportLock);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
            Thread thread4 = new Thread(PrepareFiles);
            thread4.Start();
            Thread thread5 = new Thread(CheckPhone);
            thread5.Start();
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
            if (File.Exists("../Place_Files_Here/GSI/system.img"))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
                {
                    Thread thread = new Thread(Next1);
                    thread.Start();
                }
                else
                {
                    Uri uri = new Uri("GSIFlashAB.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                Uri uri = new Uri("GSIABPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private void AddVbmeta_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                Thread thread = new Thread(AddVbmeta1);
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(AddVbmeta2);
                thread.Start();
            }
        }

        private void AddBoot_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../Place_Files_Here/boot/boot.img"))
            {
                Thread thread = new Thread(AddBoot1);
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(AddBoot2);
                thread.Start();
            }
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
        private void PrepareFiles()
        {
            String command = @"/C cd .. & cd Place_Files_Here & cd GSI & ren * system.img & cd .. & cd boot & ren *.img boot.img & cd .. & cd vbmeta & ren * vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
            if (File.Exists("../Place_Files_Here/vbmeta/vbmeta.img"))
            {
                this.Dispatcher.Invoke(() =>
                {
                    AddVbmeta.Visibility = Visibility.Hidden;
                    RectangleNormal.Visibility = Visibility.Hidden;
                    BootRectangle.Visibility = Visibility.Hidden;
                    VbmetaRectangle.Visibility = Visibility.Visible;
                });
            }
            else
            {

            }
            this.Dispatcher.Invoke(() =>
            {
                if (File.Exists("../Place_Files_Here/boot/boot.img") & AddVbmeta.Visibility == Visibility.Hidden)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        AddBootBtn.Visibility = Visibility.Hidden;
                        RectangleNormal.Visibility = Visibility.Visible;
                        BootRectangle.Visibility = Visibility.Hidden;
                        VbmetaRectangle.Visibility = Visibility.Hidden;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (AddVbmeta.Visibility == Visibility.Visible)
                        {
                            RectangleNormal.Visibility = Visibility.Hidden;
                            BootRectangle.Visibility = Visibility.Hidden;
                            VbmetaRectangle.Visibility = Visibility.Visible;
                        }
                    });
                }
            });
        }
        private void AddVbmeta1()
        {
            this.Dispatcher.Invoke(() =>
            {
                AddVbmeta.Visibility = Visibility.Hidden;
                RectangleNormal.Visibility = Visibility.Visible;
                BootRectangle.Visibility = Visibility.Hidden;
                VbmetaRectangle.Visibility = Visibility.Hidden;
            });
        }
        private void AddVbmeta2()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd Place_Files_Here & cd vbmeta & start .";
            process.StartInfo = startInfo;
            process.Start();
        }
        private void AddBoot1()
        {
            this.Dispatcher.Invoke(() =>
            {
                AddBootBtn.Visibility = Visibility.Hidden;
                RectangleNormal.Visibility = Visibility.Visible;
                BootRectangle.Visibility = Visibility.Hidden;
                VbmetaRectangle.Visibility = Visibility.Hidden;
            });
        }
        private void AddBoot2()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C cd .. & cd Place_Files_Here & cd boot & start .";
            Process.Start("CMD.exe", strCmdText);
        }
        private void Next1()
        {
            this.Dispatcher.Invoke(() =>
            {
                Uri uri = new Uri("GSIABPickAFile.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            });
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
            string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
            if (File.Exists(GSI))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        FileInfo fs = new FileInfo(GSI);
                        long filesize = fs.Length / 1000000;
                        PhoneStatus2.Content = PhoneStatus2.Content + " · Invalid GSI (-500 MB)";
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
                    FileInfo fs = new FileInfo(GSI);
                    if (fs.Length >= 1000000000)
                    {
                        long filesize = fs.Length / 1000000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            PhoneStatus2.Content = PhoneStatus2.Content + " · Valid GSI (" + System.Convert.ToString(filesize) + "GB)";
                        });
                    }
                    else
                    {
                        long filesize = fs.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            PhoneStatus2.Content = PhoneStatus2.Content + " · Valid GSI (" + System.Convert.ToString(filesize) + "MB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    PhoneStatus2.Content = PhoneStatus2.Content + " · No GSI";
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
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-flash-light.png"));
                }
            });
        }
    }
}
