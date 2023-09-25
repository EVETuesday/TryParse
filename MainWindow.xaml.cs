using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
using HtmlAgilityPack;

namespace TryParse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathG;
        public MainWindow(string path)
        {
            try
            {

            
            InitializeComponent();
            pathG = path;
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDocument = htmlWeb.Load(path);
            HtmlNodeCollection htmlNodes = htmlDocument.DocumentNode.SelectNodes("//img");
            //ObservableCollection<string> words = SubsringTag(htmlDocument.Text, '<','>');
            ObservableCollection<Im> im = new ObservableCollection<Im>();

            if (htmlNodes!=null)
            {            
                foreach (var htmlNode in htmlNodes)
                {
                    Im im1 = new Im();
                    string image1 = htmlNode.GetAttributeValue("src","");
                    Image image = new Image();
                    try
                    {
                        image.Source = new BitmapImage(new Uri(image1));
                        image.Stretch = Stretch.Fill;
                        im1.Source = image1;
                        im.Add(im1);
                    }
                    catch 
                    {

                    }
                    
                    
                }
                lvImages.ItemsSource = im;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Im im = button.DataContext as Im;
            FulWindow fulWindow = new FulWindow(im, this);
            fulWindow.Show();
            Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AddPath addPath = new AddPath(pathG);
            addPath.Show();
            Close();
        }


        ObservableCollection<string> SubsringTag(string text, char startTag,char endTag)
        {
            int i = 0;
            string[] words = text.Split(startTag);
            ObservableCollection<string> wordsF = new ObservableCollection<string>();
            foreach (var item in words)
            {
                string[] w = item.Split(endTag);
                wordsF.Add(w[0]);
            }
            return wordsF;
        }

        //public static async Task<HtmlDocument> AsyncLoad(string path)
        //{
        //    await Task.Delay(5);
        //    HtmlWeb htmlWeb = new HtmlWeb();
        //    HtmlDocument htmlDocument = htmlWeb.Load(path);
        //    htmlWeb.LoadFromWebAsync(path).RunSynchronously();

        //    return htmlDocument2;

        //}

    }
    public class Im
    {
        public  string Source { get; set; }
    }
}
