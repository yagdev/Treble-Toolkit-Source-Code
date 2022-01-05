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
using System.Windows.Media.Effects;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for BugReports.xaml
    /// </summary>
    public partial class BugReports : Page
    {
        public BugReports()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PrivacyAndDataManagement.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelReport(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(DeleteReport);
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
        private void DeleteReport()
        {
            string Report = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "BugReports", "Report.txt");
            if (File.Exists(Report))
            {
                File.Delete(Report);
            }
        }
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-folder-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-folder-light.png"));
                }
            });
            string Report = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "BugReports", "Report.txt");
            if (File.Exists(Report))
            {
                FileInfo fInfo = new FileInfo(@"..\..\BugReports\Report.txt");
                this.Dispatcher.Invoke(() =>
                {
                    BugReport.Effect = DeviceSpecificFeatures_Copy.Effect;
                });
                FileInfo fs = new FileInfo(Report);
                if (fs.Length >= 1000000)
                {
                    long filesize = fs.Length / 1000000;
                    this.Dispatcher.Invoke(() =>
                    {
                        FileSizeCheck.Content = System.Convert.ToString(filesize) + "MB";
                    });
                }
                else
                {
                    long filesize = fs.Length / 1000;
                    this.Dispatcher.Invoke(() =>
                    {
                        FileSizeCheck.Content = System.Convert.ToString(filesize) + "KB";
                    });
                }
                this.Dispatcher.Invoke(() =>
                {
                    cc.Content = "Your Bug Report is from " + fs.CreationTime;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    cc.Content = "You Have No Bug Reports";
                    FileSizeCheck.Content = "If you find one, make sure to report it though!";
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
                    myShadowColor.R = 0;
                    myDropShadowEffect.Direction = 0;
                    myDropShadowEffect.ShadowDepth = 0;

                    myDropShadowEffect.Color = myShadowColor;
                    BugReport.Effect = myDropShadowEffect;
                });
            }
        }

    }
}
