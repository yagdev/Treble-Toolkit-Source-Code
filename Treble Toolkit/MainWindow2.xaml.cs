using System;
using System.Windows;

namespace Treble_Toolkit
{
    /// <summary>
    /// Lógica interna para MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
