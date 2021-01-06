using Arc.ViewModels;
using Arc.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _viewModel = new SongLibraryViewModel();
            DataContext = _viewModel;
            InitializeComponent();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(songList.ItemsSource);
            view.Filter = SongFilter;
        }

        private bool SongFilter(object item)
        {
            if (String.IsNullOrEmpty(songSearch.Text))
                return true;
            else if(songSearch.Text.StartsWith("*"))
                return (item as SongData).Author.Contains(songSearch.Text.Replace("*",""), StringComparison.OrdinalIgnoreCase);
            else if (songSearch.Text.StartsWith("."))
                return (item as SongData).Lyric.Any(x => x.Text.Contains(songSearch.Text.Replace(".", ""), StringComparison.OrdinalIgnoreCase));
            else
                return (item as SongData).Title.Contains(songSearch.Text, StringComparison.OrdinalIgnoreCase);
            }

        private void songSearchFilter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.Songs).Refresh();
        }

        private void songList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_viewModel.IsInEditMode)
            {
                SongData selectedSong = _viewModel.SongData;
                _viewModel.SongData = selectedSong;
                (sender as ListBox).SelectedItem = null;
            }
            else
            {
                if (e.AddedItems.Count == 0)
                    return;
                SongData selectedItem = (SongData)e.AddedItems[0];
                _viewModel.SongData = selectedItem;
                _viewModel.SongLyrics.Clear();

                foreach (SongLyric lyric in selectedItem.Lyric)
                {
                    _viewModel.SongLyrics.Add(lyric);
                }
            }
           
        }
    }
}
