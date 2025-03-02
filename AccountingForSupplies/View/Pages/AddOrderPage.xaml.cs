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
        List<Product> _products = App.context.Product.ToList();
        public AddOrderPage()
        {
            InitializeComponent();

            ProductsLv.ItemsSource = _products;
        }

        private void DeleteUnitProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuantityTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddUnitProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
