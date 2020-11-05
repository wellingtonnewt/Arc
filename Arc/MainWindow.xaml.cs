using Arc.UserControls;
using System.Collections.Generic;
using System.Windows;


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
        }

        void MenuItemMethod()
        {
            MenuItems = new List<MainMenuItem>();

            MenuItems.Add(new MainMenuItem("/Resources/Images/Music_White.png", new SongLibrary()));

        }
    }
}
