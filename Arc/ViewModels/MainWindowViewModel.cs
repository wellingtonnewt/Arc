﻿using Arc.UserControls;
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

            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary()));
            MenuItems.Add(new MainMenuItem("/Resources/Images/Bible_White.png", new Bible()));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
