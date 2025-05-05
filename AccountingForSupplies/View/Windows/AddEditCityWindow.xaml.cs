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
    /// Логика взаимодействия для AddEditCityWindow.xaml
    /// </summary>
    public partial class AddEditCityWindow : Window
    {
        City currentCity { get; set; }
        public AddEditCityWindow()
        {
            InitializeComponent();

            AcceptBtn.Visibility = Visibility.Collapsed;
        }
        public AddEditCityWindow(int id)
        {
            InitializeComponent();

            AddBtn.Visibility = Visibility.Collapsed;
            currentCity = App.context.City.FirstOrDefault(c => c.Id == id);
            LoginTbx.DataContext = currentCity;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            currentCity.Name = LoginTbx.Text;
            App.context.SaveChanges();
            FeedbackService.Information("Данные успешно изменены!");
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                City newCity = new City
                {
                    Name = LoginTbx.Text,
                };
                App.context.City.Add(newCity);
                App.context.SaveChanges();
                FeedbackService.Information("Город успешно добавлен!");
                Close();
            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex.Message);
            }

        }
    }
}
