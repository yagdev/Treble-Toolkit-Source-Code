using System.Windows;
using System.IO;
using System;

namespace Treble_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string IsTransparent = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "NotTransparent.txt");
            if (File.Exists(IsTransparent))
            {
                var newForm = new MainWindow2();
                newForm.Show();
                this.Close();
            }
            else
            {
                
            }
            string IsTransparent2 = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "TransparentTheme.txt");
            if (File.Exists(IsTransparent2))
            {
                var newForm = new MainWindow3();
                newForm.Show();
                this.Close();
            }
            else
            {

            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
