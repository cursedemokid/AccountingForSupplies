﻿using AccountingForSupplies.AppData;
using AccountingForSupplies.View.Pages;

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

namespace AccountingForSupplies
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

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void BaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentEmployee.PositionId != 3)
            {
                FeedbackService.Error("У Вас недостаточно прав для открытия этой страницы!");
            }
            else
            {
                MainFrame.Navigate(new BasePage());
            }
        }
    }
}
