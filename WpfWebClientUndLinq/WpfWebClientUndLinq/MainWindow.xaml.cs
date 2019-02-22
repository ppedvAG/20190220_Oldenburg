using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;

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

            suchTb.KeyUp += (s, e) =>
            {
                if (e.Key == Key.Enter)
                    LoadJSON(null, null);
            };


            suchTb.SelectAll();
            suchTb.Focus();
        }

        IEnumerable<Volumeinfo> bücher;

        private void LoadJSON(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                var json = wc.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}");
                jsonTb.Text = json;

                BookResult result = JsonConvert.DeserializeObject<BookResult>(json);
                bücher = result.items.Select(x => x.volumeInfo);
                myGrid.ItemsSource = bücher;
            }
        }

        private void Sortieren(object sender, RoutedEventArgs e)
        {
            var query = from b in bücher
                        where b.publisher != null && !b.publisher.StartsWith("pearson", System.StringComparison.CurrentCultureIgnoreCase)
                        orderby b.publisher, b.pageCount
                        select b;

            //myGrid.ItemsSource = query.ToList();

            //linq lamba
            myGrid.ItemsSource = bücher.Where(b => b.publisher != null &&
                                                  !b.publisher.StartsWith("pearson", System.StringComparison.CurrentCultureIgnoreCase))
                                                  .OrderBy(b => b.publisher)
                                                  .ThenBy(b => b.pageCount)
                                                  .ToList();

        }

        private void MeistenSeiten(object sender, RoutedEventArgs e)
        {
        https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
            //🍺🍺🍺🍺🍺🍺🍺
            //🍻🍻
            //👨‍👨‍👧‍👦👨‍🌵🌵
            var summe = bücher.Sum(x => x.pageCount);

            var result = bücher.OrderByDescending(x => x.pageCount).FirstOrDefault();

            MessageBox.Show(result.title.ToString());
        }
    }
}
