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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingForSupplies.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        List<Product> _products = App.context.Product.ToList();
        List<Category> _categories = App.context.Category.ToList();
        public ProductsPage()
        {
            InitializeComponent();

            ProductsLv.ItemsSource = _products;
            _categories.Insert(0, new Category() { Name = "Все категории" });

            FilterByCategoryCmb.ItemsSource = _categories;
        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsLv.SelectedItem != null)
            {
                if (FeedbackService.Question("Вы уверены, что хотите удалить товар из списка?") == MessageBoxResult.Yes)
                {
                    Product product = ProductsLv.SelectedItem as Product;
                    App.context.Product.Remove(product);
                    App.context.SaveChanges();
                }
                else
                {
                    ProductsLv.SelectedItem = null;
                }
            }
        }

        private void AddEditProductBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }


        private void ProductsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void FilterByCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category selectedCategory = FilterByCategoryCmb.SelectedItem as Category;
            var filteredProducts = _products.Where(p => p.Category.Name == selectedCategory.Name || selectedCategory.Name == "Все категории").ToList();
            ProductsLv.ItemsSource = filteredProducts;
        }
    }
}
