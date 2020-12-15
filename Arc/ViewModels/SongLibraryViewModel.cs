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

        public void SaveSong()
        {
            Console.WriteLine("Saving song "+_songData.Title+ " to file.");
            _songData.Save();
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
                Songs.Remove(selectedItem);
                SongData = null;
            }
        }

        private void DiscardSong_Click(object sender)
        {
            SongData selectedItem = Songs[Songs.Count - 1];
            SongData = selectedItem;
            selectedItem.Delete();
            Songs.Remove(selectedItem);
            SongData = null;
        }
        private void SaveSong_Click(object sender)
        {
            IsInEditMode = false;

            SongData lastSong = Songs[Songs.Count - 1];

            Songs.RemoveAt(Songs.Count - 1);
            Songs.IndexOf(lastSong);

            SongData = lastSong;
            lastSong.Save();
        }
    }
}
