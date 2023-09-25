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
using static System.Net.Mime.MediaTypeNames;

namespace TryParse
{
    /// <summary>
    /// Логика взаимодействия для FulWindow.xaml
    /// </summary>
    public partial class FulWindow : Window
    {
        MainWindow mainWindow1;
        public FulWindow(Im im, MainWindow mainWindow)
        {
            InitializeComponent();
            mainWindow1 = mainWindow;
            imImage.Source = new BitmapImage(new Uri(im.Source));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            mainWindow1.Visibility = Visibility.Visible;
        }
    }
}
