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

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for FlashingGSITUT.xaml
    /// </summary>
    public partial class FlashingGSITUT : Page
    {
        public FlashingGSITUT()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("QSG.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("UnlockBootloaderTut.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIABFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DeviceSpecificFeatures_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("GSIAFlash.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}