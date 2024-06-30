using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hoz_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        VolunteerDBEntities conn = new VolunteerDBEntities();
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Events AddEvents = new Events();
            if (Addmer1.Text != "" && Addcateg2.Text != "" && AddPlace.Text != "" && AddData.SelectedDate != null && Addstatus.Text != "")
            {
                DateTime datatime1 = Convert.ToDateTime(AddData.SelectedDate);
                AddEvents.EventName = Addmer1.Text;
                AddEvents.Category = Addcateg2.Text;
                AddEvents.Location = AddPlace.Text;
                AddEvents.EventDate = datatime1;
                AddEvents.Status = Addstatus.Text;
                conn.Events.Add(AddEvents);
                conn.SaveChanges();
                System.Windows.MessageBox.Show("Мероприятие успешно добавлено");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
