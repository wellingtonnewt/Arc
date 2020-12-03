using Arc.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace Arc.ViewModels
{
    public class SongLibraryViewModel : INotifyPropertyChanged
    {


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

            SongLyrics.Add(new SongLyric());
            SongLyrics.Add(new SongLyric());
        }

        void ProcessDirectory()
        {
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
    }
}
