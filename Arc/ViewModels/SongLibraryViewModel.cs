using Arc.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Arc.Helpers;

namespace Arc.ViewModels
{
    public class SongLibraryViewModel : INotifyPropertyChanged
    {
        private bool _isInEditMode;

        public bool IsInEditMode
        {
            get
            {
                return _isInEditMode;
            }
            set
            {
                _isInEditMode = value;
                OnPropertyChanged("IsInEditMode");
                OnPropertyChanged("IsInEditModeButton");
                OnPropertyChanged("IsNotInEditModeButton");
            }
        }

        public Visibility IsInEditModeButton
        {
            get
            {
                if (_isInEditMode)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public Visibility IsNotInEditModeButton
        {
            get
            {
                if (_isInEditMode)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public ICommand NewClick { get; set; }
        public ICommand DeleteClick { get; set; }
        public ICommand SaveClick { get; set; }
        public ICommand DiscardClick { get; set; }
        public ICommand AddLyric { get; set; }
        public ICommand EditClick { get; set; }
        public ICommand SaveEditClick { get; set; }
        public ICommand DiscardEditClick { get; set; }

        private SongData _songData;

        public SongData SongData {
            get {
                return _songData;
            }
            set{
                _songData = value;
                OnPropertyChanged("SongData");
            } 
        }

        public ObservableCollection<SongData> Songs { get; set; }

        public ObservableCollection<SongLyric> SongLyrics { get; set; }
        public ObservableCollection<SongLyric> prevSongLyric { get; set; }

        public SongLibraryViewModel()
        {
            SongLyrics = new ObservableCollection<SongLyric>();
            Songs = new ObservableCollection<SongData>();

            ProcessDirectory();

            if (Songs.Count > 0)
            {
                SongData = Songs[0];
                foreach (SongLyric lyric in SongData.Lyric)
                {
                    SongLyrics.Add(lyric);
                }
            }

            NewClick = new RelayCommand(o => NewSong_Click(o));
            DeleteClick = new RelayCommand(o => DeleteSong_Click(o));
            DiscardClick = new RelayCommand(o => DiscardSong_Click(o));
            SaveClick = new RelayCommand(o => SaveSong_Click(o));
            AddLyric = new RelayCommand(o => Add_Lyric(o));
            EditClick = new RelayCommand(o => Edit_Click(o));
            SaveEditClick = new RelayCommand(o => SaveEdit_Click(o));
            DiscardEditClick = new RelayCommand(o => DiscardEdit_Click(o));

        }

        void ProcessDirectory()
        {
            if (!Directory.Exists("Songs"))
            {
                Directory.CreateDirectory("Songs");
            }

            string[] files = Directory.GetFiles("Songs");

            foreach (string filePath in files)
            {
                Songs.Add(SongData.Load(filePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NewSong_Click(object sender)
        {
            IsInEditMode = true;

            Songs.Add(new SongData("Title", "Author")
            {
                Lyric = new List<SongLyric>()
                {
                    new SongLyric()
                    {
                       Text = "Verse 1"
                    }
                }
            });

            SongData lastSong = Songs[Songs.Count - 1];
            SongData = lastSong;

            SongLyrics.Clear();

            foreach (SongLyric lyric in lastSong.Lyric)
            {
                SongLyrics.Add(lyric);
            }
        }

        private void DeleteSong_Click(object sender)
        {
            SongData selectedItem = SongData;
            if (selectedItem != null)
            {
                selectedItem.Delete();
                SongLyrics.Clear();
                Songs.Remove(selectedItem);
                SongData = null;
            }
        }

        private void DiscardSong_Click(object sender)
        {
            IsInEditMode = false;

            SongData selectedItem = Songs[Songs.Count - 1];
            SongData = selectedItem;
            SongLyrics.Clear();
            Songs.Remove(selectedItem);
            SongData = null;
        }

        private void SaveSong_Click(object sender)
        {
            IsInEditMode = false;

            SongData lastSong = Songs[Songs.Count - 1];
            SongData = lastSong;
            lastSong.Save();
        }

        private void Add_Lyric(object sender)
        {

            SongData selectedItem = SongData;

            selectedItem.Lyric.Add(
                    new SongLyric()
                    {
                        Text = "New Lyric"
                    });

            SongLyrics.Clear();

            foreach (SongLyric lyric in selectedItem.Lyric)
            {
                SongLyrics.Add(lyric);
            }
        }
        public SongData prevSong;

        private void Edit_Click(object sender)
        {
            prevSong = new SongData();
            SongData selectedItem = SongData;

            if (selectedItem != null)
            {
                IsInEditMode = true;
                prevSong = selectedItem.Clone();
            }
        }
        private void SaveEdit_Click(object sender)
        {
            IsInEditMode = false;
            prevSong.Delete();
            SongData selectedItem = SongData;
            selectedItem.Save();
        }
        private void DiscardEdit_Click(object sender)
        {
            IsInEditMode = false;

            SongData selectedItem = SongData;
            selectedItem.Delete();

            SongData = prevSong;
            SongLyrics.Clear();

            foreach (SongLyric lyric in prevSong.Lyric)
            {
                SongLyrics.Add(lyric);
            }
            prevSong.Save();
        }
    }
}
