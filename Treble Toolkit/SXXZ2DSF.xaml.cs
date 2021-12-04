using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interação lógica para OnePlus6DSF.xam
    /// </summary>
    public partial class SXXZ2DSF : Page
    {
        public SXXZ2DSF()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
        }

        private void HM10L_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Download);
            thread.Start();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Value = e.ProgressPercentage;
            });
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                status_pgr.Visibility = Visibility.Hidden;
                BackAbout.Content = "Download Finished";
            });
        }

        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("SonyXperia1.xaml", UriKind.Relative);
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
        private void Download()
        {
            using (WebClient wc = new WebClient())
            {
                string TWRPDownloadLocationTemp = System.IO.Path.Combine(Environment.CurrentDirectory, @"..", "Place_Files_Here", "TWRP", "twrp.img");
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        BackAbout.IsEnabled = false;
                        BackAbout.Content = "Starting Download...";
                        BackAbout.FontSize = 16;
                        status_pgr.Visibility = Visibility.Visible;
                    });
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                        webClient.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1iWzrS-5tdOLYcRXInF_a54IPaXalkecq"), TWRPDownloadLocationTemp);
                    }
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        BackAbout.Content = "You need an internet connection for this...";
                        BackAbout.FontSize = 10;
                    });
                }
            }
        }
    }
}
