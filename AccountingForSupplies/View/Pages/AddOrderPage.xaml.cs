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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        List<Order> _orders = App.context.Order.ToList();
        List<Product> _products = App.context.Product.ToList();
        List<Category> _categories = App.context.Category.ToList();
        public AddOrderPage()
        {
            InitializeComponent();

            ProductsLv.ItemsSource = _products;
            _categories.Insert(0, new Category() { Name = "Все категории" });
            FilterByCategoryCmb.ItemsSource = _categories;
        }

        private void DeleteUnitProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            OrderProduct orderProduct = button.DataContext as OrderProduct;
            orderProduct.Quantity--;
            orderProduct.TotalCost = orderProduct.Product.Cost * orderProduct.Quantity;
            Grid grid = button.Parent as Grid;
            TextBox textBox = grid.Children.OfType<TextBox>().FirstOrDefault(tB => tB.Name == "QuantityTb");
            if (textBox.Text != "0")
            {
                TextBlock textBlock = grid.Children.OfType<TextBlock>().FirstOrDefault(tBl => tBl.Name == "TotalCostTbl");
                textBox.Text = orderProduct.Quantity.ToString();
                textBlock.Text = orderProduct.TotalCost.ToString();
            }
            else
            {
                FeedbackService.Warning("Количество товара не может быть меньше 0");
                orderProduct.Quantity = 0;
            }
        }

        private void QuantityTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddUnitProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            OrderProduct orderProduct = button.DataContext as OrderProduct;
            orderProduct.Quantity++;
            orderProduct.TotalCost = orderProduct.Product.Cost * orderProduct.Quantity;
            Grid grid = button.Parent as Grid;
            TextBox textBox = grid.Children.OfType<TextBox>().FirstOrDefault(tB => tB.Name == "QuantityTb");
            TextBlock textBlock = grid.Children.OfType<TextBlock>().FirstOrDefault(tBl => tBl.Name == "TotalCostTbl");
            textBox.Text = orderProduct.Quantity.ToString();
            textBlock.Text = orderProduct.TotalCost.ToString();
        }

        private void ProductsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = ProductsLv.SelectedItem as Product;
            if (selectedProduct != null)
            {
                int orderId = _orders.Max(order => order.Id);
                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderId = orderId + 1,
                    ProductId = selectedProduct.Id,
                    Quantity = 1,
                    Product = selectedProduct,
                    TotalCost = selectedProduct.Cost
                };
                OrderProductLb.Items.Add(orderProduct);
            }
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OrderAcceptWindow orderAcceptWindow = new OrderAcceptWindow();
                if (orderAcceptWindow.ShowDialog() == true)
                {
                    foreach (OrderProduct orderProduct in OrderProductLb.Items)
                    {
                        if (orderProduct.Quantity != 0)
                        {
                            App.context.OrderProduct.Add(orderProduct);
                        }
                    }
                    FeedbackService.Information("Заказ успешно добавлен");
                    App.context.SaveChanges();
                }
                else
                {
                    FeedbackService.Error("Заказ не был создан");
                }
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }
        }

        private void FilterByCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = FilterByCategoryCmb.SelectedItem as Category;
            ProductsLv.ItemsSource = _products.Where(p => p.CategoryId == category.Id || category.Name == "Все категории");
        }
    }
}
