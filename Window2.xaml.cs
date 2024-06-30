using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Hoz_Shop
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string role2; 
        string login_ = "";
        VolunteerDBEntities conn = new VolunteerDBEntities();
        List<string> finman1 = new List<string>();
        public Window2(string a)
        {
            login_ = a;
            InitializeComponent();
            Events.ItemsSource = conn.Events.ToList();
            FinancialManagement.ItemsSource = conn.FinancialManagement.ToList();
            StartupCapital.ItemsSource = conn.StartupCapital.ToList();
            StartupCapital.CanUserDeleteRows = false;
            StartupCapital.AutoGenerateColumns = false;
            int i = 0;
            List<Events> finman2 = conn.Events.ToList();
            foreach (Events item in finman2)
            {
                finman1.Add(item.EventName);
            }
            ComboMer.ItemsSource = finman1.ToList();
        }
        private void but_addz(object sender, RoutedEventArgs e)
        {
            FinancialManagement AddFinance = new FinancialManagement();
            if (tbvyd.Text != "" && tbpotr.Text != "")
            {
                StartupCapital capital = conn.StartupCapital.First();
                decimal residue = capital.Amount - Convert.ToDecimal(tbvyd.Text);
                if (residue > 0)
                {
                    Events select = conn.Events.Where(c => c.EventName == ComboMer.Text).FirstOrDefault();
                    AddFinance.EventID = select.EventID;
                    AddFinance.AllocatedAmount = Convert.ToInt32(tbvyd.Text);
                    AddFinance.SpentAmount = Convert.ToInt32(tbpotr.Text);
                    conn.FinancialManagement.Add(AddFinance);
                    conn.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно добавлено!");
                    FinancialManagement.ItemsSource = conn.FinancialManagement.ToList();
                    StartupCapital capital2 = conn.StartupCapital.First();
                    capital2.Amount = residue;
                    StartupCapital.ItemsSource = conn.StartupCapital.ToList();
                }
                else MessageBox.Show("Недостаточное количество денег в фонде, пожалуйста, укажите меньше");
            }
        }
        
        private void but_redz(object sender, RoutedEventArgs e)
        {
            if (tbvyd.Text != "" && tbpotr.Text != "")
            {
                int id = ((FinancialManagement)FinancialManagement.SelectedItem).ID;
                FinancialManagement select = conn.FinancialManagement.Where(c => c.ID == id).FirstOrDefault();
                if (select != null)
                {
                    StartupCapital capital = conn.StartupCapital.First();
                    decimal residue = capital.Amount - Convert.ToDecimal (tbvyd.Text);
                    if (residue > 0)
                    {
                        Events select3 = conn.Events.Where(c => c.EventName == ComboMer.Text).FirstOrDefault();
                        select.EventID = select3.EventID;
                        select.AllocatedAmount = Convert.ToDecimal(tbvyd.Text);
                        select.SpentAmount = Convert.ToDecimal(tbpotr.Text);
                        conn.SaveChanges();
                        FinancialManagement.ItemsSource = conn.FinancialManagement.ToList();
                        StartupCapital capital2 = conn.StartupCapital.First();
                        capital2.Amount = residue;
                        StartupCapital.ItemsSource = conn.StartupCapital.ToList();
                    }
                    else MessageBox.Show("Недостаточное количество денег в фонде, пожалуйста, укажите меньше");
                }

            }
        }

        private void delete_user(object sender, RoutedEventArgs e)
        {
            if (FinancialManagement.SelectedIndex != -1)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Подтвердите действие", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    int cell = ((FinancialManagement)FinancialManagement.SelectedItem).ID;
                    FinancialManagement select = conn.FinancialManagement.Where(c => c.ID == cell).FirstOrDefault();
                    conn.FinancialManagement.Remove(select);
                    conn.SaveChanges();
                    FinancialManagement.ItemsSource = conn.FinancialManagement.ToList();
                    System.Windows.MessageBox.Show("Действие выполнено", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else System.Windows.MessageBox.Show("Выберите элемент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void add_tovar(object sender, RoutedEventArgs e)
        {
            Window3 a = new Window3();
            this.Hide(); 
            a.ShowDialog(); 
            this.Show();    
        }

        private void red_tovar_sklad(object sender, RoutedEventArgs e)
        {
            int id = ((StartupCapital)StartupCapital.SelectedItem).StartupID;
            StartupCapital select = conn.StartupCapital.Where(c => c.StartupID == id).FirstOrDefault();
            if (tbcapit.Text != "")
            {
                if (select != null)
                {

                    select.Amount = Convert.ToDecimal(tbcapit.Text);
                    conn.SaveChanges();
                    StartupCapital.ItemsSource = conn.StartupCapital.ToList();
                }
            }
        }
    

        private void red_tovar_magaz(object sender, RoutedEventArgs e)
        {
            Window4 a = new Window4();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
        private void del_tov_sklad(object sender, RoutedEventArgs e)
        {
            VolunteerDBEntities conn = new VolunteerDBEntities();

            if (StartupCapital.SelectedIndex != -1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Подтвердите действие", "Внимание!", (MessageBoxButtons)MessageBoxButton.OKCancel, (MessageBoxIcon)MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    int cell = ((StartupCapital)StartupCapital.SelectedItem).StartupID;
                    StartupCapital select = conn.StartupCapital.Where(c => c.StartupID == cell).FirstOrDefault();
                    conn.StartupCapital.Remove(select);
                    conn.SaveChanges();
                    StartupCapital.ItemsSource = conn.StartupCapital.ToList();
                    MessageBox.Show("Действие выполнено", "Внимание", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Information);
                }
            }
            else MessageBox.Show("Выберите элемент", "Ошибка", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Error);
        }
       
        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            VolunteerDBEntities conn = new VolunteerDBEntities();
            Events.ItemsSource = conn.Events.Where(C => C.EventName.Contains(tbx.Text) ||
            C.Location.ToString().Contains(tbx.Text)).ToList();
        }
        private void ComboMer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComboMer.SelectedIndex != -1)
            {
                string eventname = ComboMer.SelectedItem.ToString();
            }
            else MessageBox.Show("Выберите в списке товаров товар", "Внимание!", (MessageBoxButtons)MessageBoxButton.OK, (MessageBoxIcon)MessageBoxImage.Warning);
        }
        private void FinancialManagement_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            decimal AllAmount = ((FinancialManagement)FinancialManagement.SelectedItem).AllocatedAmount;
            tbvyd.Text = AllAmount.ToString();
            decimal AddEvents1 = ((FinancialManagement)FinancialManagement.SelectedItem).EventID;
            Events select3 = conn.Events.Where(c => c.EventID == AddEvents1).FirstOrDefault();
            ComboMer.SelectedItem = select3.EventName;
            decimal SpAmount = ((FinancialManagement)FinancialManagement.SelectedItem).SpentAmount;
            tbpotr.Text = SpAmount.ToString(); 
        }

        private void StartupCapital_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            decimal CapAmount = ((StartupCapital)StartupCapital.SelectedItem).Amount;
            tbcapit.Text = CapAmount.ToString();
        }
    }

}