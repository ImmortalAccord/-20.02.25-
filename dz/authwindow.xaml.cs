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

namespace dz
{
    /// <summary>
    /// Логика взаимодействия для authwindow.xaml
    /// </summary>
    public partial class authwindow : Window
    {
        AuthService _authService = new AuthService();

        public authwindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = TbxLogin.Text;
            string pass = TbxPass.Text;

            if (_authService.CheckData(login, pass))
            {
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
            }
            else
            {
                MessageBox.Show("Ошибка ввода логина или пароля. Проверьте значения");
            }
        }
    }
}
