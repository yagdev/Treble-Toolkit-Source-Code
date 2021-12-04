using System;
using System.Windows;
using System.IO;

namespace Treble_Toolkit
{
    /// <summary>
    /// Lógica interna para MainWindow3.xaml
    /// </summary>
    public partial class MainWindow3 : Window
    {
        public MainWindow3()
        {
            InitializeComponent();
            if (Environment.OSVersion.Version.Build <= 9)
            {
                string W7 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "W7.txt");
                if (File.Exists(W7)) { }
                else
                {
                    ContentFrame.Navigate(new Uri("Windows7Warning.xaml", UriKind.Relative));
                }
            }
            else
            {
                string FTU = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "FirstTimeUse.txt");
                if (File.Exists(FTU)) { }
                else
                {
                    ContentFrame.Navigate(new Uri("QuickStartGuide.xaml", UriKind.Relative));
                }
            }
        }
    }
}
