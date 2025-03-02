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
    /// Логика взаимодействия для OrderAcceptWindow.xaml
    /// </summary>
    public partial class OrderAcceptWindow : Window
    {
        List<Client> _clients = App.context.Client.ToList();
        public OrderAcceptWindow()
        {
            InitializeComponent();
            ClientCmb.ItemsSource = _clients;
        }

        private void AcceptOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AddressTbx.Text) != true || ClientCmb.SelectedItem != null)
            {

                Order order = new Order()
                {
                    EmployeeId = App.CurrentEmployee.Id,
                    ClientId = Convert.ToInt32(ClientCmb.SelectedValue),
                    Date = DateTime.Now,
                    Address = AddressTbx.Text,
                    OrderStatusId = 1
                };
                App.context.Order.Add(order);
                DialogResult = true;
            }
            {
                FeedbackService.Warning("не все поля запонены! Заполните все поля и повторите попытку");
            }
        }
    }
}
