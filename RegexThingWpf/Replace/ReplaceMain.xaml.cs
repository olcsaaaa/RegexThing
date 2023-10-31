using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
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

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            string rgx = tbRegex.Text;
            string smpl = tbSample.Text;
            string rplc = tbReplacement.Text;
            if (string.IsNullOrEmpty(rgx) || string.IsNullOrEmpty(smpl) || string.IsNullOrEmpty(rplc))
            {
                ReplaceWarningDialog dialog = new();
                dialog.Show();
                SystemSounds.Beep.Play();
                dialog.WarningHeader.Content = "Fill out every field";
                dialog.WarningBody.Content = "One or more field is empty";
            }
            try
            {
                ResultsTB.Text = Regex.Replace(smpl, rgx, rplc);
            }catch (Exception ex)
            {
                ReplaceExceptionMessage rem = new();
                rem.Show();
                SystemSounds.Exclamation.Play();
                rem.ExceptionType.Content = ex.GetType();
                rem.ExceptionBody.Text = ex.Message;
                tbRegex.Focus();
            }
        }
    }
}
