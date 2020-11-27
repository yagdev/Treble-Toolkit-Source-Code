using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TrebleToolkit5
{
    /// <summary>
    /// Interaction logic for PMFlash.xaml
    /// </summary>
    public partial class PMFlash : Page
    {
        public PMFlash()
        {
            InitializeComponent();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            const string strCmdText = "/C adb.exe sideload PM.zip";
            Process.Start("CMD.exe", strCmdText);
            Uri uri = new Uri("FlashFinished.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomePage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
