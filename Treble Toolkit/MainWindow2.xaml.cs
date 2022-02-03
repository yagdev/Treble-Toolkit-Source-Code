using System;
using System.Windows;
using System.IO;

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
            string Dark = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "DarkTheme.txt");
            string Light = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\", "UpdateInfo", "Settings", "LightTheme.txt");
            if (File.Exists(Dark))
            {
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Dark;
            }
            else
            {
                if (File.Exists(Light))
                {
                    SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Light;
                }
                else
                {
                    if (SourceChord.FluentWPF.SystemTheme.AppTheme == SourceChord.FluentWPF.ApplicationTheme.Dark)
                    {
                        SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Dark;
                    }
                    else
                    {
                        SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Light;
                    }
                }
            }
        }
    }
}
