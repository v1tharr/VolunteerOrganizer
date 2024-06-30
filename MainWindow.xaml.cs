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

namespace Hoz_Shop
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VolunteerDBEntities conn = new VolunteerDBEntities();
            string Login;
            Users select = conn.Users.Where(c => c.Username == tblog.Text && c.Password == tb2.Password).FirstOrDefault();
            if (String.IsNullOrWhiteSpace(tblog.Text) || String.IsNullOrWhiteSpace(tb2.Password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (select != null)
            {
                if (tblog.Text == select.Username && tb2.Password == select.Password && select.Role == "user")
                {
                    
                    this.Hide();
                    Window1 window1 = new Window1(tblog.Text);
                    window1.ShowDialog();
                }
                if (tblog.Text == select.Username && tb2.Password == select.Password && select.Role == "admin")
                {
                    string role = select.Role;
                    this.Hide();
                    Window2 window2 = new Window2(tblog.Text);
                    window2.ShowDialog();
                }
            }
            else MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
