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

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for TWRPBootFinished.xaml
    /// </summary>
    public partial class TWRPBootFinished : Page
    {
        public TWRPBootFinished()
        {
            InitializeComponent();
        }

        private void ReportBug_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("TWRPBoot.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HomeScreen.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
