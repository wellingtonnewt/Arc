﻿using Arc.ViewModels;
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
            _viewModel = new SongLibraryViewModel();
            DataContext = _viewModel;
            InitializeComponent();
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
                return (item as SongData).Title.Contains(songSearch.Text,StringComparison.OrdinalIgnoreCase);
        }

        private void songSearchFilter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(_viewModel.Songs).Refresh();
        }

        private void songList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        
        private void SongAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Songs.Add(new SongData("Hello", "Adell") 
            {
                Lyric = new List<SongLyric>()
                { 
                    new SongLyric() 
                    { 
                        Text = "test"
                    } 
                }
            });
            SongData lastSong = _viewModel.Songs[_viewModel.Songs.Count - 1];
            _viewModel.SongData = lastSong;
            lastSong.Save();

            _viewModel.SongLyrics.Clear();

            foreach (SongLyric lyric in lastSong.Lyric)
            {
                _viewModel.SongLyrics.Add(lyric);
            }
        }

        private void SongDelete_Click(object sender, RoutedEventArgs e)
        {
            SongData selectedItem =(songList.SelectedItem as SongData);
            selectedItem.Delete();
            _viewModel.Songs.Remove(selectedItem);
            _viewModel.SongData = null;
        }
    }
}
