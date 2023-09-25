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

namespace TryParse
{
    /// <summary>
    /// Логика взаимодействия для AddPath.xaml
    /// </summary>
    public partial class AddPath : Window
    {
        public AddPath()
        {
            InitializeComponent();
        }
        public AddPath(string path)
        {
            InitializeComponent();
            tbTextPath.Text = path;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTextPath.Text))
            {
                MainWindow mainWindow = new MainWindow(tbTextPath.Text);
                mainWindow.Show();
                Close();
            }
        }
    }
}
