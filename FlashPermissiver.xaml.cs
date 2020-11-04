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
using System.Windows.Shapes;

namespace TrebleToolkitReloaded
{
    /// <summary>
    /// Interaction logic for FlashPermissiver.xaml
    /// </summary>
    public partial class FlashPermissiver : Window
    {
        public FlashPermissiver()
        {
            InitializeComponent();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            const string strCmdText = "/C adb.exe sideload PM.zip";
            Process.Start("CMD.exe", strCmdText);
            var win2 = new FlashFinished();
            win2.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new MainWindow();
            win2.Show();
            this.Close();
        }
    }
}
