using Arc.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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
            SongLyrics.Add(new SongLyric());
            SongLyrics.Add(new SongLyric());
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
