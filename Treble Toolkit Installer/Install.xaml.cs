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
    /// Interação lógica para Install.xam
    /// </summary>
    public partial class Install : Page
    {
        public Install()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
            Thread thread2 = new Thread(UpdateUI);
            thread2.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("InstallingCF.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void AppData(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("InstallingAD.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void PF(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("InstallingPF.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Start.xaml", UriKind.Relative);
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
        private void UpdateUI()
        {
            Dispatcher dis = Dispatcher.CurrentDispatcher;
            this.Dispatcher.Invoke(() =>
            {
                if (SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme == SourceChord.FluentWPF.ElementTheme.Dark)
                {
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-dark.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-dark.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-dark.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-restart-dark.png"));
                    BtnImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-down-dark.png"));
                }
                else
                {
                    BtnImg_Copy.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-light.png"));
                    BtnImg_Copy1.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-light.png"));
                    BtnImg_Copy2.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-folder-light.png"));
                    BtnImg_Copy3.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-restart-light.png"));
                    BtnImg_Copy4.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/Treble Toolkit Installer;Component/tt-down-light.png"));
                }
            });
        }
    }
}
