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
using System.Threading.Tasks;
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
                    string VbmetaIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "Vbmeta", "vbmeta.img");
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
                                    FileInfo fs = new FileInfo(GSI);
                                    if (fs.Length >= 1000000000) 
                                    {
                                        long filesize = fs.Length / 1000000000;
                                        GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "GB)";
                                    }
                                    else 
                                    {
                                        long filesize = fs.Length / 1000000;
                                        GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                                    }
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
                                Change1b.Content = "Add"; 
                                Delete1b.Content = "🔒 Delete";
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
                                    FileInfo fs2 = new FileInfo(BootIMG);
                                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                                    if (fs2.Length >= 1000000000)
                                    {
                                        long filesize2 = fs2.Length / 1000000000;
                                        BootFileLabel.Content = "Invalid File (>100MB)";
                                    }
                                    else
                                    {
                                        long filesize2 = fs2.Length / 1000000;
                                        BootFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                                    }
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
                                Change2b.Content = "Add";
                                Delete2b.Content = "🔒 Delete";
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
                                    FileInfo fs = new FileInfo(TWRPIMG);
                                    if (fs.Length >= 1000000000)
                                    {
                                        long filesize = fs.Length / 1000000000;
                                        TWRPFileLabel.Content = "Invalid File (>100MB)";
                                    }
                                    else
                                    {
                                        long filesize = fs.Length / 1000000;
                                        TWRPFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                                    }
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
                                Change4b.Content = "Add";
                                Delete4b.Content = "🔒 Delete";
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
                    if (File.Exists(VbmetaIMG))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\Vbmeta\vbmeta.img");
                                if (fInfo.Length > 10000000)
                                {
                                    VbmetaFileLabel.Content = "Invalid (> 10MB)";
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
                                }
                                else
                                {
                                    VbmetaRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                    FileInfo fs2 = new FileInfo(VbmetaIMG);
                                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\vbmeta\vbmeta.img");
                                    if (fs2.Length >= 1000000)
                                    {
                                        long filesize2 = fs2.Length / 1000000;
                                        VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                                    }
                                    else
                                    {
                                        long filesize2 = fs2.Length / 1000;
                                        VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "KB)";
                                    }
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
                                VbmetaFileLabel.Content = "Not Detected";
                                Change3b.Content = "Add";
                                Delete3b.Content = "🔒 Delete";
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
                        });
                    }
                }, DispatcherPriority.Normal);
            });
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
                    string VbmetaIMG = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\", "Place_Files_Here", "Vbmeta", "vbmeta.img");
                    if (File.Exists(GSI))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                Change1b.Content = "Change";
                                Delete1b.Content = "Delete";
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
                                    Change1b.Content = "Change";
                                    Delete1b.Content = "Delete";
                                    FileInfo fs = new FileInfo(GSI);
                                    if (fs.Length >= 1000000000)
                                    {
                                        long filesize = fs.Length / 1000000000;
                                        GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "GB)";
                                    }
                                    else
                                    {
                                        long filesize = fs.Length / 1000000;
                                        GSIFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                                    }
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
                                Change1b.Content = "Add";
                                Delete1b.Content = "🔒 Delete";
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
                                Change2b.Content = "Change";
                                Delete2b.Content = "Delete";
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
                                    Change2b.Content = "Change";
                                    Delete2b.Content = "Delete";
                                    FileInfo fs2 = new FileInfo(BootIMG);
                                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\GSI\system.img");
                                    if (fs2.Length >= 1000000000)
                                    {
                                        long filesize2 = fs2.Length / 1000000000;
                                        BootFileLabel.Content = "Invalid File (>100MB)";
                                    }
                                    else
                                    {
                                        long filesize2 = fs2.Length / 1000000;
                                        BootFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                                    }
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
                                Change2b.Content = "Add";
                                Delete2b.Content = "🔒 Delete";
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
                                    Change4b.Content = "Change";
                                    Delete4b.Content = "Delete";
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
                                    Change4b.Content = "Change";
                                    Delete4b.Content = "Delete";
                                    FileInfo fs = new FileInfo(TWRPIMG);
                                    if (fs.Length >= 1000000000)
                                    {
                                        long filesize = fs.Length / 1000000000;
                                        TWRPFileLabel.Content = "Invalid File (>100MB)";
                                    }
                                    else
                                    {
                                        long filesize = fs.Length / 1000000;
                                        TWRPFileLabel.Content = "Detected (" + System.Convert.ToString(filesize) + "MB)";
                                    }
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
                                Change4b.Content = "Add";
                                Delete4b.Content = "🔒 Delete";
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
                    if (File.Exists(VbmetaIMG))
                    {
                        Task.Run(() =>
                        {
                            dis.Invoke(() =>
                            {
                                FileInfo fInfo = new FileInfo(@"..\Place_Files_Here\Vbmeta\vbmeta.img");
                                if (fInfo.Length > 10000000)
                                {
                                    VbmetaFileLabel.Content = "Invalid (> 10MB)";
                                    Change3b.Content = "Change";
                                    Delete3b.Content = "Delete";
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
                                }
                                else
                                {
                                    VbmetaRectangle.Effect = DeviceSpecificFeatures_Copy.Effect;
                                    Change3b.Content = "Change";
                                    Delete3b.Content = "Delete";
                                    FileInfo fs2 = new FileInfo(VbmetaIMG);
                                    FileInfo fInfo2 = new FileInfo(@"..\Place_Files_Here\vbmeta\vbmeta.img");
                                    if (fs2.Length >= 1000000)
                                    {
                                        long filesize2 = fs2.Length / 1000000;
                                        VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "MB)";
                                    }
                                    else
                                    {
                                        long filesize2 = fs2.Length / 1000;
                                        VbmetaFileLabel.Content = "Detected (" + System.Convert.ToString(filesize2) + "KB)";
                                    }
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
                                VbmetaFileLabel.Content = "Not Detected";
                                Change3b.Content = "Add";
                                Delete3b.Content = "🔒 Delete";
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
                        });
                    }
                }, DispatcherPriority.Normal);
            });
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Change1(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir GSI & cd GSI & start . & ren *.img system.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete1(object sender, RoutedEventArgs e)
        {
            String command = @"/C cd .. & cd Place_Files_Here & mkdir GSI & cd GSI & del /f /q system.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change2(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir boot & cd boot & start . & ren * boot.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete2(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir boot & cd boot & del /f /q boot.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change3(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir vbmeta & cd vbmeta & start . & ren * vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete3(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir vbmeta & cd vbmeta & del /f /q vbmeta.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Change4(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir twrp & cd twrp & start . & ren * twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Delete4(object sender, RoutedEventArgs e)
        {
            String command = @"/C taskkill /f /im explorer.exe & start explorer.exe & cd .. & cd Place_Files_Here & mkdir twrp & cd twrp & del /f /q twrp.img";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Setup2.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
