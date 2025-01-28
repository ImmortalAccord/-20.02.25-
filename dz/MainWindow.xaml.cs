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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<IProduct> _products = new List<IProduct>();
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            {
                var newProduct = new Product();
                newProduct.Name = Tovar.Text;
                if (decimal.TryParse(Price.Text, out decimal price))
                {
                    newProduct.Price = price;
                    _products.Add(newProduct);
                    List_Tovars.ItemsSource = null;
                    List_Tovars.ItemsSource = _products;
                }
                else
                {
                    MessageBox.Show("Неправильный ввод цены");
                }
            }
        }
    }
}
