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
    /// Interaction logic for FlashTWRP.xaml
    /// </summary>
    public partial class FlashTWRP : Window
    {
        public FlashTWRP()
        {
            InitializeComponent();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            const string strCmdText = "/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir TWRP & cd TWRP & ren *.img twrp.img & cd .. & cd .. & cd assets & fastboot.exe flash recovery ../Place_Files_Here/TWRP/twrp.img & fastboot.exe reboot";
            Process.Start("CMD.exe", strCmdText);
            var win2 = new FlashFinished();
            win2.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new TWRP();
            win2.Show();
            this.Close();
        }
    }
}
