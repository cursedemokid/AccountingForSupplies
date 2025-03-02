using AccountingForSupplies.AppData;

using Microsoft.Win32;

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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            CategoryCmb.ItemsSource = App.context.Category.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void AddSourceBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ImageSourceTbx.Text = ofd.FileName;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CostTbx.Text != null && NameTbx.Text != null && CategoryCmb.SelectedItem != null)
            {

                try
                {
                    Product product = new Product()
                    {
                        Name = NameTbx.Text,
                        CategoryId = Convert.ToInt32(CategoryCmb.SelectedValue),
                        Cost = Convert.ToDecimal(CostTbx.Text),
                        Image = ImageSourceTbx.Text,
                    };
                    App.context.Product.Add(product);
                    App.context.SaveChanges();
                    FeedbackService.Information("Товар успешно добавлен!");
                    ClearText();
                }
                catch (Exception ex)
                {
                    FeedbackService.Error(ex);
                }
            }
            else
            {
                FeedbackService.Warning("Не все обязательные поля заполнены! Заполните все обязательные поля и повторите попытку");
            }
        }

        public void ClearText()
        {
            CostTbx.Text = string.Empty;
            ImageSourceTbx.Text = string.Empty;
            NameTbx.Text = string.Empty;
            CategoryCmb.SelectedItem = null;
        }
    }
}
