using AccountingForSupplies.AppData;
using AccountingForSupplies.View.Windows;

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

namespace AccountingForSupplies.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        List<Client> _clients = App.context.Client.ToList();
        public ClientPage()
        {
            InitializeComponent();

            ClientsLV.ItemsSource = _clients;
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditClientWindow addEditClientWindow = new AddEditClientWindow();
            if (addEditClientWindow.ShowDialog() == true)
            {
                FeedbackService.Information("Новый клиент успешно добавлен!");
                ClientsLV.ItemsSource = _clients;
            }
        }

        private void EditEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = ClientsLV.SelectedItem as Client;
            AddEditClientWindow addEditClientWindow = new AddEditClientWindow(selectedClient.Id);
            if (selectedClient != null)
            {
                if (addEditClientWindow.ShowDialog() == true)
                {
                    FeedbackService.Information("Данные клиента успешно изменены!");
                    ClientsLV.ItemsSource = _clients;
                }
                else
                {
                    FeedbackService.Error("Данные работника не изменены");
                }

            }
        }

        private void DeleteEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = ClientsLV.SelectedItem as Client;
            if (selectedClient != null)
            {
                if (FeedbackService.Question("Вы уверены что хотите удалить клиента?") == MessageBoxResult.Yes)
                {

                    App.context.Client.Remove(selectedClient);
                    App.context.SaveChanges();
                    FeedbackService.Information("Клиент удален");
                    ClientsLV.ItemsSource = _clients;
                }
            }
        }

        private void SearchByInitialsTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchByInitialsTbx.Text))
            {
                ClientsLV.ItemsSource = _clients.Where(c => c.FirstName == SearchByInitialsTbx.Text || c.MiddleName == SearchByInitialsTbx.Text || c.Surname == SearchByInitialsTbx.Text);
            }
            else
            {
                ClientsLV.ItemsSource = _clients;
            }
        }
    }
}
