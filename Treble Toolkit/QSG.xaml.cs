﻿using System;
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
using System.IO;
using System.Windows.Media.Animation;
using System.Threading;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for QSG.xaml
    /// </summary>
    public partial class QSG : Page
    {
        public QSG()
        {
            InitializeComponent();
            Thread thread = new Thread(Animate);
            thread.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CompatibilityCheck.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("AboutScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click2(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBootloaderTut.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click4(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FlashingGSITUT.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click5(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FlashingVendorTUT.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click6(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRP.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click7(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ZipSideloaderTUT.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click8(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("PMTUT.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void WidgetTutorial(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Widgets.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void WidgetSetup(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("WidgetSetupGuide.xaml", UriKind.Relative);
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
    }
}
