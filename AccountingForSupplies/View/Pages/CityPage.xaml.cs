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
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
        List<City> _cities = App.context.City.ToList();
        public CityPage()
        {
            InitializeComponent();

            CitiesLV.ItemsSource = _cities;
        }

        private void SearchByNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(SearchByNameTbx.Text))
            {
                CitiesLV.ItemsSource = _cities;
            }
            else
            {

                CitiesLV.ItemsSource = _cities.Where(c => c.Name == SearchByNameTbx.Text).ToList();
            }
        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCityWindow addEditCityWindow = new AddEditCityWindow();
            addEditCityWindow.ShowDialog();
           
        }

        private void EditCityBtn_Click(object sender, RoutedEventArgs e)
        {
            City selectedCity = CitiesLV.SelectedItem as City;
            if (selectedCity != null)
            {
                AddEditCityWindow addEditCityWindow = new AddEditCityWindow(selectedCity.Id);
                addEditCityWindow.ShowDialog();
            }
        }

        private void DeleteCityBtn_Click(object sender, RoutedEventArgs e)
        {
            City selectedCity = CitiesLV.SelectedItem as City;
            if (selectedCity != null)
            {
                if (FeedbackService.Question("Вы уверены что хотите удалить запись?") == MessageBoxResult.Yes)
                {
                    App.context.City.Remove(selectedCity);
                    App.context.SaveChanges();
                    FeedbackService.Information("Город удален");
                }
            }
        }
    }
}
