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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegexThingWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WarningDialog warningDialog = new();
            ExceptionMessage ed = new();
            string regex = tbRegex.Text;
            string sample = tbSample.Text;
            if (regex == String.Empty && sample == String.Empty)
            {
                warningDialog.Show();
                warningDialog.WarningHeader.Content = "Regex and Sample fields are empty";
                warningDialog.WarningBody.Content = "Please fill out Regex and Sample fields to continue";
                tbRegex.Focus();
            }
            else if (regex == String.Empty)
            {
                warningDialog.Show();
                warningDialog.WarningHeader.Content = "Regex field is empty";
                warningDialog.WarningBody.Content = "Please fill out Regex field to continue";
                tbRegex.Focus();
            }
            else if (sample == String.Empty)
            {
                warningDialog.Show();
                warningDialog.WarningHeader.Content = "Sample field is empty";
                warningDialog.WarningBody.Content = "Please fill out Sample field to continue";
                tbSample.Focus();
            }
            
            try {
                string[] res = Regex.Split(sample, regex);
            }catch(Exception ex)
            {
                string title = ex.GetType().Name;
                string body = ex.Message;
                ed.Show();
                SystemSounds.Exclamation.Play();
                ed.ExceptionType.Content = title;
                ed.ExceptionBody.Text = body;
            }

        }
        
    }
}
