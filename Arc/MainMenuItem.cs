using System.Windows.Controls;

namespace Arc
{
    public class MainMenuItem
    {
        public string IconPath { get; set; }
        public UserControl Control { get; set; }
        
        public MainMenuItem(string iconPath, UserControl control)
        {
            IconPath = iconPath;
            Control = control;
        }
    }
}
