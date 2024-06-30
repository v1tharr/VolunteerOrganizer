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

namespace Hoz_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        VolunteerDBEntities conn = new VolunteerDBEntities();
        public Window4()
        {
            InitializeComponent();
            EventsRed.ItemsSource = conn.Events.ToList();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Events)EventsRed.SelectedItem).EventID;
            Events select = conn.Events.Where(c => c.EventID == id).FirstOrDefault();
            if (Addmer1.Text != "" && Addcateg2.Text != "" && AddPlace.Text != "" && AddData.SelectedDate != null && Addstatus.Text != "")
            {
                if (select != null)
                {

                    select.EventName = Convert.ToString(Addmer1.Text);
                    select.Category = Convert.ToString(Addcateg2.Text);
                    select.Location = Convert.ToString(AddPlace.Text);
                    select.EventDate = Convert.ToDateTime(AddData.SelectedDate);
                    select.Status = Convert.ToString(Addstatus.Text);
                    conn.SaveChanges();
                    EventsRed.ItemsSource = conn.Events.ToList();
                }
            }
        }
        
        private void EventsRed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EventsRed.SelectedIndex != -1)
            {
                string cell1 = ((Events)EventsRed.SelectedItem).EventName;
                Addmer1.Text = cell1;
                string cell2 = ((Events)EventsRed.SelectedItem).Category;
                Addcateg2.Text = cell2;
                string cell3 = ((Events)EventsRed.SelectedItem).Location;
                AddPlace.Text = cell3;
                DateTime cell4 = ((Events)EventsRed.SelectedItem).EventDate;
                AddData.SelectedDate = Convert.ToDateTime(cell4);
                string cell5 = ((Events)EventsRed.SelectedItem).Status;
                Addstatus.Text = cell5;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EventsRed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}