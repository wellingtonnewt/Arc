using Arc.Xml;
using System;
using System.Collections.Generic;
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

        public SongLibraryViewModel(SongData songData)
        {
            SongData = songData;
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
