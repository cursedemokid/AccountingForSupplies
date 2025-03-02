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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        List<Order> _orders = App.context.Order.ToList();
        List<OrderProduct> _orderProduct = App.context.OrderProduct.ToList();
        List<OrderStatus> _orderStatuses = App.context.OrderStatus.ToList();
        public OrdersPage()
        {
            InitializeComponent();

            OrdersLv.ItemsSource = _orders;
            _orderStatuses.Insert(0, new OrderStatus() { Name = "Все статусы" });
            FilterByOrderStatusCmb.ItemsSource = _orderStatuses;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderStatus selectedOrderStatus = FilterByOrderStatusCmb.SelectedItem as OrderStatus;
            var filteredOrders = _orders.Where(ord => (FilterByDateDp.SelectedDate == null || FilterByDateDp.SelectedDate.Value.Date == ord.Date) && (selectedOrderStatus.Name == "Все статусы" || selectedOrderStatus.Name == ord.OrderStatus.Name));
            OrdersLv.ItemsSource = filteredOrders;
        }


        private void AddEditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage());
        }

        private void DeleteOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FeedbackService.Question("Вы уверены, что хотите удалить заказ?") == MessageBoxResult.Yes)
            {

                Order order = OrdersLv.SelectedItem as Order;
                foreach (OrderProduct orderProduct in _orderProduct)
                {
                    if (orderProduct.OrderId == order.Id)
                    {
                        App.context.OrderProduct.Remove(orderProduct);
                    }
                }
                App.context.Order.Remove(order);
                App.context.SaveChanges();
                FeedbackService.Information("Заказ удален");
            }


        }

        private void OrderDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = OrdersLv.SelectedItem as Order;
            if (order != null)
            {
                OrderDataWindow orderDataWindow = new OrderDataWindow(order);
                orderDataWindow.ShowDialog();
            }
            else
            {
                FeedbackService.Warning("Вы не выбрали заказ! Выберите заказ в списке и повторите попытку");
            }
        }
    }
}
