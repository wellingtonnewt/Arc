using Arc.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arc.UserControls
{

    public partial class SongLibrary : UserControl
    {
        public SongLibrary(SongLibraryViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
