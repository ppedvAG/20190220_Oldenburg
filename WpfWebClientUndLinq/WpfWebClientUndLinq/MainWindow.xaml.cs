using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfWebClientUndLinq
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

        private void LoadJSON(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("https://www.googleapis.com/books/v1/volumes?q=c#");
                jsonTb.Text = json;
            }
        }
    }
}
