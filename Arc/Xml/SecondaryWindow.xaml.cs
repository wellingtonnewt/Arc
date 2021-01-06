using Arc.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arc.Xml
{
    /// <summary>
    /// Interaction logic for SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        private SongLibraryViewModel _viewModel;

        public SecondaryWindow()
        {
            _viewModel = new SongLibraryViewModel();
            DataContext = _viewModel;
            InitializeComponent();

            Screen s = Screen.AllScreens[1];

            if (Screen.AllScreens.Length > 1)
            {
                System.Drawing.Rectangle r = s.WorkingArea;
                Top = r.Top;
                Left = r.Left;
            }

           // SizeToContent = SizeToContent.WidthAndHeight;


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
