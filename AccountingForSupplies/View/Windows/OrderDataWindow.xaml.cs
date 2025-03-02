﻿using AccountingForSupplies.AppData;

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
    /// Логика взаимодействия для OrderDataWindow.xaml
    /// </summary>
    public partial class OrderDataWindow : Window
    {
        Order currentOrder;
        List<OrderStatus> _orders = App.context.OrderStatus.ToList(); 
        public OrderDataWindow(Order order)
        {
            InitializeComponent();

            OrderStatusCmb.ItemsSource = _orders;
            OrderStatusCmb.SelectedValue = order.OrderStatusId;
            currentOrder = order;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            currentOrder.OrderStatusId = Convert.ToInt32(OrderStatusCmb.SelectedValue);
            App.context.SaveChanges();
            FeedbackService.Information("Статус заказа успешно изменен!");
        }
    }
}
