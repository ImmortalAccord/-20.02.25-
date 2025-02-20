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
using dz;

namespace dz
{
    public partial class MainWindow : Window
    {
        private ShopEntities dbContext;
        private string Description;

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new ShopEntities();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List_Tovars.ItemsSource = dbContext.Products.ToList();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = Tovar.Text;
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (!decimal.TryParse(Price.Text, out decimal productPrice))
                {
                    MessageBox.Show("Введите корректную цену товара.");
                    return;
                }

                TextBox productNameTextBox = (TextBox)Tovar;
                string TovarName = Tovar.Text;

                var newProduct = new Product
                {
                    Name = productName,
                    Price = productPrice,
                    Description = Description
                };

                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();

                LoadProducts();
                Tovar.Clear();
                Price.Clear();
                TextBox Name = (TextBox)Tovar;
                productNameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }
    }
}