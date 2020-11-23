using Arc.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Arc.Xml;

namespace Arc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<MainMenuItem> MenuItems { get; set; }

        public MainWindow()
        {
            MenuItemMethod();
            InitializeComponent();

            SongData songData = new SongData();
            songData.Title = "test";
            songData.Author = "Newt Welch";
            songData.Save("test.xml");
        }

        void MenuItemMethod()
        {
            MenuItems = new List<MainMenuItem>();

            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary()));
            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary()));
        }
    }
}
