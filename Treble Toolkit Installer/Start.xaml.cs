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

namespace Treble_Toolkit_Installer
{
    /// <summary>
    /// Interação lógica para Start.xam
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Website);
            thread.Start();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Uninstall(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Uninstall.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Repair(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Reinstall.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Install(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Install.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        //Threading starts here (YAG-dev - 20/1/22@02:02)
        private void Animate()
        {
            this.Dispatcher.Invoke(() =>
            {
                GridMain.Opacity = 0;
                Grid r = (Grid)GridMain;
                DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                r.BeginAnimation(Grid.OpacityProperty, animation);
            });
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
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-down-dark.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-settings-dark.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-trash-dark.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-web-dark.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-cross-dark.png"));
                }
                else
                {
                    BtnImg.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-down-light.png"));
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-settings-light.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-trash-light.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-web-light.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-cross-light.png"));
                }
            });
        }
    }
}
