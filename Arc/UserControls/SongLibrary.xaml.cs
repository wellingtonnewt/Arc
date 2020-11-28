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
        private SongLibraryViewModel _viewModel;

        public SongLibrary()
        {
            InitializeComponent();
            _viewModel = new SongLibraryViewModel();
            DataContext = _viewModel;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Content is string content)
                {
                    if (content.Equals("EDIT"))
                    {
                        //TODO make title and author editable

                        button.Content = "SAVE";
                    } else if (content.Equals("SAVE"))
                    {
                        //TODO make title and author not editable

                        _viewModel.SaveSong();
                        button.Content = "EDIT";
                    }
                }
            }
        }
    }
}
