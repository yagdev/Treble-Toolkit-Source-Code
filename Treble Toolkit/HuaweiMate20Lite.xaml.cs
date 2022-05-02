using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for HuaweiMate20Lite.xaml
    /// </summary>
    public partial class HuaweiMate20Lite : Page
    {
        public HuaweiMate20Lite()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }
        private void DSF_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Mate20LDSF.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibleDevices.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UpdateAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start https://www.tudocelular.com/Huawei/fichas-tecnicas/n4812/Huawei-Mate-20-Lite.html";
            process.StartInfo = startInfo;
            process.Start();
        }
        //Threading starts here (YAG-dev, 5/4/2022@01:01, 22.5+)
        private void UpdateUI()
        {
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-cpu-dark.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-storage-dark.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-battery-dark.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-dark.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-gsi-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-cpu-light.png"));
                    DeviceInfoImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-storage-light.png"));
                    DeviceInfoImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                    DeviceInfoImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-battery-light.png"));
                    DeviceInfoImg_Copy5.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy6.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-more-light.png"));
                    DeviceInfoImg_Copy7.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-phone-light.png"));
                }
            });
        }
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
    }
}
