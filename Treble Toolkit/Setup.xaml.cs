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
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Diagnostics;
using System.Windows.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : Page
    {
        public Setup()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(FileProcess);
            thread2.Start();
            Thread thread3 = new Thread(UpdateUI);
            thread3.Start();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(FileProcess);
            thread.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Change1Prc);
            thread.Start();
        }

        private void Delete1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Delete1Prc);
            thread.Start();
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Change2Prc);
            thread.Start();
        }

        private void Delete2(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Delete2Prc);
            thread.Start();
        }

        private void Change3(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Change3Prc);
            thread.Start();
        }

        private void Delete3(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Delete3Prc);
            thread.Start();
        }

        private void Change4(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Change4Prc);
            thread.Start();
        }

        private void Delete4(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Delete4Prc);
            thread.Start();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup2.xaml", UriKind.Relative);
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
        private void FileProcess()
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
            Thread thread = new Thread(CheckGSI);
            thread.Start();
            Thread thread2 = new Thread(CheckTWRP);
            thread2.Start();
            Thread thread3 = new Thread(CheckBoot);
            thread3.Start();
            Thread thread4 = new Thread(VbmetaIMGCheck);
            thread4.Start();
        }
        private void CheckGSI()
        {
            string GSI = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "GSI", "system.img");
            if (File.Exists(GSI))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                if (fInfo.Length < 500000000)
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
                    });
                    FileInfo fs = new FileInfo(GSI);
                    if (fs.Length >= 1000000000)
                    {
                        long filesize = fs.Length / 1000000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "GB)";
                        });
                    }
                    else
                    {
                        long filesize = fs.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    GSIFileLabel.Content = "Not Detected";
                    Change1b.Content = "Add";
                    Delete1b.Content = "🔒 Delete";
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
                    });
                    FileInfo fs2 = new FileInfo(BootIMG);
                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                    if (fs2.Length >= 1000000000)
                    {
                        long filesize2 = fs2.Length / 1000000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            BootFileLabel.Content = "Invalid File (>100MB)";
                        });
                    }
                    else
                    {
                        long filesize2 = fs2.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            BootFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    BootFileLabel.Content = "Not Detected";
                    Change2b.Content = "Add";
                    Delete2b.Content = "🔒 Delete";
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
                    });
                    FileInfo fs = new FileInfo(TWRPIMG);
                    if (fs.Length >= 1000000000)
                    {
                        long filesize = fs.Length / 1000000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            TWRPFileLabel.Content = "Invalid File (>100MB)";
                        });
                    }
                    else
                    {
                        long filesize = fs.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            TWRPFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    TWRPFileLabel.Content = "Not Detected";
                    Change4b.Content = "Add";
                    Delete4b.Content = "🔒 Delete";
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
        private void VbmetaIMGCheck()
        {
            string VbmetaIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "Vbmeta", "vbmeta.img");
            if (File.Exists(VbmetaIMG))
            {
                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\Vbmeta\vbmeta.img");
                if (fInfo.Length > 10000000)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        VbmetaFileLabel.Content = "Invalid (> 10MB)";
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
                        VbmetaRectangle.Effect = myDropShadowEffect;
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        VbmetaRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                    });
                    FileInfo fs2 = new FileInfo(VbmetaIMG);
                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\vbmeta\vbmeta.img");
                    if (fs2.Length >= 1000000)
                    {
                        long filesize2 = fs2.Length / 1000000;
                        this.Dispatcher.Invoke(() =>
                        {
                            VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                        });
                    }
                    else
                    {
                        long filesize2 = fs2.Length / 1000;
                        this.Dispatcher.Invoke(() =>
                        {
                            VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "KB)";
                        });
                    }
                }
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    VbmetaFileLabel.Content = "Not Detected";
                    Change3b.Content = "Add";
                    Delete3b.Content = "🔒 Delete";
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
                    VbmetaRectangle.Effect = myDropShadowEffect;
                });
            }
        }
        private void Change1Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir GSI & cd GSI & start . & ren *.img system.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete1Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir GSI & cd GSI & del /f /q system.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change2Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir boot & cd boot & start . & ren * boot.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete2Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir boot & cd boot & del /f /q boot.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change3Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir vbmeta & cd vbmeta & start . & ren * vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete3Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir vbmeta & cd vbmeta & del /f /q vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change4Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir twrp & cd twrp & start . & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete4Prc()
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir twrp & cd twrp & del /f /q twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bootimg-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-vbmetaimg-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrpimg-dark.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                    DeviceSpecificFeatures_Copy2.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-settings-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-bootimg-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-vbmetaimg-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-twrpimg-light.png"));
                    DeviceSpecificFeatures_Copy.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceSpecificFeatures_Copy1.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                    DeviceSpecificFeatures_Copy2.Tag = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-launch-light.png"));
                }
            });
        }
    }
}
