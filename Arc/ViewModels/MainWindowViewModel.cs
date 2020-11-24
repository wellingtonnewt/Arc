using Arc.UserControls;
using Arc.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Arc.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainMenuItem> MenuItems { get; set; }

        public MainWindowViewModel()
        {
            MenuItems = new ObservableCollection<MainMenuItem>();

            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary(new ViewModels.SongLibraryViewModel(new SongData("Random Nmae", "nalskdnlaks")))));
            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary(new ViewModels.SongLibraryViewModel(new SongData("d", "d")))));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
