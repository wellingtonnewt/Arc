using Arc.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Arc.Xml;
using Arc.ViewModels;

namespace Arc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            MainMenu.SelectedIndex = 0;
        }
    }
}
