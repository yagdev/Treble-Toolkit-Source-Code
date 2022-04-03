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
using System.Windows.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para ResetAll.xam
    /// </summary>
    public partial class ResetAll : Page
    {
        public ResetAll()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void BackAbout_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Settings.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Reset);
            thread.Start();
        }
        //Threading starts here -- 11/3/2022@19:34, YAG-dev, 22.4+
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
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-dark.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-dark.png"));
                }
                else
                {
                    DeviceInfoImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                    DeviceInfoImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-restart-light.png"));
                    DeviceInfoImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/gui;Component/tt-retry-light.png"));
                }
            });
        }
        private void Reset()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings & cd Settings & del * /f /q";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
