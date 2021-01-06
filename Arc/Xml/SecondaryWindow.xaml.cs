using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arc.Xml
{
    /// <summary>
    /// Interaction logic for SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        public SecondaryWindow()
        {
            InitializeComponent();

            //if (Screen.AllScreens.Length == 1)
           // {
              //  Screen screen = Screen.AllScreens[0];

             //   System.Drawing.Rectangle r = screen.WorkingArea;
              //  this.Left = r.Left;
              //  this.Top = r.Top;
            //}
        }
    }
}
