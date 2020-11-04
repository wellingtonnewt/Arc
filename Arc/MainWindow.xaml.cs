using System.Collections.Generic;
using Arc.Xml;
using System.Windows;
using Arc.UserControls;

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
            FillMenuList();
            InitializeComponent();
            MenuItemsListBox.SelectedIndex = 0;

        }

        private void FillMenuList()
        {
            MenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem("/Resources/Images/Music_White.png",new SongLibrary())
            };
        }
    }
}
