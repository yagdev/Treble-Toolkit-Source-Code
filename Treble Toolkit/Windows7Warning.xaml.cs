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
using System.IO;
using System.Diagnostics;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for Windows7Warning.xaml
    /// </summary>
    public partial class Windows7Warning : Page
    {
        public Windows7Warning()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cd .. & cd .. & mkdir UpdateInfo & cd UpdateInfo & mkdir Settings";
            process.StartInfo = startInfo;
            process.Start();
            string W7 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "W7.txt");
            using (StreamWriter sw = File.CreateText(W7))
            {
                sw.WriteLine("Treble Toolkit Windows Versions Earlier Than 10 Warning Confirmation");
                sw.WriteLine("©2021 YAG-dev");
            }
            string FTU = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "FirstTimeUse.txt");
            if (File.Exists(FTU)) 
            {
                Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                Uri uri = new Uri("QuickStartGuide.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
