using System;
using System.Windows;

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
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
