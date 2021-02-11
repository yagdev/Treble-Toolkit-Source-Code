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
    /// Interaction logic for FlashAConfirmation.xaml
    /// </summary>
    public partial class FlashAConfirmation : Page
    {
        public FlashAConfirmation()
        {
            InitializeComponent();
            Flash1.Visibility = Visibility.Visible;
            Flash2.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets & fastboot.exe format system & fastboot.exe format boot & fastboot.exe format userdata & fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img & fastboot.exe flash system ../Place_Files_Here/GSI/system.img & fastboot.exe reboot & cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
            Process.Start("CMD.exe", strCmdText);
            Uri uri = new Uri("FlashFinished.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("FlashAFileSetup.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Flash2.Visibility = Visibility.Visible;
            Flash1.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Flash1.Visibility = Visibility.Visible;
            Flash2.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            const string strCmdText = "/C adb.exe reboot-bootloader & cd .. & mkdir Place_Files_Here & cd Place_Files_Here & mkdir boot & cd boot & ren *.img boot.img & cd .. & mkdir GSI & cd GSI & ren *.img system.img & cd .. & mkdir vbmeta & cd vbmeta & ren *.img vbmeta.img & cd .. & cd .. & cd assets & fastboot.exe format system & fastboot.exe format userdata & fastboot.exe --disable-verity --disable-verification flash vbmeta ../Place_Files_Here/vbmeta/vbmeta.img & fastboot.exe flash boot ../Place_Files_Here/boot/boot.img & fastboot.exe flash system ../Place_Files_Here/GSI/system.img & fastboot.exe reboot & cd .. & cd Place_Files_Here & mkdir boot & mkdir GSI & mkdir vbmeta & taskkill /f /im adb.exe";
            Process.Start("CMD.exe", strCmdText);
            Uri uri = new Uri("FlashFinished.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
