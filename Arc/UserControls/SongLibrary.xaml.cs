using Arc.ViewModels;
using Arc.Xml;
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
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(songList.ItemsSource);
            view.Filter = SongFilter;
        }

        private void lyricChange(object sender, SelectionChangedEventArgs e)
        {

        }
        private bool SongFilter(object item)
        {
            if (String.IsNullOrEmpty(songSearch.Text))
                return true;
            else
                return (item as SongData).Title.Contains(songSearch.Text);
        }

        private void songSearchFilter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.Songs).Refresh();
        }
    }
}
