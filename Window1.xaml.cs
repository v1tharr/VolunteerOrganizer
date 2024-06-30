using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hoz_Shop
{
    public partial class Window1 : System.Windows.Window
    {
        decimal sum_shopping = 0;
        VolunteerDBEntities conn = new VolunteerDBEntities();
        string loginUser;
        public Window1(string parametr)
        {
            InitializeComponent();
            loginUser   = parametr;
            EventsUser.ItemsSource = conn.Events.ToList();
            Users select = conn.Users.Where(c => c.Username == loginUser).FirstOrDefault();
            List <Events> Eventss = conn.Events.ToList();
            List<Events> ListEvents = new List<Events>();
            List<UserEvents> Event = conn.UserEvents.Where(c=> c.UserID==select.UserID).ToList();
            foreach (UserEvents Item in Event )
            {
                foreach (Events Item1 in Eventss)
                {
                   if (Item.EventID==Item1.EventID)
                    {
                        if (Item1.Status == "Выполнено")
                            ListEvents.Add(Item1);
                    }
                }
            }
            vpzadachi.ItemsSource=ListEvents.ToList();
            uservera.Items.Add("Выполнено");
            uservera.Items.Add("Назначено");
            uservera.SelectedItem = "Назначено";
        }
        private void AddToShoppingBox(object sender, RoutedEventArgs e)
        {
            int id = ((Events)EventsUser.SelectedItem).EventID;
            Users user = conn.Users.Where(c => c.Username == loginUser).FirstOrDefault();
            Events select1 = conn.Events.Where(c => c.EventID == id).FirstOrDefault();
            if (EventsUser.SelectedIndex != -1)
            {
                if (select1 != null)
                {
                    select1.Status = Convert.ToString(uservera.SelectedItem);
                    EventsUser.ItemsSource=conn.Events.ToList();
                    UserEvents newEvents = new UserEvents();
                    newEvents.EventID = id;
                    newEvents.UserID = user.UserID;
                    newEvents.Status = select1.Status;
                    conn.UserEvents.Add(newEvents);
                    Users select = conn.Users.Where(c => c.Username == loginUser).FirstOrDefault();
                    List<Events> Eventss = conn.Events.ToList();
                    List<Events> ListEvents = new List<Events>();
                    List<UserEvents> Event = conn.UserEvents.Where(c => c.UserID == select.UserID).ToList();
                    foreach (UserEvents Item in Event)
                    {
                        foreach (Events Item1 in Eventss)
                        {
                            if (Item.EventID == Item1.EventID)
                            {
                                if (Item1.Status == "Выполнено")
                                ListEvents.Add(Item1);
                            }
                        }
                    }
                    vpzadachi.ItemsSource = ListEvents.ToList();
                    conn.SaveChanges();
                }
            }
        }
        private void EventsUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EventsUser.SelectedIndex!= -1)
            {
                int id = ((Events)EventsUser.SelectedItem).EventID;
            }
        }
    }
}
