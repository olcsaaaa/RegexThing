using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegexThingWpf
{
    /// <summary>
    /// Interaction logic for SplitMain.xaml
    /// </summary>
    public partial class ReplaceMain : Window
    {
        public ReplaceMain()
        {
            InitializeComponent();
        }

        private void BackImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
