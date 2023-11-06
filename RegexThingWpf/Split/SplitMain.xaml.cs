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
    public partial class SplitMain : Window
    {
        public SplitMain()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string smpl = tbSample.Text;
            string rgx = tbRegex.Text;
            if (string.IsNullOrEmpty(rgx) || string.IsNullOrEmpty(smpl))
            {
                SplitWarningDialog dialog = new();
                dialog.Show();
                SystemSounds.Beep.Play();
                dialog.WarningHeader.Content = "Fill out every field";
                dialog.WarningBody.Content = "One or more field is empty";
            }
            else
            {
                try
                {
                    string[] res = Regex.Split(smpl, rgx);
                    string r = "";
                    foreach (string s in res)
                    {
                        r += $"{s}\r\n";
                    }
                    ResultsTB.Text = r;
                }
                catch (Exception ex)
                {
                    SplitExceptionMessage ed = new SplitExceptionMessage();
                    string title = ex.GetType().Name;
                    string body = ex.Message;
                    ed.Show();
                    SystemSounds.Exclamation.Play();
                    ed.ExceptionType.Content = title;
                    ed.ExceptionBody.Text = body;
                }
            }



        }

        private void BackImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
