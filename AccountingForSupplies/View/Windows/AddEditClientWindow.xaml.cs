using AccountingForSupplies.AppData;

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

namespace AccountingForSupplies.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        Client client { get; set; }
        List<Client> _clients = App.context.Client.ToList();
        public AddEditClientWindow()
        {
            InitializeComponent();

            CompanyCmb.ItemsSource = App.context.Company.ToList();
        }

        public AddEditClientWindow(int id)
        {
            InitializeComponent();

            client = _clients.FirstOrDefault(c => c.Id == id);
            CompanyCmb.ItemsSource = App.context.Company.ToList();
            CompanyCmb.SelectedValue = client.CompanyId;
            MainGrid.DataContext = client;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client newClient = new Client
                {
                    Surname = SurnameTbx.Text,
                    FirstName = FirstNameTbx.Text,
                    MiddleName = MiddleNameTbx.Text,
                    Email = EmailTbx.Text,
                    PhoneNumber = PhoneNumberTbx.Text,
                    CompanyId = Convert.ToInt32(CompanyCmb.SelectedValue),
                };

                App.context.Client.Add(newClient);
                App.context.SaveChanges();
                DialogResult = true;
                Close();
                FeedbackService.Error("Сотрудник с таким логином уже существует! Поменяйте логин и попробуйте заново");
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            client.FirstName = FirstNameTbx.Text;
            client.Email = EmailTbx.Text;
            client.Surname = SurnameTbx.Text;
            client.MiddleName = MiddleNameTbx.Text;
            client.PhoneNumber = PhoneNumberTbx.Text;
            client.CompanyId = Convert.ToInt32(CompanyCmb.SelectedValue);
            App.context.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}
